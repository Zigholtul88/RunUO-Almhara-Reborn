using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class OrderShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 20; } }

		public override int InitMinHits{ get{ return 101; } }
		public override int InitMaxHits{ get{ return 115; } }

		public override int ArmorBase{ get{ return 95; } }

		[Constructable]
		public OrderShield() : base( 0x1BC4 )
		{
                        Name = "Order Shield - (Lv. 54)";
			Weight = 7.0;
			Attributes.DefendChance = 20;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 54 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 54 in order to equip this." );
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

		public OrderShield( Serial serial ) : base(serial)
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