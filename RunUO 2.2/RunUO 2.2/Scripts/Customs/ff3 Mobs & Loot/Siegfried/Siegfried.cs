//Customized By Mrs Death

using System;
using Server.Items;

namespace Server.Mobiles

              {
              [CorpseName( " corpse of Siegfried" )]
              public class Siegfried : BaseCreature
              {
				private Timer m_Timer;
                                 [Constructable]
                                    public Siegfried() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
                            {
                                               
					                           Body = 400;
						                       Female = false; 
						                       Hue = 33779;
						                       Name = "Siegfried";

                                               //Body = 149; // Uncomment these lines and input values
                                               //BaseSoundID = 0x4B0; // To use your own custom body and sound.
                                               SetStr( 3000, 6000 );
                                               SetDex( 2000, 4000 );
                                               SetInt( 1000, 2000 );
                                               SetHits( 20000, 60000 );
                                               SetDamage( 20, 25 );
                                               SetDamageType( ResistanceType.Cold, 10 );
                                               SetDamageType( ResistanceType.Fire, 20 );
                                               SetDamageType( ResistanceType.Energy, 30 );
                                               SetDamageType( ResistanceType.Poison, 40 );

                                               SetResistance( ResistanceType.Physical, 10 );
                                               SetResistance( ResistanceType.Cold, 10 );
                                               SetResistance( ResistanceType.Fire, 10 );
                                               SetResistance( ResistanceType.Energy, 10 );
                                               SetResistance( ResistanceType.Poison, 10 );

			SetSkill( SkillName.Fencing, 10.0, 20.0 );
			SetSkill( SkillName.Macing, 10.0, 20.0 );
			SetSkill( SkillName.MagicResist, 10.0, 20.0 );
			SetSkill( SkillName.Swords, 10.0, 20.0 );
			SetSkill( SkillName.Tactics, 10.0, 20.0 );
			SetSkill( SkillName.Wrestling, 10.0, 20.0 );


			//m_Timer = new TeleportTimer( this );
			//m_Timer.Start();



            Fame = 5000;
            Karma = 10000;
            VirtualArmor = 15;

			PackGold( 15120, 25130 );


	    		LeatherChest chest = new LeatherChest();
            		chest.Hue = 598;
            		chest.Movable = false;
            		AddItem(chest);

            		LeatherArms arms = new LeatherArms();
            		arms.Hue = 598;
            		arms.Movable = false;
            		AddItem(arms);

            		LeatherGloves gloves = new LeatherGloves();
            		gloves.Hue = 598;
            		gloves.Movable = false;
            		AddItem(gloves);

            		LeatherGorget gorget = new LeatherGorget();
            		gorget.Hue = 598;
            		gorget.Movable = false;
            		AddItem(gorget);

            		LeatherCap helm = new LeatherCap();
            		helm.Hue = 598;
            		helm.Movable = false;
            		AddItem(helm);

            		LeatherLegs legs = new LeatherLegs();
            		legs.Hue = 598;
            		legs.Movable = false;
            		AddItem(legs);
			
			Item Shoes = new Shoes(); 
			Shoes.Movable = false;
			Shoes.Hue = 598; 
			AddItem( Shoes );
			
			Item Cloak = new Cloak();
            		Cloak.Hue = 598;
            		Cloak.Movable = false;
            		AddItem( Cloak );

			Item LockeDagger = new LockeDagger();
            		LockeDagger.Hue = 598;
            		LockeDagger.Movable = false;
            		AddItem( LockeDagger );
           



                            }
                                 public override void GenerateLoot()
		{
			switch ( Utility.Random( 30 ))
			{
				case 0: PackItem( new LockeBandana() ); break;
				case 1: PackItem( new LockeDagger() ); break;
				case 2: PackItem( new LockeChest() ); break;
				case 3: PackItem( new LockeLegs() ); break;
				case 4: PackItem( new LockeBuckler() ); break;
				case 5: PackItem( new LockeGorget() ); break;
				case 6: PackItem( new LockeArms() ); break;
				case 7: PackItem( new LockeTGloves() ); break;
				
				
				
		 }
		}
		
		        public override bool HasBreath{ get{ return true ; } }
				public override int BreathFireDamage{ get{ return 11; } }
				public override int BreathColdDamage{ get{ return 11; } }
//                public override bool IsScaryToPets{ get{ return true; } }
				public override bool AutoDispel{ get{ return true; } }
                public override bool BardImmune{ get{ return true; } }
                public override bool Unprovokable{ get{ return true; } }
                public override Poison HitPoison{ get{ return Poison. Lethal ; } }
                public override bool AlwaysMurderer{ get{ return true; } }
//				public override bool IsScaredOfScaryThings{ get{ return false; } }






		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from is BaseCreature )
			{
				BaseCreature bc = (BaseCreature)from;

				if ( bc.Controlled || bc.BardTarget == this )
					damage = 0; // Immune to pets and provoked creatures
			}
		}
		private class TeleportTimer : Timer
		{
			private Mobile m_Owner;

			private static int[] m_Offsets = new int[]
			{
				-1, -1,
				-1,  0,
				-1,  1,
				0, -1,
				0,  1,
				1, -1,
				1,  0,
				1,  1
			};

			public TeleportTimer( Mobile owner ) : base( TimeSpan.FromSeconds( 9.0 ), TimeSpan.FromSeconds( 15.0 ) )
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if ( m_Owner.Deleted )
				{
					Stop();
					return;
				}

				Map map = m_Owner.Map;

				if ( map == null )
					return;

				if ( 0.5 < Utility.RandomDouble() )
					return;

				Mobile toTeleport = null;

				foreach ( Mobile m in m_Owner.GetMobilesInRange( 16 ) )
				{
					if ( m != m_Owner && m.Player && m_Owner.CanBeHarmful( m ) && m_Owner.CanSee( m ) )
					{
						toTeleport = m;
						break;
					}
				}

				if ( toTeleport != null )
				{
					int offset = Utility.Random( 8 ) * 2;

					Point3D to = m_Owner.Location;

					for ( int i = 0; i < m_Offsets.Length; i += 2 )
					{
						int x = m_Owner.X + m_Offsets[(offset + i) % m_Offsets.Length];
						int y = m_Owner.Y + m_Offsets[(offset + i + 1) % m_Offsets.Length];

						if ( map.CanSpawnMobile( x, y, m_Owner.Z ) )
						{
							to = new Point3D( x, y, m_Owner.Z );
							break;
						}
						else
						{
							int z = map.GetAverageZ( x, y );

							if ( map.CanSpawnMobile( x, y, z ) )
							{
								to = new Point3D( x, y, z );
								break;
							}
						}
					}

					Mobile m = toTeleport;

					Point3D from = m.Location;

					m.Location = to;

					Server.Spells.SpellHelper.Turn( m_Owner, toTeleport );
					Server.Spells.SpellHelper.Turn( toTeleport, m_Owner );

					m.ProcessDelta();

					Effects.SendLocationParticles( EffectItem.Create( from, m.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
					Effects.SendLocationParticles( EffectItem.Create(   to, m.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 5023 );

					m.PlaySound( 0x1FE );

					m_Owner.Combatant = toTeleport;
				}
			}
		}


public Siegfried( Serial serial ) : base( serial )
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
