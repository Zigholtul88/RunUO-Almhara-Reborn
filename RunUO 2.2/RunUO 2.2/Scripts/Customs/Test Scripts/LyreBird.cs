using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a lyre bird corpse" )]	
	public class LyreBird : BaseCreature
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 15.0 ); //the delay between talks is 15 seconds
		public DateTime m_NextTalk;

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public LyreBird() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a lyre bird";
			Body = 831;
			BaseSoundID = 0x8F;
			Hue = 1151;

			SetStr( 12, 17 );
			SetDex( 9, 14 );
			SetInt( 5, 8 );

			SetHits( 15, 30 );
			SetMana( 100 );

			SetDamage( 3, 11 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.Wrestling, 93.1, 98.6 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.MagicResist, 2.3, 2.7 );

			Fame = 180;
			Karma = 0;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 0.0;

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new Apple() ); break;
				case 1: PackItem( new Banana() ); break;
				case 2: PackItem( new Grapes() ); break;
				case 3: PackItem( new Lemon() ); break;
				case 4: PackItem( new Lime() ); break;
				case 5: PackItem( new Pear() ); break;
			}
		}

		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 5 ) && InLOS( m ) && m is PlayerMobile ) // check if it's time to talk & mobile in range & in los.
			{
				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 50 ) )
				{
					case 0: Say("**");
						PlaySound(0xA8); 
						break;
					case 1: Say("**"); 
						PlaySound(0x99);
						break;	
					case 2: Say("**");
						PlaySound(0x3F3); 
						break;
					case 3: Say("**"); 
						PlaySound(0x462);
						break;
					case 4: Say("**");
						PlaySound(0xC9); 
						break;
					case 5: Say("**"); 
						PlaySound(0xCA);
						break;
					case 6: Say("**"); 
						PlaySound(0xCB);
						break;
					case 7: Say("**"); 
						PlaySound(0xCC);
						break;
					case 8: Say("**"); 
						PlaySound(0xD6);
						break;
					case 9: Say("**"); 
						PlaySound(0xE5);
						break;
					case 10: Say("**"); 
						PlaySound(846);
						break;
					case 11: Say("**"); 
						PlaySound(0x21D);
						break;
					case 12: Say("**"); 
						PlaySound(0x162);
						break;
					case 13: Say("**"); 
						PlaySound(0x163);
						break;
					case 14: Say("**"); 
						PlaySound(0x270);
						break;
					case 15: Say("**"); 
						PlaySound(1511);
						break;
					case 16: Say("**"); 
						PlaySound(1508);
						break;
					case 17: Say("**"); 
						PlaySound(1510);
						break;
					case 18: Say("**"); 
						PlaySound(1509);
						break;
					case 19: Say("**"); 
						PlaySound(456);
						break;
					case 20: Say("**"); 
						PlaySound(0xC9);
						break;
					case 21: Say("**"); 
						PlaySound(0xCA);
						break;
					case 22: Say("**"); 
						PlaySound(0xCB);
						break;
					case 23: Say("**"); 
						PlaySound(0x26B);
						break;
					case 24: Say("**"); 
						PlaySound(0x5A);
						break;
					case 25: Say("**"); 
						PlaySound(0x164);
						break;
					case 26: Say("**"); 
						PlaySound(0x187);
						break;
					case 27: Say("**"); 
						PlaySound(0x1BA);
						break;
					case 28: Say("**"); 
						PlaySound(422);
						break;
					case 29: Say("**"); 
						PlaySound(0x388);
						break;
					case 30: Say("**"); 
						PlaySound(1320);
						break;
					case 31: Say("**"); 
						PlaySound(1354);
						break;
					case 32: Say("**"); 
						PlaySound(0x275);
						break;
					case 33: Say("**"); 
						PlaySound(0xA3);
						break;
					case 34: Say("**"); 
						PlaySound(0xC4);
						break;
					case 35: Say("**"); 
						PlaySound(0x64);
						break;
					case 36: Say("**"); 
						PlaySound(0x69);
						break;
					case 37: Say("**"); 
						PlaySound(0x6E);
						break;
					case 38: Say("**"); 
						PlaySound(0x78);
						break;
					case 39: Say("**"); 
						PlaySound(0x4D7);
						break;
					case 40: Say("**"); 
						PlaySound(0xD9);
						break;
					case 41: Say("**"); 
						PlaySound(0x99);
						break;
					case 42: Say("**"); 
						PlaySound(0x9E);
						break;
					case 43: Say("**"); 
						PlaySound(0x82);
						break;
					case 44: Say("**"); 
						PlaySound(0x83);
						break;
					case 45: Say("**"); 
						PlaySound(0x84);
						break;
					case 46: Say("**"); 
						PlaySound(0x277);
						break;
					case 47: Say("**"); 
						PlaySound(0x270);
						break;
					case 48: Say("**"); 
						PlaySound(0x273);
						break;
					case 49: Say("**"); 
						PlaySound(0x279);
						break;
				};
			}
		}

		public LyreBird( Serial serial ) : base( serial )
		{
		}

		public override int GetIdleSound() { return 0x07D; }
		public override int GetAngerSound() { return 0x07E; }
		public override int GetAttackSound() { return 0x07F; }
		public override int GetHurtSound() { return 0x080; }
		public override int GetDeathSound() { return 0x081; }

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