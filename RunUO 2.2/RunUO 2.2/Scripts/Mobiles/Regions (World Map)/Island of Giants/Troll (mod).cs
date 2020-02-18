using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a troll corpse" )]
	public class Troll : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}

		[Constructable]
		public Troll() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.2, 0.4 )
		{
			Name = "a troll";
			Body = Utility.RandomList( 53, 54 );
			BaseSoundID = 461;

   			if ( Body == 54 ) //Axe
   			{
  				DamageMin += 2;
   				DamageMax += 5;
   				RawStr += 100;
   				RawDex -= 25;
				Skills.Swords.Base += 80;
				Skills.Lumberjacking.Base += 70;
   			}

			SetStr( 177, 204 );
			SetDex( 50, 64 );
			SetInt( 47, 63 );

			SetHits( 212, 246 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.Healing, 45.8, 60.2 );
			SetSkill( SkillName.MagicResist, 45.1, 53.8 );
			SetSkill( SkillName.Tactics, 50.1, 68.8 );
			SetSkill( SkillName.Wrestling, 70.3, 81.3 );

			Fame = 3500;
			Karma = -3500;

			PackGold( 214, 219 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new StrengthScroll() );

			PackItem( new Arrow( Utility.RandomMinMax( 8, 13 ) ) ); 

		}

		public override bool CanRummageCorpses{ get{ return true; } }

		public override bool HasBreath{ get{ return true; } } // spear throw enabled

		public override double BreathMinDelay{ get{ return 1.0; } }
		public override double BreathMaxDelay{ get{ return 15.0; } }

		public override int BreathPhysicalDamage{ get{ return 100; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x0F63; } }
		public override int BreathEffectSound{ get{ return 0x5D2; } }
		public override int BreathAngerSound{ get{ return 461; } }

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
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(2), from);
                              corpse.AddCarvedItem(new TrollTooth(), from);

                              from.SendMessage( "You carve up some raw ribs and a troll tooth." );
                              corpse.Carved = true; 
			}
                }

		public Troll( Serial serial ) : base( serial )
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
