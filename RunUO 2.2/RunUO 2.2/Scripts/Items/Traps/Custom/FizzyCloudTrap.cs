using System;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.Spells;
using Server.Mobiles;

namespace Server.Items
{
	public class FizzyCloudTrap : Item
	{
	
		private int mXa;
		private Timer m_XPlus;
		private Timer m_XMinus;
		private Timer m_RecordLocationTimer;
	
		[CommandProperty(AccessLevel.GameMaster)]
		public int Xa
		{
			get { return mXa; }
			set { mXa = value; }
		}
	
		[Constructable]
		public FizzyCloudTrap() : base( )
		{
			Weight = 100.0;
			Name = "Moving Trap";
			ItemID = 14508;
			
			this.m_RecordLocationTimer = new RecordLocationTimer (this);
			this.m_RecordLocationTimer.Start();
		}
		
		public FizzyCloudTrap( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			
			writer.Write(mXa);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			LootType = LootType.Blessed;

			int version = reader.ReadInt();
			
			mXa = reader.ReadInt();
			
			this.m_XMinus = new XMinus (this);
			this.m_XMinus.Start();
		}
		
///////////////////////		
		private class RecordLocationTimer  : Timer
		{
			private FizzyCloudTrap m_FizzyCloudTrap;
			
		
			public RecordLocationTimer ( FizzyCloudTrap trap ) : base( TimeSpan.Zero )
			{
				m_FizzyCloudTrap = trap;
			}
			
			public void RecordLocation()
			{
				Point3D loc = m_FizzyCloudTrap.GetWorldLocation();
				m_FizzyCloudTrap.Xa = loc.X;
			}

			protected override void OnTick()
			{
				RecordLocation();
				Stop();
				
				m_FizzyCloudTrap.m_XPlus = new XPlus (m_FizzyCloudTrap);
				m_FizzyCloudTrap.m_XPlus.Start();
			}
		}
		
	///////////////////
		private class XPlus  : Timer
		{
			private FizzyCloudTrap m_FizzyCloudTrap;
			
			public XPlus ( FizzyCloudTrap trap ) : base( TimeSpan.FromSeconds( 0.1 ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_FizzyCloudTrap = trap;
				
			}
	
			protected override void OnTick()
			{
				
				if( (m_FizzyCloudTrap.Xa + 5) > m_FizzyCloudTrap.X )
					{
						m_FizzyCloudTrap.X++;
						
						List<Mobile> list = new List<Mobile>();
						foreach( Mobile mob in m_FizzyCloudTrap.GetMobilesInRange( 1 ) ) 
						{
							Point3D traploc = m_FizzyCloudTrap.GetWorldLocation();
							//Point3D mobloc = mob.X();
							if( ( mob.X == ( m_FizzyCloudTrap.X + 1 ) & mob.Y == m_FizzyCloudTrap.Y || mob.X == ( m_FizzyCloudTrap.X - 1 ) & mob.Y == m_FizzyCloudTrap.Y ) & mob.Alive )
							{
								//if (mob is Mobile & mob.Alive)
								list.Add(mob);
							}
						}
						
						foreach (Mobile mob in list)
						{
							if( mob is PlayerMobile )
							{
								mob.PlaySound(mob.Female ? 0x327 : 0x437);
								mob.Animate(20, 1, 1, true, false, 0);

					                        Spells.SpellHelper.Damage(TimeSpan.FromTicks(1), mob, mob, Utility.RandomMinMax(45, 50));
							}
							else
							{
								BaseCreature bc = (BaseCreature)mob;
								bc.PlaySound(bc.GetAngerSound());
								if (bc.Body.IsAnimal)
								{
									bc.Animate(10, 5, 1, true, false, 0);
					                                Spells.SpellHelper.Damage(TimeSpan.FromTicks(1), mob, mob, Utility.RandomMinMax(0, 0));
								}
								else if (bc.Body.IsMonster)
								{
									bc.Animate(18, 5, 1, true, false, 0);
					                                Spells.SpellHelper.Damage(TimeSpan.FromTicks(1), mob, mob, Utility.RandomMinMax(0, 0));
								}
							}
						}
						
						Start();
						
					}
				else
				{
					Stop();
					m_FizzyCloudTrap.m_XMinus = new XMinus (m_FizzyCloudTrap);
					m_FizzyCloudTrap.m_XMinus.Start();
				}
				
			}
		}
		
	///////////////////////////////
		private class XMinus  : Timer
		{
			private FizzyCloudTrap m_FizzyCloudTrap;

			public XMinus ( FizzyCloudTrap trap ) : base( TimeSpan.FromSeconds( 0.1 ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_FizzyCloudTrap = trap;
			}
			
			protected override void OnTick()
			{
				if( (m_FizzyCloudTrap.Xa - 5) < m_FizzyCloudTrap.X )
					{
						m_FizzyCloudTrap.X--;
						
						List<Mobile> list = new List<Mobile>();
						foreach( Mobile mob in m_FizzyCloudTrap.GetMobilesInRange( 1 ) ) 
						{
							Point3D traploc = m_FizzyCloudTrap.GetWorldLocation();
							//Point3D mobloc = mob.Location();
							if( ( mob.X == ( m_FizzyCloudTrap.X + 1 ) & mob.Y == m_FizzyCloudTrap.Y || mob.X == ( m_FizzyCloudTrap.X - 1 ) & mob.Y == m_FizzyCloudTrap.Y ) & mob.Alive )
							{
								//if (mob is Mobile & mob.Alive)
								list.Add(mob);
							}
						}
						
						foreach (Mobile mob in list)
						{
							if( mob is PlayerMobile )
							{
								mob.PlaySound(mob.Female ? 0x327 : 0x437);
								mob.Animate(20, 1, 1, true, false, 0);

					                        Spells.SpellHelper.Damage(TimeSpan.FromTicks(1), mob, mob, Utility.RandomMinMax(45, 50));
							}
							else
							{
								BaseCreature bc = (BaseCreature)mob;
								bc.PlaySound(bc.GetAngerSound());
								if (bc.Body.IsAnimal)
								{
									bc.Animate(10, 5, 1, true, false, 0);
					                                Spells.SpellHelper.Damage(TimeSpan.FromTicks(1), mob, mob, Utility.RandomMinMax(0, 0));
								}
								else if (bc.Body.IsMonster)
								{
									bc.Animate(18, 5, 1, true, false, 0);
					                                Spells.SpellHelper.Damage(TimeSpan.FromTicks(1), mob, mob, Utility.RandomMinMax(0, 0));
								}
							}
						}
						
						Start();
					}
				else
				{
					Stop();
					m_FizzyCloudTrap.m_XPlus = new XPlus (m_FizzyCloudTrap);
					m_FizzyCloudTrap.m_XPlus.Start();
				}
				
			}
		}	// end of XMinus Timer
		
	}	// end of class MovingTrap
}	// end of namespace
