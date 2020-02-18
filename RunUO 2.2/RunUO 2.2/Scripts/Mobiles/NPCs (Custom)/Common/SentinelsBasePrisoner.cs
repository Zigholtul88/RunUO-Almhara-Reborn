using System;
using Server;
using Server.Items;
using EDI = Server.Mobiles.EscortDestinationInfo;

namespace Server.Mobiles
{
	public class SentinelsBasePrisoner : BaseEscortable
	{
		private static string[] m_GreenAcres = new string[]
		{
			"Coven's Landing"
		};

		private static string[] m_MLDestinations = new string[]
		{
			"Cove", "Serpent's Hold", "Jhelom",		// ML List
			"Nujel'm"
		};

		public override string[] GetPossibleDestinations()
		{
			if ( Core.ML )
				return m_MLDestinations;
			else
				return m_GreenAcres;
		}

		[Constructable]
		public SentinelsBasePrisoner()
		{
			Title = "the prisoner";
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
				AddItem( new PlainDress( GetRandomHue() ) );
			else
				AddItem( new Shirt( GetRandomHue() ) );

			int lowHue = GetRandomHue();

			AddItem( new ShortPants( lowHue ) );

			if ( Female )
				AddItem( new Shoes( lowHue ) );
			else
				AddItem( new Boots( lowHue ) );

			Utility.AssignRandomHair( this );

			PackGold( 7, 15 );
		}

		public SentinelsBasePrisoner( Serial serial ) : base( serial )
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