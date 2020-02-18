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

namespace Server.Engines.Quests.LeatherShortageElmhaven
{ 
	public class ElmhavenLeatherWorker : BaseQuester
	{ 
		public override bool IsActiveVendor{ get{ return true; } }

		[Constructable]
		public ElmhavenLeatherWorker() : base( "(Leather Shortage - Elmhaven)" )
		{
		}

		public ElmhavenLeatherWorker( Serial serial ) : base( serial )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBElmhavenLeatherWorker() );
		}

		public override void InitOutfit()
		{
			Name = "Talarah the leather worker";
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 1002;
                        HairItemID = 12236;
                        HairHue = 64;

			SetStr( 134 );
			SetDex( 92 );
			SetInt( 61 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 32, 65 );

			AddItem( new ElvenDarkShirt(773) );
			AddItem( new ElvenPants(783) );
			AddItem( new ElvenBoots(868) );
                }

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );

			QuestSystem qs = player.Quest;

			if ( qs is LeatherShortageElmhavenQuest )
			{
				if ( qs.IsObjectiveInProgress( typeof( GatherLeatherObjective ) ) )
				{
					qs.AddConversation( new GatherLeatherConversation() );
                        }
			}
			else
			{
				LeatherShortageElmhavenQuest newQuest = new LeatherShortageElmhavenQuest( player );
				bool inRestartPeriod = false;

				if ( qs != null )
				{
					if ( contextMenu )
						player.SendMessage("I understand that you're eager but perhaps you might outta finish that there quest you started earlier!");
				}
				else if ( QuestSystem.CanOfferQuest( player, typeof( LeatherShortageElmhavenQuest ), out inRestartPeriod ) )
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

				if ( qs is LeatherShortageElmhavenQuest )
				{
					if ( dropped is SpinedLeather )
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
							player.AddToBackpack( new SkillSlotDeedQuestReward() );	
						        player.AddToBackpack( new WeightIncreaseDeed() );
                                                        return true;
                                                }
					}
					else if ( dropped is HornedLeather )
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
							player.AddToBackpack( new SkillSlotDeedQuestReward() );	
						        player.AddToBackpack( new WeightIncreaseDeed() );	
                                                        return true;
                                             }
					}
					else if ( dropped is BarbedLeather )
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
							player.AddToBackpack( new SkillSlotDeedQuestReward() );	
						        player.AddToBackpack( new WeightIncreaseDeed() );		
                                                        return true;
                                                }
					}
				}
			}

			return base.OnDragDrop( from, dropped );
		}

                #region repair by LIACS
                public override void OnSpeech(SpeechEventArgs e)
                {
                    if ((e.Speech.ToLower() == "repair"))
                    {
                        BeginRepair(e.Mobile);
                    }
                    else
                    {
                        base.OnSpeech(e);
                    }
                }
                public void BeginRepair(Mobile from)
                {
                    if (Deleted || !from.CheckAlive())
                        return;

                    SayTo(from, "What do you want me to repair?");

                    from.Target = new RepairTarget(this);
                }

                private class RepairTarget : Target
                {
                    private ElmhavenLeatherWorker m_LeatherWorker;

                    public RepairTarget(ElmhavenLeatherWorker leatherworker) : base(12, false, TargetFlags.None)
                    {
                        m_LeatherWorker = leatherworker;
                    }

                    protected override void OnTarget(Mobile from, object targeted)
                    {
                        if (targeted is BaseArmor)
                        {
                            BaseArmor ba = targeted as BaseArmor;
                            Container pack = from.Backpack;
                            int toConsume = 0;
                            toConsume = (ba.MaxHitPoints - ba.HitPoints) * 3; //Adjuct price here by changing 3 to whatever you want.

                            if ((toConsume == 0) && (ba.Resource == CraftResource.RegularLeather || ba.Resource == CraftResource.SpinedLeather || ba.Resource == CraftResource.HornedLeather || ba.Resource == CraftResource.BarbedLeather))
                            {
                                m_LeatherWorker.SayTo(from, "That armor is not damaged.");
                            }
                            else if (ba.Resource == CraftResource.Iron || ba.Resource == CraftResource.DullCopper || ba.Resource == CraftResource.ShadowIron || ba.Resource == CraftResource.Copper || ba.Resource == CraftResource.Bronze || ba.Resource == CraftResource.Gold || ba.Resource == CraftResource.Agapite || ba.Resource == CraftResource.Verite || ba.Resource == CraftResource.Valorite)
                            {
                                m_LeatherWorker.SayTo(from, "I cannot repair that.");
                            }
                            else if ((ba.HitPoints < ba.MaxHitPoints) && (pack.ConsumeTotal(typeof(Gold), toConsume) && (ba.Resource == CraftResource.RegularLeather || ba.Resource == CraftResource.SpinedLeather || ba.Resource == CraftResource.HornedLeather || ba.Resource == CraftResource.BarbedLeather)))
                            {
                                ba.HitPoints = ba.MaxHitPoints;
                                m_LeatherWorker.SayTo(from, "Here is your armor.");
                                from.SendMessage(String.Format("You pay {0}gp.", toConsume));
                            }
                            else
                            {
                                m_LeatherWorker.SayTo(from, "It will cost you {0}gp to have your armor repaired.", toConsume);
                                from.SendMessage("You do not have enough gold.");
                            }
                        }
                    }
                }
                #endregion

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

	public class SBElmhavenLeatherWorker : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElmhavenLeatherWorker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "1041279", typeof( TaxidermyKit ), 5000, 20, 0x1EBA, 0 ) );

			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( TaxidermyKit ), 2500 );

				Add( typeof( Hides ), 2 );
				Add( typeof( SpinedHides ), 4 );
				Add( typeof( HornedHides ), 8 );
				Add( typeof( BarbedHides ), 12 );

				Add( typeof( Leather ), 5 );
				Add( typeof( SpinedLeather ), 10 );
				Add( typeof( HornedLeather ), 15 );
				Add( typeof( BarbedLeather ), 20 );
			}
		}
	}
}
