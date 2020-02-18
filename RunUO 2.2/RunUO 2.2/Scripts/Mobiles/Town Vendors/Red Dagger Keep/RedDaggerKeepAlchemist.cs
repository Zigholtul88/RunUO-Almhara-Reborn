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
	public class RedDaggerKeepAlchemist : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public RedDaggerKeepAlchemist() : base( "the alchemist" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBRedDaggerKeepAlchemist() ); 
		}

		public override void InitOutfit()
		{
			Name = "Crimsharr";
			Body = 148;
			BaseSoundID = 451;

			SetStr( 105 );
			SetDex( 92 );
			SetInt( 197 );

			SetSkill( SkillName.Alchemy, 85.0, 100.0 );
			SetSkill( SkillName.EvalInt, 65.0, 88.0 );
			SetSkill( SkillName.Magery, 64.0, 100.0 );
			SetSkill( SkillName.MagicResist, 65.0, 88.0 );
			SetSkill( SkillName.Wrestling, 36.0, 68.0 );
			SetSkill( SkillName.TasteID, 65.0, 88.0 );

			PackGold( 31, 63 );

			PackReg( 5, 10 );
			PackItem( new Bone() );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new MagicArrowScroll() );

			PackItem( new Bonemeal( Utility.RandomMinMax( 13, 24 ) ) );
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

		public RedDaggerKeepAlchemist( Serial serial ) : base( serial ) 
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

	public class SBRedDaggerKeepAlchemist : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBRedDaggerKeepAlchemist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
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
				Add( new GenericBuyInfo( "Greater Toxic Potion", typeof( GreaterToxicPotion ), 2000, 500, 0xF0D, 64 ) );

 				Add( new GenericBuyInfo( typeof( CurePotion ), 700, 800, 0xF07, 0 ) );
				Add( new GenericBuyInfo( typeof( HealPotion ), 700, 800, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( "Sky Blue Potion", typeof( ManaPotion ), 800, 800, 0xF03, 1266 ) );

				Add( new GenericBuyInfo( typeof( ExplosionPotion ), 700, 800, 0xF0D, 0 ) );
				Add( new GenericBuyInfo( "Magenta Potion", typeof( LightningPotion ), 700, 800, 0xF0D, 23 ) );
				Add( new GenericBuyInfo( "Ice Blue Potion", typeof( ShatterPotion ), 700, 800, 0xF0D, 1152 ) );
				Add( new GenericBuyInfo( "Toxic Potion", typeof( ToxicPotion ), 1000, 500, 0xF0D, 64 ) );

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
				Add( new GenericBuyInfo( "Lesser Toxic Potion", typeof( LesserToxicPotion ), 500, 500, 0xF0D, 64 ) );

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
			}
		}
	}
}
