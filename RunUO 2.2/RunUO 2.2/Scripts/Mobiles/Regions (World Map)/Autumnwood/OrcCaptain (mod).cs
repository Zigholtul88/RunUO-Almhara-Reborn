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
	[CorpseName( "an orcish corpse" )]
	public class OrcCaptain : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.WhirlwindAttack;
		}

		[Constructable]
		public OrcCaptain() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "orc" );
			Body = 7;
			BaseSoundID = 0x45A;

			SetStr( 177, 206 );
			SetDex( 91, 109 );
			SetInt( 61, 100 );

			SetHits( 134, 174 );

			SetDamage( 1, 3 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.Anatomy, 57.9, 62.4 );
			SetSkill( SkillName.MagicResist, 71.6, 80.4 );
			SetSkill( SkillName.Poisoning, 57.5, 62.6 );
			SetSkill( SkillName.Tactics, 75.3, 89.2 );
			SetSkill( SkillName.Wrestling, 72.1, 85.1 );

			Fame = 2500;
			Karma = -2500;

			PackGold( 100, 350 );

		        PackItem( new LargeBattleAxe() ); 
		        PackItem( new RingmailChest() ); 
		        PackItem( new ThighBoots() ); 
			PackItem( new OrcHelm() );

			PackItem( new FishScale( Utility.RandomMinMax( 12, 15 ) ) );

			switch ( Utility.Random( 7 ) )
			{
				case 0: PackItem( new Arrow() ); break;
				case 1: PackItem( new Lockpick() ); break;
				case 2: PackItem( new Shaft() ); break;
				case 3: PackItem( new Ribs() ); break;
				case 4: PackItem( new Bandage() ); break;
				case 5: PackItem( new BeverageBottle( BeverageType.Wine ) ); break;
				case 6: PackItem( new Jug( BeverageType.Cider ) ); break;
			}
		}

		public override Poison HitPoison{ get{ return Poison.Lesser; } }
		public override bool CanRummageCorpses{ get{ return true; } }

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.4 > Utility.RandomDouble() )
			{
				ShootGrassWind( from );
			}
		}

		public void ShootGrassWind( Mobile to )
		{
			int damage = 8;
			this.MovingEffect( to, 0x0C4E, 10, 0, false, false );
			this.DoHarmful( to );
			this.PlaySound( 0x32F ); // f_shush
			AOS.Damage( to, this, damage, 100, 0, 0, 0, 0 );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( !IsFanned( attacker ) && 0.05 > Utility.RandomDouble() )
			{
                                attacker.SendMessage( "The orc captain fans you with gas, reducing your resistance to physical attacks." );

		                ResistanceMod mod = new ResistanceMod( ResistanceType.Physical, - 50 );

				attacker.FixedParticles( 0x3779, 10, 30, 0x34, EffectLayer.RightFoot );
				attacker.PlaySound( 0x1E6 );

				// This should be done in place of the normal attack damage.
				//AOS.Damage( attacker, this, Utility.RandomMinMax( 5, 10 ), 0, 0, 0, 100, 0 );

				attacker.AddResistanceMod( mod );
		
				ExpireTimer timer = new ExpireTimer( attacker, mod, TimeSpan.FromSeconds( 10.0 ) );
				timer.Start();
				m_Table[attacker] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		public bool IsFanned( Mobile m )
		{
			return m_Table.Contains( m );
		}

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private ResistanceMod m_Mod;

			public ExpireTimer( Mobile m, ResistanceMod mod, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
				m_Mod = mod;
				Priority = TimerPriority.TwoFiftyMS;
		        }

			protected override void OnTick()
			{
                                m_Mobile.SendMessage( "Your resistance to physical attacks has returned." );
				m_Mobile.RemoveResistanceMod( m_Mod );
				Stop();
				m_Table.Remove( m_Mobile );
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(), from);
                        corpse.AddCarvedItem(new OrcHead(), from);

                        from.SendMessage( "You carve up a raw rib and the creatures head." );
                        corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( m.Player && m.FindItemOnLayer( Layer.Helm ) is OrcishKinMask )
				return false;

			return base.IsEnemy( m );
		}

		public override void AggressiveAction( Mobile aggressor, bool criminal )
		{
			base.AggressiveAction( aggressor, criminal );

			Item item = aggressor.FindItemOnLayer( Layer.Helm );

			if ( item is OrcishKinMask )
			{
				AOS.Damage( aggressor, 50, 0, 100, 0, 0, 0 );
				item.Delete();
				aggressor.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
				aggressor.PlaySound( 0x307 );
			}
		}

		public OrcCaptain( Serial serial ) : base( serial )
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