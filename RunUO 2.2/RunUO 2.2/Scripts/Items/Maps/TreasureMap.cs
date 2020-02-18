using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Regions;
using Server.Targeting;
using Server.ContextMenus;
using Server.Items;

namespace Server.Items
{
	public class TreasureMap : MapItem
	{
        private DateTime m_Found;

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime Found
        {
            get { return m_Found; }
            set { m_Found = value; InvalidateProperties(); }
        }

		private int m_Level;
		private bool m_Completed;
		private Mobile m_CompletedBy;
		private Mobile m_Decoder;
		private Map m_Map;
		private Point2D m_Location;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Level{ get{ return m_Level; } set{ m_Level = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public bool Completed{ get{ return m_Completed; } set{ m_Completed = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile CompletedBy{ get{ return m_CompletedBy; } set{ m_CompletedBy = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Decoder{ get{ return m_Decoder; } set{ m_Decoder = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public Map ChestMap{ get{ return m_Map; } set{ m_Map = value; InvalidateProperties(); } }

		[CommandProperty( AccessLevel.GameMaster )]
        public Point2D ChestLocation { get { return m_Location; } set { m_Location = value; InvalidateProperties(); } }

		private static Point2D[] m_Locations;
		private static Point2D[] m_HavenLocations;

		private static Type[][] m_DefaultSpawns = new Type[][]
		{
			new Type[]{ typeof( HeadlessOne ), typeof( Skeleton ) },
			new Type[]{ typeof( Mongbat ), typeof( Ratman ), typeof( HeadlessOne ), typeof( Skeleton ), typeof( Zombie ) },
			new Type[]{ typeof( OrcishMage ), typeof( Gargoyle ), typeof( Gazer ), typeof( HellHound ), typeof( EarthElemental ) },
			new Type[]{ typeof( Lich ), typeof( OgreLord ), typeof( DreadSpider ), typeof( AirElemental ), typeof( FireElemental ) },
			new Type[]{ typeof( DreadSpider ), typeof( LichLord ), typeof( Daemon ), typeof( ElderGazer ), typeof( OgreLord ) },
			new Type[]{ typeof( LichLord ), typeof( Daemon ), typeof( ElderGazer ), typeof( PoisonElemental ), typeof( BloodElemental ) },
			new Type[]{ typeof( AncientWyrm ), typeof( Balron ), typeof( BloodElemental ), typeof( PoisonElemental ), typeof( Titan ), typeof( ColdDrake ) },
            new Type[]{ typeof( AncientWyrm ), typeof( Balron ), typeof( BloodElemental ), typeof( PoisonElemental ), typeof( GreaterDragon ), typeof( ColdDrake ), typeof( FrostDragon ) }
		};
		private static Type[][] m_IlshenarSpawns = new Type[][]
		{
			new Type[]{ typeof( HeadlessOne ), typeof( Skeleton ) },
			new Type[]{ typeof( Mongbat ), typeof( Ratman ), typeof( HeadlessOne ), typeof( Skeleton ), typeof( Zombie ), typeof( Orc ) },
			new Type[]{ typeof( RatmanMage ), typeof( EnslavedGargoyle ), typeof( Gazer ), typeof( Imp ), typeof( EarthElemental ), typeof( Troll ), typeof( Ettin ), typeof( Doppleganger ) },
			new Type[]{ typeof( Lich ), typeof( OgreLord ), typeof( DreadSpider ), typeof( AirElemental ), typeof( FireElemental ), typeof( ArcaneDaemon ), typeof( ArcaneDaemon ), typeof( ChaosDaemon ), typeof( ChaosDaemon ) },
			new Type[]{ typeof( ExodusOverseer ), typeof( LichLord ), typeof( Daemon ), typeof( ElderGazer ), typeof( OgreLord ), typeof( BloodElemental ), typeof( Golem ), typeof( Moloch ) },
			new Type[]{ typeof( PoisonElemental ), typeof( GargoyleDestroyer ), typeof( GargoyleEnforcer ), typeof( ExodusMinion ), typeof( LichLord ) },
			new Type[]{ typeof( ExodusMinion ), typeof( GargoyleDestroyer ), typeof( Changeling ), typeof( ColdDrake ), typeof( Titan ) },
            new Type[]{ typeof( ExodusMinion ), typeof( GargoyleDestroyer ), typeof( Balron ), typeof( Titan ), typeof( RenegadeChangeling ) }
		};
		private static Type[][] m_MalasSpawns = new Type[][]
		{
			new Type[]{ typeof( HeadlessOne ), typeof( Skeleton ) },
			new Type[]{ typeof( VampireBat ), typeof( PatchworkSkeleton ), typeof( MoundOfMaggots ), typeof( Skeleton ), typeof( Zombie ), typeof( RestlessSoul ) },
			new Type[]{ typeof( SkeletalMage ), typeof( BoneMagi ), typeof( WailingBanshee ), typeof( GoreFiend ), typeof( FleshGolem ), typeof( Gibberling ) },
			new Type[]{ typeof( Lich ), typeof( SkeletalKnight ), typeof( BoneKnight ), typeof( Ravager ), typeof( CrystalElemental ), typeof( FleshGolem ) },
			new Type[]{ typeof( CrystalElemental ), typeof( LichLord ), typeof( OrcBrute ), typeof( Ravager ), typeof( Devourer ) },
			new Type[]{ typeof( WandererOfTheVoid ), typeof( Ravager ), typeof( LichLord ), typeof( Devourer ), typeof( OrcBrute ), typeof( Minotaur ), typeof( InterredGrizzle ) },
            new Type[]{ typeof( Devourer ), typeof( RottingCorpse ), typeof( WandererOfTheVoid ), typeof( MinotaurCaptain ), typeof( MinotaurScout ) },
            new Type[]{ typeof( Devourer ), typeof( RottingCorpse ), typeof( WandererOfTheVoid ), typeof( MinotaurCaptain ), typeof( MinotaurScout ), typeof( SkeletalDragon ), typeof( InterredGrizzle ) }
        };
		private static Type[][] m_TokunoSpawns = new Type[][]
		{
			new Type[]{ typeof( HeadlessOne ), typeof( HordeMinion ), typeof( Skeleton ), typeof( Zombie ) },
			new Type[]{ typeof( HordeMinion ), typeof( DeathwatchBeetleHatchling ), typeof( HeadlessOne ), typeof( Skeleton ), typeof( Zombie ) },
			new Type[]{ typeof( BoneMagi ), typeof( SkeletalMage ), typeof( Kappa ), typeof( HellHound ), typeof( DeathwatchBeetle ), typeof( EvilMage ) },
			new Type[]{ typeof( Kappa ), typeof( KazeKemono ), typeof( DreadSpider ), typeof( DeathwatchBeetle ), typeof( EvilMageLord ) },
			new Type[]{ typeof( TsukiWolf ), typeof( RaiJu ), typeof( Daemon ), typeof( RevenantLion ), typeof( KazeKemono ), typeof( YomotsuWarrior ) },
			new Type[]{ typeof( RuneBeetle ), typeof( RevenantLion ), typeof( Ronin ), typeof( FanDancer ), typeof( YomotsuWarrior ), typeof( KazeKemono ), typeof( LesserHiryu ), typeof( RaiJu ) },
			new Type[]{ typeof( RuneBeetle ), typeof( LadyOfTheSnow ), typeof( YomotsuElder ), typeof( YomotsuPriest ), typeof( YomotsuWarrior ), typeof( Hiryu ), typeof( Oni ) },
			new Type[]{ typeof( RuneBeetle ), typeof( LadyOfTheSnow ), typeof( YomotsuElder ), typeof( YomotsuPriest ), typeof( YomotsuWarrior ), typeof( Hiryu ), typeof( Oni ), typeof( Yamandon ) }
        };
		private static Type[][] m_TerMurSpawns = new Type[][]
		{
			new Type[]{ typeof( HeadlessOne ), typeof( Skeleton ) },
			new Type[]{ typeof( Mongbat ), typeof( Ratman ), typeof( HeadlessOne ), typeof( Skeleton ), typeof( Zombie ), typeof( Orc ) },
			new Type[]{ typeof( RatmanMage ), typeof( EnslavedGargoyle ), typeof( Gazer ), typeof( Imp ), typeof( EarthElemental ), typeof( Troll ), typeof( Ettin ), typeof( Doppleganger ) },
			new Type[]{ typeof( Lich ), typeof( OgreLord ), typeof( DreadSpider ), typeof( AirElemental ), typeof( FireElemental ), typeof( ArcaneDaemon ), typeof( ArcaneDaemon ), typeof( ChaosDaemon ), typeof( ChaosDaemon ) },
			new Type[]{ typeof( ExodusOverseer ), typeof( LichLord ), typeof( Daemon ), typeof( ElderGazer ), typeof( OgreLord ), typeof( BloodElemental ), typeof( Golem ), typeof( Moloch ) },
			new Type[]{ typeof( PoisonElemental ), typeof( GargoyleDestroyer ), typeof( GargoyleEnforcer ), typeof( ExodusMinion ), typeof( LichLord ) },
			new Type[]{ typeof( ExodusMinion ), typeof( GargoyleDestroyer ), typeof( Changeling ), typeof( ColdDrake ), typeof( Titan ) },
            new Type[]{ typeof( ExodusMinion ), typeof( GargoyleDestroyer ), typeof( Balron ), typeof( Titan ), typeof( RenegadeChangeling ) }
		};

		public const double LootChance = 0.01; // 1% chance to appear as loot

        public static Point2D GetRandomLocation(Map t_map)
        {
            bool LandOk = true;

            int tx = 0, ty = 0, tz = 0;

            for (int tm = 0; tm < 10; ++tm)
            {
                if (t_map == Map.Trammel || t_map == Map.Felucca)
                {
                    tx = Utility.Random(4080) + 1;
                    ty = Utility.Random(5100) + 1;
                    tz = t_map.GetAverageZ(tx, ty);
                }
                else if (t_map == Map.Ilshenar)
                {
                    tx = Utility.Random(1550) + 221;
                    ty = Utility.Random(1215) + 200;
                    tz = t_map.GetAverageZ(tx, ty);
                }
                else if (t_map == Map.Malas)
                {
                    tx = Utility.Random(1550) + 601;
                    ty = Utility.Random(1840) + 71;
                    tz = t_map.GetAverageZ(tx, ty);
                }
                else if (t_map == Map.Tokuno)
                {
                    tx = Utility.Random(1320) + 91;
                    ty = Utility.Random(1380) + 21;
                    tz = t_map.GetAverageZ(tx, ty);
                }
                else if (t_map == Map.TerMur)
                {
                    tx = Utility.Random(920) + 301;
                    ty = Utility.Random(1250) + 2800;
                    tz = t_map.GetAverageZ(tx, ty);
                }

                LandTile t = t_map.Tiles.GetLandTile(tx, ty);
                LandOk = true;

                if (t.ID == 1) { LandOk = false; }
                if (t.ID >= 26 && t.ID <= 50) { LandOk = false; }
                if (t.ID >= 68 && t.ID <= 111) { LandOk = false; }
                if (t.ID >= 141 && t.ID <= 171) { LandOk = false; }
                if (t.ID >= 220 && t.ID <= 231) { LandOk = false; }
                if (t.ID >= 236 && t.ID <= 239) { LandOk = false; }
                if (t.ID >= 244 && t.ID <= 247) { LandOk = false; }
                if (t.ID >= 252 && t.ID <= 255) { LandOk = false; }
                if (t.ID >= 260 && t.ID <= 263) { LandOk = false; }
                if (t.ID >= 268 && t.ID <= 279) { LandOk = false; }
                if (t.ID >= 286 && t.ID <= 297) { LandOk = false; }
                if (t.ID >= 302 && t.ID <= 324) { LandOk = false; }
                if (t.ID >= 380 && t.ID <= 394) { LandOk = false; }
                if (t.ID >= 441 && t.ID <= 475) { LandOk = false; }
                if (t.ID >= 500 && t.ID <= 580) { LandOk = false; }
                if (t.ID >= 586 && t.ID <= 621) { LandOk = false; }
                if (t.ID >= 662 && t.ID <= 799) { LandOk = false; }
                if (t.ID >= 1001 && t.ID <= 1308) { LandOk = false; }
                if (t.ID >= 1325 && t.ID <= 1340) { LandOk = false; }
                if (t.ID >= 1367 && t.ID <= 1378) { LandOk = false; }
                if (t.ID >= 1661 && t.ID <= 1696) { LandOk = false; }
                if (t.ID >= 1741 && t.ID <= 1757) { LandOk = false; }
                if (t.ID >= 1771 && t.ID <= 2495) { LandOk = false; }
                if (t.ID >= 2540) { LandOk = false; }
                if (t.ID == 16374 || t.ID == 16380 || t.ID == 16381 || t.ID == 16382 || t.ID == 16383) { LandOk = true; }

                Mobile mSp = new Rat();
                mSp.Name = "Gerald the Amazing Treasure Locating Rat";
                mSp.MoveToWorld(new Point3D(tx, ty, tz), t_map);
                Region RatReg = mSp.Region;
                mSp.Delete();

                if (LandOk && t_map.CanSpawnMobile(tx, ty, tz) && !RatReg.IsPartOf(typeof(Regions.GuardedRegion)))
                {
                    return (new Point2D(tx, ty));
                }
                else { tm = 0; }
            }
            return Point2D.Zero;
        }
   
		public static Point2D GetRandomHavenLocation()
		{
			if ( m_HavenLocations == null )
				LoadLocations();

			if ( m_HavenLocations.Length > 0 )
				return m_HavenLocations[Utility.Random( m_HavenLocations.Length )];

			return Point2D.Zero;
		}

		private static void LoadLocations()
		{
			string filePath = Path.Combine( Core.BaseDirectory, "Data/treasure.cfg" );

			List<Point2D> havenList = new List<Point2D>();

			if ( File.Exists( filePath ) )
			{
				using ( StreamReader ip = new StreamReader( filePath ) )
				{
					string line;

					while ( (line = ip.ReadLine()) != null )
					{
						try
						{
							string[] split = line.Split( ' ' );

							int x = Convert.ToInt32( split[0] ), y = Convert.ToInt32( split[1] );

							Point2D loc = new Point2D( x, y );

							if ( IsInHavenIsland( loc ) )
								havenList.Add( loc );
						}
						catch
						{
						}
					}
				}
			}
			m_HavenLocations = havenList.ToArray();
		}

		public static bool IsInHavenIsland( IPoint2D loc )
		{
			return ( loc.X >= 3314 && loc.X <= 3814 && loc.Y >= 2345 && loc.Y <= 3095 );
		}

		public static BaseCreature SpawnIt( int level, Point3D p, Map map, bool guardian )
		{
			if ( level >= 0 )
			{
				BaseCreature bc = new Rat();

				try
				{
					if ( map == Map.Trammel || map == Map.Felucca ) 
                        bc = (BaseCreature)Activator.CreateInstance( m_DefaultSpawns[level][Utility.Random( m_DefaultSpawns[level].Length )] );
					if ( map == Map.Ilshenar ) 
                        bc = (BaseCreature)Activator.CreateInstance( m_IlshenarSpawns[level][Utility.Random( m_IlshenarSpawns[level].Length )] );
					if ( map == Map.Malas ) 
                        bc = (BaseCreature)Activator.CreateInstance( m_MalasSpawns[level][Utility.Random( m_MalasSpawns[level].Length )] );
					if ( map == Map.Tokuno ) 
                        bc = (BaseCreature)Activator.CreateInstance( m_TokunoSpawns[level][Utility.Random( m_TokunoSpawns[level].Length )] );
					if ( map == Map.TerMur ) 
                        bc = (BaseCreature)Activator.CreateInstance( m_TerMurSpawns[level][Utility.Random( m_TerMurSpawns[level].Length )] );
				}
				catch
				{
					return null;
				}

				bc.Home = p;
				bc.RangeHome = 5;

				if ( guardian && level == 0 )
				{
					bc.Name = "a chest guardian";
					bc.Hue = 0x835;
				}
                
                if (map == Map.Ilshenar && Utility.RandomDouble() > 0.92)
                {
                    bc.IsParagon = true;
                    bc.Title += "[Guardian]/";
                }
                else
                    bc.Title += "[Guardian]";

				return bc;
			}

			return null;
		}

		public static BaseCreature Spawn( int level, Point3D p, Map map, Mobile target, bool guardian )
		{
			if ( map == null )
				return null;

			BaseCreature c = SpawnIt( level, p, map, guardian );

			if ( c != null )
			{
				bool spawned = false;

				for ( int i = 0; !spawned && i < 10; ++i )
				{
					int x = p.X - 3 + Utility.Random( 7 );
					int y = p.Y - 3 + Utility.Random( 7 );

					if ( map.CanSpawnMobile( x, y, p.Z ) )
					{
						c.MoveToWorld( new Point3D( x, y, p.Z ), map );
						spawned = true;
					}
					else
					{
						int z = map.GetAverageZ( x, y );

						if ( map.CanSpawnMobile( x, y, z ) )
						{
							c.MoveToWorld( new Point3D( x, y, z ), map );
							spawned = true;
						}
					}
				}

				if ( !spawned )
				{
					c.Delete();
					return null;
				}

				if ( target != null )
					c.Combatant = target;

				return c;
			}

			return null;
		}

		[Constructable]
		public TreasureMap( int level, Map map )
		{          
			m_Level = level;
			m_Map = map;
            DisplayMap = map;

			if ( level == 0 )
				this.ChestLocation = GetRandomHavenLocation();
			else
                this.ChestLocation = GetRandomLocation(map);

            UpdateTreasureMap(this);
		}

        private static void UpdateTreasureMap(TreasureMap Tmap)
        {
            Map map = Tmap.ChestMap;
            Point2D loc = Tmap.ChestLocation;

            Tmap.Width = 300;
            Tmap.Height = 300;

            int width = 600;
            int height = 600;

            int x1 = loc.X - Utility.RandomMinMax(width / 4, (width / 4) * 3);
            int y1 = loc.Y - Utility.RandomMinMax(height / 4, (height / 4) * 3);

            if (x1 < 0) { x1 = 0; }
            if (y1 < 0) { y1 = 0; }

            int x2 = x1 + width;
            int y2 = y1 + height;

            if (x2 > Map.Maps[map.MapID].Width)
                x2 = Map.Maps[map.MapID].Width;

            if (y2 > Map.Maps[map.MapID].Height)
                y2 = Map.Maps[map.MapID].Height;


            if (map == Map.Trammel || map == Map.Felucca)
            {
                if (x2 >= 5120) { x2 = 5119; }
                if (y2 >= 4096) { y2 = 4095; }
            }
            else if (map == Map.Ilshenar)
            {
                if (x2 > 1940)
                    x2 = 1940;

                if (y2 > 1420)
                    y2 = 1420;
            }
            else if (map == Map.Malas)
            {
                if (x2 > 2560)
                    x2 = 2560;

                if (y2 > 2048)
                    y2 = 2048;
            }
            else if (map == Map.Tokuno)
            {
                if (x2 > 1448)
                    x2 = 1448;

                if (y2 > 1448)
                    y2 = 1448;
            }
            else if (map == Map.TerMur)
            {
                if (x2 > 1280)
                    x2 = 1280;

                if (y2 > 4096)
                    y2 = 4096;
            }

            x1 = x2 - width;
            y1 = y2 - height;

            Tmap.Bounds = new Rectangle2D(x1, y1, width, height);

            Tmap.ClearPins();
            Tmap.Protected = true;

            if ( Tmap.Pins.Count > 0 )
                Tmap.ChangePin( 1, loc.X, loc.Y);
            else
                Tmap.AddWorldPin( loc.X, loc.Y );
        }

		public TreasureMap( Serial serial ) : base( serial )
		{
		}

		public static bool HasDiggingTool( Mobile m )
		{
			if ( m.Backpack == null )
				return false;

			List<BaseHarvestTool> items = m.Backpack.FindItemsByType<BaseHarvestTool>();

			foreach ( BaseHarvestTool tool in items )
			{
				if ( tool.HarvestSystem == Engines.Harvest.Mining.System )
					return true;
			}

			return false;
		}

		public void OnBeginDig( Mobile from )
		{
			if ( m_Completed )
			{
				from.SendLocalizedMessage( 503028 ); // The treasure for this map has already been found.
			}
			else if ( m_Level == 0 && !CheckYoung( from ) )
			{
				from.SendLocalizedMessage( 1046447 ); // Only a young player may use this treasure map.
			}
			else if ( from != m_Decoder )
			{
				from.SendLocalizedMessage( 503016 ); // Only the person who decoded this map may actually dig up the treasure.
			}
			else if ( m_Decoder != from && !HasRequiredSkill( from ) )
			{
				from.SendLocalizedMessage( 503031 ); // You did not decode this map and have no clue where to look for the treasure.
			}
			else if ( !from.CanBeginAction( typeof( TreasureMap ) ) )
			{
				from.SendLocalizedMessage( 503020 ); // You are already digging treasure.
			}
			else if ( from.Map != this.m_Map )
			{
				from.SendLocalizedMessage( 1010479 ); // You seem to be in the right place, but may be on the wrong facet!
			}
			else
			{
				from.SendLocalizedMessage( 503033 ); // Where do you wish to dig?
				from.Target = new DigTarget( this );
			}
		}

		private class DigTarget : Target
		{
			private TreasureMap m_Map;

			public DigTarget( TreasureMap map ) : base( 6, true, TargetFlags.None )
			{
				m_Map = map;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Map.Deleted )
					return;

				Map map = m_Map.Map;

				if ( m_Map.m_Completed )
				{
					from.SendLocalizedMessage( 503028 ); // The treasure for this map has already been found.
				}
				else if ( from != m_Map.m_Decoder )
				{
					from.SendLocalizedMessage( 503016 ); // Only the person who decoded this map may actually dig up the treasure.
				}
				else if ( m_Map.m_Decoder != from && !m_Map.HasRequiredSkill( from ) )
				{
					from.SendLocalizedMessage( 503031 ); // You did not decode this map and have no clue where to look for the treasure.
					return;
				}
				else if ( !from.CanBeginAction( typeof( TreasureMap ) ) )
				{
					from.SendLocalizedMessage( 503020 ); // You are already digging treasure.
				}
				else if ( !HasDiggingTool( from ) )
				{
					from.SendMessage( "You must have a digging tool to dig for treasure." );
				}
				else if ( from.Map != map )
				{
					from.SendLocalizedMessage( 1010479 ); // You seem to be in the right place, but may be on the wrong facet!
				}
				else
				{
					IPoint3D p = targeted as IPoint3D;

					Point3D targ3D;
					if ( p is Item )
						targ3D = ((Item)p).GetWorldLocation();
					else
						targ3D = new Point3D( p );

					int maxRange;
					double skillValue = from.Skills[SkillName.Mining].Value;

					if ( skillValue >= 100.0 )
						maxRange = 4;
					else if ( skillValue >= 81.0 )
						maxRange = 3;
					else if ( skillValue >= 51.0 )
						maxRange = 2;
					else
						maxRange = 1;

					Point2D loc = m_Map.m_Location;
					int x = loc.X, y = loc.Y;

					Point3D chest3D0 = new Point3D( loc, 0 );

					if ( Utility.InRange( targ3D, chest3D0, maxRange ) )
					{
						if ( from.Location.X == x && from.Location.Y == y )
						{
							from.SendLocalizedMessage( 503030 ); // The chest can't be dug up because you are standing on top of it.
						}
						else if ( map != null )
						{
							int z = map.GetAverageZ( x, y );

							if ( !map.CanFit( x, y, z, 16, true, true ) )
							{
								from.SendLocalizedMessage( 503021 ); // You have found the treasure chest but something is keeping it from being dug up.
							}
							else if ( from.BeginAction( typeof( TreasureMap ) ) )
							{
								new DigTimer( from, m_Map, new Point3D( x, y, z ), map ).Start();
							}
							else
							{
								from.SendLocalizedMessage( 503020 ); // You are already digging treasure.
							}
						}
					}
					else if ( m_Map.Level > 0 )
					{
						if ( Utility.InRange( targ3D, chest3D0, 8 ) ) // We're close, but not quite
						{
							from.SendLocalizedMessage( 503032 ); // You dig and dig but no treasure seems to be here.
						}
						else
						{
							from.SendLocalizedMessage( 503035 ); // You dig and dig but fail to find any treasure.
						}
					}
					else
					{
						if ( Utility.InRange( targ3D, chest3D0, 8 ) ) // We're close, but not quite
						{
							from.SendAsciiMessage( 0x44, "The treasure chest is very close!" );
						}
						else
						{
							Direction dir = Utility.GetDirection( targ3D, chest3D0 );

							string sDir;
							switch ( dir )
							{
								case Direction.North:	sDir = "north"; break;
								case Direction.Right:	sDir = "northeast"; break;
								case Direction.East:	sDir = "east"; break;
								case Direction.Down:	sDir = "southeast"; break;
								case Direction.South:	sDir = "south"; break;
								case Direction.Left:	sDir = "southwest"; break;
								case Direction.West:	sDir = "west"; break;
								default:				sDir = "northwest"; break;
							}

							from.SendAsciiMessage( 0x44, "Try looking for the treasure chest more to the {0}.", sDir );
						}
					}
				}
			}
		}

		private class DigTimer : Timer
		{
			private Mobile m_From;
			private TreasureMap m_TreasureMap;

			private Point3D m_Location;
			private Map m_Map;

			private TreasureChestDirt m_Dirt1;
			private TreasureChestDirt m_Dirt2;
			private TreasureMapChest m_Chest;

			private int m_Count;

			private DateTime m_NextSkillTime;
			private DateTime m_NextSpellTime;
			private DateTime m_NextActionTime;
			private DateTime m_LastMoveTime;

			public DigTimer( Mobile from, TreasureMap treasureMap, Point3D location, Map map ) : base( TimeSpan.Zero, TimeSpan.FromSeconds( 1.0 ) )
			{
				m_From = from;
				m_TreasureMap = treasureMap;

				m_Location = location;
				m_Map = map;

				m_NextSkillTime = from.NextSkillTime;
				m_NextSpellTime = from.NextSpellTime;
				m_NextActionTime = from.NextActionTime;
				m_LastMoveTime = from.LastMoveTime;

				Priority = TimerPriority.TenMS;
			}

			private void Terminate()
			{
				Stop();
				m_From.EndAction( typeof( TreasureMap ) );

				if ( m_Chest != null )
					m_Chest.Delete();

				if ( m_Dirt1 != null )
				{
					m_Dirt1.Delete();
					m_Dirt2.Delete();
				}
			}

			protected override void OnTick()
			{
				if ( m_NextSkillTime != m_From.NextSkillTime || m_NextSpellTime != m_From.NextSpellTime || m_NextActionTime != m_From.NextActionTime )
				{
					Terminate();
					return;
				}

				if ( m_LastMoveTime != m_From.LastMoveTime )
				{
					m_From.SendLocalizedMessage( 503023 ); // You cannot move around while digging up treasure. You will need to start digging anew.
					Terminate();
					return;
				}

				int z = ( m_Chest != null ) ? m_Chest.Z + m_Chest.ItemData.Height : int.MinValue;
				int height = 16;

				if ( z > m_Location.Z )
					height -= ( z - m_Location.Z );
				else
					z = m_Location.Z;

				if ( !m_Map.CanFit( m_Location.X, m_Location.Y, z, height, true, true, false ) )
				{
					m_From.SendLocalizedMessage( 503024 ); // You stop digging because something is directly on top of the treasure chest.
					Terminate();
					return;
				}

				m_Count++;

				m_From.RevealingAction();
				m_From.Direction = m_From.GetDirectionTo( m_Location );

				if ( m_Count > 1 && m_Dirt1 == null )
				{
					m_Dirt1 = new TreasureChestDirt();
					m_Dirt1.MoveToWorld( m_Location, m_Map );

					m_Dirt2 = new TreasureChestDirt();
					m_Dirt2.MoveToWorld( new Point3D( m_Location.X, m_Location.Y - 1, m_Location.Z ), m_Map );
				}

				if ( m_Count == 5 )
				{
					m_Dirt1.Turn1();
				}
				else if ( m_Count == 10 )
				{
					m_Dirt1.Turn2();
					m_Dirt2.Turn2();
				}
				else if ( m_Count > 10 )
				{
					if ( m_Chest == null )
					{
						m_Chest = new TreasureMapChest( m_From, m_TreasureMap.Level, true );
						m_Chest.MoveToWorld( new Point3D( m_Location.X, m_Location.Y, m_Location.Z - 15 ), m_Map );
					}
					else
					{
						m_Chest.Z++;
					}

					Effects.PlaySound( m_Chest, m_Map, 0x33B );
				}

				if ( m_Chest != null && m_Chest.Location.Z >= m_Location.Z )
				{
					Stop();
					m_From.EndAction( typeof( TreasureMap ) );

					m_Chest.Temporary = false;
					m_TreasureMap.Completed = true;
					m_TreasureMap.CompletedBy = m_From;

                    m_TreasureMap.StopTimer();

					int spawns;
					switch ( m_TreasureMap.Level )
					{
						case 0: spawns = 3; break;
						case 1: spawns = 0; break;
						default: spawns = 4; break;
					}

					for ( int i = 0; i < spawns; ++i )
					{
						BaseCreature bc = Spawn( m_TreasureMap.Level, m_Chest.Location, m_Chest.Map, null, true );

						if ( bc != null )
							m_Chest.Guardians.Add( bc );
					}
				}
				else
				{
					if ( m_From.Body.IsHuman && !m_From.Mounted )
						m_From.Animate( 11, 5, 1, true, false, 0 );

					new SoundTimer( m_From, 0x125 + (m_Count % 2) ).Start();
				}
			}

			private class SoundTimer : Timer
			{
				private Mobile m_From;
				private int m_SoundID;

				public SoundTimer( Mobile from, int soundID ) : base( TimeSpan.FromSeconds( 0.9 ) )
				{
					m_From = from;
					m_SoundID = soundID;

					Priority = TimerPriority.TenMS;
				}

				protected override void OnTick()
				{
					m_From.PlaySound( m_SoundID );
				}
			}
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.InRange( GetWorldLocation(), 2 ) )
			{
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
				return;
			}

			if ( !m_Completed && m_Decoder == null )
				Decode( from );
			else
				DisplayTo( from );
		}

		private bool CheckYoung( Mobile from )
		{
			if ( from.AccessLevel >= AccessLevel.GameMaster )
				return true;

			if ( from is PlayerMobile && ((PlayerMobile)from).Young )
				return true;

			if ( from == this.Decoder )
			{
				this.Level = 1;
				from.SendLocalizedMessage( 1046446 ); // This is now a level one treasure map.
				return true;
			}

			return false;
		}

		private double GetMinSkillLevel()
		{
			switch ( m_Level )
			{
				case 1: return 21.0;
				case 2: return 41.0;
				case 3: return 61.0;
				case 4: return 81.0;
				case 5: return 91.0;
				case 6: return 100.0;
                case 7: return 100.0;

				default: return 0.0;
			}
		}

		private bool HasRequiredSkill( Mobile from )
		{
			return ( from.Skills[SkillName.Cartography].Value >= GetMinSkillLevel() );
		}

		public void Decode( Mobile from )
		{
			if ( m_Completed || m_Decoder != null )
				return;

			if ( m_Level == 0 )
			{
				if ( !CheckYoung( from ) )
				{
					from.SendLocalizedMessage( 1046447 ); // Only a young player may use this treasure map.
					return;
				}
			}
			else
			{
				double minSkill = GetMinSkillLevel();
                double maxSkill = minSkill + 30.0;

                if (from.Skills[SkillName.Cartography].Value < minSkill)
                {
                    from.SendLocalizedMessage(503013); // The map is too difficult to attempt to decode.
                    return;
                }
                else if ( !from.CheckSkill( SkillName.Cartography, ( minSkill-10 ), maxSkill ) )
				{
					from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 503018 ); // You fail to make anything of the map.
					return;
				}
			}

			from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 503019 ); // You successfully decode a treasure map!
            Found = DateTime.Now;
			Decoder = from;
			LootType = LootType.Blessed;
			DisplayTo( from );
            StartTimer();
		}

		public override void DisplayTo( Mobile from )
		{
			if ( m_Completed )
			{
				SendLocalizedMessageTo( from, 503014 ); // This treasure hunt has already been completed.
			}
			else if ( m_Level == 0 && !CheckYoung( from ) )
			{
				from.SendLocalizedMessage( 1046447 ); // Only a young player may use this treasure map.
				return;
			}
			else if ( m_Decoder != from && !HasRequiredSkill( from ) )
			{
				from.SendLocalizedMessage( 503031 ); // You did not decode this map and have no clue where to look for the treasure.
				return;
			}
			else
			{
				SendLocalizedMessageTo( from, 503017 ); // The treasure is marked by the red pin. Grab a shovel and go dig it up!
			}

			from.PlaySound( 0x249 );
			base.DisplayTo( from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			if ( !m_Completed )
			{
				if ( m_Decoder == null )
				{
					list.Add( new DecodeMapEntry( this ) );
				}
				else
				{
					bool digTool = HasDiggingTool( from );
                    
					list.Add( new OpenMapEntry( this ) );
					list.Add( new DigEntry( this, digTool ) );
				}
			}
		}

		private class DecodeMapEntry : ContextMenuEntry
		{
			private TreasureMap m_Map;

			public DecodeMapEntry( TreasureMap map ) : base( 6147, 2 )
			{
				m_Map = map;
			}

			public override void OnClick()
			{
				if ( !m_Map.Deleted )
					m_Map.Decode( Owner.From );
			}
		}

		private class OpenMapEntry : ContextMenuEntry
		{
			private TreasureMap m_Map;

			public OpenMapEntry( TreasureMap map ) : base( 6150, 2 )
			{
				m_Map = map;
			}

			public override void OnClick()
			{
				if ( !m_Map.Deleted )
					m_Map.DisplayTo( Owner.From );
			}
		}

		private class DigEntry : ContextMenuEntry
		{
			private TreasureMap m_Map;

			public DigEntry( TreasureMap map, bool enabled ) : base( 6148, 2 )
			{
				m_Map = map;

				if ( !enabled )
					this.Flags |= CMEFlags.Disabled;
			}

			public override void OnClick()
			{
				if ( m_Map.Deleted )
					return;

				Mobile from = Owner.From;

				if ( HasDiggingTool( from ) )
					m_Map.OnBeginDig( from );
				else
					from.SendMessage( "You must have a digging tool to dig for treasure." );
			}
		}

		public override int LabelNumber
		{ 
			get
			{
                if (m_Decoder != null)
                {
                    // = Decoded
                    if (m_Level == 7)
                        return 1116790;
                    else if ( m_Level == 6 )
                        return 1063452;
                    else
                        return 1041510 + m_Level;
                }
                else                
                {
                    // = Not Decoded
                    if (m_Level == 7)
                        return 1116773;
                    else if ( m_Level == 6 )
                        return 1063453;
                    else
                        return 1041516 + m_Level;
                }
			}
		}

		public override void GetProperties( ObjectPropertyList list )
		{
            base.GetProperties(list);

            string mDesc = "";

			if ( m_Map == Map.Trammel ) 
                mDesc = "for somewhere in Trammel";
 			if ( m_Map == Map.Felucca ) 
                mDesc = "for somewhere in Felucca";
 			if ( m_Map == Map.Ilshenar ) 
                mDesc = "for somewhere in Ilshenar";
 			if ( m_Map == Map.Malas ) 
                mDesc = "for somewhere in Malas";
 			if ( m_Map == Map.Tokuno ) 
                mDesc = "for somewhere in Tokuno Islands";
 			if ( m_Map == Map.TerMur ) 
                mDesc = "for somewhere in Ter Mur";

            list.Add(1053099, String.Format("<BASEFONT COLOR=#DDCC22>\t{0}<BASEFONT COLOR=#FFFFFF>", mDesc)); // for somewhere in Felucca : for somewhere in Trammel  etc...
            
            if (m_Completed)
            {
                list.Add(1041507, m_CompletedBy == null ? "someone" : m_CompletedBy.Name); // completed by ~1_val~
            }
            else
            {
                int Age = GetAge( m_Found );
                int TimeLeft = 30 - Age;

                if (m_Decoder != null && TimeLeft > 0)
                    list.Add(String.Format("This map will expire in {0} days", TimeLeft));
                else if (m_Decoder != null && TimeLeft <= 0)
                    list.Add("This map will expire and reset very soon");                                                
            }
		}

		public override void OnSingleClick( Mobile from )
		{
            int mDesc = 1041503;

			if ( m_Map == Map.Trammel ) 
                mDesc = 1041503;
 			if ( m_Map == Map.Felucca ) 
                mDesc = 1041502;
 			if ( m_Map == Map.Ilshenar ) 
                mDesc = 1060850;
 			if ( m_Map == Map.Malas ) 
                mDesc = 1060851;
 			if ( m_Map == Map.Tokuno ) 
                mDesc = 1115645;
 			if ( m_Map == Map.TerMur ) 
                mDesc = 1115646;

			if ( m_Completed )
			{
				from.Send( new MessageLocalizedAffix( Serial, ItemID, MessageType.Label, 0x3B2, 3, 1048030, "", AffixType.Append, String.Format( " completed by {0}", m_CompletedBy == null ? "someone" : m_CompletedBy.Name ), "" ) );
			}
            // = Decoded
            else if (m_Decoder != null)
            {
                if (m_Level == 7)
                    LabelTo(from, 1041522, String.Format("#{0}\t \t#{1}", 1116790, mDesc));
                if (m_Level == 6)
                    LabelTo(from, 1041522, String.Format("#{0}\t \t#{1}", 1063452, mDesc));
                else
                    LabelTo(from, 1041522, String.Format("#{0}\t \t#{1}", 1041510 + m_Level, mDesc));
            }
            // = Not Decoded
            else
            {
                if (m_Level == 7)
                    LabelTo(from, 1041522, String.Format("#{0}\t \t#{1}", 1116773, mDesc));
                if (m_Level == 6)
                    LabelTo(from, 1041522, String.Format("#{0}\t \t#{1}", 1063453, mDesc));
                else
                    LabelTo(from, 1041522, String.Format("#{0}\t \t#{1}", 1041516 + m_Level, mDesc));
            }         
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            // SF Treasure = version 2
            writer.Write((int)2);

			writer.Write( (Mobile) m_CompletedBy );
			writer.Write( m_Level );
			writer.Write( m_Completed );
			writer.Write( m_Decoder );
			writer.Write( m_Map );
			writer.Write( m_Location );
            
            writer.Write( (DateTime) m_Found);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
                case 2:
                {
                    goto case 1;
                }
				case 1:
				{
					m_CompletedBy = reader.ReadMobile();

					goto case 0;
				}
				case 0:
				{
					m_Level = (int)reader.ReadInt();
					m_Completed = reader.ReadBool();
					m_Decoder = reader.ReadMobile();
					m_Map = reader.ReadMap();
					m_Location = reader.ReadPoint2D();

                    if (version >= 2)
                        m_Found = reader.ReadDateTime();

					if ( version == 0 && m_Completed )
						m_CompletedBy = m_Decoder;
                   
					break;
				}
			}

			if (m_Decoder != null)
            {
                if (LootType == LootType.Regular)
                {
                    LootType = LootType.Blessed;
                }
                if (version <= 1)
                {
                    m_Found = DateTime.Now;
                }

                StartTimer();
			}
		}

        private Timer m_Timer;

        public virtual void StartTimer()
        {
            if (m_Timer != null)
                return;

            m_Timer = Timer.DelayCall(TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(10), new TimerCallback(Slice));
            m_Timer.Priority = TimerPriority.OneMinute;
        }

        public virtual void StopTimer()
        {
            if (m_Timer != null)
                m_Timer.Stop();

            m_Timer = null;
        }

        public virtual void Slice()
        {
            int Age = GetAge(m_Found);

            if (m_Decoder != null && Age >= 30)
            {
                // = Get New Treasure Location after 30 Days
                m_Decoder = null;
                m_Found = DateTime.Now;
                m_Location = GetRandomLocation(m_Map);

                ClearPins();
                UpdateTreasureMap(this);
                UpdateTotals();
                StopTimer();
            }

            InvalidateProperties();
        }

        public override void OnAfterDelete()
        {
            base.OnAfterDelete();

            StopTimer();
        }

        public static int GetAge(DateTime found)
        {
            TimeSpan span = DateTime.Now - found;

            return (int)(span.TotalDays);
        }
	}

	public class TreasureChestDirt : Item
	{
		public TreasureChestDirt() : base( 0x912 )
		{
			Movable = false;

			Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerCallback( Delete ) );
		}

		public TreasureChestDirt( Serial serial ) : base( serial )
		{
		}

		public void Turn1()
		{
			this.ItemID = 0x913;
		}

		public void Turn2()
		{
			this.ItemID = 0x914;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			Delete();
		}
	}
}