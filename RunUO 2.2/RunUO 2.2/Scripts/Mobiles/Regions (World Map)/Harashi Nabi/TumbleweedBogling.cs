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
	[CorpseName( "a tumbleweed bogling corpse" )]
	public class TumbleweedBogling : BaseCreature
	{
		[Constructable]
		public TumbleweedBogling() : base( AIType.AI_Melee, FightMode.Closest, 8, 1, 0.2, 0.4 )
		{
			Name = "a tumbleweed bogling";
			Body = 779;
			Hue = 1169;
			BaseSoundID = 422;

			SetStr( 396, 420 );
			SetDex( 191, 215 );
			SetInt( 21, 45 );

			SetHits( 458, 572 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.MagicResist, 75.1, 100.0 );
			SetSkill( SkillName.Tactics, 55.1, 80.0 );
			SetSkill( SkillName.Wrestling, 55.1, 75.0 );

			Fame = 4500;
			Karma = -4500;

                        PackGold( 100, 500 );

			PackItem( new Log( 4 ) );
			PackItem( new Engines.Plants.Seed() );
		}

		public override int Hides{ get{ return 6; } }
		public override int Meat{ get{ return 1; } }

		public TumbleweedBogling( Serial serial ) : base( serial )
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