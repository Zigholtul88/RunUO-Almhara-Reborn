using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Multis;
using Server.Network;
using Server.ContextMenus;
using Server.Engines.PartySystem;

namespace Server.Items
{
        [Flipable( 0xE43, 0xE42 )]
	public class MongbatHideoutTreasureChest1 : LockableContainer
	{
                public override bool Decays{ get{ return true; } } 

                public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 30, 60 ) ); } }

                public override int DefaultGumpID{ get{ return 0x49; } }
                public override int DefaultDropSound{ get{ return 0x42; } }

                public override Rectangle2D Bounds
                {
                      get{ return new Rectangle2D( 18, 105, 144, 73 ); }
                }

                [Constructable]
                public MongbatHideoutTreasureChest1() : base( 0xE43 )
                {
		      Name = "a treasure chest -40-";
		      Movable = true;
		      Weight = 1000.0;

                      TrapPower = 0;
                      Locked = true;

                      RequiredSkill = 40;
                      LockLevel = 40;
                      MaxLockLevel = 80;

/////////////////////////////////// Gold
 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( new Gold( Utility.Random( 20, 300 ) ) );

/////////////////////////////////////// Supplies

			switch ( Utility.Random( 19 ) )
			{
				case 0: DropItem( new Board(60) ); break;
				case 1: DropItem( new BoltOfCloth(60) ); break;
				case 2: DropItem( new Bottle(60) ); break;
				case 3: DropItem( new CopperWire(60) ); break;
				case 4: DropItem( new Cotton(60) ); break;
				case 5: DropItem( new DarkYarn(60) ); break;
				case 6: DropItem( new Feather(60) ); break;
				case 7: DropItem( new Flax(60) ); break;
				case 8: DropItem( new Gears(60) ); break;
				case 9: DropItem( new GoldWire(60) ); break;
				case 10: DropItem( new IronIngot(60) ); break;
				case 11: DropItem( new IronWire(60) ); break;
				case 12: DropItem( new Leather(60) ); break;
				case 13: DropItem( new LightYarn(60) ); break;
				case 14: DropItem( new Shaft(60) ); break;
				case 15: DropItem( new SilverWire(60) ); break;
				case 16: DropItem( new SpoolOfThread(60) ); break;
				case 17: DropItem( new Springs(60) ); break;
				case 18: DropItem( new Wool(60) ); break;
			}

			switch ( Utility.Random( 5 ) )
			{
				case 0: DropItem( new BeetleEgg(15) ); break;
				case 1: DropItem( new FishScale(15) ); break;
				case 2: DropItem( new Nirnroot(15) ); break;
				case 3: DropItem( new SerpentScale(15) ); break;
				case 4: DropItem( new ThunderStone(15) ); break;
			}

                      	Item ReagentLoot = Loot.RandomReagent();
                      	ReagentLoot.Amount = Utility.RandomMinMax( 5, 10 );
                         DropItem( ReagentLoot );

 		      if ( Utility.RandomDouble() < 0.05 )
		         DropItem( new SackFlour() );

/////////////////////////////////////// Rare Items

 		      if ( Utility.RandomDouble() < 0.01 )
		         DropItem( new DyeTub() );

/////////////////////////////////////// LV 1-15
 		      if ( Utility.RandomDouble() < 0.10 )
                      {
	                        BaseWeapon weapon = Loot.RandomWeapon( true );
			        switch ( Utility.Random( 36 ) )
			        {
			 	        case 0: weapon = new Hatchet(); break; // Lv1
				        case 1: weapon = new Axe (); break; // Lv5
				        case 2: weapon = new BattleAxe(); break; // Lv10
				        case 3: weapon = new Bow(); break; // Lv1
			                case 4: weapon = new Crossbow(); break; // Lv1
				        case 5: weapon = new Balestra(); break; // Lv5
				        case 6: weapon = new ElvenLeafBow(); break; // Lv5
				        case 7: weapon = new MagicalShortbow(); break; // Lv10
				        case 8: weapon = new RepeatingCrossbow(); break; // Lv10
				        case 9: weapon = new SkinningKnife(); break; // Lv1
				        case 10: weapon = new Cleaver(); break; // Lv5
				        case 11: weapon = new Dagger(); break; // Lv5
				        case 12: weapon = new ButcherKnife(); break; // Lv10
				        case 13: weapon = new EbonyDagger(); break; // Lv10
				        case 14: weapon = new Sai(); break; // Lv15
				        case 15: weapon = new Club(); break; // Lv1
				        case 16: weapon = new Nunchaku(); break; // Lv1
				        case 17: weapon = new Mace(); break; // Lv5
				        case 18: weapon = new Maul(); break; // Lv10
				        case 19: weapon = new Scepter(); break; // Lv15
				        case 20: weapon = new Pitchfork(); break; // Lv1
				        case 21: weapon = new ShortSpear(); break; // Lv5
				        case 22: weapon = new Pilum(); break; // Lv10
				        case 23: weapon = new Pike(); break; // Lv15
				        case 24: weapon = new GnarledStaff(); break; // Lv1
				        case 25: weapon = new ShepherdsCrook(); break; // Lv1
				        case 26: weapon = new QuarterStaff(); break; // Lv10
				        case 27: weapon = new ReptilianStaff(); break; // Lv15
				        case 28: weapon = new Bokuto(); break; // Lv1
				        case 29: weapon = new BoneHarvester(); break; // Lv1
				        case 30: weapon = new Cutlass(); break; // Lv1
				        case 31: weapon = new ElvenMachete(); break; // Lv1
				        case 32: weapon = new Kryss(); break; // Lv1
				        case 33: weapon = new EbonyRapier(); break; // Lv10
				        case 34: weapon = new Scimitar(); break; // Lv10
				        default: weapon = new Leafblade(); break; // Lv1
			        }

			        switch ( Utility.Random( 14 ) )
			        {
				        case 0: weapon.Attributes.AttackChance = Utility.RandomMinMax( 1, 5 ); break;
				        case 1: weapon.Attributes.DefendChance = Utility.RandomMinMax( 1, 5 ); break;
				        case 2: weapon.Attributes.Luck = Utility.RandomMinMax( 1, 10 ); break;
				        case 3: weapon.Attributes.WeaponSpeed = Utility.RandomMinMax( 1, 25 ); break;
				        case 4: weapon.WeaponAttributes.HitDispel = Utility.RandomMinMax( 2, 10 ); break;
				        case 5: weapon.WeaponAttributes.HitFireball = Utility.RandomMinMax( 2, 10 ); break;
				        case 6: weapon.WeaponAttributes.HitHarm = Utility.RandomMinMax( 2, 10 ); break;
				        case 7: weapon.WeaponAttributes.HitLeechHits = Utility.RandomMinMax( 2, 10 ); break;
				        case 8: weapon.WeaponAttributes.HitLeechMana = Utility.RandomMinMax( 2, 10 ); break;
				        case 9: weapon.WeaponAttributes.HitLeechStam = Utility.RandomMinMax( 2, 10 ); break;
				        case 10: weapon.WeaponAttributes.HitLightning = Utility.RandomMinMax( 2, 10 ); break;
				        case 11: weapon.WeaponAttributes.HitLowerAttack = Utility.RandomMinMax( 2, 10 ); break;
				        case 12: weapon.WeaponAttributes.HitLowerDefend = Utility.RandomMinMax( 2, 10 ); break;
				        default: weapon.Attributes.WeaponDamage = Utility.RandomMinMax( 1, 10 ); break;
				}

			       	DropItem( weapon );
			}

/////////////////////////////////////// LV 1-15
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			        BaseArmor armor = Loot.RandomArmor( true );
			        switch ( Utility.Random( 39 ) )
			        {
			                case 0: armor = new LeatherArms(); break; // Lv1
			                case 1: armor = new LeatherBustierArms(); break; // Lv1
				        case 2: armor = new LeatherCap(); break; // Lv1
				        case 3: armor = new LeatherChest(); break; // Lv1
			                case 4: armor = new LeatherGloves(); break; // Lv1
			                case 5: armor = new LeatherGorget(); break; // Lv1
				        case 6: armor = new LeatherLegs(); break; // Lv1
				        case 7: armor = new LeatherShorts(); break; // Lv1
				        case 8: armor = new LeatherSkirt(); break; // Lv1
				        case 9: armor = new FemaleLeafChest(); break; // Lv1
				        case 10: armor = new LeafArms(); break; // Lv3
			                case 11: armor = new LeafChest(); break; // Lv3
			                case 12: armor = new LeafGloves(); break; // Lv3
				        case 13: armor = new LeafGorget(); break; // Lv3
				        case 14: armor = new LeafLegs(); break; // Lv3
				        case 15: armor = new LeafTonlet(); break; // Lv3
				        case 16: armor = new LeatherDo(); break; // Lv6
				        case 17: armor = new LeatherHaidate(); break; // Lv6
				        case 18: armor = new LeatherHiroSode(); break; // Lv6
				        case 19: armor = new LeatherJingasa(); break; // Lv6
				        case 20: armor = new LeatherMempo(); break; // Lv6
			                case 21: armor = new LeatherNinjaHood(); break; // Lv6
			                case 22: armor = new LeatherNinjaJacket(); break; // Lv6
				        case 23: armor = new LeatherNinjaMitts(); break; // Lv6
				        case 24: armor = new LeatherNinjaPants(); break; // Lv6
				        case 25: armor = new LeatherSuneate(); break; // Lv6
				        case 26: armor = new EbonsilkArms(); break; // Lv9
			                case 27: armor = new EbonsilkChest(); break; // Lv9
			                case 28: armor = new EbonsilkGloves(); break; // Lv9
				        case 29: armor = new EbonsilkGorget(); break; // Lv9
				        case 30: armor = new EbonsilkLegs(); break; // Lv9
				        case 31: armor = new EbonsilkTiara(); break; // Lv9
				        case 32: armor = new ChitinArms(); break; // Lv12
			                case 33: armor = new ChitinChest(); break; // Lv12
			                case 34: armor = new ChitinGloves(); break; // Lv12
				        case 35: armor = new ChitinGorget(); break; // Lv12
				        case 36: armor = new ChitinHelmet(); break; // Lv12
				        case 37: armor = new ChitinLegs(); break; // Lv12
				        default: armor = new FemaleLeatherChest(); break; // Lv1
		                }

			        BaseRunicTool.ApplyAttributesTo( armor, 3, 5, 50 );
				DropItem( armor );
			}

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
	                       BaseHat hat = Loot.RandomHat( true ); 
		               BaseRunicTool.ApplyAttributesTo( hat, 3, 5, 10 );
		               DropItem( hat );
		        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseClothing clothing = Loot.RandomClothing( true );
		               BaseRunicTool.ApplyAttributesTo( clothing, 3, 5, 10 );
                               DropItem( clothing );
                        }

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseShield shield1 = new Buckler();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( shield1, 3, 5, 50 );              
                               DropItem( shield1 );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseShield shield2 = new WoodenShield();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( shield2, 3, 5, 50 );              
                               DropItem( shield2 );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseShield shield3 = new AmmoniteShield();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( shield3, 3, 5, 50 );              
                               DropItem( shield3 );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseShield shield4 = new BronzeShield();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( shield4, 3, 5, 50 );              
                               DropItem( shield4 );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseShield shield5 = new MetalShield();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( shield5, 3, 5, 50 );              
                               DropItem( shield5 );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseShield shield6 = new WoodenKiteShield();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( shield6, 3, 5, 50 );              
                               DropItem( shield6 );
                        }

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseJewel bracelet = new SilverBracelet();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( bracelet, 3, 5, 10 );              
                               DropItem( bracelet );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseJewel earrings = new SilverEarrings();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( earrings, 3, 5, 10 );              
                               DropItem( earrings );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseJewel necklace = new SilverNecklace();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( necklace, 3, 5, 10 );              
                               DropItem( necklace );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseJewel ring = new SilverRing();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( ring, 3, 5, 10 );              
                               DropItem( ring );
                        }
                }

                public MongbatHideoutTreasureChest1( Serial serial ) : base( serial )
                {
                }

                public override void Serialize( GenericWriter writer )
                {
                    	base.Serialize( writer );
                    	writer.Write( (int) 1 ); // version
                }

                public override void Deserialize( GenericReader reader )
                {
                    	base.Deserialize( reader );
                    	int version = reader.ReadInt();
                }
        }

        [Flipable( 0xE43, 0xE42 )]
	public class MongbatHideoutTreasureChest2 : LockableContainer
	{
                public override bool Decays{ get{ return true; } } 

                public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 30, 60 ) ); } }

                public override int DefaultGumpID{ get{ return 0x49; } }
                public override int DefaultDropSound{ get{ return 0x42; } }

                public override Rectangle2D Bounds
                {
                      get{ return new Rectangle2D( 18, 105, 144, 73 ); }
                }

                [Constructable]
                public MongbatHideoutTreasureChest2() : base( 0xE43 )
                {
		      Name = "a treasure chest -50-";
		      Movable = true;
		      Weight = 1000.0;

                      TrapPower = 0;
                      Locked = true;

                      RequiredSkill = 50;
                      LockLevel = 50;
                      MaxLockLevel = 80;

/////////////////////////////////// Gold
 		      if ( Utility.RandomDouble() < 0.25 )
                         DropItem( new Gold( Utility.Random( 20, 300 ) ) );

/////////////////////////////////////// Supplies

			switch ( Utility.Random( 18 ) )
			{
				case 0: DropItem( new Board(70) ); break;
				case 1: DropItem( new BoltOfCloth(70) ); break;
				case 2: DropItem( new Bottle(70) ); break;
				case 3: DropItem( new CopperWire(70) ); break;
				case 4: DropItem( new Cotton(70) ); break;
				case 5: DropItem( new DarkYarn(70) ); break;
				case 6: DropItem( new Feather(70) ); break;
				case 7: DropItem( new Flax(70) ); break;
				case 8: DropItem( new Gears(70) ); break;
				case 9: DropItem( new GoldWire(70) ); break;
				case 10: DropItem( new IronIngot(70) ); break;
				case 11: DropItem( new IronWire(70) ); break;
				case 12: DropItem( new Leather(70) ); break;
				case 13: DropItem( new LightYarn(70) ); break;
				case 14: DropItem( new Shaft(70) ); break;
				case 15: DropItem( new SilverWire(70) ); break;
				case 16: DropItem( new SpoolOfThread(70) ); break;
				case 17: DropItem( new Springs(70) ); break;
				case 18: DropItem( new Wool(70) ); break;
			}

			switch ( Utility.Random( 5 ) )
			{
				case 0: DropItem( new BeetleEgg(25) ); break;
				case 1: DropItem( new FishScale(25) ); break;
				case 2: DropItem( new Nirnroot(25) ); break;
				case 3: DropItem( new SerpentScale(25) ); break;
				case 4: DropItem( new ThunderStone(25) ); break;
			}

                      Item ReagentLoot = Loot.RandomReagent();
                      ReagentLoot.Amount = Utility.RandomMinMax( 10, 15 );
                         DropItem( ReagentLoot );

 		      if ( Utility.RandomDouble() < 0.05 )
		         DropItem( new SackFlour() );

/////////////////////////////////////// Rare Items

 		      if ( Utility.RandomDouble() < 0.01 )
		         DropItem( new DyeTub() );

/////////////////////////////////////// LV 10-20
/////////////////////////////////////// LV 10-25 for staves
 		      	if ( Utility.RandomDouble() < 0.10 )
			{
	                       	BaseWeapon weapon = Loot.RandomWeapon( true );
			       	switch ( Utility.Random( 28 ) )
			       	{
				        case 0: weapon = new BattleAxe(); break; // Lv10
				        case 1: weapon = new DoubleAxe(); break; // Lv20
				        case 2: weapon = new MagicalShortbow(); break; // Lv10
				        case 3: weapon = new RepeatingCrossbow(); break; // Lv10
				        case 4: weapon = new ButcherKnife(); break; // Lv10
				        case 5: weapon = new CompositeBow(); break; // Lv20
				        case 6: weapon = new EbonyCrossbow(); break; // Lv20
				        case 7: weapon = new EbonyDagger(); break; // Lv10
				        case 8: weapon = new Sai(); break; // Lv15
				        case 9: weapon = new EbonyDualDaggers(); break; // Lv20
				        case 10: weapon = new Maul(); break; // Lv10
				        case 11: weapon = new Scepter(); break; // Lv15
				        case 12: weapon = new WarMace(); break; // Lv20
				        case 13: weapon = new Pilum(); break; // Lv10
				        case 14: weapon = new Pike(); break; // Lv15
				        case 15: weapon = new Spear(); break; // Lv20
				        case 16: weapon = new QuarterStaff(); break; // Lv10
				        case 17: weapon = new ReptilianStaff(); break; // Lv15
				        case 18: weapon = new BubbleStaff(); break; // Lv25
				        case 19: weapon = new CrystalStaff(); break; // Lv25
				        case 20: weapon = new EnergyStaff(); break; // Lv25
				        case 21: weapon = new FireStaff(); break; // Lv25
				        case 22: weapon = new VineStaff(); break; // Lv25
				        case 23: weapon = new EbonyRapier(); break; // Lv10
				        case 24: weapon = new Scimitar(); break; // Lv10
				        case 25: weapon = new Longsword(); break; // Lv20
				        case 26: weapon = new VikingSword(); break; // Lv20
				        default: weapon = new Wakizashi(); break; // Lv20
			        }

			        switch ( Utility.Random( 14 ) )
			        {
				        case 0: weapon.Attributes.AttackChance = Utility.RandomMinMax( 1, 5 ); break;
				        case 1: weapon.Attributes.DefendChance = Utility.RandomMinMax( 1, 5 ); break;
				        case 2: weapon.Attributes.Luck = Utility.RandomMinMax( 1, 10 ); break;
				        case 3: weapon.Attributes.WeaponSpeed = Utility.RandomMinMax( 1, 25 ); break;
				        case 4: weapon.WeaponAttributes.HitDispel = Utility.RandomMinMax( 2, 10 ); break;
				        case 5: weapon.WeaponAttributes.HitFireball = Utility.RandomMinMax( 2, 10 ); break;
				        case 6: weapon.WeaponAttributes.HitHarm = Utility.RandomMinMax( 2, 10 ); break;
				        case 7: weapon.WeaponAttributes.HitLeechHits = Utility.RandomMinMax( 2, 10 ); break;
				        case 8: weapon.WeaponAttributes.HitLeechMana = Utility.RandomMinMax( 2, 10 ); break;
				        case 9: weapon.WeaponAttributes.HitLeechStam = Utility.RandomMinMax( 2, 10 ); break;
				        case 10: weapon.WeaponAttributes.HitLightning = Utility.RandomMinMax( 2, 10 ); break;
				        case 11: weapon.WeaponAttributes.HitLowerAttack = Utility.RandomMinMax( 2, 10 ); break;
				        case 12: weapon.WeaponAttributes.HitLowerDefend = Utility.RandomMinMax( 2, 10 ); break;
				        default: weapon.Attributes.WeaponDamage = Utility.RandomMinMax( 1, 10 ); break;
				}

			        switch ( Utility.Random( 14 ) )
			        {
				        case 0: weapon.Attributes.AttackChance = Utility.RandomMinMax( 1, 5 ); break;
				        case 1: weapon.Attributes.DefendChance = Utility.RandomMinMax( 1, 5 ); break;
				        case 2: weapon.Attributes.Luck = Utility.RandomMinMax( 1, 10 ); break;
				        case 3: weapon.Attributes.WeaponSpeed = Utility.RandomMinMax( 1, 25 ); break;
				        case 4: weapon.WeaponAttributes.HitDispel = Utility.RandomMinMax( 2, 10 ); break;
				        case 5: weapon.WeaponAttributes.HitFireball = Utility.RandomMinMax( 2, 10 ); break;
				        case 6: weapon.WeaponAttributes.HitHarm = Utility.RandomMinMax( 2, 10 ); break;
				        case 7: weapon.WeaponAttributes.HitLeechHits = Utility.RandomMinMax( 2, 10 ); break;
				        case 8: weapon.WeaponAttributes.HitLeechMana = Utility.RandomMinMax( 2, 10 ); break;
				        case 9: weapon.WeaponAttributes.HitLeechStam = Utility.RandomMinMax( 2, 10 ); break;
				        case 10: weapon.WeaponAttributes.HitLightning = Utility.RandomMinMax( 2, 10 ); break;
				        case 11: weapon.WeaponAttributes.HitLowerAttack = Utility.RandomMinMax( 2, 10 ); break;
				        case 12: weapon.WeaponAttributes.HitLowerDefend = Utility.RandomMinMax( 2, 10 ); break;
				        default: weapon.Attributes.WeaponDamage = Utility.RandomMinMax( 1, 10 ); break;
				}

			       	DropItem( weapon );
			}

/////////////////////////////////////// LV 12-18
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			        BaseArmor armor = Loot.RandomArmor( true );
			        switch ( Utility.Random( 19 ) )
			        {
				        case 0: armor = new ChitinArms(); break; // Lv12
			                case 1: armor = new ChitinChest(); break; // Lv12
			                case 2: armor = new ChitinGloves(); break; // Lv12
				        case 3: armor = new ChitinGorget(); break; // Lv12
				        case 4: armor = new ChitinHelmet(); break; // Lv12
				        case 5: armor = new ChitinLegs(); break; // Lv12
				        case 6: armor = new FemaleStuddedChest(); break; // Lv15
			                case 7: armor = new StuddedArms(); break; // Lv15
			                case 8: armor = new StuddedBustierArms(); break; // Lv15
				        case 9: armor = new StuddedChest(); break; // Lv15
				        case 10: armor = new StuddedGloves(); break; // Lv15
				        case 11: armor = new StuddedGorget(); break; // Lv15
				        case 12: armor = new StuddedLegs(); break; // Lv15
			                case 13: armor = new HideFemaleChest(); break; // Lv18
			                case 14: armor = new HideGloves(); break; // Lv18
				        case 15: armor = new HideGorget(); break; // Lv18
				        case 16: armor = new HidePants(); break; // Lv18
				        case 17: armor = new HidePauldrons(); break; // Lv18
				        default: armor = new HideChest(); break; // Lv18
		                }

			        BaseRunicTool.ApplyAttributesTo( armor, 3, 5, 50 );
				DropItem( armor );
			}

 		        if ( Utility.RandomDouble() < 0.10 )
                        {
	                       BaseHat hat = Loot.RandomHat( true ); 
		               BaseRunicTool.ApplyAttributesTo( hat, 3, 5, 10 );
		               DropItem( hat );
		        }
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			       BaseClothing clothing = Loot.RandomClothing( true );
		               BaseRunicTool.ApplyAttributesTo( clothing, 3, 5, 10 );
                               DropItem( clothing );
                        }

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseShield shield1 = new MetalShield();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( shield1, 3, 5, 50 );              
                               DropItem( shield1 );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseShield shield2 = new WoodenKiteShield();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( shield2, 3, 5, 50 );              
                               DropItem( shield2 );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			       BaseShield shield3 = new MetalKiteShield();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( shield3, 3, 5, 50 );              
                               DropItem( shield3 );
                        }

 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			       BaseJewel bracelet = new SilverBracelet();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( bracelet, 3, 5, 10 );              
                               DropItem( bracelet );
                        }
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			       BaseJewel earrings = new SilverEarrings();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( earrings, 3, 5, 10 );              
                               DropItem( earrings );
                        }
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			       BaseJewel necklace = new SilverNecklace();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( necklace, 3, 5, 10 );              
                               DropItem( necklace );
                        }
 		        if ( Utility.RandomDouble() < 0.10 )
                        {
			       BaseJewel ring = new SilverRing();
			       if ( Core.AOS )
		               BaseRunicTool.ApplyAttributesTo( ring, 3, 5, 10 );              
                               DropItem( ring );
                        }
                }

                public MongbatHideoutTreasureChest2( Serial serial ) : base( serial )
                {
                }

                public override void Serialize( GenericWriter writer )
                {
                    	base.Serialize( writer );
                    	writer.Write( (int) 1 ); // version
                }

                public override void Deserialize( GenericReader reader )
                {
                    	base.Deserialize( reader );
                    	int version = reader.ReadInt();
                }
        }
}