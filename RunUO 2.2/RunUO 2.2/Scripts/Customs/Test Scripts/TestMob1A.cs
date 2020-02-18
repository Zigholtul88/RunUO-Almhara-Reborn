using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "a corpse" )]
	public class TestMob1A : BaseCreature
	{
                private static readonly int[] m_North = new int[]
                {
                       -1, -1,
                        1, -1,
                       -1, 2,
                        1, 2
                };
                private static readonly int[] m_East = new int[]
                {
                       -1, 0,
                        2, 0
                };

		[Constructable]
		public TestMob1A() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "Bob";
			Title = "the Gate Keeper";
			Body = 0x1D;
			BaseSoundID = 0x9E;

			SetStr( 47, 70 );
			SetDex( 49, 63 );
			SetInt( 18, 29 );

			SetHits( 275, 300 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 18 );

			SetSkill( SkillName.MagicResist, 18.9, 25.8 );
			SetSkill( SkillName.Tactics, 32.5, 46.9 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 1500;
			Karma = -1500;

			PackGold( 2, 5 );
			AddItem( new MagicalShortbow() );
			PackItem( new Arrow( Utility.RandomMinMax( 5, 7 ) ) );

			PackItem( new FishScale( Utility.RandomMinMax( 6, 12 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}

                public override void OnThink()
                {
                        base.OnThink();

                        if ( Combatant == null )
                            return;

                        if ( Hits > 0.6 * HitsMax && Utility.RandomDouble() < 0.05 )
                            FireRing();
                }

                public virtual void FireRing()
                {
                        for (int i = 0; i < m_North.Length; i += 2)
                        {
                                Point3D p = Location;

                                p.X += m_North[i];
                                p.Y += m_North[i + 1];

                                IPoint3D po = p as IPoint3D;

                                SpellHelper.GetSurfaceTop(ref po);

                                Effects.SendLocationEffect(po, Map, 0x3E27, 50);
                        }

                        for (int i = 0; i < m_East.Length; i += 2)
                        {
                                Point3D p = Location;

                                p.X += m_East[i];
                                p.Y += m_East[i + 1];

                                IPoint3D po = p as IPoint3D;

                                SpellHelper.GetSurfaceTop(ref po);

                                Effects.SendLocationEffect(po, Map, 0x3E31, 50);
                        }
                }

		public TestMob1A( Serial serial ) : base( serial )
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
