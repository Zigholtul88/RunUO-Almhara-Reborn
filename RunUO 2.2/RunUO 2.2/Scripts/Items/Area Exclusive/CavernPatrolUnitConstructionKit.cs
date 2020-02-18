using System;
using Server;
using Server.Mobiles;
using Server.Spells;

namespace Server.Items
{
	public class CavernPatrolUnitConstructionKit : Item
	{
		public override string DefaultName
		{
			get { return "cavern patrol unit construction kit"; }
		}

		[Constructable]
		public CavernPatrolUnitConstructionKit() : base( 0x1EA8 )
		{
			Weight = 4.0;
			Hue = 2401;
		}

		public CavernPatrolUnitConstructionKit( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
				return;
			}

			double tinkerSkill = from.Skills[SkillName.Tinkering].Value;

			if ( tinkerSkill < 30.0 )
			{
				from.SendMessage( "You must have at least 30.0 skill in tinkering to construct a patrol unit." );
				return;
			}
			else if ( (from.Followers + 10) > from.FollowersMax )
			{
				from.SendLocalizedMessage( 1049607 ); // You have too many followers to control that creature.
				return;
			}

			double scalar;

			if ( tinkerSkill >= 50.0 )
				scalar = 1.0;
			else if ( tinkerSkill >= 45.0 )
				scalar = 0.9;
			else if ( tinkerSkill >= 40.0 )
				scalar = 0.8;
			else if ( tinkerSkill >= 35.0 )
				scalar = 0.7;
			else
				scalar = 0.6;

			Container pack = from.Backpack;

			if ( pack == null )
				return;

			int res = pack.ConsumeTotal(
				new Type[]
				{
					typeof( PowerCrystal ),
					typeof( IronIngot ),
					typeof( BlackGear ),
					typeof( BronzeGear ),
					typeof( CrimsonGear )
				},
				new int[]
				{
					1,
					25,
					15,
					10,
					5
				} );

			switch ( res )
			{
				case 0:
				{
					from.SendMessage( "You must have a power crystal to construct the patrol unit." );
					break;
				}
				case 1:
				{
					from.SendMessage( "You must have 25 iron ingots to construct the patrol unit." );
					break;
				}
				case 2:
				{
					from.SendMessage( "You must have 15 black gears to construct the patrol unit." );
					break;
				}
				case 3:
				{
					from.SendMessage( "You must have 10 bronze gears to construct the patrol unit." );
					break;
				}
				case 4:
				{
					from.SendMessage( "You must have 5 crimson gears to construct the patrol unit." );
					break;
				}
				default:
				{
					StoneBurrowPatrolUnit u = new StoneBurrowPatrolUnit( true, scalar );

					if ( u.SetControlMaster( from ) )
					{
						Delete();

						u.MoveToWorld( from.Location, from.Map );
						from.PlaySound( 0x241 );
					}

					break;
				}
			}
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