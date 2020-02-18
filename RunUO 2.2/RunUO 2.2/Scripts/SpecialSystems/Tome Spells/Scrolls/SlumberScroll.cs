using System;
using Server;
using System.Collections;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Spells.Tome;
using Server.Targeting;

namespace Server.Items
{
	public class SlumberScroll : Item
	{
		[Constructable]
		public SlumberScroll() : this( 1 )
		{
		}

		[Constructable]
		public SlumberScroll( int amount ) : base( 0x2261 )
		{
			Name = "Slumber - 6th Circle";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 1157;

			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile from )
		{
                        new SlumberSpell ( from, this ).Cast();
		}

		public SlumberScroll( Serial serial ) : base( serial )
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
		}
	}
}

namespace Server.Spells.Tome
{
	public class SlumberSpell : TomeSpell
	{
                private SlumberBody m_Body;

		private static SpellInfo m_Info = new SpellInfo(
				"Slumber", "slumber",
				-1,
				9002
			);

                public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(5); } }
                public override SpellCircle Circle { get { return SpellCircle.Sixth; } }
		public override double RequiredSkill { get { return 45.1; } }
		public override int RequiredMana { get { return 60; } }

		public SlumberSpell( Mobile caster, Item scroll ): base( caster, scroll, m_Info )
		{
		}

		public override void OnCast() 
		{ 
                if (CheckSequence())
                    Caster.Target = new InternalTarget(this);
		} 

		public void Target( Mobile m ) 
		{ 
			if ( !Caster.CanSee( m ) ) 
			{ 
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen. 
			} 
			else
			{
                            SpellHelper.Turn( Caster, m );
                            Effects.SendLocationParticles(EffectItem.Create(new Point3D(m.X, m.Y, m.Z + 16), Caster.Map, EffectItem.DefaultDuration), 0x376A, 10, 15, 5045);
                            m.PlaySound(0x3C4);

                            m.Hidden = true;
                            m.Frozen = true;
                            m.Squelched = true;

                            ArrayList sleepequip = new ArrayList();

                            Item hat = m.FindItemOnLayer( Layer.Helm );
                            if (hat != null)
                            {
                               sleepequip.Add(hat);
                            }
                            SlumberBody body = new SlumberBody( m, false );
                            body.Map = m.Map;
                            body.Location = m.Location;
                            m_Body = body;
                            m.Z -= 100;

                            m.SendMessage("You fall asleep");

                            RemoveTimer( m );

                            TimeSpan duration = TimeSpan.FromSeconds(Caster.Skills[SkillName.Magery].Value * 1.2); // 120% of magery

                            Timer t = new InternalTimer(m, duration, m_Body);

                            m_Table[m] = t;

                            t.Start();
                   }
        }

        private static Hashtable m_Table = new Hashtable();

        public static void RemoveTimer(Mobile m)
        {
            Timer t = (Timer)m_Table[m];

            if (t != null)
            {
                t.Stop();
                m_Table.Remove(m);
            }
        }

        private class InternalTimer : Timer
        {
            private Mobile m_Mobile;
            private Item m_Body;

            public InternalTimer(Mobile m, TimeSpan duration, Item body): base(duration)
            {
                m_Mobile = m;
                m_Body = body;
            }

            protected override void OnTick()
            {
                m_Mobile.RevealingAction();
                m_Mobile.Frozen = false;
                m_Mobile.Squelched = false;

                if (m_Body != null)
                {
                    m_Body.Delete();
                    m_Mobile.SendMessage("You wake up!");
                    m_Mobile.Z = m_Body.Z;
                    m_Mobile.Animate(21, 6, 1, false, false, 0);
                }
                RemoveTimer(m_Mobile);
            }
        }

        public class InternalTarget : Target
        {
            private SlumberSpell m_Owner;

            public InternalTarget(SlumberSpell owner): base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                {
                    m_Owner.Target((Mobile)o);
                }
            }

            protected override void OnTargetFinish( Mobile from )
            {
                m_Owner.FinishSequence();
            }
        }
    }
}
