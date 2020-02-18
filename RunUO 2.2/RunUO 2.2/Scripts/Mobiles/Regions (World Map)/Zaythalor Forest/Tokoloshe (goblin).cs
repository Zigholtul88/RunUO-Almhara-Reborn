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
	[CorpseName( "a tokoloshe corpse" )]
	public class Tokoloshe : BaseCreature
	{
		[Constructable]
		public Tokoloshe() : base( AIType.AI_Thief, FightMode.Closest, 8, 1, 0.175, 0.350 )
		{
			Name = "a tokoloshe";
			Body = 723;
                        Hue = 1153;

			SetStr( 23, 31 );
			SetDex( 16, 20 );
			SetInt( 2 );

			SetMana( 0 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 8 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.ArmsLore, 80.3, 80.4 );
			SetSkill( SkillName.DetectHidden, 65.0, 88.0 );
			SetSkill( SkillName.MagicResist, 10.1, 12.7 );
			SetSkill( SkillName.Stealing, 95.0 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 200;
			Karma = -200;

			PackGold( 67, 131 );
			PackItem( new FishScale( Utility.RandomMinMax( 1, 2 ) ) );

			if ( 0.03 > Utility.RandomDouble() )
				PackItem( new ShortSpear() );
		}

		public override int Meat{ get{ return 1; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !IsFanned( defender ) && 0.15 > Utility.RandomDouble() )
			{
                                defender.SendMessage( "The tokoloshe sprays you with gas, reducing your resistance to physical attacks." );

		                ResistanceMod mod = new ResistanceMod( ResistanceType.Physical, - 50 );

				defender.FixedParticles( 0x3779, 10, 30, 0x34, EffectLayer.RightFoot );
				defender.PlaySound( 0x1E6 );

				// This should be done in place of the normal attack damage.
				//AOS.Damage( defender, this, Utility.RandomMinMax( 5, 10 ), 100, 0, 0, 0, 0 );

				defender.AddResistanceMod( mod );
		
				ExpireTimer timer = new ExpireTimer( defender, mod, TimeSpan.FromSeconds( 10.0 ) );
				timer.Start();
				m_Table[defender] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		public bool IsFanned( Mobile m )
		{
			return m_Table.Contains( m );
		}

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private ResistanceMod m_Mod;

			public ExpireTimer( Mobile m, ResistanceMod mod, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
				m_Mod = mod;
				Priority = TimerPriority.TwoFiftyMS;
		        }

			protected override void OnTick()
			{
                                m_Mobile.SendMessage( "Your resistance to physical attacks has returned." );
				m_Mobile.RemoveResistanceMod( m_Mod );
				Stop();
				m_Table.Remove( m_Mobile );
			}
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.ZaythalorPredator; }
		}

		public override bool IsEnemy( Mobile m )
		{
		        PlayerMobile pm = m as PlayerMobile;

			if ( m is PlayerMobile && m.SkillsTotal >= 5000 )
				return false;

                        if ( m is PlayerVendor || m is TownCrier || m is BaseSpecialCreature )
				return false;

			if ( m is BaseCreature )
			{
				BaseCreature c = (BaseCreature)m;

				if( c.Controlled || c.FightMode == FightMode.Aggressor || c.FightMode == FightMode.Closest || c.FightMode == FightMode.None )

					return false;
			}

			return true;
		}

		public Tokoloshe( Serial serial ) : base( serial )
		{
		}

		public override bool CanRummageCorpses{ get{ return true; } }

		public override int GetAttackSound() { return 1533; } 
		public override int GetAngerSound() { return 1533; } 
		public override int GetHurtSound() { return 1535; } 
		public override int GetDeathSound() { return 1534; }

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
	}
}
