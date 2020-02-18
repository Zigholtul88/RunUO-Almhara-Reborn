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
	public class RedDaggerKeepHealer2 : BaseHealer 
	{ 
		public override bool IsActiveVendor{ get{ return true; } }

		[Constructable]
		public RedDaggerKeepHealer2()
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			SBInfos.Add( new SBRedDaggerKeepHealer2() ); 
		}

		public override void InitOutfit()
		{
			Name = "Mohrgana the healer";
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 2405;
                        HairItemID = 12236;
                        HairHue = 1114;

			SetStr( 298, 325 );
			SetDex( 86, 101 );
			SetInt( 301, 364 );

			SetSkill( SkillName.EvalInt, 25.8, 33.7 );
			SetSkill( SkillName.Forensics, 80.0, 100.0 );
			SetSkill( SkillName.Healing, 60.0, 83.0 );
			SetSkill( SkillName.MagicResist, 118.7, 128.2 );
			SetSkill( SkillName.SpiritSpeak, 80.0, 100.0 );

			PackGold( 46, 61 );

			CrystalStaff weapon = new CrystalStaff();
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

			AddItem( new PlumeCloak(98) );
			AddItem( new MoonElfPlainDress(98) );
			AddItem( new HighBoots(98) );
                }

		public RedDaggerKeepHealer2( Serial serial ) : base( serial ) 
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
