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
	[CorpseName( "a forest bat corpse" )]
	public class ForestBat : BaseCreature
	{
		[Constructable]
		public ForestBat() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			CurrentSpeed = BoostedSpeed;
			RangePerception = 200;

			Name = "a forest bat";
			Body = 317;
                        Hue = 1237;
			BaseSoundID = 0x270;

			SetStr( 47, 65 );
			SetDex( 78, 83 );
			SetInt( 15, 28 );

			SetMana( 100 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 8 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.MagicResist, 19.9, 27.3 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 300;
			Karma = -300;

                        Flying = true;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 5.5;

			PackGold( 56, 101 );

			PackItem( new BlackPearl( Utility.RandomMinMax( 18, 45 ) ) );

			if ( 0.10 > Utility.RandomDouble() )
				PackItem( new Apple() );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override int GetIdleSound() { return 0x29B; } 
		public override bool CanRummageCorpses{ get{ return true; } }

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{      
 			if ( !Flying && Utility.RandomDouble() < 0.25 )
                        {
                                 Flying = true;
			         CurrentSpeed = BoostedSpeed;
				 from.SendMessage( "The forest bat has taken flight" );
                        }

			base.OnDamage( amount, from, willKill );
                }

		public override void OnDamagedBySpell( Mobile from )
		{
			if ( Flying )
			{
                                Flying = false;
				from.SendMessage( "The forest bat has landed" );
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
				     attacker.SendMessage( "The forest bat has landed" );
                                     Flying = false;
				     CurrentSpeed = PassiveSpeed;
			        }
			}
			else if ( Flying )
			{
				attacker.SendMessage( "Your weapon misses the forest bat" );
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
							damage *= 2;
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
							damage *= 2;
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
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new RawForestBatRibs( amount ), from );
                              corpse.AddCarvedItem(new ForestBatClaw( amount ), from );

                              from.SendMessage( "You carve up a raw forest bat rib and a bat claw." );
                              corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.ZaythalorPredator; }
		}

		public ForestBat( Serial serial ) : base( serial )
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