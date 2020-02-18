using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a reapers corpse" )]
	public class Reaper : BaseCreature
	{
		[Constructable]
		public Reaper() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a reaper";
			Body = 47;
			BaseSoundID = 442;

			SetStr( 72, 201 );
			SetDex( 66, 75 );
			SetInt( 110, 235 );

			SetHits( 80, 258 );
			SetStam( 0 );
			SetMana( 550, 1175 );

			SetDamage( 9, 11 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.EvalInt, 1.5, 24.4 );
			SetSkill( SkillName.Magery, 93.2, 99.9 );
			SetSkill( SkillName.MagicResist, 105.0, 121.8 );
			SetSkill( SkillName.Tactics, 46.7, 57.0 );
			SetSkill( SkillName.Wrestling, 56.3, 63.1 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 40;

			PackGold( 17, 23 );

			PackItem( new Andalusite() );

			PackItem( new Nirnroot( Utility.RandomMinMax( 11, 16 ) ) );

			if ( 0.25 > Utility.RandomDouble() )
				PackItem( new Board( 10 ) );
			else
				PackItem( new Log( 10 ) );

			PackItem( new MandrakeRoot( 5 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override bool DisallowAllMoves{ get{ return true; } }

		public Reaper( Serial serial ) : base( serial )
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