using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Paprika" )]
	public class Paprika : BaseGuardian
	{
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public Paprika() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
                        // based off of crane mob stats
			Name = "Paprika";
			Body = 254;
			BaseSoundID = 0x4D7;

			SetStr( 26, 35 );
			SetDex( 16, 25 );
			SetInt( 11, 15 );

			SetHits( 26, 35 );
			SetMana( 0 );

			SetDamage( 1, 1 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5, 5 );

			SetSkill( SkillName.MagicResist, 4.1, 5.0 );
			SetSkill( SkillName.Tactics, 10.1, 11.0 );
			SetSkill( SkillName.Wrestling, 10.1, 11.0 );

			Fame = 0;
			Karma = 10000;
		}

		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override int GetAttackSound() { return 0x4D7; } 
		public override int GetIdleSound() { return 0x4D8; } 
		public override int GetAngerSound() { return 0x4D9; } 
		public override int GetHurtSound() { return 0x4DA; } 
		public override int GetDeathSound() { return 0x4D6; }

		public Paprika( Serial serial ) : base( serial )
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