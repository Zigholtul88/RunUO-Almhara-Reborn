using System;
using Server;
using Server.Items;
using EDI = Server.Mobiles.EscortDestinationInfo;

namespace Server.Mobiles
{
	public class ElandrimEscort : BaseEscortable
	{
		private static string[] m_TownNames = new string[]
		{
			"Hammerhill", "Old Punderer's Haven", "Skaddria Naddheim"
		};

		private static string[] m_MLDestinations = new string[]
		{
			"Hammerhill", "Old Punderer's Haven", "Skaddria Naddheim"
		};

		public override string[] GetPossibleDestinations()
		{
			if ( Core.ML )
				return m_MLDestinations;
			else
				return m_TownNames;
		}

		[Constructable]
		public ElandrimEscort()
		{
			Title = "the escort";
		}

		public override bool ClickTitle{ get{ return false; } } // Do not display 'the seeker of adventure' when single-clicking

		public override void InitOutfit()
		{
			SetStr( 154 );
			SetDex( 148 );
			SetInt( 125 );

			PackGold( 200, 600 );

			Body = 606;
			Name = NameList.RandomName( "elven female" );
			Hue = Utility.RandomList( 897,898,899,2405 );
                        HairHue = 1153;
                        HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );

			switch ( Utility.Random( 18 ) )
			{
				case 0: AddItem( new CitizenDress( Utility.RandomBlueHue() ) ); break;
				case 1: AddItem( new CommonerDress( Utility.RandomGreenHue() ) ); break;
				case 2: AddItem( new ConfessorDress( Utility.RandomRedHue() ) ); break;
				case 3: AddItem( new ElegantGown( Utility.RandomYellowHue() ) ); break;
				case 4: AddItem( new FancyDress( Utility.RandomBlueHue() ) ); break;
				case 5: AddItem( new FlowerDress( Utility.RandomGreenHue() ) ); break;
				case 6: AddItem( new FormalDress( Utility.RandomRedHue() ) ); break;
				case 7: AddItem( new GildedDress( Utility.RandomYellowHue() ) ); break;
				case 8: AddItem( new MaidensDress( Utility.RandomBlueHue() ) ); break;
				case 9: AddItem( new MedievalLongDress( Utility.RandomGreenHue() ) ); break;
				case 10: AddItem( new NobleDress( Utility.RandomRedHue() ) ); break;
				case 11: AddItem( new NocturnalDress( Utility.RandomYellowHue() ) ); break;
				case 12: AddItem( new PartyDress( Utility.RandomBlueHue() ) ); break;
				case 13: AddItem( new PlainDress( Utility.RandomGreenHue() ) ); break;
				case 14: AddItem( new ReinassanceDress( Utility.RandomRedHue() ) ); break;
				case 15: AddItem( new TheaterDress( Utility.RandomYellowHue() ) ); break;
				case 16: AddItem( new VictorianDress( Utility.RandomNeutralHue() ) ); break;
				case 17: AddItem( new MoonElfPlainDress( Utility.RandomNeutralHue() ) ); break;
			}

			if ( 0.05 > Utility.RandomDouble() )
                        {
			        SilverBracelet bracelet = new SilverBracelet();
                                bracelet.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			        bracelet.Movable = true;
			        AddItem( bracelet );
                        }

			if ( 0.05 > Utility.RandomDouble() )
                        {
			        SilverNecklace necklace = new SilverNecklace();
                                necklace.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			        necklace.Movable = true;
			        AddItem( necklace );
                        }

			if ( 0.05 > Utility.RandomDouble() )
                        {
			        SilverEarrings earrings = new SilverEarrings();
                                earrings.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			        earrings.Movable = true;
			        AddItem( earrings );
			}
                }

		public ElandrimEscort( Serial serial ) : base( serial )
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