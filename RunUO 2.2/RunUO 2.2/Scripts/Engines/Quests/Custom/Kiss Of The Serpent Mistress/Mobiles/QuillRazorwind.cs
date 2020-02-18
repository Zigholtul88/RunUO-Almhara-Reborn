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
using Server.Engines.Quests;

namespace Server.Engines.Quests.KissOfTheSerpentMistress
{
	public class QuillRazorwind : BaseQuester
	{
		public override bool IsActiveVendor{ get{ return true; } }

		[Constructable]
		public QuillRazorwind() : base( "(Kiss of the Serpent Mistress)" )
		{
		}

		public QuillRazorwind( Serial serial ) : base( serial )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBQuillRazorwind() );
		}

		public override void InitOutfit()
		{
			Name = "Quill Razorwind the fletcher";
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 1002;
                        HairItemID = 12238;
                        HairHue = 63;

			SetStr( 225 );
			SetDex( 265 );
			SetInt( 151 );

			SetSkill( SkillName.Archery, 80.0, 100.0 );
			SetSkill( SkillName.Anatomy, 59.5, 68.7 );
			SetSkill( SkillName.Fletching, 80.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 61.0, 93.0 );

			PackGold( 14, 46 );

			ElvenCompositeLongbow weapon = new ElvenCompositeLongbow();
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

			PackItem( new Arrow( Utility.RandomMinMax( 20, 30 ) ) );

			FemaleLeatherChest chest = new FemaleLeatherChest();
			chest.Movable = true;
                        chest.Hue = 2207;
			AddItem( chest );

			StuddedGorget gorget = new StuddedGorget();
			gorget.Movable = true;
                        gorget.Hue = 2207;
			AddItem( gorget );

			StuddedArms arms = new StuddedArms();
			arms.Movable = true;
                        arms.Hue = 2207;
			AddItem( arms );

			StuddedGloves gloves = new StuddedGloves();
			gloves.Movable = true;
                        gloves.Hue = 2207;
			AddItem( gloves );

			DrowSpiderCloak cloak = new DrowSpiderCloak(); 
			cloak.Movable = true; 
                        cloak.Hue = 663;
			AddItem( cloak ); 

			AddItem( new ThighBoots(663) );
                }

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );

			QuestSystem qs = player.Quest;

			if ( qs is KissOfTheSerpentMistressQuest )
			{
				if ( qs.IsObjectiveInProgress( typeof( SlayCalcifinaObjective ) ) )
				{
					qs.AddConversation( new DuringSlayCalcifinaConversation() );
                                }
			}
			else
			{
				KissOfTheSerpentMistressQuest newQuest = new KissOfTheSerpentMistressQuest( player );
				bool inRestartPeriod = false;

				if ( qs != null )
				{
					if ( contextMenu )
						player.SendMessage("I understand that you're eager but perhaps you might outta finish that there quest you started earlier!");
				}
				else if ( QuestSystem.CanOfferQuest( player, typeof( KissOfTheSerpentMistressQuest ), out inRestartPeriod ) )
				{
					newQuest.SendOffer();
				}
				else if ( inRestartPeriod && contextMenu )
				{
					player.SendMessage("Hopefully she is in a far better place. Devoid of heartaches and despair.");
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{			
			PlayerMobile player = from as PlayerMobile;

			if ( player != null )
			{
				QuestSystem qs = player.Quest;

				if ( qs is KissOfTheSerpentMistressQuest )
				{
					if ( dropped is CalcifinasJournal )
					{
					      qs.AddConversation( new CalcifinasJournalConversation() );
						QuestObjective obj = qs.FindObjective( typeof( ReturnJournalObjective ) );

						if ( obj != null && !obj.Completed )
						{
							dropped.Delete();								

							obj.Complete();
						}				
					}					
					else if ( dropped is SerpentStriker )
					{
						QuestObjective obj = qs.FindObjective( typeof( ReturnBowObjective ) );

						if ( obj != null && !obj.Completed )
						{
							dropped.Delete();								

							obj.Complete();
							player.AddToBackpack( new RazorwindBow() );

					                player.AddToBackpack( new Gold( Utility.RandomMinMax( 5575, 5895 ) ) );

					                player.AddToBackpack( new SkillSlotDeedQuestReward() );
					                player.AddToBackpack( new WeightIncreaseDeed() );
					                player.AddToBackpack( new QuestGoodieBag() );						
						}				
					}
				}
			}

			return base.OnDragDrop( from, dropped );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}

	public class SBQuillRazorwind: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBQuillRazorwind()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
////////////////////////////////////////////////////// Misc
// All tools sell at a base price of 100 gp
				Add( new GenericBuyInfo( typeof( FletcherTools ), 100, 378, 0x1022, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenQuiver ), 100, 20, 0x2FB7, 0 ) );

////////////////////////////////////////////////////// Primary Components
				Add( new GenericBuyInfo( "Iron Ingot", typeof( IronIngot ), 5, 999, 0x1BF2, 0 ) );
				Add( new GenericBuyInfo( "Leather", typeof( Leather ), 5, 999, 0x1081, 0 ) );
				Add( new GenericBuyInfo( "Log", typeof( Log ), 5, 999, 0x1BDD, 0 ) );

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

////////////////////////////////////////////////////// Ammunition
				Add( new GenericBuyInfo( typeof( Arrow ), 8, Utility.Random( 100, 500 ), 0xF3F, 0 ) );
				Add( new GenericBuyInfo( typeof( Arrow ), 8, Utility.Random( 100, 500 ), 0xF3F, 0 ) );
				Add( new GenericBuyInfo( typeof( Arrow ), 8, Utility.Random( 100, 500 ), 0xF3F, 0 ) );
				Add( new GenericBuyInfo( typeof( OakArrow ), 10, Utility.Random( 50, 80 ), 0xF3F, 2010 ) );
				Add( new GenericBuyInfo( typeof( OakArrow ), 10, Utility.Random( 50, 80 ), 0xF3F, 2010 ) );
				Add( new GenericBuyInfo( typeof( YewArrow ), 15, Utility.Random( 50, 80 ), 0xF3F, 1192 ) );
				Add( new GenericBuyInfo( typeof( YewArrow ), 15, Utility.Random( 50, 80 ), 0xF3F, 1192 ) );
				Add( new GenericBuyInfo( typeof( AshArrow ), 20, Utility.Random( 50, 80 ), 0xF3F, 1191 ) );

				Add( new GenericBuyInfo( typeof( Bolt ), 8, Utility.Random( 100, 500 ), 0x1BFB, 0 ) );
				Add( new GenericBuyInfo( typeof( Bolt ), 8, Utility.Random( 100, 500 ), 0x1BFB, 0 ) );
				Add( new GenericBuyInfo( typeof( Bolt ), 8, Utility.Random( 100, 500 ), 0x1BFB, 0 ) );
				Add( new GenericBuyInfo( typeof( DullCopperBolt ), 10, Utility.Random( 50, 100 ), 0x1BFB, 2419 ) );
				Add( new GenericBuyInfo( typeof( DullCopperBolt ), 10, Utility.Random( 50, 100 ), 0x1BFB, 2419 ) );
				Add( new GenericBuyInfo( typeof( ShadowIronBolt ), 15, Utility.Random( 50, 100 ), 0x1BFB, 2406 ) );
				Add( new GenericBuyInfo( typeof( ShadowIronBolt ), 15, Utility.Random( 50, 100 ), 0x1BFB, 2406 ) );
				Add( new GenericBuyInfo( typeof( BronzeBolt ), 20, Utility.Random( 50, 100 ), 0x1BFB, 2418 ) );

				Add( new GenericBuyInfo( typeof( FukiyaDarts ), 8, Utility.Random( 100, 500 ), 0x2806, 0 ) );

////////////////////////////////////////////////////// Weapons
				Add( new GenericBuyInfo( typeof( Fukiya ), 100, 500, 0x27AA, 0 ) );
				Add( new GenericBuyInfo( typeof( Bow ), 100, 500, 0x13B2, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Crossbow ), 100, 500, 0xF50, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Balestra ), 200, 500, 15353, 0 ) ); // Level 5
				Add( new GenericBuyInfo( typeof( ElvenLeafBow ), 200, 500, 15358, 0 ) ); // Level 5
				Add( new GenericBuyInfo( typeof( MagicalShortbow ), 300, 500, 0x2D2B, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( RepeatingCrossbow ), 300, 500, 0x26C3, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( CompositeBow ), 400, 500, 0x26C2, 0 ) ); // Level 20
				Add( new GenericBuyInfo( typeof( EbonyCrossbow ), 400, 500, 15808, 0 ) ); // Level 20
				Add( new GenericBuyInfo( typeof( FireBow ), 500, 500, 15359, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( GrassBow ), 500, 500, 15362, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( IceBow ), 500, 500, 15365, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( LightningBow ), 500, 500, 15368, 0 ) ); // Level 25
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
////////////////////////////////////////////////////// Misc
// (Sell Price = Vendor Price / by 2) 

				Add( typeof( FletcherTools ), 50 );
				Add( typeof( ElvenQuiver ), 50 );

////////////////////////////////////////////////////// Primary Components
// (Sell Price = Harvest component is 5 per cost equal to x amount / by 2 and round up to the nearest 5) 
				Add( typeof( IronIngot ), 3 );
				Add( typeof( Log ), 3 );

////////////////////////////////////////////////////// Components
// (Sell Price = Remains the same as those found on buying menus) 

				Add( typeof( Feather ), 1 );
				Add( typeof( Shaft ), 1 );

////////////////////////////////////////////////////// Ammunition
// (Sell Price = Harvest component is 5 per cost equal to x amount + Secondary component is 1 per cost equal to x amount / by 2) 

				Add( typeof( Arrow ), 4 );
				Add( typeof( Bolt ), 4 );
				Add( typeof( FukiyaDarts ), 4 );
			} 
		} 
	} 
}