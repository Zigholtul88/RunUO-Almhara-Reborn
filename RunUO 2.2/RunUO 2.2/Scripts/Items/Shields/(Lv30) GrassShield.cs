using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 14412, 14413 )]
	public class GrassShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 11; } }

		public override int InitMinHits{ get{ return 26; } }
		public override int InitMaxHits{ get{ return 52; } }

		public override int AosStrReq{ get{ return 55; } }

		[Constructable]
		public GrassShield() : base( 14412 )
		{
                        Name = "Grass Shield - (Lv. 30)";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
			Attributes.DefendChance = 11;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 30 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 30 in order to equip this." );
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

		public GrassShield( Serial serial ) : base(serial)
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
