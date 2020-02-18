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

namespace Server.Engines.Quests.OreShortageElmhaven
{ 
	public class ElmhavenMiner : BaseQuester
	{ 
		public override bool IsActiveVendor{ get{ return true; } }

		[Constructable]
		public ElmhavenMiner() : base( "(Ore Shortage - Elmhaven)" ) 
		{ 
		} 

		public ElmhavenMiner( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenMiner() ); 
		} 

		public override void InitOutfit()
		{
			Name = "Lynis the miner";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33770;
                        HairItemID = 8251;
                        HairHue = 1132;
                        FacialHairItemID = 8267;
                        FacialHairHue = 1132;

			SetStr( 157 );
			SetDex( 102 );
			SetInt( 44 );

			SetSkill( SkillName.Anatomy, 59.5, 68.7 );
			SetSkill( SkillName.ArmsLore, 64.0, 100.0 );
			SetSkill( SkillName.Fencing, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );

			PackGold( 17, 34 );

			AddItem( new BodySash(913) );
			AddItem( new FancyShirt(808) );
			AddItem( new ShortPants(808) );
			AddItem( new ThighBoots(893) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 2412;
			gloves.Movable = true;
			AddItem( gloves );

                }

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );

			QuestSystem qs = player.Quest;

			if ( qs is OreShortageElmhavenQuest )
			{
				if ( qs.IsObjectiveInProgress( typeof( GatherIngotsObjective ) ) )
				{
					qs.AddConversation( new GatherIngotsConversation() );
                        }
			}
			else
			{
				OreShortageElmhavenQuest newQuest = new OreShortageElmhavenQuest( player );
				bool inRestartPeriod = false;

				if ( qs != null )
				{
					if ( contextMenu )
						player.SendMessage("I understand that you're eager but perhaps you might outta finish that there quest you started earlier!");
				}
				else if ( QuestSystem.CanOfferQuest( player, typeof( OreShortageElmhavenQuest ), out inRestartPeriod ) )
				{
					newQuest.SendOffer();
				}
				else if ( inRestartPeriod && contextMenu )
				{
					player.SendMessage("The shop is doing fine right now so there's nothing else I need from you. Try coming back tomorrow.");
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{			
			PlayerMobile player = from as PlayerMobile;

			if ( player != null )
			{
				QuestSystem qs = player.Quest;

				if ( qs is OreShortageElmhavenQuest )
				{
					if ( dropped is DullCopperIngot )
					{
                                             if(dropped.Amount<=98)
							{
					                        player.SendMessage("This is not enough.");
                                                                return false;
							}		
                                             else if(dropped.Amount!=99) //Technically it requires 100
                                             {
								dropped.Delete();	
					                        qs.AddConversation( new Reward100Conversation() );
					                player.AddToBackpack( new SkillSlotDeedQuestReward() );
					                player.AddToBackpack( new WeightIncreaseDeed() );
								player.AddToBackpack( new ThreeGoldBars() );	
								player.AddToBackpack( new RubyPickaxe() );
								player.AddToBackpack( new SkillSlotDeedQuestReward() );
						                player.AddToBackpack( new WeightIncreaseDeed() );	
				                                PlaySound( 1090 );
                                                                return true;
                                             }

					}

					else if ( dropped is ShadowIronIngot )
					{
                                          if(dropped.Amount<=98)
							{
					                        player.SendMessage("This is not enough.");
                                                                return false;
							}		
                                          else if(dropped.Amount!=99) //Technically it requires 100
                                             {
								dropped.Delete();	
					                        qs.AddConversation( new Reward200Conversation() );
					                player.AddToBackpack( new SkillSlotDeedQuestReward() );
					                player.AddToBackpack( new WeightIncreaseDeed() );
								player.AddToBackpack( new ThreeGoldBars() );	
								player.AddToBackpack( new OneGoldBar() );	
								player.AddToBackpack( new EmeraldPickaxe() );	
								player.AddToBackpack( new SkillSlotDeedQuestReward() );
						                player.AddToBackpack( new WeightIncreaseDeed() );	
				                                PlaySound( 1049 );
                                                return true;
                                             }

					}

					else if ( dropped is CopperIngot )
					{
                                          if(dropped.Amount<=98)
							{
					                  player.SendMessage("This is not enough.");
                                                return false;
							}		
                                          else if(dropped.Amount!=99) //Technically it requires 100
                                             {
								dropped.Delete();	
					                        qs.AddConversation( new Reward300Conversation() );
					                player.AddToBackpack( new SkillSlotDeedQuestReward() );
					                player.AddToBackpack( new WeightIncreaseDeed() );
								player.AddToBackpack( new FiveGoldBars() );	
								player.AddToBackpack( new DiamondPickaxe() );
								player.AddToBackpack( new SkillSlotDeedQuestReward() );	
						                player.AddToBackpack( new WeightIncreaseDeed() );	
				                                PlaySound( 1085 );
                                                return true;
                                             }
					}

					else if ( dropped is BronzeIngot )
					{
                                          if(dropped.Amount<=98)
							{
					                  player.SendMessage("This is not enough.");
                                                return false;
							}		
                                          else if(dropped.Amount!=99) //Technically it requires 100
                                             {
								dropped.Delete();	
					                        qs.AddConversation( new Reward400Conversation() );
					                player.AddToBackpack( new SkillSlotDeedQuestReward() );
					                player.AddToBackpack( new WeightIncreaseDeed() );
								player.AddToBackpack( new FiveGoldBars() );
								player.AddToBackpack( new FiveGoldBars() );	
								player.AddToBackpack( new DiamondPickaxe() );
								player.AddToBackpack( new DiamondPickaxe() );
								player.AddToBackpack( new SkillSlotDeedQuestReward() );
						                player.AddToBackpack( new WeightIncreaseDeed() );		
				                                PlaySound( 1054 );
                                                                return true;
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

	public class SBElmhavenMiner: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBElmhavenMiner() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{
				Add( new GenericBuyInfo( "Jacobs Pickaxe", typeof( JacobsPickaxe ), 500, 300, 0xE86, 0 ) );

				Add( new GenericBuyInfo( typeof( Pickaxe ), 100, 900, 0xE86, 0 ) );
				Add( new GenericBuyInfo( typeof( Shovel ), 100, 950, 0xF39, 0 ) );

				Add( new GenericBuyInfo( typeof( SturdyPickaxe ), 300, 800, 0xE86, 0x973 ) );
				Add( new GenericBuyInfo( typeof( SturdyShovel ), 300, 850, 0xF39, 0x973 ) );

				Add( new GenericBuyInfo( "Miner's Ingot Pouch", typeof( MinersIngotPouch ), 5000, 500, 0xE79, 0 ) );
				Add( new GenericBuyInfo( typeof( Pouch ), 25, 250, 0xE79, 0 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
			} 
		} 
	} 
}
