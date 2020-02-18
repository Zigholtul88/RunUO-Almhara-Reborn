using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a papyrus vine corpse" )]
	public class PapyrusVine : BaseCreature
	{
		[Constructable]
		public PapyrusVine() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a papyrus vine";
			Body = 8;
			Hue = 1167;
			BaseSoundID = 684;

			SetStr( 456, 580 );
			SetDex( 26, 45 );
			SetInt( 526, 540 );

			SetHits( 494, 608 );

			SetDamage( 10, 23 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 15 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 99.1, 100.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 15.5, 25.0 );
			SetSkill( SkillName.Tactics, 80.1, 90.0 );
			SetSkill( SkillName.Wrestling, 80.1, 90.0 );

			Fame = 5000;
			Karma = -5000;

                        PackGold( 100, 500 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.MedScrolls, 2 );
			AddLoot( LootPack.Potions, 1 );
		}

		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }
		public override bool DisallowAllMoves{ get{ return true; } }

		public PapyrusVine( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 352 )
				BaseSoundID = 684;
		}
	}
}
