using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Spells;
using System.Collections.Generic;

namespace Server.Mobiles
    {
    public abstract class BaseSpecialCreature : BaseCreature
        {
        public virtual bool DoesTeleporting { get { return false; } }
        public virtual double TeleportingChance { get { return 0.625; } }

        public virtual bool DoesNoxStriking { get { return false; } }
        public virtual double NoxStrikingChance { get { return 0.250; } }

        public virtual bool DoesLifeDraining { get { return false; } }
        public virtual double LifeDrainingChance
            {
            get
                {
                if( Hits < ( HitsMax / Utility.RandomMinMax( 1, 3 ) ) )
                    return 0.125;

                return 0.0;
                }
            }

        public virtual bool DoesTripleBolting { get { return false; } }
        public virtual double TripleBoltingChance { get { return 0.250; } }

        public virtual bool DoesMultiFirebreathing { get { return false; } }
        public virtual double MultiFirebreathingChance { get { return 1.000; } }
        public virtual int BreathDamagePercent { get { return 100; } }
        public virtual int BreathMaxTargets { get { return 5; } }
        public virtual int BreathMaxRange { get { return 5; } }
        public override bool HasBreath { get { return DoesMultiFirebreathing; } }

        public virtual bool DoesEarthquaking { get { return false; } }
        public virtual double EarthquakingChance { get { return 0.250; } }

        public virtual bool DoesSummoning { get { return false; } }
        public virtual double SummoningChance { get { return 0.150; } }
        public virtual double SummoningLowChance { get { return 0.050; } }
        public virtual Type SummoningType { get { return null; } }
        public virtual TimeSpan SummoningDuration { get { return TimeSpan.FromMinutes( 2.0 ); } }
        public virtual TimeSpan SummoningDelay { get { return TimeSpan.FromMinutes( 2.0 ); } }
        public virtual int SummoningSound { get { return -1; } }
        public virtual int SummoningMin { get { return 1; } }
        public virtual int SummoningMax { get { return 1; } }

        public override void OnGotMeleeAttack( Mobile attacker )
            {
            base.OnGotMeleeAttack( attacker );

            Mobile target = attacker;

            if( target is BaseCreature && ((BaseCreature)target).Controlled )
                target = ((BaseCreature)target).ControlMaster;

            if( target == null )
                target = attacker;

            if( DoesNoxStriking && NoxStrikingChance >= Utility.RandomDouble() )
                NoxStrike( target );

            if( DoesLifeDraining && LifeDrainingChance >= Utility.RandomDouble() )
                DrainLife();

            if( DoesTripleBolting && TripleBoltingChance >= Utility.RandomDouble() )
                TripleBolt( target );

            if( DoesSummoning && SummoningChance >= Utility.RandomDouble() )
                SummonMinions( target );
            }

        public override void OnGaveMeleeAttack( Mobile defender )
            {
            base.OnGaveMeleeAttack( defender );

            if( DoesLifeDraining && LifeDrainingChance >= Utility.RandomDouble() )
                DrainLife();

            if( DoesEarthquaking && EarthquakingChance >= Utility.RandomDouble() )
                Earthquake();
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

            if( DoesSummoning && SummoningChance >= Utility.RandomDouble() )
                SummonMinions( target );
            }

        #region Summoning

        private DateTime m_NextSummonTime = DateTime.Now;

        public virtual int SummonMinions( Mobile victim )
            {
            int minions = 0;

            if( Map == null || Map == Map.Internal || Map != victim.Map || SummoningType == null )
                return minions;

            if( m_NextSummonTime >= DateTime.Now && Utility.RandomDouble() > SummoningLowChance )
                return minions;

            #region Cantidad de Summons
            int min = SummoningMin;
            int max = SummoningMax;
            
            if( min > max )
                {
                int aux = min;
                max = min;
                min = max;
                }

            int amount = min;

            if( min != max )
                amount = Utility.RandomMinMax( min, max );

            if( amount < 1 )
                amount = 1;
            #endregion

            for( int m = 0; m < amount; m++ )
                {
                BaseCreature minion;

                try { minion = (BaseCreature)Activator.CreateInstance( SummoningType ); }
                catch { continue; }

                int offset = Utility.Random( 8 ) * 2;
                Point3D selectedOffset = victim.Location;

                for( int i = 0; i < m_Offsets.Length; i += 2 )
                    {
                    int x = X + m_Offsets[( offset + i     ) % m_Offsets.Length];
                    int y = Y + m_Offsets[( offset + i + 1 ) % m_Offsets.Length];

                    if( Map.CanSpawnMobile( x, y, Z ) )
                        {
                        selectedOffset = new Point3D( x, y, Z );
                        break;
                        }
                    else
                        {
                        int z = Map.GetAverageZ( x, y );

                        if( Map.CanSpawnMobile( x, y, z ) )
                            {
                            selectedOffset = new Point3D( x, y, z );
                            break;
                            }
                        }
                    }

                BaseCreature.Summon( minion, false, this, selectedOffset, SummoningSound, SummoningDuration );
                minion.Combatant = victim;
                minions++;
                }

            /* NOTA: 
             * 
             * Cada 6 minions esperamos el doble de tiempo que el pautado,
             * esto logra que no se sumonee 28 summons y se tarde lo mismo 
             * que cuando se summonean 3 de ellos. Eh lo.
             */

            m_NextSummonTime = DateTime.Now + TimeSpan.FromSeconds( SummoningDelay.TotalSeconds * ( 0.8 + ( minions * 0.2 ) ) ); 

            return minions;
            }

        #endregion

        #region Earthquake

        public virtual void Earthquake()
            {
            if( Map == null )
                return;

            List<Mobile> targets = new List<Mobile>();

            foreach( Mobile m in this.GetMobilesInRange( 6 ) )
                {
                if( m == this || !CanBeHarmful( m ) || m.AccessLevel >= AccessLevel.Counselor )
                    continue;

                if( m is BaseCreature && ( ( (BaseCreature)m ).Controlled || ( (BaseCreature)m ).Summoned || ( (BaseCreature)m ).Team != this.Team ) )
                    targets.Add( m );
                else if( m.Player )
                    targets.Add( m );
                }

            PlaySound( 0x2F3 );

            for( int i = 0; i < targets.Count; ++i )
                {
                Mobile m = targets[i];

                double damage = m.Hits * 0.6;

                if( damage < 10.0 )
                    damage = 10.0;
                else if( damage > 75.0 )
                    damage = 75.0;

                DoHarmful( m );

                AOS.Damage( m, this, (int)damage, 100, 0, 0, 0, 0 );

                if( m.Alive && m.Body.IsHuman && !m.Mounted )
                    m.Animate( 20, 7, 1, true, false, 0 ); // take hit
                }
            }

        #endregion

        #region Multi Breath

        public override void BreathStart( Mobile target )
            {
            base.BreathStart( target ); //tiramos un firebreath al objetivo original.

            if( !DoesMultiFirebreathing || Utility.RandomDouble() > MultiFirebreathingChance )
                return;

            List<Mobile> posibleTgts = new List<Mobile>();

            foreach( Mobile m in target.Map.GetMobilesInRange( target.Location, BreathMaxRange ) )
                if( m != null && !m.Deleted && m != target && m.Alive && !m.IsDeadBondedPet &&
                    ( m.AccessLevel < AccessLevel.Counselor || CanSee( m ) ) && CanBeHarmful( m ) &&
                    ( m.Player || ( m is BaseCreature && ( (BaseCreature)m ).Controlled ) ) )
                    posibleTgts.Add( m );

            int maxTgts = BreathMaxTargets - 1; //BreathMaxTargets - 1 + el primer firebreath que va al target original.
            int mt = 0;
            int maxAtt = 3;
            int at = 0;

            for( int i = 0; i < posibleTgts.Count && mt++ < maxTgts && at++ < maxAtt; i++ )
                {
                int x = Utility.Random( posibleTgts.Count );
                Mobile t = posibleTgts[x];

                if( t == null || !CanBeHarmful( t ) )
                    return;

                BreathStallMovement();
                BreathPlayAngerSound();
                BreathPlayAngerAnimation();

                Direction = GetDirectionTo( t );

                Timer.DelayCall( TimeSpan.FromSeconds( BreathEffectDelay ), new TimerStateCallback( BreathEffect_Callback ), t );

                posibleTgts.RemoveAt( x );
                at = 0;
                }
            }

        public override int BreathComputeDamage()       //Que haga un toke menos de daño, 
            {                                           //si va a meter 5 firebreaths....
            int fromBase = base.BreathComputeDamage();  //Además, lo usa la Hydra que tiene 1.5Ks de hits, y el Abscess con sus 7Ks.

            if( DoesMultiFirebreathing )
                return (int)( fromBase * ( BreathDamagePercent / 10 ) );

            return fromBase;
            }

        #endregion

        #region Triple Energy Bolts

        private int Bolts = 0;

        public virtual void TripleBolt( Mobile to )
            {
            Bolts = 0;
            Timer.DelayCall( TimeSpan.FromSeconds( Utility.Random( 3 ) ), new TimerStateCallback( Bolt_Callback ), to );
            Timer.DelayCall( TimeSpan.FromSeconds( Utility.Random( 3 ) ), new TimerStateCallback( Bolt_Callback ), to );
            Timer.DelayCall( TimeSpan.FromSeconds( Utility.Random( 3 ) ), new TimerStateCallback( Bolt_Callback ), to );
            }

        public virtual void Bolt_Callback( object state )
            {
            Mobile to = state as Mobile;

            if( to == null )
                return;

            DoHarmful( to );

            to.BoltEffect( 0 );

            int damage = Utility.RandomMinMax( 23, 29 );

            AOS.Damage( to, this, damage, false, 0, 0, 0, 0, 100 );

            if( ++Bolts == 3 && damage > 0 )
                to.SendMessage( "You get shocked and dazed!" );
            }

        #endregion

        #region Teleport

        private Timer m_Timer;

        public static int[] m_Offsets = new int[]
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

        private class TeleportTimer : Timer
            {
            private BaseSpecialCreature m_Owner;

            public TeleportTimer( BaseSpecialCreature owner )
                : base( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 5.0 ) )
                {
                m_Owner = owner;
                }

            protected override void OnTick()
                {
                if( m_Owner.Deleted )
                    {
                    Stop();
                    return;
                    }

                if( Utility.RandomDouble() > m_Owner.TeleportingChance )
                    return;

                Map map = m_Owner.Map;

                if( map == null )
                    return;

                List<Mobile> toTeleport = new List<Mobile>();

                foreach( Mobile m in m_Owner.Region.GetMobiles() )
                    if( m != m_Owner && m.Player && m_Owner.CanBeHarmful( m ) && m_Owner.CanSee( m ) && m.AccessLevel < AccessLevel.Counselor )
                        toTeleport.Add( m );

                if( toTeleport.Count > 0 )
                    {
                    int offset = Utility.Random( 8 ) * 2;

                    Point3D to = m_Owner.Location;

                    for( int i = 0; i < m_Offsets.Length; i += 2 )
                        {
                        int x = m_Owner.X + BaseSpecialCreature.m_Offsets[( offset + i     ) % BaseSpecialCreature.m_Offsets.Length];
                        int y = m_Owner.Y + BaseSpecialCreature.m_Offsets[( offset + i + 1 ) % BaseSpecialCreature.m_Offsets.Length];

                        if( map.CanSpawnMobile( x, y, m_Owner.Z ) )
                            {
                            to = new Point3D( x, y, m_Owner.Z );
                            break;
                            }
                        else
                            {
                            int z = map.GetAverageZ( x, y );

                            if( map.CanSpawnMobile( x, y, z ) )
                                {
                                to = new Point3D( x, y, z );
                                break;
                                }
                            }
                        }

                    Mobile m = toTeleport[Utility.Random( toTeleport.Count )];

                    Point3D from = m.Location;

                    m.Location = to;

                    SpellHelper.Turn( m_Owner, m );
                    SpellHelper.Turn( m, m_Owner );

                    m.ProcessDelta();

                    Effects.SendLocationParticles( EffectItem.Create( from, m.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 2023 );
                    Effects.SendLocationParticles( EffectItem.Create( to, m.Map, EffectItem.DefaultDuration ), 0x3728, 10, 10, 5023 );

                    m.PlaySound( 0x1FE );

                    m_Owner.Combatant = m;
                    }
                }
            }

        #endregion

        #region NoxStrike

        public virtual void NoxStrike( Mobile attacker )
            {
            /* Counterattack with Hit Poison Area
             * 20-25 damage, unresistable
             * Lethal poison, 100% of the time
             * Particle effect: Type: "2" From: "0x4061A107" To: "0x0" ItemId: "0x36BD" ItemIdName: "explosion" FromLocation: "(296 615, 17)" ToLocation: "(296 615, 17)" Speed: "1" Duration: "10" FixedDirection: "True" Explode: "False" Hue: "0xA6" RenderMode: "0x0" Effect: "0x1F78" ExplodeEffect: "0x1" ExplodeSound: "0x0" Serial: "0x4061A107" Layer: "255" Unknown: "0x0"
             * Doesn't work on provoked monsters
             */

            if( attacker is BaseCreature && ( (BaseCreature)attacker ).BardProvoked )
                return;

            Mobile target = null;

            if( attacker is BaseCreature )
                {
                Mobile m = ( (BaseCreature)attacker ).GetMaster();

                if( m != null )
                    target = m;
                }

            if( target == null || !target.InRange( this, 18 ) )
                target = attacker;

            this.Animate( 10, 4, 1, true, false, 0 );

            List<Mobile> targets = new List<Mobile>();

            foreach( Mobile m in target.GetMobilesInRange( 8 ) )
                {
                if( m == this || !CanBeHarmful( m ) || m.AccessLevel >= AccessLevel.Counselor )
                    continue;

                if( m is BaseCreature && ( ( (BaseCreature)m ).Controlled || ( (BaseCreature)m ).Summoned || ( (BaseCreature)m ).Team != this.Team ) )
                    targets.Add( m );
                else if( m.Player && m.Alive )
                    targets.Add( m );
                }

            for( int i = 0; i < targets.Count; ++i )
                {
                Mobile m = targets[i];

                DoHarmful( m );

                AOS.Damage( m, this, Utility.RandomMinMax( 20, 25 ), true, 0, 0, 0, 100, 0 );

                m.FixedParticles( 0x36BD, 1, 10, 0x1F78, 0xA6, 0, (EffectLayer)255 );
                m.ApplyPoison( this, Poison.Lethal );
                }
            }

        #endregion

        #region DrainLife

        public virtual void DrainLife()
            {
            List<Mobile> list = new List<Mobile>();

            foreach( Mobile m in Region.GetMobiles() )
                {
                if( m == this || !CanBeHarmful( m ) || !CanSee( m ) || m.AccessLevel >= AccessLevel.Counselor )
                    continue;

                if( m is BaseCreature && ( ( (BaseCreature)m ).Controlled || ( (BaseCreature)m ).Summoned || ( (BaseCreature)m ).Team != Team ) )
                    list.Add( m );
                else if( m.Player )
                    list.Add( m );
                }

            foreach( Mobile m in list )
                {
                DoHarmful( m );

                m.FixedParticles( 0x374A, 10, 15, 5013, 0x496, 0, EffectLayer.Waist );
                m.PlaySound( 0x231 );

                m.SendMessage( "You feel the life drain out of you!" );

                int toDrain = Utility.RandomMinMax( 10, 40 );

                Hits += toDrain;
                m.Damage( toDrain, this );
                }
            }

        #endregion

        public BaseSpecialCreature( AIType ai, FightMode mode, int iRangePerception, int iRangeFight, double dActiveSpeed, double dPassiveSpeed ) : base( ai, mode, iRangePerception, iRangeFight, dActiveSpeed, dPassiveSpeed )
            {
            if( DoesTeleporting )
                {
                m_Timer = new TeleportTimer( this );
                m_Timer.Start();
                }
            }

        public BaseSpecialCreature( Serial serial ) : base( serial )
            {
            if( DoesTeleporting )
                {
                m_Timer = new TeleportTimer( this );
                m_Timer.Start();
                }
            }

        public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); }
        public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); }
        }
    }