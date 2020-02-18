using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an orcish corpse" )]
	public class OFQOrcBrute : BaseCreature
	{
		[Constructable]
		public OFQOrcBrute() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an orc brute";
			Body = 189;
			BaseSoundID = 0x45A;

			SetStr( 1000 );
			SetDex( 100 );
			SetInt( 100 );

			SetHits( 2000 );

			SetDamage( 5, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.Macing, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 15000;
			Karma = -15000;

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( Loot.RandomStatue() );
			pack.DropItem( new ShadowIronIngot( 100 ) );
			pack.DropItem( new BolaBall() );
			pack.DropItem( Loot.RandomGem() );
			pack.DropItem( Loot.RandomGem() );
			pack.DropItem( Loot.RandomGem() );
			pack.DropItem( new OFQRing() );

			PackItem( pack );
		}

                public override bool OnBeforeDeath()
                {
                        this.Say("GHARNAFLABLUP!");

                        return base.OnBeforeDeath();
                }

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int Meat{ get{ return 2; } }

		public override bool CanRummageCorpses{ get{ return true; } }

		public override void OnDamagedBySpell( Mobile caster )
		{
			if ( caster == this )
				return;

			SpawnOrcLord( caster );
		}

		public void SpawnOrcLord( Mobile target )
		{
			Map map = target.Map;

			if ( map == null )
				return;

			int orcs = 0;

			foreach ( Mobile m in this.GetMobilesInRange( 10 ) )
			{
				if ( m is OrcishLord )
					++orcs;
			}

			if ( orcs < 10 )
			{
				BaseCreature orc = new SpawnedOrcishLord();

				orc.Team = this.Team;

				Point3D loc = target.Location;
				bool validLocation = false;

				for ( int j = 0; !validLocation && j < 10; ++j )
				{
					int x = target.X + Utility.Random( 3 ) - 1;
					int y = target.Y + Utility.Random( 3 ) - 1;
					int z = map.GetAverageZ( x, y );

					if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
						loc = new Point3D( x, y, Z );
					else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
						loc = new Point3D( x, y, z );
				}

				orc.MoveToWorld( loc, map );

				orc.Combatant = target;
			}
		}

		public OFQOrcBrute( Serial serial ) : base( serial )
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
