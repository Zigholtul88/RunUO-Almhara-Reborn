using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an ice serpent corpse" )]
	[TypeAlias( "Server.Mobiles.Iceserpant" )]
	public class IceSerpent : BaseCreature
	{
		[Constructable]
		public IceSerpent() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a giant ice serpent";
			Body = 89;
			BaseSoundID = 219;

			SetStr( 216, 245 );
			SetDex( 26, 50 );
			SetInt( 66, 85 );

			SetHits( 260, 294 );
			SetMana( 0 );

			SetDamage( 7, 17 );

			SetDamageType( ResistanceType.Physical, 10 );
			SetDamageType( ResistanceType.Cold, 90 );

			SetResistance( ResistanceType.Physical, 32 );
			SetResistance( ResistanceType.Cold, 80 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 27.5, 50.0 );
			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 75.1, 80.0 );
			SetSkill( SkillName.Wrestling, 60.1, 80.0 );

			Fame = 16000;
			Karma = -16000;

			PackItem( Loot.RandomArmorOrShieldOrWeapon() );
			
			switch ( Utility.Random( 10 ))
			{
				case 0: PackItem( new LeftArm() ); break;
				case 1: PackItem( new RightArm() ); break;
				case 2: PackItem( new Torso() ); break;
				case 3: PackItem( new Bone() ); break;
				case 4: PackItem( new RibCage() ); break;
				case 5: PackItem( new RibCage() ); break;
				case 6: PackItem( new BonePile() ); break;
				case 7: PackItem( new BonePile() ); break;
				case 8: PackItem( new BonePile() ); break;
				case 9: PackItem( new BonePile() ); break;
			}
			
			PackGold( 17, 23 );

			PackItem( new TurquoiseCustom() );
			PackItem( new DiamondDust( Utility.RandomMinMax( 5, 9 ) ) );
			PackItem( new SerpentScale( Utility.RandomMinMax( 11, 14 ) ) );

 			if ( Utility.RandomDouble() < 0.01 )
				PackItem( new GlacialStaff() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override bool DeathAdderCharmable{ get{ return true; } }

		public override int Meat{ get{ return 4; } }
		public override int Hides{ get{ return 15; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

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
				AOS.Damage( m, this, Utility.Random( 15, 25 ), 0, 0, 100, 0, 0, true );
				m.PlaySound( 0x0FC );
				m.RevealingAction();
				DoHarmful( m );
				m.SendMessage( "The ice serpent's icy aura damages you slowly as you stand near it!" );
				m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 5, 5 ) );
			}
		}

		public IceSerpent(Serial serial) : base(serial)
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

			if ( BaseSoundID == -1 )
				BaseSoundID = 219;
		}
	}
}