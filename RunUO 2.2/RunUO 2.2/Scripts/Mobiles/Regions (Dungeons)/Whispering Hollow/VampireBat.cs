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
	[CorpseName( "a vampire bat corpse" )]
	public class VampireBat : BaseCreature
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
		public VampireBat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a vampire bat";
			Body = 317;
			BaseSoundID = 0x270;

			SetStr( 91, 110 );
			SetDex( 91, 115 );
			SetInt( 26, 50 );

			SetHits( 455, 566 );

			SetDamage( 4, 5 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 60 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.MagicResist, 70.1, 95.0 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 11000;
			Karma = -11000;

			PackGold( 213, 316 );
			PackReg( 42, 76 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 3 );
			AddLoot( LootPack.Potions );
		}

		public override int GetIdleSound()
		{
			return 0x29B;
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{      
 			if ( !Flying && Utility.RandomDouble() < 0.25 )
                        {
                                 Flying = true;
			         CurrentSpeed = BoostedSpeed;
				 from.SendMessage( "The vampire bat has taken flight" );
                        }

			base.OnDamage( amount, from, willKill );
                }

		public override void OnDamagedBySpell( Mobile from )
		{
			if ( Flying )
			{
                                Flying = false;
				from.SendMessage( "The vampire bat has landed" );
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
				     attacker.SendMessage( "The vampire bat has landed" );
                                     Flying = false;
				     CurrentSpeed = PassiveSpeed;
			        }
			}
			else if ( Flying )
			{
				attacker.SendMessage( "Your weapon misses the vampire bat" );
			}
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( Flying )
				damage = 0; // no melee damage when flying

			if ( from != null && from != this )
			{
				if ( from is PlayerMobile )
				{
					PlayerMobile p_PlayerMobile = from as PlayerMobile;
					Item weapon1 = p_PlayerMobile.FindItemOnLayer( Layer.OneHanded );
					Item weapon2 = p_PlayerMobile.FindItemOnLayer( Layer.TwoHanded );

					if ( weapon1 != null )
					{
						if ( weapon1 is BaseRanged )
						{
							damage += 5;
						}
                                                else
                                                {
							damage -= 5;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseRanged )
						{
							damage += 5;
						}
                                                else
                                                {
							damage -= 5;
                                                }
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

                              corpse.AddCarvedItem(new RawForestBatRibs( amount ), from );
                              corpse.AddCarvedItem(new VampireBatClaw( amount ), from );

                              from.SendMessage( "You carve up a raw forest bat rib and a bat claw." );
                              corpse.Carved = true; 
			}
                }

		public VampireBat( Serial serial ) : base( serial )
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