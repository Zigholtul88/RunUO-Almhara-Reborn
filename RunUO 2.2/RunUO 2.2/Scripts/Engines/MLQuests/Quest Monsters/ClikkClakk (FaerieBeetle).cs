using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.Fourth;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Clikk-Clakk" )]
	public class ClikkClakk : BaseSpecialCreature
	{
                public override bool DoesTripleBolting { get { return true; } }
                public override double TripleBoltingChance { get { return 0.250; } }

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
		public ClikkClakk() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "Clikk-Clakk";
			Body = 807;
                        Hue = 181;

			SetStr( 122, 154 );
			SetDex( 92, 122 );
			SetInt( 89, 111 );

			SetHits( 500 );
			SetMana( 1000 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.MagicResist, 50.0 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 10000;
			Karma = -10000;

			PackReg( 50, 100 );
		}

                public override bool OnBeforeDeath()
                {
                        this.Say("Nooooooooooooo! I cannot die!");

                        return base.OnBeforeDeath();
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

		public override bool CanRummageCorpses{ get{ return true; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new Gold( Utility.RandomMinMax( 500, 1000 ) ), from );
                              corpse.AddCarvedItem( new FaerieBeetleCarapace(), from );
                              corpse.AddCarvedItem( new BeetleEgg( Utility.RandomMinMax( 54, 69 ) ), from );
                              corpse.AddCarvedItem( new FaerieBeetleMeat(), from );

                              from.SendMessage( "You carve up some gold, beetle eggs, a beetle carapace, and some meat." );
                              corpse.Carved = true; 
			}
                }

	        public override void OnDamagedBySpell( Mobile attacker )
	        {
		        base.OnDamagedBySpell( attacker );

                        Mobile target = attacker;

                        if( target is BaseCreature && ((BaseCreature)target).Controlled )
                        target = ((BaseCreature)target).ControlMaster;

                        if( target == null )
                        target = attacker;

                        if( DoesTripleBolting && TripleBoltingChance >= Utility.RandomDouble() )
                        TripleBolt( target );

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

                        Mobile target = attacker;

                        if( target is BaseCreature && ((BaseCreature)target).Controlled )
                        target = ((BaseCreature)target).ControlMaster;

                        if( target == null )
                        target = attacker;

                        if( DoesTripleBolting && TripleBoltingChance >= Utility.RandomDouble() )
                        TripleBolt( target );

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

                                AOS.Damage( m, Utility.RandomMinMax( 15, 30 ), 0, 0, 0, 0, 100 );

		                m.BoltEffect( 0x480 );

                                if ( m.Alive && m.Body.IsHuman && !m.Mounted )
                                    m.Animate( 20, 7, 1, true, false, 0 ); // take hit
                        }
                }

		public ClikkClakk( Serial serial ) : base( serial )
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