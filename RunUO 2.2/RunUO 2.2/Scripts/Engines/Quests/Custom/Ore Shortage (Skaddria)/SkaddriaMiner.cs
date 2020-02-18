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

namespace Server.Engines.Quests.OreShortageSkaddria
{ 
	public class SkaddriaMiner : BaseQuester
	{ 
		public override bool IsActiveVendor{ get{ return true; } }

		[Constructable]
		public SkaddriaMiner() : base( "(Ore Shortage - Skaddria)" )
		{
		}

		public SkaddriaMiner( Serial serial ) : base( serial )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBSkaddriaMiner() );
		}

		public override void InitOutfit()
		{
			Name = "Lewis Townsend the miner";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33770;
                        HairItemID = 8260;
                        HairHue = 1102;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			SetStr( 71 );
			SetDex( 43 );
			SetInt( 9 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Mining, 65.0, 88.0 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );
			SetSkill( SkillName.Swords, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );

			PackGold( 5, 10 );

			AddItem( new Shirt(848) );
			AddItem( new Kilt(33) );
			AddItem( new Shoes() );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Movable = true;
			AddItem( gloves );

			Pickaxe weapon = new Pickaxe();
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

                }

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );

			QuestSystem qs = player.Quest;

			if ( qs is OreShortageSkaddriaQuest )
			{
				if ( qs.IsObjectiveInProgress( typeof( GatherIngotsObjective ) ) )
				{
					qs.AddConversation( new GatherIngotsConversation() );
                        }
			}
			else
			{
				OreShortageSkaddriaQuest newQuest = new OreShortageSkaddriaQuest( player );
				bool inRestartPeriod = false;

				if ( qs != null )
				{
					if ( contextMenu )
						player.SendMessage("I understand that you're eager but perhaps you might outta finish that there quest you started earlier!");
				}
				else if ( QuestSystem.CanOfferQuest( player, typeof( OreShortageSkaddriaQuest ), out inRestartPeriod ) )
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

				if ( qs is OreShortageSkaddriaQuest )
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

	public class SBSkaddriaMiner : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSkaddriaMiner()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Pickaxe ), 100, 999, 0xE86, 0 ) );
				Add( new GenericBuyInfo( typeof( Shovel ), 100, 999, 0xF39, 0 ) );
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
