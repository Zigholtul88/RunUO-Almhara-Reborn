using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class HeaterShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 21; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 37; } }

		public override int AosStrReq{ get{ return 100; } }

		[Constructable]
		public HeaterShield() : base( 0x1B76 )
		{
                        Name = "Heater Shield - (Lv. 57)";
			Weight = 8.0;
			Attributes.DefendChance = 21;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 57 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 57 in order to equip this." );
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

		public HeaterShield( Serial serial ) : base(serial)
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
