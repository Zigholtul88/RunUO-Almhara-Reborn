using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a dire wolf corpse" )]
	[TypeAlias( "Server.Mobiles.Direwolf" )]
	public class DireWolf : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public DireWolf() : base( AIType.AI_Melee,FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = "a dire wolf";
			Body = 23;
			BaseSoundID = 0xE5;

			SetStr( 96, 119 );
			SetDex( 81, 105 );
			SetInt( 36, 119 );

			SetHits( 116, 144 );
			SetMana( 0 );

			SetDamage( 5, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 22 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 25.0 );
			SetSkill( SkillName.Healing, 45.8, 60.2 );
			SetSkill( SkillName.MagicResist, 58.8, 74.8 );
			SetSkill( SkillName.Ninjitsu, 75.0 );
			SetSkill( SkillName.Tactics, 50.6, 68.7 );
			SetSkill( SkillName.Wrestling, 74.0, 82.0 );

			Fame = 1500;
			Karma = -1500;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 45.5;

			PackGold( 126, 158 );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		private DateTime m_NextAttack;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextAttack )
			{
				SandAttack( combatant );
				m_NextAttack = DateTime.Now + TimeSpan.FromSeconds( 10.0 + (10.0 * Utility.RandomDouble()) );
			}
		}

		public void SandAttack( Mobile m )
		{
			DoHarmful( m );

			m.FixedParticles( 0x36B0, 10, 25, 9540, 2413, 0, EffectLayer.Waist );

			new InternalTimer( m, this ).Start();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile, m_From;

			public InternalTimer( Mobile m, Mobile from ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				m_Mobile.PlaySound( 0x4CF );
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 1, 30 ), 90, 10, 0, 0, 0 );
			}
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.5 > Utility.RandomDouble() )
			{
				/* Blood Bath
				 * Start cliloc 1070826
				 * Sound: 0x52B
				 * 2-3 blood spots
				 * Damage: 3 hps per second for 60 seconds
				 * End cliloc: 1070824
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if( timer != null )
				{
					timer.DoExpire();
                                        defender.SendMessage( "The dire wolf pup continues inflicting bleeding damage!" );
				}
				else
                                        defender.SendMessage( "The dire wolf pup goes into a rage, inflicting continuous bleeding damage!" );

				timer = new ExpireTimer( defender, this );
				timer.Start();
				m_Table[defender] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private Mobile m_From;
			private int m_Count;

			public ExpireTimer( Mobile m, Mobile from ): base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			public void DoExpire()
			{
				Stop();
				m_Table.Remove( m_Mobile );
			}

			public void DrainLife()
			{
				if( m_Mobile.Alive )
					m_Mobile.Damage( 3, m_From );
				else
					DoExpire();
			}

			protected override void OnTick()
			{
				DrainLife();

				if( ++m_Count >= 60 )
				{
					DoExpire();
                                        m_Mobile.SendMessage( "The blood clouting from the dire wolf pup's bite subsides." );
				}
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(), from);
                              corpse.AddCarvedItem(new SpinedHides(7), from);
                              corpse.AddCarvedItem(new RawDireWolfLeg(), from);

                              from.SendMessage( "You carve up a raw rib, some hides, and a raw dire wolf leg." );
                              corpse.Carved = true; 
			}
                }

		public DireWolf(Serial serial) : base(serial)
		{
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
	}
}