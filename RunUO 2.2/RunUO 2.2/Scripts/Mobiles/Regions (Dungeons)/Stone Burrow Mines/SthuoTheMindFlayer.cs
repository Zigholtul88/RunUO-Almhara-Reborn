using System;
using System.Collections;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Sthuo" )]
	public class SthuoTheMindFlayer : BaseCreature
	{
                private static bool m_Talked;
                string[]SthuoSay = new string[]
       	        {
		        "This very moment I should commence the herald of your final chapter.",
		        "My deepest apologizes. I forget my spells can be a bit too much for the feebleminded.",
		        "It appears you've made it past my sickler minions. Unfortunately for you, this is where it ends.",
		        "Pity how I originally figured you to be made of sturdier quality.",
		        "Your life hangs upon a candle tip and I intend on extinguishing it.",
		        "The trials that are your mere existence will soon come to a stopping point whenever I'm finished.",
		        "Do not think I was going easy on you. Believe me citizen of Skaddria, we have only just begun.",
		        "Unfortunately for you, this meeting will have to come to a sudden close.",
		};

		[Constructable]
		public SthuoTheMindFlayer() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Sthuo the Mind Flayer";
			Body = 721;

			SetStr( 150, 200 );
			SetDex( 75, 85 );
			SetInt( 850, 1000 );

			SetHits( 800, 850 );
			SetMana( 800 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Energy, 30 );

			SetResistance( ResistanceType.Physical, 15 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.EvalInt, 180.0, 185.0 );
			SetSkill( SkillName.Magery, 185.0, 195.0 );
			SetSkill( SkillName.MagicResist, 55.0, 70.0 );
			SetSkill( SkillName.Meditation, 145.0, 150.0 );
			SetSkill( SkillName.Tactics, 45.9, 60.0 );
			SetSkill( SkillName.Wrestling, 51.3, 57.6 );

			Fame = 50000;
			Karma = -50000;

			AddItem( new LightSource() );

                        PackGold( 3430, 5935 ); 
			PackReg( 300 );

                        if (Utility.RandomDouble() < 0.5 )
                                PackItem(new TreasureMap(3, Map.Malas ) );

			switch ( Utility.Random( 5 ) )
			{
				case 0: PackItem( new Alexandrite(10) ); break;
				case 1: PackItem( new Kunzite(10) ); break;
				case 2: PackItem( new Tanzanite(10) ); break;
				case 3: PackItem( new Zultanite(10) ); break;
				case 4: PackItem( new PinkQuartz(10) ); break;
			}

			switch ( Utility.Random( 5 ) )
			{
				case 0: PackItem( new ArcaneStone(250) ); break;
				case 1: PackItem( new CharredFeather(250) ); break;
				case 2: PackItem( new DiamondDust(250) ); break;
				case 3: PackItem( new DragonScale(250) ); break;
				case 4: PackItem( new LichDust(250) ); break;
			}

			PackItem( new BeetleEgg( Utility.RandomMinMax( 11, 16 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 10 );
			AddLoot( LootPack.LowScrolls, 4 );
			AddLoot( LootPack.MedScrolls, 2 );
			AddLoot( LootPack.Potions );
		}

                public override void OnMovement( Mobile m, Point3D oldLocation )
                {
                     if( m_Talked == false )
                     {
                          if ( m.InRange( this, 3 ) && m is PlayerMobile)
                          {
                             m_Talked = true;
                             SayRandom(SthuoSay, this );
                             this.Move( GetDirectionTo( m.Location ) );
                             SpamTimer t = new SpamTimer();
                             t.Start();
                          }
                    }
              }

              private class SpamTimer : Timer
              {
                   public SpamTimer() : base( TimeSpan.FromSeconds( 25 ) )
                   {
                        Priority = TimerPriority.OneSecond;
                   }

                   protected override void OnTick()
                   {
                           m_Talked = false;
                   }
              }

                private static void SayRandom( string[] say, Mobile m )
                {
                     m.Say( say[Utility.Random( say.Length )] );
                }

		public override int GetIdleSound() { return 1553; } 
		public override int GetAngerSound() { return 1550; } 
		public override int GetHurtSound() { return 1552; } 
		public override int GetDeathSound() { return 1551; }

		public SthuoTheMindFlayer( Serial serial ) : base( serial )
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