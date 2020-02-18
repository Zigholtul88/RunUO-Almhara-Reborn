using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a cavern mongbat corpse" )]
	public class CavernMongbatRavager : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public CavernMongbatRavager() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = NameList.RandomName( "mongbat" );
			Title = "the cavern mongbat ravager"; 
			Body = 39;
			Hue = Utility.RandomList( 1002,1005,1012,1023,1035,1038,1041,1047,1052,1058 );
			BaseSoundID = 422;

			SetStr( 127, 136 );
			SetDex( 79, 87 );
			SetInt( 39, 51 );

			SetHits( 275, 335 );

			SetDamage( 4, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25 );

			SetSkill( SkillName.MagicResist, 32.8, 41.8 );
			SetSkill( SkillName.Tactics, 56.7, 64.1 );
			SetSkill( SkillName.Wrestling, 67.8, 72.5 );

			Fame = 7500;
			Karma = -7500;

			PackGold( 149, 212 );

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

		public CavernMongbatRavager( Serial serial ) : base( serial )
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
