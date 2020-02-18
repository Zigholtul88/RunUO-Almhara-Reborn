using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an ophidian corpse" )]
	public class OphidianMatriarch : BaseCreature
	{
		[Constructable]
		public OphidianMatriarch() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ophidian" );
			Title = "the ophidian matriarch"; 
			Body = 87;
			BaseSoundID = 644;

			SetStr( 439, 489 );
			SetDex( 109 );
			SetInt( 375, 441 );

			SetHits( 2000, 2606 );
			SetMana( 2050, 2215 );

			SetDamage( 11, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 35 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.EvalInt, 55.6, 78.9 );
			SetSkill( SkillName.Magery, 93.5, 99.8 );
			SetSkill( SkillName.Meditation, 78.9, 89.5 );
			SetSkill( SkillName.MagicResist, 93.7, 98.2 );
			SetSkill( SkillName.Tactics, 60.3, 67.1 );
			SetSkill( SkillName.Wrestling, 66.8, 67.6 );

			Fame = 16000;
			Karma = -16000;

			PackGold( 1171, 2083 );
			PackReg( 100, 150 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new EnergyVortexScroll() );

			Timer.DelayCall(TimeSpan.FromSeconds(1), new TimerCallback(SpawnOphidians));
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.HighScrolls, 5 );
			AddLoot( LootPack.MedScrolls, 7 );
			AddLoot( LootPack.LowScrolls, 9 );
			AddLoot( LootPack.Gems, 15 );
			AddLoot( LootPack.Potions );
		}

		public override Poison PoisonImmune{ get{ return Poison.Greater; } }

		public override bool HasBreath{ get{ return true; } } // energy bolt enabled

		public override double BreathMinDelay{ get{ return 1.0; } }
		public override double BreathMaxDelay{ get{ return 10.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x379F; } }
		public override int BreathEffectSound{ get{ return 0x20A; } }
		public override int BreathAngerSound{ get{ return 639; } }

		private DateTime m_NextAttack;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextAttack )
			{
				SandAttack( combatant );
				m_NextAttack = DateTime.Now + TimeSpan.FromSeconds( 10.0 + (10.0 * Utility.RandomDouble()) );
			}
		}

		public void SandAttack( Mobile m )
		{
			DoHarmful( m );

			m.FixedParticles( 0x36B0, 10, 25, 9540, 2413, 0, EffectLayer.Waist );

			new InternalTimer( m, this ).Start();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile, m_From;

			public InternalTimer( Mobile m, Mobile from ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				m_Mobile.PlaySound( 0x4CF );
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 1, 30 ), 90, 10, 0, 0, 0 );
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(2), from);
                              corpse.AddCarvedItem(new SerpentScale( Utility.RandomMinMax( 26, 37 )), from);
                              corpse.AddCarvedItem(new OphidianEye(), from);

                              from.SendMessage( "You carve up raw ribs, serpent scales, and an ophidian eye." );
                              corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

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
			int damage = 45;
			this.MovingEffect( to, 0x36E4, 10, 0, false, false );
			this.DoHarmful( to );
			this.PlaySound( 0x1E5 ); // magic arrow
			AOS.Damage( to, this, damage, 0, 100, 0, 0, 0 );
		}

		public override void OnGaveMeleeAttack(Mobile defender)
		{
			base.OnGaveMeleeAttack(defender);
			if (0.1 >= Utility.RandomDouble())
				Earthquake();
		}

		public void Earthquake()
		{
			Map map = this.Map;
			if (map == null)
				return;
			ArrayList targets = new ArrayList();
			foreach (Mobile m in this.GetMobilesInRange(8))
			{
				if (m == this || !CanBeHarmful(m))
					continue;
				if (m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team))
					targets.Add(m);
				else if (m.Player)
					targets.Add(m);
			}
			PlaySound(0x2F3);
			for (int i = 0; i < targets.Count; ++i)
			{
				Mobile m = (Mobile)targets[i];
				if( m != null && !m.Deleted && m is PlayerMobile )
				{
					PlayerMobile pm = m as PlayerMobile;
					if(pm != null && pm.Mounted)
					{
						pm.Mount.Rider=null;
					}
				}
				double damage = m.Hits * 0.6;//was .6
				if (damage < 10.0)
					damage = 10.0;
				else if (damage > 75.0)
					damage = 75.0;
				DoHarmful(m);
				AOS.Damage(m, this, (int)damage, 100, 0, 0, 0, 0);
				if (m.Alive && m.Body.IsHuman && !m.Mounted)
					m.Animate(20, 7, 1, true, false, 0); // take hit
			}
		}

		public OphidianMatriarch( Serial serial ) : base( serial )
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
		#region SpawnHelpers
		public void SpawnOphidians()
		{
			BaseCreature spawna = new OphidianEnforcer();
			spawna.MoveToWorld(Location, Map);

			BaseCreature spawnb = new OphidianShaman();
			spawnb.MoveToWorld(Location, Map);

			BaseCreature spawnc = new OphidianWarrior();
			spawnc.MoveToWorld(Location, Map);

			BaseCreature spawnd = new OphidianZealot();
			spawnd.MoveToWorld(Location, Map);
		}
		#endregion
	}
}
