using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
	public class TundraProtector : BaseHealer
	{
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public TundraProtector()
		{
			Name = "a tundra protector";
			Body = 103;
                        Hue = 2544;
			BaseSoundID = 362;

			SetStr( 111, 140 );
			SetDex( 201, 220 );
			SetInt( 1001, 1040 );

			SetHits( 480 );

			SetDamage( 5, 12 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Cold, 75 );

			SetResistance( ResistanceType.Physical, 35, 40 );
			SetResistance( ResistanceType.Fire, 5, 5 );
			SetResistance( ResistanceType.Cold, 95, 125 );
			SetResistance( ResistanceType.Poison, 45, 55 );
			SetResistance( ResistanceType.Energy, 35, 45 );

			SetSkill( SkillName.EvalInt, 100.1, 110.0 );
			SetSkill( SkillName.Magery, 110.1, 120.0 );
			SetSkill( SkillName.Meditation, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.SpiritSpeak, 80.0, 100.0 );
			SetSkill( SkillName.Tactics, 50.1, 60.0 );
			SetSkill( SkillName.Wrestling, 30.1, 100.0 );

			Karma = -15000;
		}

		public override bool ShowFameTitle{ get{ return false; } }
		public override bool ClickTitle{ get{ return false; } } // Do not display title in OnSingleClick

		public override bool CheckResurrect( Mobile m )
		{
			if ( Core.AOS && m.Criminal )
			{
				Say( 501222 ); // Thou art a criminal.  I shall not resurrect thee.
				return false;
			}

			return true;
		}

		public TundraProtector( Serial serial ) : base( serial )
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