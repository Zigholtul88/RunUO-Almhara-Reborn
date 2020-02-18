using System;
using Server;

namespace Server.Items
{
	public class TruthGlasses : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 10; } }

		public override int AosStrReq{ get{ return 1; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }
		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }		

		[Constructable]
		public TruthGlasses() : base( 0x2FB8 )
		{
                        Name = "Truth Glasses";
			Weight = 2.0;	
		}
		public TruthGlasses( Serial serial ) : base( serial )
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
