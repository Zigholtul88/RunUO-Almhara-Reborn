using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a bogling corpse" )]
	public class Bogling : BaseCreature
	{
		[Constructable]
		public Bogling() : base( AIType.AI_Melee, FightMode.Closest, 4, 1, 0.2, 0.4 )
		{
			Name = "a bogling";
			Body = 779;
			BaseSoundID = 422;

			SetStr( 96, 120 );
			SetDex( 91, 115 );
			SetInt( 21, 45 );

			SetHits( 305, 310 );

			SetDamage( 15, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Fire, -50 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.MagicResist, 75.1, 100.0 );
			SetSkill( SkillName.Tactics, 85.1, 90.0 );
			SetSkill( SkillName.Wrestling, 85.1, 95.0 );

			Fame = 5000;
			Karma = -500;

			PackGold( 95, 189 );

			PackItem( new Engines.Plants.Seed() );

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 125, 519 ) ) );
			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Grapes( Utility.RandomMinMax( 3, 7 ) ) );
			pack.DropItem( new Log( Utility.RandomMinMax( 4, 7 ) ) );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( Loot.RandomShield() );

			if ( 0.05 > Utility.RandomDouble() )
				pack.DropItem( Loot.RandomPotion() );

			if ( 0.04 > Utility.RandomDouble() )
				pack.DropItem( Loot.RandomGem() );

			PackItem( pack );
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs(1), from );
                              corpse.AddCarvedItem( new Hides(6), from );
                              corpse.AddCarvedItem( new Nirnroot( Utility.RandomMinMax( 2, 5 ) ), from );
                              corpse.AddCarvedItem( new FertileDirt( Utility.RandomMinMax( 7, 16 ) ), from );

                              from.SendMessage( "You carve up some raw ribs, hides, fertile dirt, and some nirnroot." );
                              corpse.Carved = true; 
			}
                }

		public Bogling( Serial serial ) : base( serial )
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