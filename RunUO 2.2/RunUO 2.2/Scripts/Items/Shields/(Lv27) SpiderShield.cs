using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 14408, 14409 )]
	public class SpiderShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 10; } }

		public override int InitMinHits{ get{ return 101; } }
		public override int InitMaxHits{ get{ return 115; } }

		public override int AosStrReq{ get{ return 50; } }

		[Constructable]
		public SpiderShield() : base( 14408 )
		{
                        Name = "Spider Shield - (Lv. 27)";
			Weight = 7.0;
			Layer = Layer.TwoHanded;
			Attributes.DefendChance = 10;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 27 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 27 in order to equip this." );
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

		public SpiderShield( Serial serial ) : base(serial)
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
