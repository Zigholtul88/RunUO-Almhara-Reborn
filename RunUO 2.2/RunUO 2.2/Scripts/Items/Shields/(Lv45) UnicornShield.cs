using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 14402, 14403 )]
	public class UnicornShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 16; } }

		public override int InitMinHits{ get{ return 58; } }
		public override int InitMaxHits{ get{ return 72; } }

		public override int AosStrReq{ get{ return 80; } }

		[Constructable]
		public UnicornShield() : base( 14402 )
		{
                        Name = "Unicorn Shield - (Lv. 45)";
			Weight = 6.0;
			Layer = Layer.TwoHanded;
			Attributes.DefendChance = 16;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 45 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 45 in order to equip this." );
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

		public UnicornShield( Serial serial ) : base(serial)
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
