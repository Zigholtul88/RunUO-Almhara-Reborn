using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 15349, 15350 )]
	public class VikingStuddedChest : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 9; } }

		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 45; } }

		public override int AosStrReq{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.Half; } }

		[Constructable]
		public VikingStuddedChest() : base( 15349 )
		{
                        Name = "Viking Studded Chest - (Lv. 24)";
			Weight = 8.0;
			Layer = Layer.InnerTorso;
			Attributes.BonusHits = 12;
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

		public VikingStuddedChest( Serial serial ) : base( serial )
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