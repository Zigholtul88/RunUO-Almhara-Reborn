using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;
using Server.Engines.BulkOrders;

namespace Server.Mobiles 
{ 
	public class YondallAlchemist : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public YondallAlchemist() : base( "the alchemist" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBYondallAlchemist() ); 
		}

		public override void InitOutfit()
		{
			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			SetSkill( SkillName.Alchemy, 85.0, 100.0 );
			SetSkill( SkillName.EvalInt, 65.0, 88.0 );
			SetSkill( SkillName.Magery, 64.0, 100.0 );
			SetSkill( SkillName.MagicResist, 65.0, 88.0 );
			SetSkill( SkillName.Wrestling, 36.0, 68.0 );
			SetSkill( SkillName.TasteID, 65.0, 88.0 );

			PackGold( 41, 82 );

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

		#region Bulk Orders
		public override Item CreateBulkOrder( Mobile from, bool fromContextMenu )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm != null && pm.NextAlchemyBulkOrder == TimeSpan.Zero && (fromContextMenu || 0.2 > Utility.RandomDouble()) )
			{
				double theirSkill = pm.Skills[SkillName.Alchemy].Base;

				if ( theirSkill >= 70.1 )
					pm.NextAlchemyBulkOrder = TimeSpan.FromHours( 3.0 );
				else if ( theirSkill >= 50.1 )
					pm.NextAlchemyBulkOrder = TimeSpan.FromHours( 2.0 );
				else
					pm.NextAlchemyBulkOrder = TimeSpan.FromHours( 1.0 );

				return SmallAlchemyBOD.CreateRandomFor( from );
			}

			return null;
		}

		public override bool IsValidBulkOrder( Item item )
		{
			return ( item is SmallAlchemyBOD || item is LargeAlchemyBOD );
		}

		public override bool SupportsBulkOrders( Mobile from )
		{
			return ( from is PlayerMobile && from.Skills[SkillName.Alchemy].Base > 0 );
		}

		public override TimeSpan GetNextBulkOrder( Mobile from )
		{
			if ( from is PlayerMobile )
				return ((PlayerMobile)from).NextAlchemyBulkOrder;

			return TimeSpan.Zero;
		}

		public override void OnSuccessfulBulkOrderReceive( Mobile from )
		{
			if( Core.SE && from is PlayerMobile )
				((PlayerMobile)from).NextAlchemyBulkOrder = TimeSpan.Zero;
		}
		#endregion

		public YondallAlchemist( Serial serial ) : base( serial ) 
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

	public class SBYondallAlchemist : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBYondallAlchemist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Your Trusty Potion Guide", typeof( YourTrustyPotionGuide ), 50, 100, 0xFBD, 0 ) );

				Add( new GenericBuyInfo( typeof( AgilityPotion ), 200, 100, 0xF08, 0 ) );
				Add( new GenericBuyInfo( "Teal Potion", typeof( MindPotion ), 200, 100, 0xF04, 1173 ) );
				Add( new GenericBuyInfo( typeof( StrengthPotion ), 200, 100, 0xF09, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 200, 100, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( "Lesser Sky Blue Potion", typeof( LesserManaPotion ), 300, 100, 0xF03, 1266 ) );

 				Add( new GenericBuyInfo( typeof( LesserCurePotion ), 200, 100, 0xF07, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserExplosionPotion ), 200, 100, 0xF0D, 0 ) );
				Add( new GenericBuyInfo( "Lesser Ice Blue Potion", typeof( LesserShatterPotion ), 200, 100, 0xF0D, 1152 ) );
				Add( new GenericBuyInfo( "Lesser Magenta Potion", typeof( LesserLightningPotion ), 200, 100, 0xF0D, 23 ) );
				Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 200, 100, 0xF0A, 0 ) );
				Add( new GenericBuyInfo( "Lesser Toxic Potion", typeof( LesserToxicPotion ), 700, 100, 0xF0D, 64 ) );

				Add( new GenericBuyInfo( typeof( NightSightPotion ), 200, 100, 0xF06, 0 ) );
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 200, 100, 0xF0B, 0 ) );

				Add( new GenericBuyInfo( typeof( HeatingStand ), 100, 100, 0x1849, 0 ) ); 
				Add( new GenericBuyInfo( typeof( MortarPestle ), 100, 100, 0xE9B, 0 ) );

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
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( AgilityPotion ), 50 );
				Add( typeof( LesserCurePotion ), 50 );
				Add( typeof( LesserExplosionPotion ), 50 );
				Add( typeof( LesserHealPotion ), 50 );
				Add( typeof( LesserPoisonPotion ), 50 );
				Add( typeof( NightSightPotion ), 50 );
				Add( typeof( RefreshPotion ), 50 );
				Add( typeof( StrengthPotion ), 50 );

				Add( typeof( MindPotion ), 50 );
				Add( typeof( LesserManaPotion ), 50 );
				Add( typeof( LesserShatterPotion ), 50 );
				Add( typeof( LesserLightningPotion ), 50 );

				Add( typeof( NovicePotionOfArchery ), 50 );
				Add( typeof( NovicePotionOfFencing ), 50 );
				Add( typeof( NovicePotionOfMaceFighting ), 50 );
				Add( typeof( NovicePotionOfMagery ), 50 );
				Add( typeof( NovicePotionOfParry ), 50 );
				Add( typeof( NovicePotionOfSwordsmanship ), 50 );
				Add( typeof( NovicePotionOfWrestling ), 50 );

				Add( typeof( NovicePotionOfAlchemy ), 50 );
				Add( typeof( NovicePotionOfBlacksmithy ), 50 );
				Add( typeof( NovicePotionOfCarpentry ), 50 );
				Add( typeof( NovicePotionOfCooking ), 50 );
				Add( typeof( NovicePotionOfFletching ), 50 );
				Add( typeof( NovicePotionOfInscription ), 50 );
				Add( typeof( NovicePotionOfTailoring ), 50 );
				Add( typeof( NovicePotionOfTinkering ), 50 );

				Add( typeof( NovicePotionOfAnimalTaming ), 50 );
				Add( typeof( NovicePotionOfDiscordance ), 50 );
				Add( typeof( NovicePotionOfFishing ), 50 );
				Add( typeof( NovicePotionOfHerding ), 50 );
				Add( typeof( NovicePotionOfHiding ), 50 );
				Add( typeof( NovicePotionOfLumberjacking ), 50 );
				Add( typeof( NovicePotionOfMagicResist ), 50 );
				Add( typeof( NovicePotionOfMining ), 50 );

				Add( typeof( NovicePotionOfPeacemaking ), 50 );
				Add( typeof( NovicePotionOfPoisoning ), 50 );
				Add( typeof( NovicePotionOfProvocation ), 50 );
				Add( typeof( NovicePotionOfSnooping ), 50 );
				Add( typeof( NovicePotionOfStealing ), 50 );
				Add( typeof( NovicePotionOfVeterinary ), 50 );

				Add( typeof( HeatingStand ), 50 );
				Add( typeof( MortarPestle ), 50 );

				Add( typeof( Bone ), 2 ); 
				Add( typeof( RibCage ), 5 ); 
				Add( typeof( BonePile ), 10 );  
			}
		}
	}
}
