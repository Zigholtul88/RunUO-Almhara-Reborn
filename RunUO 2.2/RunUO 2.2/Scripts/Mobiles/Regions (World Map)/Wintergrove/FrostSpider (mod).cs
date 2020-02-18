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
	[CorpseName( "a frost spider corpse" )]
	public class FrostSpider : BaseCreature
	{
		[Constructable]
		public FrostSpider() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = "a frost spider";
			Body = 20;
			BaseSoundID = 0x388;

			SetStr( 76, 100 );
			SetDex( 126, 145 );
			SetInt( 36, 60 );

			SetHits( 90, 120 );
			SetMana( 0 );

			SetDamage( 6, 16 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Cold, 80 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 35.1, 50.0 );
			SetSkill( SkillName.Wrestling, 50.1, 65.0 );

			Fame = 775;
			Karma = -775;

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new CureScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Poor );
		}

		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 11, 16 )), from);
                        corpse.AddCarvedItem(new SpidersSilk( Utility.RandomMinMax( 5, 7 )), from);
                        corpse.AddCarvedItem(new DiamondDust( Utility.RandomMinMax( 2, 5 )), from);
                        corpse.AddCarvedItem(new SpiderEgg( Utility.RandomMinMax( 7, 15 )), from);

                        from.SendMessage( "You carve up some gold, spider silk, diamond dust, and spider eggs." );
                        corpse.Carved = true; 
			}
                }

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
				AOS.Damage( m, this, Utility.Random( 15, 20 ), 0, 0, 100, 0, 0, true );
				m.PlaySound( 0x0FC );
				m.RevealingAction();
				DoHarmful( m );
				m.SendMessage( "The frost spider's icy aura damages you slowly as you stand near it!" );
				m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 5, 5 ) );
			}
		}

		public FrostSpider( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 387 )
				BaseSoundID = 0x388;
		}
	}
}