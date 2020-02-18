using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a dragonian ravager corpse" )]
	public class DragonianRavager : BaseCreature
	{
		[Constructable]
		public DragonianRavager () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the dragonian ravager"; 
			Body = 362;
			BaseSoundID = 362;

			SetStr( 401, 430 );
			SetDex( 133, 152 );
			SetInt( 101, 140 );

			SetHits( 482, 516 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Fire, 20 );

			SetResistance( ResistanceType.Physical, 46 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.4, 88.5 );
			SetSkill( SkillName.Wrestling, 68.8, 81.7 );

			Fame = 65000;
			Karma = -65000;

			PackReg( 25 );

			PackGold( 51, 73 );

			PackItem( new DragonScale( Utility.RandomMinMax( 9, 14 ) ) );

			switch ( Utility.Random( 2 ))
			{
				case 0: PackItem( new Lupis() ); break;
				case 1: PackItem( new Tsavorite() ); break;
			}

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new FireballScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(10), from);
                        corpse.AddCarvedItem(new HornedHides(20), from);
                        corpse.AddCarvedItem(new BlackScales(10), from);
                        corpse.AddCarvedItem(new RedScales(10), from);
                        corpse.AddCarvedItem(new DragonScale( Utility.RandomMinMax( 25, 40 )), from);
                        corpse.AddCarvedItem(new DragonHeart(), from);

                        from.SendMessage( "You carve up raw ribs, horned hides, black and red scales, specialized dragon scales, and a dragon heart." );
                        corpse.Carved = true; 
			}
                }

		public DragonianRavager( Serial serial ) : base( serial )
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