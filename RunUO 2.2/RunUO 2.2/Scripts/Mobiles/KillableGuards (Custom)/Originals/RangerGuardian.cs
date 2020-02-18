using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	public class RangerGuardian : BaseGuardian
	{ 
		[Constructable] 
		public RangerGuardian() : base( AIType.AI_Archer, FightMode.Weakest, 15, 5, 0.1, 0.2 ) 
		{ 
			Title = "the Ranger Guard"; 

			AddItem( new Bow() );
			PackItem( new Arrow( Utility.RandomMinMax( 50, 80 ) ) ); 

			AddItem( new Boots(1436) );
			AddItem( new Cloak(23) );
			AddItem( new BodySash(23) );

			RangerArms arms = new RangerArms();
			arms.Hue = 2126;
			arms.Movable = false;
			AddItem( arms );

			RangerChest chest = new RangerChest();
			chest.Hue = 1436;
			chest.Movable = false;
			AddItem( chest );

			RangerGloves gloves = new RangerGloves();
			gloves.Hue = 1436;
			gloves.Movable = false;
			AddItem( gloves );

			RangerGorget gorget = new RangerGorget();
			gorget.Hue = 2126;
			gorget.Movable = false;
			AddItem( gorget );

			RangerLegs legs = new RangerLegs();
			legs.Hue = 2126;
			legs.Movable = false;
			AddItem( legs );

			SetStr( 500 );
			SetDex( 800 );
			SetInt( 200 );

			SetSkill( SkillName.Anatomy, 100.0, 100.0 );
			SetSkill( SkillName.Archery, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );

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

		public RangerGuardian( Serial serial ) : base( serial ) 
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