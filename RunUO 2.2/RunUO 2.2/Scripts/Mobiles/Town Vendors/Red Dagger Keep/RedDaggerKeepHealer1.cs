using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;

namespace Server.Mobiles 
{ 
	public class RedDaggerKeepHealer1 : BaseHealer 
	{ 
		public override bool IsActiveVendor{ get{ return true; } }
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public RedDaggerKeepHealer1() 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			SBInfos.Add( new SBRedDaggerKeepHealer1() ); 
		}

		public override void InitOutfit()
		{
			Name = "Sidrathra the Healer";
			Body = 69;
			BaseSoundID = 377;

			SetStr( 298, 325 );
			SetDex( 86, 101 );
			SetInt( 301, 364 );

			SetHits( 356, 390 );
			SetMana( 1505, 1820 );

			SetDamage( 8, 19 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.EvalInt, 25.8, 33.7 );
			SetSkill( SkillName.Forensics, 80.0, 100.0 );
			SetSkill( SkillName.Healing, 60.0, 83.0 );
			SetSkill( SkillName.MagicResist, 118.7, 128.2 );
			SetSkill( SkillName.SpiritSpeak, 80.0, 100.0 );

			PackGold( 46, 61 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new MindBlastScroll() );
                }

		public RedDaggerKeepHealer1( Serial serial ) : base( serial ) 
		{ 
		} 

		public override bool CheckResurrect( Mobile m )
		{
			if ( m.Criminal )
			{
				Say( 501222 ); // Thou art a criminal.  I shall not resurrect thee.
				return false;
			}
			else if ( m.Kills >= 5 )
			{
				Say( 501223 ); // Thou'rt not a decent and good person. I shall not resurrect thee.
				return false;
			}
			else if ( m.Karma < 0 )
			{
				Say( 501224 ); // Thou hast strayed from the path of virtue, but thou still deservest a second chance.
			}

			return true;
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
