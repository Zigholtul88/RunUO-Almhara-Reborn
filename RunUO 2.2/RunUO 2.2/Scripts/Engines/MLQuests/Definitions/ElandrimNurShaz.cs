using System;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Engines.MLQuests.Objectives;
using Server.Engines.MLQuests.Rewards;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Engines.MLQuests.Definitions
{
	#region Quest

	public class TreasureOfTheSands : MLQuest
	{
		public TreasureOfTheSands()
		{
			Activated = true;
			OneTimeOnly = true;
			Title = "Treasure Of The Sands";
			Description = "Welcome to Earthen Treasures. I'm known around these parts as Melinhara Thornburch but you can call me Melon. Or is it Melly? Any way I've been wanting to procure several Gems of the Sands from the wild beetles that roam the beach due south of this establishment in order to finalize my creation. Special bracelets that contain the power of regeneration and magic protection. Once I'm finished with the batch I will then need to deliever them to Cedric Thornforge, who has a penchant for demanding strange items, all at my expense. That snobby, go for nothing weasel. If you can gather at least 10 of these gems then I'll not only have what I need for my next shipment but I will even be so generous in crafting one for you. Now do we have a deal or what?";
			RefusalMessage = "Damn it, can't you help out a sister when she needs some assistance?";
			InProgressMessage = "I know I should be taking this task by myself but I am currently swamped with old back orders that I need to fill out right this moment or else these customers are gonna be pretty upset. So I suggest that you get going.";
			CompletionNotice = "You have collected enough gems. Return to Melinhara over at Elandrim Nur Shaz for your reward.";
			CompletionMessage = "There, now the order is complete and you have in your possession one sexy new bracelet. That's gonna make two people that I've pleasured this night. If you need another one then come back tomorrow where I'm sure I'm gonna need to conjure up another batch because Cedric is really that crazy. Seriously he's been hounding me about this stupid sword that he ordered from Elmhaven. Any way take care.";

			Objectives.Add( new CollectObjective( 10, typeof( GemOfTheSands ), "gem of the sands" ) );

			Rewards.Add( ItemReward.MLQuestCompletionDeed );
			Rewards.Add( ItemReward.MLExperienceCheck500 );
			Rewards.Add( ItemReward.BeachBeetleBracelet );
		}
	}

	#endregion

	#region Mobiles

	[QuesterName( "Melinhara (Elandrim Nur Shaz)" )]
	public class Melinhara : BaseCreature
	{
		public override bool IsInvulnerable { get { return true; } }
		public override bool CanTeach { get { return true; } }

		public override bool CanShout { get { return true; } }
		public override void Shout( PlayerMobile pm )
		{
			MLQuestSystem.Tell( this, pm, Utility.RandomList(
				1074200, // Thank goodness you are here, there’s no time to lose.
				1074206 // Excuse me please traveler, might I have a little of your time?
			) );
		}

		[Constructable]
		public Melinhara(): base( AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2 )
		{
			Name = "Melinhara - (Treasure Of The Sands)";
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 1023;
                        HairItemID = 12241;
                        HairHue = 1113;

			InitStats( 100, 100, 25 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.ItemID, 64.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			AddItem( new FormalDress( 268 ) );
			AddItem( new ElvenBoots( 868 ) );
		}

		public Melinhara( Serial serial ): base( serial )
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