using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class WoodenShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 2; } }

		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 23; } }

		public override int AosStrReq{ get{ return 10; } }

		[Constructable]
		public WoodenShield() : base( 0x1B7A )
		{
                        Name = "Wooden Shield - (Lv. 3)";
			Weight = 5.0;
			Attributes.DefendChance = 2;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 3 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 3 in order to equip this." );
				return false;
			}
		}

		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public WoodenShield( Serial serial ) : base(serial)
		{
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
