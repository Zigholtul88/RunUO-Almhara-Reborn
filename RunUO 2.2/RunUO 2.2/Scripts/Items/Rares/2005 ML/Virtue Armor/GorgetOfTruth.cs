using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2B0E, 0x2B0F )]
	public class GorgetOfTruth : BaseArmor
	{
		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int OldStrReq{ get{ return 30; } }
		public override int OldDexBonus{ get{ return -1; } }
		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public GorgetOfTruth() : base( 0x2B0F )
		{
                  Name = "Gorget of Truth";
			Weight = 10.0;
                  ItemID = 0x2B0F;
		}

		public GorgetOfTruth( Serial serial ) : base( serial )
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








