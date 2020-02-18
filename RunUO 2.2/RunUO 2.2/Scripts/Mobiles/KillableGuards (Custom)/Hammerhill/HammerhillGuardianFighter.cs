using System; 
using System.Collections; 
using Server.Items; 
using Server.Misc; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	public class HammerhillGuardianFighter : BaseGuardian
	{ 
		[Constructable] 
		public HammerhillGuardianFighter() : base( AIType.AI_Melee, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "Guardian Fighter of Hammerhill"; 

			SetStr( 950, 1000 );
			SetDex( 300, 500 );
			SetInt( 100, 200 );

			SetHits( 1500, 2000 );

			SetDamage( 10, 15 );

			SetSkill( SkillName.Anatomy, 100.0, 100.0);
			SetSkill( SkillName.Healing, 25.0, 35.0 );
			SetSkill( SkillName.Lumberjacking, 100.0, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );
			SetSkill( SkillName.Swords, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );

			Karma = 10000;

			PackItem( new Bandage( Utility.RandomMinMax( 15, 20 ) ) );

			AddItem( new LargeBattleAxe() );
			AddItem( new ShortBoots(1838) );
			AddItem( new Bandana(1838) );
			AddItem( new Cloak(1838) );

			LeatherGorget gorget = new LeatherGorget();
			gorget.Hue = 1838;
			gorget.Movable = true;
			AddItem( gorget );

			StuddedArms arms = new StuddedArms();
			arms.Hue = 1838;
			arms.Movable = true;
			AddItem( arms );

			StuddedGloves gloves = new StuddedGloves();
			gloves.Hue = 1838;
			gloves.Movable = true;
			AddItem( gloves );

			if ( Female = Utility.RandomBool() ) 
			{ 
				Body = 401; 
				Name = NameList.RandomName( "female" );
								
			      FemaleStuddedChest chest = new FemaleStuddedChest();
			      chest.Hue = 1838;
			      chest.Movable = true;
			      AddItem( chest );
			}
			else 
			{ 
				Body = 400; 			
				Name = NameList.RandomName( "male" ); 

			      StuddedChest chest = new StuddedChest();
			      chest.Hue = 1838;
			      chest.Movable = true;
			      AddItem( chest );

			      StuddedLegs legs = new StuddedLegs();
			      legs.Hue = 1838;
			      legs.Movable = true;
			      AddItem( legs );
			}

			Utility.AssignRandomHair( this );
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public HammerhillGuardianFighter( Serial serial ) : base( serial ) 
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