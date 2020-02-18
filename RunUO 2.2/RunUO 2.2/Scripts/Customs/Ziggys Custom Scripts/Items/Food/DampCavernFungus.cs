using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Network;
using Server.Gumps;
using Server.Multis;
using Server.ContextMenus;

namespace Server.Items
{
	public class DampCavernFungus : Food
	{
		[Constructable]
		public DampCavernFungus() : this( 1 )
		{
		}

		[Constructable]
		public DampCavernFungus( int amount ) : base( amount, 0x26B7 )
		{
                        Name = "Damp Cavern Fungus";
                        Hue = 2003;

			this.Weight = 0.1;
			this.FillFactor = 1;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042038 ); // You must have the object in your backpack to use it.
			}
			else if ( from.Hits < from.HitsMax )
			{
					from.Hits = Math.Min( from.Hits + 5, from.HitsMax);

					from.FixedParticles( 0x375A, 9, 16, 5007, EffectLayer.Waist );
				
				      from.PlaySound( 0x1EE );
				
				      Consume();
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}

		public DampCavernFungus( Serial serial ) : base( serial )
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
