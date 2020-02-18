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
	[CorpseName( "the corpse of Puddles" )]
	public class Puddles : BaseCreature
	{
		[Constructable]
		public Puddles() : base( AIType.AI_Melee, FightMode.Aggressor, 5, 1, 0.175, 0.350 )
		{
			Name = "Puddles";
			Body = 51;
			BaseSoundID = 456;
			Hue = 163;

			SetStr( 12, 17 );
			SetDex( 9, 14 );
			SetInt( 5, 8 );

			SetHits( 500 );

			SetDamage( 3, 6 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5 );
			SetResistance( ResistanceType.Poison, 100 );

			SetSkill( SkillName.MagicResist, 50.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 10000;
			Karma = -10000;

			PackReg( 500, 1000 );
		}

                public override bool OnBeforeDeath()
                {
                        this.Say("Oh you gotta be kidding me!");

                        return base.OnBeforeDeath();
                }

		public override bool CanRummageCorpses{ get{ return true; } }

		public override bool HasBreath{ get{ return true; } } // green sludge enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 25.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 163; } }
		public override int BreathEffectItemID{ get{ return 0x113E; } }
		public override int BreathEffectSound{ get{ return 0x1CA; } }
		public override int BreathAngerSound{ get{ return 0x0C9; } }

		public override void OnDamagedBySpell( Mobile attacker )
		{
			base.OnDamagedBySpell( attacker );

			DoCounter( attacker );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoCounter( attacker );
		}

		private void DoCounter( Mobile attacker )
		{
			if( this.Map == null )
				return;

			if ( attacker is BaseCreature && ((BaseCreature)attacker).BardProvoked )
				return;

			if ( 0.2 > Utility.RandomDouble() )
			{
				/* Counterattack with Hit Poison Area
				 * 5-10 damage, unresistable
				 * Lesser poison, 100% of the time
				 * Particle effect: Type: "2" From: "0x4061A107" To: "0x0" ItemId: "0x36BD" ItemIdName: "explosion" FromLocation: "(296 615, 17)" ToLocation: "(296 615, 17)" Speed: "1" Duration: "10" FixedDirection: "True" Explode: "False" Hue: "0xA6" RenderMode: "0x0" Effect: "0x1F78" ExplodeEffect: "0x1" ExplodeSound: "0x0" Serial: "0x4061A107" Layer: "255" Unknown: "0x0"
				 * Doesn't work on provoked monsters
				 */

				Mobile target = null;

				if ( attacker is BaseCreature )
				{
					Mobile m = ((BaseCreature)attacker).GetMaster();
					
					if( m != null )
						target = m;
				}

				if ( target == null || !target.InRange( this, 18 ) )
					target = attacker;

				this.Animate( 10, 4, 1, true, false, 0 );

				ArrayList targets = new ArrayList();

				foreach ( Mobile m in target.GetMobilesInRange( 8 ) )
				{
					if ( m == this || !CanBeHarmful( m ) )
						continue;

					if ( m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team) )
						targets.Add( m );
					else if ( m.Player && m.Alive )
						targets.Add( m );
				}

				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];

					DoHarmful( m );

					AOS.Damage( m, this, Utility.RandomMinMax( 5, 10 ), true, 0, 0, 0, 100, 0 );

					m.FixedParticles( 0x36BD, 1, 10, 0x1F78, 0xA6, 0, (EffectLayer)255 );
					m.ApplyPoison( this, Poison.Lesser );
				}
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new GreenSlimeVial( amount ), from );

                              from.SendMessage( "You carve up the corpse and notice a vial of green slime." );
                              corpse.Carved = true; 
			}
                }

		public Puddles( Serial serial ) : base( serial )
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

		private DateTime m_NextDrop = DateTime.Now;

		public virtual void DropOoze()
		{
			int amount = Utility.RandomMinMax( 1, 3 );
			bool corrosive = Utility.RandomBool();

			for( int i = 0; i < amount; i++ )
			{
				Item ooze = new AcidicOoze( corrosive );
				Point3D p = new Point3D( Location );

				for( int j = 0; j < 5; j++ )
				{
					p = GetSpawnPosition( 2 );
					bool found = false;

					foreach( Item item in Map.GetItemsInRange( p, 0 ) )
						if( item is AcidicOoze )
						{
							found = true;
							break;
						}

					if( !found )
						break;
				}

				ooze.MoveToWorld( p, Map );
			}

			if( Combatant != null )
			{
				if( corrosive )
					Combatant.SendLocalizedMessage( 1072071 ); // A corrosive gas seeps out of your enemy's skin!
				else
					Combatant.SendLocalizedMessage( 1072072 ); // A poisonous gas seeps out of your enemy's skin!
			}
		}

		private int RandomPoint( int mid )
		{
			return ( mid + Utility.RandomMinMax( -2, 2 ) );
		}

		public virtual Point3D GetSpawnPosition( int range )
		{
			return GetSpawnPosition( Location, Map, range );
		}

		public virtual Point3D GetSpawnPosition( Point3D from, Map map, int range )
		{
			if( map == null )
				return from;

			Point3D loc = new Point3D( ( RandomPoint( X ) ), ( RandomPoint( Y ) ), Z );

			loc.Z = Map.GetAverageZ( loc.X, loc.Y );

			return loc;
		}
	}

	public class AcidicOoze : Item
	{
		private bool m_Corrosive;

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Corrosive
		{
			get { return m_Corrosive; }
			set { m_Corrosive = value; }
		}

		[Constructable]
		public AcidicOoze(): this(false)
		{
		}

		[Constructable]
		public AcidicOoze(bool corrosive): base(0x122A)
		{
			Movable = false;
			Hue = 0x95;

			m_Corrosive = corrosive;
			Timer.DelayCall(TimeSpan.FromSeconds(30), new TimerCallback(Morph));
		}

		private Hashtable m_Table;

		public override bool OnMoveOver(Mobile m)
		{
			if( m != null && !m.Deleted )
			{
				if( m_Table == null )
				{
					m_Table = new Hashtable();
				}

				if( ( m is BaseCreature && ( (BaseCreature)m ).Controlled ) || m.Player )
				{
					m_Table[ m ] = Timer.DelayCall( TimeSpan.FromSeconds( 1 ), TimeSpan.FromSeconds( 1 ), new TimerStateCallback( Damage_Callback ), m );
				}
			}
			return base.OnMoveOver( m );
		}

		public override bool OnMoveOff(Mobile m)
		{
			if (m_Table == null)
				m_Table = new Hashtable();

			if (m_Table[m] is Timer)
			{
				Timer timer = (Timer)m_Table[m];

				timer.Stop();

				m_Table[m] = null;
			}

			return base.OnMoveOff(m);
		}

		public AcidicOoze(Serial serial): base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version

			writer.Write((bool)m_Corrosive);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			m_Corrosive = reader.ReadBool();
		}

		private void Damage_Callback(object state)
		{
			if (state is Mobile)
				Damage((Mobile)state);
		}

		/* Ode to ASayre .. perhaps a lil voodoo  will summon his ghost :D  */

		private bool DamageSelector( ref bool z, ref int hp, ref int mhp ) 
		{
			return ( ( ( mhp -= ( z ) ? ( ( mhp > 10 ) ? 10 : 1 ) : 0 ) > 0 ) && ( hp -= ( ( z ) ? 0 : ( ( hp > 10 ) ? 10 : 1 ) ) ) > 0 );
		}

		private bool ValidMobile( Mobile m )
		{
			return ( !m.Deleted && m.Alive && m.AccessLevel == AccessLevel.Player );
		}

		private bool IsUsingDurability( IDurability item )
		{
			return ( (item.HitPoints + item.MaxHitPoints ) > 0 );
		}

		private IDurability ValidDurabilityEquipment( Mobile m, Item item )
		{
			return ( ( item != null && !item.Deleted && item.Parent == m && item is IDurability ) ? item as IDurability : null );
		}

		public virtual void Damage( Mobile m )
		{
			if( m == null || m.Deleted || !m.Alive || m.Map == null || m.Map == Map.Internal ) /* cant have that happen again */
			{
				StopTimer( m );
			}
			else
			{
				if( ValidMobile( m ) )
				{
					if( m_Corrosive && ( m.Items.Count > 0 ) )
					{
						for( int i = 0; i < m.Items.Count; i++ )
						{
							Item m_Item; IDurability item = ValidDurabilityEquipment( m, ( m_Item = m.Items[ i ] as Item ) );

							if( item != null && ( IsUsingDurability( item ) ) && ( Utility.RandomDouble() < 0.25 ) )
							{
								int hp; bool z = ( ( hp = item.HitPoints ) < 1 ); int mhp = item.MaxHitPoints;

								if( !( DamageSelector( ref z, ref hp, ref mhp ) ) && z )
								{
									m.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1061121 ); // Your equipment is severely damaged.

									if( ( item.MaxHitPoints = mhp ) < 1 )
									{
										m_Item.Delete();
									}
								}

								item.HitPoints = hp;
							}
						}
					}
					else
					{
						AOS.Damage( m, 0, 0, 0, 0, 100, 0 );
					}
				}
				else
				{
					StopTimer( m );
				}
			}
		}

		public virtual void Morph()
		{
			ItemID += 1;

			Timer.DelayCall(TimeSpan.FromSeconds(5), new TimerCallback(Decay));
		}

		public virtual void StopTimer(Mobile m)
		{
			if (m_Table[m] is Timer)
			{
				Timer timer = (Timer)m_Table[m];
				timer.Stop();
				m_Table[m] = null;
			}
		}

		public virtual void Decay()
		{
			if (m_Table == null)
				m_Table = new Hashtable();

			foreach (DictionaryEntry entry in m_Table)
				if (entry.Value is Timer)
					((Timer)entry.Value).Stop();

			m_Table.Clear();

			Delete();
		}
	}
}

