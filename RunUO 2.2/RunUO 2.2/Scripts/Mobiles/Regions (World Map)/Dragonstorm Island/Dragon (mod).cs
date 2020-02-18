using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Third;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a dragon corpse" )]
	public class Dragon : BaseSpecialCreature
	{
                public override bool DoesMultiFirebreathing { get { return true; } }
                public override double MultiFirebreathingChance { get { return 0.6; } } //60%
                public override int BreathDamagePercent { get { return 15; } }
                public override int BreathMaxTargets { get { return 5; } }
                public override int BreathMaxRange { get { return 10; } }

		[Constructable]
		public Dragon () : base( AIType.AI_Mage, FightMode.Closest, 16, 1, 0.175, 0.350 )
		{
			CurrentSpeed = BoostedSpeed;
			RangePerception = 200;

			Name = "a dragon";
			Body = Utility.RandomList( 12, 59 );
			BaseSoundID = 362;

			SetStr( 792, 825 );
			SetDex( 88, 110 );
			SetInt( 437, 475 );

			SetHits( 956, 990 );
			SetMana( 2185, 2375 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.EvalInt, 58.0, 80.4 );
			SetSkill( SkillName.Magery, 87.5, 99.4 );
			SetSkill( SkillName.MagicResist, 99.2, 100.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 91.0, 93.2 );

			Fame = 15000;
			Karma = -15000;

			Tamable = true;
			ControlSlots = 6;
			MinTameSkill = 93.9;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.MedScrolls, 1 );
			AddLoot( LootPack.LowScrolls, 5 );
			AddLoot( LootPack.Gems, 3 );
	        }

		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(19), from);
                              corpse.AddCarvedItem(new BarbedHides(20), from);
                              corpse.AddCarvedItem(new RedScales(12), from);
                              corpse.AddCarvedItem(new DragonScale( Utility.RandomMinMax( 35, 50 )), from);
                              corpse.AddCarvedItem(new DragonHeart(), from);

                              from.SendMessage( "You carve up raw ribs, barbed hides, red scales, specialized dragon scales, and a dragon heart." ); 
                              corpse.Carved = true;
			}
                }

		public Dragon( Serial serial ) : base( serial )
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