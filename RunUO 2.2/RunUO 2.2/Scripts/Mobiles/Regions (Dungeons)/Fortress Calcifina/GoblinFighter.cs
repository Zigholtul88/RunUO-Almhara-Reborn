using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Targeting;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a goblin fighter corpse" )]
	public class GoblinFighter : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

                private static bool m_Talked;
                string[]GoblinFighterSay = new string[]
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
		public GoblinFighter() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
			Name = "a goblin fighter";
			SpeechHue = Utility.RandomDyedHue();
			Body = 723;

			SetStr( 225, 235 );
			SetDex( 165, 175 );
			SetInt( 105, 110 );

			SetHits( 150, 185 );

			SetDamage( 8, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.Anatomy, 82.9, 85.2 );
			SetSkill( SkillName.Tactics, 82.6, 89.3 );
			SetSkill( SkillName.Wrestling, 84.1, 85.8 );

			Fame = 3000;
			Karma = -3000;

			PackGold( 13, 17 );

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new ChickenLeg() ); break;
				case 1: PackItem( new CookedBird() ); break;
				case 2: PackItem( new FishSteak() ); break;
				case 3: PackItem( new LambLeg() ); break;
				case 4: PackItem( new Ribs() ); break;
				case 5: PackItem( new Sausage() ); break;
			}

			if ( 0.08 > Utility.RandomDouble() )
				PackItem( new ShortSpear() );

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 11, 13 ) ) );
			pack.DropItem( new Lockpick( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new Pitcher( BeverageType.Water ) );

			PackItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
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
                             SayRandom(GoblinFighterSay, this );
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

		public GoblinFighter( Serial serial ) : base( serial )
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
