using System;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a snowbound ridgeback corpse" )]
	public class SnowboundRidgeback : BaseMount
	{
		[Constructable]
		public SnowboundRidgeback() : this( "a snowbound ridgeback" )
		{
		}

		[Constructable]
		public SnowboundRidgeback( string name ) : base( name, 188, 0x3EB8, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
                        Hue = 1151;
			BaseSoundID = 0x3F3;

			SetStr( 298, 335 );
			SetDex( 127, 142 );
			SetInt( 54, 71 );

			SetHits( 347, 396 );

			SetDamage( 11, 15 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 70 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.MagicResist, 32.2, 38.8 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.Wrestling, 80.1, 100.0 );

			Fame = 14500;
			Karma = -14500;

			PackItem( new DiamondDust( Utility.RandomMinMax( 5, 11 ) ) );

			Container pack = new Backpack();
			pack.DropItem( new Gold( Utility.RandomMinMax( 13, 22 ) ) );
			pack.DropItem( new HealPotion() );
			pack.DropItem( new TurquoiseCustom() );
			pack.DropItem( new BlackPearl( Utility.RandomMinMax( 5, 8 ) ) );
			PackItem( pack );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new HarmScroll() );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
			AddLoot( LootPack.Potions );
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public SnowboundRidgeback( Serial serial ) : base( serial )
		{
		}

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