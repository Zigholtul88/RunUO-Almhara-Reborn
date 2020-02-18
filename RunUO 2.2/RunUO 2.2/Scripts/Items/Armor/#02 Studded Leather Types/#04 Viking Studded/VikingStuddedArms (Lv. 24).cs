using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 15345, 15346 )]
	public class VikingStuddedArms : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 9; } }

		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 45; } }

		public override int AosStrReq{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.Half; } }

		[Constructable]
		public VikingStuddedArms() : base( 15345 )
		{
                        Name = "Viking Studded Arms - (Lv. 24)";
			Weight = 4.0;
			Layer = Layer.Arms;
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

		public VikingStuddedArms( Serial serial ) : base( serial )
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