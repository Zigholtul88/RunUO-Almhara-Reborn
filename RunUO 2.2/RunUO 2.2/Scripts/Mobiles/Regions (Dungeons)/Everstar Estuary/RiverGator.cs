using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a river gator corpse" )]
	public class RiverGator : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.2; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public RiverGator() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
			Name = "a river gator";
			Body = 0xCA;
			BaseSoundID = 660;
                        Hue = 853;

			SetStr( 212, 271 );
			SetDex( 146, 200 );
			SetInt( 144, 185 );

			SetHits( 205, 325 );

			SetDamage( 12, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );

			SetSkill( SkillName.MagicResist, 65.1, 75.0 );
			SetSkill( SkillName.Tactics, 50.1, 60.0 );
			SetSkill( SkillName.Wrestling, 60.1, 80.0 );

			Fame = 5500;
			Karma = -5500;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 55.0;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 22, 47 )), from);
                        corpse.AddCarvedItem(new RawRibs(1), from);
                        corpse.AddCarvedItem(new SpinedHides(15), from);
                        corpse.AddCarvedItem(new SerpentScale( Utility.RandomMinMax( 15, 23 )), from);

                        from.SendMessage( "Upon finding gold, you also carve up some raw ribs, spined hides, and serpent scales." );
                        corpse.Carved = true;
			}
                }

		public RiverGator(Serial serial) : base(serial)
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

			if ( BaseSoundID == 0x5A )
				BaseSoundID = 660;
		}
	}
}