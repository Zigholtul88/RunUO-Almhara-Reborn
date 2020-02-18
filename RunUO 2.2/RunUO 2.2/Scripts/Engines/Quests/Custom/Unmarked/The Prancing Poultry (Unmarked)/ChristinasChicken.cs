using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a chicken corpse" )]
	public class ChristinasChicken : BaseCreature
	{
		[Constructable]
		public ChristinasChicken() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a missing chicken";
			Body = 0xD0;
			BaseSoundID = 0x6E;

			SetStr( 10 );
			SetDex( 15 );
			SetInt( 10 );

			SetHits( 6 );
			SetMana( 0 );

			SetDamage( 1 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 2 );

			Fame = 150;
			Karma = 0;

			VirtualArmor = 2;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = -25.0;

			if ( 0.15 > Utility.RandomDouble() )
				PackItem( new Eggs() );
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawBird(), from);
                        corpse.AddCarvedItem(new RawChickenLeg(2), from);
                        corpse.AddCarvedItem(new Feather(25), from);

                        from.SendMessage( "You carve up some raw bird, legs, and feathers." ); 
			}
                }

		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay; } }

		public ChristinasChicken(Serial serial) : base(serial)
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