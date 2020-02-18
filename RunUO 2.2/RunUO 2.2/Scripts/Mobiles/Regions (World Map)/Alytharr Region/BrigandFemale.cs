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
using Server.Targeting;

namespace Server.Mobiles
{
	public class BrigandFemale : BaseCreature
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 15.0 ); //the delay between talks is 15 seconds
		public DateTime m_NextTalk;

		public override bool ClickTitle{ get{ return false; } }

		[Constructable]
		public BrigandFemale() : base( AIType.AI_Mage, FightMode.Closest, 5, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomDyedHue();
			Name = NameList.RandomName( "female" );
			Body = 0x191;
			Title = "the brigand";
			Hue = Utility.RandomSkinHue();

			SetStr( 50, 100 );
			SetDex( 24, 178 );
			SetInt( 89, 111 );

			SetHits( 100, 150 );
			SetMana( 445, 555 );

			SetDamage( 1, 3 );

			SetSkill( SkillName.EvalInt, 35.5, 45.5 );
			SetSkill( SkillName.Magery, 55.9, 69.9 );
			SetSkill( SkillName.MagicResist, 39.1, 51.3 );
			SetSkill( SkillName.Tactics, 21.9, 37.5 );
			SetSkill( SkillName.Wrestling, 63.0, 81.5 );

			Fame = 2000;
			Karma = -2000;

			m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 2, 5 ) );

			PackGold( 2, 207 );

			AddItem( new Bandana());

			switch ( Utility.Random( 5 ))
			{
				case 0: AddItem( new CitizenDress() ); break;
				case 1: AddItem( new CommonerDress() ); break;
				case 2: AddItem( new DancersGarb() ); break;
				case 3: AddItem( new FormalDress() ); break;
				case 4: AddItem( new PlainDress() ); break;
			}

			switch ( Utility.Random( 6 ))
			{
				case 0: AddItem( new Boots() ); break;
				case 1: AddItem( new HeavyBoots() ); break;
				case 2: AddItem( new HighBoots() ); break;
				case 3: AddItem( new LightBoots() ); break;
				case 4: AddItem( new ShortBoots() ); break;
				case 5: AddItem( new ThighBoots() ); break;
			}

			Container pack1 = new Backpack();
			pack1.DropItem( new Pitcher( BeverageType.Water ) );
			pack1.DropItem( new Gold( Utility.RandomMinMax( 5, 227 ) ) );
			pack1.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );
			pack1.DropItem( new FishScale( Utility.RandomMinMax( 4, 8 ) ) );

                        Item ScrollLoot1 = Loot.RandomScroll( 0, 10, SpellbookType.Regular );
                        ScrollLoot1.Amount = Utility.Random( 2, 5 );
                        pack1.DropItem( ScrollLoot1 );

                        Item ScrollLoot2 = Loot.RandomScroll( 0, 10, SpellbookType.Regular );
                        ScrollLoot2.Amount = Utility.Random( 2, 5 );
                        pack1.DropItem( ScrollLoot2 );

			if ( 0.03 > Utility.RandomDouble() )
				pack1.DropItem( new OneGoldBar() );

			if ( 0.03 > Utility.RandomDouble() )
				pack1.DropItem( new FireOpal() );

			PackItem( pack1 );

			Container pack2 = new Backpack();
			pack2.DropItem( new BlackPearl( Utility.RandomMinMax( 7, 12 ) ) );
			pack2.DropItem( new Bloodmoss( Utility.RandomMinMax( 5, 9 ) ) );
			pack2.DropItem( new Garlic( Utility.RandomMinMax( 9, 14 ) ) );
			pack2.DropItem( new Ginseng( Utility.RandomMinMax( 3, 7 ) ) );
			pack2.DropItem( new MandrakeRoot( Utility.RandomMinMax( 8, 15 ) ) );
			pack2.DropItem( new Nightshade( Utility.RandomMinMax( 9, 17 ) ) );
			pack2.DropItem( new SpidersSilk( Utility.RandomMinMax( 7, 12 ) ) );
			pack2.DropItem( new SulfurousAsh( Utility.RandomMinMax( 5, 9 ) ) );
			PackItem( pack2 );

			switch ( Utility.Random( 3 ) )
			{
				case 0: PackItem( new Ribs() ); break;
				case 1: PackItem( new Shaft() ); break;
				case 2: PackItem( new Candle() ); break;
			}

			switch ( Utility.Random( 3 ))
			{
				case 0: AddItem( new GnarledStaff() ); break;
				case 1: AddItem( new QuarterStaff() ); break;
				case 2: AddItem( new BlackStaff() ); break;
				case 3: AddItem( new CrystalStaff() ); break;
			}

			Utility.AssignRandomHair( this );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );

 		        if ( Utility.RandomDouble() < 0.15 )
                        {
			     BaseWeapon weapon = Loot.RandomWeapon( true );
			     switch ( Utility.Random( 4 ) )
			     {
			          case 0: weapon = new QuarterStaff(); break;
			          case 1: weapon = new BlackStaff(); break;
			          case 2: weapon = new CrystalStaff(); break;
				  default: weapon = new GnarledStaff(); break;
		             }

		             BaseRunicTool.ApplyAttributesTo( weapon, 2, 10, 20 ); 

                             PackItem( weapon );
                        }
		}

		public override bool HasBreath{ get{ return true; } } // magic arrow enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 100; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x36E4; } }
		public override int BreathEffectSound{ get{ return 0x1E5; } }
		public override int BreathAngerSound{ get{ return 0x331; } } //play f_sneeze

		public override bool AlwaysMurderer{ get{ return true; } }

		public override int GetHurtSound()  { return 806; } //play female oomph 3
		public override int GetAngerSound() { return 802; } //play female no
		public override int GetDeathSound() { return 790; } //play female death 3

		private DateTime m_NextAbilityTime;

		public override void OnThink()
		{
			if ( DateTime.Now >= m_NextAbilityTime )
			{
				BrigandMale toBuff = null;

				foreach ( Mobile m in this.GetMobilesInRange( 8 ) )
				{
					if ( m is BrigandMale && IsFriend( m ) && m.Combatant != null && CanBeBeneficial( m ) && m.CanBeginAction( typeof( BrigandFemale ) ) && InLOS( m ) )
					{
						toBuff = (BrigandMale)m;
						break;
					}
				}

				if ( toBuff != null )
				{
					if ( CanBeBeneficial( toBuff ) && toBuff.BeginAction( typeof( BrigandFemale ) ) )
					{
						m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 30, 60 ) );

						toBuff.Say( true, "OH YEAH!" );
						this.Say( true, "Unleash your true potential!" );

						DoBeneficial( toBuff );

						object[] state = new object[]{ toBuff, toBuff.HitsMaxSeed, toBuff.RawStr, toBuff.RawDex };

						SpellHelper.Turn( this, toBuff );

						int toScale = toBuff.HitsMaxSeed;

						if ( toScale > 0 )
						{
							toBuff.HitsMaxSeed += AOS.Scale( toScale, 100 );
							toBuff.Hits += AOS.Scale( toScale, 100 );
						}

						toScale = toBuff.RawStr;

						if ( toScale > 0 )
							toBuff.RawStr += AOS.Scale( toScale, 10 );

						toScale = toBuff.RawDex;

						if ( toScale > 0 )
						{
							toBuff.RawDex += AOS.Scale( toScale, 10 );
							toBuff.Stam += AOS.Scale( toScale, 50 );
						}

						toBuff.Hits = toBuff.Hits;
						toBuff.Stam = toBuff.Stam;

						toBuff.FixedParticles( 0x375A, 10, 15, 5017, EffectLayer.Waist );
						toBuff.PlaySound( 0x1EE );

						Timer.DelayCall( TimeSpan.FromSeconds( 20.0 ), new TimerStateCallback( Unbuff ), state );
					}
				}
				else
				{
					m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 2, 5 ) );
				}
			}

			base.OnThink();
		}

		private void Unbuff( object state )
		{
			object[] states = (object[])state;

			BrigandMale toDebuff = (BrigandMale)states[0];

			toDebuff.EndAction( typeof( BrigandFemale ) );

			if ( toDebuff.Deleted )
				return;

			toDebuff.HitsMaxSeed = (int)states[1];
			toDebuff.RawStr = (int)states[2];
			toDebuff.RawDex = (int)states[3];

			toDebuff.Hits = toDebuff.Hits;
			toDebuff.Stam = toDebuff.Stam;
		}

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.4 > Utility.RandomDouble() )
			{
				ShootFireball( from );
			}
		}

		public void ShootFireball( Mobile to )
		{
			int damage = 15;
			this.MovingEffect( to, 0x36D4, 10, 0, false, false );
			this.DoHarmful( to );
			this.PlaySound( 0x15E ); // fireball
			AOS.Damage( to, this, damage, 0, 100, 0, 0, 0 );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !IsFanned( defender ) && 0.15 > Utility.RandomDouble() )
			{
                                defender.SendMessage( "The brigand fans you with gas, reducing your resistance to physical attacks." );

		                ResistanceMod mod = new ResistanceMod( ResistanceType.Physical, - 50 );

				defender.FixedParticles( 0x3779, 10, 30, 0x34, EffectLayer.RightFoot );
				defender.PlaySound( 0x1E6 );

				// This should be done in place of the normal attack damage.
				//AOS.Damage( defender, this, Utility.RandomMinMax( 5, 10 ), 100, 0, 0, 0, 0 );

				defender.AddResistanceMod( mod );
		
				ExpireTimer timer = new ExpireTimer( defender, mod, TimeSpan.FromSeconds( 10.0 ) );
				timer.Start();
				m_Table[defender] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		public bool IsFanned( Mobile m )
		{
			return m_Table.Contains( m );
		}

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private ResistanceMod m_Mod;

			public ExpireTimer( Mobile m, ResistanceMod mod, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
				m_Mod = mod;
				Priority = TimerPriority.TwoFiftyMS;
		        }

			protected override void OnTick()
			{
                                m_Mobile.SendMessage( "Your resistance to physical attacks has returned." );
				m_Mobile.RemoveResistanceMod( m_Mod );
				Stop();
				m_Table.Remove( m_Mobile );
			}
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 4 ) && InLOS( m ) && m is PlayerMobile ) // check if it's time to talk & mobile in range & in los.
			{
 			        if ( Utility.RandomDouble() < 0.05 )
                                {
			                RangePerception = 200;
				        this.Combatant = m;
                                }

				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 6 ))
				{
					case 0: Say("You're just the type of action I've been waiting for!"); 
						PlaySound(794); //play female giggle
						break;
					case 1: Say("I'm so exicited and I just can't hide it"); 
						PlaySound(824); //play female yell
						break;	
					case 2: Say("I've had sheep that put up a better fight."); 
						PlaySound(816); //play female sigh
						break;	
					case 3: Say("Once I'm done I plan on doing things to your body!"); 
						PlaySound(821); //play female whistle
						break;	
					case 4: Say("Oui, now that's a stench good for the hogs."); 
						PlaySound(792); //play female fart
						break;	
					case 5: Say("You think you can best me? You haven't seen shit!"); 
						PlaySound(783); //play female cheer
						break;	
				};
			}
		}

		public BrigandFemale( Serial serial ) : base( serial )
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