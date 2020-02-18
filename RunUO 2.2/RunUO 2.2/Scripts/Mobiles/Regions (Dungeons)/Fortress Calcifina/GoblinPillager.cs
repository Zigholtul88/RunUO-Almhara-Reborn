using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Targeting;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a goblin pillager corpse" )]
	public class GoblinPillager : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

                private static bool m_Talked;
                string[]GoblinPillagerSay = new string[]
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
		public GoblinPillager() : base( AIType.AI_Melee, FightMode.Closest, 6, 1, 0.175, 0.350 )
		{
			Name = "a goblin pillager";
			SpeechHue = Utility.RandomDyedHue();
			Body = 723;

			SetStr( 175, 195 );
			SetDex( 125, 155 );
			SetInt( 95, 100 );

			SetHits( 125, 150 );

			SetDamage( 7, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.Anatomy, 76.9, 82.0 );
			SetSkill( SkillName.Tactics, 71.7, 80.1 );
			SetSkill( SkillName.Wrestling, 74.2, 83.3 );

			Fame = 1000;
			Karma = -1000;

			PackGold( 10, 11 );
			PackReg( 2, 5 );

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new ChickenLeg() ); break;
				case 1: PackItem( new CookedBird() ); break;
				case 2: PackItem( new FishSteak() ); break;
				case 3: PackItem( new LambLeg() ); break;
				case 4: PackItem( new Ribs() ); break;
				case 5: PackItem( new Sausage() ); break;
			}

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 10, 12 ) ) );
			pack.DropItem( new Lockpick( Utility.RandomMinMax( 5, 10 ) ) );

			PackItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Potions );
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
                             SayRandom(GoblinPillagerSay, this );
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

		public GoblinPillager( Serial serial ) : base( serial )
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
