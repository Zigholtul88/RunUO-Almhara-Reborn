using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 14414, 14415 )]
	public class ScarabShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 14; } }

		public override int InitMinHits{ get{ return 26; } }
		public override int InitMaxHits{ get{ return 52; } }

		public override int AosStrReq{ get{ return 70; } }

		[Constructable]
		public ScarabShield() : base( 14414 )
		{
                        Name = "Scarab Shield - (Lv. 39)";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
			Attributes.DefendChance = 14;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 39 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 39 in order to equip this." );
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

		public ScarabShield( Serial serial ) : base(serial)
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
