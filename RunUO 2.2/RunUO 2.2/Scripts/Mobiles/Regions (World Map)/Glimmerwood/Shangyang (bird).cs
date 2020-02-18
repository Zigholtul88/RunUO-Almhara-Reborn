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
	[CorpseName( "a shangyang corpse" )]	
	public class Shangyang : BaseCreature
	{
		[Constructable]
		public Shangyang() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a shangyang";
			Body = 6;
			Hue = 2583;

			SetStr( 50 );
			SetDex( 35 );
			SetInt( 96, 120 );

			SetHits( 115, 130 );
			SetMana( 1150, 1200 );

			SetDamage( 1 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.EvalInt, 76.7, 85.7 );
			SetSkill( SkillName.Magery, 80.0, 98.0 );
			SetSkill( SkillName.MagicResist, 50.0 );
			SetSkill( SkillName.Meditation, 99.2, 99.9 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 300;
			Karma = -300;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 23.6;

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new Apple() ); break;
				case 1: PackItem( new Banana() ); break;
				case 2: PackItem( new Grapes() ); break;
				case 3: PackItem( new Lemon() ); break;
				case 4: PackItem( new Lime() ); break;
				case 5: PackItem( new Pear() ); break;
			}
		}

		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }

		public override bool HasBreath{ get{ return true; } } // energy bolt enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x379F; } }
		public override int BreathEffectSound{ get{ return 0x20A; } }
		public override int BreathAngerSound{ get{ return 0x82; } }

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.4 > Utility.RandomDouble() )
			{
				ShootMagicArrow( from );
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if( attacker != null && attacker.Alive && attacker.Weapon is BaseRanged && 0.4 > Utility.RandomDouble() )
			{
				ShootMagicArrow( attacker );
			}
		}

		public void ShootMagicArrow( Mobile to )
		{
			int damage = 5;
			this.MovingEffect( to, 0x36E4, 10, 0, false, false );
			this.DoHarmful( to );
			this.PlaySound( 0x1E5 ); // magic arrow
			AOS.Damage( to, this, damage, 0, 100, 0, 0, 0 );
		}

		private Timer m_SoundTimer;
		private bool m_HasTeleportedAway;

		public override void OnCombatantChange()
		{
			base.OnCombatantChange();

			if ( Hidden && Combatant != null )
				Combatant = null;
		}

		public virtual void SendTrackingSound()
		{
			if ( Hidden )
			{
				Effects.PlaySound( this.Location, this.Map, 0x2C8 );
				Combatant = null;
			}
			else
			{
				Frozen = false;

				if ( m_SoundTimer != null )
					m_SoundTimer.Stop();

				m_SoundTimer = null;
			}
		}

		public override void OnThink()
		{
			if ( !m_HasTeleportedAway && Hits < (HitsMax / 2) )
			{
				Map map = this.Map;

				if ( map != null )
				{
					// try 10 times to find a teleport spot
					for ( int i = 0; i < 10; ++i )
					{
						int x = X + (Utility.RandomMinMax( 5, 10 ) * (Utility.RandomBool() ? 1 : -1));
						int y = Y + (Utility.RandomMinMax( 5, 10 ) * (Utility.RandomBool() ? 1 : -1));
						int z = Z;

						if ( !map.CanFit( x, y, z, 16, false, false ) )
							continue;

						Point3D from = this.Location;
						Point3D to = new Point3D( x, y, z );

						if ( !InLOS( to ) )
							continue;

						this.Location = to;
						this.ProcessDelta();
						this.Hidden = false;
						this.Combatant = null;

						Effects.SendLocationParticles( EffectItem.Create( from, map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
						Effects.SendLocationParticles( EffectItem.Create(   to, map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 5023 );

						Effects.PlaySound( to, map, 0x1FE );

						m_HasTeleportedAway = true;
						m_SoundTimer = Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 2.5 ), new TimerCallback( SendTrackingSound ) );

						Frozen = true;

						break;
					}
				}
			}

			base.OnThink();
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RoseOfShangyang(), from);

                              from.SendMessage( "You carve up some shangyang parts." );
                              corpse.Carved = true; 
			}
                }

		public Shangyang( Serial serial ) : base( serial )
		{
		}

		public override int GetIdleSound() { return 0x07D; }
		public override int GetAngerSound() { return 0x07E; }
		public override int GetAttackSound() { return 0x07F; }
		public override int GetHurtSound() { return 0x080; }
		public override int GetDeathSound() { return 0x081; }

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