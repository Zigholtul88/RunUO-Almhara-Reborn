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
	[CorpseName( "an ophidian corpse" )]
	public class OphidianJusticar : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ArmorIgnore;
		}

		[Constructable]
		public OphidianJusticar() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ophidian" );
			Title = "the ophidian justicar"; 
			Body = 85;
			BaseSoundID = 639;

			SetStr( 383, 401 );
			SetDex( 194, 209 );
			SetInt( 426, 550 );

			SetHits( 218, 246 );
			SetMana( 850, 950 );

			SetDamage( 9, 18 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 44 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 35 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.Magery, 96.0, 100.0 );
			SetSkill( SkillName.MagicResist, 83.8, 87.6 );
			SetSkill( SkillName.Tactics, 73.7, 78.8 );
			SetSkill( SkillName.Wrestling, 35.9, 58.2 );

			Fame = 11500;
			Karma = -11500;

			PackGold( 327, 367 );
			PackReg( 50, 75 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions, 4 );
			AddLoot( LootPack.LowScrolls, 5 );
			AddLoot( LootPack.MedScrolls, 2 );
		}

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

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new RawRibs( amount ), from );
                              corpse.AddCarvedItem(new SerpentScale( Utility.RandomMinMax( 12, 17 )), from);
                              corpse.AddCarvedItem(new OphidianEye(), from);

                              from.SendMessage( "You carve up raw ribs, serpent scales, and an ophidian eye." );
                              corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

	        public override void OnDamagedBySpell( Mobile attacker )
	        {
		        base.OnDamagedBySpell( attacker );

                        if ( 0.5 >= Utility.RandomDouble() )
                        this.Lightning();
	        }

                public override void OnGaveMeleeAttack( Mobile defender )
                {
                        base.OnGaveMeleeAttack( defender );

                        if ( 0.5 >= Utility.RandomDouble() )
                        this.Lightning();
                }

                public override void OnGotMeleeAttack( Mobile attacker )
	        {
		        base.OnGotMeleeAttack( attacker );

		        if ( 0.5 >= Utility.RandomDouble() )
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

                                AOS.Damage( m, Utility.RandomMinMax( 12, 15 ), 0, 0, 0, 0, 100 );

		                m.BoltEffect( 0x480 );

                                if ( m.Alive && m.Body.IsHuman && !m.Mounted )
                                    m.Animate( 20, 7, 1, true, false, 0 ); // take hit
                        }
                }

		public OphidianJusticar( Serial serial ) : base( serial )
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