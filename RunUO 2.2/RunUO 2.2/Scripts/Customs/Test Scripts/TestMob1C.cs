using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class TestMob1C : BaseCreature
	{
                private readonly Timer m_Timer;

		[Constructable]
		public TestMob1C() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "Bob";
			Title = "the Gate Keeper";
			Body = 0x1D;
			BaseSoundID = 0x9E;

			SetStr( 47, 70 );
			SetDex( 2249, 2263 );
			SetInt( 18, 29 );

			SetHits( 275, 300 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );

			SetSkill( SkillName.Archery, 450.7, 559.6 );
			SetSkill( SkillName.MagicResist, 18.9, 25.8 );
			SetSkill( SkillName.Tactics, 432.5, 546.9 );
			SetSkill( SkillName.Wrestling, 450.7, 559.6 );

			Fame = 1500;
			Karma = -1500;

                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();

			PackGold( 2, 5 );
			AddItem( new MagicalShortbow() );
			PackItem( new Arrow( Utility.RandomMinMax( 5, 7 ) ) );

			PackItem( new FishScale( Utility.RandomMinMax( 6, 12 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			base.OnMovement( m, oldLocation );

                        if ( m.Alive )
                        {
			        if ( InRange( m.Location, 5 ) && !InRange( oldLocation, 5 ) && m is PlayerMobile )
			        {
			                RangePerception = 200;
				        this.Combatant = m;
                                }
                        }
                }

		public TestMob1C( Serial serial ) : base( serial )
		{
                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();
		}

                public override void OnDelete()
                {
                        this.m_Timer.Stop();

                        base.OnDelete();
                }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		private class InternalTimer : Timer
		{
			private TestMob1C m_Owner;
			private int m_Count = 0;

			public InternalTimer( TestMob1C owner ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if ( (m_Count++ & 0x30) == 0 )
				{
					m_Owner.Direction = (Direction)(Utility.Random( 5 ) | 0x80);
				}

				m_Owner.Move( m_Owner.Direction );
			}
		}
	}
}