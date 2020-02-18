using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "an ophidian corpse" )]
	public class OphidianShaman : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public OphidianShaman() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ophidian" );
			Title = "the ophidian shaman";
			Body = 85;
			BaseSoundID = 639;

			SetStr( 283, 304 );
			SetDex( 191, 213 );
			SetInt( 397, 420 );

			SetHits( 218, 246 );
			SetMana( 685, 800 );

			SetDamage( 8, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 35 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.EvalInt, 40.4, 63.6 );
			SetSkill( SkillName.Magery, 87.9, 98.9 );
			SetSkill( SkillName.MagicResist, 84.4, 88.0 );
			SetSkill( SkillName.Tactics, 72.9, 78.0 );
			SetSkill( SkillName.Wrestling, 35.2, 61.6 );

			Fame = 5000;
			Karma = -5000;

			PackGold( 216, 342 );
			PackReg( 25, 55 );

			PackItem( new ArcaneStone( Utility.RandomMinMax( 4, 6 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new BladeSpiritsScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions, 3 );
			AddLoot( LootPack.LowScrolls, 4 );
			AddLoot( LootPack.MedScrolls );
		}

		public override bool CanRummageCorpses{ get{ return true; } }

		public override bool HasBreath{ get{ return true; } } // energy bolt enabled

		public override double BreathMinDelay{ get{ return 5.0; } }
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

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.4 > Utility.RandomDouble() )
			{
				ShootMagicArrow( from );
			}
		}

		public void ShootMagicArrow( Mobile to )
		{
			int damage = 15;
			this.MovingEffect( to, 0x36E4, 10, 0, false, false );
			this.DoHarmful( to );
			this.PlaySound( 0x1E5 ); // magic arrow
			AOS.Damage( to, this, damage, 0, 100, 0, 0, 0 );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( 0.1 > Utility.RandomDouble() )
				BeginSavageDance();
		}

		public void BeginSavageDance()
		{
			if( this.Map == null )
				return;

			ArrayList list = new ArrayList();

			foreach ( Mobile m in this.GetMobilesInRange( 8 ) )
			{
				if ( m != this && m is OphidianShaman )
					list.Add( m );
			}

			Animate( 111, 5, 1, true, false, 0 ); // Do a little dance...

			if ( AIObject != null )
				AIObject.NextMove = DateTime.Now + TimeSpan.FromSeconds( 1.0 );

			if ( list.Count >= 3 )
			{
				for ( int i = 0; i < list.Count; ++i )
				{
					OphidianShaman dancer = (OphidianShaman)list[i];

					dancer.Animate( 111, 5, 1, true, false, 0 ); // Get down tonight...

					if ( dancer.AIObject != null )
						dancer.AIObject.NextMove = DateTime.Now + TimeSpan.FromSeconds( 1.0 );
				}

				Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerCallback( EndSavageDance ) );
			}
		}

		public void EndSavageDance()
		{
			if ( Deleted )
				return;

			ArrayList list = new ArrayList();

			foreach ( Mobile m in this.GetMobilesInRange( 8 ) )
				list.Add( m );

			if ( list.Count > 0 )
			{
				switch ( Utility.Random( 3 ) )
				{
					case 0: /* greater heal */
					{
						foreach ( Mobile m in list )
						{
							bool isFriendly = ( m is OphidianApprenticeMage || m is OphidianEnforcer || m is OphidianWarrior || m is OphidianJusticar || m is OphidianShaman || m is OphidianAvenger || m is OphidianKnightErrant || m is OphidianZealot || m is OphidianMatriarch );

							if ( !isFriendly )
								continue;

							if ( m.Poisoned || MortalStrike.IsWounded( m ) || !CanBeBeneficial( m ) )
								continue;

							DoBeneficial( m );

							// Algorithm: (40% of magery) + (1-10)

							int toHeal = (int)(Skills[SkillName.Magery].Value * 0.4);
							toHeal += Utility.Random( 1, 10 );

							m.Heal( toHeal, this );

							m.FixedParticles( 0x376A, 9, 32, 5030, EffectLayer.Waist );
							m.PlaySound( 0x202 );
						}

						break;
					}
					case 1: /* lightning */
					{
						foreach ( Mobile m in list )
						{
							bool isFriendly = ( m is OphidianApprenticeMage || m is OphidianEnforcer || m is OphidianWarrior || m is OphidianJusticar || m is OphidianShaman || m is OphidianAvenger || m is OphidianKnightErrant || m is OphidianZealot || m is OphidianMatriarch );

							if ( isFriendly )
								continue;

							if ( !CanBeHarmful( m ) )
								continue;

							DoHarmful( m );

							double damage;

							if ( Core.AOS )
							{
								int baseDamage = 6 + (int)(Skills[SkillName.EvalInt].Value / 5.0);

								damage = Utility.RandomMinMax( baseDamage, baseDamage + 3 );
							}
							else
							{
								damage = Utility.Random( 12, 9 );
							}

							m.BoltEffect( 0 );

							SpellHelper.Damage( TimeSpan.FromSeconds( 0.25 ), m, this, damage, 0, 0, 0, 0, 100 );
						}

						break;
					}
					case 2: /* poison */
					{
						foreach ( Mobile m in list )
						{
							bool isFriendly = ( m is OphidianApprenticeMage || m is OphidianEnforcer || m is OphidianWarrior || m is OphidianJusticar || m is OphidianShaman || m is OphidianAvenger || m is OphidianKnightErrant || m is OphidianZealot || m is OphidianMatriarch );

							if ( isFriendly )
								continue;

							if ( !CanBeHarmful( m ) )
								continue;

							DoHarmful( m );

							if ( m.Spell != null )
								m.Spell.OnCasterHurt();

							m.Paralyzed = false;

							double total = Skills[SkillName.Magery].Value + Skills[SkillName.Poisoning].Value;

							double dist = GetDistanceToSqrt( m );

							if ( dist >= 3.0 )
								total -= (dist - 3.0) * 10.0;

							int level;

							if ( total >= 200.0 && Utility.Random( 1, 100 ) <= 10 )
								level = 3;
							else if ( total > 170.0 )
								level = 2;
							else if ( total > 130.0 )
								level = 1;
							else
								level = 0;

							m.ApplyPoison( this, Poison.GetPoison( level ) );

							m.FixedParticles( 0x374A, 10, 15, 5021, EffectLayer.Waist );
							m.PlaySound( 0x474 );
						}

						break;
					}
				}
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem( new RawRibs( amount ), from );
                              corpse.AddCarvedItem( new SerpentScale( Utility.RandomMinMax( 11, 16 ) ), from );
                              corpse.AddCarvedItem( new OphidianEye(), from );

                              from.SendMessage( "You carve up raw ribs, serpent scales, and an ophidian eye." );
                              corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public OphidianShaman( Serial serial ) : base( serial )
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