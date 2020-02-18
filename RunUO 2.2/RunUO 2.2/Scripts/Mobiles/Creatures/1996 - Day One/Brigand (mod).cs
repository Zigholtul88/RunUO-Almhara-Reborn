using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	public class Brigand : BaseCreature
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 60.0 ); //the delay between talks is 10 seconds
		public DateTime m_NextTalk;

		public override bool ClickTitle{ get{ return false; } }

		[Constructable]
		public Brigand() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomDyedHue();
			Title = "the brigand";
			Hue = Utility.RandomSkinHue();

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 0x191;
				Name = NameList.RandomName( "female" );
				AddItem( new Skirt( Utility.RandomNeutralHue() ) );
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName( "male" );
				AddItem( new ShortPants( Utility.RandomNeutralHue() ) );
			}

			SetStr( 87, 218 );
			SetDex( 24, 178 );
			SetInt( 19, 98 );

			SetDamage( 10, 23 );

			SetSkill( SkillName.Fencing, 95.0, 97.5 );
			SetSkill( SkillName.Macing, 93.0, 98.5 );
			SetSkill( SkillName.MagicResist, 0.0 );
			SetSkill( SkillName.Swords, 98.0, 99.5 );
			SetSkill( SkillName.Tactics, 89.0, 93.5 );
			SetSkill( SkillName.Wrestling, 63.0, 81.5 );

			Fame = 1200;
			Karma = -1200;

			AddItem( new Boots( Utility.RandomNeutralHue() ) );
			AddItem( new FancyShirt());
			AddItem( new Bandana());

			PackGold( 2, 7 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new CreateFoodScroll() );

			PackItem( new FishScale( Utility.RandomMinMax( 4, 8 ) ) );

			switch ( Utility.Random( 7 ))
			{
				case 0: AddItem( new Longsword() ); break;
				case 1: AddItem( new Cutlass() ); break;
				case 2: AddItem( new Broadsword() ); break;
				case 3: AddItem( new Axe() ); break;
				case 4: AddItem( new Club() ); break;
				case 5: AddItem( new Dagger() ); break;
				case 6: AddItem( new Spear() ); break;
			}

			Utility.AssignRandomHair( this );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 4 ) && InLOS( m ) ) // check if it's time to talk & mobile in range & in los.
			{
				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 4 ))
				{
					case 0: Say("Is that the best you got?"); 
						break;
					case 1: Say("Come and get some, you filthy swine."); 
						break;	
					case 2: Say("How boring, you fight like a snail."); 
						break;	
					case 3: Say("Over here, mate."); 
						break;	
				};
			}
		}

		public Brigand( Serial serial ) : base( serial )
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
