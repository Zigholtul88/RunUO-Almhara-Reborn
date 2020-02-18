using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a bronze weevil corpse" )]
	public class BronzeWeevil : BaseCreature
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

                private static readonly int[] m_North = new int[]
                {
                       -1, -1,
                        1, -1,
                       -1, 2,
                        1, 2
                };
                private static readonly int[] m_East = new int[]
                {
                       -1, 0,
                        2, 0
                };

		[Constructable]
		public BronzeWeevil() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a bronze weevil";
			Body = 807;
                        Hue = 1126;

			SetStr( 122, 154 );
			SetDex( 92, 122 );
			SetInt( 89, 111 );

			SetHits( 115, 135 );
			SetMana( 445, 555 );

			SetDamage( 1, 3 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25 );
			SetResistance( ResistanceType.Fire, -25 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Healing, 45.8, 60.2 );
			SetSkill( SkillName.MagicResist, 39.1, 51.3 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 1500;
			Karma = -1500;

			PackGold( 76, 165 );
			PackReg( 15, 50 );
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

                public override void OnThink()
                {
                        base.OnThink();

                        SparkleRing();
                }

                public virtual void SparkleRing()
                {
                        for (int i = 0; i < m_North.Length; i += 2)
                        {
                                Point3D p = Location;

                                p.X += m_North[i];
                                p.Y += m_North[i + 1];

                                IPoint3D po = p as IPoint3D;

                                SpellHelper.GetSurfaceTop(ref po);

                                Effects.SendLocationEffect(po, Map, 0x373A, 50);
                        }

                        for (int i = 0; i < m_East.Length; i += 2)
                        {
                                Point3D p = Location;

                                p.X += m_East[i];
                                p.Y += m_East[i + 1];

                                IPoint3D po = p as IPoint3D;

                                SpellHelper.GetSurfaceTop(ref po);

                                Effects.SendLocationEffect(po, Map, 0x375A, 50);
                        }
                }

		public override int GetAngerSound() { return 0x21D; } 
		public override int GetIdleSound() { return 0x21D; } 
		public override int GetAttackSound() { return 0x162; } 
		public override int GetHurtSound() { return 0x163; } 
		public override int GetDeathSound() { return 0x21D; }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanRummageCorpses{ get{ return true; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 3, 8 )), from);
                              corpse.AddCarvedItem(new BronzeWeevilEgg(), from);

                              from.SendMessage( "You carve up some gold and a bronze weevil egg." );
                              corpse.Carved = true; 
			}
                }

	        public override void OnDamagedBySpell( Mobile attacker )
	        {
		        base.OnDamagedBySpell( attacker );

                        if ( 0.8 >= Utility.RandomDouble() )
                        this.Lightning();
	        }

                public override void OnGaveMeleeAttack( Mobile defender )
                {
                        base.OnGaveMeleeAttack( defender );

                        if ( 0.8 >= Utility.RandomDouble() )
                        this.Lightning();
                }

                public override void OnGotMeleeAttack( Mobile attacker )
	        {
		        base.OnGotMeleeAttack( attacker );

		        if ( 0.8 >= Utility.RandomDouble() )
                        this.Lightning();
	        }

                public void Lightning()
                {
                        Map map = this.Map;

                        if ( map == null )
                            return;

                        ArrayList targets = new ArrayList();

                        foreach ( Mobile m in this.GetMobilesInRange( 15 ) )
                        {
                                 if ( m == this || !this.CanBeHarmful( m ) )
                                 continue;

                                 if ( m is BaseCreature && ( ( ( BaseCreature )m ).Controlled || ( ( BaseCreature )m ).Summoned || ( ( BaseCreature )m ).Team != this.Team ) )
                                      targets.Add( m );
                                 else if ( m.Player )
                                      targets.Add( m );
                        }

                        this.PlaySound( 41 );

                        for ( int i = 0; i < targets.Count; ++i )
                        {
                                Mobile m = ( Mobile )targets[i];

                                this.DoHarmful( m );

                                AOS.Damage( m, Utility.RandomMinMax( 5, 10 ), 0, 0, 0, 0, 100 );

		                m.BoltEffect( 0x480 );

                                if ( m.Alive && m.Body.IsHuman && !m.Mounted )
                                    m.Animate( 20, 7, 1, true, false, 0 ); // take hit
                        }
                }

		public BronzeWeevil( Serial serial ) : base( serial )
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