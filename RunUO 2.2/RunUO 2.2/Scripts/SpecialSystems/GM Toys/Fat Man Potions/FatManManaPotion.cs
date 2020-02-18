using System;
using Server;

namespace Server.Items
{
	public class FatManManaPotion : BasePotion
	{
		[Constructable]
		public FatManManaPotion() : base( 0xF03, PotionEffect.Heal )
		{
			Name = "Fat Man Sky Blue Potion";
			Hue = 1266;
		}

		public FatManManaPotion( Serial serial ) : base( serial )
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

		public override void Drink( Mobile from )
		{
			if ( from.Mana < from.ManaMax )
			{
				if ( from.BeginAction( typeof( BaseHealPotion ) ) )
				{
					from.Mana = Math.Min( from.Mana + 500, from.ManaMax);

					from.FixedParticles( 0x375A, 9, 16, 5007, EffectLayer.Waist );
				
					BasePotion.PlayDrinkEffect( from );
					from.PlaySound( 0x5C8 );
				
					this.Delete();

					Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( ReleaseHealLock ), from );
				}
				else
				{
					from.SendMessage( "You must wait 10 seconds before using another sky blue potion." );
				}
			}
			else
			{
				from.SendMessage( "You decide against drinking this potion, as you are already at full mana." ); 
			}
		}

		private static void ReleaseHealLock( object state )
		{
			((Mobile)state).EndAction( typeof( BaseHealPotion ) );
		}
	}
}