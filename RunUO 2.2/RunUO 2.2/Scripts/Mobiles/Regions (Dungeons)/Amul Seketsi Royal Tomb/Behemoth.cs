using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.ContextMenus;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a behemoth corpse" )]
	public class Behemoth : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ConcussionBlow;
		}

		[Constructable]
		public Behemoth() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = "a behemoth";
			Body = 1071;
                        Hue = 1769;

			SetStr( 331, 360 );
			SetDex( 66, 85 );
			SetInt( 41, 65 );

			SetHits( 555, 600 );

			SetDamage( 15, 23 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45 );
			SetResistance( ResistanceType.Fire, 45 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.MagicResist, 5.1, 10.5 );
			SetSkill( SkillName.Tactics, 75.1, 90.0 );
			SetSkill( SkillName.Wrestling, 70.1, 90.0 );

			Fame = 27500;
			Karma = -27500;

			PackItem( new MeteorSwarmScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
			AddLoot( LootPack.Gems, 2 );
	        }

                public override bool HasBreath{ get{ return true; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 100; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 1281; } }
		public override int BreathEffectItemID{ get{ return 0x36D4; } }
		public override int BreathEffectSound{ get{ return 0x160; } }
		public override int BreathAngerSound{ get{ return 0x597; } }

		public override bool CanRummageCorpses{ get{ return true; } }

		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		public override int GetAttackSound() { return 0x599; } 
		public override int GetIdleSound() { return 0x596; } 
		public override int GetAngerSound() { return 0x597; } 
		public override int GetHurtSound() { return 0x59a; } 
		public override int GetDeathSound() { return 0x59c; }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(15), from);
                              corpse.AddCarvedItem(new Hides(35), from);
                              corpse.AddCarvedItem(new MeteorSwarmScroll(), from);

                              from.SendMessage( "You carve up raw ribs, hides, and a meteor swarm scroll." );
                              corpse.Carved = true; 
			}
                }

		public Behemoth( Serial serial ) : base( serial )
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