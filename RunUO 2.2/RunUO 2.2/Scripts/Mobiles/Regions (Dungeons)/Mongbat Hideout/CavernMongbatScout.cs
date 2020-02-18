using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a cavern mongbat corpse" )]
	public class CavernMongbatScout : BaseCreature
	{
		[Constructable]
		public CavernMongbatScout() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "mongbat" );
			Title = "the cavern mongbat scout"; 
			Body = 39;
			Hue = Utility.RandomList( 1002,1005,1012,1023,1035,1038,1041,1047,1052,1058 );
			BaseSoundID = 422;

			SetStr( 47, 70 );
			SetDex( 49, 63 );
			SetInt( 18, 29 );

			SetHits( 150, 175 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15 );

			SetSkill( SkillName.MagicResist, 12.2, 21.7 );
			SetSkill( SkillName.Tactics, 27.4, 40.5 );
			SetSkill( SkillName.Wrestling, 17.9, 27.9 );

			Fame = 5000;
			Karma = -5000;

			ControlSlots = 1;

			PackGold( 45, 75 );
			PackReg( 15, 25 );

			PackItem( new FishScale( Utility.RandomMinMax( 2, 10 ) ) );
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

		public CavernMongbatScout( Serial serial ) : base( serial )
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
