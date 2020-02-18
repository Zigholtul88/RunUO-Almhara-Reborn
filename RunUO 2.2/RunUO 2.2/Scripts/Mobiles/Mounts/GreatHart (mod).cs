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
	[CorpseName( "a deer corpse" )]
	[TypeAlias( "Server.Mobiles.Greathart" )]
	public class GreatHart : BaseMount
	{
		[Constructable]
		public GreatHart() : this( "a great hart" )
		{
		}

		public override bool SubdueBeforeTame{ get{ return true; } } // Must be beaten into submission

		[Constructable]
		public GreatHart( string name ) : base( name, 0xEA, 0x3EB5, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			SetStr( 42, 70 );
			SetDex( 50, 71 );
			SetInt( 29, 55 );

			SetHits( 54, 82 );
			SetMana( 100 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 24 );
			SetResistance( ResistanceType.Cold, 5 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 30.4, 42.7 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 300;
			Karma = 0;

			VirtualArmor = 24;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 30.0;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new DeerHead(), from);
                              corpse.AddCarvedItem(new RawGroundVenison(), from);
                              corpse.AddCarvedItem(new RawVenisonRoast(), from);
                              corpse.AddCarvedItem(new RawVenisonSteak(), from);
                              corpse.AddCarvedItem(new Hides(15), from);
                              corpse.Carved = true; 

                              from.SendMessage( "You carve up some hides and deer parts." ); 
			}
                }

		public GreatHart(Serial serial) : base(serial)
		{
		}

		public override int GetAttackSound() 
		{ 
			return 0x82; 
		} 

		public override int GetHurtSound() 
		{ 
			return 0x83; 
		} 

		public override int GetDeathSound() 
		{ 
			return 0x84; 
		} 

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}