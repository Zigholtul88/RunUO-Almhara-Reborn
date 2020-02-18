using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a corpser corpse" )]
	public class Corpser : BaseCreature
	{
		[Constructable]
		public Corpser() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a corpser";
			Body = 8;
			BaseSoundID = 684;

			SetStr( 158, 180 );
			SetDex( 26, 45 );
			SetInt( 27, 40 );

			SetHits( 188, 216 );
			SetMana( 0 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 18 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 20 );

			SetSkill( SkillName.MagicResist, 15.4, 18.2 );
			SetSkill( SkillName.Tactics, 45.1, 57.0 );
			SetSkill( SkillName.Wrestling, 51.8, 61.3 );

			Fame = 10000;
			Karma = -10000;

			PackGold( 6, 15 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new ParalyzeScroll() );

			if ( 0.25 > Utility.RandomDouble() )
				PackItem( new Board( 10 ) );
			else
				PackItem( new Log( 10 ) );

			PackItem( new MandrakeRoot( 3 ) );

			PackItem( new Nirnroot( Utility.RandomMinMax( 8, 14 ) ) );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }
		public override bool DisallowAllMoves{ get{ return true; } }

		public Corpser( Serial serial ) : base( serial )
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

