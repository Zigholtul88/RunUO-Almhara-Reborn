using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 14404, 14405 )]
	public class AmmoniteShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 3; } }

		public override int InitMinHits{ get{ return 20; } }
		public override int InitMaxHits{ get{ return 45; } }

		public override int AosStrReq{ get{ return 15; } }

		[Constructable]
		public AmmoniteShield() : base( 14404 )
		{
                        Name = "Ammonite Shield - (Lv. 6)";
			Weight = 6.0;
			Layer = Layer.TwoHanded;
			Attributes.DefendChance = 3;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 6 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 6 in order to equip this." );
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

		public AmmoniteShield( Serial serial ) : base(serial)
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
