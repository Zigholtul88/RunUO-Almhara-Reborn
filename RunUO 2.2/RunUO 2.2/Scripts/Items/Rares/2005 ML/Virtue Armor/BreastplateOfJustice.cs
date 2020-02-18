using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2B08, 0x2B09 )]
	public class BreastplateOfJustice : BaseArmor
	{
		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int OldStrReq{ get{ return 60; } }
		public override int OldDexBonus{ get{ return -8; } }
		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public BreastplateOfJustice() : base( 0x2B09 )
		{
                  Name = "Breastplate of Justice";
			Weight = 10.0;
		}

		public BreastplateOfJustice( Serial serial ) : base( serial )
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

			if ( Weight == 1.0 )
				Weight = 4.0;
		}
	}
}







