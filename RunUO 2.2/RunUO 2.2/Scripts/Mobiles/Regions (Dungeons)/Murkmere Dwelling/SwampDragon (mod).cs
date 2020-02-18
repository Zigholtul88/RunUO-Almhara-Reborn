using System;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a swamp dragon corpse" )]
	public class SwampDragon : BaseMount
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		private bool m_BardingExceptional;
		private Mobile m_BardingCrafter;
		private int m_BardingHP;
		private bool m_HasBarding;
		private CraftResource m_BardingResource;

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile BardingCrafter
		{
			get{ return m_BardingCrafter; }
			set{ m_BardingCrafter = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool BardingExceptional
		{
			get{ return m_BardingExceptional; }
			set{ m_BardingExceptional = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int BardingHP
		{
			get{ return m_BardingHP; }
			set{ m_BardingHP = value; InvalidateProperties(); }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool HasBarding
		{
			get{ return m_HasBarding; }
			set
			{
				m_HasBarding = value;

				if ( m_HasBarding )
				{
					Hue = CraftResources.GetHue( m_BardingResource );
					BodyValue = 0x31F;
					ItemID = 0x3EBE;
				}
				else
				{
					Hue = 0x851;
					BodyValue = 0x31A;
					ItemID = 0x3EBD;
				}

				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public CraftResource BardingResource
		{
			get{ return m_BardingResource; }
			set
			{
				m_BardingResource = value;

				if ( m_HasBarding )
					Hue = CraftResources.GetHue( value );

				InvalidateProperties();
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int BardingMaxHP
		{
			get{ return m_BardingExceptional ? 2500 : 1000; }
		}

		[Constructable]
		public SwampDragon() : this( "a swamp dragon" )
		{
		}

		[Constructable]
		public SwampDragon( string name ) : base( name, 0x31A, 0x3EBD, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x16A;

			SetStr( 401, 430 );
			SetDex( 133, 152 );
			SetInt( 101, 140 );

			SetHits( 482, 516 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Fire, 20 );

			SetResistance( ResistanceType.Physical, 46 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.4, 88.5 );
			SetSkill( SkillName.Wrestling, 68.8, 81.7 );

			Fame = 5500;
			Karma = -5500;

			Hue = 0x851;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 84.3;
		}

		public override bool OverrideBondingReqs()
		{
			return true;
		}

		public override int GetIdleSound()
		{
			return 0x2CE;
		}

		public override int GetDeathSound()
		{
			return 0x2CC;
		}

		public override int GetHurtSound()
		{
			return 0x2D1;
		}

		public override int GetAttackSound()
		{
			return 0x2C8;
		}

		public override double GetControlChance( Mobile m, bool useBaseSkill )
		{
			return 1.0;
		}

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool AutoDispel{ get{ return !Controlled; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 20; } }
		public override int Scales{ get{ return 5; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Green; } }
		public override bool CanAngerOnTame { get { return true; } }

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.Skills[SkillName.AnimalTaming].Base < 84.3 )
			{
				from.SendMessage( "84.3 Animal Taming is needed to mount this creature." );
				return;
			}

			if ( IsDeadPet )
				return;

			if ( from.IsBodyMod && !from.Body.IsHuman )
			{
				if ( Core.AOS ) // You cannot ride a mount in your current form.
					PrivateOverheadMessage( Network.MessageType.Regular, 0x3B2, 1062061, from.NetState );
				else
					from.SendLocalizedMessage( 1061628 ); // You can't do that while polymorphed.

				return;
			}

			if ( !CheckMountAllowed( from, true ) )
				return;

			if ( from.Mounted )
			{
				from.SendLocalizedMessage( 1005583 ); // Please dismount first.
				return;
			}

			if ( !Multis.DesignContext.Check( from ) )
				return;

			if ( from.HasTrade )
			{
				from.SendLocalizedMessage( 1042317, "", 0x41 ); // You may not ride at this time
				return;
			}

			if ( from.InRange( this, 1 ) )
			{
				bool canAccess = ( from.AccessLevel >= AccessLevel.GameMaster )
					|| ( Controlled && ControlMaster == from )
					|| ( Summoned && SummonMaster == from );

				if ( canAccess )
				{
					if ( this.Poisoned )
						PrivateOverheadMessage( Network.MessageType.Regular, 0x3B2, 1049692, from.NetState ); // This mount is too ill to ride.
					else
						Rider = from;
				}
				else if ( !Controlled && !Summoned )
				{
					// That mount does not look broken! You would have to tame it to ride it.
					PrivateOverheadMessage( Network.MessageType.Regular, 0x3B2, 501263, from.NetState );
				}
				else
				{
					// This isn't your mount; it refuses to let you ride.
					PrivateOverheadMessage( Network.MessageType.Regular, 0x3B2, 501264, from.NetState );
				}
			}
			else
			{
				from.SendLocalizedMessage( 500206 ); // That is too far away to ride.
			}
		}

		public SwampDragon( Serial serial ) : base( serial )
		{
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			if ( m_HasBarding && m_BardingExceptional && m_BardingCrafter != null )
				list.Add( 1060853, m_BardingCrafter.Name ); // armor exceptionally crafted by ~1_val~
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version

			writer.Write( (bool) m_BardingExceptional );
			writer.Write( (Mobile) m_BardingCrafter );
			writer.Write( (bool) m_HasBarding );
			writer.Write( (int) m_BardingHP );
			writer.Write( (int) m_BardingResource );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					m_BardingExceptional = reader.ReadBool();
					m_BardingCrafter = reader.ReadMobile();
					m_HasBarding = reader.ReadBool();
					m_BardingHP = reader.ReadInt();
					m_BardingResource = (CraftResource) reader.ReadInt();
					break;
				}
			}

			if ( Hue == 0 && !m_HasBarding )
				Hue = 0x851;

			if ( BaseSoundID == -1 )
				BaseSoundID = 0x16A;
		}
	}
}