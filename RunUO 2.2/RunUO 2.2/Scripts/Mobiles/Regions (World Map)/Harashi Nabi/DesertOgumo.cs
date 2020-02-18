using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a desert ogumo corpse" )]
	public class DesertOgumo : BaseCreature
	{
		[Constructable]
		public DesertOgumo() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a desert ogumo";
			Body = 20;
			Hue = 150;
			BaseSoundID = 0x388;

			SetStr( 276, 300 );
			SetDex( 226, 245 );
			SetInt( 136, 160 );

			SetHits( 446, 460 );
			SetMana( 0 );

			SetDamage( 6, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 85.1, 90.0 );
			SetSkill( SkillName.Wrestling, 90.1, 95.0 );

			Fame = 4500;
			Karma = -4500;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 74.7;

                        PackGold( 100, 500 );
			PackItem( new SpidersSilk( 50 ) );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }

		public DesertOgumo( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 387 )
				BaseSoundID = 0x388;
		}
	}
}