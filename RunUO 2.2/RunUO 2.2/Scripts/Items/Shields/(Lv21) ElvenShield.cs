using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 16361, 16362 )]
	public class ElvenShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 8; } }

		public override int InitMinHits{ get{ return 46; } }
		public override int InitMaxHits{ get{ return 58; } }

		public override int AosStrReq{ get{ return 40; } }

		[Constructable]
		public ElvenShield() : base( 16361 )
		{
                        Name = "Elven Shield - (Lv. 21)";
			Weight = 5.0;
			Layer = Layer.TwoHanded;
			Attributes.DefendChance = 8;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 21 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 21 in order to equip this." );
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

		public ElvenShield( Serial serial ) : base(serial)
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
