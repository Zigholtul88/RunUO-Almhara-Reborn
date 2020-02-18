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
	[CorpseName( "a deamhan goat corpse" )]
	public class DeamhanGoat : BaseCreature
	{
		[Constructable]
		public DeamhanGoat() : base( AIType.AI_Animal, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a deamhan goat";
			Body = 0xD1;
			Hue = Utility.RandomList( 0x647, 0x650, 0x659, 0x662, 0x66B, 0x674);
			BaseSoundID = 0x99;

			SetStr( 431, 547 );
			SetDex( 236, 260 );
			SetInt( 228, 320 );

			SetHits( 320, 427 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.MagicResist, 15.3, 30.0 );
			SetSkill( SkillName.Tactics, 88.1, 97.0 );
			SetSkill( SkillName.Wrestling, 90.1, 95.0 );

			Fame = 4500;
			Karma = -4500;

                        PackGold( 100, 500 );
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 8; } }
		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay | FoodType.FruitsAndVegies; } }

                public override bool HasBreath{ get{ return true; } } // fireball enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 100; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x36D4; } }
		public override int BreathEffectSound{ get{ return 0x15E; } }
		public override int BreathAngerSound{ get{ return 0x99; } }

		public DeamhanGoat(Serial serial) : base(serial)
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