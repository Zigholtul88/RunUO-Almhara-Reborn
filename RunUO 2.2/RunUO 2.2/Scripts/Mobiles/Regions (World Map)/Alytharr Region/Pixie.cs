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
	[CorpseName( "a pixie corpse" )]
	public class Pixie : BaseCreature
	{
		public override bool InitialInnocent{ get{ return true; } }

                private readonly Timer m_Timer;

		[Constructable]
		public Pixie() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "pixie" );
			Body = 128;
			BaseSoundID = 0x467;

			SetStr( 21, 30 );
			SetDex( 301, 400 );
			SetInt( 201, 250 );

			SetHits( 13, 18 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 80, 90 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 40, 50 );

			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 90.1, 100.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 100.5, 150.0 );
			SetSkill( SkillName.Tactics, 10.1, 20.0 );
			SetSkill( SkillName.Wrestling, 10.1, 12.5 );

			Fame = 7000;
			Karma = 7000;

                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();

			VirtualArmor = 100;
			if ( 0.02 > Utility.RandomDouble() )
				PackStatue();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Gems, 2 );
		}

		public override HideType HideType{ get{ return HideType.Spined; } }
		public override int Hides{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }

		public Pixie( Serial serial ) : base( serial )
		{
                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();
		}

                public override void OnDelete()
                {
                        this.m_Timer.Stop();

                        base.OnDelete();
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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
			private Pixie m_Owner;
			private int m_Count = 0;

			public InternalTimer( Pixie owner ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if ( (m_Count++ & 0x999) == 0 )
				{
					m_Owner.Direction = (Direction)(Utility.Random( 20 ) | 0x80);
				}

				m_Owner.Move( m_Owner.Direction );
			}
		}
	}
}