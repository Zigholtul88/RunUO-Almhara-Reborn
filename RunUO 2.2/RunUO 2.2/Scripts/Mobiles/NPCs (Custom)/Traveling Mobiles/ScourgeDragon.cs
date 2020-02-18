using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Targeting;
using Server.Spells;
using Server.Spells.Fourth;

namespace Server.Mobiles
{
	[CorpseName( "a scourge dragon corpse" )]
	public class ScourgeDragon : BaseCreature
	{
        Point3D[] MoveLocations =
        {
            new Point3D( 276, 847, 30 ),//Abyssal Fathoms Entrance
            new Point3D( 131, 1813, 14 ),//Amul Seketsi Royal Tomb Entrance
            new Point3D( 1580, 203, 60 ),//Azurite Caverns Entrance
            new Point3D( 437, 1721, 26 ),//Everstar Estuary Entrance
            new Point3D( 1776, 1425, 0 ),//Murkmere Dwelling Entrance
            new Point3D( 625, 891, 21 ),//Sorcerors Den Entrance
            new Point3D( 864, 985, -45 ),//Tarnithok Fortress Entrance
            new Point3D( 490, 812, 0 ),//Whispering Hollow Entrance
            new Point3D( 168, 1151, 32 ) //Island Closest to Tartarrix
        };

              private MoveTimer m_Timer;

	      public override bool AlwaysMurderer { get { return true; } }

		[Constructable]
		public ScourgeDragon () : base( AIType.AI_Melee, FightMode.Closest, 100, 1, 0.175, 0.350 )
		{
			Name = "a scourge dragon";
			Body = 826;
			BaseSoundID = 362;

			SetStr( 300, 500 );
			SetDex( 99, 120 );
			SetInt( 150, 250 );

			SetHits( 800, 1000 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.Tactics, 99.6, 100.0 );
			SetSkill( SkillName.Wrestling, 98.6, 99.0 );

			Fame = 10000;
			Karma = -10000;

			PackGold( 160, 180 );

			switch ( Utility.Random( 18 ))
			{
				case 0: PackItem( new Amethyst() ); break;
				case 1: PackItem( new Garnet() ); break;
				case 2: PackItem( new Jade() ); break;
				case 3: PackItem( new Morganite() ); break;
				case 4: PackItem( new Paraiba() ); break;
				case 5: PackItem( new TigerEye() ); break;
				case 6: PackItem( new Alexandrite() ); break;
				case 7: PackItem( new Ametrine() ); break;
				case 8: PackItem( new Kunzite() ); break;
				case 9: PackItem( new Ruby() ); break;
				case 10: PackItem( new Sapphire() ); break;
				case 11: PackItem( new Tanzanite() ); break;
				case 12: PackItem( new Topaz() ); break;
				case 13: PackItem( new Zultanite() ); break;
				case 14: PackItem( new Diamond() ); break;
				case 15: PackItem( new Emerald() ); break;
				case 16: PackItem( new PinkQuartz() ); break;
				case 17: PackItem( new StarSapphire() ); break;
			}

			PackItem( new DragonScale( Utility.RandomMinMax( 25, 35 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new MeteorSwarmScroll() );

                 m_Timer = new MoveTimer( this );
                 ChangeLocation();

		}

        public void ChangeLocation()
        {
            this.MoveToWorld(MoveLocations[Utility.Random(MoveLocations.Length)], Map.Malas);
            this.Hidden = true; //Arrives Hidden
        }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.MedScrolls, 1 );
			AddLoot( LootPack.LowScrolls, 5 );
			AddLoot( LootPack.Gems, 3 );

 		if ( Utility.RandomDouble() < 0.10 )
                {
	                BaseWeapon weapon = Loot.RandomWeapon( true );
			switch ( Utility.Random( 33 ) )
			{
				case 0: weapon = new BattleAxe(); break;
				case 1: weapon = new ExecutionersAxe (); break;
				case 2: weapon = new LargeBattleAxe(); break;
				case 3: weapon = new WarAxe(); break;
			        case 4: weapon = new Bow(); break;
				case 5: weapon = new Crossbow(); break;
				case 6: weapon = new HeavyCrossbow(); break;
				case 7: weapon = new WarHammer(); break;
				case 8: weapon = new WarMace(); break;
				case 9: weapon = new Bardiche(); break;
				case 10: weapon = new Halberd(); break;
				case 11: weapon = new Spear(); break;
				case 12: weapon = new QuarterStaff(); break;
				case 13: weapon = new Katana(); break;
				case 14: weapon = new Longsword(); break;
				case 15: weapon = new VikingSword(); break;
				case 16: weapon = new CompositeBow(); break;
				case 17: weapon = new CrescentBlade(); break;
				case 18: weapon = new DoubleBladedStaff(); break;
				case 19: weapon = new Lance(); break;
				case 20: weapon = new PaladinSword(); break;
				case 21: weapon = new Scythe(); break;
				case 22: weapon = new Daisho(); break;
				case 23: weapon = new Lajatang(); break;
				case 24: weapon = new NoDachi(); break;
				case 25: weapon = new Tetsubo(); break;
				case 26: weapon = new Yumi(); break;
				case 27: weapon = new ElvenCompositeLongbow(); break;
				case 28: weapon = new OrnateAxe(); break;
				case 29: weapon = new RadiantScimitar(); break;
				case 30: weapon = new WarCleaver(); break;
				case 31: weapon = new WildStaff(); break;
				default: weapon = new DiamondMace(); break;
			}

			      BaseRunicTool.ApplyAttributesTo( weapon, 5, 15, 35 );

				PackItem( weapon );
			}

 		if ( Utility.RandomDouble() < 0.10 )
                {
			BaseArmor armor = Loot.RandomArmor( true );
			switch ( Utility.Random( 5 ) )
			{
			      case 0: armor = new CrusaderGauntlets(); break;
			      case 1: armor = new CrusaderGorget(); break;
				case 2: armor = new CrusaderLeggings(); break;
				case 3: armor = new CrusaderSleeves(); break;
				default: armor = new CrusaderBreastplate(); break;
		      }

			      BaseRunicTool.ApplyAttributesTo( armor, 5, 15, 35 );

				PackItem( armor );
			}

 		if ( Utility.RandomDouble() < 0.20 )
            {
			  BaseClothing clothing = Loot.RandomClothing( true );
		        BaseRunicTool.ApplyAttributesTo( clothing, 5, 15, 35 );  

                    PackItem( clothing );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseShield shield = new MetalKiteShield();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( shield, 5, 15, 35 ); 

                    PackItem( shield );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel bracelet = new GoldBracelet();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( bracelet, 5, 15, 35 );  

                    PackItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel earrings = new GoldEarrings();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( earrings, 5, 15, 35 ); 

                    PackItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel necklace = new GoldNecklace();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( necklace, 5, 15, 35 );      

                    PackItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.10 )
            {
			  BaseJewel ring = new GoldRing();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( ring, 5, 15, 35 ); 

                    PackItem( ring );
            }
	}

	        public override bool Unprovokable { get { return true; } }
	        public override bool BardImmune { get { return true; } }
		public override int Meat{ get{ return 19; } }
		public override int Hides{ get{ return 44; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override int Scales{ get{ return 7; } }
		public override ScaleType ScaleType{ get{ return ( Body == 12 ? ScaleType.Yellow : ScaleType.Red ); } }

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( to is HammerhillGuardianFighter || 
                       to is TempleCrusaderOfElmhaven || 
                       to is TempleKnightOfElmhaven || 
                       to is TempleMagicianOfElmhaven || 
                       to is TempleRangerOfElmhaven || 
                       to is ElandrimNurShazFortressGuard || 
                       to is ZaythalorForestRanger )
				damage *= 100;
		}

		public override WeaponAbility GetWeaponAbility()
		{
			if (50.0 >= Utility.RandomDouble())
			return WeaponAbility.Bladeweave;
			else
			return WeaponAbility.TalonStrike;
		}

                public override void OnGaveMeleeAttack(Mobile defender)
                {
                      base.OnGaveMeleeAttack(defender);
                      if (0.25 >= Utility.RandomDouble())

		      Ability.CrimsonMeteor( this, 50 );
                }

		public override void OnGotMeleeAttack( Mobile attacker )
		{
	              base.OnGotMeleeAttack( attacker );
                      if (0.25 >= Utility.RandomDouble())

		      Ability.CrimsonMeteor( this, 50 );
		}

		public ScourgeDragon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
            m_Timer = new MoveTimer( this );
        }

        private class MoveTimer : Timer
        {
            private ScourgeDragon m_Owner;

            public MoveTimer( ScourgeDragon owner ) : base( TimeSpan.FromHours( 1 ), TimeSpan.FromHours( 1 ) )
            {
                m_Owner = owner;
                TimerThread.PriorityChange( this, 7 );
            }

            protected override void OnTick()
            {
                if ( m_Owner == null )
                {
                    Stop();
                    return;
                }
                else if ( m_Owner.Hits == m_Owner.HitsMax ) 
                {
                    m_Owner.ChangeLocation();
                }
            }
        }
    }
}