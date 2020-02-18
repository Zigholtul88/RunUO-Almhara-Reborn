using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a blood chimera corpse" )]
	public class BloodChimera : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public BloodChimera() : base( AIType.AI_Melee, FightMode.Closest, 6, 1, 0.175, 0.350 )
		{
			Name = "a blood chimera";
			Body = 359;
			Hue = 0x648;

			SetStr( 376, 449 );
			SetDex( 218, 252 );
			SetInt( 138, 164 );

			SetHits( 494, 527 );

			SetDamage( 13, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 40 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.4, 88.5 );
			SetSkill( SkillName.Wrestling, 68.8, 81.7 );

			Fame = 35500;
			Karma = -35500;

			PackReg( 25 );

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 57, 76 ) ) );
			pack.DropItem( Loot.RandomStatue() );
			pack.DropItem( Loot.RandomClothing() );

                        if (Utility.RandomDouble() < 0.4 )
                                PackItem(new TreasureMap(2, Map.Malas ) );

 		      if ( Utility.RandomDouble() < 0.03 )
                  {
			     BaseHat hat = Loot.RandomHat( true );
		           BaseRunicTool.ApplyAttributesTo( hat, 4, 25, 30 );

                       pack.DropItem( hat );
                  }


 		      if ( Utility.RandomDouble() < 0.04 )
                  {
			     BaseWeapon weapon = Loot.RandomRangedWeapon( true );
		           BaseRunicTool.ApplyAttributesTo( weapon, 5, 25, 40 );

                       pack.DropItem( weapon );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseArmor armor = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor, 5, 25, 40 );

                       pack.DropItem( armor );
                  }

			Container bag = new Bag();
			bag.DropItem( new Gold( Utility.RandomMinMax( 37, 71 ) ) );
			bag.DropItem( Loot.RandomInstrument() );
			bag.DropItem( Loot.RandomShield() );
			bag.DropItem( Loot.RandomPotion() );
			bag.DropItem( Loot.RandomGem() );
			bag.DropItem( Loot.RandomGem() );

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseClothing clothing = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing, 4, 20, 25 );  

                       bag.DropItem( clothing );
                  }

                  if ( Utility.RandomDouble() < 0.05 )
                  {
                       BaseJewel jewel = new SilverRing();
			     if ( Core.AOS )
		           BaseRunicTool.ApplyAttributesTo( jewel, 4, 25, 40 ); 

                       bag.DropItem( jewel );
		      }

                  Item ScrollLoot = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                  ScrollLoot.Amount = Utility.Random( 2, 5 );
                  bag.DropItem( ScrollLoot );

			pack.DropItem( bag );

			PackItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 3 );
			AddLoot( LootPack.Gems, 2 );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override int Meat{ get{ return 8; } }
		public override int Hides{ get{ return 18; } }
		public override HideType HideType{ get{ return HideType.Horned; } }

		public override int GetIdleSound() { return 0x517; } 
		public override int GetAngerSound() { return 0x518; } 
		public override int GetAttackSound() { return 0x516; } 
		public override int GetHurtSound() { return 0x519; } 
		public override int GetDeathSound() { return 0x515; }

		public BloodChimera( Serial serial ) : base( serial )
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