using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
      [Flipable( 0x46B4, 0x46B5 )]
	public class GargishSash : BaseClothing
	{
		[Constructable]
		public GargishSash() : this( 0 )
		{
		}

		[Constructable]
		public GargishSash( int hue ) : base( 0x46B4, Layer.MiddleTorso, hue)
		{
                  Name = "Gargish Sash";
			Weight = 1.0;
		}

		public override bool CanEquip( Mobile from )
		{
                  if ( from.Female == false && from.BodyValue == 666 )
			{
				return true;
			} 

                  else if ( from.Female == true && from.BodyValue == 667 )
			{
				return true;
			} 

			else
			{
				from.SendMessage( "Only a gargoyle can equip this." );
				return false;
			}
		}

		public GargishSash( Serial serial ) : base( serial )
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
	}
}

