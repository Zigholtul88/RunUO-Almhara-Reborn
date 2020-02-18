using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Items
{
	public class CureLevelInfo
	{
		private Poison m_Poison;
		private double m_Chance;

		public Poison Poison
		{
			get{ return m_Poison; }
		}

		public double Chance
		{
			get{ return m_Chance; }
		}

		public CureLevelInfo( Poison poison, double chance )
		{
			m_Poison = poison;
			m_Chance = chance;
		}
	}

	public abstract class BaseCurePotion : BasePotion
	{
		public abstract CureLevelInfo[] LevelInfo{ get; }

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int RequiredLevel
		{ 
			get { return 0; }
			set {}
		}

		public override bool ForceShowProperties{ get{ return true; } }
            
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			if( RequiredLevel > 0 )
                                list.Add( 1060658, "Required Level\t{0}", RequiredLevel.ToString() );
		}

		public BaseCurePotion( PotionEffect effect ) : base( 0xF07, effect )
		{
		}

		public BaseCurePotion( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public void DoCure( Mobile from )
		{
			bool cure = false;

			CureLevelInfo[] info = LevelInfo;

			for ( int i = 0; i < info.Length; ++i )
			{
				CureLevelInfo li = info[i];

				if ( li.Poison == from.Poison && Scale( from, li.Chance ) > Utility.RandomDouble() )
				{
					cure = true;
					break;
				}
			}

			if ( cure && from.CurePoison( from ) )
			{
				from.SendLocalizedMessage( 500231 ); // You feel cured of poison!

				from.FixedEffect( 0x373A, 10, 15 );
				from.PlaySound( 0x1E0 );
			}
			else if ( !cure )
			{
				from.SendLocalizedMessage( 500232 ); // That potion was not strong enough to cure your ailment!
			}
		}

		public override void Drink( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( TransformationSpellHelper.UnderTransformation( from, typeof( Spells.Necromancy.VampiricEmbraceSpell ) ) )
			{
				from.SendLocalizedMessage( 1061652 ); // The garlic in the potion would surely kill you.
			}
			else if ( from.Poisoned )
			{
                        	if ( pm.Level >= RequiredLevel )
				{
					DoCure( from );

					BasePotion.PlayDrinkEffect( from );

					from.FixedParticles( 0x373A, 10, 15, 5012, EffectLayer.Waist );
					from.PlaySound( 0x1E0 );

					this.Consume();
				}
				else
				{
					from.SendMessage( "Your level isn't high enough to use this potion." ); 
				}
                        }
			else
			{
				from.SendLocalizedMessage( 1042000 ); // You are not poisoned.
			}
		}
	}
}