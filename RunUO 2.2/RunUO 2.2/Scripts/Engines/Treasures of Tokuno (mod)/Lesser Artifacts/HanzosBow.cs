using Server;
using System;
using Server.Misc;
using Server.Mobiles;

namespace Server.Items
{
	public class HanzosBow : Yumi
	{
		public override int LabelNumber { get { return 1070918; } } // Hanzo's Bow

		public override int InitMinHits { get { return 50; } }
		public override int InitMaxHits { get { return 55; } }

		[Constructable]
		public HanzosBow() : base()
		{
			WeaponAttributes.HitLeechHits = 40;
			WeaponAttributes.SelfRepair = 3;

			Attributes.WeaponDamage = 50;

			SkillBonuses.SetValues( 0, SkillName.Ninjitsu, 10 );
		}

		public HanzosBow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}