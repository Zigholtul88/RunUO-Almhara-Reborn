using System;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Network;
using Server.Targeting;
using EDI = Server.Mobiles.EscortDestinationInfo;

namespace Server.Mobiles
{
	public class BleakWindTunnelsLostTraveler : BaseEscortable
	{
		private static string[] m_TownNames = new string[]
		{
			"Elandrim Nur Shaz"
		};

		private static string[] m_MLDestinations = new string[]
		{
			"Elandrim Nur Shaz"
		};

		public override string[] GetPossibleDestinations()
		{
			if ( Core.ML )
				return m_MLDestinations;
			else
				return m_TownNames;
		}

		[Constructable]
		public BleakWindTunnelsLostTraveler()
		{
			if ( this.Female = Utility.RandomBool() )
			{
			     Title = "the lost traveler";
			     Body = 606;
			     Name = NameList.RandomName( "elven female" );
			     Hue = Utility.RandomList( 897,898,899,2405 );
                             HairHue = 1153;
                             HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );

			     AddItem( new FormalDress( Utility.RandomBlueHue() ) );
			     AddItem( new Sandals( Utility.RandomBlueHue() ) );
			     PackGold( 7, 15 );
			}
			else
			{
			     Title = "the lost traveler";
			     Body = 605;
			     Name = NameList.RandomName( "elven male" );
			     Hue = Utility.RandomList( 897,898,899,2405 );
                             HairHue = 1153;
                             HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );

			     AddItem( new MoonElfShirt( Utility.RandomBlueHue() ) );
			     AddItem( new MoonElfSkirt( Utility.RandomBlueHue() ) );
			     AddItem( new ElvenBoots( Utility.RandomBlueHue() ) );
			     PackGold( 7, 15 );
		        }
                }

		public override bool ClickTitle{ get{ return false; } } // Do not display 'the seeker of adventure' when single-clicking

		public BleakWindTunnelsLostTraveler( Serial serial ) : base( serial )
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