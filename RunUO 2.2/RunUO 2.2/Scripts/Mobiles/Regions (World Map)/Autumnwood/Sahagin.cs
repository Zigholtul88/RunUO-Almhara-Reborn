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
	[CorpseName( "a sahagin corpse" )]
	public class Sahagin : BaseCreature
	{
		[Constructable]
		public Sahagin() : base( AIType.AI_Melee, FightMode.Closest, 6, 1, 0.2, 0.4 )
		{
			Name = "a sahagin";
			Body = 796;
			BaseSoundID = 0x275;

			SetStr( 144, 179 );
			SetDex( 75, 81 );
			SetInt( 22, 36 );

			SetHits( 175, 200 );

			SetDamage( 1, 3 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.Anatomy, 57.9, 62.4 );
			SetSkill( SkillName.Fencing, 92.7, 98.1 );
			SetSkill( SkillName.MagicResist, 35.1, 37.2 );
			SetSkill( SkillName.Ninjitsu, 60.0 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 2800;
			Karma = -2800;

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 106, 212 ) ) );
			pack.DropItem( Loot.RandomStatue() );
			pack.DropItem( new Pearl() );

			if ( 0.04 > Utility.RandomDouble() )
				pack.DropItem( new TurquoiseCustom() );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( Loot.RandomGem() );

			PackItem( pack );

			switch ( Utility.Random( 3 ))
			{
				case 0: AddItem( Loot.RandomArmor() ); break;
				case 1: AddItem( Loot.RandomClothing() ); break;
				case 2: AddItem( Loot.RandomWeapon() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from != null && from != this )
			{
				if ( from is PlayerMobile )
				{
					PlayerMobile p_PlayerMobile = from as PlayerMobile;
					Item weapon1 = p_PlayerMobile.FindItemOnLayer( Layer.OneHanded );
					Item weapon2 = p_PlayerMobile.FindItemOnLayer( Layer.TwoHanded );

					if ( weapon1 != null )
					{
						if ( weapon1 is BaseKnife )
						{
							damage *= 2;
						}
						else if ( weapon1 is BaseSpear )
						{
							damage *= 4;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseKnife )
						{
							damage *= 2;
						}
						else if ( weapon2 is BaseSpear )
						{
							damage *= 4;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
				}
			}
		}

		public override bool CanRummageCorpses{ get{ return true; } }

		public override bool HasBreath{ get{ return true; } } // fish throw enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 100; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x0DD9; } }
		public override int BreathEffectSound{ get{ return 0x025; } }
		public override int BreathAngerSound{ get{ return 0x275; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new SahaginScale( amount ), from );

                              corpse.AddCarvedItem( new RawFishSteak( Utility.RandomMinMax( 9, 13 ) ), from );
                              corpse.AddCarvedItem( new FishScale( Utility.RandomMinMax( 12, 15 ) ), from );

                              from.SendMessage( "You carve up raw fish steaks, fish scales and a sahagin scale." ); 
                              corpse.Carved = true;
			}
                }

		public Sahagin( Serial serial ) : base( serial )
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
