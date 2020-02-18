using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an ice fiend corpse" )]
	public class IceFiend : BaseCreature
	{
		[Constructable]
		public IceFiend () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an ice fiend";
			Body = 43;
			BaseSoundID = 357;

			SetStr( 376, 405 );
			SetDex( 176, 195 );
			SetInt( 201, 225 );

			SetHits( 452, 486 );
			SetMana( 1005, 1125 );

			SetDamage( 8, 19 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Cold, 75 );

			SetResistance( ResistanceType.Physical, 60 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 60 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.EvalInt, 80.1, 90.0 );
			SetSkill( SkillName.Magery, 80.1, 90.0 );
			SetSkill( SkillName.MagicResist, 75.1, 85.0 );
			SetSkill( SkillName.Tactics, 80.1, 90.0 );
			SetSkill( SkillName.Wrestling, 80.1, 100.0 );

			Fame = 28000;
			Karma = -28000;

			PackGold( 81, 97 );

			PackItem( new Paraiba() );
			PackItem( new DiamondDust( Utility.RandomMinMax( 17, 23 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new SummonDaemonScroll() );

 			if ( Utility.RandomDouble() < 0.05 )
				PackItem( new CrackedResistColdGem() );

 			if ( Utility.RandomDouble() < 0.05 )
				PackItem( new CrackedHitHarmGem() );

			Container pack1 = new Backpack();
			pack1.DropItem( new Gold( Utility.RandomMinMax( 38, 49 ) ) );

 		      if ( Utility.RandomDouble() < 0.10 )
                  {
			   BaseWeapon weapon = Loot.RandomWeapon( true );
		           BaseRunicTool.ApplyAttributesTo( weapon, 5, 15, 30 );  

                           pack1.DropItem( weapon );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			   BaseArmor armor1 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor1, 5, 15, 30 );  

                           pack1.DropItem( armor1 );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			   BaseArmor armor2 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor2, 5, 15, 30 );  

                           pack1.DropItem( armor2 );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			   BaseArmor armor3 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor3, 5, 15, 30 );  

                           pack1.DropItem( armor3 );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			   BaseClothing clothing1 = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing1, 3, 15, 30 );  

                           pack1.DropItem( clothing1 );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			   BaseClothing clothing2 = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing2, 3, 15, 30 );  

                           pack1.DropItem( clothing2 );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			   BaseWeapon weapon = Loot.RandomWeapon( true );
		           BaseRunicTool.ApplyAttributesTo( weapon, 5, 25, 30 );  

                           pack1.DropItem( weapon );
                  }


			Container pack2 = new Backpack();
			pack2.DropItem( new BlackPearl( Utility.RandomMinMax( 7, 12 ) ) );
			pack2.DropItem( new Bloodmoss( Utility.RandomMinMax( 5, 9 ) ) );
			pack2.DropItem( new Garlic( Utility.RandomMinMax( 9, 14 ) ) );
			pack2.DropItem( new Ginseng( Utility.RandomMinMax( 3, 7 ) ) );
			pack2.DropItem( new MandrakeRoot( Utility.RandomMinMax( 8, 15 ) ) );
			pack2.DropItem( new Nightshade( Utility.RandomMinMax( 9, 17 ) ) );
			pack2.DropItem( new SpidersSilk( Utility.RandomMinMax( 7, 12 ) ) );
			pack2.DropItem( new SulfurousAsh( Utility.RandomMinMax( 5, 9 ) ) );
			PackItem( pack2 );

			Container pack3 = new Backpack();
			pack3.DropItem( new CurePotion() );
			pack3.DropItem( new CurePotion() );
			pack3.DropItem( new ExplosionPotion() );
			pack3.DropItem( new HealPotion() );
			PackItem( pack3 );

			switch ( Utility.Random( 5 ) )
			{
				case 0: PackItem( new HarmScroll(5) );  break;
				case 1: PackItem( new EnergyBoltScroll(3) ); break;
				case 2: PackItem( new PoisonFieldScroll(2) ); break;
				case 3: PackItem( new WallOfStoneScroll(2) ); break;
				case 4: PackItem( new CurseScroll(2) ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Average, 3 );

 		if ( Utility.RandomDouble() < 0.10 )
            {
	            BaseWeapon weapon = Loot.RandomWeapon( true );
		      BaseRunicTool.ApplyAttributesTo( weapon, 3, 25, 30 );  

			PackItem( weapon );
		}

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseClothing clothing = Loot.RandomClothing( true );
		        BaseRunicTool.ApplyAttributesTo( clothing, 3, 25, 30 );  

                    PackItem( clothing );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseShield shield = new ScarabShield();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( shield, 5, 25, 30 ); 

                    PackItem( shield );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseJewel bracelet = new GoldBracelet();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( bracelet, 5, 25, 30 );  

                    PackItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseJewel earrings = new GoldEarrings();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( earrings, 5, 25, 30 ); 

                    PackItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseJewel necklace = new GoldNecklace();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( necklace, 5, 25, 30 );      

                    PackItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseJewel ring = new GoldRing();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( ring, 5, 25, 30 ); 

                    PackItem( ring );
            }

			if ( 0.08 > Utility.RandomDouble() )
			{
				switch ( Utility.Random( 4 ) )
				{
					case 0: PackItem( new FrostAbyssalRingmailGloves() ); break;
					case 1: PackItem( new FrostAbyssalRingmailLeggings() ); break;
					case 2: PackItem( new FrostAbyssalRingmailSleeves() ); break;
					case 3: PackItem( new FrostAbyssalRingmailTunic() ); break;
				}
			}
		}

		public override int Meat{ get{ return 1; } }

		private DateTime m_LastRadiated;
	        private Hashtable m_Mobiles = new Hashtable();

		protected override bool OnMove( Direction d )
		{
			if ( !IsDeadBondedPet )
			{
				if ( m_LastRadiated <= DateTime.Now )
					m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 10 ) );
				IPooledEnumerable eable = GetMobilesInRange( 2 );
				foreach( Mobile m in eable )
					if ( m_Mobiles[m] == null )
						m_Mobiles[m] = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( RadiationCallBack ), m );
			}

			return base.OnMove( d );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m_LastRadiated <= DateTime.Now )
					m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 10 ) );
			if ( !IsDeadBondedPet && m_Mobiles[m] == null && Utility.InRange( Location, m.Location, 2 ) && !Utility.InRange( Location, oldLocation, 2 ) )
				m_Mobiles[m] = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( RadiationCallBack ), m );

			base.OnMovement( m, oldLocation );
		}

		public void RadiationCallBack( object state )
		{
			Mobile m = (Mobile)state;

			if ( Deleted || !Alive || !Utility.InRange( Location, m.Location, 2 ) )
			{
				((Timer)m_Mobiles[m]).Stop();
				m_Mobiles[m] = null;
				return;
			}

			if ( this != m && m.AccessLevel == AccessLevel.Player && m_LastRadiated <= DateTime.Now && Server.Spells.SpellHelper.ValidIndirectTarget( m, this ) && CanBeHarmful( m, false, false ) )
			{
				AOS.Damage( m, this, Utility.Random( 35, 45 ), 0, 0, 100, 0, 0, true );
				m.PlaySound( 0x0FC );
				m.RevealingAction();
				DoHarmful( m );
				m.SendMessage( "The ice fiend's icy aura damages you slowly as you stand near it!" );
				m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 5, 5 ) );
			}
		}

		public IceFiend( Serial serial ) : base( serial )
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