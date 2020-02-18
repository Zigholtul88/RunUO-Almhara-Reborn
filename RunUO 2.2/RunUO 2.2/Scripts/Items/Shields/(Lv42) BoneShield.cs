using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 16365, 16366 )]
	public class BoneShield : BaseShield, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 36; } }
		public override int InitMaxHits{ get{ return 44; } }

		public override int AosStrReq{ get{ return 75; } }

		[Constructable]
		public BoneShield() : base( 16365 )
		{
                        Name = "Bone Shield - (Lv. 42)";
			Weight = 6.0;
			Layer = Layer.TwoHanded;
			Attributes.DefendChance = 15;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 42 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 42 in order to equip this." );
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

		public BoneShield( Serial serial ) : base(serial)
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
