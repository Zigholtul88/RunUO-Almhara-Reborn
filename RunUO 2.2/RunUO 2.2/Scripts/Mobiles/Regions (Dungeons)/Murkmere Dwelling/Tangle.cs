using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Tangle's corpse" )]
	public class Tangle : BaseCreature
	{
		[Constructable]
		public Tangle() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.6, 1.2 )
		{
			IsParagon = true;

			Name = "Tangle";
			Body = 780;
			Hue = 0x21;

			SetStr( 870, 940 );
			SetDex( 58, 74 );
			SetInt( 46, 58 );

			SetHits( 2468, 2733 );
			SetMana( 8, 12 );

			SetDamage( 15, 28 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 40 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 61 );
			SetResistance( ResistanceType.Energy, 41 );

			SetSkill( SkillName.Wrestling, 77.8, 94.6 );
			SetSkill( SkillName.Tactics, 90.6, 100.4 );
			SetSkill( SkillName.MagicResist, 108.4, 114.0 );

			Fame = 56000;
			Karma = -56000;

			if ( 0.25 > Utility.RandomDouble() )
				PackItem( new Board( 100 ) );
			else
				PackItem( new Log( 100 ) );

			PackGold( 4526, 6543 );
			PackReg( 255 );
			PackItem( new Engines.Plants.Seed() );
			PackItem( new Engines.Plants.Seed() );

                        if (Utility.RandomDouble() < 0.15 )
                                PackItem(new TreasureMap(3, Map.Malas ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 25 );
	        }

		public override Poison PoisonImmune { get { return Poison.Lethal; } }

                public void AwardDungeonBossKey()
                {
                      List<Mobile> list = new List<Mobile>();

                      foreach ( Mobile m in GetMobilesInRange( 20 ) )
                      {
                             if ( !CanBeHarmful ( m ) )
                             continue;

                             if ( m.Player )
                             list.Add ( m );
                      }

                      foreach ( Mobile m in list )
                      {
                             if ( m == this || !CanBeHarmful( m ) )
                             continue;

                             if ( !m.Player && !( m is BaseCreature && ( (BaseCreature)m).ControlMaster.Player) )
                             continue;

                          if ( m.Player && m.Alive )
                          {
			       m.AddToBackpack( new MurkmereDwellingBossKey() );
                               m.SendMessage( "You receive a key needed to get pass the mysterious columns." );
                               DoHarmful( m );
                          }
                     }
                }

		public override bool OnBeforeDeath( ) //what happens before it dies
		{
		      AwardDungeonBossKey();
                      return base.OnBeforeDeath();
		}

		public Tangle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public void SpawnBogling( Mobile m )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			Bogling spawned = new Bogling();

			spawned.Team = this.Team;

			bool validLocation = false;
			Point3D loc = this.Location;

			for ( int j = 0; !validLocation && j < 10; ++j )
			{
				int x = X + Utility.Random( 3 ) - 1;
				int y = Y + Utility.Random( 3 ) - 1;
				int z = map.GetAverageZ( x, y );

				if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
					loc = new Point3D( x, y, Z );
				else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
					loc = new Point3D( x, y, z );
			}

			spawned.MoveToWorld( loc, map );
			spawned.Combatant = m;
		}

		public void EatBoglings()
		{
			ArrayList toEat = new ArrayList();
  
			foreach ( Mobile m in this.GetMobilesInRange( 2 ) )
			{
				if ( m is Bogling )
					toEat.Add( m );
			}

			if ( toEat.Count > 0 )
			{
				PlaySound( Utility.Random( 0x3B, 2 ) ); // Eat sound

				foreach ( Mobile m in toEat )
				{
					Hits += (m.Hits / 2);
					m.Delete();
				}
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( this.Hits > (this.HitsMax / 4) )
			{
				if ( 0.25 >= Utility.RandomDouble() )
					SpawnBogling( attacker );
			}
			else if ( 0.25 >= Utility.RandomDouble() )
			{
				EatBoglings();
			}
		}
	}
}