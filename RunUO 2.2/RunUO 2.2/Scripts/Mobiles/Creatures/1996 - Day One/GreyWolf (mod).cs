using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a grey wolf corpse" )]
	[TypeAlias( "Server.Mobiles.Greywolf" )]
	public class GreyWolf : BaseCreature
	{
		[Constructable]
		public GreyWolf() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a grey wolf";
			Body = Utility.RandomList( 25, 27 );
			BaseSoundID = 0xE5;

			SetStr( 57, 80 );
			SetDex( 56, 75 );
			SetInt( 31, 55 );

			SetHits( 68, 96 );
			SetMana( 0 );

			SetDamage( 3, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 18 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 20.8, 53.3 );
			SetSkill( SkillName.Tactics, 45.3, 60.0 );
			SetSkill( SkillName.Wrestling, 49.5, 61.9 );

			Fame = 450;
			Karma = 0;

			VirtualArmor = 18;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 53.1;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

            public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(), from);
                        corpse.AddCarvedItem(new Hides(5), from);
                        corpse.AddCarvedItem(new RawGreyWolfLeg(2), from);

                        from.SendMessage( "You carve up a raw rib, hides, and two raw wolf legs." ); 
			}
            }

		public GreyWolf(Serial serial) : base(serial)
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