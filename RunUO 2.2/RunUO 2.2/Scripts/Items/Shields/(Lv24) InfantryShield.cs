using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 16359, 16360 )]
	public class InfantryShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 9; } }

		public override int InitMinHits{ get{ return 101; } }
		public override int InitMaxHits{ get{ return 115; } }

		public override int AosStrReq{ get{ return 45; } }

		[Constructable]
		public InfantryShield() : base( 16359 )
		{
                        Name = "Infantry Shield - (Lv. 24)";
			Weight = 7.0;
			Layer = Layer.TwoHanded;
			Attributes.DefendChance = 9;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 24 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 24 in order to equip this." );
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

		public InfantryShield( Serial serial ) : base(serial)
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
