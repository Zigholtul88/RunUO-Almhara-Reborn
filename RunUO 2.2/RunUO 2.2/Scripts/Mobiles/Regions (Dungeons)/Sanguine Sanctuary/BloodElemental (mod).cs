using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a blood elemental corpse" )]
	public class BloodElemental : BaseCreature
	{
		[Constructable]
		public BloodElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a blood elemental";
			Body = 159;
			BaseSoundID = 278;

			SetStr( 527, 615 );
			SetDex( 67, 85 );
			SetInt( 226, 344 );

			SetHits( 632, 738 );
			SetMana( 1130, 1720 );

			SetDamage( 17, 27 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Poison, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 60 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.EvalInt, 58.0, 80.4 );
			SetSkill( SkillName.Magery, 87.5, 99.4 );
			SetSkill( SkillName.Meditation, 22.1, 61.7 );
			SetSkill( SkillName.MagicResist, 80.4, 94.7 );
			SetSkill( SkillName.Tactics, 80.5, 99.4 );
			SetSkill( SkillName.Wrestling, 82.2, 99.4 );

			Fame = 32500;
			Karma = -32500;

			VirtualArmor = 60;

			PackGold( 87, 99 );

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new Bloodstone() ); break;
				case 1: PackItem( new Peridot() ); break;
				case 2: PackItem( new Mandarin() ); break;
				case 3: PackItem( new Tourmaline() ); break;
				case 4: PackItem( new Sapphire() ); break;
				case 5: PackItem( new Diamond() ); break;
			}

			PackItem( new ElementalDust( Utility.RandomMinMax( 17, 22 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new ManaVampireScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Rich );
		}

		public BloodElemental( Serial serial ) : base( serial )
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
