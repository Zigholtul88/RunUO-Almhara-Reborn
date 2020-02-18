using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a cavern mongbat corpse" )]
	public class CavernMongbatBerserker : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public CavernMongbatBerserker() : base( AIType.AI_Archer, FightMode.Closest, 8, 1, 0.175, 0.350 )
		{
			Name = NameList.RandomName( "mongbat" );
			Title = "the cavern mongbat berserker"; 
			Body = 39;
			Hue = Utility.RandomList( 1002,1005,1012,1023,1035,1038,1041,1047,1052,1058 );
			BaseSoundID = 422;

			SetStr( 61, 82 );
			SetDex( 53, 65 );
			SetInt( 23, 35 );

			SetHits( 275, 300 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 18 );

			SetSkill( SkillName.MagicResist, 23.8, 29.9 );
			SetSkill( SkillName.Tactics, 85.6, 92.3 );
			SetSkill( SkillName.Wrestling, 91.6, 93.2 );

			Fame = 6500;
			Karma = -6500;

			ControlSlots = 1;

			PackGold( 126, 158 );

			PackItem( new FishScale( Utility.RandomMinMax( 9, 14 ) ) );
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

		public CavernMongbatBerserker( Serial serial ) : base( serial )
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
