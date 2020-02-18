using System;
using Server.Items;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
	public class Gypsy : BaseCreature
	{
		[Constructable]
		public Gypsy(): base( AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4 )
		{
			SetStr( 35, 63 );
			SetDex( 24, 82 );
			SetInt( 19, 98 );

			SetDamage( 1, 5 );

			SetSkill( SkillName.Cooking, 65.0, 88.0 );
			SetSkill( SkillName.Fencing, 46.5, 84.1 );
			SetSkill( SkillName.Snooping, 65.0, 88.0 );
			SetSkill( SkillName.Stealing, 65.0, 88.0 );
			SetSkill( SkillName.Tactics, 29.8, 40.3 );

			SpeechHue = Utility.RandomDyedHue();

			Hue = Utility.RandomSkinHue();

			if( this.Female = Utility.RandomBool() )
			{
				this.Body = 0x191;
				this.Name = NameList.RandomName( "female" );
				AddItem( new Kilt( Utility.RandomDyedHue() ) );
				AddItem( new Shirt( Utility.RandomDyedHue() ) );
				AddItem( new ThighBoots() );
				Title = "the gypsy";
			}
			else
			{
				this.Body = 0x190;
				this.Name = NameList.RandomName( "male" );
				AddItem( new ShortPants( Utility.RandomNeutralHue() ) );
				AddItem( new Shirt( Utility.RandomDyedHue() ) );
				AddItem( new Sandals() );
				Title = "the gypsy";
			}

			AddItem( new Bandana( Utility.RandomDyedHue() ) );
			AddItem( new Dagger() );

			Utility.AssignRandomHair( this );

			Container pack = new Backpack();

			pack.DropItem( new Gold( 10, 15 ) );

			pack.Movable = false;

			AddItem( pack );
		}


		public override bool CanTeach { get { return true; } }
		public override bool ClickTitle { get { return false; } }

		public Gypsy( Serial serial )
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
