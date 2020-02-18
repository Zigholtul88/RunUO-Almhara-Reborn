using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class MetalShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 5; } }

		public override int InitMinHits{ get{ return 36; } }
		public override int InitMaxHits{ get{ return 44; } }

		public override int AosStrReq{ get{ return 25; } }

		[Constructable]
		public MetalShield() : base( 0x1B7B )
		{
                        Name = "Metal Shield - (Lv. 12)";
			Weight = 6.0;
			Attributes.DefendChance = 5;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 12 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 12 in order to equip this." );
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

		public MetalShield( Serial serial ) : base(serial)
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
