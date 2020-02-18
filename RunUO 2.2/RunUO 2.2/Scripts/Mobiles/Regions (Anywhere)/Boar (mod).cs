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
	[CorpseName( "a pig corpse" )]
	public class Boar : BaseCreature
	{
		[Constructable]
		public Boar() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a boar";
			Body = 0x122;
			BaseSoundID = 0xC4;

			SetStr( 25 );
			SetDex( 15 );
			SetInt( 5 );

			SetHits( 30 );
			SetMana( 100 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.MagicResist, 9.0 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 300;
			Karma = 0;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 29.1;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new PorkHock(), from);
                              corpse.AddCarvedItem(new RawBaconSlab(), from);
                              corpse.AddCarvedItem(new RawGroundPork(), from);
                              corpse.AddCarvedItem(new RawHam(), from);
                              corpse.AddCarvedItem(new RawPigHead(), from);
                              corpse.AddCarvedItem(new RawPorkChop(), from);
                              corpse.AddCarvedItem(new RawPorkRoast(), from);
                              corpse.AddCarvedItem(new RawSpareRibs(), from);
                              corpse.AddCarvedItem(new RawTrotters(), from);

                              corpse.Carved = true; 

                              from.SendMessage( "You carve up some pig parts." ); 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.ZaythalorPredator; }
		}

		public Boar(Serial serial) : base(serial)
		{
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