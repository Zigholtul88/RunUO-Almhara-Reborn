using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 16363, 16364 )]
	public class WoodenDragonShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 18; } }

		public override int InitMinHits{ get{ return 46; } }
		public override int InitMaxHits{ get{ return 58; } }

		public override int AosStrReq{ get{ return 90; } }

		[Constructable]
		public WoodenDragonShield() : base( 16363 )
		{
                        Name = "Wooden Dragon Shield - (Lv. 51)";
			Weight = 5.0;
			Layer = Layer.TwoHanded;
			Attributes.DefendChance = 18;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 51 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 51 in order to equip this." );
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

		public WoodenDragonShield( Serial serial ) : base(serial)
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
