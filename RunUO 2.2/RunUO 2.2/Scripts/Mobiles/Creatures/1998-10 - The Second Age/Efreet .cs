using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an efreet corpse" )]
	public class Efreet : BaseCreature
	{
		[Constructable]
		public Efreet () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an efreet";
			Body = 131;
			BaseSoundID = 768;

			SetStr( 326, 355 );
			SetDex( 266, 285 );
			SetInt( 171, 195 );

			SetHits( 392, 426 );
			SetMana( 342, 390 );

			SetDamage( 11, 13 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Fire, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 56 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.EvalInt, 60.1, 75.0 );
			SetSkill( SkillName.Magery, 60.1, 75.0 );
			SetSkill( SkillName.MagicResist, 60.1, 75.0 );
			SetSkill( SkillName.Tactics, 60.1, 80.0 );
			SetSkill( SkillName.Wrestling, 60.1, 80.0 );

			Fame = 10000;
			Karma = -10000;

			PackGold( 45, 51 );

			PackItem( new TigerEye() );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new SummonDaemonScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );

			if ( 0.08 > Utility.RandomDouble() )
			{
				switch ( Utility.Random( 5 ) )
				{
					case 0: PackItem( new DaemonBoneArms() ); break;
					case 1: PackItem( new DaemonBoneChest() ); break;
					case 2: PackItem( new DaemonBoneGloves() ); break;
					case 3: PackItem( new DaemonBoneHelm() ); break;
					case 4: PackItem( new DaemonBoneLegs() ); break;
				}
			}
		}

		public Efreet( Serial serial ) : base( serial )
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
