using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 0x41D8, 0x41D9 )]
	public class LeatherTalons : BaseShoes
	{
		[Constructable]
		public LeatherTalons() : this( 0 )
		{
		}

		[Constructable]
		public LeatherTalons( int hue ) : base( 0x41D8, hue )
		{
                  Name = "Leather Talons";
			Weight = 3.0;
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

		public LeatherTalons( Serial serial ) : base( serial )
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

