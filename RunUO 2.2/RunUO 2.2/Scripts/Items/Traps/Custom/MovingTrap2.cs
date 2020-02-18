using System;
using Server.Items;
using System.Collections;
using System.Collections.Generic;
using Server.Spells;
using Server.Mobiles;

namespace Server.Items
{
	public class MovingTrap2 : Item
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
		public MovingTrap2() : base( )
		{
			Weight = 100.0;
			//Hue = 1906;
			Name = "Moving Trap";
			ItemID = 1872;
			
			this.m_RecordLocationTimer = new RecordLocationTimer (this);
			this.m_RecordLocationTimer.Start();
		}
		
		public MovingTrap2( Serial serial ) : base( serial )
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
			private MovingTrap2 m_MovingTrap2;
			
		
			public RecordLocationTimer ( MovingTrap2 trap ) : base( TimeSpan.Zero )
			{
				m_MovingTrap2 = trap;
			}
			
			public void RecordLocation()
			{
				Point3D loc = m_MovingTrap2.GetWorldLocation();
				m_MovingTrap2.Ya = loc.Y;
			}

			protected override void OnTick()
			{
				RecordLocation();
				Stop();
				
				m_MovingTrap2.m_XPlus = new XPlus (m_MovingTrap2);
				m_MovingTrap2.m_XPlus.Start();
			}
		}
		
	///////////////////
		private class XPlus  : Timer
		{
			private MovingTrap2 m_MovingTrap2;
			
			public XPlus ( MovingTrap2 trap ) : base( TimeSpan.FromSeconds( 0.1 ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_MovingTrap2 = trap;
				
			}
	
			protected override void OnTick()
			{
				
				if( (m_MovingTrap2.Ya + 5) > m_MovingTrap2.Y )
					{
						m_MovingTrap2.Y++;
						
						List<Mobile> list = new List<Mobile>();
						foreach( Mobile mob in m_MovingTrap2.GetMobilesInRange( 1 ) ) 
						{
							Point3D traploc = m_MovingTrap2.GetWorldLocation();
							//Point3D mobloc = mob.Y();
							if( ( mob.Y == ( m_MovingTrap2.Y + 1 ) & mob.X == m_MovingTrap2.X || mob.Y == ( m_MovingTrap2.Y - 1 ) & mob.X == m_MovingTrap2.X ) & mob.Alive )
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
					m_MovingTrap2.m_XMinus = new XMinus (m_MovingTrap2);
					m_MovingTrap2.m_XMinus.Start();
				}
				
			}
		}
		
	///////////////////////////////
		private class XMinus  : Timer
		{
			private MovingTrap2 m_MovingTrap2;

			public XMinus ( MovingTrap2 trap ) : base( TimeSpan.FromSeconds( 0.1 ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_MovingTrap2 = trap;
			}
			
			protected override void OnTick()
			{
				if( (m_MovingTrap2.Ya - 5) < m_MovingTrap2.Y )
					{
						m_MovingTrap2.Y--;
						
						List<Mobile> list = new List<Mobile>();
						foreach( Mobile mob in m_MovingTrap2.GetMobilesInRange( 1 ) ) 
						{
							Point3D traploc = m_MovingTrap2.GetWorldLocation();
							//Point3D mobloc = mob.Location();
							if( ( mob.Y == ( m_MovingTrap2.Y + 1 ) & mob.X == m_MovingTrap2.X || mob.Y == ( m_MovingTrap2.Y - 1 ) & mob.X == m_MovingTrap2.X ) & mob.Alive )
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
					m_MovingTrap2.m_XPlus = new XPlus (m_MovingTrap2);
					m_MovingTrap2.m_XPlus.Start();
				}
				
			}
		}	// end of XMinus Timer
		
	}	// end of class MovingTrap2
}	// end of namespace
