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
	[CorpseName( "a mountain giant corpse" )]
	public class MountainGiant : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public MountainGiant() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a mountain giant";
			Body = 382;
			BaseSoundID = 604;

			SetStr( 336, 385 );
			SetDex( 96, 115 );
			SetInt( 31, 55 );

			SetHits( 604, 862 );
			SetMana( 0 );

			SetDamage( 15, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.MagicResist, 60.3, 105.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.Wrestling, 80.1, 90.0 );

			Fame = 4500;
			Karma = -4500;

			PackGold( 658, 703 );

			PackItem( new Bloodstone( Utility.RandomMinMax( 1, 5 ) ) );
			PackItem( new FishScale( Utility.RandomMinMax( 15, 18 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new ArchProtectionScroll() );

			if ( 0.2 > Utility.RandomDouble() )
				PackItem( new GargoylesPickaxe() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 6 );
			AddLoot( LootPack.Potions, 5 );
		}

		public override int Meat{ get{ return 4; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.2 < Utility.RandomDouble() )
				return;

			switch ( Utility.Random( 3 ) )
			{
				case 0:
				{
					defender.SendLocalizedMessage( 1004014 ); // You have been stunned!
					defender.Freeze( TimeSpan.FromSeconds( 4.0 ) );
					break;
				}
				case 1:
				{
					defender.SendAsciiMessage( "You have been hit by a paralyzing blow!" );
					defender.Freeze( TimeSpan.FromSeconds( 3.0 ) );
					break;
				}
				case 2:
				{
					AOS.Damage( defender, this, Utility.Random( 10, 5 ), 100, 0, 0, 0, 0 );
					defender.SendAsciiMessage( "You have been hit by a critical strike!" );
					break;
				}
			}
		}

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.4 > Utility.RandomDouble() )
			{
				ThrowHatchet( from );
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if( attacker != null && attacker.Alive && attacker.Weapon is BaseRanged && 0.4 > Utility.RandomDouble() )
			{
				ThrowHatchet( attacker );
			}
		}

		public void ThrowHatchet( Mobile to )
		{
			int damage = 50;
			this.MovingEffect( to, 0xF43, 10, 0, false, false );
			this.DoHarmful( to );
			AOS.Damage( to, this, damage, 100, 0, 0, 0, 0 );
		}

		public MountainGiant( Serial serial ) : base( serial )
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