using System;
using System.Collections;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a lizardman ranger corpse" )]
	public class LizardmanRanger : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Lizardman; } }

		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 20.0 ); //the delay between talks is 20 seconds
		public DateTime m_NextTalk;

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public LizardmanRanger() : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = NameList.RandomName( "lizardman" );
			Title = "the Lizardman Ranger"; 
                        Body = 33;
			BaseSoundID = 417;

			SetStr( 132, 148 );
			SetDex( 167, 182 );
			SetInt( 39, 41 );

			SetHits( 225, 350 );

			SetDamage( 3, 6 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 31 );
			SetResistance( ResistanceType.Fire, 7 );
			SetResistance( ResistanceType.Cold, 7 );
			SetResistance( ResistanceType.Poison, 11 );

			SetSkill( SkillName.Archery, 58.1, 74.5 );
			SetSkill( SkillName.MagicResist, 39.6, 58.8 );
			SetSkill( SkillName.Tactics, 59.9, 76.4 );

			Fame = 9000;
			Karma = -9000;

			PackGold( 319, 414 );

			AddItem( new Bow() );
			PackItem( new Arrow( Utility.RandomMinMax( 72, 86 ) ) );

			switch ( Utility.Random( 9 ))
			{
				case 0: PackItem( new Agate() ); break;
				case 1: PackItem( new Beryl() ); break;
				case 2: PackItem( new ChromeDiopside() ); break;
				case 3: PackItem( new FireOpal() ); break;
				case 4: PackItem( new MoonstoneCustom() ); break;
				case 5: PackItem( new Onyx() ); break;
				case 6: PackItem( new Opal() ); break;
				case 7: PackItem( new Pearl() ); break;
				case 8: PackItem( new TurquoiseCustom() ); break;
			}

			if ( Utility.RandomDouble() < 0.01 )
        		PackItem( new BigColourfulMarble() );
		}

		public override bool CanRummageCorpses{ get{ return true; } }

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.5 > Utility.RandomDouble() )
			{
				ShootLightningArrow( from );
				Animate( 31, 5, 1, true, false, 0 );
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

                        if ( 0.5 >= Utility.RandomDouble() )
                        {
			        ShootLightningArrow( attacker );
				Animate( 31, 5, 1, true, false, 0 );
                        }
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

                        if ( 0.5 >= Utility.RandomDouble() )
                        {
			        ShootLightningArrow( defender );
				Animate( 31, 5, 1, true, false, 0 );
                        }
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 10 ) && InLOS( m ) && m is PlayerMobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
				ShootLightningArrow( m );

			        RangePerception = 300;
			        CurrentSpeed = BoostedSpeed;
				this.Combatant = m;

				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 2 ) )
				{
					case 0: Say("**");
						break;
					case 1: Say("**"); 
						break;
				};
			}
		}

//////////////////////////////////////////////////// Shoot Lightning Arrow ////////////////////////////////////////////////////

		#region Randomize
		private static int[] m_ItemID = new int[]
		{
                        8902
		};

		public static int GetRandomItemID()
		{
			return Utility.RandomList( m_ItemID );
		}

		private DateTime m_NextLightningArrow;
		private int m_Thrown;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextLightningArrow )
			{
				ShootLightningArrow( combatant );

				m_Thrown++;

				if ( 0.75 >= Utility.RandomDouble() && (m_Thrown % 2) == 1 ) // 75% chance to quickly shoot another lightning arrow
					m_NextLightningArrow = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
				else
					m_NextLightningArrow = DateTime.Now + TimeSpan.FromSeconds( 15.0 + (10.0 * Utility.RandomDouble()) ); // 15-25 seconds
			}
		}

		public void ShootLightningArrow( Mobile m )
		{
			this.MovingEffect( m, Utility.RandomList( m_ItemID ), 10, 0, false, false );
			this.DoHarmful( m );
			this.PlaySound( 0x20A ); // energy bolt

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
		                m_Mobile.BoltEffect( 0x480 );
				m_Mobile.PlaySound( 0x5CE ); // lightning strike
		                m_Mobile.Hits -= ( Utility.Random( 15, 25 ) );
			}
		}
		#endregion

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs(), from );
                              corpse.AddCarvedItem( new SpinedHides(12), from);
                              corpse.AddCarvedItem( new FishScale( Utility.RandomMinMax( 4, 8 ) ), from );
                              corpse.AddCarvedItem( new SerpentScale( Utility.RandomMinMax( 7, 12 ) ), from );

                              from.SendMessage( "You carve up raw ribs, spined hides, and an assortment of various scales." );
                              corpse.Carved = true; 
			}
                }

		public LizardmanRanger( Serial serial ) : base( serial )
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
