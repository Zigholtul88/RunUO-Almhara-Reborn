using System;
using Server;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Targeting;
using Server.Misc;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "an ophidian corpse" )]
	public class OphidianMentalist : BaseCreature
	{
		[Constructable]
		public OphidianMentalist() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ophidian" );
			Title = "the ophidian mentalist";
			Body = 87;
			BaseSoundID = 644;

			SetStr( 183, 204 );
			SetDex( 191, 213 );
			SetInt( 97, 120 );

			SetHits( 218, 246 );
			SetMana( 485, 600 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 35 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.EvalInt, 40.4, 63.6 );
			SetSkill( SkillName.Magery, 87.9, 98.9 );
			SetSkill( SkillName.MagicResist, 84.4, 88.0 );
			SetSkill( SkillName.Tactics, 72.9, 78.0 );
			SetSkill( SkillName.Wrestling, 35.2, 61.6 );

			Fame = 4000;
			Karma = -4000;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 30.5;

			PackGold( 27, 31 );
			PackReg( 5, 15 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new BladeSpiritsScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );
			AddLoot( LootPack.LowScrolls, 2 );
		}

		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(), from);
                        corpse.AddCarvedItem(new SerpentScale( Utility.RandomMinMax( 11, 16 )), from);
                        corpse.AddCarvedItem(new OphidianEye(), from);

                        from.SendMessage( "You carve up raw ribs, serpent scales, and an ophidian eye." ); 
			}
                }

		private DateTime m_LastRadiated;
	        private Hashtable m_Mobiles = new Hashtable();

		protected override bool OnMove( Direction d )
		{
			if ( !IsDeadBondedPet )
			{
				if ( m_LastRadiated <= DateTime.Now )
					m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 2 ) );
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
					m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 2 ) );
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

			if ( this != m && m.Player && m.Alive && m_LastRadiated <= DateTime.Now && Server.Spells.SpellHelper.ValidIndirectTarget( m, this ) && CanBeBeneficial( m, false, false ) )
			{
	                        AOS.Damage( m, this, 0, 0, 0, 0, 0, 0, true );
		                m.Mana += ( Utility.Random( 10, 40 ) );

		                m.FixedParticles( 0x375A, 1, 30, 1926, 88, 2, EffectLayer.Head ); 
           	                m.FixedParticles( 0x37B9, 1, 30, 1927, 85, 3, EffectLayer.Head );
		                m.FixedParticles( 0x376A, 1, 31, 1930, 80, 0, EffectLayer.Waist );
           	                m.FixedParticles( 0x37C4, 1, 31, 1757, 88, 2, EffectLayer.Waist );
				m.PlaySound( 0x202 );

				DoBeneficial( m );
				m.RevealingAction();
				m.SendMessage( "The ophidian mentalist's aura slowly regenerates mana as you stand near it!" );
				m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 5, 5 ) );
			}
		}

		public OphidianMentalist( Serial serial ) : base( serial )
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