using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 15856, 15857 )]
	public class EbonsilkGloves : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 4; } }

		public override int InitMinHits{ get{ return 30; } }
		public override int InitMaxHits{ get{ return 40; } }

		public override int AosStrReq{ get{ return 15; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		[Constructable]
		public EbonsilkGloves() : base( 15856 )
		{
                        Name = "Ebonsilk Gloves - (Lv. 9)";
			Weight = 2.0;
			Layer = Layer.Gloves;
			Attributes.BonusHits = 4;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 9 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 9 in order to equip this." );
				return false;
			}
		}

		public EbonsilkGloves( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}