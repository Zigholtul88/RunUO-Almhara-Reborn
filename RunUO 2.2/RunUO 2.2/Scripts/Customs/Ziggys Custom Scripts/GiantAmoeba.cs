using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an amoeba corpse" )]
	public class GiantAmoeba : BaseCreature
	{
		[Constructable]
		public GiantAmoeba() : base( AIType.AI_Mage, FightMode.Closest, 15, 1, 0.175, 0.350 )
		{
			Name = "a giant amoeba";
			Body = 0x111;
                        Hue = 1166;
			BaseSoundID = 0x56E;

			SetStr( 130, 150 );
			SetDex( 120, 130 );
			SetInt( 150, 230 );

			SetHits( 150, 250 );
			SetMana( 1500, 2500 );

			SetDamage( 21, 25 );

			SetDamageType( ResistanceType.Physical, 30 );
			SetDamageType( ResistanceType.Energy, 70 );

			SetResistance( ResistanceType.Physical, 60 );
			SetResistance( ResistanceType.Fire, 40 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.Wrestling, 80.0, 85.0 );
			SetSkill( SkillName.Tactics, 80.0, 85.0 );
			SetSkill( SkillName.MagicResist, 105.0, 115.0 );
			SetSkill( SkillName.Necromancy, 90.0, 110.0 );
			SetSkill( SkillName.EvalInt, 80.0, 90.0 );
			SetSkill( SkillName.Meditation, 90.0, 100.0 );

			Fame = 6500;
			Karma = -6500;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public GiantAmoeba( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
