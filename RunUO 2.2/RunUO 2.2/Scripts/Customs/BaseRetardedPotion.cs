using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public abstract class BaseRetardedPotion : BasePotion
	{
		public abstract int MinHeal { get; }
		public abstract int MaxHeal { get; }
		public abstract double Delay { get; }

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

		public BaseRetardedPotion( PotionEffect effect ) : base( 0xF0C, effect )
		{
		}

		public BaseRetardedPotion( Serial serial ) : base( serial )
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

		public void DoHeal( Mobile from )
		{
			int min = Scale( from, MinHeal );
			int max = Scale( from, MaxHeal );

			from.Heal( Utility.RandomMinMax( min, max ) );
		}

		public override void Drink( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( from.Mana < from.ManaMax )
			{
                        	if ( pm.Level >= RequiredLevel )
				{
					if ( from.Poisoned || MortalStrike.IsWounded( from ) )
					{
						from.LocalOverheadMessage( MessageType.Regular, 0x22, 1005000 ); // You can not heal yourself in your current state.
					}
					else
					{
						if ( from.BeginAction( typeof( BaseHealPotion ) ) )
						{
							DoHeal( from );

							BasePotion.PlayDrinkEffect( from );

							this.Consume();

							Timer.DelayCall( TimeSpan.FromSeconds( Delay ), new TimerStateCallback( ReleaseHealLock ), from );
						}
						else
						{
							from.LocalOverheadMessage( MessageType.Regular, 0x22, 500235 ); // You must wait 10 seconds before using another healing potion.
						}
					}
                                }
				else
				{
					from.SendMessage( "Your level isn't high enough to use this potion." ); 
				}
			}
			else
			{
				from.SendLocalizedMessage( 1049547 ); // You decide against drinking this potion, as you are already at full health.
			}
		}

		private static void ReleaseHealLock( object state )
		{
			((Mobile)state).EndAction( typeof( BaseHealPotion ) );
		}
	}
}