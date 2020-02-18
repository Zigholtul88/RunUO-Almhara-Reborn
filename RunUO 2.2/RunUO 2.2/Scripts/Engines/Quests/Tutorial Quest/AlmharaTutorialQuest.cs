using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.AlmharaTutorial
{
	public class AlmharaTutorialQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( DeclineConversation ),
				typeof( AcceptConversation ),
				typeof( GoToBankConversation ),
				typeof( GoToBankObjective ),
				typeof( RadarConversation ),
				typeof( GoUpToBankerObjective ),
				typeof( BankInformationConversation ),
				typeof( HowToMoveStuffAroundConversation ),
				typeof( YouGottaEatConversation ),
				typeof( VendorsConversation ),
				typeof( QuestNPCsConversation ),
				typeof( CombatConversation ),
				typeof( EnvironmentalHazardsConversation ),
				typeof( EndConversation )
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "How To Play The Game!";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>As you move further on, you are immediately stopped in your tracks. He turns towards you and offers you a request.</BASEFONT COLOR></I><BR><BR>Howdy partner! If you're new to this setting, then perhaps I can be your handy dandy guide! What do you say?<BR><BR>Do we got a deal or not";				
                        }
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromSeconds( 10.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15CF; } }

		public AlmharaTutorialQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public AlmharaTutorialQuest()
		{
		}

		public override void Accept()
		{
			base.Accept();

			AddConversation( new AcceptConversation() );
		}

		public override void Decline()
		{
			base.Decline();

			AddConversation( new DeclineConversation() );
		}

		private bool m_HasLeftTheArea;

		public override void Slice()
		{
			if ( !m_HasLeftTheArea && ( From.Map != Map.Malas || From.X < 2491 || From.X > 2548 || From.Y < 1969 || From.Y > 2036 ) )
			{
                                // *whistles*
			        From.PlaySound( 1095 );

				m_HasLeftTheArea = true;
				AddConversation( new RadarConversation() );
			}

			base.Slice();
		}

		public override void ChildDeserialize( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();

			m_HasLeftTheArea = reader.ReadBool();
		}

		public override void ChildSerialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 ); // version

			writer.Write( (bool) m_HasLeftTheArea );
		}
	}
}
