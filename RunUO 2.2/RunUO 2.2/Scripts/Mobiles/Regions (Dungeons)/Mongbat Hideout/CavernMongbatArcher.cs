using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a cavern mongbat corpse" )]
	public class CavernMongbatArcher : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.LightningArrow;
		}

		[Constructable]
		public CavernMongbatArcher() : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = NameList.RandomName( "mongbat" );
			Title = "the cavern mongbat archer"; 
			Body = 39;
			Hue = Utility.RandomList( 1002,1005,1012,1023,1035,1038,1041,1047,1052,1058 );
			BaseSoundID = 422;

			SetStr( 47, 70 );
			SetDex( 49, 63 );
			SetInt( 18, 29 );

			SetHits( 175, 225 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 18 );

			SetSkill( SkillName.Archery, 73.5, 89.7 );
			SetSkill( SkillName.MagicResist, 18.9, 25.8 );
			SetSkill( SkillName.Tactics, 32.5, 46.9 );

			Fame = 5500;
			Karma = -5500;

			PackGold( 55, 95 );
			AddItem( new MagicalShortbow() );
			PackItem( new Arrow( Utility.RandomMinMax( 55, 77 ) ) );

			PackItem( new FishScale( Utility.RandomMinMax( 6, 12 ) ) );
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs(), from );
                              corpse.AddCarvedItem( new Hides(6), from );
                              corpse.AddCarvedItem( new CavernMongbatClaw(), from );

                              from.SendMessage( "You carve up a raw rib, some hides and a mongbat claw." );
                              corpse.Carved = true;  
			}
                }

		public CavernMongbatArcher( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
