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
	public class AmazonianSpearFighter : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ArmorIgnore;
		}

		[Constructable]
		public AmazonianSpearFighter() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an amazonian spear fighter";
                        Body = 401;
                        Female = true;
                        Race = Race.Human;
			Hue = Utility.RandomList( 1025, 1027, 1028, 1029, 1035, 1041, 1049, 1051, 1058 );
                        HairItemID = 8252;
			HairHue = Utility.RandomList( 37, 38, 39, 40, 41 );

			SetStr( 148, 157 );
			SetDex( 106, 122 );
			SetInt( 34, 41 );

			SetHits( 100, 125 );
			SetMana( 100 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Anatomy, 57.9, 62.4 );
			SetSkill( SkillName.Fencing, 92.7, 98.1 );
			SetSkill( SkillName.MagicResist, 42.1, 59.9 );
			SetSkill( SkillName.Poisoning, 57.5, 62.6 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );

			Fame = 2000;
			Karma = -2000;

			SpearSpinTimer.SpearSpinList.Add( this );

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

			PackGold( 53, 186 );

			AddItem( new Spear() );

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 105, 425 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new FishScale( Utility.RandomMinMax( 5, 9 ) ) );

			if ( 0.05 > Utility.RandomDouble() )
				pack.DropItem( new Peridot() );

			PackItem( pack );
		}

		public override Poison HitPoison{ get{ return Poison.Lesser; } }
		public override int Meat{ get{ return 1; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return false; } }

		public override bool HasBreath{ get{ return true; } } // spear throw enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

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
		public override int GetHurtSound() { return 806; } //play female oomph 3
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
		        public static List<AmazonianSpearFighter> SpearSpinList = new List<AmazonianSpearFighter>();

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
			        foreach (AmazonianSpearFighter amazonianspearfighter in SpearSpinList)
				        amazonianspearfighter.OnTick();
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

				    AOS.Damage( m, 25, 100, 0, 0, 0, 0 );
		                    m.Stam -= ( Utility.Random( 45, 85 ) ); 
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
			int damage = 10;
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

		public AmazonianSpearFighter( Serial serial ) : base( serial )
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