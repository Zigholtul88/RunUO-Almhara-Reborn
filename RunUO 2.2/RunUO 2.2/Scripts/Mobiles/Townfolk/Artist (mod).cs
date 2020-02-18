using System;
using Server.Items;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
	public class Artist : BaseCreature
	{

		[Constructable]
		public Artist(): base( AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4 )
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
			Title = "the artist";
			Hue = Utility.RandomSkinHue();


			if( this.Female = Utility.RandomBool() )
			{
				this.Body = 0x191;
				this.Name = NameList.RandomName( "female" );
			}
			else
			{
				this.Body = 0x190;
				this.Name = NameList.RandomName( "male" );
			}
			AddItem( new Doublet( Utility.RandomDyedHue() ) );
			AddItem( new Sandals( Utility.RandomNeutralHue() ) );
			AddItem( new ShortPants( Utility.RandomNeutralHue() ) );
			AddItem( new HalfApron( Utility.RandomDyedHue() ) );

			Utility.AssignRandomHair( this );

			Container pack = new Backpack();

			pack.DropItem( new Gold( 10, 15 ) );

			pack.Movable = false;

			AddItem( pack );
		}

		public override bool ClickTitle { get { return false; } }


		public Artist( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version 
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
