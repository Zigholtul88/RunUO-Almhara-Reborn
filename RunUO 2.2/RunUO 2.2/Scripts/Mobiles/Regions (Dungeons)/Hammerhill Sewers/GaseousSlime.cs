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
	[CorpseName( "a farting slime corpse" )]
	public class GaseousSlime : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public GaseousSlime() : base( AIType.AI_Melee, FightMode.Closest, 4, 1, 0.175, 0.350 )
		{
			Name = "a gaseous slime";
			Body = 51;
                        Hue = 2126;

			SetStr( 35, 55 );
			SetDex( 15, 35 );
			SetInt( 5 );

			SetHits( 60, 80 );

			SetDamage( 1, 3 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Poison, 30 );

			SetResistance( ResistanceType.Physical, 12 );
			SetResistance( ResistanceType.Poison, 50 );

			SetSkill( SkillName.MagicResist, 6.9, 12.6 );
			SetSkill( SkillName.Poisoning, 43.9, 51.3 );
			SetSkill( SkillName.Tactics, 19.5, 28.4 );
			SetSkill( SkillName.Wrestling, 11.1, 16.7 );

			Fame = 5000;
			Karma = -5000;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 1.0;

			PackGold( 1, 5 );
			PackReg( 1, 5 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

                public override bool HasBreath{ get{ return true; } }

		public override double BreathMinDelay{ get{ return 5.0; } }
		public override double BreathMaxDelay{ get{ return 5.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 2126; } }
		public override int BreathEffectItemID{ get{ return 0x36BD; } }
		public override int BreathEffectSound{ get{ return 1064; } }
		public override int BreathAngerSound{ get{ return 1087; } }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish | FoodType.FruitsAndVegies | FoodType.GrainsAndHay | FoodType.Eggs; } }

		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override Poison HitPoison{ get{ return Poison.Regular; } }

		public override int GetIdleSound() { return 1087; } // play male puke
		public override int GetAttackSound() { return 1053; } //play male burp
		public override int GetHurtSound() { return 792; } //play female fart
		public override int GetAngerSound() { return 1053; } //play male burp
		public override int GetDeathSound() { return 1064; } //play male fart

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

			      from.PlaySound( from.Female ? 792 : 1064 );
			      from.Say( "*farts*" );
			}
                }

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

		private DateTime m_LastRadiated;
	        private Hashtable m_Mobiles = new Hashtable();

		protected override bool OnMove( Direction d )
		{
			if ( !IsDeadBondedPet )
			{
				if ( m_LastRadiated <= DateTime.Now )
					m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 2 ) );
				IPooledEnumerable eable = GetMobilesInRange( 2 );
				foreach( Mobile m in eable )
					if ( m_Mobiles[m] == null )
						m_Mobiles[m] = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( RadiationCallBack ), m );
			}

			return base.OnMove( d );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m_LastRadiated <= DateTime.Now )
					m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 2 ) );
			if ( !IsDeadBondedPet && m_Mobiles[m] == null && Utility.InRange( Location, m.Location, 2 ) && !Utility.InRange( Location, oldLocation, 2 ) )
				m_Mobiles[m] = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( RadiationCallBack ), m );

			base.OnMovement( m, oldLocation );
		}

		public void RadiationCallBack( object state )
		{
			Mobile m = (Mobile)state;

			if ( Deleted || !Alive || !Utility.InRange( Location, m.Location, 2 ) )
			{
				((Timer)m_Mobiles[m]).Stop();
				m_Mobiles[m] = null;
				return;
			}

			if ( this != m && m.Player && m.Alive && m_LastRadiated <= DateTime.Now && Server.Spells.SpellHelper.ValidIndirectTarget( m, this ) && CanBeBeneficial( m, false, false ) )
			{
	                        AOS.Damage( m, this, 0, 0, 0, 0, 0, 0, true );
		                m.Stam += ( Utility.Random( 1, 5 ) );

                                m.FixedParticles(0x36B0, 1, 14, 0x26BB, 0x3F, 0x7, EffectLayer.Waist);
                                m.PlaySound( m.Female ? 792 : 1064 );

				DoBeneficial( m );
				m.RevealingAction();

				m.SendMessage( "{0} has been gased!", m.Name );
				m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 5, 5 ) );
			}
		}

		public GaseousSlime( Serial serial ) : base( serial )
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

