using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 0x450D, 0x450D )]
	public class GargoyleTailMale : BaseWaist
	{
		[Constructable]
		public GargoyleTailMale() : this( 0 )
		{
		}

		[Constructable]
		public GargoyleTailMale( int hue ) : base( 0x450D, hue )
		{
                  Name = "Gargoyle Tail Male";
			Weight = 2.0;
		}

		public override bool CanEquip( Mobile from )
		{
                  if ( from.Female == false && from.BodyValue == 666 )
			{
				return true;
			} 

			else
			{
				from.SendMessage( "Only a male gargoyle can equip this." );
				return false;
			}
		}

		public GargoyleTailMale( Serial serial ) : base( serial )
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

