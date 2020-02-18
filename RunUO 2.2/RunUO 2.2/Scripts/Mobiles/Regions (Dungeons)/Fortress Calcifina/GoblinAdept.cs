using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Targeting;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a goblin adept corpse" )]
	public class GoblinAdept : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

                private static bool m_Talked;
                string[]GoblinAdeptSay = new string[]
       	        {
		"Nak shak baugha kashna!",
		"Sul myndurk!",
		"Pyncheknos abbla mein durz kappa!",
		"Oui, nyta bongstid mein daiga!",
		"Haleshmendaiga fouga!",
		"Ustagnaka badja pynto!",
		"Badja mygtaga booshka mamba!",
		"Klaben yag ishtoopa fouga!",
		"Zyxtudahrag!",
		"Byngstanapa juin daiga!",
		};

		[Constructable]
		public GoblinAdept() : base( AIType.AI_Mage, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = "a goblin adept";
			SpeechHue = Utility.RandomDyedHue();
			Body = 723;

			SetStr( 200, 205 );
			SetDex( 95, 105 );
			SetInt( 225, 245 );

			SetHits( 125, 150 );
			SetMana( 450, 490 );

			SetDamage( 7, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.EvalInt, 27.8, 33.8 );
			SetSkill( SkillName.Magery, 50.1, 56.4 );
			SetSkill( SkillName.MagicResist, 46.7, 60.9 );
			SetSkill( SkillName.Tactics, 71.7, 80.1 );
			SetSkill( SkillName.Wrestling, 74.2, 83.3 );

			Fame = 2500;
			Karma = -2500;

			PackGold( 14, 19 );
			PackReg( 8 );

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new ChickenLeg() ); break;
				case 1: PackItem( new CookedBird() ); break;
				case 2: PackItem( new FishSteak() ); break;
				case 3: PackItem( new LambLeg() ); break;
				case 4: PackItem( new Ribs() ); break;
				case 5: PackItem( new Sausage() ); break;
			}

			switch ( Utility.Random( 24 ))
			{
					case 0: PackItem( new ClumsyScroll() ); break;
					case 1: PackItem( new CreateFoodScroll() ); break;
					case 2: PackItem( new FeeblemindScroll() ); break;
					case 3: PackItem( new HealScroll() ); break;
					case 4: PackItem( new MagicArrowScroll() ); break;
					case 5: PackItem( new NightSightScroll() ); break;
					case 6: PackItem( new ReactiveArmorScroll() ); break;
					case 7: PackItem( new WeakenScroll() ); break;
					case 8: PackItem( new AgilityScroll() ); break;
					case 9: PackItem( new CunningScroll() ); break;
					case 10: PackItem( new CureScroll() ); break;
					case 11: PackItem( new HarmScroll() ); break;
					case 12: PackItem( new MagicTrapScroll() ); break;
					case 13: PackItem( new MagicUnTrapScroll() ); break;
					case 14: PackItem( new ProtectionScroll() ); break;
					case 15: PackItem( new StrengthScroll() ); break;
					case 16: PackItem( new BlessScroll() ); break;
					case 17: PackItem( new FireballScroll() ); break;
					case 18: PackItem( new MagicLockScroll() ); break;
					case 19: PackItem( new PoisonScroll() ); break;
					case 20: PackItem( new TelekinisisScroll() ); break;
					case 21: PackItem( new TeleportScroll() ); break;
					case 22: PackItem( new UnlockScroll() ); break;
					case 23: PackItem( new WallOfStoneScroll() ); break;
			}

			if ( 0.08 > Utility.RandomDouble() )
				PackItem( new WildStaff() );

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 12, 14 ) ) );
			pack.DropItem( new Lockpick( Utility.RandomMinMax( 5, 10 ) ) );

			PackItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Potions );
			AddLoot( LootPack.LowScrolls, 2 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

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

		public override bool IsEnemy( Mobile m )
		{
			if ( m.Player && m.FindItemOnLayer( Layer.Helm ) is GoblinTribalMask )
				return false;

			return base.IsEnemy( m );
		}

		public override void AggressiveAction( Mobile aggressor, bool criminal )
		{
			base.AggressiveAction( aggressor, criminal );

			Item item = aggressor.FindItemOnLayer( Layer.Helm );

			if ( item is GoblinTribalMask )
			{
				AOS.Damage( aggressor, 50, 0, 100, 0, 0, 0 );
				item.Delete();
				aggressor.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
				aggressor.PlaySound( 0x307 );
			}
		}

                public override void OnMovement( Mobile m, Point3D oldLocation )
                {
                     if( m_Talked == false )
                     {
                          if ( m.InRange( this, 3 ) && m is PlayerMobile)
                          {
                             m_Talked = true;
                             SayRandom(GoblinAdeptSay, this );
                             this.Move( GetDirectionTo( m.Location ) );
                             SpamTimer t = new SpamTimer();
                             t.Start();
                          }
                    }
              }

              private class SpamTimer : Timer
              {
                   public SpamTimer() : base( TimeSpan.FromSeconds( 25 ) )
                   {
                        Priority = TimerPriority.OneSecond;
                   }

                   protected override void OnTick()
                   {
                           m_Talked = false;
                   }
              }

                private static void SayRandom( string[] say, Mobile m )
                {
                     m.Say( say[Utility.Random( say.Length )] );
                }

		public GoblinAdept( Serial serial ) : base( serial )
		{
		}

		public override int GetAttackSound() { return 1533; } 
		public override int GetAngerSound() { return 1533; } 
		public override int GetHurtSound() { return 1535; } 
		public override int GetDeathSound() { return 1534; }

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
