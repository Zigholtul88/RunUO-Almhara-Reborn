using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a cavern drake corpse" )]
	public class CavernDrake : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}

		[Constructable]
		public CavernDrake() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the cavern drake";
			Body = Utility.RandomList( 60, 61 );

			SetStr( 252, 275 );
			SetDex( 112, 121 );
			SetInt( 81, 90 );

			SetHits( 475, 535 );

			SetDamage( 8, 12 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Fire, 20 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.MagicResist, 59.6, 75.2 );
			SetSkill( SkillName.Tactics, 97.5, 104.9 );
			SetSkill( SkillName.Wrestling, 90.2, 102.4 );

			Fame = 20000;
			Karma = -20000;

			PackGold( 875, 1025 );
			PackReg( 25 );

			PackItem( new FireballScroll() );

			switch ( Utility.Random( 9 ))
			{
				case 0: PackItem( new Agate() ); break;
				case 1: PackItem( new Beryl() ); break;
				case 2: PackItem( new ChromeDiopside() ); break;
				case 3: PackItem( new FireOpal() ); break;
				case 4: PackItem( new MoonstoneCustom() ); break;
				case 5: PackItem( new Onyx() ); break;
				case 6: PackItem( new Opal() ); break;
				case 7: PackItem( new Pearl() ); break;
				case 8: PackItem( new TurquoiseCustom() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 8 );
		}

		public override bool ReacquireOnMovement{ get{ return true; } }

		public override bool HasBreath{ get{ return true; } } // fire breath enabled

		public override double BreathMinDelay{ get{ return 10.0; } }
		public override double BreathMaxDelay{ get{ return 40.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }

		public override int BreathEffectHue{ get{ return 0x4E; } }
		public override int BreathEffectItemID{ get{ return 0x36B0; } }
		public override int BreathEffectSound{ get{ return 0x364; } }

		public override int GetAngerSound() { return 0x654; } // netherCyclone
		public override int GetIdleSound() { return 0x2D5; }
		public override int GetHurtSound() { return 0x658; } // spellPlague
		public override int GetDeathSound() { return 0x653; } // netherBolt

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs(10), from );
                              corpse.AddCarvedItem( new HornedHides(20), from );
                              corpse.AddCarvedItem( new YellowScales(2), from );
                              corpse.AddCarvedItem( new DragonScale( Utility.RandomMinMax( 11, 13 ) ), from );

                              from.SendMessage( "You carve up raw ribs, spined hides, and two sets of dragon scales." ); 
                              corpse.Carved = true;
			}
                }

                public void AwardDungeonBossKey()
                {
                      List<Mobile> list = new List<Mobile>();

                      foreach ( Mobile m in GetMobilesInRange( 30 ) )
                      {
                             if ( !CanBeHarmful ( m ) )
                             continue;

                             if ( m.Player )
                             list.Add ( m );
                      }

                      foreach ( Mobile m in list )
                      {
                             if ( m == this || !CanBeHarmful( m ) )
                             continue;

                             if ( !m.Player && !( m is BaseCreature && ( (BaseCreature)m).ControlMaster.Player) )
                             continue;

                          if ( m.Player && m.Alive )
                          {
			       m.AddToBackpack( new IguanaCoveBossKey() );
                               m.SendMessage( "You receive a key needed to get pass the fog gates." );
                               DoHarmful( m );
                          }
                     }
                }

		public override bool OnBeforeDeath( ) //what happens before it dies
		{
		      AwardDungeonBossKey();
                      return base.OnBeforeDeath();
		}

		public CavernDrake( Serial serial ) : base( serial )
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