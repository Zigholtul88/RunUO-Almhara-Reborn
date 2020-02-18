using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Accounting;

namespace Server.Misc
{
	public class CharacterCreation
	{
		public static void Initialize()
		{
			// Register our event handler
			EventSink.CharacterCreated += new CharacterCreatedEventHandler( EventSink_CharacterCreated );
		}

///////////////////////////// Modified for Custom Shard /////////////////////////////////
		private static void AddBackpack( Mobile m )
		{
			Container pack = m.Backpack;

			if ( pack == null )
			{
				pack = new Backpack();
				pack.Movable = false;

				m.AddItem( pack );
			}

                        bool FirstChar = Convert.ToBoolean( ((Account)m.Account).GetTag("FirstChar") );

			if ( FirstChar ) //this part checks to see if the account already has this tag, if it does it will add the following items

                        {
			      PackItem( new RedBook( "a book", m.Name, 20, true ) );

			      PackItem( new PlayerCommandsBook() );
			      PackItem( new KeyStoragePouch() );
		        }

                        else // if the account does not have this tag it will add these following items instead

			{
                                World.Broadcast( 33, true, ""+m.Name+" begins their journey through Almhara for the very first time!");

			        PackItem( new RedBook( "a book", m.Name, 20, true ) );
			        PackItem( new PlayerCommandsBook() );
			        PackItem( new KeyStoragePouch() );
				((Account)m.Account).SetTag( "FirstChar", "true" ); // this part will add the tag onto the account
			}

		}
///////////////////////////// Modified for Custom Shard /////////////////////////////////

		private static Item MakeNewbie( Item item )
		{
			if ( !Core.AOS )
				item.LootType = LootType.Newbied;

// ItemID Mod START
				if (item is BaseArmor)
				{
					BaseArmor id = (BaseArmor) item;
					id.Identified = true;
				}
				else if (item is BaseJewel)
				{
					BaseJewel id = (BaseJewel) item;
					id.Identified = true;
				}
				else if (item is BaseWeapon)
				{
					BaseWeapon id = (BaseWeapon) item;
					id.Identified = true;
				}
				else if (item is BaseClothing)
				{
					BaseClothing id = (BaseClothing) item;
					id.Identified = true;
				}
// ItemID Mod END

			return item;
		}

		private static void PlaceItemIn( Container parent, int x, int y, Item item )
		{
			parent.AddItem( item );
			item.Location = new Point3D( x, y, 0 );
		}

		private static Item MakePotionKeg( PotionEffect type, int hue )
		{
			PotionKeg keg = new PotionKeg();

			keg.Held = 100;
			keg.Type = type;
			keg.Hue = hue;

			return MakeNewbie( keg );
		}

		private static void FillBankAOS( Mobile m )
		{
			BankBox bank = m.BankBox;

			// The new AOS bankboxes don't have powerscrolls, they are automatically 'applied':

			for ( int i = 0; i < PowerScroll.Skills.Count; ++i )
				m.Skills[PowerScroll.Skills[ i ]].Cap = 120.0;

			Container cont;


			// Begin box of money
			cont = new WoodenBox();
			cont.ItemID = 0xE7D;
			cont.Hue = 0x489;

			PlaceItemIn( cont, 16, 51, new BankCheck( 500000 ) );
			PlaceItemIn( cont, 28, 51, new BankCheck( 250000 ) );
			PlaceItemIn( cont, 40, 51, new BankCheck( 100000 ) );
			PlaceItemIn( cont, 52, 51, new BankCheck( 100000 ) );
			PlaceItemIn( cont, 64, 51, new BankCheck(  50000 ) );

			PlaceItemIn( cont, 16, 115, new Factions.Silver( 9000 ) );
			PlaceItemIn( cont, 34, 115, new Gold( 60000 ) );

			PlaceItemIn( bank, 18, 169, cont );
			// End box of money


			// Begin bag of potion kegs
			cont = new Backpack();
			cont.Name = "Various Potion Kegs";

			PlaceItemIn( cont,  45, 149, MakePotionKeg( PotionEffect.CureGreater, 0x2D ) );
			PlaceItemIn( cont,  69, 149, MakePotionKeg( PotionEffect.HealGreater, 0x499 ) );
			PlaceItemIn( cont,  93, 149, MakePotionKeg( PotionEffect.PoisonDeadly, 0x46 ) );
			PlaceItemIn( cont, 117, 149, MakePotionKeg( PotionEffect.RefreshTotal, 0x21 ) );
			PlaceItemIn( cont, 141, 149, MakePotionKeg( PotionEffect.ExplosionGreater, 0x74 ) );

			PlaceItemIn( cont, 93, 82, new Bottle( 1000 ) );

			PlaceItemIn( bank, 53, 169, cont );
			// End bag of potion kegs


			// Begin bag of tools
			cont = new Bag();
			cont.Name = "Tool Bag";

			PlaceItemIn( cont, 30,  35, new TinkerTools( 1000 ) );
			PlaceItemIn( cont, 60,  35, new HousePlacementTool() );
			PlaceItemIn( cont, 90,  35, new DovetailSaw( 1000 ) );
			PlaceItemIn( cont, 30,  68, new Scissors() );
			PlaceItemIn( cont, 45,  68, new MortarPestle( 1000 ) );
			PlaceItemIn( cont, 75,  68, new ScribesPen( 1000 ) );
			PlaceItemIn( cont, 90,  68, new SmithHammer( 1000 ) );
			PlaceItemIn( cont, 30, 118, new TwoHandedAxe() );
			PlaceItemIn( cont, 60, 118, new FletcherTools( 1000 ) );
			PlaceItemIn( cont, 90, 118, new SewingKit( 1000 ) );

			PlaceItemIn( cont, 36, 51, new RunicHammer( CraftResource.DullCopper, 1000 ) );
			PlaceItemIn( cont, 42, 51, new RunicHammer( CraftResource.ShadowIron, 1000 ) );
			PlaceItemIn( cont, 48, 51, new RunicHammer( CraftResource.Copper, 1000 ) );
			PlaceItemIn( cont, 54, 51, new RunicHammer( CraftResource.Bronze, 1000 ) );
			PlaceItemIn( cont, 61, 51, new RunicHammer( CraftResource.Gold, 1000 ) );
			PlaceItemIn( cont, 67, 51, new RunicHammer( CraftResource.Agapite, 1000 ) );
			PlaceItemIn( cont, 73, 51, new RunicHammer( CraftResource.Verite, 1000 ) );
			PlaceItemIn( cont, 79, 51, new RunicHammer( CraftResource.Valorite, 1000 ) );

			PlaceItemIn( cont, 36, 55, new RunicSewingKit( CraftResource.SpinedLeather, 1000 ) );
			PlaceItemIn( cont, 42, 55, new RunicSewingKit( CraftResource.HornedLeather, 1000 ) );
			PlaceItemIn( cont, 48, 55, new RunicSewingKit( CraftResource.BarbedLeather, 1000 ) );

			PlaceItemIn( bank, 118, 169, cont );
			// End bag of tools


			// Begin bag of archery ammo
			cont = new Bag();
			cont.Name = "Bag Of Archery Ammo";

			PlaceItemIn( cont, 48, 76, new Arrow( 5000 ) );
			PlaceItemIn( cont, 72, 76, new Bolt( 5000 ) );

			PlaceItemIn( bank, 118, 124, cont );
			// End bag of archery ammo


			// Begin bag of treasure maps
			cont = new Bag();
			cont.Name = "Bag Of Treasure Maps";

			PlaceItemIn( cont, 30, 35, new TreasureMap( 1, Map.Trammel ) );
			PlaceItemIn( cont, 45, 35, new TreasureMap( 2, Map.Trammel ) );
			PlaceItemIn( cont, 60, 35, new TreasureMap( 3, Map.Trammel ) );
			PlaceItemIn( cont, 75, 35, new TreasureMap( 4, Map.Trammel ) );
			PlaceItemIn( cont, 90, 35, new TreasureMap( 5, Map.Trammel ) );
			PlaceItemIn( cont, 90, 35, new TreasureMap( 6, Map.Trammel ) );

			PlaceItemIn( cont, 30, 50, new TreasureMap( 1, Map.Trammel ) );
			PlaceItemIn( cont, 45, 50, new TreasureMap( 2, Map.Trammel ) );
			PlaceItemIn( cont, 60, 50, new TreasureMap( 3, Map.Trammel ) );
			PlaceItemIn( cont, 75, 50, new TreasureMap( 4, Map.Trammel ) );
			PlaceItemIn( cont, 90, 50, new TreasureMap( 5, Map.Trammel ) );
			PlaceItemIn( cont, 90, 50, new TreasureMap( 6, Map.Trammel ) );

			PlaceItemIn( cont, 55, 100, new Lockpick( 30 ) );
			PlaceItemIn( cont, 60, 100, new Pickaxe() );

			PlaceItemIn( bank, 98, 124, cont );
			// End bag of treasure maps


			// Begin bag of raw materials
			cont = new Bag();
			cont.Hue = 0x835;
			cont.Name = "Raw Materials Bag";

			PlaceItemIn( cont, 92, 60, new BarbedLeather( 5000 ) );
			PlaceItemIn( cont, 92, 68, new HornedLeather( 5000 ) );
			PlaceItemIn( cont, 92, 76, new SpinedLeather( 5000 ) );
			PlaceItemIn( cont, 92, 84, new Leather( 5000 ) );

			PlaceItemIn( cont, 30, 118, new Cloth( 5000 ) );
			PlaceItemIn( cont, 30,  84, new Board( 5000 ) );
			PlaceItemIn( cont, 57,  80, new BlankScroll( 500 ) );

			PlaceItemIn( cont, 30,  35, new DullCopperIngot( 5000 ) );
			PlaceItemIn( cont, 37,  35, new ShadowIronIngot( 5000 ) );
			PlaceItemIn( cont, 44,  35, new CopperIngot( 5000 ) );
			PlaceItemIn( cont, 51,  35, new BronzeIngot( 5000 ) );
			PlaceItemIn( cont, 58,  35, new GoldIngot( 5000 ) );
			PlaceItemIn( cont, 65,  35, new AgapiteIngot( 5000 ) );
			PlaceItemIn( cont, 72,  35, new VeriteIngot( 5000 ) );
			PlaceItemIn( cont, 79,  35, new ValoriteIngot( 5000 ) );
			PlaceItemIn( cont, 86,  35, new IronIngot( 5000 ) );

			PlaceItemIn( cont, 30,  59, new RedScales( 5000 ) );
			PlaceItemIn( cont, 36,  59, new YellowScales( 5000 ) );
			PlaceItemIn( cont, 42,  59, new BlackScales( 5000 ) );
			PlaceItemIn( cont, 48,  59, new GreenScales( 5000 ) );
			PlaceItemIn( cont, 54,  59, new WhiteScales( 5000 ) );
			PlaceItemIn( cont, 60,  59, new BlueScales( 5000 ) );

			PlaceItemIn( bank, 98, 169, cont );
			// End bag of raw materials


			// Begin bag of spell casting stuff
			cont = new Backpack();
			cont.Hue = 0x480;
			cont.Name = "Spell Casting Stuff";

			PlaceItemIn( cont, 45, 105, new Spellbook( UInt64.MaxValue ) );
			PlaceItemIn( cont, 65, 105, new NecromancerSpellbook( (UInt64)0xFFFF ) );
			PlaceItemIn( cont, 85, 105, new BookOfChivalry( (UInt64)0x3FF ) );
			PlaceItemIn( cont, 105, 105, new BookOfBushido() );	//Default ctor = full
			PlaceItemIn( cont, 125, 105, new BookOfNinjitsu() ); //Default ctor = full

			Runebook runebook = new Runebook( 10 );
			runebook.CurCharges = runebook.MaxCharges;
			PlaceItemIn( cont, 145, 105, runebook );

			Item toHue = new BagOfReagents( 150 );
			toHue.Hue = 0x2D;
			PlaceItemIn( cont, 45, 150, toHue );

			toHue = new BagOfNecroReagents( 150 );
			toHue.Hue = 0x488;
			PlaceItemIn( cont, 65, 150, toHue );

			PlaceItemIn( cont, 140, 150, new BagOfAllReagents( 500 ) );

			for ( int i = 0; i < 9; ++i )
				PlaceItemIn( cont, 45 + (i * 10), 75, new RecallRune() );

			PlaceItemIn( cont, 141, 74, new FireHorn() );

			PlaceItemIn( bank, 78, 169, cont );
			// End bag of spell casting stuff


			// Begin bag of ethereals
			cont = new Backpack();
			cont.Hue = 0x490;
			cont.Name = "Bag Of Ethy's!";

			PlaceItemIn( cont, 45, 66, new EtherealHorse() );
			PlaceItemIn( cont, 69, 82, new EtherealOstard() );
			PlaceItemIn( cont, 93, 99, new EtherealLlama() );
			PlaceItemIn( cont, 117, 115, new EtherealKirin() );
			PlaceItemIn( cont, 45, 132, new EtherealUnicorn() );
			PlaceItemIn( cont, 69, 66, new EtherealRidgeback() );
			PlaceItemIn( cont, 93, 82, new EtherealSwampDragon() );
			PlaceItemIn( cont, 117, 99, new EtherealBeetle() );

			PlaceItemIn( bank, 38, 124, cont );
			// End bag of ethereals


			// Begin first bag of artifacts
			cont = new Backpack();
			cont.Hue = 0x48F;
			cont.Name = "Bag of Artifacts";

			PlaceItemIn( cont, 45, 66, new TitansHammer() );
			PlaceItemIn( cont, 69, 82, new InquisitorsResolution() );
			PlaceItemIn( cont, 93, 99, new BladeOfTheRighteous() );
			PlaceItemIn( cont, 117, 115, new ZyronicClaw() );

			PlaceItemIn( bank, 58, 124, cont );
			// End first bag of artifacts


			// Begin second bag of artifacts
			cont = new Backpack();
			cont.Hue = 0x48F;
			cont.Name = "Bag of Artifacts";

			PlaceItemIn( cont, 45, 66, new GauntletsOfNobility() );
			PlaceItemIn( cont, 69, 82, new MidnightBracers() );
			PlaceItemIn( cont, 93, 99, new VoiceOfTheFallenKing() );
			PlaceItemIn( cont, 117, 115, new OrnateCrownOfTheHarrower() );
			PlaceItemIn( cont, 45, 132, new HelmOfInsight() );
			PlaceItemIn( cont, 69, 66, new HolyKnightsBreastplate() );
			PlaceItemIn( cont, 93, 82, new ArmorOfFortune() );
			PlaceItemIn( cont, 117, 99, new TunicOfFire() );
			PlaceItemIn( cont, 45, 115, new LeggingsOfBane() );
			PlaceItemIn( cont, 69, 132, new ArcaneShield() );
			PlaceItemIn( cont, 93, 66, new Aegis() );
			PlaceItemIn( cont, 117, 82, new RingOfTheVile() );
			PlaceItemIn( cont, 45, 99, new BraceletOfHealth() );
			PlaceItemIn( cont, 69, 115, new RingOfTheElements() );
			PlaceItemIn( cont, 93, 132, new OrnamentOfTheMagician() );
			PlaceItemIn( cont, 117, 66, new DivineCountenance() );
			PlaceItemIn( cont, 45, 82, new JackalsCollar() );
			PlaceItemIn( cont, 69, 99, new HuntersHeaddress() );
			PlaceItemIn( cont, 93, 115, new HatOfTheMagi() );
			PlaceItemIn( cont, 117, 132, new ShadowDancerLeggings() );
			PlaceItemIn( cont, 45, 66, new SpiritOfTheTotem() );
			PlaceItemIn( cont, 69, 82, new BladeOfInsanity() );
			PlaceItemIn( cont, 93, 99, new AxeOfTheHeavens() );
			PlaceItemIn( cont, 117, 115, new TheBeserkersMaul() );
			PlaceItemIn( cont, 45, 132, new Frostbringer() );
			PlaceItemIn( cont, 69, 66, new BreathOfTheDead() );
			PlaceItemIn( cont, 93, 82, new TheDragonSlayer() );
			PlaceItemIn( cont, 117, 99, new BoneCrusher() );
			PlaceItemIn( cont, 45, 115, new StaffOfTheMagi() );
			PlaceItemIn( cont, 69, 132, new SerpentsFang() );
			PlaceItemIn( cont, 93, 66, new LegacyOfTheDreadLord() );
			PlaceItemIn( cont, 117, 82, new TheTaskmaster() );
			PlaceItemIn( cont, 45, 99, new TheDryadBow() );

			PlaceItemIn( bank, 78, 124, cont );
			// End second bag of artifacts

			// Begin bag of minor artifacts
			cont = new Backpack();
			cont.Hue = 0x48F;
			cont.Name = "Bag of Minor Artifacts";


			PlaceItemIn( cont, 45, 66, new LunaLance() );
			PlaceItemIn( cont, 69, 82, new VioletCourage() );
			PlaceItemIn( cont, 93, 99, new CavortingClub() );
			PlaceItemIn( cont, 117, 115, new CaptainQuacklebushsCutlass() );
			PlaceItemIn( cont, 45, 132, new NightsKiss() );
			PlaceItemIn( cont, 69, 66, new ShipModelOfTheHMSCape() );
			PlaceItemIn( cont, 93, 82, new AdmiralsHeartyRum() );
			PlaceItemIn( cont, 117, 99, new CandelabraOfSouls() );
			PlaceItemIn( cont, 45, 115, new IolosLute() );
			PlaceItemIn( cont, 69, 132, new GwennosHarp() );
			PlaceItemIn( cont, 93, 66, new ArcticDeathDealer() );
			PlaceItemIn( cont, 117, 82, new EnchantedTitanLegBone() );
			PlaceItemIn( cont, 45, 99, new NoxRangersHeavyCrossbow() );
			PlaceItemIn( cont, 69, 115, new BlazeOfDeath() );
			PlaceItemIn( cont, 93, 132, new DreadPirateHat() );
			PlaceItemIn( cont, 117, 66, new BurglarsBandana() );
			PlaceItemIn( cont, 45, 82, new GoldBricks() );
			PlaceItemIn( cont, 69, 99, new AlchemistsBauble() );
			PlaceItemIn( cont, 93, 115, new PhillipsWoodenSteed() );
			PlaceItemIn( cont, 117, 132, new PolarBearMask() );
			PlaceItemIn( cont, 45, 66, new BowOfTheJukaKing() );
			PlaceItemIn( cont, 69, 82, new GlovesOfThePugilist() );
			PlaceItemIn( cont, 93, 99, new OrcishVisage() );
			PlaceItemIn( cont, 117, 115, new StaffOfPower() );
			PlaceItemIn( cont, 45, 132, new ShieldOfInvulnerability() );
			PlaceItemIn( cont, 69, 66, new HeartOfTheLion() );
			PlaceItemIn( cont, 93, 82, new ColdBlood() );
			PlaceItemIn( cont, 117, 99, new GhostShipAnchor() );
			PlaceItemIn( cont, 45, 115, new SeahorseStatuette() );
			PlaceItemIn( cont, 69, 132, new WrathOfTheDryad() );
			PlaceItemIn( cont, 93, 66, new PixieSwatter() );

			for( int i = 0; i < 10; i++ )
				PlaceItemIn( cont, 117, 128, new MessageInABottle( Utility.RandomBool() ? Map.Trammel : Map.Felucca, 4 ) );

			PlaceItemIn( bank, 18, 124, cont );

			if( Core.SE )
			{
				cont = new Bag();
				cont.Hue = 0x501;
				cont.Name = "Tokuno Minor Artifacts";

				PlaceItemIn( cont, 42, 70, new Exiler() );
				PlaceItemIn( cont, 38, 53, new HanzosBow() );
				PlaceItemIn( cont, 45, 40, new TheDestroyer() );
				PlaceItemIn( cont, 92, 80, new DragonNunchaku() );
				PlaceItemIn( cont, 42, 56, new PeasantsBokuto() );
				PlaceItemIn( cont, 44, 71, new TomeOfEnlightenment() );
				PlaceItemIn( cont, 35, 35, new ChestOfHeirlooms() );
				PlaceItemIn( cont, 29,  0, new HonorableSwords() );
				PlaceItemIn( cont, 49, 85, new AncientUrn() );
				PlaceItemIn( cont, 51, 58, new FluteOfRenewal() );
				PlaceItemIn( cont, 70, 51, new PigmentsOfTokuno() );
				PlaceItemIn( cont, 40, 79, new AncientSamuraiDo() );
				PlaceItemIn( cont, 51, 61, new LegsOfStability() );
				PlaceItemIn( cont, 88, 78, new GlovesOfTheSun() );
				PlaceItemIn( cont, 55, 62, new AncientFarmersKasa() );
				PlaceItemIn( cont, 55, 83, new ArmsOfTacticalExcellence() );
				PlaceItemIn( cont, 50, 85, new DaimyosHelm() );
				PlaceItemIn( cont, 52, 78, new BlackLotusHood() );
				PlaceItemIn( cont, 52, 79, new DemonForks() );
				PlaceItemIn( cont, 33, 49, new PilferedDancerFans() );

				PlaceItemIn( bank, 58, 124, cont );
			}

			if( Core.SE )	//This bag came only after SE.
			{
				cont = new Bag();
				cont.Name = "Bag of Bows";

				PlaceItemIn( cont, 31, 84, new Bow() );
				PlaceItemIn( cont, 78, 74, new CompositeBow() );
				PlaceItemIn( cont, 53, 71, new Crossbow() );
				PlaceItemIn( cont, 56, 39, new HeavyCrossbow() );
				PlaceItemIn( cont, 82, 72, new RepeatingCrossbow() );
				PlaceItemIn( cont, 49, 45, new Yumi() );

				for( int i = 0; i < cont.Items.Count; i++ )
				{
					BaseRanged bow = cont.Items[i] as BaseRanged;

					if( bow != null )
					{
						bow.Attributes.WeaponSpeed = 35;
						bow.Attributes.WeaponDamage = 35;
					}
				}

				PlaceItemIn( bank, 108, 135, cont );
			}
		}

		private static void FillBankbox( Mobile m )
		{
			if ( Core.AOS )
			{
				FillBankAOS( m );
				return;
			}

			BankBox bank = m.BankBox;

			bank.DropItem( new BankCheck( 1000000 ) );

			// Full spellbook
			Spellbook book = new Spellbook();

			book.Content = ulong.MaxValue;

			bank.DropItem( book );

			Bag bag = new Bag();

			for ( int i = 0; i < 5; ++i )
				bag.DropItem( new Moonstone( MoonstoneType.Felucca ) );

			// Felucca moonstones
			bank.DropItem( bag );

			bag = new Bag();

			for ( int i = 0; i < 5; ++i )
				bag.DropItem( new Moonstone( MoonstoneType.Trammel ) );

			// Trammel moonstones
			bank.DropItem( bag );

			// Treasure maps
			bank.DropItem( new TreasureMap( 1, Map.Trammel ) );
			bank.DropItem( new TreasureMap( 2, Map.Trammel ) );
			bank.DropItem( new TreasureMap( 3, Map.Trammel ) );
			bank.DropItem( new TreasureMap( 4, Map.Trammel ) );
			bank.DropItem( new TreasureMap( 5, Map.Trammel ) );

			// Bag containing 50 of each reagent
			bank.DropItem( new BagOfReagents( 50 ) );

			// Craft tools
			bank.DropItem( MakeNewbie( new Scissors() ) );
			bank.DropItem( MakeNewbie( new SewingKit( 1000 ) ) );
			bank.DropItem( MakeNewbie( new SmithHammer( 1000 ) ) );
			bank.DropItem( MakeNewbie( new FletcherTools( 1000 ) ) );
			bank.DropItem( MakeNewbie( new DovetailSaw( 1000 ) ) );
			bank.DropItem( MakeNewbie( new MortarPestle( 1000 ) ) );
			bank.DropItem( MakeNewbie( new ScribesPen( 1000 ) ) );
			bank.DropItem( MakeNewbie( new TinkerTools( 1000 ) ) );

			// A few dye tubs
			bank.DropItem( new Dyes() );
			bank.DropItem( new DyeTub() );
			bank.DropItem( new DyeTub() );
			bank.DropItem( new BlackDyeTub() );

			DyeTub darkRedTub = new DyeTub();

			darkRedTub.DyedHue = 0x485;
			darkRedTub.Redyable = false;

			bank.DropItem( darkRedTub );

			// Some food
			bank.DropItem( MakeNewbie( new Apple( 1000 ) ) );

			// Resources
			bank.DropItem( MakeNewbie( new Feather( 1000 ) ) );
			bank.DropItem( MakeNewbie( new BoltOfCloth( 1000 ) ) );
			bank.DropItem( MakeNewbie( new BlankScroll( 1000 ) ) );
			bank.DropItem( MakeNewbie( new Hides( 1000 ) ) );
			bank.DropItem( MakeNewbie( new Bandage( 1000 ) ) );
			bank.DropItem( MakeNewbie( new Bottle( 1000 ) ) );
			bank.DropItem( MakeNewbie( new Log( 1000 ) ) );

			bank.DropItem( MakeNewbie( new IronIngot( 5000 ) ) );
			bank.DropItem( MakeNewbie( new DullCopperIngot( 5000 ) ) );
			bank.DropItem( MakeNewbie( new ShadowIronIngot( 5000 ) ) );
			bank.DropItem( MakeNewbie( new CopperIngot( 5000 ) ) );
			bank.DropItem( MakeNewbie( new BronzeIngot( 5000 ) ) );
			bank.DropItem( MakeNewbie( new GoldIngot( 5000 ) ) );
			bank.DropItem( MakeNewbie( new AgapiteIngot( 5000 ) ) );
			bank.DropItem( MakeNewbie( new VeriteIngot( 5000 ) ) );
			bank.DropItem( MakeNewbie( new ValoriteIngot( 5000 ) ) );

			// Reagents
			bank.DropItem( MakeNewbie( new BlackPearl( 1000 ) ) );
			bank.DropItem( MakeNewbie( new Bloodmoss( 1000 ) ) );
			bank.DropItem( MakeNewbie( new Garlic( 1000 ) ) );
			bank.DropItem( MakeNewbie( new Ginseng( 1000 ) ) );
			bank.DropItem( MakeNewbie( new MandrakeRoot( 1000 ) ) );
			bank.DropItem( MakeNewbie( new Nightshade( 1000 ) ) );
			bank.DropItem( MakeNewbie( new SulfurousAsh( 1000 ) ) );
			bank.DropItem( MakeNewbie( new SpidersSilk( 1000 ) ) );

			// Some extra starting gold
			bank.DropItem( MakeNewbie( new Gold( 9000 ) ) );

			// 5 blank recall runes
			for ( int i = 0; i < 5; ++i )
				bank.DropItem( MakeNewbie( new RecallRune() ) );

			AddPowerScrolls( bank );
		}

		private static void AddPowerScrolls( BankBox bank )
		{
			Bag bag = new Bag();

			for ( int i = 0; i < PowerScroll.Skills.Count; ++i )
				bag.DropItem( new PowerScroll( PowerScroll.Skills[i], 120.0 ) );

			bag.DropItem( new StatCapScroll( 250 ) );

			bank.DropItem( bag );
		}

		private static void AddShirt( Mobile m, int shirtHue )
		{
		}

		private static void AddPants( Mobile m, int pantsHue )
		{
		}

		private static void AddShoes( Mobile m )
		{
		}

		private static Mobile CreateMobile( Account a )
		{
			if ( a.Count >= a.Limit )
				return null;

			for ( int i = 0; i < a.Length; ++i )
			{
				if ( a[i] == null )
					return (a[i] = new PlayerMobile());
			}

			return null;
		}

		private static void EventSink_CharacterCreated( CharacterCreatedEventArgs args )
		{
			if ( !VerifyProfession( args.Profession ) )
				args.Profession = 0;

			NetState state = args.State;

			if ( state == null )
				return;

			Mobile newChar = CreateMobile( args.Account as Account );

			if ( newChar == null )
			{
				Console.WriteLine( "Login: {0}: Character creation failed, account full", state );
				return;
			}

			args.Mobile = newChar;
			m_Mobile = newChar;

			newChar.Player = true;
			newChar.AccessLevel = args.Account.AccessLevel;
			newChar.Female = args.Female;
			//newChar.Body = newChar.Female ? 0x191 : 0x190;

			if( Core.Expansion >= args.Race.RequiredExpansion )
				newChar.Race = args.Race;	//Sets body
			else
				newChar.Race = Race.DefaultRace;

			//newChar.Hue = Utility.ClipSkinHue( args.Hue & 0x3FFF ) | 0x8000;
			newChar.Hue = newChar.Race.ClipSkinHue( args.Hue & 0x3FFF ) | 0x8000;

///////////////////////////// Added for Custom Shard /////////////////////////////////
			newChar.Hunger = Utility.Random( 1, 20 );
			newChar.Thirst = Utility.Random( 1, 20 );

                        newChar.StatCap = 1500;
                        newChar.Skills.Cap = 7000;

///////////////////////////// Added for Custom Shard /////////////////////////////////

			bool young = false;

			if ( newChar is PlayerMobile )
			{
				PlayerMobile pm = (PlayerMobile) newChar;

				pm.Profession = args.Profession;

				if ( pm.AccessLevel == AccessLevel.Player && ((Account)pm.Account).Young )
					young = pm.Young = false;
			}

			SetName( newChar, args.Name );

			AddBackpack( newChar );

			SetStats( newChar, state, args.Str, args.Dex, args.Int );
			SetSkills( newChar, args.Skills, args.Profession );

			Race race = newChar.Race;

			if( race.ValidateHair( newChar, args.HairID ) )
			{
				newChar.HairItemID = args.HairID;
				newChar.HairHue = race.ClipHairHue( args.HairHue & 0x3FFF );
			}

			if( race.ValidateFacialHair( newChar, args.BeardID ) )
			{
				newChar.FacialHairItemID = args.BeardID;
				newChar.FacialHairHue = race.ClipHairHue( args.BeardHue & 0x3FFF );
			}

			if ( args.Profession <= 3 )
			{
				AddShirt( newChar, args.ShirtHue );
				AddPants( newChar, args.PantsHue );
				AddShoes( newChar );
			}

			if( TestCenter.Enabled )
				FillBankbox( newChar );

			if ( young )
			{
			}

			CityInfo city = GetStartLocation( args, young );

///////////////////////////// Added for Custom Shard /////////////////////////////////
			newChar.MoveToWorld( city.Location, city.Map );
                  Timer.DelayCall( TimeSpan.FromSeconds( 2.0 ), new TimerCallback( delegate 
                  {
                      newChar.SendGump(new SexChoiceGump() );
                  } ) );
///////////////////////////// Added for Custom Shard /////////////////////////////////

			Console.WriteLine( "Login: {0}: New character being created (account={1})", state, args.Account.Username );
			Console.WriteLine( " - Character: {0} (serial={1})", newChar.Name, newChar.Serial );
			Console.WriteLine( " - Started: {0} {1} in {2}", city.City, city.Location, city.Map.ToString() );

			new WelcomeTimer( newChar ).Start();
		}

		public static bool VerifyProfession( int profession )
		{
			if ( profession < 0 )
				return false;
			else if ( profession < 4 )
				return true;
			else if ( Core.AOS && profession < 6 )
				return true;
			else if ( Core.SE && profession < 8 )
				return true;
			else
				return false;
		}

		private class BadStartMessage : Timer
		{
			Mobile m_Mobile;
			int m_Message;
			public BadStartMessage( Mobile m, int message ) : base( TimeSpan.FromSeconds ( 3.5 ) )
			{
				m_Mobile = m;
				m_Message = message;
				this.Start();
			}

			protected override void OnTick()
			{
				m_Mobile.SendLocalizedMessage( m_Message );
			}
		}

		private static readonly CityInfo m_NewHavenInfo = new CityInfo( "New Haven", "The Bountiful Harvest Inn", 2519, 1972, 0, Map.Malas );

		private static CityInfo GetStartLocation( CharacterCreatedEventArgs args, bool isYoung )
		{
			if( Core.ML )
			{
				//if( args.State != null && args.State.NewHaven )
				return m_NewHavenInfo;	//We don't get the client Version until AFTER Character creation

				//return args.City;  TODO: Uncomment when the old quest system is actually phased out
			}

			bool useHaven = isYoung;

			ClientFlags flags = args.State == null ? ClientFlags.None : args.State.Flags;
			Mobile m = args.Mobile;

			switch ( args.Profession )
			{
				case 4: //Necro
				{
					if ( (flags & ClientFlags.Malas) != 0 )
					{
						return new CityInfo( "Umbra", "Mardoth's Tower", 2519, 1972, 0, Map.Malas );
					}
					else
					{
						useHaven = true; 

						new BadStartMessage( m, 1062205 );
						/*
						 * Unfortunately you are playing on a *NON-Age-Of-Shadows* game 
						 * installation and cannot be transported to Malas.  
						 * You will not be able to take your new player quest in Malas 
						 * without an AOS client.  You are now being taken to the city of 
						 * Haven on the Trammel facet.
						 * */
					}

					break;
				}
				case 5:	//Paladin
				{
					return m_NewHavenInfo;
				}
				case 6:	//Samurai
				{
					if ( (flags & ClientFlags.Tokuno) != 0 )
					{
						return new CityInfo( "Samurai DE", "Haoti's Grounds", 2519, 1972, 0, Map.Malas );
					}
					else
					{
						useHaven = true;

						new BadStartMessage( m, 1063487 );
						/*
						 * Unfortunately you are playing on a *NON-Samurai-Empire* game 
						 * installation and cannot be transported to Tokuno. 
						 * You will not be able to take your new player quest in Tokuno 
						 * without an SE client. You are now being taken to the city of 
						 * Haven on the Trammel facet.
						 * */
					}

					break;
				}
				case 7:	//Ninja
				{
					if ( (flags & ClientFlags.Tokuno) != 0 )
					{
						return new CityInfo( "Ninja DE", "Enimo's Residence", 2519, 1972, 0, Map.Malas );
					}
					else
					{
						useHaven = true;

						new BadStartMessage( m, 1063487 );
						/*
						 * Unfortunately you are playing on a *NON-Samurai-Empire* game 
						 * installation and cannot be transported to Tokuno. 
						 * You will not be able to take your new player quest in Tokuno 
						 * without an SE client. You are now being taken to the city of 
						 * Haven on the Trammel facet.
						 * */
					}

					break;
				}
			}

			if( useHaven )
				return m_NewHavenInfo;
			else
				return args.City;
		}

		private static void FixStats( ref int str, ref int dex, ref int intel, int max )
		{
			int vMax = max - 30;

			int vStr = str - 10;
			int vDex = dex - 10;
			int vInt = intel - 10;

			if ( vStr < 0 )
				vStr = 0;

			if ( vDex < 0 )
				vDex = 0;

			if ( vInt < 0 )
				vInt = 0;

			int total = vStr + vDex + vInt;

			if ( total == 0 || total == vMax )
				return;

			double scalar = vMax / (double)total;

			vStr = (int)(vStr * scalar);
			vDex = (int)(vDex * scalar);
			vInt = (int)(vInt * scalar);

			FixStat( ref vStr, (vStr + vDex + vInt) - vMax, vMax );
			FixStat( ref vDex, (vStr + vDex + vInt) - vMax, vMax );
			FixStat( ref vInt, (vStr + vDex + vInt) - vMax, vMax );

			str = vStr + 10;
			dex = vDex + 10;
			intel = vInt + 10;
		}

		private static void FixStat( ref int stat, int diff, int max )
		{
			stat += diff;

			if ( stat < 0 )
				stat = 0;
			else if ( stat > max )
				stat = max;
		}

		private static void SetStats( Mobile m, NetState state, int str, int dex, int intel )
		{
			int max = state.NewCharacterCreation ? 90 : 80;

			FixStats( ref str, ref dex, ref intel, max );

			if ( str < 10 || str > 60 || dex < 10 || dex > 60 || intel < 10 || intel > 60 || (str + dex + intel) != max )
			{
				str = Utility.Random( 10, 30 );
				dex = Utility.Random( 10, 30 );
				intel = Utility.Random( 10, 30 );
			}

			m.InitStats( str, dex, intel );
		}
///////////////////////////// Modified for Custom Shard /////////////////////////////////

		private static void SetName( Mobile m, string name )
		{
			name = name.Trim();

			if ( !NameVerification.Validate( name, 2, 16, true, false, true, 1, NameVerification.SpaceDashPeriodQuote ) )
				name = "Generic Player";

			m.Name = name;
		}

		private static bool ValidSkills( SkillNameValue[] skills )
		{
			int total = 0;

			for ( int i = 0; i < skills.Length; ++i )
			{
				if ( skills[i].Value < 0 || skills[i].Value > 50 )
					return false;

				total += skills[i].Value;

				for ( int j = i + 1; j < skills.Length; ++j )
				{
					if ( skills[j].Value > 0 && skills[j].Name == skills[i].Name )
						return false;
				}
			}

			return ( total == 100 || total == 120 );
		}

///////////////////////////// Modified for Custom Shard /////////////////////////////////

		private static Mobile m_Mobile;

		private static void SetSkills( Mobile m, SkillNameValue[] skills, int prof )
		{
			switch ( prof )
			{
				case 1: // Warrior
				{
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Anatomy, 10 ),
							new SkillNameValue( SkillName.Fencing, 50 ),
							new SkillNameValue( SkillName.Healing, 50 ),
							new SkillNameValue( SkillName.Macing, 50 ),
							new SkillNameValue( SkillName.Swords, 50 ),
							new SkillNameValue( SkillName.Tactics, 10 )
						};

					break;
				}
				case 2: // Magician
				{
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Alchemy, 25 ),
							new SkillNameValue( SkillName.EvalInt, 25 ),
							new SkillNameValue( SkillName.Inscribe, 25 ),
							new SkillNameValue( SkillName.Magery, 50 ),
							new SkillNameValue( SkillName.Meditation, 50 ),
							new SkillNameValue( SkillName.Wrestling, 10 )
						};

					break;
				}
				case 3: // Blacksmith
				{
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.ArmsLore, 10 ),
							new SkillNameValue( SkillName.Blacksmith, 50 ),
							new SkillNameValue( SkillName.Mining, 50 ),
							new SkillNameValue( SkillName.Tinkering, 50 )
						};

					break;
				}
				case 4: // Necromancer
				{
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Necromancy, 50 ),
							new SkillNameValue( SkillName.Focus, 10 ),
							new SkillNameValue( SkillName.SpiritSpeak, 50 ),
							new SkillNameValue( SkillName.Swords, 50 )
						};

					break;
				}
				case 5: // Paladin
				{
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Chivalry, 50 ),
							new SkillNameValue( SkillName.Swords, 50 ),
							new SkillNameValue( SkillName.Focus, 10 ),
							new SkillNameValue( SkillName.Tactics, 25 )
						};

					break;
				}
				case 6:	//Samurai
				{
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Bushido, 50 ),
							new SkillNameValue( SkillName.Swords, 50 ),
							new SkillNameValue( SkillName.Anatomy, 10 ),
							new SkillNameValue( SkillName.Healing, 50 )
					        };
					break;
				}
				case 7:	//Ninja
				{
					skills = new SkillNameValue[]
						{
							new SkillNameValue( SkillName.Ninjitsu, 50 ),
							new SkillNameValue( SkillName.Hiding, 50 ),
							new SkillNameValue( SkillName.Fencing, 50 ),
							new SkillNameValue( SkillName.Stealth, 10 )
						};
					break;
				}
				default:
				{
					if ( !ValidSkills( skills ) )
						return;

					break;
				}
			}

			bool addSkillItems = true;
			bool elf = (m.Race == Race.Elf);

			switch ( prof )
			{
				case 1: // Warrior
				{
					addSkillItems = false;

					break;
				}
				case 2: // Mage
				{
					addSkillItems = false;

					break;
				}
				case 3: // Blacksmith
				{
					addSkillItems = false;

					break;
				}
				case 4: // Necromancer
				{
					addSkillItems = false;

					break;
				}
				case 5: // Paladin
				{
					addSkillItems = false;

					break;
				}
					
				case 6: // Samurai
				{
					addSkillItems = false;

					break;
				}
				case 7: // Ninja
				{
					addSkillItems = false;

					break;
				}
			}

			for ( int i = 0; i < skills.Length; ++i )
			{
				SkillNameValue snv = skills[i];

				if ( snv.Value > 0 && ( snv.Name != SkillName.Stealth || prof == 7 ) && snv.Name != SkillName.RemoveTrap && snv.Name != SkillName.Spellweaving )
				{
					Skill skill = m.Skills[snv.Name];

					if ( skill != null )
					{
						skill.BaseFixedPoint = snv.Value * 10;

						if ( addSkillItems )
							AddSkillItems( snv.Name, m );
					}
				}
			}
		}
///////////////////////////// Modified for Custom Shard /////////////////////////////////

		private static void EquipItem( Item item )
		{
                        //ItemID Mods Begin
                        if (item is BaseWeapon)
                               ((BaseWeapon)item).Identified = true;
                        else if (item is BaseArmor)
                               ((BaseArmor)item).Identified = true;
                        else if (item is BaseClothing)
                               ((BaseClothing)item).Identified = true;
                        else if (item is BaseJewel)
                               ((BaseJewel)item).Identified = true;
                        //ItemID Mods end

			EquipItem( item, false );
		}

		private static void EquipItem( Item item, bool mustEquip )
		{
                        //ItemID Mods Begin
                        if (item is BaseWeapon)
                               ((BaseWeapon)item).Identified = true;
                        else if (item is BaseArmor)
                               ((BaseArmor)item).Identified = true;
                        else if (item is BaseClothing)
                               ((BaseClothing)item).Identified = true;
                        else if (item is BaseJewel)
                               ((BaseJewel)item).Identified = true;
                        //ItemID Mods end

			if ( !Core.AOS )
				item.LootType = LootType.Newbied;

			if ( m_Mobile != null && m_Mobile.EquipItem( item ) )
				return;

			Container pack = m_Mobile.Backpack;

			if ( !mustEquip && pack != null )
				pack.DropItem( item );
			else
				item.Delete();
		}

		private static void PackItem( Item item )
		{
                        //ItemID Mods Begin
                        if (item is BaseWeapon)
                               ((BaseWeapon)item).Identified = true;
                        else if (item is BaseArmor)
                               ((BaseArmor)item).Identified = true;
                        //ItemID Mods end

			if ( !Core.AOS )
				item.LootType = LootType.Newbied;

			Container pack = m_Mobile.Backpack;

			if ( pack != null )
				pack.DropItem( item );
			else
				item.Delete();
		}

///////////////////////////// Modified for Custom Shard /////////////////////////////////
		private static void PackInstrument()
		{
			switch ( Utility.Random( 6 ) )
			{
				case 0: PackItem( new Drums() ); break;
				case 1: PackItem( new Harp() ); break;
				case 2: PackItem( new LapHarp() ); break;
				case 3: PackItem( new Lute() ); break;
				case 4: PackItem( new Tambourine() ); break;
				case 5: PackItem( new TambourineTassel() ); break;
			}
		}

		private static void PackScroll( int circle )
		{
			switch ( Utility.Random( 5 ) * ( circle + 1 ) )
			{
				case  0: PackItem( new ClumsyScroll() ); break;
				case  1: PackItem( new FeeblemindScroll() ); break;
				case  2: PackItem( new HealScroll() ); break;
				case  3: PackItem( new MagicArrowScroll() ); break;
				case  4: PackItem( new ReactiveArmorScroll() ); break;
			}
		}
///////////////////////////// Modified for Custom Shard /////////////////////////////////

		private static Item NecroHue( Item item )
		{
			item.Hue = 0x2C3;

			return item;
		}

///////////////////////////// Modified for Custom Shard /////////////////////////////////
		private static void AddSkillItems( SkillName skill, Mobile m )
		{
			switch ( skill )
			{
				case SkillName.Alchemy:
				{
					BagOfReagents regs = new BagOfReagents( 200 );

					if ( !Core.AOS )
					{
						foreach ( Item item in regs.Items )
							item.LootType = LootType.Newbied;
					}

					PackItem( regs );

					regs.LootType = LootType.Regular;

					PackItem( new Bottle( 100 ) );
					PackItem( new MortarPestle() );
					PackItem( new MortarPestle() );
					PackItem( new MortarPestle() );
					break;
				}
				case SkillName.Anatomy:
				{
					PackItem( new Bandage( 200 ) );
					break;
				}
				case SkillName.AnimalLore:
				{
					PackItem( MakeNewbie( new WildStaff() ) );
					break;
				}
				case SkillName.Archery:
				{
                                        BaseWeapon weapon = new Bow();
                                        weapon.Hue = 2106;
                                        weapon.WeaponAttributes.HitLightning = 5;

                                        PackItem( weapon );

					PackItem( new Arrow( 50 ) );
					PackItem( new OakArrow( 40 ) );
					PackItem( new YewArrow( 30 ) );
					PackItem( new AshArrow( 20 ) );
					break;
				}
				case SkillName.ArmsLore:
				{
					PackItem( MakeNewbie( new DiamondMace() ) );
					break;
				}
				case SkillName.Begging:
				{
					PackItem( new Gold( 1000 ) );
					break;
				}
				case SkillName.Blacksmith:
				{
					PackItem( new Tongs() );
					PackItem( MakeNewbie( new Pickaxe() ) );
					PackItem( MakeNewbie( new Pickaxe() ) );
					PackItem( new IronIngot( 50 ) );
					EquipItem( MakeNewbie( new HalfApron( Utility.RandomYellowHue() ) ) );
					break;
				}
				case SkillName.Bushido:
				{
					EquipItem( MakeNewbie( new Hakama() ) );
					EquipItem( MakeNewbie( new Kasa() ) );
					EquipItem( new BookOfBushido() );
					break;
				}
				case SkillName.Fletching:
				{
					PackItem( new Arrow( 50 ) );
					PackItem( new OakArrow( 40 ) );
					PackItem( new YewArrow( 30 ) );
					PackItem( new AshArrow( 20 ) );
					break;
				}
				case SkillName.Camping:
				{
					PackItem( new TentDeed() );

					PackItem( new Bedroll() );
					PackItem( new Kindling( 10 ) );
					break;
				}
				case SkillName.Carpentry:
				{
					PackItem( new Board( 100 ) );
					PackItem( new Saw() );
					PackItem( new HalfApron( Utility.RandomYellowHue() ) );
					break;
				}
				case SkillName.Cartography:
				{
					PackItem( new BlankMap() );
					PackItem( new BlankMap() );
					PackItem( new BlankMap() );
					PackItem( new Sextant() );
					break;
				}
				case SkillName.Chivalry:
				{
					PackItem( new BookOfChivalry( (ulong)0x3FF ) );

					break;
				}
				case SkillName.Cooking:
				{
					PackItem( new Kindling( 2 ) );
					PackItem( new RawLambLeg() );
					PackItem( new RawChickenLeg() );
					PackItem( new RawFishSteak() );
					PackItem( new SackFlour() );
					PackItem( new Pitcher( BeverageType.Water ) );
					break;
				}
				case SkillName.DetectHidden:
				{
					PackItem( new Cloak( 0x455 ) );
					break;
				}
				case SkillName.Discordance:
				{
					PackInstrument();
					break;
				}
				case SkillName.Fencing:
				{
                                        BaseWeapon weapon = new Kryss();
                                        weapon.Hue = 2106;
                                        weapon.WeaponAttributes.HitLightning = 5;

                                        PackItem( weapon );
					break;
				}
				case SkillName.Fishing:
				{
					PackItem( new FishingPole() );
					PackItem( new FloppyHat( Utility.RandomYellowHue() ) );
					PackItem( new CrabtreesCabinLager() );
					break;
				}
				case SkillName.Healing:
				{
					PackItem( new Bandage( 25 ) );
					PackItem( new Scissors() );
					break;
				}
				case SkillName.Herding:
				{
					PackItem( new ShepherdsCrook() );
					break;
				}
				case SkillName.Hiding:
				{
					PackItem( MakeNewbie( new Cloak( 0x455 ) ) );
					break;
				}
				case SkillName.Inscribe:
				{
					PackItem( new BlankScroll( 50 ) );
					PackItem( new BlueBook() );
					break;
				}
				case SkillName.Lockpicking:
				{
					PackItem( new Lockpick( 25 ) );
					break;
				}
				case SkillName.Lumberjacking:
				{
                                        BaseWeapon weapon = new Hatchet();
                                        weapon.Hue = 2106;
                                        weapon.WeaponAttributes.HitLightning = 5;

                                        PackItem( weapon );
					break;
				}
				case SkillName.Macing:
				{
                                        BaseWeapon weapon = new Club();
                                        weapon.Hue = 2106;
                                        weapon.WeaponAttributes.HitLightning = 5;

                                        PackItem( weapon );
					break;
				}
				case SkillName.Magery:
				{
					BagOfReagents regs = new BagOfReagents( 30 );

					if ( !Core.AOS )
					{
						foreach ( Item item in regs.Items )
							item.LootType = LootType.Newbied;
					}

					PackItem( regs );

					regs.LootType = LootType.Regular;

					PackScroll( 0 );
					PackScroll( 1 );
					PackScroll( 2 );

					Spellbook book = new Spellbook( (ulong)0x382A8C38 );

					EquipItem( book );

					book.LootType = LootType.Blessed;
					break;
				}
				case SkillName.Mining:
				{
					PackItem( MakeNewbie( new Pickaxe() ) );
					break;
				}
				case SkillName.Musicianship:
				{
					PackInstrument();
					break;
				}
				case SkillName.Necromancy:
				{
					Container regs = new BagOfNecroReagents( 50 );

					PackItem( regs );
					regs.LootType = LootType.Regular;

					Spellbook book = new NecromancerSpellbook( (ulong)0x8981 ); // animate dead, evil omen, pain spike, summon familiar, wraith form

					PackItem( book );
					book.LootType = LootType.Blessed;

					break;
				}
				case SkillName.Ninjitsu:
				{
					EquipItem( MakeNewbie( new Hakama( 0x2C3 ) ) );	//Only ninjas get the hued one.
					EquipItem( MakeNewbie( new Kasa() ) );
					EquipItem( new BookOfNinjitsu() );
					break;
				}
				case SkillName.Parry:
				{
					PackItem( MakeNewbie( new JewelShield() ) );
					break;
				}
				case SkillName.Peacemaking:
				{
					PackInstrument();
					PackItem( new BumLight() );
					break;
				}
				case SkillName.Poisoning:
				{
					PackItem( new LesserPoisonPotion() );
					PackItem( new PoisonPotion() );
					PackItem( new GreaterPoisonPotion() );
					PackItem( new DeadlyPoisonPotion() );
					break;
				}
				case SkillName.Provocation:
				{
					PackInstrument();
					break;
				}
				case SkillName.Snooping:
				{
					PackItem( new Lockpick( 25 ) );
					break;
				}
				case SkillName.SpiritSpeak:
				{
					PackItem( MakeNewbie( new Cloak( 0x455 ) ) );
					break;
				}
				case SkillName.Stealing:
				{
					PackItem( new BlackPantherTonic() );
					break;
				}
				case SkillName.Swords:
				{
                                        BaseWeapon weapon = new Katana();
                                        weapon.Hue = 2106;
                                        weapon.WeaponAttributes.HitLightning = 5;

                                        PackItem( weapon );
					break;
				}
				case SkillName.Tactics:
				{
					PackItem( MakeNewbie( new RuneBlade() ) );
					break;
				}
				case SkillName.Tailoring:
				{
					PackItem( new BoltOfCloth() );
					PackItem( new SewingKit() );
					break;
				}
				case SkillName.Veterinary:
				{
					PackItem( new Bandage( 5 ) );
					PackItem( new Scissors() );
					break;
				}
				case SkillName.Wrestling:
				{
					PackItem( MakeNewbie( new LeatherGloves() ) );
					PackItem( new IrishSpirit() );
					break;
				}
			}
		}
	}
}
///////////////////////////// Modified for Custom Shard /////////////////////////////////
