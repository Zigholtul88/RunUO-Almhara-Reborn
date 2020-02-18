//Created by Minth, Owner of Arise As The Gods.
//Modded by Zigholtul, Owner of Almhara Reborn.

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
	[CorpseName( "an al paca corpse" )]
	public class AlPaca : BaseMount
	{
		[Constructable]
		public AlPaca() : this( "an al paca" )
		{
		}

		[Constructable]
		public AlPaca( string name ) : base( name, 0xDC, 0x3EA6, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x3F3;

			SetStr( 350, 460 );
			SetDex( 156, 175 );
			SetInt( 16, 30 );

			SetHits( 425, 455 );
			SetMana( 0 );

			SetDamage( 15, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 35 );
			SetResistance( ResistanceType.Cold, 35 );
			SetResistance( ResistanceType.Poison, -50 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.MagicResist, 45.1, 50.0 );
			SetSkill( SkillName.Tactics, 79.2, 89.0 );
			SetSkill( SkillName.Wrestling, 85.2, 95.0 );

			Fame = 8000;
			Karma = -8000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.MedScrolls, 1 );
			AddLoot( LootPack.LowScrolls, 4 );
			AddLoot( LootPack.Gems, 2 );
	        }

		public override bool HasBreath{ get{ return true; } } // spit enabled

		public override double BreathMinDelay{ get{ return 1.0; } }
		public override double BreathMaxDelay{ get{ return 10.0; } }

		public override int BreathPhysicalDamage{ get{ return 100; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 356; } }
		public override int BreathEffectItemID{ get{ return 0x36D4; } }
		public override int BreathEffectSound{ get{ return 1094; } }
		public override int BreathAngerSound{ get{ return 1088; } }

		public override bool CanRummageCorpses{ get{ return true; } }

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 24; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new AlPacaEye( amount ), from );

                              from.SendMessage( "You carve up some al paca parts." );
                              corpse.Carved = true; 
			}
                }

		public AlPaca( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}