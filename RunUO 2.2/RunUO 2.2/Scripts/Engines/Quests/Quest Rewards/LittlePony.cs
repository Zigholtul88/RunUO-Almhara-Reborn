using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of a my little pony" )]
	[TypeAlias( "Server.Mobiles.BrownHorse", "Server.Mobiles.DirtyHorse", "Server.Mobiles.GrayHorse", "Server.Mobiles.TanHorse" )]
	public class LittlePony : BaseMount
	{
		private static int[] m_IDs = new int[]
			{
				0xC8, 0x3E9F,
				0xE2, 0x3EA0,
				0xE4, 0x3EA1,
				0xCC, 0x3EA2
			};

		[Constructable]
		public LittlePony() : this( "my little pony" )
		{
		}

		[Constructable]
		public LittlePony( string name ) : base( name, 0xE2, 0x3EA0, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			int random = Utility.Random( 4 );

			Body = m_IDs[random * 2];
			ItemID = m_IDs[random * 2 + 1];

			SetStr( 33 );
			SetDex( 57 );
			SetInt( 10 );

			SetHits( 50 );
			SetMana( 0 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 23.4, 29.6 );
			SetSkill( SkillName.Tactics, 31.0, 41.7 );
			SetSkill( SkillName.Wrestling, 33.7, 44.9 );

			Fame = 100;
			Karma = -1000;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = -50.0;
		}

		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 8; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override int GetIdleSound() { return 823; } // female yea!
		public override int GetAngerSound() { return 797; } // female hey
		public override int GetAttackSound() { return 0x186; }
		public override int GetHurtSound() { return 0x1BE; } 
		public override int GetDeathSound() { return 0x8E; } 

		public override void OnDoubleClick( Mobile from )
		{
                        if ( from.Female == false && from.BodyValue == 666 )
			{
				from.SendMessage( "As a gargoyle you cannot mount this creature." );
                                from.PlaySound( 802 ); // female no
				return;
			}

                        if ( from.Female == true && from.BodyValue == 667 )
			{
				from.SendMessage( "As a gargoyle you cannot mount this creature." );
                                from.PlaySound( 802 ); // female no
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
                                        from.PlaySound( 802 ); // female no

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
                                        from.PlaySound( 802 ); // female no
				}
			}
			else
			{
				from.SendLocalizedMessage( 500206 ); // That is too far away to ride.
			}

                        from.PlaySound( 783 ); // female woohoo!
			from.Say( "*{0} yells* WOOHOO! Let's Roll Out!", this.Name );
                        from.SpeechHue = Utility.RandomList( 3,28,38,48,53,58,63,88,93 );
		}

		public LittlePony( Serial serial ) : base( serial )
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