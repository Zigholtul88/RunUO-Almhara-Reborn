using System;
using Server;
using Server.Mobiles;

namespace Server
{
	public class OppositionGroup
	{
		private Type[][] m_Types;

		public OppositionGroup( Type[][] types )
		{
			m_Types = types;
		}

		public bool IsEnemy( object from, object target )
		{
			int fromGroup = IndexOf( from );
			int targGroup = IndexOf( target );

			return ( fromGroup != -1 && targGroup != -1 && fromGroup != targGroup );
		}

		public int IndexOf( object obj )
		{
			if ( obj == null )
				return -1;

			Type type = obj.GetType();

			for ( int i = 0; i < m_Types.Length; ++i )
			{
				Type[] group = m_Types[i];

				bool contains = false;

				for ( int j = 0; !contains && j < group.Length; ++j )
					contains = ( type == group[j] );

				if ( contains )
					return i;
			}

			return -1;
		}

		private static OppositionGroup m_TerathansAndOphidians = new OppositionGroup( new Type[][]
			{
				new Type[]
				{
					typeof( TerathanAvenger ),
					typeof( TerathanDrone ),
					typeof( TerathanMatriarch ),
					typeof( TerathanWarrior )
				},
				new Type[]
				{
					typeof( OphidianApprenticeMage ),
					typeof( OphidianAvenger ),
					typeof( OphidianEnforcer ),
					typeof( OphidianKnightErrant ),
					typeof( OphidianMatriarch ),
					typeof( OphidianShaman ),
					typeof( OphidianWarrior )
				}
			} );

		public static OppositionGroup TerathansAndOphidians
		{
			get{ return m_TerathansAndOphidians; }
		}

		private static OppositionGroup m_SavagesAndOrcs = new OppositionGroup( new Type[][]
			{
				new Type[]
				{
					typeof( Orc ),
					typeof( OrcBomber ),
					typeof( OrcBrute ),
					typeof( OrcCaptain ),
					typeof( OrcishLord ),
					typeof( OrcishMage ),
					typeof( SpawnedOrcishLord )
				},
				new Type[]
				{
					typeof( Savage ),
					typeof( SavageRider ),
					typeof( SavageRidgeback ),
					typeof( SavageShaman )
				}
			} );

		public static OppositionGroup SavagesAndOrcs
		{
			get{ return m_SavagesAndOrcs; }
		}
		
		private static OppositionGroup m_FeyAndUndead = new OppositionGroup( new Type[][]
			{
				new Type[]
				{
					typeof( EtherealWarrior ),
					typeof( Kirin ),
					typeof( LordOaks ),
					typeof( Pixie ),
					typeof( Silvani ),
					typeof( Unicorn ),
					typeof( Wisp ),
					typeof( Treefellow ),
					typeof( MLDryad )
				},
				new Type[]
				{
					typeof( AncientLich ),
					typeof( Bogle ),
					typeof( LichLord ),
					typeof( Shade ),
					typeof( Spectre ),
					typeof( Wraith ),
					typeof( BoneKnight ),
					typeof( Ghoul ),
					typeof( Mummy ),
					typeof( SkeletalKnight ),
					typeof( Skeleton ),
					typeof( Zombie ),
					typeof( ShadowKnight ),
					typeof( DarknightCreeper ),
					typeof( RevenantLion ),
					typeof( LadyOfTheSnow ),
					typeof( RottingCorpse ),
					typeof( SkeletalDragon ),
					typeof( Lich )
				}
			} );

		public static OppositionGroup FeyAndUndead
		{
			get{ return m_FeyAndUndead; }
		}

		private static OppositionGroup m_AlytharrPredator = new OppositionGroup( new Type[][]
			{
				new Type[]
				{
					typeof( Centaur ),
					typeof( MinorBloodElemental ),
					typeof( WyvernYoungling )
				},
				new Type[]
				{
					typeof( AlytharrForestHart ),
					typeof( AlytharrGrassSnake ),
					typeof( BlackLizard ),
					typeof( HillToad )
				}
			} );

		public static OppositionGroup AlytharrPredator
		{
			get{ return m_AlytharrPredator; }
		}

		private static OppositionGroup m_GlimmerwoodPredator = new OppositionGroup( new Type[][]
			{
				new Type[]
				{
					typeof( AntLion ),
					typeof( SavageRidgeback )
				},
				new Type[]
				{
					typeof( ForestOstard ),
					typeof( Gryphon ),
					typeof( Parrot ),
					typeof( Ridgeback )
				}
			} );

		public static OppositionGroup GlimmerwoodPredator
		{
			get{ return m_GlimmerwoodPredator; }
		}

		private static OppositionGroup m_ZaythalorPredator = new OppositionGroup( new Type[][]
			{
				new Type[]
				{
					typeof( EvilMage ),
					typeof( Gizzard ),
					typeof( GreenSlime ),
					typeof( LesserAntLion ),
					typeof( MadPumpkinSpirit ),
					typeof( MinorGoblin ),
					typeof( SwampVine ),
					typeof( WildTurkey ),
					typeof( YoungAlligator ),
					typeof( YoungSpiderling )
				},
				new Type[]
				{
					typeof( Bird ),
					typeof( Boar ),
					typeof( Chicken ),
					typeof( Hind ),
					typeof( Rabbit ),
					typeof( ForestBat ),
					typeof( GreySquirrel ),
					typeof( GreyWolfPup ),
					typeof( LargeFrog ),
					typeof( RhinoBeetle ),
					typeof( WaterLizard )
				}
			} );

		public static OppositionGroup ZaythalorPredator
		{
			get{ return m_ZaythalorPredator; }
		}

		private static OppositionGroup m_SamsonSwamplandsPredator = new OppositionGroup( new Type[][]
			{
				new Type[]
				{
					typeof( Allosaur )
				},
				new Type[]
				{
					typeof( ForestDragon )
				}
			} );

		public static OppositionGroup SamsonSwamplandsPredator
		{
			get{ return m_SamsonSwamplandsPredator; }
		}

		private static OppositionGroup m_HarashiNabiPredator = new OppositionGroup( new Type[][]
			{
				new Type[]
				{
					typeof( BulletAnt ),
					typeof( CliffDiver ),
					typeof( Jubokko ),
					typeof( SandKraken )
				},
				new Type[]
				{
					typeof( DesertOstard ),
					typeof( GiantTurtle ),
					typeof( Lion ),
					typeof( SandStreaker ),
					typeof( Zebra )
				}
			} );

		public static OppositionGroup HarashiNabiPredator
		{
			get{ return m_HarashiNabiPredator; }
		}
	}
}