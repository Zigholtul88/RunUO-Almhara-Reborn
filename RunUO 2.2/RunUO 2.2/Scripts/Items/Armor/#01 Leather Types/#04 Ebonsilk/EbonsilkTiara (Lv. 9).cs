using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class EbonsilkTiara : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 4; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int AosStrReq{ get{ return 15; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		[Constructable]
		public EbonsilkTiara() : base( 15862 )
		{
                        Name = "Ebonsilk Tiara - (Lv. 9)";
			Weight = 2.0;
			Layer = Layer.Helm;
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

		public EbonsilkTiara( Serial serial ) : base( serial )
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