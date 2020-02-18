using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 0x50D8, 0x50D9 )]
	public class GargishHalfApron : BaseWaist
	{
		[Constructable]
		public GargishHalfApron() : this( 0 )
		{
		}

		[Constructable]
		public GargishHalfApron( int hue ) : base( 0x50D8, hue )
		{
                  Name = "Gargish Half Apron";
			Weight = 2.0;
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

		public GargishHalfApron( Serial serial ) : base( serial )
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

