using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 0x4202, 0x420A )]
	public class SmallPlateShield : BaseShield, IDyable
	{
		public override int BaseColdResistance{ get{ return 2; } }

		public override int InitMinHits{ get{ return 26; } }
		public override int InitMaxHits{ get{ return 30; } }

		public override int AosStrReq{ get{ return 20; } }

		[Constructable]
		public SmallPlateShield() : base( 0x4202 )
		{
                  Name = "Small Plate Shield";
			Weight = 6.0;
			Attributes.DefendChance = 3;
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

		public SmallPlateShield( Serial serial ) : base(serial)
		{
		}

		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
