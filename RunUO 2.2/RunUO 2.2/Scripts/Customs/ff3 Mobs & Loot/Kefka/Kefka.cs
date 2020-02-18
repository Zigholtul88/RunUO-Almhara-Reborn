//Customized By Mrs Death

using System;
using Server.Items;

namespace Server.Mobiles

              {
              [CorpseName( " corpse of Kefka" )]
              public class Kefka : BaseCreature
              {
				private Timer m_Timer;
                                 [Constructable]
                                    public Kefka() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
                            {
                                               
					                           Body = 400;
						                       Female = false; 
						                       Hue = 33779;
						                       Title = "Kefka";
								       HairItemID = 8253;
								       HairHue = 1169;
                                               //Body = 149; // Uncomment these lines and input values
                                               //BaseSoundID = 0x4B0; // To use your own custom body and sound.
                                               SetStr( 3000, 6000 );
                                               SetDex( 2000, 4000 );
                                               SetInt( 1000, 2000 );
                                               SetHits( 100000, 300000 );
                                               SetDamage( 20, 25 );
                                               SetDamageType( ResistanceType.Cold, 199 );
                                               SetDamageType( ResistanceType.Fire, 199 );
                                               SetDamageType( ResistanceType.Energy, 199 );
                                               SetDamageType( ResistanceType.Poison, 199 );

                                               SetResistance( ResistanceType.Physical, 60 );
                                               SetResistance( ResistanceType.Cold, 70 );
                                               SetResistance( ResistanceType.Fire, 70 );
                                               SetResistance( ResistanceType.Energy, 70 );
                                               SetResistance( ResistanceType.Poison, 70 );

			SetSkill( SkillName.Fencing, 100.0, 120.0 );
			SetSkill( SkillName.Macing, 100.0, 120.0 );
			SetSkill( SkillName.MagicResist, 100.0, 120.0 );
			SetSkill( SkillName.Swords, 100.0, 120.0 );
			SetSkill( SkillName.Tactics, 100.0, 120.0 );
			SetSkill( SkillName.Wrestling, 100.0, 120.0 );


			//m_Timer = new TeleportTimer( this );
			//m_Timer.Start();



            Fame = 5000;
            Karma = 5000;
            VirtualArmor = 65;

			PackGold( 55120, 56130 );


			

			Item FancyShirt = new FancyShirt(); 
			FancyShirt.Movable = false;
			FancyShirt.Hue = 38; 
			AddItem( FancyShirt );

			Item LongPants = new LongPants(); 
			LongPants.Movable = false;
			LongPants.Hue = 38; 
			AddItem( LongPants );

			Item Cloak = new Cloak();
            		Cloak.Hue = 1271;
            		Cloak.Movable = false;
            		AddItem( Cloak );

			Item JinBaori = new JinBaori();
			JinBaori.Movable = false;
			JinBaori.Hue = 1271;
			AddItem( JinBaori );
			
			Item Shoes = new Shoes(); 
			Shoes.Movable = false;
			Shoes.Hue = 348; 
			AddItem( Shoes );
           


                            }
                                 public override void GenerateLoot()
		{
			switch ( Utility.Random( 30 ))
			{
				case 0: PackItem( new MogGorget() ); break;
				case 1: PackItem( new MogSandals() ); break;
				case 2: PackItem( new MogArms() ); break;
				case 3: PackItem( new MogChest() ); break;
				case 4: PackItem( new MogGloves() ); break;
				case 5: PackItem( new MogHelm() ); break;
				case 6: PackItem( new MogLegs() ); break;
				case 7: PackItem( new MogRing() ); break;
				case 8: PackItem( new MogBrace() ); break;
				case 9: PackItem( new MogSkirt() ); break;
				case 10: PackItem( new MogApron() ); break;
				case 11: PackItem( new MogCloak() ); break;
				case 12: PackItem( new MogRobe() ); break;
				case 13: PackItem( new MogSash() ); break;
				case 14: PackItem( new MogShirt() ); break;
				case 15: PackItem( new MogEarrings() ); break;
				
				
				
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


public Kefka( Serial serial ) : base( serial )
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
