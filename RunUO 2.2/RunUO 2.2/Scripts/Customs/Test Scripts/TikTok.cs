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
	public class TikTok : BaseCreature 
	{ 
		public override bool DeleteCorpseOnDeath{ get{ return true; } }

		[Constructable] 
		public TikTok() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 ) 
		{ 
			Body = 637; 
			Hue = 0x8026; 
			Name = "tik tok"; 

			Buckler buckler = new Buckler();
			ChainCoif coif = new ChainCoif();
			PlateGloves gloves = new PlateGloves();

			buckler.Hue = 0x835; buckler.Movable = false;
			coif.Hue = 0x835;
			gloves.Hue = 0x835;

			AddItem( buckler );
			AddItem( coif );
			AddItem( gloves );

			SetStr( 101, 110 ); 
			SetDex( 101, 110 ); 
			SetInt( 101, 110 );

			SetHits( 178, 201 );
			SetStam( 191, 200 );

			SetDamage( 10, 22 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Cold, 25 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Fire, 20, 30 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 20, 30 );

			SetSkill( SkillName.Wrestling, 75.1, 100.0 ); 
			SetSkill( SkillName.Tactics, 90.1, 100.0 ); 
			SetSkill( SkillName.MagicResist, 90.1, 100 ); 

			VirtualArmor = 40; 
			Fame = 7000; 
			Karma = -7000;

			FlyTimer.FlyList.Add( this );             
		}

		public void OnTick()
		{
			Effects.PlaySound(Location, Map, Utility.RandomList( 0x428,1053,1086,0xA8,0x99,0x3F3,0x462,0xC9,0xCA,0xCB,0xCC,0xD6,0xE5,846,0x21D,0x162,0x163,0x270,1511,1508,1510,1509,456,0xC9,0xCA,0xCB,0x26B,0x5A,0x164,0x187,0x1BA,422,0x388,1320,1354,0x275,0xA3,0xC4,0x64,0x69,0x6E,0x78,0x4D7,0xD9,0x99,0x9E,0x82,0x83,0x84,0x277,0x270,0x273,0x279,0x53D,0x53E,0x53F,0x540,0x541,0x542,0x543,0x544,0x545,0x546,0x547,0x548,0x549,0x54A,0x54B,0x54E,0x54F,0x551,0x552,0x553,0x554,0x555,0x556,0x558,0x55A,0x55B,0x55D,0x55E,0x55F,0x561,0x566,0x568,0x569 ) );
		}

	        public class FlyTimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<TikTok> FlyList = new List<TikTok>();

		        public static void Initialize() 
		        {
			        if (Enabled)
				        new FlyTimer().Start();
		        }

		        public FlyTimer() : base(TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 )) 
		        {
			        Priority = TimerPriority.OneSecond;
		        }

		        protected override void OnTick() 
		        {
			        foreach (TikTok tiktok in FlyList)
				        tiktok.OnTick();
		        }
	        }

		public override int GetIdleSound()
		{
			return 0x200;
		}

		public override int GetAngerSound()
		{
			return 0x56;
		}

		public override bool OnBeforeDeath()
		{
			if ( !base.OnBeforeDeath() )
				return false;

			Gold gold = new Gold( Utility.RandomMinMax( 240, 375 ) );
			gold.MoveToWorld( Location, Map );

			Effects.SendLocationEffect( Location, Map, 0x376A, 10, 1 );
			return true;
		}

		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		public override bool IsEnemy( Mobile m )
		{
		        PlayerMobile pm = m as PlayerMobile;

			if ( m is PlayerMobile && m.SkillsTotal >= 7000 )
				return false;

                        if ( m is PlayerVendor || m is TownCrier || m is BaseSpecialCreature )
				return false;

			if ( m is BaseCreature )
			{
				BaseCreature c = (BaseCreature)m;

				if( c.Controlled || c.FightMode == FightMode.Aggressor || c.FightMode == FightMode.Closest || c.FightMode == FightMode.None )

					return false;
			}

			return true;
		}

		public TikTok( Serial serial ) : base( serial ) 
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

			FlyTimer.FlyList.Add(this);
		} 
	} 
}