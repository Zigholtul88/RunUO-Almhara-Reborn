using System;
using System.Collections;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Grobu" )]
	public class Grobu : BaseCreature
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 60.0 ); //the delay between talks is 60 seconds
		public DateTime m_NextTalk;

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ArmorIgnore;
		}

		[Constructable]
		public Grobu() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Grobu";
			Body = 236;
			BaseSoundID = 0xA3;
			Hue = 0x455;

			SetStr( 192, 210 );
			SetDex( 132, 150 );
			SetInt( 50, 52 );

			SetHits( 500, 800 );
			SetStam( 132, 150 );
			SetMana( 9 );

			SetDamage( 8, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.Wrestling, 96.4, 119.0 );
			SetSkill( SkillName.Tactics, 96.2, 116.5 );
			SetSkill( SkillName.MagicResist, 66.2, 83.7 );

			Fame = 10000;
			Karma = 10000;
		}

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(2), from);
                        corpse.AddCarvedItem(new Hides(16), from);
                        corpse.AddCarvedItem(new CaveBearClaw(), from);
                        corpse.AddCarvedItem(new GrobusFur(), from);

                        from.SendMessage( "You carve up raw ribs, hides, a cave bear claw and the fur of Grobu." );
                        corpse.Carved = true; 
			}
                }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 4 ) && InLOS( m ) && m is PlayerMobile ) // check if it's time to talk & mobile in range & in los.
			{
				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 10 ))
				{
					case 0: Say("Me Grobu no like you!"); 
						break;
					case 1: Say("Me Grobu gonna chew you to shreds!"); 
						break;	
					case 2: Say("Me Grobu gonna rock you like a hurricane!"); 
						break;	
					case 3: Say("Me Grobu, ummmm............ sally forth!"); 
						break;	
					case 4: Say("Me Grobu will tear your soul apart!"); 
						break;	
					case 5: Say("Me Grobu say, Give me your Face!"); 
						break;	
					case 6: Say("Me Grobu hunger so bad I can taste it!"); 
						break;	
					case 7: Say("Me Grobu say, I got the touch! I got the power!"); 
						break;
					case 8: Say("BAWEENA GWANEE NEENEEBONG!"); 
						break;	
					case 9: Say("Me Grobu say, Oh shit what are we gonna do!"); 
						break;
				};
			}
		}

		public Grobu( Serial serial ) : base( serial )
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
