using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x1c06, 0x1c07 )]
	public class FemaleLeatherChest : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 1; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 37; } }

		public override int AosStrReq{ get{ return 5; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		public override bool AllowMaleWearer{ get{ return false; } }

		[Constructable]
		public FemaleLeatherChest() : base( 0x1C06 )
		{
			Weight = 1.0;
			Attributes.BonusHits = 1;
		}

		public FemaleLeatherChest( Serial serial ) : base( serial )
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