using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class WoodenKiteShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 6; } }

		public override int InitMinHits{ get{ return 46; } }
		public override int InitMaxHits{ get{ return 58; } }

		public override int AosStrReq{ get{ return 30; } }

		[Constructable]
		public WoodenKiteShield() : base( 0x1B79 )
		{
                        Name = "Wooden Kite Shield - (Lv. 15)";
			Weight = 5.0;
			Attributes.DefendChance = 6;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 15 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 15 in order to equip this." );
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

		public WoodenKiteShield( Serial serial ) : base(serial)
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
