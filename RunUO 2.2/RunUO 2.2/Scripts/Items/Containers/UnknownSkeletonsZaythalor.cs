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
	public class UnknownBardSkeletonZaythalor : LockableContainer
	{
                public override int DefaultGumpID { get { return 0x9; } }

                [Constructable]
                public UnknownBardSkeletonZaythalor(): base( 0xECA + Utility.Random( 9 ) )
                {
		        Name = "the skeletal remains of a lost bard";
		        Weight = 35.0;

                        DropItem( new Gold( Utility.RandomMinMax( 10, 100 ) ) );
                        DropItem( new Doublet( Utility.RandomNondyedHue() ) );
                        DropItem( new JesterHat( Utility.RandomNondyedHue() ) );
                        DropItem( new Bandage( Utility.RandomMinMax( 10, 20 ) ) );

			switch ( Utility.Random( 6 ) )
			{
				case 0: DropItem( new Boots() ); break;
				case 1: DropItem( new HeavyBoots() ); break;
				case 2: DropItem( new HighBoots() ); break;
				case 3: DropItem( new LightBoots() ); break;
				case 4: DropItem( new ShortBoots() ); break;
				case 5: DropItem( new ThighBoots() ); break;
			}

                        switch ( Utility.Random( 2 ) )
                        {
                                case 0: DropItem( new Kilt( Utility.RandomNondyedHue() ) ); break;
                                case 1: DropItem( new ShortPants( Utility.RandomNondyedHue() ) ); break;
                        }

                        switch ( Utility.Random( 3 ) )
                        {
                                case 0: DropItem( new BeverageBottle( BeverageType.Ale) ); break;
                                case 1: DropItem( new BeverageBottle( BeverageType.Wine) ); break;
                                case 2: DropItem( new BeverageBottle( BeverageType.Liquor) ); break;
                        }

                        DropItem( Loot.RandomInstrument() );
                }

                public UnknownBardSkeletonZaythalor( Serial serial ) : base( serial )
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

	public class UnknownMageSkeletonZaythalor : LockableContainer
	{
                public override int DefaultGumpID { get { return 0x9; } }

                [Constructable]
                public UnknownMageSkeletonZaythalor(): base( 0xECA + Utility.Random( 9 ) )
                {
		        Name = "the skeletal remains of a lost mage";
		        Weight = 35.0;

                        DropItem( new Robe( Utility.RandomNondyedHue() ) );
                        DropItem( new Sandals() );
                        DropItem( Loot.RandomJewelry() );
                        DropItem( new Gold( Utility.RandomMinMax( 10, 100 ) ) );

			switch ( Utility.Random( 6 ) )
			{
				case 0: DropItem( new Boots() ); break;
				case 1: DropItem( new HeavyBoots() ); break;
				case 2: DropItem( new HighBoots() ); break;
				case 3: DropItem( new LightBoots() ); break;
				case 4: DropItem( new ShortBoots() ); break;
				case 5: DropItem( new ThighBoots() ); break;
			}

			switch ( Utility.Random( 6 ) )
			{
				case 0: DropItem( new CrystalStaff() ); break;
				case 1: DropItem( new EbonyPristineStaff() ); break;
				case 2: DropItem( new PristineStaff() ); break;
				case 3: DropItem( new TribalStaff() ); break;
				case 4: DropItem( new GlacialStaff() ); break;
				case 5: DropItem( new WildStaff() ); break;
			}

                        Item item;

                        for ( int i = 0; i < 3; i++ )
                        {
                            item = Loot.RandomReagent();
                            item.Amount = Utility.RandomMinMax( 15, 20 );
                            DropItem( item );
                        }

                        for ( int i = 0; i < 3; i++ )
                        {
                            if ( 0.25 >= Utility.RandomDouble() )
                               item = Loot.RandomScroll(0, Loot.NecromancyScrollTypes.Length, SpellbookType.Necromancer);
                            else
                               item = Loot.RandomScroll(0, Loot.RegularScrollTypes.Length, SpellbookType.Regular);

                            item.Amount = Utility.RandomMinMax( 1, 2 );
                            DropItem( item );
                        }
                }

                public UnknownMageSkeletonZaythalor( Serial serial ) : base( serial )
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

	public class UnknownRogueSkeletonZaythalor : LockableContainer
	{
                public override int DefaultGumpID { get { return 0x9; } }

                [Constructable]
                public UnknownRogueSkeletonZaythalor(): base( 0xECA + Utility.Random( 9 ) )
                {
		        Name = "the skeletal remains of a lost rogue";
		        Weight = 35.0;

                        DropItem( new LeatherChest() );
                        DropItem( new LeatherGloves() );
                        DropItem( new LeatherArms() );
                        DropItem( new Dagger() );
                        DropItem( new Shovel( 100 ) );
                        DropItem( new Lockpick( Utility.RandomMinMax( 1, 4 ) ) );
                        DropItem( new Gold( Utility.RandomMinMax( 10, 100 ) ) );

			switch ( Utility.Random( 6 ) )
			{
				case 0: DropItem( new Boots() ); break;
				case 1: DropItem( new HeavyBoots() ); break;
				case 2: DropItem( new HighBoots() ); break;
				case 3: DropItem( new LightBoots() ); break;
				case 4: DropItem( new ShortBoots() ); break;
				case 5: DropItem( new ThighBoots() ); break;
			}

                        if ( Utility.RandomBool() )
                            DropItem( new Torch() );
                        else
                            DropItem( new Lantern() );

                        if ( 0.1 >= Utility.RandomDouble() )
                            DropItem( Loot.RandomRangedWeapon() );
                        else
                            DropItem( Loot.RandomWeapon() );

                        DropItem( new TreasureMap( Utility.RandomMinMax( 1, 2 ), Map.Malas) );
                }

                public UnknownRogueSkeletonZaythalor( Serial serial ) : base( serial )
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

	public class UnknownWarriorSkeletonZaythalor : LockableContainer
	{
                public override int DefaultGumpID { get { return 0x9; } }

                [Constructable]
                public UnknownWarriorSkeletonZaythalor(): base( 0xECA + Utility.Random( 9 ) )
                {
		        Name = "the skeletal remains of a lost warrior";
		        Weight = 35.0;

                        DropItem( new RingmailChest() );
                        DropItem( new RingmailGloves() );
                        DropItem( new RingmailArms() );
                        DropItem( new Gold( Utility.RandomMinMax( 10, 100 ) ) );
                        DropItem( new Bandage( Utility.RandomMinMax( 50, 100 ) ) );

			switch ( Utility.Random( 6 ) )
			{
				case 0: DropItem( new Boots() ); break;
				case 1: DropItem( new HeavyBoots() ); break;
				case 2: DropItem( new HighBoots() ); break;
				case 3: DropItem( new LightBoots() ); break;
				case 4: DropItem( new ShortBoots() ); break;
				case 5: DropItem( new ThighBoots() ); break;
			}

			switch ( Utility.Random( 6 ) )
			{
				case 0: DropItem( new AmmoniteShield() ); break;
				case 1: DropItem( new ElvenShield() ); break;
				case 2: DropItem( new NymphShield() ); break;
				case 3: DropItem( new SpiderShield() ); break;
				case 4: DropItem( new UnicornShield() ); break;
				case 5: DropItem( new WoodenDragonShield() ); break;
			}

                        if ( Utility.RandomBool() )
                            DropItem( new Torch() );
                        else
                            DropItem( new Lantern() );

                        if ( 0.1 >= Utility.RandomDouble() )
                            DropItem( Loot.RandomRangedWeapon() );
                        else
                            DropItem( Loot.RandomWeapon() );
                }

                public UnknownWarriorSkeletonZaythalor( Serial serial ) : base( serial )
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