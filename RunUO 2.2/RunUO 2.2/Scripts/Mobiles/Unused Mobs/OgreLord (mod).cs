using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Factions;

namespace Server.Mobiles
{
	[CorpseName( "an ogre lords corpse" )]
	public class OgreLord : BaseCreature
	{
		public override Faction FactionAllegiance { get { return Minax.Instance; } }
		public override Ethics.Ethic EthicAllegiance { get { return Ethics.Ethic.Evil; } }

		[Constructable]
		public OgreLord () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ogre lord";
			Body = 83;
			BaseSoundID = 427;

			SetStr( 819, 934 );
                        SetDex( 66, 75 );
                        SetInt( 49, 70 );

			SetHits( 952, 1104 );

			SetDamage( 20, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.MagicResist, 126.7, 140.0 );
			SetSkill( SkillName.Tactics, 91.1, 99.9 );
			SetSkill( SkillName.Wrestling, 91.2, 96.8 );

			Fame = 50000;
			Karma = -50000;

			VirtualArmor = 50;

			PackItem( new Club() );
			PackItem( new Arrow( Utility.RandomMinMax( 12, 18 ) ) );
			PackGold( 48, 61 );

			PackItem( new FishScale( Utility.RandomMinMax( 19, 27 ) ) );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override int Meat{ get{ return 2; } }

		public OgreLord( Serial serial ) : base( serial )
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