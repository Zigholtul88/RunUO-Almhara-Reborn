using System;
using Server;
using Server.Multis;
using Server.Gumps;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class BaseGrandfatherClock : Item
	{
		
		private bool m_Sound = true;
		
		private static DateTime m_ServerStart;

		public static DateTime ServerStart
		{
			get{ return m_ServerStart; }
		}

		public static void Initialize()
		{
			m_ServerStart = DateTime.Now;
		}

		public BaseGrandfatherClock( int itemID ) : base( itemID )
		{
		}
		
		public virtual bool PlaySound { get { return m_Sound; } set { m_Sound = value; } }
		

		public BaseGrandfatherClock( Serial serial ) : base( serial )
		{
		}
		
		public const double SecondsPerUOMinute = 5.0;
		public const double MinutesPerUODay = SecondsPerUOMinute * 24;

		private static DateTime WorldStart = new DateTime( 1997, 9, 1 );

		public static void GetTime( Map map, int x, int y, out int hours, out int minutes )
		{
			int totalMinutes;

			GetTime( map, x, y, out hours, out minutes, out totalMinutes );
		}

		public static void GetTime( Map map, int x, int y, out int hours, out int minutes, out int totalMinutes )
		{
			TimeSpan timeSpan = DateTime.UtcNow - WorldStart;

			totalMinutes = (int)(timeSpan.TotalSeconds / SecondsPerUOMinute);

			if ( map != null )
				totalMinutes += map.MapIndex * 320;

			// Really on OSI this must be by subserver
			totalMinutes += x / 16;

			hours = (totalMinutes / 60) % 24;
			minutes = totalMinutes % 60;
		}

		public static void GetTime( out int generalNumber, out string exactTime )
		{
			GetTime( null, 0, 0, out generalNumber, out exactTime );
		}

		public static void GetTime( Mobile from, out int generalNumber, out string exactTime )
		{
			GetTime( from.Map, from.X, from.Y, out generalNumber, out exactTime );
		}

		public static void GetTime( Map map, int x, int y, out int generalNumber, out string exactTime )
		{
			int hours, minutes;

			GetTime( map, x, y, out hours, out minutes );

			// 00:00 AM - 00:59 AM : Witching hour
			// 01:00 AM - 03:59 AM : Middle of night
			// 04:00 AM - 07:59 AM : Early morning
			// 08:00 AM - 11:59 AM : Late morning
			// 12:00 PM - 12:59 PM : Noon
			// 01:00 PM - 03:59 PM : Afternoon
			// 04:00 PM - 07:59 PM : Early evening
			// 08:00 PM - 11:59 AM : Late at night

			if ( hours >= 20 )
				generalNumber = 1042957; // It's late at night
				
			else if ( hours >= 16 )
				generalNumber = 1042956; // It's early in the evening
				
			else if ( hours >= 13 )
				generalNumber = 1042955; // It's the afternoon
				
			else if ( hours >= 12 )
				generalNumber = 1042954; // It's around noon
				
			else if ( hours >= 08 )
				generalNumber = 1042953; // It's late in the morning
				
			else if ( hours >= 04 )
				generalNumber = 1042952; // It's early in the morning
				
			else if ( hours >= 01 )
				generalNumber = 1042951; // It's the middle of the night
				
			else 
				generalNumber = 1042950; // 'Tis the witching hour. 12 Midnight.
				

			hours %= 12;

			if ( hours == 0 )
				hours = 12;

			exactTime = String.Format( "{0}:{1:D2}", hours, minutes );
		
		}
		
		public override void OnDoubleClick( Mobile m )
		{
			int genericNumber;
			string exactTime;
			int hours, minutes;
			
			Server.Items.Clock.GetTime( m.Map, m.X, m.Y, out hours, out minutes );

			GetTime( m, out genericNumber, out exactTime );

			SendLocalizedMessageTo( m, genericNumber );
			SendLocalizedMessageTo( m, 1042958, exactTime ); // ~1_TIME~ to be exact
			
			if ( hours == 12 && minutes == 0 || hours == 0 && minutes == 0)
				{
				
				Effects.PlaySound(m.Location, m.Map, 0x4D2);
				
				}
				else 
				{
	
				Effects.PlaySound(m.Location, m.Map, 0x4D3);
			
				}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			
			writer.Write( m_Sound );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Sound = reader.ReadBool();
					break;
				}
			}
		}
	}
}

	