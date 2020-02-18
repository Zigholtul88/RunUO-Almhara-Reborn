using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 0x4200, 0x4207 )]
	public class GargishWoodenShield : BaseShield, IDyable
	{
		public override int BaseEnergyResistance{ get{ return 2; } }

		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 23; } }

		public override int AosStrReq{ get{ return 5; } }

		[Constructable]
		public GargishWoodenShield() : base( 0x4200 )
		{
                  Name = "Gargish Wooden Shield";
			Weight = 5.0;
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

		public GargishWoodenShield( Serial serial ) : base(serial)
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
