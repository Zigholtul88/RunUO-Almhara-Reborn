using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a squidlarkin corpse" )]
	public class Squidlarkin : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public Squidlarkin() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a squidlarkin";
			Body = 364;
			BaseSoundID = 0x451;

			SetStr( 223, 268 );
			SetDex( 196, 212 );
			SetInt( 124, 147 );

			SetHits( 289, 385 );

			SetDamage( 8, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 45 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.MagicResist, 37.5, 42.9 );
			SetSkill( SkillName.Tactics, 70.1, 80.0 );
			SetSkill( SkillName.Wrestling, 95.1, 100.0 );

			Fame = 14000;
			Karma = -14000;

			PackReg( 1, 5 );

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 16, 32 ) ) );
			pack.DropItem( Loot.RandomStatue() );
			pack.DropItem( new Pearl() );

			if ( 0.04 > Utility.RandomDouble() )
				pack.DropItem( new Pearl() );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( Loot.RandomGem() );

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseClothing clothing1 = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing1, 3, 10, 25 );  

                       pack.DropItem( clothing1 );
                  }

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseClothing clothing2 = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing2, 3, 10, 25 );  

                       pack.DropItem( clothing2 );
                  }

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseWeapon weapon = Loot.RandomWeapon( true );
		           BaseRunicTool.ApplyAttributesTo( weapon, 3, 10, 25 );  

                       pack.DropItem( weapon );
                  }

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseJewel necklace = new GoldNecklace();
			     if ( Core.AOS )
		           BaseRunicTool.ApplyAttributesTo( necklace, 2, 10, 15 ); 

                       pack.DropItem( necklace );
                  }

			PackItem( pack );

			switch ( Utility.Random( 3 ))
			{
				case 0: AddItem( Loot.RandomArmor() ); break;
				case 1: AddItem( Loot.RandomClothing() ); break;
				case 2: AddItem( Loot.RandomWeapon() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawFishSteak( Utility.RandomMinMax( 9, 13 )), from);
                        corpse.AddCarvedItem(new FishScale( Utility.RandomMinMax( 12, 15 )), from);

                        from.SendMessage( "You carve up raw fish steaks and some fish scales." );
                        corpse.Carved = true; 
			}
                }

		public Squidlarkin( Serial serial ) : base( serial )
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