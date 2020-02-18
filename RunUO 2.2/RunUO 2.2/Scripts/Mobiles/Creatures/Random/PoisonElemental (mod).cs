using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a poison elementals corpse" )]
	public class PoisonElemental : BaseCreature
	{
		[Constructable]
		public PoisonElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a poison elemental";
			Body = 162;
			BaseSoundID = 263;

			SetStr( 430, 515 );
			SetDex( 166, 184 );
			SetInt( 362, 431 );

			SetHits( 512, 618 );
			SetMana( 1810, 2155 );

			SetDamage( 12, 18 );

			SetDamageType( ResistanceType.Physical, 10 );
			SetDamageType( ResistanceType.Poison, 90 );

			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.EvalInt, 20.4, 33.6 );
			SetSkill( SkillName.Magery, 83.6, 94.5 );
			SetSkill( SkillName.Meditation, 87.0, 112.2 );
			SetSkill( SkillName.Poisoning, 90.3, 100.0 );
			SetSkill( SkillName.MagicResist, 92.4, 113.4 );
			SetSkill( SkillName.Tactics, 80.3, 99.4 );
			SetSkill( SkillName.Wrestling, 74.1, 89.5 );

			Fame = 12500;
			Karma = -12500;

			VirtualArmor = 70;

			PackGold( 52, 56 );

			switch ( Utility.Random( 3 ))
			{
				case 0: PackItem( new Citrine() ); break;
				case 1: PackItem( new Demantoid() ); break;
				case 2: PackItem( new Zircon() ); break;
			}

			PackItem( new Nightshade( 4 ) );
			PackItem( new LesserPoisonPotion() );

			PackItem( new ElementalDust( Utility.RandomMinMax( 12, 16 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new PoisonFieldScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Rich );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override double HitPoisonChance{ get{ return 0.75; } }

		public PoisonElemental( Serial serial ) : base( serial )
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