using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a dragonian overlord corpse" )]
	public class DragonianOverlord : BaseCreature
	{
		[Constructable]
		public DragonianOverlord () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "dragon" );
			Title = "the dragonian overlord";
			Body = 399;
			BaseSoundID = 362;

			SetStr( 1103, 1131 );
			SetDex( 99, 120 );
			SetInt( 734, 752 );

			SetHits( 956, 990 );
			SetMana( 3670, 3760 );

			SetDamage( 15, 25 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Fire, 25 );

			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 80 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 60 );
			SetResistance( ResistanceType.Energy, 60 );

			SetSkill( SkillName.EvalInt, 72.8, 78.2 );
			SetSkill( SkillName.Magery, 85.8, 99.3 );
			SetSkill( SkillName.Meditation, 61.7, 64.4 );
			SetSkill( SkillName.MagicResist, 120.1, 133.0 );
			SetSkill( SkillName.Tactics, 99.6, 100.0 );
			SetSkill( SkillName.Wrestling, 98.6, 99.0 );

			Fame = 222500;
			Karma = -222500;

////////////////////////////////Main Pack////////////////////////////////

			PackGold( 350, 500 );
			PackReg( 45, 55 );
			PackItem( new MeteorSwarmScroll() );

////////////////////////////////1st Backpack////////////////////////////////

			Container pack1 = new Backpack();
			pack1.DropItem( new Cloak(762) );
			pack1.DropItem( new RoyalCirclet() );

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

 		      if ( Utility.RandomDouble() < 0.25 )
                  {
			     BaseWeapon weapon = Loot.RandomWeapon( true );
		           BaseRunicTool.ApplyAttributesTo( weapon, 5, 15, 30 );  

                       pack2.DropItem( weapon );
                  }

 		      if ( Utility.RandomDouble() < 0.25 )
                  {
			     BaseArmor armor1 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor1, 5, 15, 30 );  

                       pack2.DropItem( armor1 );
                  }

 		      if ( Utility.RandomDouble() < 0.25 )
                  {
			     BaseArmor armor2 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor2, 5, 15, 30 );  

                       pack2.DropItem( armor2 );
                  }

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseJewel earrings = new GoldEarrings();
			     if ( Core.AOS )
		           BaseRunicTool.ApplyAttributesTo( earrings, 5, 15, 30 ); 

                       pack2.DropItem( earrings );
                  }

			Container bag2 = new Bag();
			bag2.DropItem( new Gold( Utility.RandomMinMax( 250, 300 ) ) );
			bag2.DropItem( new DragonScale( Utility.RandomMinMax( 25, 35 ) ) );
			bag2.DropItem( Loot.RandomPotion() );
			bag2.DropItem( new GreaterCurePotion() );
			bag2.DropItem( new GreaterStrengthPotion() );
			bag2.DropItem( new GreaterHealPotion() );
			bag2.DropItem( Loot.RandomGem() );
			bag2.DropItem( Loot.RandomGem() );
			bag2.DropItem( Loot.RandomGem() );
			pack2.DropItem( bag2 );

			PackItem( pack2 );

////////////////////////////////3rd Backpack////////////////////////////////

			Container pack3 = new Backpack();
			pack3.DropItem( new Spellbook() );
			pack3.DropItem( Loot.RandomWand() );
			pack3.DropItem( Loot.RandomWand() );
			pack3.DropItem( Loot.RandomClothing() );
			pack3.DropItem( Loot.RandomClothing() );

 		      if ( Utility.RandomDouble() < 0.25 )
                  {
			     BaseClothing clothing = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing, 3, 15, 30 );  

                       pack3.DropItem( clothing );
                  }

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseJewel necklace = new GoldNecklace();
			     if ( Core.AOS )
		           BaseRunicTool.ApplyAttributesTo( necklace, 3, 15, 30 ); 

                       pack3.DropItem( necklace );
                  }

			Container bag3 = new Bag();
			bag3.DropItem( new Gold( Utility.RandomMinMax( 25, 50 ) ) );
			bag3.DropItem( new Bandage( Utility.RandomMinMax( 9, 18 ) ) );
			bag3.DropItem( Loot.RandomGem() );
			bag3.DropItem( Loot.RandomGem() );

                  Item ScrollLoot1 = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                  ScrollLoot1.Amount = Utility.Random( 5, 10 );
                  bag3.DropItem( ScrollLoot1 );

                  Item ScrollLoot2 = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                  ScrollLoot2.Amount = Utility.Random( 5, 10 );
                  bag3.DropItem( ScrollLoot2 );

                  Item ScrollLoot3 = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                  ScrollLoot3.Amount = Utility.Random( 5, 10 );
                  bag3.DropItem( ScrollLoot3 );

			pack3.DropItem( bag3 );

			PackItem( pack3 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 5 );
			AddLoot( LootPack.HighScrolls, 3 );
			AddLoot( LootPack.MedScrolls, 4 );
			AddLoot( LootPack.LowScrolls, 6 );
			AddLoot( LootPack.Gems, 5 );

 		if ( Utility.RandomDouble() < 0.20 )
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

 		if ( Utility.RandomDouble() < 0.20 )
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

 		if ( Utility.RandomDouble() < 0.20 )
            {
			  BaseClothing clothing = Loot.RandomClothing( true );
		        BaseRunicTool.ApplyAttributesTo( clothing, 5, 35, 50 );  
                    clothing.Hue = 1461;

                    PackItem( clothing );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseShield shield = new MetalKiteShield();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( shield, 5, 35, 50 ); 
                    shield.Hue = 1461;

                    PackItem( shield );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel bracelet = new GoldBracelet();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( bracelet, 5, 35, 50 );  
                    bracelet.Hue = 1461;

                    PackItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel earrings = new GoldEarrings();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( earrings, 5, 35, 50 ); 
                    earrings.Hue = 1461;             

                    PackItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel necklace = new GoldNecklace();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( necklace, 5, 35, 50 );      
                    necklace.Hue = 1461;      

                    PackItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel ring = new GoldRing();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( ring, 5, 35, 50 ); 
                    ring.Hue = 1461;             

                    PackItem( ring );
            }
	}

		public override int GetIdleSound() { return 0x2D3; }
                public override int GetHurtSound() { return 0x2D1; }

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override bool AutoDispel{ get{ return true; } }
		public override int Scales{ get{ return 12; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Red; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override Poison HitPoison{ get{ return Utility.RandomBool() ? Poison.Lesser : Poison.Regular; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(19), from);
                        corpse.AddCarvedItem(new BarbedHides(40), from);
                        corpse.AddCarvedItem(new DragonScale( Utility.RandomMinMax( 35, 50 )), from);
                        corpse.AddCarvedItem(new DragonHeart(), from);

                        from.SendMessage( "You carve up raw ribs, barbed hides, colored scales, specialized dragon scales, and a dragon heart." );
                        corpse.Carved = true; 
			}
                }

		public DragonianOverlord( Serial serial ) : base( serial )
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