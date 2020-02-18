using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Regions;

namespace Server.Items
{
	public class QuestTimerBlueBastards : Item
	{
                private TimeSpan m_LifeSpan;
 
                [CommandProperty(AccessLevel.GameMaster)]
                public TimeSpan LifeSpan
                {
                        get { return m_LifeSpan; }
                        set { m_LifeSpan = value; }
                }
 
                private DateTime m_CreationTime;
 
                [CommandProperty(AccessLevel.GameMaster)]
                public DateTime CreationTime
                {
                        get { return m_CreationTime; }
                        set { m_CreationTime = value; }
                }
 
                private Timer m_Timer;

                public virtual void Expire( Mobile parent )
                {
                        if ( parent != null )
                            parent.SendMessage( 38, "Time's up Bitch!");
                        Effects.PlaySound( GetWorldLocation(), Map, 0x201 );
 
                        this.Delete();
                }
 
                public override void OnDelete()
                {
                        if (m_Timer != null)
                            m_Timer.Stop();
 
                        base.OnDelete();
                }
 
                public virtual void CheckExpiry()
                {
                        if ( ( m_CreationTime + m_LifeSpan ) < DateTime.Now )
                            Expire( RootParent as Mobile );
                        else
                            InvalidateProperties();
                }

                [Constructable]
                public QuestTimerBlueBastards( int lifeSpan ) : this( TimeSpan.FromMinutes( lifeSpan ) )
                {
                }

		[Constructable]
		public QuestTimerBlueBastards( TimeSpan lifeSpan )
		{
			Name = "Quest Timer";
                        ItemID = 0x104B;
                        Movable = false;
			LootType = LootType.Blessed;

                        m_CreationTime = DateTime.Now;
                        m_LifeSpan = lifeSpan;
 
                        m_Timer = Timer.DelayCall( TimeSpan.FromMinutes( 30 ), TimeSpan.FromMinutes( 30 ), new TimerCallback( CheckExpiry ) );
		}

		public QuestTimerBlueBastards( Serial serial ) : base( serial )
		{
		}

		// this controls the list you see when you mouse-over the item
		public override void AddNameProperty( ObjectPropertyList list )
		{
			// make sure the normal mouse-over props show up
			base.AddNameProperty( list );

			// initial variables for use only inside the property list
			TimeSpan timetouse = ( ( m_CreationTime + m_LifeSpan ) - DateTime.Now );
			string lisths;

			// determine the info the timer display shows
			if ( timetouse.Minutes > 0 )
			{
				int min = timetouse.Minutes;
				lisths = String.Format( "{0} minutes.", min.ToString() );
			}
			else if ( timetouse.Seconds > 0 )
			{
				int sec = timetouse.Seconds;
				lisths = String.Format( "{0} seconds.", sec.ToString() );
			}
			else
			{
				lisths = ( "<BASEFONT COLOR=#00FF00>Dormant<BASEFONT COLOR=#FFFFFF>" ); //FFFFFF
			}

			// adding the timer to the property list
			list.Add( "<BASEFONT COLOR=#00FF00>Time Remaining: {0}<BASEFONT COLOR=#FFFFFF>", lisths ); //FFFFFF

			// because we do not want the server spamming updates, slow down how fast the mouse-over info refreshes
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerCallback( InvalidateProperties ) );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
                        writer.Write( m_LifeSpan );
                        writer.Write( m_CreationTime );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt(); 

                        m_LifeSpan = reader.ReadTimeSpan();
                        m_CreationTime = reader.ReadDateTime();

                        m_Timer = Timer.DelayCall( TimeSpan.FromMinutes( 30 ), TimeSpan.FromMinutes( 30 ), new TimerCallback( CheckExpiry ) );
		}
	}
}