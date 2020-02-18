using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 15347, 15348 )]
	public class VikingStuddedCap : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 9; } }

		public override int InitMinHits{ get{ return 30; } }
		public override int InitMaxHits{ get{ return 40; } }

		public override int AosStrReq{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Studded; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.Half; } }

		[Constructable]
		public VikingStuddedCap() : base( 15347 )
		{
                        Name = "Viking Studded Cap - (Lv. 24)";
			Weight = 2.0;
			Layer = Layer.Helm;
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

		public VikingStuddedCap( Serial serial ) : base( serial )
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