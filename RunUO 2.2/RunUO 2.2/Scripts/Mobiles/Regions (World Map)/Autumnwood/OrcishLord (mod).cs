using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an orcish corpse" )]
	public class OrcishLord : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.DoubleStrike;
		}

		[Constructable]
		public OrcishLord() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.2, 0.4 )
		{
			Name = "an orcish lord";
			Body = 138;
			BaseSoundID = 0x45A;

			SetStr( 147, 215 );
			SetDex( 91, 115 );
			SetInt( 61, 85 );

			SetHits( 190, 246 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.MagicResist, 70.1, 85.0 );
			SetSkill( SkillName.Swords, 60.1, 85.0 );
			SetSkill( SkillName.Tactics, 75.1, 90.0 );
			SetSkill( SkillName.Wrestling, 60.1, 85.0 );

			Fame = 2500;
			Karma = -2500;

			AxeSlamTimer.AxeSlamList.Add( this );

			PackGold( 100, 350 );

			PackItem( new RingmailChest() );
			PackItem( new OrcHelm() );

			PackItem( new FishScale( Utility.RandomMinMax( 11, 14 ) ) );

			switch ( Utility.Random( 5 ) )
			{
				case 0: PackItem( new Lockpick(5) );  break;
				case 1: PackItem( new MortarPestle() ); break;
				case 2: PackItem( new Bottle() ); break;
				case 3: PackItem( new RawRibs(3) ); break;
				case 4: PackItem( new Shovel() ); break;
			}
		}

		public override bool CanRummageCorpses{ get{ return true; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(), from);
                        corpse.AddCarvedItem(new OrcHead(), from);

                        from.SendMessage( "You carve up a raw rib and the creatures head." );
                        corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( m.Player && m.FindItemOnLayer( Layer.Helm ) is OrcishKinMask )
				return false;

			return base.IsEnemy( m );
		}

		public override void AggressiveAction( Mobile aggressor, bool criminal )
		{
			base.AggressiveAction( aggressor, criminal );

			Item item = aggressor.FindItemOnLayer( Layer.Helm );

			if ( item is OrcishKinMask )
			{
				AOS.Damage( aggressor, 50, 0, 100, 0, 0, 0 );
				item.Delete();
				aggressor.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
				aggressor.PlaySound( 0x307 );
			}
		}

		public void OnTick()
		{
		        AxeSlamAttack();
			this.Animate( 18, 5, 1, true, false, 0 );
			this.FixedParticles( 0x375A, 10, 15, 5037, EffectLayer.Waist );
		}

	        public class AxeSlamTimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<OrcishLord> AxeSlamList = new List<OrcishLord>();

		        public static void Initialize() 
		        {
			        if (Enabled)
				        new AxeSlamTimer().Start();
		        }

		        public AxeSlamTimer() : base(TimeSpan.FromSeconds( 15.0 ), TimeSpan.FromSeconds( 15.0 )) 
		        {
			        Priority = TimerPriority.OneSecond;
		        }

		        protected override void OnTick() 
		        {
			        foreach (OrcishLord orcishlord in AxeSlamList)
				        orcishlord.OnTick();
		        }
	        }

                public void AxeSlamAttack()
                {
                        List<Mobile> list = new List<Mobile>();

                        foreach ( Mobile m in GetMobilesInRange( 3 ) )
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
		                    m.BoltEffect( 0x480 );
			            m.PlaySound( 0x220 ); // Earthquake

				    AOS.Damage( m, 25, 100, 0, 0, 0, 0 );
		                    m.Stam -= ( Utility.Random( 25, 35 ) ); 
                               }
                        }
                }

		public OrcishLord( Serial serial ) : base( serial )
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

			AxeSlamTimer.AxeSlamList.Add(this);
		}
	}
}