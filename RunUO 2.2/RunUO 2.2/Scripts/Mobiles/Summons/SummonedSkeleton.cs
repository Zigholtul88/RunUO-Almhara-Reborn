using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal corpse" )]
	public class SummonedSkeleton : BaseCreature
	{
		public Timer	m_Timer;

		[Constructable]
		public SummonedSkeleton() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a summoned skeleton";
			Body = Utility.RandomList( 50, 56 );
			BaseSoundID = 0x48D;

   			if ( Body == 56 ) //Hatchet
   			{
  				DamageMin += 2;
   				DamageMax += 6;
   				RawStr += 10;
   				RawDex -= 10;
				Skills.Lumberjacking.Base += 55;
   			}

			SetStr( 61, 76 );
			SetDex( 56, 73 );
			SetInt( 16, 37 );

			SetHits( 68, 96 );

			SetDamage( 3, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 16 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.MagicResist, 45.4, 58.2 );
			SetSkill( SkillName.Tactics, 45.1, 59.2 );
			SetSkill( SkillName.Wrestling, 49.4, 57.5 );

			Fame = 450;
			Karma = -450;

			VirtualArmor = 16;

			m_Timer = new AutokillTimer(this);
			m_Timer.Start();
		}

		public override void GenerateLoot()
		{
   			if ( Body == 56 ) //Hatchet
   			{
				AddItem( new Hatchet() );
   			}
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from != null && from != this )
			{
				if (from is PlayerMobile)
				{
					PlayerMobile p_PlayerMobile = from as PlayerMobile;
					Item weapon1 = p_PlayerMobile.FindItemOnLayer( Layer.OneHanded );
					Item weapon2 = p_PlayerMobile.FindItemOnLayer( Layer.TwoHanded );

					if (weapon1 != null)
					{
						if (weapon1 is BaseBashing )
						{
							damage += 1;
						}
                                    else
                                    {
							damage = 5;
							from.SendMessage("Your weapon deals little damage to the skeleton's durable bones.");
                                    }
					}

					else if (weapon2 != null)
					{
						if (weapon2 is BaseBashing )
						{
							damage += 1;
						}
                                    else
                                    {
							damage = 5;
							from.SendMessage("Your weapon deals little damage to the skeleton's durable bones.");
                                    }
					}
				}
			}
		}

		public SummonedSkeleton (Serial serial) : base(serial)
		{
			m_Timer = new AutokillTimer(this);
			m_Timer.Start();
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}

		private class AutokillTimer : Timer
		{
			private SummonedSkeleton m_Owner;

			public AutokillTimer( SummonedSkeleton owner ) : base( TimeSpan.FromMinutes(1.0) )
			{
				m_Owner = owner;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Owner.Delete();
				Stop();
			}
		}
	}
}
