using System;
using Server;
using Server.Items;

namespace Server.Engines.BulkOrders
{
	public delegate Item ConstructCallback( int type );

	public sealed class RewardType
	{
		private int m_Points;
		private Type[] m_Types;

		public int Points{ get{ return m_Points; } }
		public Type[] Types{ get{ return m_Types; } }

		public RewardType( int points, params Type[] types )
		{
			m_Points = points;
			m_Types = types;
		}

		public bool Contains( Type type )
		{
			for ( int i = 0; i < m_Types.Length; ++i )
			{
				if ( m_Types[i] == type )
					return true;
			}

			return false;
		}
	}

	public sealed class RewardItem
	{
		private int m_Weight;
		private ConstructCallback m_Constructor;
		private int m_Type;

		public int Weight{ get{ return m_Weight; } }
		public ConstructCallback Constructor{ get{ return m_Constructor; } }
		public int Type{ get{ return m_Type; } }

		public RewardItem( int weight, ConstructCallback constructor ) : this( weight, constructor, 0 )
		{
		}

		public RewardItem( int weight, ConstructCallback constructor, int type )
		{
			m_Weight = weight;
			m_Constructor = constructor;
			m_Type = type;
		}

		public Item Construct()
		{
			try{ return m_Constructor( m_Type ); }
			catch{ return null; }
		}
	}

	public sealed class RewardGroup
	{
		private int m_Points;
		private RewardItem[] m_Items;

		public int Points{ get{ return m_Points; } }
		public RewardItem[] Items{ get{ return m_Items; } }

		public RewardGroup( int points, params RewardItem[] items )
		{
			m_Points = points;
			m_Items = items;
		}

		public RewardItem AcquireItem()
		{
			if ( m_Items.Length == 0 )
				return null;
			else if ( m_Items.Length == 1 )
				return m_Items[0];

			int totalWeight = 0;

			for ( int i = 0; i < m_Items.Length; ++i )
				totalWeight += m_Items[i].Weight;

			int randomWeight = Utility.Random( totalWeight );

			for ( int i = 0; i < m_Items.Length; ++i )
			{
				RewardItem item = m_Items[i];

				if ( randomWeight < item.Weight )
					return item;

				randomWeight -= item.Weight;
			}

			return null;
		}
	}

	public abstract class RewardCalculator
	{
		private RewardGroup[] m_Groups;

		public RewardGroup[] Groups{ get{ return m_Groups; } set{ m_Groups = value; } }

		public abstract int ComputePoints( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type );
		public abstract int ComputeGold( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type );

		public virtual int ComputeFame( SmallBOD bod )
		{
			int points = ComputePoints( bod ) / 50;

			return points * points;
		}

		public virtual int ComputeFame( LargeBOD bod )
		{
			int points = ComputePoints( bod ) / 50;

			return points * points;
		}

		public virtual int ComputePoints( SmallBOD bod )
		{
			return ComputePoints( bod.AmountMax, bod.RequireExceptional, bod.Material, 1, bod.Type );
		}

		public virtual int ComputePoints( LargeBOD bod )
		{
			return ComputePoints( bod.AmountMax, bod.RequireExceptional, bod.Material, bod.Entries.Length, bod.Entries[0].Details.Type );
		}

		public virtual int ComputeGold( SmallBOD bod )
		{
			return ComputeGold( bod.AmountMax, bod.RequireExceptional, bod.Material, 1, bod.Type );
		}

		public virtual int ComputeGold( LargeBOD bod )
		{
			return ComputeGold( bod.AmountMax, bod.RequireExceptional, bod.Material, bod.Entries.Length, bod.Entries[0].Details.Type );
		}

		public virtual RewardGroup LookupRewards( int points )
		{
			for ( int i = m_Groups.Length - 1; i >= 1; --i )
			{
				RewardGroup group = m_Groups[i];

				if ( points >= group.Points )
					return group;
			}

			return m_Groups[0];
		}

		public virtual int LookupTypePoints( RewardType[] types, Type type )
		{
			for ( int i = 0; i < types.Length; ++i )
			{
				if ( types[i].Contains( type ) )
					return types[i].Points;
			}

			return 0;
		}

		public RewardCalculator()
		{
		}
	}

	public sealed class SmithRewardCalculator : RewardCalculator
	{
		#region Constructors
		private static readonly ConstructCallback SturdyShovel = new ConstructCallback( CreateSturdyShovel );
		private static readonly ConstructCallback SturdyPickaxe = new ConstructCallback( CreateSturdyPickaxe );
		private static readonly ConstructCallback MiningGloves = new ConstructCallback( CreateMiningGloves );
		private static readonly ConstructCallback GargoylesPickaxe = new ConstructCallback( CreateGargoylesPickaxe );
		private static readonly ConstructCallback ProspectorsTool = new ConstructCallback( CreateProspectorsTool );
		private static readonly ConstructCallback PowderOfTemperament = new ConstructCallback( CreatePowderOfTemperament );
		private static readonly ConstructCallback RunicHammer = new ConstructCallback( CreateRunicHammer );
		private static readonly ConstructCallback PowerScroll = new ConstructCallback( CreatePowerScroll );
		private static readonly ConstructCallback ColoredAnvil = new ConstructCallback( CreateColoredAnvil );
		private static readonly ConstructCallback AncientHammer = new ConstructCallback( CreateAncientHammer );

		private static Item CreateSturdyShovel( int type )
		{
			return new SturdyShovel();
		}

		private static Item CreateSturdyPickaxe( int type )
		{
			return new SturdyPickaxe();
		}

		private static Item CreateMiningGloves( int type )
		{
			if ( type == 1 )
				return new LeatherGlovesOfMining( 1 );
			else if ( type == 3 )
				return new StuddedGlovesOfMining( 3 );
			else if ( type == 5 )
				return new RingmailGlovesOfMining( 5 );

			throw new InvalidOperationException();
		}

		private static Item CreateGargoylesPickaxe( int type )
		{
			return new GargoylesPickaxe();
		}

		private static Item CreateProspectorsTool( int type )
		{
			return new ProspectorsTool();
		}

		private static Item CreatePowderOfTemperament( int type )
		{
			return new PowderOfTemperament();
		}

		private static Item CreateRunicHammer( int type )
		{
			if ( type >= 1 && type <= 8 )
				return new RunicHammer( CraftResource.Iron + type, Core.AOS ? ( 55 - (type*5) ) : 50 );

			throw new InvalidOperationException();
		}

		private static Item CreatePowerScroll( int type )
		{
			if ( type == 5 || type == 10 || type == 15 || type == 20 )
				return new PowerScroll( SkillName.Blacksmith, 100 + type );

			throw new InvalidOperationException();
		}

		private static Item CreateColoredAnvil( int type )
		{
			// Generate an anvil deed, not an actual anvil.
			//return new ColoredAnvilDeed();

			return new ColoredAnvil();
		}

		private static Item CreateAncientHammer( int type )
		{
			if ( type == 10 || type == 15 || type == 30 || type == 60 )
				return new AncientSmithyHammer( type );

			throw new InvalidOperationException();
		}
		#endregion

		public static readonly SmithRewardCalculator Instance = new SmithRewardCalculator();

		private RewardType[] m_Types = new RewardType[]
			{
				// Armors
				new RewardType( 200, typeof( RingmailGloves ), typeof( RingmailChest ), typeof( RingmailArms ), typeof( RingmailLegs ) ),
				new RewardType( 300, typeof( ChainCoif ), typeof( ChainLegs ), typeof( ChainChest ) ),
				new RewardType( 400, typeof( PlateArms ), typeof( PlateLegs ), typeof( PlateHelm ), typeof( PlateGorget ), typeof( PlateGloves ), typeof( PlateChest ) ),

				// Weapons
				new RewardType( 200, typeof( Bardiche ), typeof( Halberd ) ),
				new RewardType( 300, typeof( Dagger ), typeof( ShortSpear ), typeof( Spear ), typeof( WarFork ), typeof( Kryss ) ),	//OSI put the dagger in there.  Odd, ain't it.
				new RewardType( 350, typeof( Axe ), typeof( BattleAxe ), typeof( DoubleAxe ), typeof( ExecutionersAxe ), typeof( LargeBattleAxe ), typeof( TwoHandedAxe ) ),
				new RewardType( 350, typeof( Cutlass ), typeof( Katana ), typeof( Longsword ), typeof( Scimitar ), /*typeof( ThinLongsword ),*/ typeof( VikingSword ) ),
				new RewardType( 350, typeof( WarAxe ), typeof( HammerPick ), typeof( Mace ), typeof( Maul ), typeof( WarHammer ), typeof( WarMace ) )
			};

		public override int ComputePoints( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type )
		{
			int points = 0;

			if ( quantity == 10 )
				points += 10;
			else if ( quantity == 15 )
				points += 25;
			else if ( quantity == 20 )
				points += 50;

			if ( exceptional )
				points += 200;

			if ( itemCount > 1 )
				points += LookupTypePoints( m_Types, type );

			if ( material >= BulkMaterialType.DullCopper && material <= BulkMaterialType.Valorite )
				points += 200 + (50 * (material - BulkMaterialType.DullCopper));

			return points;
		}

		private static int[][][] m_GoldTable = new int[][][]
			{
				new int[][] // 1-part (regular)
				{
					new int[]{ 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000 },
					new int[]{ 10000, 11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000 },
					new int[]{ 19000, 20000, 21000, 22000, 23000, 24000, 25000, 26000, 27000 }
				},
				new int[][] // 1-part (exceptional)
				{
					new int[]{ 2000, 4000, 6000, 8000, 10000, 12000, 14000, 16000, 18000 },
					new int[]{ 20000, 22000, 24000, 26000, 28000, 30000, 32000, 34000, 36000 },
					new int[]{ 38000, 40000, 42000, 44000, 46000, 48000, 50000, 52000, 54000 }
				},
				new int[][] // Ringmail (regular)
				{
					new int[]{ 3000,  5000,  5000,  7500,  7500, 10000, 10000, 15000, 15000 },
					new int[]{ 4500,  7500,  7500, 11250, 11500, 15000, 15000, 22500, 22500 },
					new int[]{ 6000, 10000, 15000, 15000, 20000, 20000, 30000, 30000, 50000 }
				},
				new int[][] // Ringmail (exceptional)
				{
					new int[]{  5000, 10000, 10000, 15000, 15000, 25000,  25000,  50000,  50000 },
					new int[]{  7500, 15000, 15000, 22500, 22500, 37500,  37500,  75000,  75000 },
					new int[]{ 10000, 20000, 30000, 30000, 50000, 50000, 100000, 100000, 200000 }
				},
				new int[][] // Chainmail (regular)
				{
					new int[]{ 4000,  7500,  7500, 10000, 10000, 15000, 15000, 25000,  25000 },
					new int[]{ 6000, 11250, 11250, 15000, 15000, 22500, 22500, 37500,  37500 },
					new int[]{ 8000, 15000, 20000, 20000, 30000, 30000, 50000, 50000, 100000 }
				},
				new int[][] // Chainmail (exceptional)
				{
					new int[]{  7500, 15000, 15000, 25000,  25000,  50000,  50000, 100000, 100000 },
					new int[]{ 11250, 22500, 22500, 37500,  37500,  75000,  75000, 150000, 150000 },
					new int[]{ 15000, 30000, 50000, 50000, 100000, 100000, 200000, 200000, 200000 }
				},
				new int[][] // Platemail (regular)
				{
					new int[]{  5000, 10000, 10000, 15000, 15000, 25000,  25000,  50000,  50000 },
					new int[]{  7500, 15000, 15000, 22500, 22500, 37500,  37500,  75000,  75000 },
					new int[]{ 10000, 20000, 30000, 30000, 50000, 50000, 100000, 100000, 200000 }
				},
				new int[][] // Platemail (exceptional)
				{
					new int[]{ 10000, 25000,  25000,  50000,  50000, 100000, 100000, 100000, 100000 },
					new int[]{ 15000, 37500,  37500,  75000,  75000, 150000, 150000, 150000, 150000 },
					new int[]{ 20000, 50000, 100000, 100000, 200000, 200000, 200000, 200000, 200000 }
				},
				new int[][] // 2-part weapons (regular)
				{
					new int[]{ 3000, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 4500, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 6000, 0, 0, 0, 0, 0, 0, 0, 0 }
				},
				new int[][] // 2-part weapons (exceptional)
				{
					new int[]{ 5000, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 7500, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 10000, 0, 0, 0, 0, 0, 0, 0, 0 }
				},
				new int[][] // 5-part weapons (regular)
				{
					new int[]{ 4000, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 6000, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 8000, 0, 0, 0, 0, 0, 0, 0, 0 }
				},
				new int[][] // 5-part weapons (exceptional)
				{
					new int[]{ 7500, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 11250, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 15000, 0, 0, 0, 0, 0, 0, 0, 0 }
				},
				new int[][] // 6-part weapons (regular)
				{
					new int[]{ 4000, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 6000, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 10000, 0, 0, 0, 0, 0, 0, 0, 0 }
				},
				new int[][] // 6-part weapons (exceptional)
				{
					new int[]{ 7500, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 11250, 0, 0, 0, 0, 0, 0, 0, 0 },
					new int[]{ 15000, 0, 0, 0, 0, 0, 0, 0, 0 }
				}
			};

		private int ComputeType( Type type, int itemCount )
		{
			// Item count of 1 means it's a small BOD.
			if ( itemCount == 1 )
				return 0;

			int typeIdx;

			// Loop through the RewardTypes defined earlier and find the correct one.
			for ( typeIdx = 0; typeIdx < 7; ++typeIdx )
			{
				if ( m_Types[typeIdx].Contains( type ) )
					break;
			}

			// Types 5, 6 and 7 are Large Weapon BODs with the same rewards.
			if ( typeIdx > 5 )
				typeIdx = 5;

			return ( typeIdx + 1 ) * 2;
		}

		public override int ComputeGold( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type )
		{
			int[][][] goldTable = m_GoldTable;

			int typeIndex = ComputeType( type, itemCount );
			int quanIndex = ( quantity == 20 ? 2 : quantity == 15 ? 1 : 0 );
			int mtrlIndex = ( material >= BulkMaterialType.DullCopper && material <= BulkMaterialType.Valorite ) ? 1 + (int)(material - BulkMaterialType.DullCopper) : 0;

			if ( exceptional )
				typeIndex++;

			int gold = goldTable[typeIndex][quanIndex][mtrlIndex];

			int min = (gold * 9) / 10;
			int max = (gold * 10) / 9;

			return Utility.RandomMinMax( min, max );
		}

		public SmithRewardCalculator()
		{
			Groups = new RewardGroup[]
				{
					new RewardGroup(    0, new RewardItem( 1, SturdyShovel ) ),
					new RewardGroup(   25, new RewardItem( 1, SturdyPickaxe ) ),
					new RewardGroup(   50, new RewardItem( 45, SturdyShovel ), new RewardItem( 45, SturdyPickaxe ), new RewardItem( 10, MiningGloves, 1 ) ),
					new RewardGroup(  200, new RewardItem( 45, GargoylesPickaxe ), new RewardItem( 45, ProspectorsTool ), new RewardItem( 10, MiningGloves, 3 ) ),
					new RewardGroup(  400, new RewardItem( 2, GargoylesPickaxe ), new RewardItem( 2, ProspectorsTool ), new RewardItem( 1, PowderOfTemperament ) ),
					new RewardGroup(  450, new RewardItem( 9, PowderOfTemperament ), new RewardItem( 1, MiningGloves, 5 ) ),
					new RewardGroup(  500, new RewardItem( 1, RunicHammer, 1 ) ),
					new RewardGroup(  550, new RewardItem( 3, RunicHammer, 1 ), new RewardItem( 2, RunicHammer, 2 ) ),
					new RewardGroup(  600, new RewardItem( 1, RunicHammer, 2 ) ),
					new RewardGroup(  625, new RewardItem( 3, RunicHammer, 2 ), new RewardItem( 1, ColoredAnvil ) ),
					new RewardGroup(  650, new RewardItem( 1, RunicHammer, 3 ) ),
					new RewardGroup(  675, new RewardItem( 1, ColoredAnvil ), new RewardItem( 3, RunicHammer, 3 ) ),
					new RewardGroup(  700, new RewardItem( 1, RunicHammer, 4 ) ),
					new RewardGroup(  750, new RewardItem( 1, AncientHammer, 10 ) ),
					new RewardGroup(  800, new RewardItem( 1, RunicHammer, 4 ) ),
					new RewardGroup(  850, new RewardItem( 1, AncientHammer, 15 ) ),
					new RewardGroup(  900, new RewardItem( 1, RunicHammer, 4 ) ),
					new RewardGroup(  950, new RewardItem( 1, RunicHammer, 5 ) ),
					new RewardGroup( 1000, new RewardItem( 1, AncientHammer, 30 ) ),
					new RewardGroup( 1050, new RewardItem( 1, RunicHammer, 6 ) ),
					new RewardGroup( 1100, new RewardItem( 1, AncientHammer, 60 ) ),
					new RewardGroup( 1150, new RewardItem( 1, RunicHammer, 7 ) ),
					new RewardGroup( 1200, new RewardItem( 1, RunicHammer, 8 ) )
				};
		}
	}

	public sealed class TailorRewardCalculator : RewardCalculator
	{
		#region Constructors
		private static readonly ConstructCallback Cloth = new ConstructCallback( CreateCloth );
		private static readonly ConstructCallback Sandals = new ConstructCallback( CreateSandals );
		private static readonly ConstructCallback StretchedHide = new ConstructCallback( CreateStretchedHide );
		private static readonly ConstructCallback RunicKit = new ConstructCallback( CreateRunicKit );
		private static readonly ConstructCallback Tapestry = new ConstructCallback( CreateTapestry );
		private static readonly ConstructCallback PowerScroll = new ConstructCallback( CreatePowerScroll );
		private static readonly ConstructCallback BearRug = new ConstructCallback( CreateBearRug );
		private static readonly ConstructCallback ClothingBlessDeed = new ConstructCallback( CreateCBD );

		private static int[][] m_ClothHues = new int[][]
			{
				new int[]{ 0x483, 0x48C, 0x488, 0x48A },
				new int[]{ 0x495, 0x48B, 0x486, 0x485 },
				new int[]{ 0x48D, 0x490, 0x48E, 0x491 },
				new int[]{ 0x48F, 0x494, 0x484, 0x497 },
				new int[]{ 0x489, 0x47F, 0x482, 0x47E }
			};

		private static Item CreateCloth( int type )
		{
			if ( type >= 0 && type < m_ClothHues.Length )
			{
				UncutCloth cloth = new UncutCloth( 100 );
				cloth.Hue = m_ClothHues[type][Utility.Random( m_ClothHues[type].Length )];
				return cloth;
			}

			throw new InvalidOperationException();
		}

		private static int[] m_SandalHues = new int[]
			{
				0x489, 0x47F, 0x482,
				0x47E, 0x48F, 0x494,
				0x484, 0x497
			};

		private static Item CreateSandals( int type )
		{
			return new Sandals( m_SandalHues[Utility.Random( m_SandalHues.Length )] );
		}

		private static Item CreateStretchedHide( int type )
		{
			switch ( Utility.Random( 4 ) )
			{
				default:
				case 0:	return new SmallStretchedHideEastDeed();
				case 1: return new SmallStretchedHideSouthDeed();
				case 2: return new MediumStretchedHideEastDeed();
				case 3: return new MediumStretchedHideSouthDeed();
			}
		}

		private static Item CreateTapestry( int type )
		{
			switch ( Utility.Random( 4 ) )
			{
				default:
				case 0:	return new LightFlowerTapestryEastDeed();
				case 1: return new LightFlowerTapestrySouthDeed();
				case 2: return new DarkFlowerTapestryEastDeed();
				case 3: return new DarkFlowerTapestrySouthDeed();
			}
		}

		private static Item CreateBearRug( int type )
		{
			switch ( Utility.Random( 4 ) )
			{
				default:
				case 0:	return new BrownBearRugEastDeed();
				case 1: return new BrownBearRugSouthDeed();
				case 2: return new PolarBearRugEastDeed();
				case 3: return new PolarBearRugSouthDeed();
			}
		}

		private static Item CreateRunicKit( int type )
		{
			if ( type >= 1 && type <= 3 )
				return new RunicSewingKit( CraftResource.RegularLeather + type, 60 - (type*15) );

			throw new InvalidOperationException();
		}

		private static Item CreatePowerScroll( int type )
		{
			if ( type == 5 || type == 10 || type == 15 || type == 20 )
				return new PowerScroll( SkillName.Tailoring, 100 + type );

			throw new InvalidOperationException();
		}

		private static Item CreateCBD( int type )
		{
			return new ClothingBlessDeed();
		}
		#endregion

		public static readonly TailorRewardCalculator Instance = new TailorRewardCalculator();

		public override int ComputePoints( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type )
		{
			int points = 0;

			if ( quantity == 10 )
				points += 10;
			else if ( quantity == 15 )
				points += 25;
			else if ( quantity == 20 )
				points += 50;

			if ( exceptional )
				points += 100;

			if ( itemCount == 4 )
				points += 300;
			else if ( itemCount == 5 )
				points += 400;
			else if ( itemCount == 6 )
				points += 500;

			if ( material == BulkMaterialType.Spined )
				points += 50;
			else if ( material == BulkMaterialType.Horned )
				points += 100;
			else if ( material == BulkMaterialType.Barbed )
				points += 150;

			return points;
		}

		private static int[][][] m_AosGoldTable = new int[][][]
			{
				new int[][] // 1-part (regular)
				{
					new int[]{ 1000, 2000, 3000, 4000 },
					new int[]{ 5000, 6000, 7000, 8000 },
					new int[]{ 9000, 10000, 11000, 12000 }
				},
				new int[][] // 1-part (exceptional)
				{
					new int[]{ 2000, 4000, 6000, 8000 },
					new int[]{ 10000, 12000, 14000, 16000 },
					new int[]{ 18000, 20000, 22000, 24000 }
				},
				new int[][] // 4-part (regular)
				{
					new int[]{  4000,  4000,  5000,  5000 },
					new int[]{  6000,  6000,  7500,  7500 },
					new int[]{  8000, 10000, 10000, 15000 }
				},
				new int[][] // 4-part (exceptional)
				{
					new int[]{  5000,  5000,  7500,  7500 },
					new int[]{  7500,  7500, 11250, 11250 },
					new int[]{ 10000, 15000, 15000, 20000 }
				},
				new int[][] // 5-part (regular)
				{
					new int[]{  5000,  5000,  7500,  7500 },
					new int[]{  7500,  7500, 11250, 11250 },
					new int[]{ 10000, 15000, 15000, 20000 }
				},
				new int[][] // 5-part (exceptional)
				{
					new int[]{  7500,  7500, 10000, 10000 },
					new int[]{ 11250, 11250, 15000, 15000 },
					new int[]{ 15000, 20000, 20000, 30000 }
				},
				new int[][] // 6-part (regular)
				{
					new int[]{  7500,  7500, 10000, 10000 },
					new int[]{ 11250, 11250, 15000, 15000 },
					new int[]{ 15000, 20000, 20000, 30000 }
				},
				new int[][] // 6-part (exceptional)
				{
					new int[]{ 10000, 10000, 15000, 15000 },
					new int[]{ 15000, 15000, 22500, 22500 },
					new int[]{ 20000, 30000, 30000, 50000 }
				}
			};

		private static int[][][] m_OldGoldTable = new int[][][]
			{
				new int[][] // 1-part (regular)
				{
					new int[]{ 150, 150, 300, 300 },
					new int[]{ 225, 225, 450, 450 },
					new int[]{ 300, 400, 600, 750 }
				},
				new int[][] // 1-part (exceptional)
				{
					new int[]{ 300, 300,  600,  600 },
					new int[]{ 450, 450,  900,  900 },
					new int[]{ 600, 750, 1200, 1800 }
				},
				new int[][] // 4-part (regular)
				{
					new int[]{  3000,  3000,  4000,  4000 },
					new int[]{  4500,  4500,  6000,  6000 },
					new int[]{  6000,  8000,  8000, 10000 }
				},
				new int[][] // 4-part (exceptional)
				{
					new int[]{  4000,  4000,  5000,  5000 },
					new int[]{  6000,  6000,  7500,  7500 },
					new int[]{  8000, 10000, 10000, 15000 }
				},
				new int[][] // 5-part (regular)
				{
					new int[]{  4000,  4000,  5000,  5000 },
					new int[]{  6000,  6000,  7500,  7500 },
					new int[]{  8000, 10000, 10000, 15000 }
				},
				new int[][] // 5-part (exceptional)
				{
					new int[]{  5000,  5000,  7500,  7500 },
					new int[]{  7500,  7500, 11250, 11250 },
					new int[]{ 10000, 15000, 15000, 20000 }
				},
				new int[][] // 6-part (regular)
				{
					new int[]{  5000,  5000,  7500,  7500 },
					new int[]{  7500,  7500, 11250, 11250 },
					new int[]{ 10000, 15000, 15000, 20000 }
				},
				new int[][] // 6-part (exceptional)
				{
					new int[]{  7500,  7500, 10000, 10000 },
					new int[]{ 11250, 11250, 15000, 15000 },
					new int[]{ 15000, 20000, 20000, 30000 }
				}
			};

		public override int ComputeGold( int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type )
		{
			int[][][] goldTable = ( Core.AOS ? m_AosGoldTable : m_OldGoldTable );

			int typeIndex = (( itemCount == 6 ? 3 : itemCount == 5 ? 2 : itemCount == 4 ? 1 : 0 ) * 2) + (exceptional ? 1 : 0);
			int quanIndex = ( quantity == 20 ? 2 : quantity == 15 ? 1 : 0 );
			int mtrlIndex = ( material == BulkMaterialType.Barbed ? 3 : material == BulkMaterialType.Horned ? 2 : material == BulkMaterialType.Spined ? 1 : 0 );

			int gold = goldTable[typeIndex][quanIndex][mtrlIndex];

			int min = (gold * 9) / 10;
			int max = (gold * 10) / 9;

			return Utility.RandomMinMax( min, max );
		}

		public TailorRewardCalculator()
		{
			Groups = new RewardGroup[]
				{
					new RewardGroup(   0, new RewardItem( 1, Cloth, 0 ) ),
					new RewardGroup(  50, new RewardItem( 1, Cloth, 1 ) ),
					new RewardGroup( 100, new RewardItem( 1, Cloth, 2 ) ),
					new RewardGroup( 150, new RewardItem( 9, Cloth, 3 ), new RewardItem( 1, Sandals ) ),
					new RewardGroup( 200, new RewardItem( 4, Cloth, 4 ), new RewardItem( 1, Sandals ) ),
					new RewardGroup( 300, new RewardItem( 1, StretchedHide ) ),
					new RewardGroup( 350, new RewardItem( 1, RunicKit, 1 ) ),
					new RewardGroup( 400, new RewardItem( 2, RunicKit, 1 ), new RewardItem( 3, Tapestry ) ),
					new RewardGroup( 450, new RewardItem( 1, BearRug ) ),
					new RewardGroup( 500, new RewardItem( 1, RunicKit, 1 ) ),
					new RewardGroup( 550, new RewardItem( 1, ClothingBlessDeed ) ),
					new RewardGroup( 575, new RewardItem( 1, RunicKit, 2 ) ),
					new RewardGroup( 600, new RewardItem( 1, RunicKit, 2 ) ),
					new RewardGroup( 650, new RewardItem( 1, RunicKit, 3 ) ),
					new RewardGroup( 700, new RewardItem( 1, RunicKit, 3 ) )
				};
		}
    }

    #region Carpentry Rewards
    public sealed class CarpentryRewardCalculator : RewardCalculator
    {
        public CarpentryRewardCalculator()
        {
		Groups = new RewardGroup[]
		{
			new RewardGroup(   0, new RewardItem( 1, DovetailSaw, 1 ) )
		};
        }

        #region Constructors

        private static Item DovetailSaw(int type)
        {
            BaseTool tool = new DovetailSaw();
            tool.UsesRemaining = 250;

            return tool;
        }
        #endregion

        public static readonly CarpentryRewardCalculator Instance = new CarpentryRewardCalculator();

        public override int ComputePoints(int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type)
        {
            int points = 0;

            if (quantity == 10)
                points += 10;
            else if (quantity == 15)
                points += 25;
            else if (quantity == 20)
                points += 50;

            if (exceptional)
                points += 200;

            switch (material)
            {
                case BulkMaterialType.None: break;
                case BulkMaterialType.OakWood: points += 300;  break;
                case BulkMaterialType.AshWood: points += 350; break;
                case BulkMaterialType.YewWood: points += 400; break;
                case BulkMaterialType.Heartwood: points += 450; break;
                case BulkMaterialType.Bloodwood: points += 500; break;
                case BulkMaterialType.Frostwood: points += 550; break;
            }

            if (itemCount > 1)
                points += this.LookupTypePoints(m_Types, type);

            return points;
        }

        private RewardType[] m_Types =
        {
            new RewardType(250, typeof(TallCabinet), typeof(ShortCabinet)),
            new RewardType(250, typeof(RedArmoire), typeof(ElegantArmoire), typeof(MapleArmoire), typeof(CherryArmoire)),
            new RewardType(300, typeof(PlainWoodenChest), typeof(OrnateWoodenChest), typeof(GildedWoodenChest), typeof(WoodenFootLocker), typeof(FinishedWoodenChest)),
            new RewardType(350, typeof(WildStaff), typeof(ArcanistsWildStaff), typeof(AncientWildStaff), typeof(ThornedWildStaff), typeof(HardenedWildStaff)),
            new RewardType(250, typeof(LapHarp), typeof(Lute), typeof(Drums), typeof(Harp)),
            new RewardType(200, typeof(GnarledStaff), typeof(QuarterStaff), typeof(ShepherdsCrook), typeof(Tetsubo), typeof(Bokuto)),
            new RewardType(300, typeof(WoodenBox), typeof(EmptyBookcase), typeof(WoodenBench), typeof(WoodenThrone)),
        };

        private static readonly int[][][] m_GoldTable = new int[][][]
        {
            new int[][] // 1-part (regular)
            {
                new int[] { 1500, 1500, 2250, 2250, 3000, 3000 },
                new int[] { 2250, 2250, 3250, 3250, 4500, 4500 },
                new int[] { 3000, 4000, 5000, 5000, 6000, 7500 }
            },
            new int[][] // 1-part (exceptional)
            {
                new int[] { 3000, 3000, 4000, 5000, 6000, 6000 },
                new int[] { 4500, 4500, 6500, 7500, 9000, 9000 },
                new int[] { 6000, 7500, 8500, 10000, 12000, 18000 }
            },
            new int[][] // 2-part (regular)
            {
                new int[] { 2000, 2000, 2000, 2500, 2500, 2500 },
                new int[] { 3000, 3000, 3000, 3750, 3750, 3750 },
                new int[] { 4000, 4500, 4500, 5000, 5000, 7500 }
            },
            new int[][] // 2-part (exceptional)
            {
                new int[] { 2500, 2500, 3000, 3350, 3350, 4000 },
                new int[] { 3750, 3750, 4250, 4750, 5200, 5200 },
                new int[] { 5000, 6100, 6100, 7000, 7000, 10000 }
            },
            new int[][] // 4-part (regular)
            {
                new int[] { 4000, 4000, 4000, 5000, 5000, 5000 },
                new int[] { 6000, 6000, 6000, 7500, 7500, 7500 },
                new int[] { 8000, 9000, 9500, 10000, 10000, 15000 }
            },
            new int[][] // 4-part (exceptional)
            {
                new int[] { 5000, 5000, 6000, 6750, 7500, 7500 },
                new int[] { 7500, 7500, 8500, 9500, 11250, 11250 },
                new int[] { 10000, 1250, 1250, 15000, 15000, 20000 }
            },
            new int[][] // 5-part (regular)
            {
                new int[] { 5000, 5000, 60000, 6000, 7500, 7500 },
                new int[] { 7500, 7500, 7500, 11250, 11250, 11250 },
                new int[] { 10000, 10000, 1250, 15000, 15000, 20000 }
            },
            new int[][] // 5-part (exceptional)
            {
                new int[] { 7500, 7500, 8500, 9500, 10000, 10000 },
                new int[] { 11250, 11250, 1250, 1350, 15000, 15000 },
                new int[] { 15000, 1750, 1750, 20000, 20000, 30000 }
            },
        };

        public override int ComputeGold(int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type)
        {
            int[][][] goldTable = m_GoldTable;

            int typeIndex = ((itemCount == 5 ? 2 : itemCount == 4 ? 1 : 0) * 2) + (exceptional ? 1 : 0);
            int quanIndex = (quantity == 20 ? 2 : quantity == 15 ? 1 : 0);
            int mtrlIndex = (material == BulkMaterialType.Frostwood ? 5 : material == BulkMaterialType.Bloodwood ? 4 : material == BulkMaterialType.Heartwood ? 3 : material == BulkMaterialType.YewWood ? 2 : material == BulkMaterialType.AshWood ? 1 : 0);

            int gold = goldTable[typeIndex][quanIndex][mtrlIndex];

            int min = (gold * 9) / 10;
            int max = (gold * 10) / 9;

            return Utility.RandomMinMax(min, max);
        }
    }
    #endregion

    #region Inscription Rewards
    public sealed class InscriptionRewardCalculator : RewardCalculator
    {
        public InscriptionRewardCalculator()
        {
		Groups = new RewardGroup[]
		{
			new RewardGroup(   0, new RewardItem( 1, ScribesPen, 1 ) )
		};
        }

        #region Constructors

        private static Item ScribesPen(int type)
        {
            BaseTool tool = new ScribesPen();
            tool.UsesRemaining = 250;

            return tool;
        }

        #endregion

        public static readonly InscriptionRewardCalculator Instance = new InscriptionRewardCalculator();

        public override int ComputePoints(int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type)
        {
            int points = 0;

            if (quantity == 10)
                points += 10;
            else if (quantity == 15)
                points += 25;
            else if (quantity == 20)
                points += 50;

            if (itemCount > 1)
                points += this.LookupTypePoints(m_Types, type);

            return points;
        }

        private RewardType[] m_Types =
        {
            new RewardType(200, typeof(ClumsyScroll), typeof(FeeblemindScroll), typeof(WeakenScroll)),
            new RewardType(300, typeof(CurseScroll), typeof(GreaterHealScroll), typeof(RecallScroll)),
            new RewardType(300, typeof(PoisonStrikeScroll), typeof(WitherScroll), typeof(StrangleScroll)),
            new RewardType(250, typeof(MindRotScroll), typeof(SummonFamiliarScroll), typeof(AnimateDeadScroll), typeof(HorrificBeastScroll)),
            new RewardType(200, typeof(HealScroll), typeof(AgilityScroll), typeof(CunningScroll), typeof(CureScroll), typeof(StrengthScroll)),
            new RewardType(250, typeof(BloodOathScroll), typeof(CorpseSkinScroll), typeof(CurseWeaponScroll), typeof(EvilOmenScroll), typeof(PainSpikeScroll)),
            new RewardType(300, typeof(BladeSpiritsScroll), typeof(DispelFieldScroll), typeof(MagicReflectScroll), typeof(ParalyzeScroll), typeof(SummonCreatureScroll)),
            new RewardType(350, typeof(ChainLightningScroll), typeof(FlamestrikeScroll), typeof(ManaVampireScroll), typeof(MeteorSwarmScroll), typeof(PolymorphScroll)),
            new RewardType(400, typeof(SummonAirElementalScroll), typeof(SummonDaemonScroll), typeof(SummonEarthElementalScroll), typeof(SummonFireElementalScroll), typeof(SummonWaterElementalScroll)),
            new RewardType(450, typeof(Spellbook), typeof(NecromancerSpellbook), typeof(Runebook))
        };

        private static readonly int[][] m_GoldTable = new int[][]
        {
            new int[] // singles
            {
                1500, 2250, 3000
            },
            new int[] // no 2 piece
            {
            },
            new int[] // 3-part
            {
                4000, 6000, 8000
            },
            new int[] // 4-part
            {
                5000, 7500, 10000
            },
            new int[] // 5-part
            {
                7500, 11250, 15000
            },
        };

        public override int ComputeGold(int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type)
        {
            int[][] goldTable = m_GoldTable;

            int quanIndex = (quantity == 20 ? 2 : quantity == 15 ? 1 : 0);

            int gold = goldTable[itemCount - 1][quanIndex];

            int min = (gold * 9) / 10;
            int max = (gold * 10) / 9;

            return Utility.RandomMinMax(min, max);
        }
    }
    #endregion

    #region Cooking Rewards
    public sealed class CookingRewardCalculator : RewardCalculator
    {
        public CookingRewardCalculator()
        {
		Groups = new RewardGroup[]
		{
			new RewardGroup(   0, new RewardItem( 1, Skillet, 1 ) )
		};
        }

        #region Constructors

        private static Item Skillet(int type)
        {
            BaseTool tool = new Skillet();
            tool.UsesRemaining = 250;

            return tool;
        }

        #endregion

        public static readonly CookingRewardCalculator Instance = new CookingRewardCalculator();

        public override int ComputePoints(int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type)
        {
            int points = 0;

            if (quantity == 10)
                points += 10;
            else if (quantity == 15)
                points += 25;
            else if (quantity == 20)
                points += 50;

            if (exceptional)
                points += 200;

            if (itemCount > 1)
                points += this.LookupTypePoints(m_Types, type);

            return points;
        }

        private RewardType[] m_Types =
        {
            new RewardType(200, typeof(SackFlour), typeof(Dough)),
            new RewardType(250, typeof(UnbakedFruitPie), typeof(UnbakedPeachCobbler), typeof(UnbakedApplePie), typeof(UnbakedPumpkinPie)),
            new RewardType(300, typeof(CookedBird), typeof(FishSteak), typeof(FriedEggs), typeof(LambLeg), typeof(Ribs)),
            new RewardType(350, typeof(Cookies), typeof(Cake), typeof(Muffins)),
            new RewardType(400, typeof(TribalPaint), typeof(EggBomb)),
            new RewardType(450, typeof(MisoSoup), typeof(WhiteMisoSoup), typeof(RedMisoSoup), typeof(AwaseMisoSoup)),
            new RewardType(500, typeof(WasabiClumps), typeof(SushiRolls), typeof(SushiPlatter), typeof(GreenTea)),
        };

        private static readonly int[][] m_GoldTable = new int[][]
        {
            new int[] // singles
            {
                1500, 2250, 3000
            },
            new int[] // no 2 piece
            {
            },
            new int[] // 3-part
            {
                4000, 6000, 8000
            },
            new int[] // 4-part
            {
                5000, 7500, 10000
            },
            new int[] // 5-part
            {
                7500, 11250, 15000
            },
            new int[] // 6-part (regular)
            {
                7500, 11250, 15000
            },
        };

        public override int ComputeGold(int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type)
        {
            int[][] goldTable = m_GoldTable;

            int quanIndex = (quantity == 20 ? 2 : quantity == 15 ? 1 : 0);

            int gold = goldTable[itemCount - 1][quanIndex];

            int min = (gold * 9) / 10;
            int max = (gold * 10) / 9;

            return Utility.RandomMinMax(min, max);
        }
    }
    #endregion

    #region Fletching Rewards
    public sealed class FletchingRewardCalculator : RewardCalculator
    {
        public FletchingRewardCalculator()
        {
		Groups = new RewardGroup[]
		{
			new RewardGroup(   0, new RewardItem( 1, FletcherTools, 1 ) )
		};
        }

        #region Constructors

        private static Item FletcherTools(int type)
        {
            BaseTool tool = new FletcherTools();
            tool.UsesRemaining = 250;

            return tool;
        }
        #endregion

        public static readonly FletchingRewardCalculator Instance = new FletchingRewardCalculator();

        public override int ComputePoints(int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type)
        {
            int points = 0;

            if (quantity == 10)
                points += 10;
            else if (quantity == 15)
                points += 25;
            else if (quantity == 20)
                points += 50;

            if (exceptional)
                points += 200;

            switch (material)
            {
                case BulkMaterialType.None: break;
                case BulkMaterialType.OakWood: points += 300; break;
                case BulkMaterialType.AshWood: points += 350; break;
                case BulkMaterialType.YewWood: points += 400; break;
                case BulkMaterialType.Heartwood: points += 450; break;
                case BulkMaterialType.Bloodwood: points += 500; break;
                case BulkMaterialType.Frostwood: points += 550; break;
            }

            if (itemCount > 1)
                points += this.LookupTypePoints(m_Types, type);

            return points;
        }

        private RewardType[] m_Types =
        {
            new RewardType(200, typeof(Arrow), typeof(Bolt)),
            new RewardType(300, typeof(Bow), typeof(CompositeBow), typeof(Yumi)),
            new RewardType(300, typeof(Crossbow), typeof(HeavyCrossbow), typeof(RepeatingCrossbow)),
            new RewardType(350, typeof(MagicalShortbow), typeof(RangersShortbow), typeof(LightweightShortbow), typeof(MysticalShortbow), typeof(AssassinsShortbow)),
            new RewardType(250, typeof(ElvenCompositeLongbow), typeof(BarbedLongbow), typeof(SlayerLongbow), typeof(FrozenLongbow), typeof(LongbowOfMight)),
        };

        private static readonly int[][][] m_GoldTable = new int[][][]
        {
            new int[][] // 1-part (regular)
            {
                new int[] { 1500, 1500, 2250, 2250, 3000, 3000 },
                new int[] { 2250, 2250, 3250, 3250, 4500, 4500 },
                new int[] { 3000, 4000, 5000, 5000, 6000, 7500 }
            },
            new int[][] // 1-part (exceptional)
            {
                new int[] { 3000, 3000, 4000, 5000, 6000, 6000 },
                new int[] { 4500, 4500, 6500, 7500, 9000, 9000 },
                new int[] { 6000, 7500, 8500, 10000, 12000, 18000 }
            },
            new int[][] // 4-part (regular)
            {
                new int[] { 4000, 4000, 4000, 5000, 5000, 5000 },
                new int[] { 6000, 6000, 6000, 7500, 7500, 7500 },
                new int[] { 8000, 9000, 9500, 10000, 10000, 15000 }
            },
            new int[][] // 4-part (exceptional)
            {
                new int[] { 5000, 5000, 6000, 6750, 7500, 7500 },
                new int[] { 7500, 7500, 8500, 9500, 11250, 11250 },
                new int[] { 10000, 1250, 1250, 15000, 15000, 20000 }
            },
            new int[][] // 5-part (regular)
            {
                new int[] { 5000, 5000, 60000, 6000, 7500, 7500 },
                new int[] { 7500, 7500, 7500, 11250, 11250, 11250 },
                new int[] { 10000, 10000, 1250, 15000, 15000, 20000 }
            },
            new int[][] // 5-part (exceptional)
            {
                new int[] { 7500, 7500, 8500, 9500, 10000, 10000 },
                new int[] { 11250, 11250, 1250, 1350, 15000, 15000 },
                new int[] { 15000, 1750, 1750, 20000, 20000, 30000 }
            },
        };

        public override int ComputeGold(int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type)
        {
            int[][][] goldTable = m_GoldTable;

            int typeIndex = ((itemCount == 5 ? 2 : itemCount == 4 ? 1 : 0) * 2) + (exceptional ? 1 : 0);
            int quanIndex = (quantity == 20 ? 2 : quantity == 15 ? 1 : 0);
            int mtrlIndex = (material == BulkMaterialType.Frostwood ? 5 : material == BulkMaterialType.Bloodwood ? 4 : material == BulkMaterialType.Heartwood ? 3 : material == BulkMaterialType.YewWood ? 2 : material == BulkMaterialType.AshWood ? 1 : 0);

            int gold = goldTable[typeIndex][quanIndex][mtrlIndex];

            int min = (gold * 9) / 10;
            int max = (gold * 10) / 9;

            return Utility.RandomMinMax(min, max);
        }
    }
    #endregion

    #region Alchemy Rewards
    public sealed class AlchemyRewardCalculator : RewardCalculator
    {
        public AlchemyRewardCalculator()
        {
		Groups = new RewardGroup[]
		{
			new RewardGroup(   0, new RewardItem( 1, MortarAndPestle, 1 ) )
		};
        }

        #region Constructors
        private static Item MortarAndPestle(int type)
        {
            BaseTool tool = new MortarPestle();
            tool.UsesRemaining = 250;

            return tool;
        }
        #endregion

        public static readonly AlchemyRewardCalculator Instance = new AlchemyRewardCalculator();

        public override int ComputePoints(int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type)
        {
            int points = 0;

            if (quantity == 10)
                points += 10;
            else if (quantity == 15)
                points += 25;
            else if (quantity == 20)
                points += 50;

            if (itemCount == 3)
            {
                if(type == typeof(RefreshPotion) || type == typeof(HealPotion) || type == typeof(CurePotion))
                    points += 250;
                else
                    points += 300;
            }
            else if (itemCount == 4)
                points += 200;
            else if (itemCount == 5)
                points += 400;
            else if (itemCount == 6)
                points += 350;

            return points;
        }

        private static readonly int[][] m_GoldTable = new int[][]
        {
            new int[] // singles
            {
                1500, 2250, 3000
            },
            new int[] // no 2 piece
            {
            },
            new int[] // 3-part
            {
                4000, 6000, 8000
            },
            new int[] // 4-part
            {
                5000, 7500, 10000
            },
            new int[] // 5-part
            {
                7500, 11250, 15000
            },
            new int[] // 6-part (regular)
            {
                7500, 11250, 15000
            },
        };

        public override int ComputeGold(int quantity, bool exceptional, BulkMaterialType material, int itemCount, Type type)
        {
            int[][] goldTable = m_GoldTable;

            int quanIndex = (quantity == 20 ? 2 : quantity == 15 ? 1 : 0);

            int gold = goldTable[itemCount - 1][quanIndex];

            int min = (gold * 9) / 10;
            int max = (gold * 10) / 9;

            return Utility.RandomMinMax(min, max);
        }
    }
    #endregion


}