using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a gargoyle corpse" )]
	public class Gargoyle : BaseCreature
	{
		[Constructable]
		public Gargoyle() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gargoyle";
			Body = 4;
			BaseSoundID = 372;

			SetStr( 159, 175 );
			SetDex( 77, 94 );
			SetInt( 82, 100 );

			SetHits( 176, 210 );
			SetMana( 410, 500 );

			SetDamage( 7, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 32 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 15 );

			SetSkill( SkillName.EvalInt, 65.4, 73.6 );
			SetSkill( SkillName.Magery, 75.2, 86.4 );
			SetSkill( SkillName.MagicResist, 71.0, 84.1 );
			SetSkill( SkillName.Tactics, 50.6, 69.9 );
			SetSkill( SkillName.Wrestling, 53.4, 79.7 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 32;

			PackGold( 16, 20 );

			PackItem( new FishScale( Utility.RandomMinMax( 8, 13 ) ) );

			switch ( Utility.Random( 4 ))
			{
				case 0: PackItem( new Agate() ); break;
				case 1: PackItem( new ChromeDiopside() ); break;
				case 2: PackItem( new MoonstoneCustom() ); break;
				case 3: PackItem( new Opal() ); break;
			}

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new BlessScroll() );

			if ( 0.05 > Utility.RandomDouble() )
				PackItem( new GargoylesPickaxe() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override int Meat{ get{ return 1; } }

		public Gargoyle( Serial serial ) : base( serial )
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