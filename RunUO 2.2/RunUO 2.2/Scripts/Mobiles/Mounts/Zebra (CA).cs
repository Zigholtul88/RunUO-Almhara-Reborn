using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a zebra corpse" )]
	public class Zebra : BaseMount
	{
		[Constructable]
		public Zebra() : this( "a zebra" )
		{
		}

		[Constructable]
		public Zebra( string name ) : base( name, 0x34D, 0x3EB2, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			BaseSoundID = 0xA8;

			SetStr( 144, 282 );
			SetDex( 169, 187 );
			SetInt( 117, 146 );

			SetHits( 367, 402 );
			SetMana( 0 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 18 );
			SetResistance( ResistanceType.Fire, 10 );

			SetSkill( SkillName.Anatomy, 15.0 );
			SetSkill( SkillName.MagicResist, 29.5, 34.7 );
			SetSkill( SkillName.Tactics, 39.3, 43.6 );
			SetSkill( SkillName.Wrestling, 43.5, 57.3 );

			Fame = 500;
			Karma = -500;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 33.3;
		}

		public override int Meat{ get{ return 6; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override int GetAttackSound() { return 0x82; }
		public override int GetHurtSound() { return 0x83; } 
		public override int GetDeathSound() { return 0x84; } 

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.HarashiNabiPredator; }
		}

		public override void OnGaveMeleeAttack( Mobile defender ) 
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.1 > Utility.RandomDouble() )
			{
				/* Maniacal laugh
				 * Cliloc: 1070840
				 * Effect: Type: "3" From: "0x57D4F5B" To: "0x0" ItemId: "0x37B9" ItemIdName: "glow" FromLocation: "(884 715, 10)" ToLocation: "(884 715, 10)" Speed: "10" Duration: "5" FixedDirection: "True" Explode: "False"
				 * Paralyzes for 4 seconds, or until hit
				 */

				defender.FixedEffect( 0x37B9, 10, 5 );
				defender.SendLocalizedMessage( 1070840 ); // You are frozen as the creature laughs maniacally.

				defender.Paralyze( TimeSpan.FromSeconds( 4.0 ) );
 			}
		}

		public Zebra(Serial serial) : base(serial)
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