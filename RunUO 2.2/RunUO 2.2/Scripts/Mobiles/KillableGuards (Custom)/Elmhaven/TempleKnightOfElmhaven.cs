using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	public class TempleKnightOfElmhaven : BaseGuardian
	{ 
		[Constructable] 
		public TempleKnightOfElmhaven() : base( AIType.AI_Melee, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "Temple Knight of Elmhaven"; 

			SetStr( 900, 1100 );
			SetDex( 200, 500 );
			SetInt( 200, 300 );

			SetHits( 1500, 2000 );

			SetDamage( 10, 15 );

			SetSkill( SkillName.Anatomy, 100.0, 100.0);
			SetSkill( SkillName.Healing, 25.0, 35.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );
			SetSkill( SkillName.Parry, 100.0, 100.0 );
			SetSkill( SkillName.Swords, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );

			Karma = 10000;

			PackItem( new Bandage( Utility.RandomMinMax( 15, 20 ) ) );

			Longsword weapon = new Longsword();
                  weapon.Hue = 2126;
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

			AddItem( new Bandana(2125) );
			AddItem( new Cloak(2126) );

			PlateGorget gorget = new PlateGorget();
			gorget.Hue = 2126;
			gorget.Movable = true;
			AddItem( gorget );

			PlateArms arms = new PlateArms();
			arms.Hue = 2126;
			arms.Movable = true;
			AddItem( arms );

			PlateGloves gloves = new PlateGloves();
			gloves.Hue = 2130;
			gloves.Movable = true;
			AddItem( gloves );

			PlateLegs legs = new PlateLegs();
			legs.Hue = 2130;
			legs.Movable = true;
			AddItem( legs );

			HeaterShield shield = new HeaterShield();
			shield.Hue = 2130;
			shield.Movable = true;
			AddItem( shield );


			if ( Female = Utility.RandomBool() ) 
			{ 
				Body = 401; 
				Name = NameList.RandomName( "female" );
								
			      FemalePlateChest chest = new FemalePlateChest();
			      chest.Hue = 2130;
			      chest.Movable = true;
			      AddItem( chest );
			}
			else 
			{ 
				Body = 400; 			
				Name = NameList.RandomName( "male" ); 

			      PlateChest chest = new PlateChest();
			      chest.Hue = 2130;
			      chest.Movable = true;
			      AddItem( chest );
			}

			Utility.AssignRandomHair( this );
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public TempleKnightOfElmhaven( Serial serial ) : base( serial ) 
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