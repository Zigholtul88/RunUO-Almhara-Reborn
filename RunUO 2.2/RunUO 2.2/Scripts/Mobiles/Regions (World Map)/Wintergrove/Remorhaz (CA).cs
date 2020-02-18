using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a remorhaz corpse" )]
	public class Remorhaz : BaseCreature
	{
		[Constructable]
		public Remorhaz () : base( AIType.AI_Melee, FightMode.Closest, 7, 1, 0.175, 0.350 )
		{
			Name = "a remorhaz";
			Body = 315;

			SetStr( 397, 414 );
			SetDex( 103, 138 );
			SetInt( 135, 151 );

			SetHits( 410, 472 );

			SetDamage( 11, 15 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Fire, 25 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 40 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.MagicResist, 45.1, 50.0 );
			SetSkill( SkillName.Tactics, 65.4, 88.5 );
			SetSkill( SkillName.Wrestling, 68.8, 81.7 );

			Fame = 5500;
			Karma = -5500;

			PackGold( 51, 73 );
			PackReg( 17 );

			switch ( Utility.Random( 2 ))
			{
				case 0: PackItem( new TurquoiseCustom() ); break;
				case 1: PackItem( new Tsavorite() ); break;
			}

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new FlamestrikeScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
			AddLoot( LootPack.Gems );
		}

		public override int GetAngerSound() { return 0x5A; } 
		public override int GetIdleSound() { return 0x5A; } 
		public override int GetAttackSound() { return 0x164; } 
		public override int GetHurtSound() { return 0x187; } 
		public override int GetDeathSound() { return 0x1BA; }

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override int Meat{ get{ return 8; } }
		public override int Hides{ get{ return 17; } }
		public override HideType HideType{ get{ return HideType.Horned; } }

		private DateTime m_LastRadiated;
	        private Hashtable m_Mobiles = new Hashtable();

		protected override bool OnMove( Direction d )
		{
			if ( !IsDeadBondedPet )
			{
				if ( m_LastRadiated <= DateTime.Now )
					m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 10 ) );
				IPooledEnumerable eable = GetMobilesInRange( 2 );
				foreach( Mobile m in eable )
					if ( m_Mobiles[m] == null )
						m_Mobiles[m] = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( RadiationCallBack ), m );
			}

			return base.OnMove( d );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m_LastRadiated <= DateTime.Now )
					m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 10 ) );
			if ( !IsDeadBondedPet && m_Mobiles[m] == null && Utility.InRange( Location, m.Location, 2 ) && !Utility.InRange( Location, oldLocation, 2 ) )
				m_Mobiles[m] = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( RadiationCallBack ), m );

			base.OnMovement( m, oldLocation );
		}

		public void RadiationCallBack( object state )
		{
			Mobile m = (Mobile)state;

			if ( Deleted || !Alive || !Utility.InRange( Location, m.Location, 2 ) )
			{
				((Timer)m_Mobiles[m]).Stop();
				m_Mobiles[m] = null;
				return;
			}

			if ( this != m && m.AccessLevel == AccessLevel.Player && m_LastRadiated <= DateTime.Now && Server.Spells.SpellHelper.ValidIndirectTarget( m, this ) && CanBeHarmful( m, false, false ) )
			{
				AOS.Damage( m, this, Utility.Random( 45, 50 ), 0, 0, 100, 0, 0, true );
				m.PlaySound( 0x0FC );
				m.RevealingAction();
				DoHarmful( m );
				m.SendMessage( "The icy aura radiating from the remorhaz damages you slowly as you stand near it!" );
				m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 5, 5 ) );
			}
		}

		public Remorhaz( Serial serial ) : base( serial )
		{
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
	}
}