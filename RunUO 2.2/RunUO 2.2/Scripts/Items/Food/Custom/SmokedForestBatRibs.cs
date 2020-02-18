using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Network;
using Server.Multis;
using Server.ContextMenus;

namespace Server.Items
{
	public class SmokedForestBatRibs : Food
	{
                public override double DefaultWeight
                {
                    get { return 1.0; }
                }

		[Constructable]
		public SmokedForestBatRibs() : this( 1 )
		{
		}

		[Constructable]
		public SmokedForestBatRibs( int amount ) : base( amount, 0x9F1 )
		{
                        this.Name = "Smoked Forest Bat Ribs";
			this.Hue = 1;
                        this.Stackable = true;
                        this.Amount = amount;
			this.FillFactor = 1;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !Movable )
				return;

			if ( from.InRange( this.GetWorldLocation(), 1 ) )
			{
				Eat( from );
			}

			if ( from.Mana < from.ManaMax )
			{
				from.Mana = Math.Min( from.Mana + 5, from.ManaMax);

				from.FixedParticles( 0x375A, 9, 16, 5007, EffectLayer.Waist );

				from.PlaySound( Utility.Random( 0x3A, 3 ) );
				from.PlaySound( 0x1EE );
				from.SendMessage("You've recovered 5 mana points.");
			}
			else
			{
				from.Say( "*burp!*" );
				from.PlaySound( from.Female ? 782 : 1053 );
			}
		}

		public SmokedForestBatRibs( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}