using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBMage : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMage()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Spellbook ), 100, 100, 0xEFA, 0 ) );
				
				if ( Core.AOS )
					Add( new GenericBuyInfo( typeof( NecromancerSpellbook ), 100, 100, 0x2253, 0 ) );
				
				Add( new GenericBuyInfo( typeof( ScribesPen ), 100, 100, 0xFBF, 0 ) );

				Add( new GenericBuyInfo( typeof( BlankScroll ), 5, 999, 0x0E34, 0 ) );

				Add( new GenericBuyInfo( "1041072", typeof( MagicWizardsHat ), 11, 200, 0x1718, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( RecallRune ), 15, 999, 0x1F14, 0 ) );

				Add( new GenericBuyInfo( "Your Trusty Potion Guide", typeof( YourTrustyPotionGuide ), 50, 100, 0xFBD, 0 ) );

				Add( new GenericBuyInfo( typeof( HeatingStand ), 100, 100, 0x1849, 0 ) ); 
				Add( new GenericBuyInfo( typeof( MortarPestle ), 100, 100, 0xE9B, 0 ) );

				Add( new GenericBuyInfo( typeof( AgilityPotion ), 200, 999, 0xF08, 0 ) );
				Add( new GenericBuyInfo( "Teal Potion", typeof( MindPotion ), 200, 999, 0xF04, 1173 ) );
				Add( new GenericBuyInfo( typeof( StrengthPotion ), 200, 999, 0xF09, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 200, 999, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( "Lesser Sky Blue Potion", typeof( LesserManaPotion ), 300, 999, 0xF03, 1266 ) );

 				Add( new GenericBuyInfo( typeof( LesserCurePotion ), 200, 999, 0xF07, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserExplosionPotion ), 200, 999, 0xF0D, 0 ) );
				Add( new GenericBuyInfo( "Lesser Ice Blue Potion", typeof( LesserShatterPotion ), 200, 999, 0xF0D, 1152 ) );
				Add( new GenericBuyInfo( "Lesser Magenta Potion", typeof( LesserLightningPotion ), 200, 999, 0xF0D, 23 ) );
				Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 200, 999, 0xF0A, 0 ) );
				Add( new GenericBuyInfo( "Lesser Toxic Potion", typeof( LesserToxicPotion ), 700, 999, 0xF0D, 64 ) );

				Add( new GenericBuyInfo( typeof( NightSightPotion ), 200, 999, 0xF06, 0 ) );
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 200, 999, 0xF0B, 0 ) );

				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, 999, 0xF7A, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, 999, 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 3, 999, 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, 999, 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, 999, 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 3, 999, 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, 999, 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, 999, 0xF8C, 0 ) );

				if ( Core.AOS )
				{
					Add( new GenericBuyInfo( typeof( BatWing ), 3, 999, 0xF78, 0 ) );
					Add( new GenericBuyInfo( typeof( DaemonBlood ), 6, 999, 0xF7D, 0 ) );
					Add( new GenericBuyInfo( typeof( PigIron ), 5, 999, 0xF8A, 0 ) );
					Add( new GenericBuyInfo( typeof( NoxCrystal ), 6, 999, 0xF8E, 0 ) );
					Add( new GenericBuyInfo( typeof( GraveDust ), 3, 999, 0xF8F, 0 ) );
				}

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
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( GreaterAgilityPotion ), 700 );
				Add( typeof( GreaterCurePotion ), 700 );
				Add( typeof( GreaterExplosionPotion ), 700 );
				Add( typeof( GreaterHealPotion ), 700 );
				Add( typeof( GreaterLightningPotion ), 700 );
				Add( typeof( GreaterManaPotion ), 700 );
				Add( typeof( GreaterMindPotion ), 700 );
				Add( typeof( GreaterPoisonPotion ), 700 );
				Add( typeof( GreaterShatterPotion ), 700 );
				Add( typeof( GreaterStrengthPotion ), 700 );

				Add( typeof( CurePotion ), 300 );
				Add( typeof( ExplosionPotion ), 300 );
				Add( typeof( HealPotion ), 300 );
				Add( typeof( LightningPotion ), 300 );
				Add( typeof( ManaPotion ), 300 );
				Add( typeof( PoisonPotion ), 300 );
				Add( typeof( ShatterPotion ), 300 );

				Add( typeof( AgilityPotion ), 50 );
				Add( typeof( LesserCurePotion ), 50 );
				Add( typeof( LesserExplosionPotion ), 50 );
				Add( typeof( LesserHealPotion ), 50 );
				Add( typeof( LesserLightningPotion ), 50 );
				Add( typeof( LesserManaPotion ), 50 );
				Add( typeof( LesserPoisonPotion ), 50 );
				Add( typeof( LesserShatterPotion ), 50 );
				Add( typeof( MindPotion ), 50 );
				Add( typeof( NightSightPotion ), 50 );
				Add( typeof( RefreshPotion ), 50 );
				Add( typeof( StrengthPotion ), 50 );

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

				Add( typeof( WizardsHat ), 15 );
				Add( typeof( BlackPearl ), 3 ); 
				Add( typeof( Bloodmoss ),4 ); 
				Add( typeof( MandrakeRoot ), 2 ); 
				Add( typeof( Garlic ), 2 ); 
				Add( typeof( Ginseng ), 2 ); 
				Add( typeof( Nightshade ), 2 ); 
				Add( typeof( SpidersSilk ), 2 ); 
				Add( typeof( SulfurousAsh ), 2 ); 

				if ( Core.AOS )
				{
					Add( typeof( BatWing ), 1 );
					Add( typeof( DaemonBlood ), 3 );
					Add( typeof( PigIron ), 2 );
					Add( typeof( NoxCrystal ), 3 );
					Add( typeof( GraveDust ), 1 );
				}

				Add( typeof( RecallRune ), 13 );
				Add( typeof( Spellbook ), 25 );

				Type[] types = Loot.RegularScrollTypes;

				for ( int i = 0; i < types.Length; ++i )
					Add(types[i], i + 3 + (i / 4));     // This is NOT 100% OSI accurate. Two spells per circle will be off by 1gp, as OSI's math is slightly different.


				if ( Core.SE )
				{				
					Add( typeof( ExorcismScroll ), 1 );
					Add( typeof( AnimateDeadScroll ), 26 );
					Add( typeof( BloodOathScroll ), 26 );
					Add( typeof( CorpseSkinScroll ), 26 );
					Add( typeof( CurseWeaponScroll ), 26 );
					Add( typeof( EvilOmenScroll ), 26 );
					Add( typeof( PainSpikeScroll ), 26 );
					Add( typeof( SummonFamiliarScroll ), 26 );
					Add( typeof( HorrificBeastScroll ), 27 );
					Add( typeof( MindRotScroll ), 39 );
					Add( typeof( PoisonStrikeScroll ), 39 );
					Add( typeof( WraithFormScroll ), 51 );
					Add( typeof( LichFormScroll ), 64 );
					Add( typeof( StrangleScroll ), 64 );
					Add( typeof( WitherScroll ), 64 );
					Add( typeof( VampiricEmbraceScroll ), 101 );
					Add( typeof( VengefulSpiritScroll ), 114 );
			}

		}
	}
	}
}