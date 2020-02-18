using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 0x44C1, 0x44C2 )]
	public class GargoyleTailFemale : BaseWaist
	{
		[Constructable]
		public GargoyleTailFemale() : this( 0 )
		{
		}

		[Constructable]
		public GargoyleTailFemale( int hue ) : base( 0x44C1, hue )
		{
                  Name = "Gargoyle Tail Female";
			Weight = 2.0;
		}

		public override bool CanEquip( Mobile from )
		{
                  if ( from.Female == true && from.BodyValue == 667 )
			{
				return true;
			} 

			else
			{
				from.SendMessage( "Only a female gargoyle can equip this." );
				return false;
			}
		}

		public GargoyleTailFemale( Serial serial ) : base( serial )
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

