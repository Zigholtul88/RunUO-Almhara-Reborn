using System;
using Server.Items;

namespace Server.Items
{
	public class BreathingApparatus : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 1; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 37; } }

		public override int AosStrReq{ get{ return 10; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		[Constructable]
		public BreathingApparatus() : base( 0x277A )
		{
                        Name = "Breathing Apparatus";
			Weight = 2.0;

			Attributes.BonusStam = 4;
		}

		public BreathingApparatus( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}