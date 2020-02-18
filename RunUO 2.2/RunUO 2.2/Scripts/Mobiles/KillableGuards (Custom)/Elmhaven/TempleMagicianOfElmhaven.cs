using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	public class TempleMagicianOfElmhaven : BaseGuardian
	{ 
		[Constructable] 
		public TempleMagicianOfElmhaven() : base( AIType.AI_Mage, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "Temple Magician of Elmhaven"; 

			SetStr( 700, 800 );
			SetDex( 200, 300 );
			SetInt( 500, 1200 );

			SetHits( 1000, 1200 );
			SetMana( 500, 1200 );

			SetDamage( 19, 35 );

			SetSkill( SkillName.Magery, 100.0, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0,100.0 );

			Karma = 10000;

			AddItem( new FancyRobe(2130) );
			AddItem( new LightBoots(2130) );
			AddItem( new Bandana(2125) );
			AddItem( new Cloak(2126) );

			if ( Female = Utility.RandomBool() ) 
			{ 
				Body = 401; 
				Name = NameList.RandomName( "female" );
			}
			else 
			{ 
				Body = 400; 			
				Name = NameList.RandomName( "male" ); 
			}

			Utility.AssignRandomHair( this );
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public TempleMagicianOfElmhaven( Serial serial ) : base( serial ) 
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