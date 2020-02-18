using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	public class TempleCrusaderOfElmhaven : BaseGuardian
	{ 
		[Constructable] 
		public TempleCrusaderOfElmhaven() : base( AIType.AI_Melee, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "Temple Crusader of Elmhaven"; 

			SetStr( 1200, 1500 );
			SetDex( 200, 500 );
			SetInt( 100, 200 );

			SetHits( 1500, 2000 );

			SetDamage( 15, 20 );

			SetSkill( SkillName.Anatomy, 100.0, 100.0);
			SetSkill( SkillName.Healing, 25.0, 35.0 );
			SetSkill( SkillName.Macing, 100.0, 100.0 );
			SetSkill( SkillName.Parry, 100.0, 100.0 );
			SetSkill( SkillName.Swords, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );

			Karma = 10000;

			WarMace weapon = new WarMace();
                  weapon.Hue = 2126;
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

			AddItem( new HeavyBoots(2130) );
			AddItem( new Bandana(2125) );
			AddItem( new Cloak(2126) );

			CrusaderGorget gorget = new CrusaderGorget();
			gorget.Hue = 2126;
			gorget.Movable = true;
			AddItem( gorget );

		      CrusaderBreastplate chest = new CrusaderBreastplate();
			chest.Hue = 2130;
			chest.Movable = true;
			AddItem( chest );

			CrusaderSleeves arms = new CrusaderSleeves();
			arms.Hue = 2126;
			arms.Movable = true;
			AddItem( arms );

			CrusaderGauntlets gloves = new CrusaderGauntlets();
			gloves.Hue = 2130;
			gloves.Movable = true;
			AddItem( gloves );

			CrusaderLeggings legs = new CrusaderLeggings();
			legs.Hue = 2130;
			legs.Movable = true;
			AddItem( legs );

			MetalKiteShield shield = new MetalKiteShield();
			shield.Hue = 2130;
			shield.Movable = true;
			AddItem( shield );

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

		public TempleCrusaderOfElmhaven( Serial serial ) : base( serial ) 
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