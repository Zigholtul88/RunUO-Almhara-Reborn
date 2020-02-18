using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a lady of the snow corpse" )]
	public class LadyOfTheSnow : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }

		[Constructable]
		public LadyOfTheSnow() : base( AIType.AI_Mage, FightMode.Closest, 7, 1, 0.2, 0.4 )
		{
			Name = "a lady of the snow";
                        Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 2411;
                        HairItemID = 12236;
                        HairHue = 1153;

			SetStr( 276, 305 );
			SetDex( 106, 125 );
			SetInt( 175, 205 );

			SetHits( 276, 305 );
			SetMana( 175, 205 );

			SetDamage( 5, 15 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Cold, 80 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.Magery, 68.4, 77.9 );
			SetSkill( SkillName.MagicResist, 63.2, 75.1 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.Wrestling, 80.1, 100.0 );

			Fame = 3200;
			Karma = -3200;

			PackGold( 11, 16 );
			PackReg( 12, 14 );

			AddItem( new RaggedDress(598) );
			AddItem( new Necklace() );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 1153;
			gloves.Movable = true;
			AddItem( gloves );

			PackItem( new TurquoiseCustom( Utility.RandomMinMax( 1, 3 ) ) );
			PackItem( new DiamondDust( Utility.RandomMinMax( 7, 11 ) ) );

			if ( 0.25 > Utility.RandomDouble() )
				PackItem( Engines.Plants.Seed.RandomBonsaiSeed() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.LowScrolls );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool BleedImmune { get { return true; } }
		public override bool CanRummageCorpses { get { return true; } }

		public override int GetIdleSound() { return 794; } //play female giggle
		public override int GetHurtSound()  { return 806; } //play female oomph 3
		public override int GetAngerSound() { return 824; } //play female yell
		public override int GetDeathSound() { return 790; } //play female death 3

		// TODO: Snowball

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.1 > Utility.RandomDouble() )
			{
				/* Cold Wind
				 * Graphics: Message - Type: "3" From: "0x57D4F5B" To: "0x0" ItemId: "0x37B9" ItemIdName: "glow" FromLocation: "(928 164, 34)" ToLocation: "(928 164, 34)" Speed: "10" Duration: "5" FixedDirection: "True" Explode: "False"
				 * Start cliloc: 1070832
				 * Damage: 1hp per second for 5 seconds
				 * End cliloc: 1070830
				 * Reset cliloc: 1070831
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if( timer != null )
				{
					timer.DoExpire();
					defender.SendLocalizedMessage( 1070831 ); // The freezing wind continues to blow!
				}
				else
					defender.SendLocalizedMessage( 1070832 ); // An icy wind surrounds you, freezing your lungs as you breathe!

				timer = new ExpireTimer( defender, this );
				timer.Start();
				m_Table[defender] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private Mobile m_From;
			private int m_Count;

			public ExpireTimer( Mobile m, Mobile from )
				: base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			public void DoExpire()
			{
				Stop();
				m_Table.Remove( m_Mobile );
			}

			public void DrainLife()
			{
				if( m_Mobile.Alive )
					m_Mobile.Damage( 2, m_From );
				else
					DoExpire();
			}

			protected override void OnTick()
			{
				DrainLife();

				if( ++m_Count >= 5 )
				{
					DoExpire();
					m_Mobile.SendLocalizedMessage( 1070830 ); // The icy wind dissipates.
				}
			}
		}

		public LadyOfTheSnow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}