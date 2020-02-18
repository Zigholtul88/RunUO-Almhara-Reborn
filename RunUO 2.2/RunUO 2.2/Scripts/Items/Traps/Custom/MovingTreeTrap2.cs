using System;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.Spells;
using Server.Mobiles;

namespace Server.Items
{
	public class MovingTreeTrap2 : Item
	{
	
		private int mYa;
		private Timer m_XPlus;
		private Timer m_XMinus;
		private Timer m_RecordLocationTimer;
	
		[CommandProperty(AccessLevel.GameMaster)]
		public int Ya
		{
			get { return mYa; }
			set { mYa = value; }
		}
	
		[Constructable]
		public MovingTreeTrap2() : base( )
		{
			Weight = 100.0;
			Name = "Moving Tree Trap";
			ItemID = 14459;
			
			this.m_RecordLocationTimer = new RecordLocationTimer (this);
			this.m_RecordLocationTimer.Start();
		}
		
		public MovingTreeTrap2( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			
			writer.Write(mYa);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			LootType = LootType.Blessed;

			int version = reader.ReadInt();
			
			mYa = reader.ReadInt();
			
			this.m_XMinus = new XMinus (this);
			this.m_XMinus.Start();
		}
		
///////////////////////		
		private class RecordLocationTimer  : Timer
		{
			private MovingTreeTrap2 m_MovingTreeTrap2;
			
		
			public RecordLocationTimer ( MovingTreeTrap2 trap ) : base( TimeSpan.Zero )
			{
				m_MovingTreeTrap2 = trap;
			}
			
			public void RecordLocation()
			{
				Point3D loc = m_MovingTreeTrap2.GetWorldLocation();
				m_MovingTreeTrap2.Ya = loc.Y;
			}

			protected override void OnTick()
			{
				RecordLocation();
				Stop();
				
				m_MovingTreeTrap2.m_XPlus = new XPlus (m_MovingTreeTrap2);
				m_MovingTreeTrap2.m_XPlus.Start();
			}
		}
		
	///////////////////
		private class XPlus  : Timer
		{
			private MovingTreeTrap2 m_MovingTreeTrap2;
			
			public XPlus ( MovingTreeTrap2 trap ) : base( TimeSpan.FromSeconds( 0.1 ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_MovingTreeTrap2 = trap;
				
			}
	
			protected override void OnTick()
			{
				
				if( (m_MovingTreeTrap2.Ya + 5) > m_MovingTreeTrap2.Y )
					{
						m_MovingTreeTrap2.Y++;
						
						List<Mobile> list = new List<Mobile>();
						foreach( Mobile mob in m_MovingTreeTrap2.GetMobilesInRange( 1 ) ) 
						{
							Point3D traploc = m_MovingTreeTrap2.GetWorldLocation();
							//Point3D mobloc = mob.Y();
							if( ( mob.Y == ( m_MovingTreeTrap2.Y + 1 ) & mob.X == m_MovingTreeTrap2.X || mob.Y == ( m_MovingTreeTrap2.Y - 1 ) & mob.X == m_MovingTreeTrap2.X ) & mob.Alive )
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
					m_MovingTreeTrap2.m_XMinus = new XMinus (m_MovingTreeTrap2);
					m_MovingTreeTrap2.m_XMinus.Start();
				}
				
			}
		}
		
	///////////////////////////////
		private class XMinus  : Timer
		{
			private MovingTreeTrap2 m_MovingTreeTrap2;

			public XMinus ( MovingTreeTrap2 trap ) : base( TimeSpan.FromSeconds( 0.1 ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_MovingTreeTrap2 = trap;
			}
			
			protected override void OnTick()
			{
				if( (m_MovingTreeTrap2.Ya - 5) < m_MovingTreeTrap2.Y )
					{
						m_MovingTreeTrap2.Y--;
						
						List<Mobile> list = new List<Mobile>();
						foreach( Mobile mob in m_MovingTreeTrap2.GetMobilesInRange( 1 ) ) 
						{
							Point3D traploc = m_MovingTreeTrap2.GetWorldLocation();
							//Point3D mobloc = mob.Location();
							if( ( mob.Y == ( m_MovingTreeTrap2.Y + 1 ) & mob.X == m_MovingTreeTrap2.X || mob.Y == ( m_MovingTreeTrap2.Y - 1 ) & mob.X == m_MovingTreeTrap2.X ) & mob.Alive )
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
					m_MovingTreeTrap2.m_XPlus = new XPlus (m_MovingTreeTrap2);
					m_MovingTreeTrap2.m_XPlus.Start();
				}
				
			}
		}	// end of XMinus Timer
		
	}	// end of class MovingTreeTrap2
}	// end of namespace
