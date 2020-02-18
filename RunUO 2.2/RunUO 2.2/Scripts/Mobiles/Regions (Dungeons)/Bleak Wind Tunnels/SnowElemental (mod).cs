using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a snow elemental corpse" )]
	public class SnowElemental : BaseCreature
	{
		[Constructable]
		public SnowElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a snow elemental";
			Body = 163;
			BaseSoundID = 263;

			SetStr( 326, 355 );
			SetDex( 166, 185 );
			SetInt( 71, 95 );

			SetHits( 392, 426 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Cold, 80 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 60 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.MagicResist, 50.1, 65.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.Wrestling, 80.1, 100.0 );

			Fame = 15000;
			Karma = -15000;

			PackGold( 15, 28 );

			PackItem( new BlackPearl( 3 ) );
			Item ore = new IronOre( 3 );
			ore.ItemID = 0x19B8;
			PackItem( ore );

			PackItem( new ElementalDust( Utility.RandomMinMax( 6, 9 ) ) );
			PackItem( new DiamondDust( Utility.RandomMinMax( 6, 12 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new HarmScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
		}

		public override bool BleedImmune{ get{ return true; } }

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
				AOS.Damage( m, this, Utility.Random( 25, 35 ), 0, 0, 100, 0, 0, true );
				m.PlaySound( 0x0FC );
				m.RevealingAction();
				DoHarmful( m );
				m.SendMessage( "The snow elementals's icy aura damages you slowly as you stand near it!" );
				m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 5, 5 ) );
			}
		}

		public SnowElemental( Serial serial ) : base( serial )
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