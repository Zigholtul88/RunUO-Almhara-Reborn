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
	[CorpseName( "the corpse of Vygul the Uncleansed" )]
	public class AncientLich : BaseSpecialCreature
	{
                public override bool DoesTripleBolting { get { return true; } }
                public override double TripleBoltingChance { get { return 0.250; } }

                public override bool DoesEarthquaking { get { return true; } }
                public override double EarthquakingChance { get { return 0.250; } }

		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

	        public override bool AlwaysMurderer { get { return true; } }

		[Constructable]
		public AncientLich() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Vygul the Uncleansed";
			Body = 82;
			BaseSoundID = 412;

			SetStr( 216, 305 );
			SetDex( 96, 115 );
			SetInt( 966, 1045 );

			SetHits( 760, 895 );
                        SetMana( 3800, 4150 );

			SetDamage( 15, 27 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Cold, 40 );
			SetDamageType( ResistanceType.Energy, 40 );

			SetResistance( ResistanceType.Physical, 55 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.EvalInt, 120.1, 130.0 );
			SetSkill( SkillName.Magery, 120.1, 130.0 );
			SetSkill( SkillName.Meditation, 100.1, 101.0 );
			SetSkill( SkillName.Poisoning, 100.1, 101.0 );
			SetSkill( SkillName.MagicResist, 175.2, 200.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 75.1, 100.0 );

			Fame = 78000;
			Karma = -78000;

			PackReg( 50, 80 );
			PackNecroReg( 30, 275 );

			PackGold( 235, 360 );

			PackItem( new LichDust( Utility.RandomMinMax( 27, 49 ) ) );

			switch ( Utility.Random( 18 ))
			{
				case 0: PackItem( new Amethyst() ); break;
				case 1: PackItem( new Garnet() ); break;
				case 2: PackItem( new Jade() ); break;
				case 3: PackItem( new Morganite() ); break;
				case 4: PackItem( new Paraiba() ); break;
				case 5: PackItem( new TigerEye() ); break;
				case 6: PackItem( new Alexandrite() ); break;
				case 7: PackItem( new Ametrine() ); break;
				case 8: PackItem( new Kunzite() ); break;
				case 9: PackItem( new Ruby() ); break;
				case 10: PackItem( new Sapphire() ); break;
				case 11: PackItem( new Tanzanite() ); break;
				case 12: PackItem( new Topaz() ); break;
				case 13: PackItem( new Zultanite() ); break;
				case 14: PackItem( new Diamond() ); break;
				case 15: PackItem( new Emerald() ); break;
				case 16: PackItem( new PinkQuartz() ); break;
				case 17: PackItem( new StarSapphire() ); break;
			}
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override int GetIdleSound()
		{
			return 0x19D;
		}

		public override int GetAngerSound()
		{
			return 0x175;
		}

		public override int GetDeathSound()
		{
			return 0x108;
		}

		public override int GetAttackSound()
		{
			return 0xE2;
		}

		public override int GetHurtSound()
		{
			return 0x28B;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.MedScrolls, 5 );
			AddLoot( LootPack.Gems, 3 );

 		     if ( Utility.RandomDouble() < 0.10 )
                     {
	                        BaseWeapon weapon = Loot.RandomWeapon( true );
			        BaseRunicTool.ApplyAttributesTo( weapon, 5, 15, 35 );
				PackItem( weapon );
		     }

 		     if ( Utility.RandomDouble() < 0.10 )
                     {
			BaseArmor armor = Loot.RandomArmor( true );
			switch ( Utility.Random( 5 ) )
			{
			        case 0: armor = new EbonsilkGloves(); break;
			        case 1: armor = new EbonsilkGorget(); break;
				case 2: armor = new EbonsilkLegs(); break;
				case 3: armor = new EbonsilkArms(); break;
				default: armor = new EbonsilkChest(); break;
		        }

			        BaseRunicTool.ApplyAttributesTo( armor, 5, 15, 35 );
				PackItem( armor );
			}

 		     if ( Utility.RandomDouble() < 0.20 )
                     {
			        BaseClothing clothing = Loot.RandomClothing( true );
		                BaseRunicTool.ApplyAttributesTo( clothing, 5, 15, 35 );  
                                PackItem( clothing );
                     }

 		     if ( Utility.RandomDouble() < 0.10 )
                     {
			        BaseShield shield = new BlackHeaterShield();
			        if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( shield, 5, 15, 35 ); 
                                PackItem( shield );
                     }

 		     if ( Utility.RandomDouble() < 0.10 )
                     {
			        BaseJewel bracelet = new GoldBracelet();
			        if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( bracelet, 5, 15, 35 );  
                                PackItem( bracelet );
                     }

 		     if ( Utility.RandomDouble() < 0.10 )
                     {
			        BaseJewel earrings = new GoldEarrings();
			        if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( earrings, 5, 15, 35 ); 
                                PackItem( earrings );
                     }

 		     if ( Utility.RandomDouble() < 0.10 )
                     {
			        BaseJewel necklace = new GoldNecklace();
			        if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( necklace, 5, 15, 35 );      
                                PackItem( necklace );
                     }

 		     if ( Utility.RandomDouble() < 0.10 )
                     {
			        BaseJewel ring = new GoldRing();
			        if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( ring, 5, 15, 35 ); 
                                PackItem( ring );
                     }
	        }

		public override bool Unprovokable{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
		}

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

                public override void OnGaveMeleeAttack(Mobile defender)
                {
                      base.OnGaveMeleeAttack(defender);

                      if( DoesEarthquaking && EarthquakingChance >= Utility.RandomDouble() )
                      Earthquake();

                      if (0.15 >= Utility.RandomDouble())
		      Ability.FlameCross( this );
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

		public override bool OnBeforeDeath()
		{
                    if (Combatant is PlayerMobile)
			Ability.FlameWave( Combatant );

                        return base.OnBeforeDeath();
		}

		public AncientLich( Serial serial ) : base( serial )
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