using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	public class SummonedInvestmentBanker : BaseVendor
	{
		public Timer	m_Timer;

		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.MerchantsGuild; } }

		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public SummonedInvestmentBanker() : base( "the investment banker" )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBBanker() );
		}

		public override void InitOutfit()
		{
			CantWalk = true;

			SetStr( 999 );
			SetDex( 999 );
			SetInt( 999 );

			SetSkill( SkillName.Anatomy, 60.0, 183.0 );
			SetSkill( SkillName.Cooking, 75.0, 98.0 );
			SetSkill( SkillName.TasteID, 36.0, 68.0 );

			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 0x191; 
				this.Name = NameList.RandomName( "female" );
			        this.Hue = Utility.RandomSkinHue(); 

                                this.HairHue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
                                this.HairItemID = Utility.RandomList( 8251,8252,8253,8260,8261,8262,8263,8264,8265 );

			        switch ( Utility.Random( 17 ) )
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
			        }

			        switch ( Utility.Random( 8 ) )
			        {
				       case 0: AddItem( new Boots( Utility.RandomNeutralHue() ) ); break;
				       case 1: AddItem( new FurBoots( Utility.RandomNeutralHue() ) ); break;
				       case 2: AddItem( new LightBoots( Utility.RandomNeutralHue() ) ); break;
				       case 3: AddItem( new Sandals( Utility.RandomNeutralHue() ) ); break;
				       case 4: AddItem( new ShortBoots( Utility.RandomNeutralHue() ) ); break;
				       case 5: AddItem( new ThighBoots( Utility.RandomNeutralHue() ) ); break;
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
			else 
			{ 
				this.Body = 0x190; 
				this.Name = NameList.RandomName( "male" );
			        this.Hue = Utility.RandomSkinHue();

                                this.HairHue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
                                this.HairItemID = Utility.RandomList( 8251,8252,8253,8260,8261,8262,8263,8264,8265 );
                                this.FacialHairHue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
                                this.FacialHairItemID = Utility.RandomList( 8254,8255,8256,8257,8267,8268,8269 );

			        switch ( Utility.Random( 8 ) )
			        {
				       case 0: AddItem( new FancyShirt( Utility.RandomBlueHue() ) ); break;
				       case 1: AddItem( new FancyTunic( Utility.RandomGreenHue() ) ); break;
				       case 2: AddItem( new FormalShirt( Utility.RandomRedHue() ) ); break;
				       case 3: AddItem( new LeatherShirt( Utility.RandomYellowHue() ) ); break;
				       case 4: AddItem( new ReinassanceShirt( Utility.RandomBlueHue() ) ); break;
				       case 5: AddItem( new Shirt( Utility.RandomGreenHue() ) ); break;
				       case 6: AddItem( new Surcoat( Utility.RandomRedHue() ) ); break;
				       case 7: AddItem( new Tunic( Utility.RandomNeutralHue() ) ); break;
                                }

			        switch ( Utility.Random( 9 ) )
			        {
				       case 0: AddItem( new FancyPants( Utility.RandomNeutralHue() ) ); break;
				       case 1: AddItem( new FurSarong( Utility.RandomNeutralHue() ) ); break;
				       case 2: AddItem( new Hakama( Utility.RandomNeutralHue() ) ); break;
				       case 3: AddItem( new Kilt( Utility.RandomNeutralHue() ) ); break;
				       case 4: AddItem( new LeatherPants( Utility.RandomNeutralHue() ) ); break;
				       case 5: AddItem( new LongPants( Utility.RandomNeutralHue() ) ); break;
				       case 6: AddItem( new ReinassancePants( Utility.RandomNeutralHue() ) ); break;
				       case 7: AddItem( new ShortPants( Utility.RandomNeutralHue() ) ); break;
				       case 8: AddItem( new TattsukeHakama( Utility.RandomNeutralHue() ) ); break;
                                }

			        switch ( Utility.Random( 6 ) )
			        {
				       case 0: AddItem( new Boots( Utility.RandomNeutralHue() ) ); break;
				       case 1: AddItem( new HeavyBoots( Utility.RandomNeutralHue() ) ); break;
				       case 2: AddItem( new HighBoots( Utility.RandomNeutralHue() ) ); break;
				       case 3: AddItem( new Shoes( Utility.RandomNeutralHue() ) ); break;
				       case 4: AddItem( new ShortBoots( Utility.RandomNeutralHue() ) ); break;
				       case 5: AddItem( new ThighBoots( Utility.RandomNeutralHue() ) ); break;
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
			              SilverEarrings earrings = new SilverEarrings();
                                      earrings.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              earrings.Movable = true;
			              AddItem( earrings );
                                }
			} 

			if ( 0.05 > Utility.RandomDouble() )
				AddItem( new BodySash( Utility.RandomDyedHue() ) );

			if ( 0.05 > Utility.RandomDouble() )
                        {
			        switch ( Utility.Random( 6 ) )
			        {
				      case 0: AddItem( new Bandana( Utility.RandomDyedHue() ) ); break;
				      case 1: AddItem( new Bonnet( Utility.RandomDyedHue() ) ); break;
				      case 2: AddItem( new Cap( Utility.RandomDyedHue() ) ); break;
				      case 3: AddItem( new FeatheredHat( Utility.RandomDyedHue() ) ); break;
				      case 4: AddItem( new SkullCap( Utility.RandomDyedHue() ) ); break;
				      case 5: AddItem( new WideBrimHat( Utility.RandomDyedHue() ) ); break;
			        }
                        }

			m_Timer = new AutokillTimer(this);
			m_Timer.Start();
                }

		public static int GetBalance( Mobile from )
		{
			Item[] gold, checks;

			return GetBalance( from, out gold, out checks );
		}

		public static int GetBalance( Mobile from, out Item[] gold, out Item[] checks )
		{
			int balance = 0;

			Container bank = from.FindBankNoCreate();

			if ( bank != null )
			{
				gold = bank.FindItemsByType( typeof( Gold ) );
				checks = bank.FindItemsByType( typeof( BankCheck ) );

				for ( int i = 0; i < gold.Length; ++i )
					balance += gold[i].Amount;

				for ( int i = 0; i < checks.Length; ++i )
					balance += ((BankCheck)checks[i]).Worth;
			}
			else
			{
				gold = checks = new Item[0];
			}

			return balance;
		}

		public static bool Withdraw( Mobile from, int amount )
		{
			Item[] gold, checks;
			int balance = GetBalance( from, out gold, out checks );

			if ( balance < amount )
				return false;

			for ( int i = 0; amount > 0 && i < gold.Length; ++i )
			{
				if ( gold[i].Amount <= amount )
				{
					amount -= gold[i].Amount;
					gold[i].Delete();
				}
				else
				{
					gold[i].Amount -= amount;
					amount = 0;
				}
			}

			for ( int i = 0; amount > 0 && i < checks.Length; ++i )
			{
				BankCheck check = (BankCheck)checks[i];

				if ( check.Worth <= amount )
				{
					amount -= check.Worth;
					check.Delete();
				}
				else
				{
					check.Worth -= amount;
					amount = 0;
				}
			}

			return true;
		}

		public static bool Deposit( Mobile from, int amount )
		{
			BankBox box = from.FindBankNoCreate();
			if ( box == null )
				return false;

			List<Item> items = new List<Item>();

			while ( amount > 0 )
			{
				Item item;
				if ( amount < 5000 )
				{
					item = new Gold( amount );
					amount = 0;
				}
				else if ( amount <= 1000000 )
				{
					item = new BankCheck( amount );
					amount = 0;
				}
				else
				{
					item = new BankCheck( 1000000 );
					amount -= 1000000;
				}

				if ( box.TryDropItem( from, item, false ) )
				{
					items.Add( item );
				}
				else
				{
					item.Delete();
					foreach ( Item curItem in items )
					{
						curItem.Delete();
					}

					return false;
				}
			}

			return true;
		}

		public static int DepositUpTo( Mobile from, int amount )
		{
			BankBox box = from.FindBankNoCreate();
			if ( box == null )
				return 0;

			int amountLeft = amount;
			while ( amountLeft > 0 )
			{
				Item item;
				int amountGiven;

				if ( amountLeft < 5000 )
				{
					item = new Gold( amountLeft );
					amountGiven = amountLeft;
				}
				else if ( amountLeft <= 1000000 )
				{
					item = new BankCheck( amountLeft );
					amountGiven = amountLeft;
				}
				else
				{
					item = new BankCheck( 1000000 );
					amountGiven = 1000000;
				}

				if ( box.TryDropItem( from, item, false ) )
				{
					amountLeft -= amountGiven;
				}
				else
				{
					item.Delete();
					break;
				}
			}

			return amount - amountLeft;
		}

		public static void Deposit( Container cont, int amount )
		{
			while ( amount > 0 )
			{
				Item item;

				if ( amount < 5000 )
				{
					item = new Gold( amount );
					amount = 0;
				}
				else if ( amount <= 1000000 )
				{
					item = new BankCheck( amount );
					amount = 0;
				}
				else
				{
					item = new BankCheck( 1000000 );
					amount -= 1000000;
				}

				cont.DropItem( item );
			}
		}

		public SummonedInvestmentBanker( Serial serial ) : base( serial )
		{
			m_Timer = new AutokillTimer(this);
			m_Timer.Start();
		}

		public override bool HandlesOnSpeech( Mobile from )
		{
			if ( from.InRange( this.Location, 12 ) )
				return true;

			return base.HandlesOnSpeech( from );
		}

		public override void OnSpeech( SpeechEventArgs e )
		{
			if ( !e.Handled && e.Mobile.InRange( this.Location, 12 ) )
			{
				for ( int i = 0; i < e.Keywords.Length; ++i )
				{
					int keyword = e.Keywords[i];

					switch ( keyword )
					{
						case 0x0000: // *withdraw*
						{
							e.Handled = true;

							if ( e.Mobile.Criminal )
							{
								this.Say( 500389 ); // I will not do business with a criminal!
								break;
							}

							string[] split = e.Speech.Split( ' ' );

							if ( split.Length >= 2 )
							{
								int amount;

								Container pack = e.Mobile.Backpack;

								if ( !int.TryParse( split[1], out amount ) )
									break;

								if ( (!Core.ML && amount > 5000) || (Core.ML && amount > 60000) )
								{
									this.Say( 500381 ); // Thou canst not withdraw so much at one time!
								}
								else if (pack == null || pack.Deleted || !(pack.TotalWeight < pack.MaxWeight) || !(pack.TotalItems < pack.MaxItems))
								{
									this.Say(1048147); // Your backpack can't hold anything else.
								}
								else if (amount > 0)
								{
									BankBox box = e.Mobile.FindBankNoCreate();

									if (box == null || !box.ConsumeTotal(typeof(Gold), amount))
									{
										this.Say(500384); // Ah, art thou trying to fool me? Thou hast not so much gold!
									}
									else
									{
										pack.DropItem(new Gold(amount));

										this.Say(1010005); // Thou hast withdrawn gold from thy account.
									}
								}
							}

							break;
						}
						case 0x0001: // *balance*
						{
							e.Handled = true;

							if ( e.Mobile.Criminal )
							{
								this.Say( 500389 ); // I will not do business with a criminal!
								break;
							}

							BankBox box = e.Mobile.FindBankNoCreate();

							if ( box != null )
								this.Say( 1042759, box.TotalGold.ToString() ); // Thy current bank balance is ~1_AMOUNT~ gold.
							else
								this.Say( 1042759, "0" ); // Thy current bank balance is ~1_AMOUNT~ gold.

							break;
						}
						case 0x0002: // *bank*
						{
							e.Handled = true;

							if ( e.Mobile.Criminal )
							{
								this.Say( 500378 ); // Thou art a criminal and cannot access thy bank box.
								break;
							}

							e.Mobile.BankBox.Open();

							break;
						}
						case 0x0003: // *check*
						{
							e.Handled = true;

							if ( e.Mobile.Criminal )
							{
								this.Say( 500389 ); // I will not do business with a criminal!
								break;
							}

							string[] split = e.Speech.Split( ' ' );

							if ( split.Length >= 2 )
							{
								int amount;

                                if ( !int.TryParse( split[1], out amount ) )
                                    break;

								if ( amount < 5000 )
								{
									this.Say( 1010006 ); // We cannot create checks for such a paltry amount of gold!
								}
								else if ( amount > 1000000 )
								{
									this.Say( 1010007 ); // Our policies prevent us from creating checks worth that much!
								}
								else
								{
									BankCheck check = new BankCheck( amount );

									BankBox box = e.Mobile.BankBox;

									if ( !box.TryDropItem( e.Mobile, check, false ) )
									{
										this.Say( 500386 ); // There's not enough room in your bankbox for the check!
										check.Delete();
									}
									else if ( !box.ConsumeTotal( typeof( Gold ), amount ) )
									{
										this.Say( 500384 ); // Ah, art thou trying to fool me? Thou hast not so much gold!
										check.Delete();
									}
									else
									{
										this.Say( 1042673, AffixType.Append, amount.ToString(), "" ); // Into your bank box I have placed a check in the amount of:
									}
								}
							}

							break;
						}
					}
				}
			}

			base.OnSpeech( e );
		}

		public override void AddCustomContextEntries( Mobile from, List<ContextMenuEntry> list )
		{
			if ( from.Alive )
				list.Add( new OpenBankEntry( from, this ) );

			base.AddCustomContextEntries( from, list );
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

		private class AutokillTimer : Timer
		{
			private SummonedInvestmentBanker m_Owner;

			public AutokillTimer( SummonedInvestmentBanker owner ) : base( TimeSpan.FromMinutes(5.0) )
			{
				m_Owner = owner;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Owner.Delete();
				Stop();
			}
		}
	}
}
