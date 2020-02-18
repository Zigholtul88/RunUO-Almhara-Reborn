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
	[CorpseName( "a dobhar-chu corpse" )]
	public class Dobharchu : BaseCreature
	{
		[Constructable]
		public Dobharchu() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a dobhar-chu";
			Body = 0xD9;
                        Hue = 93;
			BaseSoundID = 0x85;

			SetStr( 30, 50 );
			SetDex( 25, 35 );
			SetInt( 15, 30 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 12 );

			SetSkill( SkillName.MagicResist, 7.6, 9.8 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 400;
			Karma = -400;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 9.1;

			PackItem( new FishScale( Utility.RandomMinMax( 12, 15 ) ) );
		}

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public Dobharchu(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}