using System;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a ki-rin corpse" )]
	public class Kirin : BaseMount
	{
		public override bool InitialInnocent{ get{ return true; } }

		public override TimeSpan MountAbilityDelay { get { return TimeSpan.FromHours( 1.0 ); } }

		public override void OnDisallowedRider( Mobile m )
		{
			m.SendLocalizedMessage( 1042319 ); // The Ki-Rin refuses your attempts to mount it.
		}

		public override bool DoMountAbility( int damage, Mobile attacker )
		{
			if( Rider == null || attacker == null )	//sanity
				return false;

			if( (Rider.Hits - damage) < 30 && Rider.Map == attacker.Map && Rider.InRange( attacker, 18 ) )	//Range and map checked here instead of other base fuction because of abiliites that don't need to check this
			{
				attacker.BoltEffect( 0 );
				// 35~100 damage, unresistable, by the Ki-rin.
				attacker.Damage( Utility.RandomMinMax( 35, 100 ), this, false );	//Don't inform mount about this damage, Still unsure wether or not it's flagged as the mount doing damage or the player.  If changed to player, without the extra bool it'd be an infinite loop

				Rider.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1042534 );	// Your mount calls down the forces of nature on your opponent.
				Rider.FixedParticles( 0, 0, 0, 0x13A7, EffectLayer.Waist );
				Rider.PlaySound( 0xA9 );	// Ki-rin's whinny.
				return true;
			}

			return false;
		}

		[Constructable]
		public Kirin() : this( "a ki-rin" )
		{
		}

		[Constructable]
		public Kirin( string name ) : base( name, 132, 0x3EAD, AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x3C5;

			SetStr( 296, 325 );
			SetDex( 86, 105 );
			SetInt( 186, 225 );

			SetMana( 186, 225 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Fire, 10 );
			SetDamageType( ResistanceType.Cold, 10 );
			SetDamageType( ResistanceType.Energy, 10 );

			SetResistance( ResistanceType.Physical, 55 );
			SetResistance( ResistanceType.Fire, 35 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.EvalInt, 80.1, 90.0 );
			SetSkill( SkillName.Magery, 60.4, 100.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 85.3, 100.0 );
			SetSkill( SkillName.Tactics, 20.1, 22.5 );
			SetSkill( SkillName.Wrestling, 80.5, 92.5 );

			Fame = 9000;
			Karma = 9000;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 95.1;
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Horned; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.Skills[SkillName.AnimalTaming].Base < 95.1 )
			{
				from.SendMessage( "95.1 Animal Taming is needed to mount this creature." );
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

		public Kirin( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version == 0 )
				AI = AIType.AI_Mage;
		}
	}
}