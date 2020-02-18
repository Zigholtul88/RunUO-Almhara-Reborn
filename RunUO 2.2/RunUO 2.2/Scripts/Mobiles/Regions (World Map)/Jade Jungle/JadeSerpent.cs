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
	[CorpseName( "a jade serpent corpse" )]
	public class JadeSerpent : BaseCreature
	{
		[Constructable]
		public JadeSerpent() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
			Name = "a jade serpent";
			Body = 0x15;
			Hue = 2966;
			BaseSoundID = 219;

			SetStr( 197, 225 );
			SetDex( 76, 91 );
			SetInt( 34, 51 );

			SetHits( 135, 165 );
			SetMana( 0 );

			SetDamage( 1, 4 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Energy, 30 );

			SetResistance( ResistanceType.Physical, 38 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 70 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.MagicResist, 48.8, 59.5 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 1500;
			Karma = -1500;

			if ( 0.15 > Utility.RandomDouble() )
				PackItem( new Jade() );
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
						if ( weapon1 is BaseKnife )
						{
							damage *= 2;
						}
						else if ( weapon1 is BaseSpear )
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
						if ( weapon2 is BaseKnife )
						{
							damage *= 2;
						}
						else if ( weapon2 is BaseSpear )
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

		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override bool DeathAdderCharmable{ get{ return true; } }

		public override bool HasBreath{ get{ return true; } } // glass breath enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x5738; } }
		public override int BreathEffectSound{ get{ return 0x38E; } } // glasbrk2
		public override int BreathAngerSound{ get{ return 219; } } // anger sound

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs(4), from );
                              corpse.AddCarvedItem( new SpinedHides(15), from );
                              corpse.AddCarvedItem( new SerpentScale( Utility.RandomMinMax( 9, 15 ) ), from );
                              corpse.AddCarvedItem( new SerpentineJade(), from );

                              from.SendMessage( "You carve up raw ribs, spined hides, serpent scales and a piece of serpentine jade." ); 
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

                                AOS.Damage( m, Utility.RandomMinMax( 8, 12 ), 0, 0, 0, 0, 100 );

		                m.BoltEffect( 0x480 );

                                if ( m.Alive && m.Body.IsHuman && !m.Mounted )
                                    m.Animate( 20, 7, 1, true, false, 0 ); // take hit
                        }
                }

		public JadeSerpent(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			if ( BaseSoundID == -1 )
				BaseSoundID = 219;
		}
	}
}