using System; 
using Server.Items; 
using Server; 
using Server.Misc; 

namespace Server.Mobiles 
{ 
	public class Actor : BaseCreature 
	{ 
		[Constructable] 
		public Actor () : base( AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4 ) 
		{ 
			SetStr( 35, 63 );
			SetDex( 24, 82 );
			SetInt( 19, 98 );

			SetDamage( 1, 5 );

			SetSkill( SkillName.Anatomy, 31.2, 71.4 );
			SetSkill( SkillName.MagicResist, 3.9, 24.4 );
			SetSkill( SkillName.Wrestling, 46.5, 84.1 );
			SetSkill( SkillName.Tactics, 29.8, 40.3 );

			SpeechHue = Utility.RandomDyedHue(); 

			Hue = Utility.RandomSkinHue(); 

			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 0x191; 
				this.Name = NameList.RandomName( "female" );
				AddItem( new FancyDress( Utility.RandomDyedHue() ) ); 
				Title = "the actress"; 
			} 
			else 
			{ 
				this.Body = 0x190; 
				this.Name = NameList.RandomName( "male" );
				AddItem( new LongPants( Utility.RandomNeutralHue() ) ); 
				AddItem( new FancyShirt( Utility.RandomDyedHue() ) );
				Title = "the actor";
			} 

			AddItem( new Boots( Utility.RandomNeutralHue() ) );

			Utility.AssignRandomHair( this );

			Container pack = new Backpack(); 

			pack.DropItem( new Gold( 10, 15 ) );

			pack.Movable = false; 

			AddItem( pack ); 
		} 


		public override bool ClickTitle{ get{ return false; } }

		public Actor( Serial serial ) : base( serial ) 
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
