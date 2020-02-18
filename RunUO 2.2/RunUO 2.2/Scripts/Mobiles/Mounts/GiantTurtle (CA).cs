using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a giant turtle corpse" )]
	public class GiantTurtle : BaseMount
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public GiantTurtle() : this( "a giant turtle" )
		{
		}

		[Constructable]
		public GiantTurtle( string name ) : base( name, 0x113, 0x3EB1, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.3, 0.6 )
		{
			BaseSoundID = 224;

			SetStr( 361, 485 );
			SetDex( 41, 65 );
			SetInt( 46, 70 );

			SetHits( 697, 711 );

			SetDamage( 15, 21 );

			SetDamageType( ResistanceType.Physical, 85 );
			SetDamageType( ResistanceType.Poison, 15 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 25, 35 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 5, 15 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 40.1, 55.0 );
			SetSkill( SkillName.Tactics, 45.1, 70.0 );
			SetSkill( SkillName.Wrestling, 50.1, 70.0 );

			Fame = 1500;
			Karma = -1500;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 36.4;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override int GetDeathSound()
		{
			return 1218;
		}

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override bool BleedImmune{ get{ return true; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( Utility.RandomDouble() < 0.25 )
				CacophonicAttack( defender );
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.HarashiNabiPredator; }
		}

		public GiantTurtle( Serial serial ) : base( serial )
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

		private static Hashtable m_Table;

		public virtual void CacophonicAttack( Mobile to )
		{
			if( m_Table == null )
				m_Table = new Hashtable();

			if( to.Alive && to.Player && m_Table[ to ] == null )
			{
				to.Send( SpeedControl.WalkSpeed );
				to.SendLocalizedMessage( 1072069 ); // A cacophonic sound lambastes you, suppressing your ability to move.
				to.PlaySound( 0x584 );

				m_Table[ to ] = Timer.DelayCall( TimeSpan.FromSeconds( 30 ), new TimerStateCallback( EndCacophonic_Callback ), to );
			}
		}

		private void EndCacophonic_Callback( object state )
		{
			if( state is Mobile )
				CacophonicEnd( (Mobile)state );
		}

		public virtual void CacophonicEnd( Mobile from )
		{
			if( m_Table == null )
				m_Table = new Hashtable();

			m_Table[ from ] = null;

			from.Send( SpeedControl.Disable );
		}

		public static bool UnderCacophonicAttack( Mobile from )
		{
			if( m_Table == null )
				m_Table = new Hashtable();

			return m_Table[ from ] != null;
		}
	}
}