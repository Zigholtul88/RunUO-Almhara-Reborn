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
	[CorpseName( "a water elemental corpse" )]
	public class WaterElemental : BaseCreature
	{
		[Constructable]
		public WaterElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a water elemental";
			Body = 16;
			BaseSoundID = 278;

			SetStr( 126, 154 );
			SetDex( 67, 81 );
			SetInt( 102, 124 );

			SetHits( 152, 186 );
			SetMana( 510, 620 );

			SetDamage( 7, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 60 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.EvalInt, 50.4, 53.6 );
			SetSkill( SkillName.Magery, 66.3, 78.6 );
			SetSkill( SkillName.MagicResist, 101.6, 114.8 );
			SetSkill( SkillName.Tactics, 50.8, 67.7 );
			SetSkill( SkillName.Wrestling, 55.1, 69.1 );

			Fame = 14500;
			Karma = -14500;

			CanSwim = true;

                        PackGold( 15, 29 ); 
			PackItem( new BlackPearl( 3 ) );

			PackItem( new Pearl() );

			PackItem( new ElementalDust( Utility.RandomMinMax( 5, 10 ) ) );

 			if ( Utility.RandomDouble() < 0.15 )
				PackItem( new SummonWaterElementalScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Potions );
		}

		public override bool BleedImmune{ get{ return true; } }

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{      
 			if ( !Flying && Utility.RandomDouble() < 0.25 )
                        {
                                 from.PlaySound( 0x107 );
		                 this.FixedParticles( 0x375A, 1, 30, 9966, 88, 2, EffectLayer.Head ); 
           	                 this.FixedParticles( 0x37B9, 1, 30, 9502, 85, 3, EffectLayer.Head );
		                 this.FixedParticles( 0x376A, 1, 31, 9961, 80, 0, EffectLayer.Waist );
           	                 this.FixedParticles( 0x37C4, 1, 31, 9502, 88, 2, EffectLayer.Waist );

                                 Flying = true;
				 from.SendMessage( "The water elemental throws up a barrier" );
                        }

			base.OnDamage( amount, from, willKill );
                }

		public override void OnDamagedBySpell( Mobile from )
		{
			if ( Flying )
			{
                                from.PlaySound( 0x5CE );
		                this.BoltEffect( 0x480 );
                                Flying = false;
				from.SendMessage( "The water elemental's barrier has shattered" );
				CurrentSpeed = PassiveSpeed;
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if( attacker != null && attacker.Alive && attacker.Weapon is BaseRanged )
			{
			        if ( Flying )
			        {
				     PlaySound( 0x238 );
				     attacker.SendMessage( "Your weapon phases through the barrier" );
			        }
			}
			else if ( Flying )
			{
				PlaySound( 0x238 );
				attacker.SendMessage( "Your weapon phases through the barrier" );
			}
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( Flying )
				damage = 0; // no melee damage when flying
		}

		public WaterElemental( Serial serial ) : base( serial )
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
