using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Krillyx" )]
	public class Krillyx : BaseGuardian
	{
		public override bool InitialInnocent{ get{ return true; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

                private static bool m_Talked;
                string[]KrillyxSay = new string[]
       	        {
		"WARK!",
		"FUCK YOU BITCH!",
		"YOUR MOTHER SUCKS COCKS IN HELL!",
		"LET THE BODIES HIT THE FLOOR! RAWRRRRRRRRRRRRRRRRRRRR!",
		"WHAT THE FUCK!",
		"WANKER!",
		"YAH GUNNA LET ME LOSE MUH MIND! UP IN HERE! UP IN HERE!",
		"POLLY WANNA FUCK YOU OVER THE SIDE OF YOUR FOREHEAD!",
		"IS YOU GUNNA CRY LIKE A BITCH!",
		"SHIT PICKLE! SHIT PICKLE! SHIT PICKLE!",
		"WHATCHA GONNA DO WHEN WE COME FOR YOU!",
		"AM I BEING A NUISANCE!? :D",
		};

		[Constructable]
		public Krillyx() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
                        // based off of parrot mob stats
			Name = "Krillyx";
			Title = "the parrot";
			Body = 831;	

			SetStr( 12, 17 );
			SetDex( 9, 14 );
			SetInt( 5, 8 );

			SetHits( 100, 115 );

			SetDamage( 1, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.MagicResist, 2.3, 2.7 );
			SetSkill( SkillName.Ninjitsu, 60.0 );
			SetSkill( SkillName.Tactics, 5.5, 8.1 );
			SetSkill( SkillName.Wrestling, 9.7, 9.9 );

			Fame = 0;
			Karma = 10000;

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new Apple() ); break;
				case 1: PackItem( new Banana() ); break;
				case 2: PackItem( new Grapes() ); break;
				case 3: PackItem( new Lemon() ); break;
				case 4: PackItem( new Lime() ); break;
				case 5: PackItem( new Pear() ); break;
			}
		}

		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }

		public override int GetIdleSound() { return 0x0BF; }
		public override int GetAngerSound() { return 0x0C0; }
		public override int GetAttackSound() { return 0x0C2; }
		public override int GetHurtSound() { return 0x0C3; }
		public override int GetDeathSound() { return 0x0C1; }

                public override void OnMovement( Mobile m, Point3D oldLocation )
                {
                     if( m_Talked == false )
                     {
                          if ( m.InRange( this, 4 ) && m is PlayerMobile )
                          {
                               m_Talked = true;
                               SayRandom(KrillyxSay, this );
                               this.Move( GetDirectionTo( m.Location ) );
                               SpamTimer t = new SpamTimer();
                               t.Start();
                          }
                     }
                }

                private class SpamTimer : Timer
                {
                    public SpamTimer() : base( TimeSpan.FromSeconds( Utility.Random( 5, 25 ) ) )
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

		public Krillyx( Serial serial ) : base( serial )
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