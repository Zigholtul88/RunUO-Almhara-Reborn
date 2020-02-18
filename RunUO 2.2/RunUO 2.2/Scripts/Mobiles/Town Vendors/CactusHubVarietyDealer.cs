using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Engines.Craft;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;
using Server.ACC.CSS.Systems.Bard;
using Server.ACC.CSS.Systems.Druid;

namespace Server.Mobiles 
{ 
	public class CactusHubVarietyDealer : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public CactusHubVarietyDealer() : base( "the variety dealer" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBCactusHubVarietyDealer() ); 
		}

		public override void InitOutfit()
		{
			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			SetSkill( SkillName.AnimalLore, 55.0, 78.0 );
			SetSkill( SkillName.AnimalTaming, 55.0, 78.0 );
			SetSkill( SkillName.Herding, 64.0, 100.0 );
			SetSkill( SkillName.Veterinary, 60.0, 83.0 );

			PackGold( 23, 35 );

			AddItem( new StrawHat(2405) );

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

		public CactusHubVarietyDealer( Serial serial ) : base( serial ) 
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

	public class SBCactusHubVarietyDealer : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBCactusHubVarietyDealer() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 	
////////////////////////////////////////////////////// Tools
// All tools sell at a base price of 100 gp
				Add( new GenericBuyInfo( typeof( ElvenQuiver ), 100, 20, 0x2FB7, 0 ) );
				Add( new GenericBuyInfo( typeof( FletcherTools ), 100, 378, 0x1022, 0 ) );
				Add( new GenericBuyInfo( typeof( HeatingStand ), 100, 100, 0x1849, 0 ) ); 
				Add( new GenericBuyInfo( typeof( JuicersTools ), 100, 20, 0xE4F, 0 ) );
				Add( new GenericBuyInfo( typeof( MortarPestle ), 100, 100, 0xE9B, 0 ) );
		                Add( new GenericBuyInfo( typeof( Scissors ), 100, 40, 0xF9F, 0 ) );
				Add( new GenericBuyInfo( typeof( SewingKit ), 100, 500, 0xF9D, 0 ) );
				Add( new GenericBuyInfo( typeof( SmithHammer ), 100, 999, 0x13E3, 0 ) );
				Add( new GenericBuyInfo( typeof( Tongs ), 100, 999, 0xFBB, 0 ) ); 

////////////////////////////////////////////////////// Primary Components
				Add( new GenericBuyInfo( "Board", typeof( Board ), 5, 999, 0x1BD7, 0 ) );
				Add( new GenericBuyInfo( "Iron Ingot", typeof( IronIngot ), 5, 999, 0x1BF2, 0 ) );
				Add( new GenericBuyInfo( "Leather", typeof( Leather ), 5, 999, 0x1081, 0 ) );
				Add( new GenericBuyInfo( "Log", typeof( Log ), 5, 999, 0x1BDD, 0 ) );

				Add( new GenericBuyInfo( typeof( Cotton ), 5, 999, 0xDF9, 0 ) );
				Add( new GenericBuyInfo( "Dark Yarn", typeof( DarkYarn ), 5, 999, 0xE1D, 0 ) );
				Add( new GenericBuyInfo( "Light Yarn", typeof( LightYarn ), 5, 999, 0xE1E, 0 ) );

				Add( new GenericBuyInfo( typeof( Flax ), 5, 999, 0x1A9C, 0 ) );
				Add( new GenericBuyInfo( typeof( SpoolOfThread ), 5, 999, 0xFA0, 0 ) );
				Add( new GenericBuyInfo( typeof( Wool ), 5, 999, 0xDF8, 0 ) );

////////////////////////////////////////////////////// Secondary Components
				Add( new GenericBuyInfo( "Copper Wire", typeof( CopperWire ), 1, 999, 0x1879, 0 ) );
				Add( new GenericBuyInfo( "Feather", typeof( Feather ), 1, 999, 0x1BD1, 0 ) );
				Add( new GenericBuyInfo( "Gears", typeof( Gears ), 1, 999, 0x1053, 0 ) );
				Add( new GenericBuyInfo( "Gold Wire", typeof( GoldWire ), 1, 999, 0x1878, 0 ) );
				Add( new GenericBuyInfo( "Iron Wire", typeof( IronWire ), 1, 999, 0x1876, 0 ) );
				Add( new GenericBuyInfo( "Shaft", typeof( Shaft ), 1, 999, 0x1BD4, 0 ) );
				Add( new GenericBuyInfo( "Silver Wire", typeof( SilverWire ), 1, 999, 0x1877, 0 ) );
				Add( new GenericBuyInfo( "Spool of Thread", typeof( SpoolOfThread ), 1, 999, 0xFA0, 0 ) );
				Add( new GenericBuyInfo( "Springs", typeof( Springs ), 1, 999, 0x105D, 0 ) );

////////////////////////////////////////////////////// Bard Items
				Add( new GenericBuyInfo( "Bard Spellbook", typeof( BardSpellbook ), 800, 10, 0xEFA, 0x96 ) );

				Add( new GenericBuyInfo( "Energy Carol Scroll", typeof( BardEnergyCarolScroll ), 200, 244, 0x14ED, 0x96 ) );
				Add( new GenericBuyInfo( "Fire Carol Scroll", typeof( BardFireCarolScroll ), 200, 368, 0x14ED, 0x96 ) );
				Add( new GenericBuyInfo( "Ice Carol Scroll", typeof( BardIceCarolScroll ), 200, 368, 0x14ED, 0x96 ) );
				Add( new GenericBuyInfo( "Poison Carol Scroll", typeof( BardPoisonCarolScroll ), 200, 251, 0x14ED, 0x96 ) );

				Add( new GenericBuyInfo( typeof( Drums ), 500, ( 20 ), 0x0E9C, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Tambourine ), 500, ( 20 ), 0x0E9E, 0 ) ); 
				Add( new GenericBuyInfo( typeof( LapHarp ), 500, ( 20 ), 0x0EB2, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Lute ), 500, ( 20 ), 0x0EB3, 0 ) ); 

////////////////////////////////////////////////////// Ammunition
				Add( new GenericBuyInfo( typeof( Arrow ), 5, Utility.Random( 80, 100 ), 0xF3F, 0 ) );
				Add( new GenericBuyInfo( typeof( OakArrow ), 10, Utility.Random( 50, 80 ), 0xF3F, 2010 ) );
				Add( new GenericBuyInfo( typeof( YewArrow ), 15, Utility.Random( 50, 80 ), 0xF3F, 1192 ) );
				Add( new GenericBuyInfo( typeof( AshArrow ), 20, Utility.Random( 50, 80 ), 0xF3F, 1191 ) );

				Add( new GenericBuyInfo( typeof( Bolt ), 5, Utility.Random( 80, 100 ), 0x1BFB, 0 ) );
				Add( new GenericBuyInfo( typeof( DullCopperBolt ), 10, Utility.Random( 50, 100 ), 0x1BFB, 2419 ) );
				Add( new GenericBuyInfo( typeof( ShadowIronBolt ), 15, Utility.Random( 50, 100 ), 0x1BFB, 2406 ) );
				Add( new GenericBuyInfo( typeof( BronzeBolt ), 20, Utility.Random( 50, 100 ), 0x1BFB, 2418 ) );

////////////////////////////////////////////////////// Potions
				Add( new GenericBuyInfo( "Your Trusty Potion Guide", typeof( YourTrustyPotionGuide ), 50, 800, 0xFBD, 0 ) );

				Add( new GenericBuyInfo( typeof( GreaterAgilityPotion ), 800, 500, 0xF08, 0 ) );
				Add( new GenericBuyInfo( "Greater Teal Potion", typeof( GreaterMindPotion ), 800, 500, 0xF04, 1173 ) );
				Add( new GenericBuyInfo( typeof( GreaterStrengthPotion ), 800, 500, 0xF09, 0 ) );

 				Add( new GenericBuyInfo( typeof( GreaterCurePotion ), 1000, 500, 0xF07, 0 ) );
				Add( new GenericBuyInfo( typeof( GreaterHealPotion ), 1000, 500, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( "Greater Sky Blue Potion", typeof( GreaterManaPotion ), 1000, 500, 0xF03, 1266 ) );

				Add( new GenericBuyInfo( typeof( GreaterExplosionPotion ), 1500, 800, 0xF0D, 0 ) );
				Add( new GenericBuyInfo( "Greater Magenta Potion", typeof( GreaterLightningPotion ), 1500, 800, 0xF0D, 23 ) );
				Add( new GenericBuyInfo( "Greater Ice Blue Potion", typeof( GreaterShatterPotion ), 1500, 800, 0xF0D, 1152 ) );

 				Add( new GenericBuyInfo( typeof( CurePotion ), 700, 800, 0xF07, 0 ) );
				Add( new GenericBuyInfo( typeof( HealPotion ), 700, 800, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( "Sky Blue Potion", typeof( ManaPotion ), 800, 800, 0xF03, 1266 ) );

				Add( new GenericBuyInfo( typeof( ExplosionPotion ), 700, 800, 0xF0D, 0 ) );
				Add( new GenericBuyInfo( "Magenta Potion", typeof( LightningPotion ), 700, 800, 0xF0D, 23 ) );
				Add( new GenericBuyInfo( "Ice Blue Potion", typeof( ShatterPotion ), 700, 800, 0xF0D, 1152 ) );

				Add( new GenericBuyInfo( typeof( AgilityPotion ), 200, 800, 0xF08, 0 ) );
				Add( new GenericBuyInfo( "Teal Potion", typeof( MindPotion ), 200, 800, 0xF04, 1173 ) );
				Add( new GenericBuyInfo( typeof( StrengthPotion ), 200, 800, 0xF09, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 200, 800, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( "Lesser Sky Blue Potion", typeof( LesserManaPotion ), 300, 800, 0xF03, 1266 ) );

 				Add( new GenericBuyInfo( typeof( LesserCurePotion ), 200, 800, 0xF07, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserExplosionPotion ), 200, 100, 0xF0D, 0 ) );
				Add( new GenericBuyInfo( "Lesser Ice Blue Potion", typeof( LesserShatterPotion ), 200, 800, 0xF0D, 1152 ) );
				Add( new GenericBuyInfo( "Lesser Magenta Potion", typeof( LesserLightningPotion ), 200, 800, 0xF0D, 23 ) );
				Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 200, 100, 0xF0A, 0 ) );

				Add( new GenericBuyInfo( typeof( NightSightPotion ), 200, 800, 0xF06, 0 ) );
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 200, 800, 0xF0B, 0 ) );

				Add( new GenericBuyInfo( typeof( HeatingStand ), 100, 800, 0x1849, 0 ) ); 
				Add( new GenericBuyInfo( typeof( MortarPestle ), 100, 800, 0xE9B, 0 ) );

////////////////////////////////////////////////////// Adept Combat Potions
				Add( new GenericBuyInfo( "Adept Potion Of Archery", typeof( AdeptPotionOfArchery ), 500, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Fencing", typeof( AdeptPotionOfFencing ), 500, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Mace Fighting", typeof( AdeptPotionOfMaceFighting ), 500, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Magery", typeof( AdeptPotionOfMagery ), 500, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Parry", typeof( AdeptPotionOfParry ), 500, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Swordsmanship", typeof( AdeptPotionOfSwordsmanship ), 500, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Wrestling", typeof( AdeptPotionOfWrestling ), 500, 100, 0xE29, 45 ) );

////////////////////////////////////////////////////// Adept Crafting Potions
				Add( new GenericBuyInfo( "Adept Potion Of Alchemy", typeof( AdeptPotionOfAlchemy ), 500, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Blacksmithy", typeof( AdeptPotionOfBlacksmithy ), 500, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Mace Fighting", typeof( AdeptPotionOfCarpentry ), 500, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Magery", typeof( AdeptPotionOfCooking ), 500, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Parry", typeof( AdeptPotionOfFletching ), 500, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Swordsmanship", typeof( AdeptPotionOfInscription ), 500, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Wrestling", typeof( AdeptPotionOfTailoring ), 500, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Tinkering", typeof( AdeptPotionOfTinkering ), 500, 100, 0xE29, 60 ) );

////////////////////////////////////////////////////// Adept Misc Potions
				Add( new GenericBuyInfo( "Adept Potion Of Animal Taming", typeof( AdeptPotionOfAnimalTaming ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Discordance", typeof( AdeptPotionOfDiscordance ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Fishing", typeof( AdeptPotionOfFishing ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Herding", typeof( AdeptPotionOfHerding ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Hiding", typeof( AdeptPotionOfHiding ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Lumberjacking", typeof( AdeptPotionOfLumberjacking ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Magic Resist", typeof( AdeptPotionOfMagicResist ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Mining", typeof( AdeptPotionOfMining ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Peacemaking", typeof( AdeptPotionOfPeacemaking ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Poisoning", typeof( AdeptPotionOfPoisoning ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Provocation", typeof( AdeptPotionOfProvocation ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Snooping", typeof( AdeptPotionOfSnooping ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Stealing", typeof( AdeptPotionOfStealing ), 500, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Adept Potion Of Veterinary", typeof( AdeptPotionOfVeterinary ), 500, 100, 0xE29, 285 ) );

////////////////////////////////////////////////////// Novice Combat Potions
				Add( new GenericBuyInfo( "Novice Potion Of Archery", typeof( NovicePotionOfArchery ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Fencing", typeof( NovicePotionOfFencing ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Mace Fighting", typeof( NovicePotionOfMaceFighting ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Magery", typeof( NovicePotionOfMagery ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Parry", typeof( NovicePotionOfParry ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Swordsmanship", typeof( NovicePotionOfSwordsmanship ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Wrestling", typeof( NovicePotionOfWrestling ), 100, 100, 0xE29, 45 ) );

////////////////////////////////////////////////////// Novice Crafting Potions
				Add( new GenericBuyInfo( "Novice Potion Of Alchemy", typeof( NovicePotionOfAlchemy ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Blacksmithy", typeof( NovicePotionOfBlacksmithy ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Mace Fighting", typeof( NovicePotionOfCarpentry ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Magery", typeof( NovicePotionOfCooking ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Parry", typeof( NovicePotionOfFletching ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Swordsmanship", typeof( NovicePotionOfInscription ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Wrestling", typeof( NovicePotionOfTailoring ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Tinkering", typeof( NovicePotionOfTinkering ), 100, 100, 0xE29, 60 ) );

////////////////////////////////////////////////////// Novice Misc Potions
				Add( new GenericBuyInfo( "Novice Potion Of Animal Taming", typeof( NovicePotionOfAnimalTaming ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Discordance", typeof( NovicePotionOfDiscordance ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Fishing", typeof( NovicePotionOfFishing ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Herding", typeof( NovicePotionOfHerding ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Hiding", typeof( NovicePotionOfHiding ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Lumberjacking", typeof( NovicePotionOfLumberjacking ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Magic Resist", typeof( NovicePotionOfMagicResist ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Mining", typeof( NovicePotionOfMining ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Peacemaking", typeof( NovicePotionOfPeacemaking ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Poisoning", typeof( NovicePotionOfPoisoning ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Provocation", typeof( NovicePotionOfProvocation ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Snooping", typeof( NovicePotionOfSnooping ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Stealing", typeof( NovicePotionOfStealing ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Veterinary", typeof( NovicePotionOfVeterinary ), 100, 100, 0xE29, 285 ) );

////////////////////////////////////////////////////// Reagents
				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, 999, 0xF7A, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, 999, 0xF7B, 0 ) ); 
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, 999, 0xF86, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Garlic ), 3, 999, 0xF84, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, 999, 0xF85, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Nightshade ), 3, 999, 0xF88, 0 ) ); 
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, 999, 0xF8D, 0 ) ); 
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, 999, 0xF8C, 0 ) ); 

				Add( new GenericBuyInfo( typeof( BatWing ), 8, 999, 0xF78, 0 ) );
				Add( new GenericBuyInfo( typeof( DaemonBlood ), 8, 999, 0xF7D, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveDust ), 8, 999, 0xF8F, 0 ) );
				Add( new GenericBuyInfo( typeof( NoxCrystal ), 8, 999, 0xF8E, 0 ) );
				Add( new GenericBuyInfo( typeof( PigIron ), 8, 999, 0xF8A, 0 ) );

				Add( new GenericBuyInfo( "Destroying Angel", typeof( DestroyingAngel ), 8, 999, 0xE1F, 0x290 ) );
				Add( new GenericBuyInfo( "Petrafied Wood", typeof( PetrafiedWood ), 8, 999, 0x97A, 0x46C ) );
				Add( new GenericBuyInfo( "Spring Water", typeof( SpringWater ), 8, 999, 0xE24, 0x47F ) );

////////////////////////////////////////////////////// Scrolls
				Add( new GenericBuyInfo( typeof( BlankScroll ), 5, 999, 0x0E34, 0 ) );
				Add( new GenericBuyInfo( "Identification Scroll", typeof( IdentificationScroll ), 25, 999, 0x481, 5360 ) );
				Add( new GenericBuyInfo( "Recharge Scroll", typeof( RechargeScroll ), 50, 999, 0x1F65, 0 ) );

				Type[] types = Loot.RegularScrollTypes;

				int circles = 3;

				for ( int i = 0; i < circles*8 && i < types.Length; ++i )
				{
					int itemID = 0x1F2E + i;

					if ( i == 6 )
						itemID = 0x1F2D;
					else if ( i > 6 )
						--itemID;

					Add( new GenericBuyInfo( types[i], 12 + ((i / 8) * 10), 20, itemID, 0 ) );
				}

////////////////////////////////////////////////////// Misc
				Add( new GenericBuyInfo( "TamersHandbookEcology", typeof( TamersHandbookEcology ), 5, 999, 0x1C11, 2110 ) );

				Add( new GenericBuyInfo( typeof( Backpack ), 25, 50, 0x9B2, 0 ) );
				Add( new GenericBuyInfo( typeof( Bandage ), 5, 999, 0xE21, 0 ) );
				Add( new GenericBuyInfo( typeof( BookOfZooTravel ), 1000, 50, 17080, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyJuiceBottle ), 20, 999, 0x99B, 0 ) );
				Add( new GenericBuyInfo( typeof( RecallRune ), 100, 999, 0x1f14, 0 ) );
				Add( new GenericBuyInfo( typeof( Spellbook ), 100, 55, 0xEFA, 0 ) );
				Add( new GenericBuyInfo( typeof( NecromancerSpellbook ), 115, 67, 0x2253, 0 ) );

				Add( new GenericBuyInfo( "1041072", typeof( MagicWizardsHat ), 11, 10, 0x1718, 0 ) );

////////////////////////////////////////////////////// Drinks
				Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Ale, 14, 50, 0x99F, 0 ) );
				Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Wine, 14, 46, 0x9C7, 0 ) );
				Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Liquor, 14, 37, 0x99B, 0 ) );
				Add( new BeverageBuyInfo( typeof( Jug ), BeverageType.Cider, 26, 86, 0x9C8, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 14, 50, 0x9F0, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Ale, 22, 45, 0x1F95, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Cider, 22, 75, 0x1F97, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Liquor, 22, 61, 0x1F99, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Wine, 22, 39, 0x1F9B, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Water, 22, 82, 0x1F9D, 0 ) );

////////////////////////////////////////////////////// Food
				Add( new GenericBuyInfo( typeof( BreadLoaf ), 12, 56, 0x103B, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseWheel ), 42, 72, 0x97E, 0 ) );
				Add( new GenericBuyInfo( typeof( CookedBird ), 36, 44, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( LambLeg ), 16, 65, 0x160A, 0 ) );
				Add( new GenericBuyInfo( typeof( ChickenLeg ), 10, 65, 0x1608, 0 ) );
				Add( new GenericBuyInfo( typeof( Ribs ), 14, 70, 0x9F2, 0 ) );

				Add( new GenericBuyInfo( typeof( WoodenBowlOfCarrots ), 25, 100, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfCorn ), 28, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfLettuce ), 26, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfPeas ), 23, 100, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyPewterBowl ), 15, 100, 0x15FD, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfCorn ), 28, 100, 0x15FE, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfLettuce ), 26, 100, 0x15FF, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPeas ), 23, 100, 0x1600, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPotatos ), 25, 100, 0x1601, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfStew ), 27, 100, 0x1604, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfTomatoSoup ), 32, 100, 0x1606, 0 ) );

				Add( new GenericBuyInfo( typeof( ApplePie ), 28, 20, 0x1041, 0 ) ); //OSI just has Pie, not Apple/Fruit/Meat
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
////////////////////////////////////////////////////// Gems
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

//////////////////////////////// Raw Food ////////////////////////////////
				Add( typeof( AlligatorMeat ), 6 ); 
				Add( typeof( BlackLizardMeat ), 7 ); 
				Add( typeof( FaerieBeetleCollectorMeat ), 5 ); 
				Add( typeof( FaerieBeetleMeat ), 12 );
				Add( typeof( GreySquirrelMeat ), 4 );
				Add( typeof( HillToadMeat ), 17 ); 
				Add( typeof( LargeFrogMeat ), 6 ); 
				Add( typeof( RawDireWolfLeg ), 8 ); 
				Add( typeof( RawForestBatRibs ), 3 );
				Add( typeof( RawGizzardRibs ), 6 ); 
				Add( typeof( RawGreyWolfLeg ), 5 ); 
				Add( typeof( RawHarpyRibs ), 16 ); 
				Add( typeof( SandCrabMeat ), 11 ); 
				Add( typeof( SewerBeef ), 4 );
				Add( typeof( WaterLizardMeat ), 9 ); 
				Add( typeof( WyvernMeat ), 25 ); 

//////////////////////////////// Poultry ////////////////////////////////
				Add( typeof( RawBird ), 2 ); 
				Add( typeof( RawChicken ), 5 ); 
				Add( typeof( RawChickenLeg ), 4 ); 
				Add( typeof( RawDuck ), 5 ); 
				Add( typeof( RawDuckLeg ), 4 ); 
				Add( typeof( RawTurkey ), 26 );
				Add( typeof( RawTurkeyLeg ), 14 ); 

//////////////////////////////// Protein Foods ////////////////////////////////
				Add( typeof( RawRibs ), 5 ); 
				Add( typeof( RawLambLeg ), 4 ); 
				Add( typeof( RawChickenLeg ), 3 ); 
				Add( typeof( RawFishSteak ), 3 );

//////////////////////////////// Monster Parts ////////////////////////////////
				Add( typeof( SmallStarLakeCrabEgg ), 250 ); 
				Add( typeof( LargeStarLakeCrabEgg ), 300 ); 

				Add( typeof( AlytharrGrassSnakeSkin ), 65 ); 
				Add( typeof( BlackLizardEyeBall ), 75 ); 
				Add( typeof( BogCreeperCarapace ), 150 );
				Add( typeof( CaveBearClaw ), 125 ); 
				Add( typeof( CavernMongbatClaw ), 75 ); 
				Add( typeof( CavernScorpionCarapace ), 150 );
 				Add( typeof( CharredSpriteWings ), 275 ); 
				Add( typeof( CliffStriderPowder ), 125 ); 
				Add( typeof( CrushedShatterGlass ), 125 ); 
				Add( typeof( DragonHeart ), 500 );
				Add( typeof( EttinTooth ), 85 ); 
				Add( typeof( FaerieBeetleCarapace ), 50 ); 
				Add( typeof( ForestBatClaw ), 50 );
				Add( typeof( ForestHartShard ), 500 );
				Add( typeof( GiantToadEye ), 145 );
				Add( typeof( GreenSlimeVial ), 125 );
				Add( typeof( GrobusFur ), 800 );
				Add( typeof( HarpyTalon ), 175 );
				Add( typeof( HillToadEye ), 125 );
				Add( typeof( LesserAntlionCarapace ), 175 );
				Add( typeof( MesmenirHorn ), 175 );
				Add( typeof( MinorBloodVial ), 300 );
				Add( typeof( MummyBandage ), 85 );
				Add( typeof( OgreEye ), 125 );
				Add( typeof( OphidianEye ), 65 );
				Add( typeof( PookahEye ), 200 );
				Add( typeof( RawDireWolfLeg ), 75 ); 
				Add( typeof( RawGreyWolfLeg ), 50 );
				Add( typeof( RazorbackTooth ), 225 );
				Add( typeof( RoseOfQuagmire ), 115 );
				Add( typeof( RoseOfUmdhlebi ), 275 );
				Add( typeof( SandCrabMeat ), 75 );
				Add( typeof( SandStreakerWings ), 145 );
				Add( typeof( SmallBlackAntEgg ), 200 );
				Add( typeof( SwampVineAppendages ), 125 );
				Add( typeof( TerathanEye ), 50 );
				Add( typeof( TrollTooth ), 105 );
				Add( typeof( VerdantSpriteWings ), 75 );
				Add( typeof( WaterLizardEyeBall ), 50 );
				Add( typeof( WyvernTooth ), 300 );
			} 
		} 
	} 
}
