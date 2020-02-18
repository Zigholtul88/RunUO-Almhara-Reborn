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

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.Skills[SkillName.AnimalTaming].Base < 76.6 )
			{
				from.SendMessage( "76.6 Animal Taming is needed to mount this creature." );
				return;
			}

			if ( IsDeadPet )
				return;

			if ( from.IsBodyMod && !from.Body.IsHuman )
			{
				if ( Core.AOS ) // You cannot ride a mount in your current form.
					PrivateOverheadMessage( Network.MessageType.Regular, 0x3B2, 1062061, from.NetState );
				else
					from.SendLocalizedMessage( 1061628 ); // You can't do that while polymorphed.

				return;
			}

			if ( !CheckMountAllowed( from, true ) )
				return;

			if ( from.Mounted )
			{
				from.SendLocalizedMessage( 1005583 ); // Please dismount first.
				return;
			}

			if ( from.Female ? !AllowFemaleRider : !AllowMaleRider )
			{
				OnDisallowedRider( from );
				return;
			}

			if ( !Multis.DesignContext.Check( from ) )
				return;

			if ( from.HasTrade )
			{
				from.SendLocalizedMessage( 1042317, "", 0x41 ); // You may not ride at this time
				return;
			}

			if ( from.InRange( this, 1 ) )
			{
				bool canAccess = ( from.AccessLevel >= AccessLevel.GameMaster )
					|| ( Controlled && ControlMaster == from )
					|| ( Summoned && SummonMaster == from );

				if ( canAccess )
				{
					if ( this.Poisoned )
						PrivateOverheadMessage( Network.MessageType.Regular, 0x3B2, 1049692, from.NetState ); // This mount is too ill to ride.
					else
						Rider = from;
				}
				else if ( !Controlled && !Summoned )
				{
					// That mount does not look broken! You would have to tame it to ride it.
					PrivateOverheadMessage( Network.MessageType.Regular, 0x3B2, 501263, from.NetState );
				}
				else
				{
					// This isn't your mount; it refuses to let you ride.
					PrivateOverheadMessage( Network.MessageType.Regular, 0x3B2, 501264, from.NetState );
				}
			}
			else
			{
				from.SendLocalizedMessage( 500206 ); // That is too far away to ride.
			}
		}

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