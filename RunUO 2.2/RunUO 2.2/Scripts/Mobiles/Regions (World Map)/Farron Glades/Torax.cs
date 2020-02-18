//Created by Minth, Owner of Arise As The Gods.
//Modded by Zigholtul, Owner of Almhara Reborn.

using System;
using System.Collections;
using Server.Items;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a Torax corpse" )]
	public class Torax : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Torax() : base( AIType.AI_Melee, FightMode.Closest, 6, 1, 0.2, 0.4 )
		{
			Name = "a Torax";
			Body = 0xCE;
			BaseSoundID = 0x388;
                        Hue = 0x648;

			SetStr( 440, 555 );
			SetDex( 128, 157 );
			SetInt( 136, 160 );

			SetHits( 540, 555 );
			SetMana( 0 );

			SetDamage( 12, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, -50 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.MagicResist, 36.9, 45.8 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 95.0, 100.2 );

			Fame = 6000;
			Karma = -6000;

			PackGold( 36, 65 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 1 );
			AddLoot( LootPack.MedScrolls, 2 );
			AddLoot( LootPack.LowScrolls, 4 );
			AddLoot( LootPack.Gems, 2 );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.2 < Utility.RandomDouble() )
				return;

			switch ( Utility.Random( 2 ) )
			{
				case 0:
				{
					defender.SendMessage( "The Torax Has Bitten You!" ); 
			                defender.PlaySound( 0x597 );
					AOS.Damage( defender, this, Utility.Random( 95, 65 ), 100, 0, 0, 0, 0 );
					break;
				}
				case 1:
				{
					defender.SendAsciiMessage( "The Torax Is Using Its Head As A Battering Ram And Slams Into You!" );
			                defender.PlaySound( 0x599 );
					defender.Freeze( TimeSpan.FromSeconds( 3.0 ) );
					IMount mount = defender.Mount;

					if ( mount != null )
					mount.Rider = null;

					if ( defender.Mounted )
					return;

					AOS.Damage( defender, this, Utility.Random( 45, 40 ), 100, 0, 0, 0, 0 );
					break;
				}
			}
		}

		public Torax( Serial serial ) : base( serial )
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