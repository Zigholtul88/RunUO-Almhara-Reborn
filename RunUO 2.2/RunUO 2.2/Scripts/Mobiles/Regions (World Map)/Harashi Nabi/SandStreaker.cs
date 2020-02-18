using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a sand streaker corpse" )]
	public class SandStreaker : BaseCreature
	{
		[Constructable]
		public SandStreaker() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a sand streaker";
			Body = 718;
                        Hue = 853;

			SetStr( 51, 69 );
			SetDex( 78, 83 );
			SetInt( 19, 32 );

			SetHits( 78, 112 );

			SetDamage( 3, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 8 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.MagicResist, 19.9, 27.3 );
			SetSkill( SkillName.Tactics, 46.8, 48.8 );
			SetSkill( SkillName.Wrestling, 43.7, 51.4 );

			Fame = 600;
			Karma = -600;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 8.9;

			PackReg( 50, 100 );

			if ( 0.10 > Utility.RandomDouble() )
				PackItem( new Carrot() );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override int GetAttackSound() { return 1513; } 
		public override int GetAngerSound() { return 1558; } 
		public override int GetDeathSound() { return 1514; } 
		public override int GetHurtSound() { return 1515; } 
		public override int GetIdleSound() { return 1516; } 

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(9), from);
                              corpse.AddCarvedItem(new SandStreakerWings(), from);

                              from.SendMessage( "You carve up some raw ribs and a pair of sand streaker wings." );
                              corpse.Carved = true; 
			}
                }

		private DateTime m_NextAttack;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextAttack )
			{
				SandAttack( combatant );
				m_NextAttack = DateTime.Now + TimeSpan.FromSeconds( 10.0 + (10.0 * Utility.RandomDouble()) );
			}
		}

		public void SandAttack( Mobile m )
		{
			DoHarmful( m );

			m.FixedParticles( 0x36B0, 10, 25, 9540, 2413, 0, EffectLayer.Waist );

			new InternalTimer( m, this ).Start();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile, m_From;

			public InternalTimer( Mobile m, Mobile from ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				m_Mobile.PlaySound( 0x4CF );
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 1, 20 ), 90, 10, 0, 0, 0 );
			}
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.HarashiNabiPredator; }
		}

		public SandStreaker( Serial serial ) : base( serial )
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