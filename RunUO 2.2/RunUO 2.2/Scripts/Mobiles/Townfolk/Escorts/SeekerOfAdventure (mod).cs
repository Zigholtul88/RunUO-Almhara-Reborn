using System;
using Server;
using Server.Items;
using EDI = Server.Mobiles.EscortDestinationInfo;

namespace Server.Mobiles
{
	public class SeekerOfAdventure : BaseEscortable
	{
		private static string[] m_DungeonRegion = new string[]
		{
			"Amul Seketsi Royal Tomb", "Bearstein Caverns", "Bharlim Passage",
			"Black Widow Pit", "Bleak Wind Tunnels", "Fungully Grotto",
			"Hammerhill Sewers", "Iguana Cove", "Mongbat Hideout",
                        "Nimaku Lava Basin", "Oboru Burial Grounds", "Stone Burrow Mines",
			"Swampwater Solitude", "Vygul's Vault", "Whispering Hollow"
		};

		private static string[] m_LandscapeRegion = new string[]
		{
			"Autumnwood", "Dragon Storm Island", "Glimmerwood",
			"Island of Giants", "Island of Tartarrix", "Oboru Jungle",
			"Ponyo Plateau", "Samson Swamplands", "Star Lake",
                        "Zaythalor Graveyard"
		};

		public override string[] GetPossibleDestinations()
		{
			if ( Core.ML )
				return m_DungeonRegion;
			else
				return m_LandscapeRegion;
		}

		[Constructable]
		public SeekerOfAdventure()
		{
			Title = "the seeker of adventure";
		}

		public override bool ClickTitle{ get{ return false; } } // Do not display 'the seeker of adventure' when single-clicking

		private static int GetRandomHue()
		{
			switch ( Utility.Random( 6 ) )
			{
				default:
				case 0: return 0;
				case 1: return Utility.RandomBlueHue();
				case 2: return Utility.RandomGreenHue();
				case 3: return Utility.RandomRedHue();
				case 4: return Utility.RandomYellowHue();
				case 5: return Utility.RandomNeutralHue();
			}
		}

		public override void InitOutfit()
		{
			if ( Female )
				AddItem( new FancyDress( GetRandomHue() ) );
			else
				AddItem( new FancyShirt( GetRandomHue() ) );

			int lowHue = GetRandomHue();

			AddItem( new ShortPants( lowHue ) );

			if ( Female )
				AddItem( new ThighBoots( lowHue ) );
			else
				AddItem( new Boots( lowHue ) );

			if ( !Female )
				AddItem( new BodySash( lowHue ) );

			AddItem( new Cloak( GetRandomHue() ) );

			AddItem( new Longsword() );

			Utility.AssignRandomHair( this );

			PackGold( 100, 150 );
		}

		public SeekerOfAdventure( Serial serial ) : base( serial )
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