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
	[CorpseName( "a dampwood mite corpse" )]
	public class DampwoodMite : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public DampwoodMite() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = "a dampwood mite";
			Body = 736;
                        Hue = 64;

			SetStr( 76, 100 );
			SetDex( 76, 94 );
			SetInt( 36, 59 );

			SetHits( 121, 150 );
			SetMana( 0 );

			SetDamage( 5, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 16 );
			SetResistance( ResistanceType.Poison, 25 );

			SetSkill( SkillName.Poisoning, 60.4, 79.2 );
			SetSkill( SkillName.MagicResist, 25.2, 39.8 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 36.8, 49.9 );
			SetSkill( SkillName.Wrestling, 53.8, 67.1 );

			Fame = 600;
			Karma = -600;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 25.4;

			PackGold( 157, 257 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override Poison HitPoison{ get{ return Poison.Regular; } }

		public override int GetIdleSound() { return 1605; } 
		public override int GetAngerSound() { return 1602; } 
		public override int GetHurtSound() { return 1604; } 
		public override int GetDeathSound() { return 1603; }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new Gold( Utility.RandomMinMax( 125, 175 ) ), from );
                              corpse.AddCarvedItem( new SpiderEgg( Utility.RandomMinMax( 7, 15 ) ), from );
                              corpse.AddCarvedItem( new SpidersSilk( Utility.RandomMinMax( 27, 58 ) ), from );

                              from.SendMessage( "You carve up some spider silk and spider eggs." );
                              corpse.Carved = true; 
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
		                m_Mobile.Hits -= ( Utility.Random( 15, 35 ) );
		                m_Mobile.Stam -= ( Utility.Random( 15, 35 ) );
		                m_Mobile.Mana -= ( Utility.Random( 15, 35 ) );
			}
		}
		#endregion

		public DampwoodMite( Serial serial ) : base( serial )
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