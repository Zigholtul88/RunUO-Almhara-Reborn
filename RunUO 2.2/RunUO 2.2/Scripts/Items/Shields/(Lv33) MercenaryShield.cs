using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 14406, 14407 )]
	public class MercenaryShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 12; } }

		public override int InitMinHits{ get{ return 78; } }
		public override int InitMaxHits{ get{ return 105; } }

		public override int AosStrReq{ get{ return 60; } }

		[Constructable]
		public MercenaryShield() : base( 14406 )
		{
                        Name = "Mercenary Shield - (Lv. 33)";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
			Attributes.DefendChance = 12;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 33 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 33 in order to equip this." );
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

		public MercenaryShield( Serial serial ) : base(serial)
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
