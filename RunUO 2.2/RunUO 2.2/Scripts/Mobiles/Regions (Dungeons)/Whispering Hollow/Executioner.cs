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
	public class Executioner : BaseCreature 
	{ 
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.DoubleStrike;
		}

		[Constructable] 
		public Executioner() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			SpeechHue = Utility.RandomDyedHue(); 
			Title = "the executioner"; 
			Hue = Utility.RandomSkinHue(); 

			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 0x191; 
				this.Name = NameList.RandomName( "female" ); 
				AddItem( new Skirt( Utility.RandomRedHue() ) ); 
			} 
			else 
			{ 
				this.Body = 0x190; 
				this.Name = NameList.RandomName( "male" ); 
				AddItem( new ShortPants( Utility.RandomRedHue() ) ); 
			} 

			SetStr( 386, 400 );
			SetDex( 151, 165 );
			SetInt( 161, 175 );

			SetHits( 2386, 2400 );

			SetDamage( 12, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 125.0 );
			SetSkill( SkillName.Fencing, 46.0, 77.5 );
			SetSkill( SkillName.Macing, 35.0, 57.5 );
			SetSkill( SkillName.Poisoning, 60.0, 82.5 );
			SetSkill( SkillName.MagicResist, 83.5, 92.5 );
			SetSkill( SkillName.Swords, 125.0 );
			SetSkill( SkillName.Tactics, 125.0 );
			SetSkill( SkillName.Lumberjacking, 125.0 );

			Fame = 45000;
			Karma = -45000;

			AxeSlamTimer.AxeSlamList.Add( this );

			PackGold( 2561, 3938 );

			AddItem( new ThighBoots( Utility.RandomRedHue() ) );
			AddItem( new Surcoat( Utility.RandomRedHue() ) );
			AddItem( new ExecutionersAxe() );

			Utility.AssignRandomHair( this );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }

		public void OnTick()
		{
		        AxeSlamAttack();
			this.Animate( 18, 5, 1, true, false, 0 );
			this.FixedParticles( 0x375A, 10, 15, 5037, EffectLayer.Waist );
		}

	        public class AxeSlamTimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<Executioner> AxeSlamList = new List<Executioner>();

		        public static void Initialize() 
		        {
			        if (Enabled)
				        new AxeSlamTimer().Start();
		        }

		        public AxeSlamTimer() : base(TimeSpan.FromSeconds( 15.0 ), TimeSpan.FromSeconds( 15.0 ) ) 
		        {
			        Priority = TimerPriority.OneSecond;
		        }

		        protected override void OnTick() 
		        {
			        foreach ( Executioner executioner in AxeSlamList )
				        executioner.OnTick();
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

				    AOS.Damage( m, 70, 100, 0, 0, 0, 0 );
		                    m.Stam -= ( Utility.Random( 55, 75 ) );
                               }
                        }
                }

		public Executioner( Serial serial ) : base( serial ) 
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

			AxeSlamTimer.AxeSlamList.Add(this);
		} 
	} 
}