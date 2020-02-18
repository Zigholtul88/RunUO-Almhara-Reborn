using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Engines.Quests;
using Server.Engines.Quests.KissOfTheSerpentMistress;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Calcifina" )]
	public class CalcifinaTheEnslaver : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

                private static bool m_Talked;
                string[]CalcifinaSay = new string[]
       	        {
		        "You cannot win this fight, don't even try!",
		        "Hmmm, am I being too hard on you?",
		        "Hide behind the walls if you must, I will still find you!",
		        "Oh dear, is my venom too much for you to handle?",
		        "I will flay the skin right off of your wretched bones!",
		        "The end shall herald forth your inevitable demise!",
		        "You've passed through my orc minions, but you will not best me foul mortal!",
		        "You shouldn't have come down here, now you must die!",
		        "My Serpent Striker shall make swift work of you!",
		};

		[Constructable]
		public CalcifinaTheEnslaver () : base( AIType.AI_Archer, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = "Calcifina the Enslaver";
			Body = 87;
			
			SetStr( 150, 200 );
			SetDex( 250, 300 );
			SetInt( 125, 150 );

			SetHits( 6000, 8350 );

			SetDamage( 19, 25 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 50 );
			
			SetSkill( SkillName.Anatomy, 50.0 );
			SetSkill( SkillName.Archery, 185.0 );
			SetSkill( SkillName.MagicResist, 50.0 );
			SetSkill( SkillName.Poisoning, 30.0 );
			SetSkill( SkillName.Tactics, 185.0 );

                        Fame = 8000;
                        Karma = -8000;

			PackItem( new Arrow( Utility.RandomMinMax( 50, 80 ) ) ); 
			PackItem( new Arrow( Utility.RandomMinMax( 50, 80 ) ) ); 
			PackItem( new Arrow( Utility.RandomMinMax( 50, 80 ) ) ); 

			PackGold( 5550, 6075 );

			PackItem( new OneGoldBar() );

                        PackItem( new TreasureMap(1, Map.Malas ) );
		}
			
		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );
			AddLoot( LootPack.Gems, 15 );
		}

		public override int GetIdleSound() { return 1557; } 
		public override int GetAngerSound() { return 1554; } 
		public override int GetHurtSound() { return 1556; } 
		public override int GetDeathSound() { return 1555; }

		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override Poison HitPoison{ get{ return Poison.Regular; } }
		
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

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ParalyzingBlow;
		}

                public override void OnMovement( Mobile m, Point3D oldLocation )
                {
                        if ( m_Talked == false )
                        {
                                if ( m.InRange( this, 8 ) && m is PlayerMobile )
                                {
                                        m.Send( PlayMusic.GetInstance( MusicName.Taiko ) );
                                        m_Talked = true;
                                        SayRandom(CalcifinaSay, this );
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

                public void AwardLoot()
                {
                      List<Mobile> list = new List<Mobile>();

                      foreach ( Mobile m in GetMobilesInRange( 12 ) )
                      {
                             if ( !CanBeHarmful ( m ) )
                             continue;

                             if ( m.Player )
                             list.Add ( m );
                      }

                      foreach ( Mobile m in list )
                      {
			    SerpentStriker serpentstriker = new SerpentStriker();
				
		            PlayerMobile player = m as PlayerMobile;
			    QuestSystem qs = player.Quest;

			    if ( qs is KissOfTheSerpentMistressQuest && qs.IsObjectiveInProgress( typeof( SlayCalcifinaObjective ) ) )
			    {
				       qs.AddObjective( new ObtainBowAndJournalObjective() );

                                       m.AddToBackpack( new SerpentStriker() );

                                       m.Send( Network.PlayMusic.GetInstance( MusicName.Victory ) );
                                       m.SendMessage( "You receive the serpent striker." ); 
                                       DoHarmful( m );
			    }
                            else
                            {
                                       m.Send( Network.PlayMusic.GetInstance( MusicName.Victory ) );
                                       m.AddToBackpack( new Diamond(10) );
                                       DoHarmful( m ); 
                            }
                      }
                }

		public override bool OnBeforeDeath() //what happens before it dies
		{
		      AwardLoot();
                      return base.OnBeforeDeath();
                }

		public CalcifinaTheEnslaver( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}
	}
}
