using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a pig corpse" )]
	public class Pig : BaseCreature
	{
		[Constructable]
		public Pig() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a pig";
			Body = 0xCB;
			BaseSoundID = 0xC4;

			SetStr( 20 );
			SetDex( 20 );
			SetInt( 10 );

			SetHits( 24 );
			SetMana( 100 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 12 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 5.0 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 150;
			Karma = 0;

			VirtualArmor = 12;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 11.1;
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

		public Pig(Serial serial) : base(serial)
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