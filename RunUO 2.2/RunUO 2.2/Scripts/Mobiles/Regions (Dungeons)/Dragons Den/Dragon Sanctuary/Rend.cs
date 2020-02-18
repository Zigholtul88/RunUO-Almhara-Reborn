using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Misc;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Rend" )]
	public class Rend : BaseMount
	{
                Point3D[] MoveLocations =
                {
                        new Point3D( 1677, 346, 33 ),//Dragon Sanctuary [Random Building]
                        new Point3D( 1754, 173, 103 ) //Dragon Sanctuary [Random Building]
                };

                private MoveTimer m_Timer;

		[Constructable]
		public Rend() : base( "Rend", 0x114, 0x3E90, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.35 )
		{
			IsParagon = true;

			Name = "Rend";
			Hue = 0x455;
			BaseSoundID = 0x16A;

			SetStr( 1261, 1284 );
			SetDex( 363, 384 );
			SetInt( 601, 642 );

			SetHits( 5176, 6100 );

			SetDamage( 26, 33 );

			SetDamageType( ResistanceType.Physical, 100 );
			SetDamageType( ResistanceType.Poison, 0 );
			SetDamageType( ResistanceType.Energy, 0 );

			SetResistance( ResistanceType.Physical, 75 );
			SetResistance( ResistanceType.Fire, 81 );
			SetResistance( ResistanceType.Cold, 46 );
			SetResistance( ResistanceType.Poison, 35 );
			SetResistance( ResistanceType.Energy, 45 );

			SetSkill( SkillName.Wrestling, 136.3, 150.3 );
			SetSkill( SkillName.Tactics, 133.4, 141.4 );
			SetSkill( SkillName.MagicResist, 90.9, 110.0 );
			SetSkill( SkillName.Anatomy, 66.6, 72.0 );

			Fame = 800000;
			Karma = -800000;

                        m_Timer = new MoveTimer( this );
                        ChangeLocation();

                        if (Utility.RandomDouble() < 0.8 )
                                PackItem(new TreasureMap(5, Map.Malas ) );
		}

                public void ChangeLocation()
                {
                        this.MoveToWorld( MoveLocations[ Utility.Random( MoveLocations.Length )], Map.Ilshenar );
                        this.Hidden = true; //Arrives Hidden
                }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 3 );
		}

		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override bool CanBreath{ get{ return true; } }

		public override bool AutoDispel{ get{ return true; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public Rend( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
                        m_Timer = new MoveTimer(this);
		}

                private class MoveTimer : Timer
                {
                        private Rend m_Owner;

                public MoveTimer(Rend owner): base(TimeSpan.FromHours(1), TimeSpan.FromHours(1))
                {
                        m_Owner = owner;
                        TimerThread.PriorityChange(this, 7);
                }

                protected override void OnTick()
                {
                        if (m_Owner == null)
                        {
                        Stop();
                        return;
                }
                else if (m_Owner.Hits == m_Owner.HitsMax) // IE not in combat at all
                {
                        m_Owner.ChangeLocation();
                }
            }
        }
    }
}