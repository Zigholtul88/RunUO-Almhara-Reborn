using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an ettins corpse" )]
	public class Ettin : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}

		[Constructable]
		public Ettin() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
			Name = "an ettin";
			Body = Utility.RandomList( 2, 18 );
			BaseSoundID = 367;

   			if ( Body == 18 ) //Hammer 
   			{
  				DamageMin += 5;
   				DamageMax += 10;
   				RawStr += 100;
   				RawDex -= 25;
				Skills.Macing.Base += 80;
   			}

			SetStr( 136, 163 );
			SetDex( 56, 74 );
			SetInt( 31, 54 );

			SetHits( 164, 198 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 38 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.MagicResist, 42.3, 52.9 );
			SetSkill( SkillName.Tactics, 50.7, 67.8 );
			SetSkill( SkillName.Wrestling, 75.5, 83.3 );

			Fame = 3000;
			Karma = -3000;

			PackGold( 217, 219 );
			PackItem( new Arrow( Utility.RandomMinMax( 5, 8 ) ) ); 

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new ProtectionScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }

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
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 1, 30 ), 90, 10, 0, 0, 0 );
			}
		}

		public override void OnGaveMeleeAttack( Mobile defender ) 
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.2 > Utility.RandomDouble() )
			{
				defender.FixedEffect( 0x37B9, 10, 5 );
                                defender.SendMessage( "You are frozen as the spear fighter laughs maniacally." );
			        defender.PlaySound( 0x529 ); // tengu_idle03

				defender.Paralyze( TimeSpan.FromSeconds( 5.0 ) );
 			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(4), from);
                              corpse.AddCarvedItem(new EttinTooth(), from);

                              from.SendMessage( "You carve up some raw ribs and an ettin tooth." );
                              corpse.Carved = true; 
			}
                }

		public Ettin( Serial serial ) : base( serial )
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
