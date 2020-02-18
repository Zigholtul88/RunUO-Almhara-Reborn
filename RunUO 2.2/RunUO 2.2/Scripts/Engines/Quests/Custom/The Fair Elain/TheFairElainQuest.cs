using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests.TheFairElain
{
	public class TheFairElainQuest : QuestSystem
	{
		private static Type[] m_TypeReferenceTable = new Type[]
			{
				typeof( TheFairElain.DeclineConversation ),
				typeof( TheFairElain.AcceptConversation ),
				typeof( TheFairElain.SeekVacarJamesObjective ),
				typeof( TheFairElain.DuringSeekVacarJamesConversation ),
				typeof( TheFairElain.VacarJamesConversation ),
				typeof( TheFairElain.SeekErikSullivanObjective ),
				typeof( TheFairElain.DuringSeekErikSullivanConversation ),
				typeof( TheFairElain.ErikSullivanConversation ),
				typeof( TheFairElain.SeekAndoraObjective ),
				typeof( TheFairElain.DuringSeekAndoraConversation ),
				typeof( TheFairElain.AndoraConversation ),
				typeof( TheFairElain.SeekAcarasObjective ),
				typeof( TheFairElain.DuringSeekAcarasConversation ),
				typeof( TheFairElain.AcarasConversation ),
				typeof( TheFairElain.BringAcarasRobeObjective ),
				typeof( TheFairElain.DuringBringAcarasRobeConversation ),
				typeof( TheFairElain.AcarasEndConversation ),
				typeof( TheFairElain.BringRingToAndoraObjective ),
				typeof( TheFairElain.DuringBringRingToAndoraAcaraConversation ),
				typeof( TheFairElain.AndorasEndConversation ),
				typeof( TheFairElain.BringBookToVacarObjective ),
				typeof( TheFairElain.DuringBringBookToVacarAndoraConversation ),
				typeof( TheFairElain.VacarJamesEndConversation ),
				typeof( TheFairElain.DuringBringLetterVacarConversation ),
				typeof( TheFairElain.ErikSullivanEndConversation ),
				typeof( TheFairElain.AlecsanderEndConversation )
			};

		public override Type[] TypeReferenceTable{ get{ return m_TypeReferenceTable; } }

		public override object Name
		{
			get
			{
				return "The Fair Elain!";
			}
		}

		public override object OfferMessage
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>*You see a young man who seems to have mistaken you for someone else.*</BASEFONT COLOR></I><BR><BR>Oh! Oh. You're not Elain. No, 'tis alright. I need a love letter from the great poet, Vacar James, to win the heart of my fair Elain.<BR><BR>If you bring me a love letter written by the poet, I'll hand over an item that's been in my family for generations.<BR><BR><I><BASEFONT COLOR=#0099FF>Proceed?</BASEFONT COLOR></I><BR><BR>";	
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.FromMinutes( 525600.0 ); } }
		public override bool IsTutorial{ get{ return false; } }

		public override int Picture{ get{ return 0x15CF; } }

		public TheFairElainQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public TheFairElainQuest()
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
	}
}