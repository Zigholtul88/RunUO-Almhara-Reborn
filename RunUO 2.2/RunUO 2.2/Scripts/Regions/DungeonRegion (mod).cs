using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;
using Server.Spells;
using Server.Spells.Third;
using Server.Spells.Fourth;
using Server.Spells.Sixth;
using Server.Spells.Seventh;
using Server.Spells.Chivalry;
using Server.Targeting;

namespace Server.Regions
{
	public class DungeonRegion : BaseRegion
	{
		public override bool YoungProtected { get { return false; } }

		private Point3D m_EntranceLocation;
		private Map m_EntranceMap;

		public Point3D EntranceLocation{ get{ return m_EntranceLocation; } set{ m_EntranceLocation = value; } }
		public Map EntranceMap{ get{ return m_EntranceMap; } set{ m_EntranceMap = value; } }

                private Hashtable m_Table;
		public DungeonRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
			XmlElement entrEl = xml["entrance"];

			Map entrMap = map;
			ReadMap( entrEl, "map", ref entrMap, false );

			if ( ReadPoint3D( entrEl, entrMap, ref m_EntranceLocation, false ) )
				m_EntranceMap = entrMap;
		}

                public virtual TimeSpan DamageInterval
                {
                      get
                      {
                          return TimeSpan.FromSeconds(1);
                      }
                }

                public Hashtable Table
                {
                      get
                      {
                          return this.m_Table;
                      }
                }

                public override void OnEnter( Mobile m )
                {
                       base.OnEnter(m);
		
                       if ( m.Player && m.Alive )
                       {
			       m.Send( Network.PlayMusic.GetInstance( m.Region.Music ) );

                               this.StartTimer(m);
                       }
                }

                public override void OnLocationChanged(Mobile m, Point3D oldLocation)
                {
                      base.OnLocationChanged(m, oldLocation);
			
                      this.StopTimer(m);
			
                      if (m.Player && m.Alive )
                          this.StartTimer(m);
                }

                public override void OnExit(Mobile m)
                {
                      base.OnExit(m);
			
                      this.StopTimer(m);
                }

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return false;
		}

		public override void AlterLightLevel( Mobile m, ref int global, ref int personal )
		{
			global = LightCycle.DungeonLevel;
		}

		public override bool OnBeginSpellCast( Mobile m, ISpell s )
		{
			if ( ( s is GateTravelSpell || s is RecallSpell || s is MarkSpell || s is TeleportSpell || s is SacredJourneySpell ) && m.AccessLevel == AccessLevel.Player )
			{
				m.SendMessage( "Where the fuck do you think you're going? Not in my dungeon! Nigga yo ass is getting some exercise!" );
				return false;
			}
			else
			{
				return base.OnBeginSpellCast( m, s );
			}
		}

                public void StartTimer(Mobile m)
                {
                      if (this.m_Table == null)
                          this.m_Table = new Hashtable();
				
                      this.m_Table[m] = Timer.DelayCall(TimeSpan.Zero, this.DamageInterval, new TimerStateCallback(Damage), m);
                }

                public void StopTimer(Mobile m)
                {
                      if (this.m_Table == null)
                          this.m_Table = new Hashtable();
				
                      if (this.m_Table[m] != null)
                      {
                          Timer timer = (Timer)this.m_Table[m];
				
                          timer.Stop();
                      }
                }

                public void Damage(object state)
                {
                      if (state is Mobile)
                          this.Damage((Mobile)state);			
                }

                public virtual void Damage(Mobile m)
                {
                      if (m.Player && !m.Alive)
                          m.Send( Network.PlayMusic.GetInstance( MusicName.Death ) );
                          this.StopTimer(m);
                }
        }
}