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
	[CorpseName( "the corpse of Pyre" )]
	public class Pyre : BaseCreature
	{
                Point3D[] MoveLocations =
                {
                        new Point3D( 1651, 251, 81 ),//Dragon Sanctuary [Random Building]
                        new Point3D( 1653, 356, -3 ),//Dragon Sanctuary [Random Building]
                        new Point3D( 1725, 232, 78 ) //Dragon Sanctuary [Random Building]
                };

                private MoveTimer m_Timer;

		[Constructable]
		public Pyre() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			IsParagon = true;

			Name = "Pyre";
			Body = 832;
			BaseSoundID = 0x8F;
			Hue = 0x489;

			SetStr( 605, 611 );
			SetDex( 391, 519 );
			SetInt( 669, 818 );

			SetHits( 1783, 1939 );
			SetMana( 3500, 3800 );

			SetDamage( 30 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 50 );

			SetResistance( ResistanceType.Physical, 65 );
			SetResistance( ResistanceType.Fire, 72 );
			SetResistance( ResistanceType.Poison, 36 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.Wrestling, 121.9, 130.6 );
			SetSkill( SkillName.Tactics, 114.4, 117.4 );
			SetSkill( SkillName.MagicResist, 147.7, 153.0 );
			SetSkill( SkillName.Poisoning, 122.8, 124.0 );
			SetSkill( SkillName.Magery, 121.8, 127.8 );
			SetSkill( SkillName.EvalInt, 103.6, 117.0 );
			SetSkill( SkillName.Meditation, 100.0, 110.0 );

			Fame = 500000;
			Karma = -500000;

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

		public override bool AutoDispel{ get{ return true; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public Pyre( Serial serial ) : base( serial )
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
                        private Pyre m_Owner;

                public MoveTimer(Pyre owner): base(TimeSpan.FromHours(1), TimeSpan.FromHours(1))
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