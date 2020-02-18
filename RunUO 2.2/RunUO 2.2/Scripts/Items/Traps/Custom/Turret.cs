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
	[CorpseName( "a turret corpse" )]	
	public class Turret : BaseCreature
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 1.0 ); //the delay between talks is 1 second
		public DateTime m_NextTalk;

		[Constructable]
		public Turret() : base( AIType.AI_Animal, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			CantWalk = true;

			Name = "a turret";
			Body = 6;
                        Hue = 1;

			SetStr( 12, 17 );
			SetDex( 9, 14 );
			SetInt( 5, 8 );

			SetHits( 10 );
			SetMana( 0 );

			SetDamage( 0 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, -50 );
			SetResistance( ResistanceType.Fire, -50 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, -50 );
			SetResistance( ResistanceType.Energy, -50 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 0.0 );

			Fame = 10;
			Karma = -10;
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 6 ) && InLOS( m ) && m is Mobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
		                m.Hits -= ( Utility.Random( 22, 25 ) );

			        this.MovingEffect( m, 0xF42, 10, 0, false, false );

				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 1 ) )
				{
					case 0: Say("**");
						PlaySound(0x307); 
						break;
				};
			}
		}

		public Turret( Serial serial ) : base( serial )
		{
		}

		public override int GetIdleSound() { return 0x0D1; }
		public override int GetAngerSound() { return 0x0D2; }
		public override int GetAttackSound() { return 0x0D3; }
		public override int GetHurtSound() { return 0x0D4; }
		public override int GetDeathSound() { return 0x0D5; }

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