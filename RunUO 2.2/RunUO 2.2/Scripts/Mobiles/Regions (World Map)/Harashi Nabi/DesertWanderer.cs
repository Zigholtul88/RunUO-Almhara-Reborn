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
	[CorpseName( "a desert wanderer corpse" )]
	public class DesertWanderer : BaseCreature
	{
		[Constructable]
		public DesertWanderer() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a desert wanderer";
			Body = 316;
			Hue = 149;
			BaseSoundID = 377;

			SetStr( 311, 400 );
			SetDex( 101, 125 );
			SetInt( 201, 250 );

			SetHits( 451, 500 );

			SetDamage( 5, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.MagicResist, 50.1, 75.0 );
			SetSkill( SkillName.Tactics, 60.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 70.0 );

			Fame = 5000;
			Karma = -5000;

                        PackGold( 100, 500 );

			int count = Utility.RandomMinMax( 2, 3 );

			for ( int i = 0; i < count; ++i )
				PackItem( new TreasureMap( 3, Map.Malas ) );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public DesertWanderer( Serial serial ) : base( serial )
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