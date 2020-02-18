using System;
using System.Collections;
using System.Xml;
using Server;
using Server.Network;

namespace Server.Regions
{
	public class DungeonEntranceRegion : BaseRegion
	{
                private Hashtable m_Table;
		public DungeonEntranceRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
		}

                public virtual int EnterMessage
                {
                      get
                      {
                          return 0;
                      }
                }
                public virtual int EnterSound
                {
                      get
                      {
                          return 0;
                      }
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

                public override void OnEnter(Mobile m)
                {
                      base.OnEnter(m);
		                     
                      if (m.Player && m.Alive && m.AccessLevel == AccessLevel.Player )
                      {
                          if (this.EnterSound > 0)
                              m.PlaySound(this.EnterSound);
				
                          if (this.EnterMessage > 0)	
                              m.SendLocalizedMessage(this.EnterMessage); 
				
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
                          this.StopTimer(m);
                }
        }
}