using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class Buckler : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 1; } }

		public override int InitMinHits{ get{ return 41; } }
		public override int InitMaxHits{ get{ return 51; } }

		public override int AosStrReq{ get{ return 5; } }

		[Constructable]
		public Buckler() : base( 0x1B73 )
		{
                        Name = "Buckler - (Lv. 1)";
			Weight = 5.0;
			Attributes.DefendChance = 1;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 1 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 1 in order to equip this." );
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

		public Buckler( Serial serial ) : base(serial)
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
