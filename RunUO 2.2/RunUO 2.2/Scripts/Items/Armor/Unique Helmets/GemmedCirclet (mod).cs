using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x2B70, 0x3167 )]
	public class GemmedCirclet : BaseArmor
	{
		public override Race RequiredRace{ get { return Race.Elf; } }
		public override int BasePhysicalResistance{ get{ return 4; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int AosStrReq{ get{ return 10; } }
		public override int OldStrReq{ get{ return 10; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		[Constructable]
		public GemmedCirclet() : base( 0x2B70 )
		{
			Weight = 2.0;
			Attributes.BonusHits = 5;
			SkillBonuses.SetValues( 0, SkillName.MagicResist, 5.0 );
		}

		public GemmedCirclet( Serial serial ) : base( serial )
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