using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network; 
using Server.Spells;
using Server.Targeting;
using Server.Engines.Quests;
using Server.Engines.Quests.StaffOfFlyingMonkeys;
using Server.Engines.Quests.StolenNecklace;

namespace Server.Items
{
	public class BoulderTunnelBarrier : Item
	{
		[Constructable]
		public BoulderTunnelBarrier() : base( 0x3967 )
		{
			Movable = false;
			Visible = false;
		}
 
		public override bool OnMoveOver( Mobile m )
		{
			if ( m is BaseCreature )
				m = ((BaseCreature)m).ControlMaster;

			PlayerMobile player  = m as PlayerMobile;

			if ( player != null )
			{
		                QuestSystem qs = player.Quest;

			        bool sendMessage = m.Player;

		                if ( qs is StaffOfFlyingMonkeysQuest )
		                {  
                                        if ( qs.IsObjectiveInProgress( typeof( EscapeObjective ) ) )
			                {
        	                                m.SendMessage("You cannot enter during this portion of the questline.");

			                        return false;
                                        }
                                }
		                else if ( qs is StolenNecklaceQuest )
		                {
                                        if ( qs.IsObjectiveInProgress( typeof( ReturnStolenNecklaceObjective ) ) )
			                {
        	                                m.SendMessage("You cannot enter during this portion of the questline.");

			                        return false;
                                        }
                                }
                        }

			return true;
		}

		public BoulderTunnelBarrier( Serial serial ) : base( serial )
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
}