using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a reptalon corpse" )]
	public class Reptalon : BaseMount
	{
		[Constructable]
		public Reptalon() : base( "a reptalon", 0x114, 0x3E90, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.35 )
		{
			BaseSoundID = 0x16A; // TODO check

			SetStr( 1001, 1025 );
			SetDex( 152, 164 );
			SetInt( 251, 289 );

			SetHits( 833, 931 );

			SetDamage( 21, 28 );
			
			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Poison, 25 );
			SetDamageType( ResistanceType.Energy, 75 );

			SetResistance( ResistanceType.Physical, 53, 64 );
			SetResistance( ResistanceType.Fire, 35, 45 );
			SetResistance( ResistanceType.Cold, 36, 45 );
			SetResistance( ResistanceType.Poison, 52, 63 );
			SetResistance( ResistanceType.Energy, 71, 83 );

			SetSkill( SkillName.Wrestling, 101.5, 118.2 );
			SetSkill( SkillName.Tactics, 101.7, 108.2 );
			SetSkill( SkillName.MagicResist, 76.4, 89.9 );
			SetSkill( SkillName.Anatomy, 56.4, 59.7 );
			
			Fame = 60000;
			Karma = -60000;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 101.1;

                        if (Utility.RandomDouble() < 0.4 )
                                PackItem(new TreasureMap(3, Map.Malas ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.AosUltraRich, 3 );
		}

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ParalyzingBlow;
		}

		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override bool CanBreath{ get{ return true; } }
		public override bool CanAngerOnTame{ get { return true; } }
		public override bool StatLossAfterTame{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.Skills[SkillName.AnimalTaming].Base < 101.1 )
			{
				from.SendMessage( "101.1 Animal Taming is needed to mount this creature." );
				return;
			}

                        if ( from.Female == false && from.BodyValue == 666 )
			{
				from.SendMessage( "As a gargoyle you cannot mount this creature." );
				return;
			}

                        if ( from.Female == true && from.BodyValue == 667 )
			{
				from.SendMessage( "As a gargoyle you cannot mount this creature." );
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

		public Reptalon( Serial serial ) : base( serial )
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
