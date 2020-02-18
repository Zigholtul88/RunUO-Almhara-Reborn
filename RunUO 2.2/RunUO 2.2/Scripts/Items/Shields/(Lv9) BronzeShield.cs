using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class BronzeShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 4; } }

		public override int InitMinHits{ get{ return 26; } }
		public override int InitMaxHits{ get{ return 30; } }

		public override int AosStrReq{ get{ return 20; } }

		[Constructable]
		public BronzeShield() : base( 0x1B72 )
		{
                        Name = "Bronze Shield - (Lv. 9)";
			Weight = 6.0;
			Attributes.DefendChance = 4;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 9 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 9 in order to equip this." );
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

		public BronzeShield( Serial serial ) : base(serial)
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
