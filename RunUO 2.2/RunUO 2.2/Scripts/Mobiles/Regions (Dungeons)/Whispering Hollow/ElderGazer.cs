using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an elder gazer corpse" )]
	public class ElderGazer : BaseCreature
	{
		[Constructable]
		public ElderGazer () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an elder gazer";
			Body = 22;
			BaseSoundID = 377;

			SetStr( 298, 325 );
			SetDex( 86, 101 );
			SetInt( 301, 364 );

			SetHits( 756, 890 );
			SetMana( 1505, 1820 );

			SetDamage( 4, 8 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.EvalInt, 85.8, 93.7 );
			SetSkill( SkillName.Magery, 92.1, 99.2 );
			SetSkill( SkillName.MagicResist, 118.7, 128.2 );
			SetSkill( SkillName.Tactics, 82.1, 97.5 );
			SetSkill( SkillName.Wrestling, 85.0, 97.7 );

			Fame = 18500;
			Karma = -18500;

			PackGold( 1221, 2325 );

			PackItem( new MindBlastScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );
		}

		public override int Meat{ get{ return 1; } }

		public ElderGazer( Serial serial ) : base( serial )
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