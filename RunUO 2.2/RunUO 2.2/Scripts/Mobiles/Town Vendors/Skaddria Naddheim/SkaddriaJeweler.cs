using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles 
{ 
	public class SkaddriaJeweler : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SkaddriaJeweler() : base( "the jeweler" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBSkaddriaJeweler() ); 
		} 

		public override void InitOutfit()
		{
			SetStr( 72 );
			SetDex( 61 );
			SetInt( 38 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.ItemID, 64.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 23, 35 );

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
                }

                public override void OnSpeech( SpeechEventArgs e )
                {
                    	if ( ( e.Speech.ToLower() == "id" ) )
                    	{
                        	BeginIdentify ( e.Mobile );
                    	}
                    	else
                    	{
                        	base.OnSpeech( e );
                    	}
                }

                public void BeginIdentify( Mobile from )
                {
                    	if ( Deleted || !from.CheckAlive() )
                        	return;

                    	SayTo( from, "What do you want me to id?" );

                    	from.Target = new IdentifyTarget( this );
                }

                private class IdentifyTarget : Target
                {
                    	private SkaddriaJeweler m_Jeweler;

                    	public IdentifyTarget( SkaddriaJeweler jeweler ): base( 12, false, TargetFlags.None )
                    	{
                        	m_Jeweler = jeweler;
                    	}

                    	protected override void OnTarget( Mobile from, object targeted )
                    	{
				if ( targeted is PlayerMobile )
				{
					PlayerMobile pm = targeted as PlayerMobile;

					if ( pm.Female == false )
					{
                                		m_Jeweler.SayTo( from, "You are a male, not an object. But you do seem like a tough fella." );
					}
					else if ( pm.Female == true )
					{
                                		m_Jeweler.SayTo( from, "You are a female, not an object and not bad looking either." );
					}
					else
					{
                                		m_Jeweler.SayTo( from, "Yeah I'm not touching that with a 10 foot pole." );
					}
				}

				if ( targeted is BaseVendor )
				{
					BaseVendor bv = targeted as BaseVendor;

					if ( bv.Female == false )
					{
                                		m_Jeweler.SayTo( from, "That person identifies as a male. Want me to pull down their pants?" );
					}
					else if ( bv.Female == true )
					{
                                		m_Jeweler.SayTo( from, "That person identifies as a female. Want me to lift up their shirt?" );
					}
					else
					{
                                		m_Jeweler.SayTo( from, "They identify as none of your business." );
					}
				}

				if ( targeted is BaseCreature )
				{
					BaseCreature c = targeted as BaseCreature;

					if ( c.Tamable )
					{
                                		m_Jeweler.SayTo( from, "That creature seems to know its identity already. It doesn't need my help." );
					}
					else
					{
                                		m_Jeweler.SayTo( from, "Get that frigging thing away from me before it causes trouble." );
					}
				}

                        	if ( targeted is BaseWeapon )
                        	{
                            		BaseWeapon bw = targeted as BaseWeapon;
                            		Container pack = from.Backpack;
                            		int toConsume = 250;
                            		toConsume = 250;

                            		if ( bw.Identified == true )
                            		{
                                		m_Jeweler.SayTo( from, "That weapon is already identified." );
                            		}
                            		else if ( ( bw.Identified == false ) && ( pack.ConsumeTotal( typeof( Gold ), toConsume ) ) )
                            		{
			        		Item a = from.Backpack.FindItemByType( typeof( Gold ) );
			        		if ( a != null )

						a.Consume( toConsume );

                                		bw.Identified = true;
                                		m_Jeweler.SayTo( from, "Here is your weapon." );
                                		from.SendMessage( "You pay 500 gp." );
                                		Effects.PlaySound( from.Location, from.Map, 0x2A );
                            		}
                            		else
                            		{
                                		m_Jeweler.SayTo( from, "It will cost you 500 gp to have your weapon identified." );
                                		from.SendMessage( "You do not have enough gold." );
                            		}
                        	}

                        	else if ( targeted is BaseArmor )
                        	{
                            		BaseArmor ba = targeted as BaseArmor;
                            		Container pack = from.Backpack;
                            		int toConsume = 200;
                            		toConsume = 200;

                            		if ( ba.Identified == true )
                            		{
                                		m_Jeweler.SayTo( from, "That armor is already identified." );
                            		}
                            		else if ( ( ba.Identified == false ) && ( pack.ConsumeTotal( typeof( Gold ), toConsume ) ) )
                            		{
			        		Item a = from.Backpack.FindItemByType( typeof( Gold ) );
			        		if ( a != null )

						a.Consume( toConsume );

                                		ba.Identified = true;
                                		m_Jeweler.SayTo( from, "Here is your armor." );
                                		from.SendMessage( "You pay 400 gp." );
                                		Effects.PlaySound( from.Location, from.Map, 0x2A );
                            		}
                            		else
                            		{
                                		m_Jeweler.SayTo( from, "It will cost you 400 gp to have your armor identified." );
                                		from.SendMessage( "You do not have enough gold." );
                            		}                    
                        	}

                        	else if ( targeted is BaseClothing )
                        	{
                            		BaseClothing bc = targeted as BaseClothing;
                            		Container pack = from.Backpack;
                            		int toConsume = 150;
                            		toConsume = 150;

                            		if ( bc.Identified == true )
                            		{
                                		m_Jeweler.SayTo( from, "That clothing is already identified." );
                            		}
                            		else if ( ( bc.Identified == false ) && ( pack.ConsumeTotal( typeof( Gold ), toConsume ) ) )
                            		{
			        		Item a = from.Backpack.FindItemByType( typeof( Gold ) );
			        		if ( a != null )

						a.Consume( toConsume );

                                		bc.Identified = true;
                                		m_Jeweler.SayTo( from, "Here is your clothing." );
                                		from.SendMessage( "You pay 300 gp." );
                                		Effects.PlaySound( from.Location, from.Map, 0x2A );
                            		}
                            		else
                            		{
                                		m_Jeweler.SayTo( from, "It will cost you 300 gp to have your clothing identified." );
                                		from.SendMessage( "You do not have enough gold." );
                            		}                    
                        	}

                        	else if ( targeted is BaseJewel )
                        	{
                            		BaseJewel bj = targeted as BaseJewel;
                            		Container pack = from.Backpack;
                            		int toConsume = 100;
                            		toConsume = 100;

                            		if ( bj.Identified == true )
                            		{
                                		m_Jeweler.SayTo( from, "That jewel is already identified." );
                            		}
                            		else if ( ( bj.Identified == false ) && ( pack.ConsumeTotal( typeof( Gold ), toConsume ) ) )
                            		{
			        		Item a = from.Backpack.FindItemByType( typeof( Gold ) );
			        		if ( a != null )

						a.Consume( toConsume );

                                		bj.Identified = true;
                                		m_Jeweler.SayTo( from, "Here is your jewel." );
                                		from.SendMessage( "You pay 200 gp." );
                                		Effects.PlaySound( from.Location, from.Map, 0x2A );
                            		}
                            		else
                            		{
                                		m_Jeweler.SayTo( from, "It will cost you 200 gp to have your jewel identified." );
                                		from.SendMessage( "You do not have enough gold." );
                            		}                    
                        	}
				else
				{
                                	m_Jeweler.SayTo( from, "That is not something I can identify." );
				}
                    	}
                }

		public SkaddriaJeweler( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new SkaddriaJewelerEntry( from, this ) );
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

		public class SkaddriaJewelerEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public SkaddriaJewelerEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}
			
			public override void OnClick()
			{
				if( !( m_Mobile is PlayerMobile ) )
					return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				{
					if ( ! mobile.HasGump( typeof( SkaddriaJewelerGump ) ) )
					{
						mobile.SendGump( new SkaddriaJewelerGump( mobile ));
					}
				}
			}
		}
        }

	public class SBSkaddriaJeweler: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBSkaddriaJeweler() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{
				Add( new GenericBuyInfo( typeof( CrackedAttackChanceGem ), 500, 500, 0x3198, 1023 ) );
				Add( new GenericBuyInfo( typeof( CrackedSpellDamageGem ), 500, 500, 0x3198, 2607 ) );
				Add( new GenericBuyInfo( typeof( CrackedWeaponDamageGem ), 500, 500, 0x3198, 971 ) );
				Add( new GenericBuyInfo( typeof( CrackedWeaponSpeedGem ), 500, 500, 0x3198, 1009 ) );

				Add( new GenericBuyInfo( typeof( GoldRing ), 50, 20, 0x108A, 0 ) );
				Add( new GenericBuyInfo( typeof( Necklace ), 100, 20, 0x1085, 0 ) );
				Add( new GenericBuyInfo( typeof( GoldNecklace ), 100, 20, 0x1088, 0 ) );
				Add( new GenericBuyInfo( typeof( GoldBeadNecklace ), 100, 20, 0x1089, 0 ) );
				Add( new GenericBuyInfo( typeof( Beads ), 50, 20, 0x108B, 0 ) );
				Add( new GenericBuyInfo( typeof( GoldBracelet ), 80, 20, 0x1086, 0 ) );
				Add( new GenericBuyInfo( typeof( GoldEarrings ), 60, 20, 0x1087, 0 ) );

				Add( new GenericBuyInfo( typeof( Agate ), 30, 999, 0xF17, 2307 ) );
				Add( new GenericBuyInfo( typeof( Beryl ), 47, 999, 0xF2F, 496 ) );
				Add( new GenericBuyInfo( typeof( ChromeDiopside ), 70, 999, 0xF1C, 1902 ) );
				Add( new GenericBuyInfo( typeof( FireOpal ), 95, 999, 0xF15, 1357 ) );
				Add( new GenericBuyInfo( typeof( MoonstoneCustom ), 35, 999, 0xF1B, 1846 ) );
				Add( new GenericBuyInfo( typeof( Onyx ), 43, 999, 0xF18, 1905 ) );
				Add( new GenericBuyInfo( typeof( Opal ), 15, 999, 0xF26, 1187 ) );
				Add( new GenericBuyInfo( typeof( Pearl ), 31, 999, 0xF2B, 2960 ) );
				Add( new GenericBuyInfo( typeof( TurquoiseCustom ), 53, 999, 0xF15, 1286 ) );

				Add( new GenericBuyInfo( typeof( Bloodstone ), 162, 999, 0xF2F, 1194 ) );
				Add( new GenericBuyInfo( typeof( Citrine ), 169, 999, 0xF15, 0 ) );
				Add( new GenericBuyInfo( typeof( Demantoid ), 134, 999, 0xF26, 2076 ) );
				Add( new GenericBuyInfo( typeof( Jasper ), 165, 999, 0xF1B, 538 ) );
				Add( new GenericBuyInfo( typeof( Lolite ), 181, 999, 0xF17, 1176 ) );
				Add( new GenericBuyInfo( typeof( Lupis ), 144, 999, 0xF15, 2124 ) );
				Add( new GenericBuyInfo( typeof( Peridot ), 120, 999, 0xF18, 2126 ) );
				Add( new GenericBuyInfo( typeof( Tsavorite ), 193, 999, 0xF1C, 1594 ) );
				Add( new GenericBuyInfo( typeof( Zircon ), 112, 999, 0xF2B, 2422 ) );

				Add( new GenericBuyInfo( typeof( Amber ), 243, 999, 0xF25, 0 ) );
				Add( new GenericBuyInfo( typeof( Amethyst ), 242, 999, 0xF16, 0 ) );
				Add( new GenericBuyInfo( typeof( Andalusite ), 264, 999, 0xF2F, 2424 ) );
				Add( new GenericBuyInfo( typeof( Chrysoberyl ), 288, 999, 0xF15, 2961 ) );
				Add( new GenericBuyInfo( typeof( Garnet ), 238, 999, 0xF1B, 2116 ) );
				Add( new GenericBuyInfo( typeof( Jade ), 205, 999, 0xF17, 2002 ) );
				Add( new GenericBuyInfo( typeof( Mandarin ), 232, 999, 0xF2B, 1358 ) );
				Add( new GenericBuyInfo( typeof( Morganite ), 252, 999, 0xF26, 2970 ) );
				Add( new GenericBuyInfo( typeof( Paraiba ), 291, 999, 0xF18, 2499 ) );
				Add( new GenericBuyInfo( typeof( TigerEye ), 281, 999, 0xF1C, 1192 ) );
				Add( new GenericBuyInfo( typeof( Tourmaline ), 206, 999, 0xF2D, 0 ) );

				Add( new GenericBuyInfo( typeof( Alexandrite ), 360, 999, 0xF26, 2591 ) );
				Add( new GenericBuyInfo( typeof( Ametrine ), 353, 999, 0xF1B, 2599 ) );
				Add( new GenericBuyInfo( typeof( Kunzite ), 359, 999, 0xF17, 2535 ) );
				Add( new GenericBuyInfo( typeof( Ruby ), 392, 20, 0xF13, 0 ) );
				Add( new GenericBuyInfo( typeof( Sapphire ), 304, 999, 0xF19, 0 ) );
				Add( new GenericBuyInfo( typeof( Tanzanite ), 377, 999, 0xF15, 2593 ) );
				Add( new GenericBuyInfo( typeof( Topaz ), 386, 999, 0xF1C, 2952 ) );
				Add( new GenericBuyInfo( typeof( Zultanite ), 354, 999, 0xF2F, 2105 ) );

				Add( new GenericBuyInfo( typeof( Diamond ), 495, 999, 0xF26, 0 ) );
				Add( new GenericBuyInfo( typeof( Emerald ), 440, 999, 0xF10, 0 ) );
				Add( new GenericBuyInfo( typeof( PinkQuartz ), 454, 999, 0xF17, 2662 ) );
				Add( new GenericBuyInfo( typeof( StarSapphire ), 463, 999, 0xF21, 0 ) );

				Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ),  100, 20, 0x1ED0, 0, new object[] {  500 } ) ); // 500 charges
				Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ), 200, 20, 0x1ED0, 0, new object[] { 1000 } ) ); // 1000 charges
				Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ), 300, 20, 0x1ED0, 0, new object[] { 2000 } ) ); // 2000 charges

				Add( new GenericBuyInfo( "1060740", typeof( ReceiverCrystal ), 50, 20, 0x1ED0, 0 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( Agate ), 30 );
				Add( typeof( Beryl ), 47 );
				Add( typeof( ChromeDiopside ), 70 );
				Add( typeof( FireOpal ), 95 );
				Add( typeof( MoonstoneCustom ), 35 );
				Add( typeof( Onyx ), 43 );
				Add( typeof( Opal ), 15 );
				Add( typeof( Pearl ), 31 );
				Add( typeof( TurquoiseCustom ), 53 );

				Add( typeof( Bloodstone ), 162 );
				Add( typeof( Citrine ), 169 );
				Add( typeof( Demantoid ), 134 );
				Add( typeof( Jasper ), 165 );
				Add( typeof( Lolite ), 181 );
				Add( typeof( Lupis ), 144 );
				Add( typeof( Peridot ), 120 );
				Add( typeof( Tsavorite ), 193 );
				Add( typeof( Zircon ), 112 );

				Add( typeof( Amber ), 243 );
				Add( typeof( Amethyst ), 242 );
				Add( typeof( Andalusite ), 264 );
				Add( typeof( Chrysoberyl ), 288 );
				Add( typeof( Garnet ), 238 );
				Add( typeof( Jade ), 205 );
				Add( typeof( Mandarin ), 232 );
				Add( typeof( Morganite ), 252 );
				Add( typeof( Paraiba ), 291 );
				Add( typeof( TigerEye ), 281 );
				Add( typeof( Tourmaline ), 206 );

				Add( typeof( Alexandrite ), 360 );
				Add( typeof( Ametrine ), 353 );
				Add( typeof( Kunzite ), 359 );
				Add( typeof( Ruby ), 392 );
				Add( typeof( Sapphire ), 304 );
				Add( typeof( Tanzanite ), 377 );
				Add( typeof( Topaz ), 386 );
				Add( typeof( Zultanite ), 354 );

				Add( typeof( Diamond ), 495 );
				Add( typeof( Emerald ), 440 );
				Add( typeof( PinkQuartz ), 454 );
				Add( typeof( StarSapphire ), 463 );

				Add( typeof( GoldRing ), 25 );
				Add( typeof( SilverRing ), 25 );

				Add( typeof( Necklace ), 50 );
				Add( typeof( GoldNecklace ), 50 );
				Add( typeof( GoldBeadNecklace ), 50 );
				Add( typeof( SilverNecklace ), 50 );
				Add( typeof( SilverBeadNecklace ), 50 );

				Add( typeof( Beads ), 25 );

				Add( typeof( GoldBracelet ), 40 );
				Add( typeof( SilverBracelet ), 40 );

				Add( typeof( GoldEarrings ), 30 );
				Add( typeof( SilverEarrings ), 30 );
			} 
		} 
	} 

        public class SkaddriaJewelerGump : Gump 
        { 
                public static void Initialize() 
                { 
                     CommandSystem.Register( "SkaddriaJewelerGump", AccessLevel.GameMaster, new CommandEventHandler( SkaddriaJewelerGump_OnCommand ) ); 
                } 

                private static void SkaddriaJewelerGump_OnCommand( CommandEventArgs e ) 
                { 
                     e.Mobile.SendGump( new SkaddriaJewelerGump( e.Mobile ) ); 
                } 

                public SkaddriaJewelerGump( Mobile owner ) : base( 50,50 ) 
                { 
//----------------------------------------------------------------------------------------------------
			this.AddPage(0);
			this.AddBackground(126, 131, 398, 389, 9270);
			this.AddAlphaRegion(130, 132, 391, 389);
			this.AddImage(110, 460, 10464);
			this.AddImage(536, 214, 9265);
			this.AddImage(507, 460, 10464);
			this.AddImage(507, 408, 10464);
			this.AddImage(110, 193, 10464);
			this.AddImage(110, 247, 10464);
			this.AddImage(110, 301, 10464);
			this.AddImage(110, 354, 10464);
			this.AddImage(110, 408, 10464);
			this.AddImage(110, 139, 10464);
			this.AddImage(93, 197, 9263);
			this.AddImage(59, 124, 10421);
			this.AddImage(88, 110, 10420);
			this.AddImage(107, 246, 10411);
			this.AddImage(43, 399, 10402);
			this.AddImage(93, 513, 10103);
			this.AddImage(109, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(218, 513, 10100);
			this.AddImage(202, 513, 10100);
			this.AddImage(124, 513, 10100);
			this.AddImage(172, 513, 10100);
			this.AddImage(156, 513, 10100);
			this.AddImage(140, 513, 10100);
			this.AddImage(188, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(249, 513, 10100);
			this.AddImage(264, 513, 10100);
			this.AddImage(218, 513, 10100);
			this.AddImage(308, 513, 10100);
			this.AddImage(172, 513, 10100);
			this.AddImage(292, 513, 10100);
			this.AddImage(188, 513, 10100);
			this.AddImage(277, 513, 10100);
			this.AddImage(339, 513, 10100);
			this.AddImage(324, 513, 10100);
			this.AddImage(415, 513, 10100);
			this.AddImage(399, 513, 10100);
			this.AddImage(354, 513, 10100);
			this.AddImage(368, 123, 10100);
			this.AddImage(385, 513, 10100);
			this.AddImage(445, 513, 10100);
			this.AddImage(430, 513, 10100);
			this.AddImage(521, 513, 10100);
			this.AddImage(505, 513, 10100);
			this.AddImage(460, 513, 10100);
			this.AddImage(476, 513, 10100);
			this.AddImage(491, 513, 10100);
			this.AddImage(156, 123, 10100);
			this.AddImage(140, 123, 10100);
			this.AddImage(232, 123, 10100);
			this.AddImage(216, 123, 10100);
			this.AddImage(171, 123, 10100);
			this.AddImage(187, 123, 10100);
			this.AddImage(202, 123, 10100);
			this.AddImage(339, 513, 10100);
			this.AddImage(324, 513, 10100);
			this.AddImage(415, 513, 10100);
			this.AddImage(399, 513, 10100);
			this.AddImage(353, 123, 10100);
			this.AddImage(369, 513, 10100);
			this.AddImage(385, 513, 10100);
			this.AddImage(263, 123, 10100);
			this.AddImage(248, 123, 10100);
			this.AddImage(339, 123, 10100);
			this.AddImage(323, 123, 10100);
			this.AddImage(278, 123, 10100);
			this.AddImage(294, 123, 10100);
			this.AddImage(309, 123, 10100);
			this.AddImage(398, 123, 10100);
			this.AddImage(383, 123, 10100);
			this.AddImage(474, 123, 10100);
			this.AddImage(458, 123, 10100);
			this.AddImage(413, 123, 10100);
			this.AddImage(429, 123, 10100);
			this.AddImage(444, 123, 10100);
			this.AddImage(505, 123, 10100);
			this.AddImage(489, 123, 10100);
			this.AddImage(521, 123, 10100);
			this.AddImage(507, 193, 10464);
			this.AddImage(507, 139, 10464);
			this.AddImage(507, 354, 10464);
			this.AddImage(507, 299, 10464);
			this.AddImage(507, 247, 10464);
			this.AddImage(523, 254, 10411);
			this.AddImage(532, 130, 10431);
			this.AddImage(500, 112, 10430);
			this.AddImage(535, 513, 10105);
			this.AddImage(520, 417, 10412);
			this.AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 );
			this.AddHtml( 157, 181, 345, 279, "G'day to you and welcome my fellow Almharian. If you have any gems or jewels you want to sell then I'll take them off your hands. In addition if you have any equipment that needs to be identified then simply say to me id and I'll do just that for a fee of course. Weapons costs 500 gp, armor costs 400 gp, clothing costs 300 gp, and jewels cost 200 gp.", false, true);

//----------------------------------------------------------------------------------------------------
		}

                public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 

                { 
                    Mobile from = state.Mobile; 

                    switch ( info.ButtonID ) 
                { 

                case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
                { 
                    //Cancel 
                    break; 
                } 
            }
        }
    }
}