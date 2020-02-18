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
	public class SpectralArmour : BaseCreature 
	{ 
		public override bool DeleteCorpseOnDeath{ get{ return false; } }

		[Constructable] 
		public SpectralArmour() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{
			Body = 637; 
			Hue = 0x8026; 
			Name = "spectral armour"; 

			Buckler buckler = new Buckler();
			buckler.Hue = 0x835; 
                        buckler.Movable = true;
		        BaseRunicTool.ApplyAttributesTo( buckler, 5, 25, 35 );
			AddItem( buckler );

			ChainCoif coif = new ChainCoif();
			coif.Hue = 0x835;
                        coif.Movable = true;
		        BaseRunicTool.ApplyAttributesTo( coif, 5, 25, 35 );
			AddItem( coif );

			PlateGloves gloves = new PlateGloves();
			gloves.Hue = 0x835;
                        gloves.Movable = true;
		        BaseRunicTool.ApplyAttributesTo( gloves, 5, 25, 35 );
			AddItem( gloves );

			SetStr( 101, 110 ); 
			SetDex( 101, 110 ); 
			SetInt( 101, 110 );

			SetHits( 578, 601 );
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
 
			Fame = 7000; 
			Karma = -7000;

			FlyTimer.FlyList.Add( this );             
		}

		public void OnTick()
		{
			Effects.PlaySound(Location, Map, 0x51F);
		}

	        public class FlyTimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<SpectralArmour> FlyList = new List<SpectralArmour>();

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
			        foreach (SpectralArmour spectralarmour in FlyList)
				        spectralarmour.OnTick();
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

			Gold gold = new Gold( Utility.RandomMinMax( 440, 575 ) );
			gold.MoveToWorld( Location, Map );

			Effects.SendLocationEffect( Location, Map, 0x376A, 10, 1 );
			return true;
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }

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

		public SpectralArmour( Serial serial ) : base( serial ) 
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