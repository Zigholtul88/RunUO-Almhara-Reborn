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
	[CorpseName( "a terathan matriarch corpse" )]
	public class TerathanMatriarch : BaseCreature
	{
		[Constructable]
		public TerathanMatriarch() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "terathan" );
			Title = "the terathan matriarch"; 
			Body = 72;
			BaseSoundID = 599;

			SetStr( 316, 405 );
			SetDex( 96, 115 );
			SetInt( 366, 455 );

			SetHits( 4380, 5486 );
			SetMana( 1050, 1150 );

			SetDamage( 11, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45 );
			SetResistance( ResistanceType.Fire, -50 );
			SetResistance( ResistanceType.Cold, 35 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 90.1, 100.0 );
			SetSkill( SkillName.Tactics, 50.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 80.0 );

			Fame = 60000;
			Karma = -60000;

			PackReg( 15, 35 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new EnergyVortexScroll() );

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 12, 19 ) ) );
			pack.DropItem( new Peach( Utility.RandomMinMax( 5, 9 ) ) );

			PackItem( pack );

			switch ( Utility.Random( 7 ) )
			{
				case 0: PackItem( new BreadLoaf() ); break;
				case 1: PackItem( new ApplePie() ); break;
				case 2: PackItem( new Cake() ); break;
				case 3: PackItem( new Muffins() ); break;
				case 4: PackItem( new Coconut() ); break;
				case 5: PackItem( new IrishSpirit() ); break;
				case 6: PackItem( new MontoyaRock() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 15 );
			AddLoot( LootPack.Potions, 5 );
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from != null && from != this )
			{
				if ( from is PlayerMobile )
				{
					PlayerMobile p_PlayerMobile = from as PlayerMobile;
					Item weapon1 = p_PlayerMobile.FindItemOnLayer( Layer.OneHanded );
					Item weapon2 = p_PlayerMobile.FindItemOnLayer( Layer.TwoHanded );

					if ( weapon1 != null )
					{
						if ( weapon1 is BaseBashing )
						{
							damage *= 2;
						}
						else if ( weapon1 is BaseStaff )
						{
							damage *= 4;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseBashing )
						{
							damage *= 2;
						}
						else if ( weapon2 is BaseStaff )
						{
							damage *= 4;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
				}
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs(4), from );
                              corpse.AddCarvedItem( new SpidersSilk( Utility.RandomMinMax( 12, 27 ) ), from );
                              corpse.AddCarvedItem( new SpiderEgg( Utility.RandomMinMax( 26, 37 ) ), from );
                              corpse.AddCarvedItem( new TerathanEye(), from );

                              from.SendMessage( "You carve up some raw ribs, spider silk, spider eggs, and a terathan eye." ); 
			}
                }

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.5 > Utility.RandomDouble() )
			{
				ThrowWeb( from );
				Animate( 18, 5, 1, true, false, 0 );
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

                        if (0.5 >= Utility.RandomDouble())
		                ThrowWeb( attacker );
				Animate( 18, 5, 1, true, false, 0 );
		}

                public override void OnGaveMeleeAttack( Mobile defender )
                {
                        base.OnGaveMeleeAttack( defender );

                        if (0.5 >= Utility.RandomDouble())
		                ThrowWeb( defender );
				Animate( 18, 5, 1, true, false, 0 );
                }

//////////////////////////////////////////////////// Throw Web ////////////////////////////////////////////////////

		#region Randomize
		private static int[] m_ItemID = new int[]
		{
                        3811, 3812, 3813, 3814
		};

		public static int GetRandomItemID()
		{
			return Utility.RandomList( m_ItemID );
		}

		private DateTime m_NextWeb;
		private int m_Thrown;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextWeb )
			{
				ThrowWeb( combatant );

				m_Thrown++;

				if ( 0.75 >= Utility.RandomDouble() && (m_Thrown % 2) == 1 ) // 75% chance to quickly throw another piece of web
					m_NextWeb = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
				else
					m_NextWeb = DateTime.Now + TimeSpan.FromSeconds( 15.0 + (10.0 * Utility.RandomDouble()) ); // 15-25 seconds
			}
		}

		public void ThrowWeb( Mobile m )
		{
			this.MovingEffect( m, Utility.RandomList( m_ItemID ), 10, 0, false, false );
			this.DoHarmful( m );
			this.PlaySound( 0x382 ); // giant_snail1

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
				m_Mobile.PlaySound( 0x025 ); // splash01
		                m_Mobile.Hits -= ( Utility.Random( 1, 25 ) );
		                m_Mobile.Stam -= ( Utility.Random( 1, 25 ) );
		                m_Mobile.Mana -= ( Utility.Random( 1, 25 ) );
			}
		}
		#endregion

                public void AwardDungeonBossKey()
                {
                      List<Mobile> list = new List<Mobile>();

                      foreach ( Mobile m in GetMobilesInRange( 20 ) )
                      {
                             if ( !CanBeHarmful ( m ) )
                             continue;

                             if ( m.Player )
                             list.Add ( m );
                      }

                      foreach ( Mobile m in list )
                      {
                             if ( m == this || !CanBeHarmful( m ) )
                             continue;

                             if ( !m.Player && !( m is BaseCreature && ( (BaseCreature)m).ControlMaster.Player) )
                             continue;

                          if ( m.Player && m.Alive )
                          {
			       m.AddToBackpack( new AgurastAscensionBossKey() );
                               m.SendMessage( "You receive a key needed to get pass the fog gates." );
                               DoHarmful( m );
                          }
                     }
                }

		public override bool OnBeforeDeath( ) //what happens before it dies
		{
		      AwardDungeonBossKey();
                      return base.OnBeforeDeath();
		}

		public TerathanMatriarch( Serial serial ) : base( serial )
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