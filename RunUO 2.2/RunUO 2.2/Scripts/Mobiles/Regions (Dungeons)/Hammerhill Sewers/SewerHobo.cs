using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	public class SewerHobo : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

                private static bool m_Talked;
                string[]SewerHoboSay = new string[]
       	        {
		"This here bottle sure gets the system going.",
		"Ah crap, I'm out of Bum Light!",
		"Praise be to the rabbit horde king!",
		"Oui, I think I just shatnered myself!",
		"Was that one of them gaseous slimes I've been seeing?",
		"Can you tell me where I can find the king of the rabbit horde?",
		};

		[Constructable]
		public SewerHobo() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.2, 0.4 )
		{
                        Name = "a sewer hobo";
			SpeechHue = Utility.RandomDyedHue();
			Body = 0x190;
			Hue = Utility.RandomSkinHue();

			SetStr( 70, 105 );
			SetDex( 24, 178 );
			SetInt( 18 );

			SetHits( 65, 85 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Poison, 30 );

			SetResistance( ResistanceType.Physical, 10 );
			SetResistance( ResistanceType.Poison, 30 );

			SetSkill( SkillName.MagicResist, 7.6, 19.3 );
			SetSkill( SkillName.Poisoning, 39.6, 48.2 );
			SetSkill( SkillName.Tactics, 29.5, 41.4 );
			SetSkill( SkillName.Wrestling, 26.7, 32.3 );

			Fame = 3500;
			Karma = -3500;

			PackGold( 1, 5 );
			PackReg( 1, 5 );

			PackItem( new BumLight() );

			AddItem( new Shoes( Utility.RandomNeutralHue() ) );
			AddItem( new Shirt( Utility.RandomNeutralHue() ) );
			AddItem( new ShortPants( Utility.RandomNeutralHue() ) );

			Utility.AssignRandomHair( this );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return false; } }

		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override Poison HitPoison{ get{ return Poison.Regular; } }

		public override int GetAttackSound() { return 1097; } //play male yeah
		public override int GetHurtSound() { return 1053; } //play male burp
		public override int GetAngerSound() { return 1097; } //play male yeah
		public override int GetDeathSound() { return 1087; } //play male puke

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
		}

                public override void OnMovement( Mobile m, Point3D oldLocation )
                {
                     if( m_Talked == false )
                     {
                          if ( m.InRange( this, 3 ) && m is PlayerMobile)
                          {
                             m_Talked = true;
                             SayRandom(SewerHoboSay, this );
                             this.Move( GetDirectionTo( m.Location ) );
                             SpamTimer t = new SpamTimer();
                             t.Start();
                          }
                    }
              }

              private class SpamTimer : Timer
              {
                   public SpamTimer() : base( TimeSpan.FromSeconds( 25 ) )
                   {
                        Priority = TimerPriority.OneSecond;
                   }

                   protected override void OnTick()
                   {
                           m_Talked = false;
                   }
              }

                private static void SayRandom( string[] say, Mobile m )
                {
                     m.Say( say[Utility.Random( say.Length )] );
                }

		public SewerHobo( Serial serial ) : base( serial )
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