using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a headless corpse" )]
	public class HeadlessOne : BaseCreature
	{
		[Constructable]
		public HeadlessOne() : base( AIType.AI_Melee, FightMode.Closest, 3, 1, 0.2, 0.4 )
		{
			Name = "a headless one";
			Body = 31;
			Hue = Utility.RandomSkinHue() & 0x7FFF;
			BaseSoundID = 0x39D;

			SetStr( 26, 47 );
			SetDex( 39, 55 );
			SetInt( 17, 30 );

			SetHits( 32, 60 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 18 );

			SetSkill( SkillName.MagicResist, 15.1, 19.5 );
			SetSkill( SkillName.Tactics, 25.1, 38.3 );
			SetSkill( SkillName.Wrestling, 31.8, 42.3 );

			Fame = 450;
			Karma = -450;

			VirtualArmor = 18;

			PackGold( 1, 3 );
			PackReg( 1, 4 );

			PackItem( new FishScale( Utility.RandomMinMax( 1, 3 ) ) );

			switch ( Utility.Random( 10 ))
			{
				case 0: PackItem( new LeftArm() ); break;
				case 1: PackItem( new RightArm() ); break;
				case 2: PackItem( new Torso() ); break;
				case 3: PackItem( new Bone() ); break;
				case 4: PackItem( new RibCage() ); break;
				case 5: PackItem( new RibCage() ); break;
				case 6: PackItem( new BonePile() ); break;
				case 7: PackItem( new BonePile() ); break;
				case 8: PackItem( new BonePile() ); break;
				case 9: PackItem( new BonePile() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public HeadlessOne( Serial serial ) : base( serial )
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