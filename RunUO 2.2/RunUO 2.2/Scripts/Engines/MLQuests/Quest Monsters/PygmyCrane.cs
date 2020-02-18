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
	[CorpseName( "a pygmy crane corpse" )]
	public class PygmyCrane : BaseCreature
	{
		public override bool IsScaredOfScaryThings{ get{ return false; } }
		public override bool IsScaryToPets{ get{ return true; } }

		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 60.0 ); //the delay between talks is 60 seconds
		public DateTime m_NextTalk;

		[Constructable]
		public PygmyCrane() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a pygmy crane";
			Body = 254;
			BaseSoundID = 0x4D7;
			Hue = 0x482;

			SetStr( 96, 118 );
			SetDex( 86, 105 );
			SetInt( 54, 71 );

			SetHits( 116, 144 );

			SetDamage( 7, 11 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.MagicResist, 54.6, 65.0 );
			SetSkill( SkillName.Tactics, 75.9, 99.4 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 1800;
			Karma = -1800;
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool CanAngerOnTame { get { return true; } }

		public override int GetAttackSound() { return 0x4D7; } 
		public override int GetAngerSound() { return 0x4D9; } 
		public override int GetDeathSound() { return 0x4D6; }
		public override int GetHurtSound() { return 0x4DA; } 
		public override int GetIdleSound() { return 0x4D8; } 

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 5 ) && InLOS( m ) && m is PlayerMobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
 			        if ( Utility.RandomDouble() < 0.05 )
                                {
					m.SendMessage( "The pygmy crane lays another egg" );
			                PygmyCraneEggs eggs = new PygmyCraneEggs();
			                eggs.MoveToWorld( Location, Map );
			                Effects.SendLocationEffect( Location, Map, 0x376A, 10, 1 );
                                }

				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 2 ) )
				{
					case 0: Say("**");
				                PlaySound(0x4D8);
						break;
					case 1: Say("**");
				                PlaySound(0x4DA);
						break;
				};
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new Feather(25), from);
                              corpse.AddCarvedItem(new RawRibs(), from);
                              corpse.AddCarvedItem(new PygmyCraneEggs( amount ), from );

                              from.SendMessage( "You carve up feathers, raw ribs and some eggs." );
                              corpse.Carved = true; 
			}
                }

		public PygmyCrane( Serial serial ) : base( serial )
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
