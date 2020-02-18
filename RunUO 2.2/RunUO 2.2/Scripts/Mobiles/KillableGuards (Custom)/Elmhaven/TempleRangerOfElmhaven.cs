using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	public class TempleRangerOfElmhaven : BaseGuardian
	{ 
		[Constructable] 
		public TempleRangerOfElmhaven() : base( AIType.AI_Archer, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "Temple Ranger of Elmhaven"; 

			SetStr( 850, 900 );
			SetDex( 500, 700 );
			SetInt( 100, 200 );

			SetHits( 1500, 2000 );

			SetDamage( 19, 35 );

			SetSkill( SkillName.Anatomy, 100.0, 100.0 );
			SetSkill( SkillName.Archery, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );

			Karma = 10000;

			Crossbow weapon = new Crossbow();
                  weapon.Hue = 2126;
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

			PackItem( new Bolt( Utility.RandomMinMax( 50, 80 ) ) ); 

			AddItem( new HighBoots(2130) );
			AddItem( new Bandana(2125) );
			AddItem( new Cloak(2126) );

			StuddedGorget gorget = new StuddedGorget();
			gorget.Hue = 2126;
			gorget.Movable = true;
			AddItem( gorget );

			StuddedArms arms = new StuddedArms();
			arms.Hue = 2126;
			arms.Movable = true;
			AddItem( arms );

			StuddedGloves gloves = new StuddedGloves();
			gloves.Hue = 2130;
			gloves.Movable = true;
			AddItem( gloves );

			if ( Female = Utility.RandomBool() ) 
			{ 
				Body = 401; 
				Name = NameList.RandomName( "female" );
								
			      FemaleStuddedChest chest = new FemaleStuddedChest();
			      chest.Hue = 2130;
			      chest.Movable = true;
			      AddItem( chest );
			}
			else 
			{ 
				Body = 400; 			
				Name = NameList.RandomName( "male" ); 

			      StuddedChest chest = new StuddedChest();
			      chest.Hue = 2130;
			      chest.Movable = true;
			      AddItem( chest );

			      StuddedLegs legs = new StuddedLegs();
			      legs.Hue = 2130;
			      legs.Movable = true;
			      AddItem( legs );
			}

			Utility.AssignRandomHair( this );
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public TempleRangerOfElmhaven( Serial serial ) : base( serial ) 
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