using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	public class VillageGuardOfKameronKove : BaseGuardian
	{ 
		[Constructable] 
		public VillageGuardOfKameronKove() : base( AIType.AI_Mage, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "Village Guard of Kameron Kove"; 
			Hue = Utility.RandomList( 3,28,38,48,53,58,63,88,93 );

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

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 386;
				Name = NameList.RandomName( "female" );
			}
			else
			{
				Body = 390;
				Name = NameList.RandomName( "male" );
			}
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public VillageGuardOfKameronKove( Serial serial ) : base( serial ) 
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