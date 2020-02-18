using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class TestMob1 : BaseCreature
	{
		[Constructable]
		public TestMob1() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "Bob";
			Title = "the Gate Keeper";
			Body = 0x1D;
			BaseSoundID = 0x9E;

			SetStr( 47, 70 );
			SetDex( 49, 63 );
			SetInt( 18, 29 );

			SetHits( 75, 100 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 18 );

			SetSkill( SkillName.MagicResist, 18.9, 25.8 );
			SetSkill( SkillName.Tactics, 32.5, 46.9 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 1500;
			Karma = -1500;

			PackGold( 2, 5 );
			AddItem( new MagicalShortbow() );
			PackItem( new Arrow( Utility.RandomMinMax( 5, 7 ) ) );

			PackItem( new FishScale( Utility.RandomMinMax( 6, 12 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}

                public override void OnDeath( Container corpse )
                {
                //change the line below to the coords and map you want
/////////////////////// Mongbat Hideout Entrance ///////////////////////
                        Moongate gate = new Moongate( new Point3D( 1341, 1198, 0 ), Map.Malas );
 
                if( gate != null && !gate.Deleted && corpse != null && !corpse.Deleted )
                {
                        gate.MoveToWorld( corpse.Location, corpse.Map );
 
                //set how long you want the gate to stay open by changing the TimeSpan.FromSeconds in the line below
                        Timer.DelayCall( TimeSpan.FromSeconds( 10.0 ), new TimerCallback( gate.Delete ) );
                }
                        base.OnDeath( corpse );
                }

		public TestMob1( Serial serial ) : base( serial )
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
