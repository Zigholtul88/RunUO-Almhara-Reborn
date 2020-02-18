using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a sea serpents corpse" )]
	[TypeAlias( "Server.Mobiles.Seaserpant" )]
	public class SeaSerpent : BaseFastEnemy
	{
		[Constructable]
		public SeaSerpent() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = "a sea serpent";
			Body = 150;
			BaseSoundID = 447;

			Hue = Utility.Random( 0x530, 9 );

			SetStr( 186, 215 );
			SetDex( 62, 83 );
			SetInt( 61, 87 );

			SetHits( 720, 954 );
			SetMana( 305, 435 );

			SetDamage( 5, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.Magery, 99.1, 113.0 );
			SetSkill( SkillName.MagicResist, 64.0, 74.9 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 90.1, 99.4 );
			SetSkill( SkillName.Wrestling, 84.3, 93.0 );

			Fame = 16000;
			Karma = -16000;

			CanSwim = true;
			CantWalk = true;

			if ( Utility.RandomBool() )
				PackItem( new SulfurousAsh( 144 ) );
			else
				PackItem( new BlackPearl( 144 ) );

			PackItem( new RawFishSteak() );
			PackItem( new SpecialFishingNet() );

			PackGold( 561, 938 );

			PackItem( new DragonScale( Utility.RandomMinMax( 11, 14 ) ) );

			PackItem( new LightningScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 12 );
		}

		public override bool HasBreath{ get{ return true; } }
		public override int Meat{ get{ return 15; } }
		public override int Hides{ get{ return 35; } }
		public override HideType HideType{ get{ return HideType.Horned; } }
		public override int Scales{ get{ return 35; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Blue; } }

		public SeaSerpent( Serial serial ) : base( serial )
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