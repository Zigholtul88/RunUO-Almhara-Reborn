using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a cavern mongbat corpse" )]
	public class CavernMongbatShaman : BaseCreature
	{
		[Constructable]
		public CavernMongbatShaman() : base( AIType.AI_Mage, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
			Name = NameList.RandomName( "mongbat" );
			Title = "the cavern mongbat shaman"; 
			Body = 39;
			Hue = Utility.RandomList( 1002,1005,1012,1023,1035,1038,1041,1047,1052,1058 );
			BaseSoundID = 422;

			SetStr( 73, 92 );
			SetDex( 53, 59 );
			SetInt( 97, 102 );

			SetHits( 175, 200 );
			SetMana( 194, 204 );

			SetDamage( 1, 4 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 21 );

			SetSkill( SkillName.Magery, 45.5, 50.5 );
			SetSkill( SkillName.MagicResist, 18.9, 25.8 );
			SetSkill( SkillName.Tactics, 32.5, 46.9 );
			SetSkill( SkillName.Wrestling, 47.8, 57.9 );

			Fame = 6500;
			Karma = -6500;

			ControlSlots = 1;

			PackGold( 74, 126 );
			PackReg( 37, 42 );

			PackItem( new FishScale( Utility.RandomMinMax( 6, 12 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.LowScrolls );
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

		public CavernMongbatShaman( Serial serial ) : base( serial )
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
