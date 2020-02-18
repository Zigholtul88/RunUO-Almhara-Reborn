using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a frost troll corpse" )]
	public class FrostTroll : BaseCreature
	{
		[Constructable]
		public FrostTroll() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a frost troll";
			Body = 55;
			BaseSoundID = 461;

			SetStr( 227, 265 );
			SetDex( 66, 85 );
			SetInt( 46, 70 );

			SetHits( 280, 312 );

			SetDamage( 14, 20 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.Wrestling, 80.1, 100.0 );

			Fame = 14000;
			Karma = -14000;

			PackGold( 15, 23 );

			PackItem( new DoubleAxe() ); 

			PackItem( new Opal() );
			PackItem( new DiamondDust( Utility.RandomMinMax( 3, 6 ) ) );
			PackItem( new FishScale( Utility.RandomMinMax( 13, 17 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new StrengthScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 2; } }

		public FrostTroll( Serial serial ) : base( serial )
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