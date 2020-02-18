using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Fourth;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a black dragon corpse" )]
	public class BlackDragon : BaseAssholeEnemy
	{
	      public override bool AlwaysMurderer { get { return true; } }

		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 30.0 ); //the delay between talks is 30 second
		public DateTime m_NextTalk;

		[Constructable]
		public BlackDragon() : base( AIType.AI_Melee, FightMode.Closest, 100, 1, 350.0, 0.7 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the black dragon"; 
			Body = 106;

			CurrentSpeed = BoostedSpeed;
			RangePerception = 200;

			SetStr( 100, 120 );
			SetDex( 16, 25 );
			SetInt( 6, 10 );

			SetHits( 500 );
			SetMana( 0 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.Tactics, 99.6, 100.0 );
			SetSkill( SkillName.Wrestling, 98.6, 99.0 );

			Fame = 1000;
			Karma = -1000;

                        Flying = true;
			FlyTimer.FlyList.Add( this );

			PackGold( 500, 1000 );

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

			PackItem( new DragonScale( Utility.RandomMinMax( 25, 35 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new MeteorSwarmScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.MedScrolls, 1 );
			AddLoot( LootPack.LowScrolls, 5 );
			AddLoot( LootPack.Gems, 3 );
	        }

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }

	        public override bool Unprovokable { get { return true; } }
	        public override bool BardImmune { get { return true; } }

                public override bool HasBreath{ get{ return true; } }

		public override double BreathMinDelay{ get{ return 50.0; } }
		public override double BreathMaxDelay{ get{ return 60.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 0x4E; } }
		public override int BreathEffectItemID{ get{ return 0x36B0; } }
		public override int BreathEffectSound{ get{ return 0x364; } }

		public override int GetAngerSound() { return 0x654; } // netherCyclone
		public override int GetIdleSound() { return 0x2D5; }
		public override int GetHurtSound() { return 0x658; } // spellPlague
		public override int GetDeathSound() { return 0x653; } // netherBolt

		public void OnTick()
		{
			if ( Flying )
                        {
			        Effects.PlaySound(Location, Map, 0x5FC);
				CurrentSpeed = BoostedSpeed;
                        }
		}

	        public class FlyTimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<BlackDragon> FlyList = new List<BlackDragon>();

		        public static void Initialize() 
		        {
			        if (Enabled)
				        new FlyTimer().Start();
		        }

		        public FlyTimer() : base(TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 )) 
		        {
			        Priority = TimerPriority.OneSecond;
		        }

		        protected override void OnTick() 
		        {
			        foreach (BlackDragon blackdragon in FlyList)
				        blackdragon.OnTick();
		        }
	        }

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
 			if ( Utility.RandomDouble() < 0.05 )
                        {
                                this.Flying = true;
			        this.CurrentSpeed = BoostedSpeed;
			}
		}

		public override void OnDamagedBySpell( Mobile from )
		{
			if ( Flying )
			{
                                Flying = false;
				from.SendMessage( "The black dragon has landed" );
				CurrentSpeed = PassiveSpeed;
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if( attacker != null && attacker.Alive && attacker.Weapon is BaseRanged )
			{
			        if ( Flying )
			        {
				        attacker.SendMessage( "The black dragon has landed" );
                                        Flying = false;
				        CurrentSpeed = PassiveSpeed;
			        }
			}
			else if ( Flying )
			{
				PlaySound( 0x238 );
			}
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( Flying )
				damage = 0; // no melee damage when flying

			if ( from != null && from != this )
			{
				if ( from is PlayerMobile )
				{
					PlayerMobile p_PlayerMobile = from as PlayerMobile;
					Item weapon1 = p_PlayerMobile.FindItemOnLayer( Layer.OneHanded );
					Item weapon2 = p_PlayerMobile.FindItemOnLayer( Layer.TwoHanded );

					if ( weapon1 != null )
					{
						if ( weapon1 is BaseRanged )
						{
							damage *= 2;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseRanged )
						{
							damage *= 2;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
				}
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(19), from);
                              corpse.AddCarvedItem(new BarbedHides(20), from);
                              corpse.AddCarvedItem(new BlackScales(15), from);
                              corpse.AddCarvedItem(new DragonScale( Utility.RandomMinMax( 35, 50 )), from);
                              corpse.AddCarvedItem(new DragonHeart(), from);

                              from.SendMessage( "You carve up raw ribs, barbed hides, black scales, specialized dragon scales, and a dragon heart." );
                              corpse.Carved = true; 
			}
                }

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( to is HammerhillGuardianFighter || 
                       to is TempleCrusaderOfElmhaven || 
                       to is TempleKnightOfElmhaven || 
                       to is TempleMagicianOfElmhaven || 
                       to is TempleRangerOfElmhaven || 
                       to is ElandrimNurShazFortressGuard || 
                       to is ZaythalorForestRanger )
				damage *= 100;
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 15 ) && InLOS( m ) && m is PlayerMobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
                                m.Send( PlayMusic.GetInstance( MusicName.StygianDragon ) );

				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 40 ) )
				{
					case 0: Say("KNEEL BEFORE ME COWARD!");
						break;
					case 1: Say("MY FANGS HUNGER FOR YOUR VESSEL!");
						break;	
					case 2: Say("DEVASTATION BEFORE DINNER!");
						break;
					case 3: Say("THE EYE OF SHADOW IS UPON YOU!"); 
						break;
					case 4: Say("FROM THE BOGS OF DESOLATION, I ARISE!");
						break;
					case 5: Say("YOUR PERSISTENT CALLOUSNESS SHALL RESULT IN YOUR DOWNFALL MORTAL!"); 
						break;
					case 6: Say("FACE THE WRATH OF SORROW! THE AGONY INFLICTED BY MY OPPRESSORS SHALL BE REFLECTED BACK UPON YOU TENFOLD!");
						break;
					case 7: Say("I AM THE DRAGON OF BLOOD! YOUR RELENTLESS PRINCE OF PAIN!"); 
						break;	
					case 8: Say("HSSSSSKKKKKKKSSSS!");
						break;
					case 9: Say("I SHALL FERTILIZE THESE LANDS USING YOUR CORPSE!"); 
						break;
					case 10: Say("CALL OUT THE BEAST AND HIS FRIENDS! I WILL DEVOUR! I WILL DIVIDE!");
						break;
					case 11: Say("I'M A HELLBOUND HIDE! A DARK DESIGNER! I AM THE VENGEFUL ONE!"); 
						break;
					case 12: Say("OO WAH AH AH AH!"); 
						break;	
					case 13: Say("GET UP MY FRIENDS! AND GET DOWN WITH THE SICKNESS!");
						break;
					case 14: Say("I SHALL TEAR A BIG HOLE IN WHAT IS TO BE! TO END ALL THIS INFATUATION WITH UNITY!"); 
						break;
					case 15: Say("I'M A LOT MORE PROVOCATIVE THAN YOU MIGHT NEED! IT'S YOUR SHOCK AND HORROR ON WHICH I FEED!");
						break;
					case 16: Say("FROM THE OTHER SIDE, I'M A TERROR TO BEHOLD! YOUR ANNIHILATION WILL BE UNAVOIDABLE!"); 
						break;
					case 17: Say("I AM A INSTRUMENT OF VIOLENCE! I AM A VESSEL OF INVINCIBILITY!"); 
						break;
					case 18: Say("SURRENDER NOW! OR BE COUNTED WITH THE ENDLESS MASSES THAT I WILL DEFEAT!"); 
						break;
					case 19: Say("MADNESS IS THE GIFT THAT HAS BEEN GIVEN TO ME!"); 
						break;
					case 20: Say("OPEN UP YOUR HATE AND LET IT PUMP INTO ME!"); 
						break;
					case 21: Say("WHEN YOU DIE! YOU'LL KNOW WHY! FOR YOU CANNOT BE SAVED, THIS WORLD IS TOO DEPRAVED!"); 
						break;
					case 22: Say("TAKE A LOOK AROUND! YOU CAN'T DENY WHAT YOU SEE! WE'RE LIVING IN A VIOLENT SOCIETY!"); 
						break;
					case 23: Say("TIME TO SHED THIS MORTAL DISGUISE! FOR THE BEAST IS COMING TO LIFE!"); 
						break;
					case 24: Say("WE BEGIN THE HUNT! AND I FEEL THE POWER COURSE AS THIS CREATURE TAKES FLIGHT!"); 
						break;
					case 25: Say("RUN YOU LITTLE BITCH! I WANT YOUR POWER GLOWING, JUICY FLOWING, RED HOT, MEANING OF LIFE!"); 
						break;
					case 26: Say("BRING THE VIOLENCE! IT'SIGNIFICANT TO THE LIFE IF YOU'VE EVER KNOWN ANYONE!"); 
						break;
					case 27: Say("COME A LITTLE CLOSER MY PRETENTIOUS WHORE! I'M LIVING WITH A FEELING THAT I CAN'T IGNORE!"); 
						break;
					case 28: Say("MALEVOLENT CRIMINAL, I! WHEN THE VISION PAINTS MY MIND! CROSS THE INVISIBLE LINE AND YOU'LL BE PAID IN KIND!"); 
						break;
					case 29: Say("NOW I CAN'T STAY BEHIND! SAVE ME FROM WREAKING MY VENGEANCE UPON YOU! TO KILLING MORE THAN I CAN TELL! BURNING NOW I BRING YOU HELL!"); 
						break;
					case 30: Say("YOU'D BETTER CHERISH THIS MOMENT AS YOU DIG INTO ME! YOU'LL NEVER GET ANOTHER CHANCE AT THIS!");
						break;
					case 31: Say("I WON'T STAND ANOTHER MINUTE OF YOU QUESTIONING ME! YOU HEAR ME BITCH! STOP! THE INTERROGATION'S OVER!");
						break;
					case 32: Say("I CAN'T HANDLE THE FEELING OF YOU PESTERING ME! HOW WOULD YOU LIKE TO MEET MY FAVORITE FIST!");
						break;
					case 33: Say("I DREAM THIS MOMENT AS YOU RUN AWAY! YOU WOULD ONLY SEPARATE ME FROM WHAT I BELIEVE! THIS MOMENT IN BRUTALITY! YOU'RE THE ONE WHO KEPT ON PUSHING 'TIL I MADE YOU BLEED!"); 
						break;
					case 34: Say("DON'T WONDER WHY YOU CAN'T CLEAR THIS FINAL SIN! YOU KNOW THIS STORY WAS OVER BEFORE IT BEGAN! THIS IS A BATTLE YOU'RE NOT GONNA WIN! WELCOME TO THE END!");
						break;
					case 35: Say("SO WHAT YOU WAITING FOR? TELL ME WHAT YOU WAITING FOR! DON'T STAND BY AND DENY IT!");
						break;
					case 36: Say("SO WHAT YOU WAITING FOR! TELL ME WHAT YOU WAITING FOR! BREAK NEW GROUND AND DEFY IT!");
						break;
					case 37: Say("NOW YOU'VE BECOME EVERYTHING YOU CLAIM TO FIGHT! THROUGH YOUR NEED TO FEEL YOU'RE RIGHT! YOU'RE THE SAVIOR OF NOTHING NOW!");
						break;
					case 38: Say("YOU SEE I CANNOT BE FORSAKEN, BECAUSE I'M NOT THE ONLY ONE! WE WALK AMONGST YOU! FEEDING! RAPING! MUST WE HIDE FROM EVERYONE!");
						break;
					case 39: Say("HOW CAN I FEEL THIS EMPTY? I WILL NOT RECOVER THIS TIME! THIS LONELINESS IS KILLING ME!");
						break;
				};
			}
		}

		public override WeaponAbility GetWeaponAbility()
		{
			if (50.0 >= Utility.RandomDouble())
			return WeaponAbility.Bladeweave;
			else
			return WeaponAbility.TalonStrike;
		}

                public void GiveOutExperience()
                {
                      List<Mobile> list = new List<Mobile>();

                      foreach ( Mobile m in GetMobilesInRange( 15 ) )
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
			       PlayerMobile pm = m as PlayerMobile;

                               DoHarmful( m );

                               pm.Exp += 1000;
                               pm.KillExp += 1000;

                               pm.Send( Network.PlayMusic.GetInstance( MusicName.Ocllo ) );
                               pm.SendMessage("You've gained 1000 exp.");

                               if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                               {
                                       Actions.DoLevel(pm, new Setup());
                               }
                          }
                     }
                }

		public override bool OnBeforeDeath( ) //what happens before it dies
		{
		        GiveOutExperience();

			return true;
		}

		public BlackDragon( Serial serial ) : base( serial )
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

			FlyTimer.FlyList.Add(this);
		}
	}
}
