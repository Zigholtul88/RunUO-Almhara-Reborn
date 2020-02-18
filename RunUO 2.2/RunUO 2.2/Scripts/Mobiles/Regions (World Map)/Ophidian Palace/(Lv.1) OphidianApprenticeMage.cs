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
	[CorpseName( "an ophidian corpse" )]
	public class OphidianApprenticeMage : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public OphidianApprenticeMage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ophidian" );
			Title = "the ophidian apprentice mage"; 
			Body = 85;
			BaseSoundID = 639;

			SetStr( 183, 204 );
			SetDex( 191, 213 );
			SetInt( 97, 120 );

			SetHits( 218, 246 );
			SetMana( 485, 600 );

			SetDamage( 5, 10 );

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

			Fame = 4000;
			Karma = -4000;

			PackGold( 227, 331 );
			PackReg( 25, 55 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new BladeSpiritsScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );
			AddLoot( LootPack.LowScrolls, 2 );
		}

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
			int damage = 10;
			this.MovingEffect( to, 0x36E4, 10, 0, false, false );
			this.DoHarmful( to );
			this.PlaySound( 0x1E5 ); // magic arrow
			AOS.Damage( to, this, damage, 0, 100, 0, 0, 0 );
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new RawRibs( amount ), from );
                              corpse.AddCarvedItem(new SerpentScale( Utility.RandomMinMax( 11, 16 )), from);
                              corpse.AddCarvedItem(new OphidianEye(), from);

                              from.SendMessage( "You carve up raw ribs, serpent scales, and an ophidian eye." );
                              corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public OphidianApprenticeMage( Serial serial ) : base( serial )
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