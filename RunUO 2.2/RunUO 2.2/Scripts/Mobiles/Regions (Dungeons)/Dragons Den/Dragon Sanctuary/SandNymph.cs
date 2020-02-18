using System;
using Server.Engines.Plants;

namespace Server.Mobiles
{
	[CorpseName( "a sand nymph's corpse" )]
	public class SandNymph : BaseCreature
	{
		public override bool InitialInnocent { get { return true; } }

		public override OppositionGroup OppositionGroup
		{
			get { return OppositionGroup.FeyAndUndead; }
		}

		[Constructable]
		public SandNymph() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "a sand nymph";
			Body = 266;
			BaseSoundID = 0x57B;
                        Hue = 1864;

			SetStr( 132, 149 );
			SetDex( 152, 168 );
			SetInt( 251, 280 );

			SetHits( 304, 321 );

			SetDamage( 11, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.Meditation, 80.0, 90.0 );
			SetSkill( SkillName.EvalInt, 70.0, 80.0 );
			SetSkill( SkillName.Magery, 70.0, 80.0 );
			SetSkill( SkillName.Anatomy, 0 );
			SetSkill( SkillName.MagicResist, 100.0, 120.0 );
			SetSkill( SkillName.Tactics, 70.0, 80.0 );
			SetSkill( SkillName.Wrestling, 70.0, 80.0 );

			Fame = 45000;
			Karma = 45000;

			if ( Core.ML && Utility.RandomDouble() < .60 )
				PackItem( Seed.RandomPeculiarSeed( 1 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.MlRich );
		}

		public override int Meat { get { return 1; } }

		public override void OnThink()
		{
			base.OnThink();

			AreaPeace();
			AreaUndress();
		}

		#region Area Peace
		private DateTime m_NextPeace;

		public void AreaPeace()
		{
			if ( Combatant == null || Deleted || !Alive || m_NextPeace > DateTime.Now || 0.1 < Utility.RandomDouble() )
				return;

			TimeSpan duration = TimeSpan.FromSeconds( Utility.RandomMinMax( 20, 80 ) );

			foreach ( Mobile m in GetMobilesInRange( RangePerception ) )
			{
				PlayerMobile p = m as PlayerMobile;

				if ( IsValidTarget( p ) )
				{
					p.PeacedUntil = DateTime.Now + duration;
					p.SendLocalizedMessage( 1072065 ); // You gaze upon the dryad's beauty, and forget to continue battling!
					p.FixedParticles( 0x376A, 1, 20, 0x7F5, EffectLayer.Waist );
					p.Combatant = null;
				}
			}

			m_NextPeace = DateTime.Now + TimeSpan.FromSeconds( 10 );
			PlaySound( 0x1D3 );
		}

		public bool IsValidTarget( PlayerMobile m )
		{
			if ( m != null && m.PeacedUntil < DateTime.Now && !m.Hidden && m.AccessLevel == AccessLevel.Player && CanBeHarmful( m ) )
				return true;

			return false;
		}
		#endregion

		#region Undress
		private DateTime m_NextUndress;

		public void AreaUndress()
		{
			if ( Combatant == null || Deleted || !Alive || m_NextUndress > DateTime.Now || 0.005 < Utility.RandomDouble() )
				return;

			foreach ( Mobile m in GetMobilesInRange( RangePerception ) )
			{
				if ( m != null && m.Player && !m.Female && !m.Hidden && m.AccessLevel == AccessLevel.Player && CanBeHarmful( m ) )
				{
					UndressItem( m, Layer.OuterTorso );
					UndressItem( m, Layer.InnerTorso );
					UndressItem( m, Layer.MiddleTorso );
					UndressItem( m, Layer.Pants );
					UndressItem( m, Layer.Shirt );

			                m.SendMessage( "The sand nymph's beauty makes your blood race. Your clothing is too confining." );
				}
			}

			m_NextUndress = DateTime.Now + TimeSpan.FromMinutes( 1 );
		}

		public void UndressItem( Mobile m, Layer layer )
		{
			Item item = m.FindItemOnLayer( layer );

			if ( item != null && item.Movable )
				m.PlaceInBackpack( item );
		}
		#endregion

		public override bool ReacquireOnMovement{ get{ return true; } }

		public SandNymph( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
