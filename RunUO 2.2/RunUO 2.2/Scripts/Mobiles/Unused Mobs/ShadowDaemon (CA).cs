using System;
using Server;
using Server.Items;
using Server.Factions;

namespace Server.Mobiles
{
	[CorpseName( "a shadow daemon corpse" )]
	public class ShadowDaemon : BaseCreature
	{
		public override Faction FactionAllegiance { get { return Shadowlords.Instance; } }
		public override Ethics.Ethic EthicAllegiance { get { return Ethics.Ethic.Evil; } }

		[Constructable]
		public ShadowDaemon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "daemon" );
			Title = "the shadow daemon";
			Body = 429;
			BaseSoundID = 357;

			SetStr( 478, 505 );
			SetDex( 82, 94 );
			SetInt( 305, 325 );

			SetHits( 572, 606 );
			SetMana( 1525, 1625 );

			SetDamage( 7, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 52, 58 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.EvalInt, 72.0, 77.2 );
			SetSkill( SkillName.Magery, 75.1, 82.8 );
			SetSkill( SkillName.MagicResist, 86.4, 95.0 );
			SetSkill( SkillName.Tactics, 70.8, 79.6 );
			SetSkill( SkillName.Wrestling, 64.5, 80.8 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 52; // Random AR = 52, 55, 58

			PackGold( 47, 69 );

			switch ( Utility.Random( 5 ))
			{
				case 0: PackItem( new Amber() ); break;
				case 1: PackItem( new Chrysoberyl() ); break;
				case 2: PackItem( new Garnet() ); break;
				case 3: PackItem( new Jade() ); break;
				case 4: PackItem( new TigerEye() ); break;
			}

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new SummonDaemonScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average, 2 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override int Meat{ get{ return 1; } }

		public ShadowDaemon( Serial serial ) : base( serial )
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
