using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Targeting;
using Server.Spells;
using Server.Spells.Fourth;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Ulyi-tath" )]
	public class Ulyitath : BaseCreature
	{
		[Constructable]
		public Ulyitath () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Ulyi-tath";
			Title = "the Lord of the Abyss";
			Body = 102;
			BaseSoundID = 357;

			SetStr( 1005, 1183 );
			SetDex( 187, 238 );
			SetInt( 151, 247 );

			SetHits( 1184, 1422 );
			SetMana( 1105, 1205 );

			SetDamage( 15, 25 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 25 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 70 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 25.6, 35.7 );
			SetSkill( SkillName.EvalInt, 80.4, 93.6 );
			SetSkill( SkillName.Magery, 96.9, 99.1 );
			SetSkill( SkillName.Meditation, 27.3, 50.8 );
			SetSkill( SkillName.MagicResist, 116.7, 122.5 );
			SetSkill( SkillName.Tactics, 90.1, 99.7 );
			SetSkill( SkillName.Wrestling, 91.2, 99.7 );

			Fame = 224000;
			Karma = -224000;

			VirtualArmor = 74; // Random AR = 74, 82, 90

			PackGold( 120, 150 );

			PackItem( new Longsword() );

			switch ( Utility.Random( 12 ))
			{
				case 0: PackItem( new Alexandrite() ); break;
				case 1: PackItem( new Ametrine() ); break;
				case 2: PackItem( new Kunzite() ); break;
				case 3: PackItem( new Ruby() ); break;
				case 4: PackItem( new Sapphire() ); break;
				case 5: PackItem( new Tanzanite() ); break;
				case 6: PackItem( new Topaz() ); break;
				case 7: PackItem( new Zultanite() ); break;
				case 8: PackItem( new Diamond() ); break;
				case 9: PackItem( new Emerald() ); break;
				case 10: PackItem( new PinkQuartz() ); break;
				case 11: PackItem( new Sapphire() ); break;
			}

			switch ( Utility.Random( 7 ))
			{
				case 0: PackItem( new DaemonicGemEncrustedBreastplate() ); break;
				case 1: PackItem( new DaemonicGemEncrustedFemaleBreastplate() ); break;
				case 2: PackItem( new DaemonicGemEncrustedGauntlets() ); break;
				case 3: PackItem( new DaemonicGemEncrustedGorget() ); break;
				case 4: PackItem( new DaemonicGemEncrustedHelmet() ); break;
				case 5: PackItem( new DaemonicGemEncrustedLeggings() ); break;
				case 6: PackItem( new DaemonicGemEncrustedSleeves() ); break;
			}

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new PolymorphScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 5 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override int Meat{ get{ return 1; } }

		public override int GetAttackSound() { return 697; } 
		public override int GetAngerSound() { return 696; } 
		public override int GetDeathSound() { return 700; }
		public override int GetHurtSound() { return 699; } 
		public override int GetIdleSound() { return 698; } 

                public override void OnGaveMeleeAttack(Mobile defender)
                {
                      base.OnGaveMeleeAttack(defender);
                      if (0.15 >= Utility.RandomDouble())

		      Ability.FlameCross( this );
                }

		public override void OnGotMeleeAttack( Mobile attacker )
		{
	              base.OnGotMeleeAttack( attacker );
                      if (0.25 >= Utility.RandomDouble())

		      Ability.CrimsonMeteor( this, 50 );
		}

		public override bool OnBeforeDeath()
		{
                    if (Combatant is PlayerMobile)
			Ability.FlameWave( Combatant );

                        return base.OnBeforeDeath();
		}

		public Ulyitath( Serial serial ) : base( serial )
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