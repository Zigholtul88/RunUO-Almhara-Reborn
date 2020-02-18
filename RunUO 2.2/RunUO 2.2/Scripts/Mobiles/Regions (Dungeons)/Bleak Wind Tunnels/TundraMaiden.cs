using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a tundra maiden corpse" )]
	public class TundraMaiden : BaseCreature
	{
		[Constructable]
		public TundraMaiden () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a tundra maiden";
			Body = 149;
                        Hue = 1153;
			BaseSoundID = 0x4B0;

			SetStr( 216, 325 );
			SetDex( 176, 195 );
			SetInt( 128, 205 );

			SetHits( 347, 397 );
			SetMana( 375, 415 );

			SetDamage( 10, 17 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Cold, 75 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 60 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.EvalInt, 80.1, 90.0 );
			SetSkill( SkillName.Magery, 80.1, 90.0 );
			SetSkill( SkillName.MagicResist, 45.1, 55.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.Tactics, 80.1, 90.0 );
			SetSkill( SkillName.Wrestling, 80.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			PackGold( 47, 61 );

			PackItem( new TurquoiseCustom() );
			PackItem( new DiamondDust( Utility.RandomMinMax( 17, 23 ) ) );

 			if ( Utility.RandomDouble() < 0.04 )
				PackItem( new CrackedResistColdGem() );

 			if ( Utility.RandomDouble() < 0.04 )
				PackItem( new CrackedHitHarmGem() );

			Container pack1 = new Backpack();
			pack1.DropItem( new Gold( Utility.RandomMinMax( 15, 17 ) ) );
			pack1.DropItem( new HoneydewMelon( Utility.RandomMinMax( 4, 7 ) ) );
			pack1.DropItem( new KnifeLeft() );
			pack1.DropItem( new SpoonRight() );
			pack1.DropItem( new Rope() );
			PackItem( pack1 );

			Container pack2 = new Backpack();
			pack2.DropItem( new BlackPearl( Utility.RandomMinMax( 7, 12 ) ) );
			pack2.DropItem( new Bloodmoss( Utility.RandomMinMax( 5, 9 ) ) );
			pack2.DropItem( new Garlic( Utility.RandomMinMax( 9, 14 ) ) );
			pack2.DropItem( new Ginseng( Utility.RandomMinMax( 3, 7 ) ) );
			pack2.DropItem( new MandrakeRoot( Utility.RandomMinMax( 8, 15 ) ) );
			pack2.DropItem( new Nightshade( Utility.RandomMinMax( 9, 17 ) ) );
			pack2.DropItem( new SpidersSilk( Utility.RandomMinMax( 7, 12 ) ) );
			pack2.DropItem( new SulfurousAsh( Utility.RandomMinMax( 5, 9 ) ) );
			PackItem( pack2 );

			Container pack3 = new Backpack();
			pack3.DropItem( new Gold( Utility.RandomMinMax( 12, 15 ) ) );
			pack3.DropItem( new PoisonPotion() );
			pack3.DropItem( new MindPotion() );
			pack3.DropItem( new StrengthPotion() );
			PackItem( pack3 );

			switch ( Utility.Random( 5 ) )
			{
				case 0: PackItem( new HarmScroll(3) );  break;
				case 1: PackItem( new EnergyBoltScroll(2) ); break;
				case 2: PackItem( new PoisonFieldScroll(2) ); break;
				case 3: PackItem( new WallOfStoneScroll(2) ); break;
				case 4: PackItem( new CurseScroll(3) ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Average, 2 );
			AddLoot( LootPack.MedScrolls, 1 );
		}

		public override int Meat{ get{ return 1; } }

		public void DrainLife()
		{
			ArrayList list = new ArrayList();

			foreach ( Mobile m in this.GetMobilesInRange( 2 ) )
			{
				if ( m == this || !CanBeHarmful( m ) )
					continue;

				if ( m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team) )
					list.Add( m );
				else if ( m.Player )
					list.Add( m );
			}

			foreach ( Mobile m in list )
			{
				DoHarmful( m );

				m.FixedParticles( 0x374A, 10, 15, 5013, 0x496, 0, EffectLayer.Waist );
				m.PlaySound( 0x231 );

				m.SendMessage( "You feel the life drain out of you!" );

				int toDrain = Utility.RandomMinMax( 10, 15 );

				Hits += toDrain;
				m.Damage( toDrain, this );
			}
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.1 >= Utility.RandomDouble() )
				DrainLife();
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( 0.1 >= Utility.RandomDouble() )
				DrainLife();
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
				AOS.Damage( m, this, Utility.Random( 25, 35 ), 0, 0, 100, 0, 0, true );
				m.PlaySound( 0x0FC );
				m.RevealingAction();
				DoHarmful( m );
				m.SendMessage( "The tundra maiden's icy aura damages you slowly as you stand near it!" );
				m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 5, 5 ) );
			}
		}

		public TundraMaiden( Serial serial ) : base( serial )
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