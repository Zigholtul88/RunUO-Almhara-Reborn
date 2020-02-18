using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal dragon corpse" )]
	public class SkeletalDragon : BaseCreature
	{
		[Constructable]
		public SkeletalDragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the skeletal dragon"; 
			Body = 104;
			BaseSoundID = 0x488;

			SetStr( 792, 825 );
			SetDex( 88, 110 );
			SetInt( 437, 475 );

			SetHits( 956, 990 );
			SetMana( 2185, 2375 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 40, 60 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 40, 60 );

			SetSkill( SkillName.EvalInt, 80.1, 100.0 );
			SetSkill( SkillName.Magery, 80.1, 100.0 );
			SetSkill( SkillName.MagicResist, 100.3, 130.0 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 97.6, 100.0 );

			Fame = 62500;
			Karma = -62500;

////////////////////////////////Main Pack////////////////////////////////

			PackGold( 75, 92 );
			PackReg( 25, 35 );

////////////////////////////////1st Backpack////////////////////////////////

			Container pack1 = new Backpack();
			pack1.DropItem( new Cloak(532) );
			pack1.DropItem( new Circlet() );

 		      if ( Utility.RandomDouble() < 0.25 )
                  {
			     BaseArmor armor1 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor1, 5, 15, 30 );  

                       pack1.DropItem( armor1 );
                  }

 		      if ( Utility.RandomDouble() < 0.25 )
                  {
			     BaseArmor armor2 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor2, 5, 15, 30 );  

                       pack1.DropItem( armor2 );
                  }

 		      if ( Utility.RandomDouble() < 0.25 )
                  {
			     BaseArmor armor3 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor3, 5, 15, 30 );  

                       pack1.DropItem( armor3 );
                  }

 		      if ( Utility.RandomDouble() < 0.25 )
                  {
			     BaseArmor armor4 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor4, 5, 15, 30 );  

                       pack1.DropItem( armor4 );
                  }

 		      if ( Utility.RandomDouble() < 0.20 )
                  {
			     BaseArmor armor5 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor5, 5, 15, 30 );  

                       pack1.DropItem( armor5 );
                  }

 		      if ( Utility.RandomDouble() < 0.50 )
                  {
			     BaseWeapon weapon = Loot.RandomWeapon( true );
		           BaseRunicTool.ApplyAttributesTo( weapon, 5, 25, 30 );  

                       pack1.DropItem( weapon );
                  }

			Container bag1 = new Bag();
			bag1.DropItem( new Gold( Utility.RandomMinMax( 50, 100 ) ) );
			bag1.DropItem( new Bandage( Utility.RandomMinMax( 9, 18 ) ) );
			bag1.DropItem( Loot.RandomGem() );
			bag1.DropItem( Loot.RandomGem() );
			pack1.DropItem( bag1 );

			PackItem( pack1 );

////////////////////////////////2nd Backpack////////////////////////////////

			Container pack2 = new Backpack();

 		      if ( Utility.RandomDouble() < 0.10 )
                  {
			     BaseWeapon weapon = Loot.RandomWeapon( true );
		           BaseRunicTool.ApplyAttributesTo( weapon, 5, 15, 30 );  

                       pack2.DropItem( weapon );
                  }

 		      if ( Utility.RandomDouble() < 0.10 )
                  {
			     BaseArmor armor1 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor1, 5, 15, 30 );  

                       pack2.DropItem( armor1 );
                  }

 		      if ( Utility.RandomDouble() < 0.10 )
                  {
			     BaseArmor armor2 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor2, 5, 15, 30 );  

                       pack2.DropItem( armor2 );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseJewel earrings = new GoldEarrings();
			     if ( Core.AOS )
		           BaseRunicTool.ApplyAttributesTo( earrings, 5, 15, 30 ); 

                       pack2.DropItem( earrings );
                  }

			Container bag2 = new Bag();
			bag2.DropItem( new Gold( Utility.RandomMinMax( 100, 250 ) ) );
			bag2.DropItem( new DragonScale( Utility.RandomMinMax( 15, 25 ) ) );
			bag2.DropItem( Loot.RandomPotion() );
			bag2.DropItem( new GreaterCurePotion() );
			bag2.DropItem( new GreaterStrengthPotion() );
			bag2.DropItem( new HealPotion() );
			bag2.DropItem( Loot.RandomGem() );
			bag2.DropItem( Loot.RandomGem() );
			pack2.DropItem( bag2 );

			PackItem( pack2 );

////////////////////////////////3rd Backpack////////////////////////////////

			Container pack3 = new Backpack();
			pack3.DropItem( new Spellbook() );
			pack3.DropItem( Loot.RandomWand() );
			pack3.DropItem( Loot.RandomClothing() );
			pack3.DropItem( Loot.RandomClothing() );

 		      if ( Utility.RandomDouble() < 0.10 )
                  {
			     BaseClothing clothing = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing, 3, 15, 30 );  

                       pack3.DropItem( clothing );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseJewel necklace = new GoldNecklace();
			     if ( Core.AOS )
		           BaseRunicTool.ApplyAttributesTo( necklace, 3, 15, 30 ); 

                       pack3.DropItem( necklace );
                  }

			Container bag3 = new Bag();
			bag3.DropItem( new Gold( Utility.RandomMinMax( 25, 50 ) ) );
			bag3.DropItem( new Bandage( Utility.RandomMinMax( 5, 15 ) ) );
			bag3.DropItem( Loot.RandomGem() );

                  Item ScrollLoot1 = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                  ScrollLoot1.Amount = Utility.Random( 2, 5 );
                  bag3.DropItem( ScrollLoot1 );

                  Item ScrollLoot2 = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                  ScrollLoot2.Amount = Utility.Random( 2, 5 );
                  bag3.DropItem( ScrollLoot2 );

                  Item ScrollLoot3 = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                  ScrollLoot3.Amount = Utility.Random( 2, 5 );
                  bag3.DropItem( ScrollLoot3 );

			pack3.DropItem( bag3 );

			PackItem( pack3 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.MedScrolls, 1 );
			AddLoot( LootPack.LowScrolls, 5 );
			AddLoot( LootPack.Gems, 3 );

 		if ( Utility.RandomDouble() < 0.10 )
            {
	            BaseWeapon weapon = Loot.RandomWeapon( true );
			switch ( Utility.Random( 33 ) )
			{
				case 0: weapon = new BattleAxe(); break;
				case 1: weapon = new ExecutionersAxe (); break;
				case 2: weapon = new LargeBattleAxe(); break;
				case 3: weapon = new WarAxe(); break;
			      case 4: weapon = new Bow(); break;
				case 5: weapon = new Crossbow(); break;
				case 6: weapon = new HeavyCrossbow(); break;
				case 7: weapon = new WarHammer(); break;
				case 8: weapon = new WarMace(); break;
				case 9: weapon = new Bardiche(); break;
				case 10: weapon = new Halberd(); break;
				case 11: weapon = new Spear(); break;
				case 12: weapon = new QuarterStaff(); break;
				case 13: weapon = new Katana(); break;
				case 14: weapon = new Longsword(); break;
				case 15: weapon = new VikingSword(); break;
				case 16: weapon = new CompositeBow(); break;
				case 17: weapon = new CrescentBlade(); break;
				case 18: weapon = new DoubleBladedStaff(); break;
				case 19: weapon = new Lance(); break;
				case 20: weapon = new PaladinSword(); break;
				case 21: weapon = new Scythe(); break;
				case 22: weapon = new Daisho(); break;
				case 23: weapon = new Lajatang(); break;
				case 24: weapon = new NoDachi(); break;
				case 25: weapon = new Tetsubo(); break;
				case 26: weapon = new Yumi(); break;
				case 27: weapon = new ElvenCompositeLongbow(); break;
				case 28: weapon = new OrnateAxe(); break;
				case 29: weapon = new RadiantScimitar(); break;
				case 30: weapon = new WarCleaver(); break;
				case 31: weapon = new WildStaff(); break;
				default: weapon = new DiamondMace(); break;
			}

			      BaseRunicTool.ApplyAttributesTo( weapon, 5, 35, 50 );
                        weapon.Hue = 1461;

				PackItem( weapon );
			}

 		if ( Utility.RandomDouble() < 0.10 )
            {
			BaseArmor armor = Loot.RandomArmor( true );
			switch ( Utility.Random( 5 ) )
			{
			      case 0: armor = new CrusaderGauntlets(); break;
			      case 1: armor = new CrusaderGorget(); break;
				case 2: armor = new CrusaderLeggings(); break;
				case 3: armor = new CrusaderSleeves(); break;
				default: armor = new CrusaderBreastplate(); break;
		      }

			      BaseRunicTool.ApplyAttributesTo( armor, 5, 35, 50 );
                        armor.Hue = 1461;

				PackItem( armor );
			}

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseClothing clothing = Loot.RandomClothing( true );
		        BaseRunicTool.ApplyAttributesTo( clothing, 5, 35, 50 );  
                    clothing.Hue = 1461;

                    PackItem( clothing );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseShield shield = new MetalKiteShield();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( shield, 5, 35, 50 ); 
                    shield.Hue = 1461;

                    PackItem( shield );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseJewel bracelet = new GoldBracelet();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( bracelet, 5, 35, 50 );  
                    bracelet.Hue = 1461;

                    PackItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseJewel earrings = new GoldEarrings();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( earrings, 5, 35, 50 ); 
                    earrings.Hue = 1461;             

                    PackItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseJewel necklace = new GoldNecklace();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( necklace, 5, 35, 50 );      
                    necklace.Hue = 1461;      

                    PackItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseJewel ring = new GoldRing();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( ring, 5, 35, 50 ); 
                    ring.Hue = 1461;             

                    PackItem( ring );
            }
	}

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathEffectHue{ get{ return 0x480; } }

		public override bool AutoDispel{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool BleedImmune{ get{ return true; } }

		public SkeletalDragon( Serial serial ) : base( serial )
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