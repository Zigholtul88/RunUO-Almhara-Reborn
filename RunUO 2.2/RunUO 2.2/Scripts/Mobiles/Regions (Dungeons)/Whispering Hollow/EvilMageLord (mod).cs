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
	[CorpseName( "an evil mage lord corpse" )] 
	public class EvilMageLord : BaseSpecialCreature 
	{ 
                public override bool DoesTripleBolting { get { return true; } }
                public override double TripleBoltingChance { get { return 0.250; } }

	        public override bool AlwaysMurderer { get { return true; } }

		[Constructable] 
		public EvilMageLord() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = NameList.RandomName( "evil mage lord" );
			Body = 125;

			PackItem( new Robe( Utility.RandomMetalHue() ) ); 
			PackItem( new WizardsHat( Utility.RandomMetalHue() ) ); 

			SetStr( 81, 105 );
			SetDex( 191, 213 );
                        SetInt( 571, 646 );

			SetHits( 2150, 2450 );
                        SetMana( 2855, 3230 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 53 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.EvalInt, 120.0 );
			SetSkill( SkillName.Magery, 92.0, 99.4 );
			SetSkill( SkillName.MagicResist, 158.2, 182.2 );
			SetSkill( SkillName.Meditation, 30.2, 45.5 );
			SetSkill( SkillName.Tactics, 50.8, 69.1 );
			SetSkill( SkillName.Wrestling, 65.8, 81.8 );

			Fame = 22500;
			Karma = -22500;

			PackGold( 2212, 3418 );

			PackReg( 250 );

			PackItem( new ArcaneStone( Utility.RandomMinMax( 120, 150 ) ) );

			if ( Utility.RandomBool() )
				PackItem( new Shoes() );
			else
				PackItem( new Sandals() );
	
			switch ( Utility.Random( 24 ))
			{
					case 0: PackItem( new BladeSpiritsScroll() ); break;
					case 1: PackItem( new DispelFieldScroll() ); break;
					case 2: PackItem( new IncognitoScroll() ); break;
					case 3: PackItem( new MagicReflectScroll() ); break;
					case 4: PackItem( new MindBlastScroll() ); break;
					case 5: PackItem( new ParalyzeScroll() ); break;
					case 6: PackItem( new PoisonFieldScroll() ); break;
					case 7: PackItem( new SummonCreatureScroll() ); break;
					case 8: PackItem( new DispelScroll() ); break;
					case 9: PackItem( new EnergyBoltScroll() ); break;
					case 10: PackItem( new ExplosionScroll() ); break;
					case 11: PackItem( new InvisibilityScroll() ); break;
					case 12: PackItem( new MarkScroll() ); break;
					case 13: PackItem( new MassCurseScroll() ); break;
					case 14: PackItem( new ParalyzeFieldScroll() ); break;
					case 15: PackItem( new RevealScroll() ); break;
					case 16: PackItem( new ChainLightningScroll() ); break;
					case 17: PackItem( new EnergyFieldScroll() ); break;
					case 18: PackItem( new FlamestrikeScroll() ); break;
					case 19: PackItem( new GateTravelScroll() ); break;
					case 20: PackItem( new ManaVampireScroll() ); break;
					case 21: PackItem( new MassDispelScroll() ); break;
					case 22: PackItem( new MeteorSwarmScroll() ); break;
					case 23: PackItem( new PolymorphScroll() ); break;
			}

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 15 );
			AddLoot( LootPack.LowScrolls, 2 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public override void OnGotMeleeAttack( Mobile attacker )
		{
	              base.OnGotMeleeAttack( attacker );

                      Mobile target = attacker;

                      if( target is BaseCreature && ((BaseCreature)target).Controlled )
                      target = ((BaseCreature)target).ControlMaster;

                      if( target == null )
                      target = attacker;

                      if( DoesTripleBolting && TripleBoltingChance >= Utility.RandomDouble() )
                      TripleBolt( target );

                      if (0.25 >= Utility.RandomDouble())
		      Ability.CrimsonMeteor( this, 50 );
		}

                public override void OnDamagedBySpell( Mobile attacker )
                {
                      base.OnDamagedBySpell( attacker );

                      Mobile target = attacker;

                      if( target is BaseCreature && ((BaseCreature)target).Controlled )
                      target = ((BaseCreature)target).ControlMaster;

                      if( target == null )
                      target = attacker;

                      if( DoesTripleBolting && TripleBoltingChance >= Utility.RandomDouble() )
                      TripleBolt( target );
                }

		public EvilMageLord( Serial serial ) : base( serial ) 
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