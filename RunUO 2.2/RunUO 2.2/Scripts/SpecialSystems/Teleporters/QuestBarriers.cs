using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network; 
using Server.Spells;
using Server.Targeting;

namespace Server.Items
{
	public class QuestBarrier10 : Item
	{
		[Constructable]
		public QuestBarrier10() : base( 0x3967 )
		{
			Movable = false;
			Visible = false;
		}
 
		public override bool OnMoveOver( Mobile m )
		{
			if ( m is BaseCreature )
				m = ((BaseCreature)m).ControlMaster;

			PlayerMobile player = m as PlayerMobile;

			if ( player != null )
			{
			        bool sendMessage = m.Player;

		                if ( player.TotalQuestsDone < 10 )
		                {  
        	                        m.SendMessage("You cannot enter this area until you've completed at least 10 quests.");
			                return false;
                                }
                        }

			return true;
		}

		public QuestBarrier10( Serial serial ) : base( serial )
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

	public class QuestBarrier20 : Item
	{
		[Constructable]
		public QuestBarrier20() : base( 0x3967 )
		{
			Movable = false;
			Visible = false;
		}
 
		public override bool OnMoveOver( Mobile m )
		{
			if ( m is BaseCreature )
				m = ((BaseCreature)m).ControlMaster;

			PlayerMobile player = m as PlayerMobile;

			if ( player != null )
			{
			        bool sendMessage = m.Player;

		                if ( player.TotalQuestsDone < 20 )
		                {  
        	                        m.SendMessage("You cannot enter this area until you've completed at least 20 quests.");
			                return false;
                                }
                        }

			return true;
		}

		public QuestBarrier20( Serial serial ) : base( serial )
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

	public class QuestBarrier30 : Item
	{
		[Constructable]
		public QuestBarrier30() : base( 0x3967 )
		{
			Movable = false;
			Visible = false;
		}
 
		public override bool OnMoveOver( Mobile m )
		{
			if ( m is BaseCreature )
				m = ((BaseCreature)m).ControlMaster;

			PlayerMobile player = m as PlayerMobile;

			if ( player != null )
			{
			        bool sendMessage = m.Player;

		                if ( player.TotalQuestsDone < 30 )
		                {  
        	                        m.SendMessage("You cannot enter this area until you've completed at least 30 quests.");
			                return false;
                                }
                        }

			return true;
		}

		public QuestBarrier30( Serial serial ) : base( serial )
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

	public class QuestBarrier40 : Item
	{
		[Constructable]
		public QuestBarrier40() : base( 0x3967 )
		{
			Movable = false;
			Visible = false;
		}
 
		public override bool OnMoveOver( Mobile m )
		{
			if ( m is BaseCreature )
				m = ((BaseCreature)m).ControlMaster;

			PlayerMobile player = m as PlayerMobile;

			if ( player != null )
			{
			        bool sendMessage = m.Player;

		                if ( player.TotalQuestsDone < 40 )
		                {  
        	                        m.SendMessage("You cannot enter this area until you've completed at least 40 quests.");
			                return false;
                                }
                        }

			return true;
		}

		public QuestBarrier40( Serial serial ) : base( serial )
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

	public class QuestBarrier50 : Item
	{
		[Constructable]
		public QuestBarrier50() : base( 0x3967 )
		{
			Movable = false;
			Visible = false;
		}
 
		public override bool OnMoveOver( Mobile m )
		{
			if ( m is BaseCreature )
				m = ((BaseCreature)m).ControlMaster;

			PlayerMobile player = m as PlayerMobile;

			if ( player != null )
			{
			        bool sendMessage = m.Player;

		                if ( player.TotalQuestsDone < 50 )
		                {  
        	                        m.SendMessage("You cannot enter this area until you've completed at least 50 quests.");
			                return false;
                                }
                        }

			return true;
		}

		public QuestBarrier50( Serial serial ) : base( serial )
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