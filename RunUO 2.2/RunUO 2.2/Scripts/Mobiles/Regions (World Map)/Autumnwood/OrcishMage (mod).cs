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
	[CorpseName( "a glowing orc corpse" )]
	public class OrcishMage : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		[Constructable]
		public OrcishMage () : base( AIType.AI_Mage, FightMode.Closest, 5, 1, 0.2, 0.4 )
		{
			Name = "an orcish mage";
			Body = 140;
			BaseSoundID = 0x45A;

			SetStr( 117, 150 );
			SetDex( 92, 113 );
			SetInt( 168, 182 );

			SetHits( 140, 180 );
			SetMana( 840, 910 );

			SetDamage( 1, 4 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.EvalInt, 50.4, 53.6 );
			SetSkill( SkillName.Magery, 66.3, 76.6 );
			SetSkill( SkillName.MagicResist, 60.2, 74.8 );
			SetSkill( SkillName.Tactics, 50.6, 64.6 );
			SetSkill( SkillName.Wrestling, 49.5, 54.9 );

			Fame = 3000;
			Karma = -3000;

			PackGold( 129, 213 );
			PackReg( 25, 100 );

			PackItem( new ArcaneStone( Utility.RandomMinMax( 4, 6 ) ) );
			PackItem( new FishScale( Utility.RandomMinMax( 10, 15 ) ) );

			if ( 0.05 > Utility.RandomDouble() )
				PackItem( new OrcishKinMask() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.LowScrolls, 2 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(), from);
                        corpse.AddCarvedItem(new OrcHead(), from);

                        from.SendMessage( "You carve up a raw rib and the creatures head." );
                        corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

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
		public override int BreathAngerSound{ get{ return 0x45A; } }

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

		public override bool IsEnemy( Mobile m )
		{
			if ( m.Player && m.FindItemOnLayer( Layer.Helm ) is OrcishKinMask )
				return false;

			return base.IsEnemy( m );
		}

		public override void AggressiveAction( Mobile aggressor, bool criminal )
		{
			base.AggressiveAction( aggressor, criminal );

			Item item = aggressor.FindItemOnLayer( Layer.Helm );

			if ( item is OrcishKinMask )
			{
				AOS.Damage( aggressor, 50, 0, 100, 0, 0, 0 );
				item.Delete();
				aggressor.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
				aggressor.PlaySound( 0x307 );
			}
		}

		public OrcishMage( Serial serial ) : base( serial )
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
