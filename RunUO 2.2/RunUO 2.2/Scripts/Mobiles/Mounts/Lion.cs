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
	[CorpseName( "a lion corpse" )]
	public class Lion : BaseMount
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Lion() : this( "a lion" )
		{
		}

		[Constructable]
		public Lion( string name ) : base( name, 277, 0x3E91, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			SetStr( 294, 370 );
			SetDex( 156, 175 );
			SetInt( 26, 50 );

			SetHits( 842, 976 );
			SetMana( 0 );

			SetDamage( 15, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );

			SetSkill( SkillName.MagicResist, 27.1, 32.0 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 4500;
			Karma = -4500;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 76.6;
		}

		public override int Meat{ get{ return 3; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public override int GetIdleSound() { return 0x3EE; } 
		public override int GetAngerSound() { return 0x3EF; } 
		public override int GetAttackSound() { return 0x3F0; } 
		public override int GetHurtSound() { return 0x3F1; } 
		public override int GetDeathSound() { return 0x3F2; }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.HarashiNabiPredator; }
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new LionPelt(), from );
                              corpse.AddCarvedItem(new LionTooth( amount ), from );

                              from.SendMessage( "You carve up some lion parts." );
                              corpse.Carved = true; 
			}
                }

		public Lion( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}