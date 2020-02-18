using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an amazonian corpse" )]
	public class AmazonianGuardBreaker : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ArmorIgnore;
		}

		[Constructable]
		public AmazonianGuardBreaker() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.2, 0.4 )
		{
			Name = "an amazonian guard breaker";
                        Body = 401;
                        Female = true;
                        Race = Race.Human;
			Hue = Utility.RandomList( 1025, 1027, 1028, 1029, 1035, 1041, 1049, 1051, 1058 );
                        HairItemID = 8252;
			HairHue = Utility.RandomList( 37, 38, 39, 40, 41 );

			SetStr( 225, 250 );
			SetDex( 159, 178 );
			SetInt( 69, 73 );

			SetHits( 425, 550 );

			SetDamage( 17, 22 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Anatomy, 63.4, 71.0 );
			SetSkill( SkillName.Healing, 45.8, 60.2 );
			SetSkill( SkillName.MagicResist, 53.6, 64.1 );
			SetSkill( SkillName.Swords, 96.9, 105.5 );
			SetSkill( SkillName.Tactics, 89.7, 107.4 );

			Fame = 35000;
			Karma = -35000;

			SpearSpinTimer.SpearSpinList.Add( this );

			new SwampDragon().Rider = this;

			AmazonianFighterHelmet helm = new AmazonianFighterHelmet();
			helm.Hue = 138;
			helm.Movable = false;
			AddItem( helm );

			AmazonianFighterBustier chest = new AmazonianFighterBustier();
			chest.Hue = 138;
			chest.Movable = false;
			AddItem( chest );

			AmazonianFighterGloves gloves = new AmazonianFighterGloves();
			gloves.Hue = 138;
			gloves.Movable = false;
			AddItem( gloves );

			AmazonianFighterBelt belt = new AmazonianFighterBelt();
			belt.Hue = 138;
			belt.Movable = false;
			AddItem( belt );

			AmazonianFighterBoots boots = new AmazonianFighterBoots();
			boots.Hue = 138;
			boots.Movable = false;
			AddItem( boots );

			PackItem( new Bandage( Utility.RandomMinMax( 15, 25 ) ) );

			PackGold( 26, 43 );
			AddItem( new Halberd());

                        if (Utility.RandomDouble() < 0.1 )
                                PackItem(new TreasureMap(1, Map.Malas ) );

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 515, 828 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new FishScale( Utility.RandomMinMax( 12, 16 ) ) );
			pack.DropItem( new Peridot(Utility.RandomMinMax( 15, 24 ) ) );

			PackItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );

 		        if ( Utility.RandomDouble() < 0.15 )
                        {
			     BaseWeapon weapon = new Halberd();
			     if ( Core.AOS )
		             BaseRunicTool.ApplyAttributesTo( weapon, 5, 35, 50 ); 

                             PackItem( weapon );
                        }

			if ( 0.45 > Utility.RandomDouble() )
			{
				switch ( Utility.Random( 5 ) )
				{
					case 0: PackItem( new AmazonianFighterHelmet() ); break;
					case 1: PackItem( new AmazonianFighterBustier() ); break;
					case 2: PackItem( new AmazonianFighterGloves() ); break;
					case 3: PackItem( new AmazonianFighterBelt() ); break;
					case 4: PackItem( new AmazonianFighterBoots() ); break;
				}
			}
		}

		public override Poison HitPoison{ get{ return Poison.Greater; } }
		public override int Meat{ get{ return 1; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return false; } }

		public override bool HasBreath{ get{ return true; } } // spear throw enabled

		public override double BreathMinDelay{ get{ return 5.0; } }
		public override double BreathMaxDelay{ get{ return 15.0; } }

		public override int BreathPhysicalDamage{ get{ return 100; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x0F63; } }
		public override int BreathEffectSound{ get{ return 0x5D2; } }
		public override int BreathAngerSound{ get{ return 824; } }

		public override int GetIdleSound() { return 794; } //play female giggle
		public override int GetHurtSound()  { return 806; } //play female oomph 3
		public override int GetAngerSound() { return 824; } //play female yell
		public override int GetDeathSound() { return 790; } //play female death 3

		public void OnTick()
		{
		        SpearSpinAttack();
			this.Animate( 18, 5, 1, true, false, 0 );
			this.FixedParticles( 0x375A, 10, 15, 5037, EffectLayer.Waist );
		}

	        public class SpearSpinTimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<AmazonianGuardBreaker> SpearSpinList = new List<AmazonianGuardBreaker>();

		        public static void Initialize() 
		        {
			        if (Enabled)
				        new SpearSpinTimer().Start();
		        }

		        public SpearSpinTimer() : base(TimeSpan.FromSeconds( 15.0 ), TimeSpan.FromSeconds( 15.0 )) 
		        {
			        Priority = TimerPriority.OneSecond;
		        }

		        protected override void OnTick() 
		        {
			        foreach (AmazonianGuardBreaker amazonianguardbreaker in SpearSpinList)
				        amazonianguardbreaker.OnTick();
		        }
	        }

                public void SpearSpinAttack()
                {
                        List<Mobile> list = new List<Mobile>();

                        foreach ( Mobile m in GetMobilesInRange( 3 ) )
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
		                    m.BoltEffect( 0x480 );
			            m.PlaySound( 0x220 ); // Earthquake

				    AOS.Damage( m, 100, 100, 0, 0, 0, 0 );
		                    m.Stam -= ( Utility.Random( 100, 200 ) ); 
                               }
                        }
                }

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.4 > Utility.RandomDouble() )
			{
				ThrowSpear( from );
			}
		}

		public void ThrowSpear( Mobile to )
		{
			int damage = 50;
			this.MovingEffect( to, 0x0F63, 10, 0, false, false );
			this.DoHarmful( to );
			this.PlaySound( 0x5D2 ); // throwH
			AOS.Damage( to, this, damage, 100, 0, 0, 0, 0 );
		}

		public override void OnGaveMeleeAttack( Mobile defender ) 
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.2 > Utility.RandomDouble() )
			{
				defender.FixedEffect( 0x37B9, 10, 5 );
                                defender.SendMessage( "You are frozen as the spear fighter laughs maniacally." );
			        defender.PlaySound( 0x529 ); // tengu_idle03

				defender.Paralyze( TimeSpan.FromSeconds( 5.0 ) );
 			}
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( m.BodyValue == 401 ||  m.BodyValue == 606 )
				return false;

			return base.IsEnemy( m );
		}

		public AmazonianGuardBreaker( Serial serial ) : base( serial )
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

			SpearSpinTimer.SpearSpinList.Add(this);
		}
	}
}