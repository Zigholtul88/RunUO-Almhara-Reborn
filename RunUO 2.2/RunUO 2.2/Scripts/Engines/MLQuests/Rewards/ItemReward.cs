using System;
using System.Collections.Generic;
using System.Text;
using Server.Engines.MLQuests.Items;
using Server.Mobiles;

namespace Server.Engines.MLQuests.Rewards
{
	public class ItemReward : BaseReward
	{
/////////////////////////////// Regular Experience Check
		public static readonly ItemReward MLExperienceCheck500 = new ItemReward( "A check for 500 xp", typeof( MLExperienceCheck500 ) );
		public static readonly ItemReward MLExperienceCheck1000 = new ItemReward( "A check for 1000 xp", typeof( MLExperienceCheck1000 ) );
		public static readonly ItemReward MLExperienceCheck1500 = new ItemReward( "A check for 1500 xp", typeof( MLExperienceCheck1500 ) );
		public static readonly ItemReward MLExperienceCheck2000 = new ItemReward( "A check for 2000 xp", typeof( MLExperienceCheck2000 ) );

/////////////////////////////// Spanish Experience Check
		public static readonly ItemReward SpanishMLExperienceCheck1500 = new ItemReward( "Un cheque por 1500 manos", typeof( SpanishMLExperienceCheck1500 ) );

/////////////////////////////// Backwards Experience Check
		public static readonly ItemReward BackwardsMLExperienceCheck1500 = new ItemReward( "px 0051 rof kcehc A", typeof( BackwardsMLExperienceCheck1500 ) );

/////////////////////////////// Regular Quest Completion Deed
		public static readonly ItemReward MLQuestCompletionDeed = new ItemReward( "A quest completion deed", typeof( MLQuestCompletionDeed ) );

/////////////////////////////// Spanish Quest Completion Deed
		public static readonly ItemReward SpanishMLQuestCompletionDeed = new ItemReward( "Una escritura de culminacion de la busqueda", typeof( SpanishMLQuestCompletionDeed ) );

/////////////////////////////// Backwards Quest Completion Deed
		public static readonly ItemReward deeDnoitelpmoCtseuQLM = new ItemReward( "deed noitelpmoc tseuq A", typeof( MLQuestCompletionDeed ) );

/////////////////////////////// Regular Bag of Treasure
		public static readonly ItemReward SmallBagOfTreasure = new ItemReward( "A small bag of treasure", typeof( SmallBagOfTreasure ) );
		public static readonly ItemReward MediumBagOfTreasure = new ItemReward( "A medium bag of treasure", typeof( MediumBagOfTreasure ) );
		public static readonly ItemReward LargeBagOfTreasure = new ItemReward( "A large bag of treasure", typeof( LargeBagOfTreasure ) );

/////////////////////////////// Spanish Bag of Treasure
		public static readonly ItemReward GranBolsaDeBillones = new ItemReward( "Una gran bolsa de billones", typeof( GranBolsaDeBillones ) );

/////////////////////////////// Backwards Bag of Treasure
		public static readonly ItemReward erusaerTfOgaBegraL = new ItemReward( "erusaert fo gab egral A", typeof( erusaerTfOgaBegraL ) );

		public static readonly ItemReward BannerBag = new ItemReward( "a bag with a random banner", typeof( BannerBag ) );
		public static readonly ItemReward BeachBeetleBracelet = new ItemReward( "Beach Beetle Bracelet", typeof( BeachBeetleBracelet ) );
		public static readonly ItemReward FharlunesBow = new ItemReward( "Fharlune's Bow", typeof( FharlunesBow ) );
		public static readonly ItemReward MagicEnchantedShovel = new ItemReward( "Magic Enchanted Shovel", typeof( MagicEnchantedShovel ) );
		public static readonly ItemReward OrcishForge = new ItemReward( "Orcish Forge", typeof( OrcishForge ) );
		public static readonly ItemReward SerpentineJadeRingmailGloves = new ItemReward( "Serpentine Jade Ringmail Gloves", typeof( SerpentineJadeRingmailGloves ) );
		public static readonly ItemReward SerpentineJadeRingmailLeggings = new ItemReward( "Serpentine Jade Ringmail Leggings", typeof( SerpentineJadeRingmailLeggings ) );
		public static readonly ItemReward SerpentineJadeRingmailSleeves = new ItemReward( "Serpentine Jade Ringmail Sleeves", typeof( SerpentineJadeRingmailSleeves ) );
		public static readonly ItemReward SerpentineJadeRingmailTunic = new ItemReward( "Serpentine Jade Ringmail Tunic", typeof( SerpentineJadeRingmailTunic ) );
		public static readonly ItemReward SpidersilkCloakOfProtection = new ItemReward( "Spidersilk Cloak Of Protection", typeof( SpidersilkCloakOfProtection ) );

		private Type m_Type;
		private int m_Amount;

		public ItemReward() : this( null, null )
		{
		}

		public ItemReward( TextDefinition name, Type type ) : this( name, type, 1 )
		{
		}

		public ItemReward( TextDefinition name, Type type, int amount ) : base( name )
		{
			m_Type = type;
			m_Amount = amount;
		}

		public virtual Item CreateItem()
		{
			Item spawnedItem = null;

			try
			{
				spawnedItem = Activator.CreateInstance( m_Type ) as Item;
			}
			catch ( Exception e )
			{
				if ( MLQuestSystem.Debug )
					Console.WriteLine( "WARNING: ItemReward.CreateItem failed for {0}: {1}", m_Type, e );
			}

			return spawnedItem;
		}

		public override void AddRewardItems( PlayerMobile pm, List<Item> rewards )
		{
			Item reward = CreateItem();

			if ( reward == null )
				return;

			if ( reward.Stackable )
			{
				if ( m_Amount > 1 )
					reward.Amount = m_Amount;

				rewards.Add( reward );
			}
			else
			{
				for ( int i = 0; i < m_Amount; ++i )
				{
					rewards.Add( reward );

					if ( i < m_Amount - 1 )
					{
						reward = CreateItem();

						if ( reward == null )
							return;
					}
				}
			}
		}
	}
}
