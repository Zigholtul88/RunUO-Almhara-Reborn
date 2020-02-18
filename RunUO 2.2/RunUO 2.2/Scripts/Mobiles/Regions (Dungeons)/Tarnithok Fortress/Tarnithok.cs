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
	[CorpseName( "the corpse of Tarni-thok" )]
	public class Tarnithok : BaseCreature
	{
		[Constructable]
		public Tarnithok () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Tarni-thok";
			Title = "the crimsondread";
			Body = 313;
			BaseSoundID = 0x165;
			Hue = 0x648;

			SetStr( 1200 );
			SetDex( 100 );
			SetInt( 1000 );

			SetHits( 30000 );
			SetMana( 5000 );

			SetDamage( 20, 30 );

			SetDamageType( ResistanceType.Physical, 15 );
			SetDamageType( ResistanceType.Fire, 85 );

			SetResistance( ResistanceType.Physical, 80 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.Anatomy, 100.0 );
			SetSkill( SkillName.DetectHidden, 80.0 );
			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Magery, 100.0 );
			SetSkill( SkillName.Meditation, 120.0 );
			SetSkill( SkillName.MagicResist, 150.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 120.0 );

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
			AddLoot( LootPack.SuperBoss, 2 );
			AddLoot( LootPack.HighScrolls, Utility.RandomMinMax( 6, 60 ) );
		}

		public override bool BardImmune{ get{ return !Core.SE; } }
		public override bool Unprovokable{ get{ return Core.SE; } }
		public override bool AreaPeaceImmune { get { return Core.SE; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

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

		public Tarnithok( Serial serial ) : base( serial )
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