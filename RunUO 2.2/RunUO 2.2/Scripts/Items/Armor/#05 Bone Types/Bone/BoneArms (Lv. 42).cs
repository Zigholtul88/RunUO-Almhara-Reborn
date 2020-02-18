using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x144e, 0x1453 )]
	public class BoneArms : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		public override int AosStrReq{ get{ return 70; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Bone; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		[Constructable]
		public BoneArms() : base( 0x144E )
		{
                        Name = "Bone Arms - (Lv. 42)";
			Weight = 2.0;
			Attributes.BonusHits = 40;
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

		public BoneArms( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}