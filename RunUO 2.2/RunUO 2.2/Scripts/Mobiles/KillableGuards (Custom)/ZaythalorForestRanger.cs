using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	public class ZaythalorForestRanger : BaseGuardian
	{ 
		[Constructable] 
		public ZaythalorForestRanger() : base( AIType.AI_Archer, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "Protector of Zaythalor Forest"; 

			SetStr( 800, 900 );
			SetDex( 900, 1000 );
			SetInt( 100, 200 );

			SetHits( 1500, 2000 );

			SetDamage( 19, 35 );

			SetSkill( SkillName.Anatomy, 100.0, 100.0 );
			SetSkill( SkillName.Archery, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );

			Bow weapon = new Bow();
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

			PackItem( new Arrow( Utility.RandomMinMax( 50, 80 ) ) ); 

			AddItem( new Boots(1436) );
			AddItem( new Cloak(23) );
			AddItem( new BodySash(23) );

			StuddedArms arms = new StuddedArms();
			arms.Hue = 2126;
			arms.Movable = true;
			AddItem( arms );

			StuddedChest chest = new StuddedChest();
			chest.Hue = 1436;
			chest.Movable = true;
			AddItem( chest );

			StuddedGloves gloves = new StuddedGloves();
			gloves.Hue = 1436;
			gloves.Movable = true;
			AddItem( gloves );

			StuddedGorget gorget = new StuddedGorget();
			gorget.Hue = 2126;
			gorget.Movable = true;
			AddItem( gorget );

			StuddedLegs legs = new StuddedLegs();
			legs.Hue = 2126;
			legs.Movable = true;
			AddItem( legs );

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

		public ZaythalorForestRanger( Serial serial ) : base( serial ) 
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