using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a deep sea serpents corpse" )]
	public class DeepSeaSerpent : BaseCreature
	{
		[Constructable]
		public DeepSeaSerpent() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a deep sea serpent";
			Body = 150;
			BaseSoundID = 447;

			Hue = Utility.Random( 0x8A0, 5 );

			SetStr( 259, 386 );
			SetDex( 100, 125 );
			SetInt( 110, 149 );

			SetHits( 302, 510 );
			SetMana( 550, 745 );

			SetDamage( 6, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 60 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.EvalInt, 8.0 );
			SetSkill( SkillName.Magery, 15.0 );
			SetSkill( SkillName.MagicResist, 61.1, 73.7 );
			SetSkill( SkillName.Tactics, 60.4, 66.6 );
			SetSkill( SkillName.Wrestling, 64.0, 69.7 );

			Fame = 6000;
			Karma = -6000;

			VirtualArmor = 60;

			CanSwim = true;
			CantWalk = true;

			PackItem( new SpecialFishingNet() );

			PackGold( 32, 38 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new ChainLightningScroll() );

			PackItem( new DragonScale( Utility.RandomMinMax( 15, 19 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override bool HasBreath{ get{ return true; } }
		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Horned; } }
		public override int Scales{ get{ return 8; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Blue; } }

		public DeepSeaSerpent( Serial serial ) : base( serial )
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