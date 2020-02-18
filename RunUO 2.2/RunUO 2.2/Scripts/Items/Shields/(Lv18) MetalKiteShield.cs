using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class MetalKiteShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 7; } }

		public override int InitMinHits{ get{ return 101; } }
		public override int InitMaxHits{ get{ return 115; } }

		public override int AosStrReq{ get{ return 35; } }

		[Constructable]
		public MetalKiteShield() : base( 0x1B74 )
		{
                        Name = "Metal Kite Shield - (Lv. 18)";
			Weight = 7.0;
			Attributes.DefendChance = 7;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 18 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 18 in order to equip this." );
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

		public MetalKiteShield( Serial serial ) : base(serial)
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
