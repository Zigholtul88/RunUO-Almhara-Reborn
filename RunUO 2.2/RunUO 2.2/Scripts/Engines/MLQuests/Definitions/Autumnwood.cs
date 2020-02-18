using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.ContextMenus;
using Server.Engines.BulkOrders;
using Server.Engines.MLQuests.Objectives;
using Server.Engines.MLQuests.Rewards;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Engines.MLQuests.Definitions
{
	#region Quests

	public class FullMetalForgery : MLQuest
	{
		public FullMetalForgery()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Full Metal Forgery";
			Description = "What do you want! I am in no mood to deal with a mortal such as yourself! Wait a minute, hold on there. I do not wish to fight you. I only want my wedding ring back. I am to be married soon. Can you help me?";
			RefusalMessage = "Foolish mortal! This may be my last chance!";
			InProgressMessage = "Thank you so very much. You see, there is a bully orc brute that has taken the ring I am to give my wife to be, at our wedding. He is much larger than me. I cannot defeat him. There may be more brute reinforcements so I'd recommend bringing a party along.";
			CompletionNotice = "Return the wedding ring to Ordin.";
			CompletionMessage = "Thank you for bringing my wedding ring back. I hope you find your reward useful.";

			Objectives.Add( new CollectObjective( 1, typeof( OFQRing ), "orcish wedding ring" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.OrcishForge );
		}
	}

	public class ResidentWeevil : MLQuest
	{
		public ResidentWeevil()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Resident Weevil";
			Description = "Excuse me, but there's red on you. Nah,I'm just kidding. I do need your help though. I love bugs. Tiny, scurring little abominations that feel quite good running along yee backside after a hard days work. Any way I need for you to find me a big one. Its the legendary Bronze Weevil and despite how extremely rare they are, I've been told that one can be found hidden away deep in Stone Burrow Mines. Actually its not so much you needing to bring me the beetle but rather one of its eggs. That way I can not only raise one of my own, but also to help preserve the legacy of these magnificent creatures from going extinct........ and to have one as my personal bodyguard.";
			RefusalMessage = "Buddy I'm telling you right now. Don't let your dreams remain a dream. Just do it.";
			InProgressMessage = "Once you're inside the mines, the bronze weevil should be not too far off. I hope.";
			CompletionMessage = "Golly Miss Molly! Got Me A Live One! I think I'm gonna name him Boulders Mckinsey or something to that effect. Or Boulders Hemmingway if its a female. What am I doing blabbering on when I should be giving you your reward. Here you go, now take care and good luck.";
			CompletionNotice = "You have collected enough bronze weevil eggs. Return to Muugul in the Autumnwood for your reward.";

			Objectives.Add( new CollectObjective( 1, typeof( BronzeWeevilEgg ), "bronze weevil egg" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck1500 );
			Rewards.Add( ItemReward.LargeBagOfTreasure );
		}
	}

	#endregion

	#region Mobiles

	[QuesterName( "OFQOrc (Autumnwood)" )]
	public class OFQOrc : BaseCreature
	{
		public override bool InitialInnocent{ get{ return true; } }
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074207, // Good day to you friend! Allow me to offer you a fabulous opportunity!  Thrills and adventure await!
				1074209 // Hey, could you help me out with something?
			) );
		}

		[Constructable]
		public OFQOrc(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Ordin Rockbottom the engaged blacksmith - (Full Metal Forgery)";
			Body = 17;
			BaseSoundID = 0x45A;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.ArmsLore, 65.0, 88.0 );
			SetSkill( SkillName.Blacksmith, 90.0, 100.0 );
			SetSkill( SkillName.Macing, 36.0, 68.0 );
			SetSkill( SkillName.Parry, 36.0, 68.0 );

			AddItem( new Shirt( Utility.RandomRedHue() ) );
			AddItem( new LongPants( Utility.RandomBlueHue() ) );
			AddItem( new BodySash( Utility.RandomGreenHue() ) );
			AddItem( new HeavyBoots( Utility.RandomGreenHue() ) );
		}

                public override void OnSpeech(SpeechEventArgs e)
                {
                    if ((e.Speech.ToLower() == "repair"))
                    {
                        BeginRepair (e.Mobile);
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
                    private OFQOrc m_Blacksmith;

                    public RepairTarget(OFQOrc blacksmith): base(12, false, TargetFlags.None)
                    {
                        m_Blacksmith = blacksmith;
                    }

                    protected override void OnTarget(Mobile from, object targeted)
                    {
                        if (targeted is BaseWeapon)
                        {
                            BaseWeapon bw = targeted as BaseWeapon;
                            Container pack = from.Backpack;
                            int toConsume = 0;
                            toConsume = (bw.MaxHitPoints - bw.HitPoints) * 3; //Adjuct price here by changing 3 to whatever you want.

                            if (toConsume == 0)
                            {
                                m_Blacksmith.SayTo(from, "That weapon is not damaged.");
                            }
                            else if ((bw.HitPoints < bw.MaxHitPoints) && (pack.ConsumeTotal(typeof(Gold), toConsume)))
                            {
			        Item a = from.Backpack.FindItemByType( typeof( Gold ) );
			        if ( a != null )

				a.Consume( toConsume );

                                bw.HitPoints = bw.MaxHitPoints;
                                m_Blacksmith.SayTo(from, "Here is your weapon.");
                                from.SendMessage(String.Format("You pay {0}gp.", toConsume));
                                Effects.PlaySound(from.Location, from.Map, 0x2A);
                            }
                            else
                            {
                                m_Blacksmith.SayTo(from, "It will cost you {0}gp to have your weapon repaired.", toConsume);
                                from.SendMessage("You do not have enough gold.");
                            }
                        }

                        if (targeted is BaseArmor)
                        {
                            BaseArmor ba = targeted as BaseArmor;
                            Container pack = from.Backpack;
                            int toConsume = 0;
                            toConsume = (ba.MaxHitPoints - ba.HitPoints) * 3; //Adjuct price here by changing 3 to whatever you want.

                            if ((toConsume == 0) && (ba.Resource == CraftResource.Iron || ba.Resource == CraftResource.DullCopper || ba.Resource == CraftResource.ShadowIron || ba.Resource == CraftResource.Copper || ba.Resource == CraftResource.Bronze || ba.Resource == CraftResource.Gold || ba.Resource == CraftResource.Agapite || ba.Resource == CraftResource.Verite || ba.Resource == CraftResource.Valorite))
                            {
                                m_Blacksmith.SayTo(from, "That armor is not damaged.");
                            }
                            else if (ba.Resource == CraftResource.RegularLeather || ba.Resource == CraftResource.SpinedLeather || ba.Resource == CraftResource.HornedLeather || ba.Resource == CraftResource.BarbedLeather)
                            {
                                m_Blacksmith.SayTo(from, "I cannot repair that.");
                            }
                            else if ((ba.HitPoints < ba.MaxHitPoints) && (pack.ConsumeTotal(typeof(Gold), toConsume) && (ba.Resource == CraftResource.Iron || ba.Resource == CraftResource.DullCopper || ba.Resource == CraftResource.ShadowIron || ba.Resource == CraftResource.Copper || ba.Resource == CraftResource.Bronze || ba.Resource == CraftResource.Gold || ba.Resource == CraftResource.Agapite || ba.Resource == CraftResource.Verite || ba.Resource == CraftResource.Valorite)))
                            {
			        Item a = from.Backpack.FindItemByType( typeof( Gold ) );
			        if ( a != null )

				a.Consume( toConsume );

                                ba.HitPoints = ba.MaxHitPoints;
                                m_Blacksmith.SayTo(from, "Here is your armor.");
                                from.SendMessage(String.Format("You pay {0}gp.", toConsume));
                                Effects.PlaySound(from.Location, from.Map, 0x2A);
                            }
                            else
                            {
                                m_Blacksmith.SayTo(from, "It will cost you {0}gp to have your armor repaired.", toConsume);
                                from.SendMessage("You do not have enough gold.");
                            }                    
                        }
                    }
                }

		public OFQOrc( Serial serial ): base( serial )
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

	[QuesterName( "Muugul (Autumnwood)" )]
	public class Muugul : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074207, // Good day to you friend! Allow me to offer you a fabulous opportunity!  Thrills and adventure await!
				1074209 // Hey, could you help me out with something?
			) );
		}

		[Constructable]
		public Muugul(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Muugul - (Resident Weevil)";
			Race = Race.Human;
			BodyValue = 0x190;
			Female = false;
			Hue = Race.RandomSkinHue();
			InitStats( 100, 100, 25 );

			Utility.AssignRandomHair( this, true );

			SetSkill( SkillName.Meditation, 60.0, 80.0 );
			SetSkill( SkillName.Focus, 60.0, 80.0 );

			AddItem( new HeavyBoots( 0x3B2 ) );
			AddItem( new ReinassanceShirt() );
			AddItem( new Kilt() );

			Item item;

			item = new SilverBracelet();
			item.Hue = 1117;
			AddItem( item );

			item = new SilverNecklace();
			item.Hue = 1117;
			AddItem( item );

			item = new SilverEarrings();
			item.Hue = 1117;
			AddItem( item );
		}

		public Muugul( Serial serial ): base( serial )
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

	#endregion
}