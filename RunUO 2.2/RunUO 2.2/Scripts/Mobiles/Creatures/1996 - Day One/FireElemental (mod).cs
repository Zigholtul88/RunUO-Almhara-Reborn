using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a fire elemental corpse" )]
	public class FireElemental : BaseCreature
	{
		[Constructable]
		public FireElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a fire elemental";
			Body = 15;
			BaseSoundID = 838;

			SetStr( 129, 151 );
			SetDex( 168, 185 );
			SetInt( 101, 119 );

			SetHits( 152, 186 );
			SetMana( 505, 595 );

			SetDamage( 7, 9 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 75 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.EvalInt, 50.4, 63.6 );
			SetSkill( SkillName.Magery, 67.0, 77.4 );
			SetSkill( SkillName.MagicResist, 79.7, 94.8 );
			SetSkill( SkillName.Tactics, 80.9, 95.3 );
			SetSkill( SkillName.Wrestling, 75.8, 99.0 );

			Fame = 4500;
			Karma = -4500;

			VirtualArmor = 40;

			PackGold( 17, 28 );

			PackItem( new SulfurousAsh( 3 ) );

			PackItem( new CharredFeather( Utility.RandomMinMax( 3, 7 ) ) );
			PackItem( new ElementalDust( Utility.RandomMinMax( 6, 9 ) ) );

			PackItem( new FireOpal() );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new SummonFireElementalScroll() );

			AddItem( new LightSource() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
		}

		public override bool BleedImmune{ get{ return true; } }

		public FireElemental( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 274 )
				BaseSoundID = 838;
		}
	}
}
