using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Misc;
using Server.Mobiles;

namespace Server.Mobiles 
{ 
	public class DragonSanctuarySamuraiSunElf : BaseGuardian
	{ 
                Point3D[] MoveLocations =
                {
                        new Point3D( 1607, 303, 48 ),//Dragon Sanctuary [City]
                        new Point3D( 1626, 333, -17 ),//Dragon Sanctuary [City]
                        new Point3D( 1629, 311, 48 ),//Dragon Sanctuary [City]
                        new Point3D( 1656, 324, 33 ),//Dragon Sanctuary [City]
                        new Point3D( 1671, 264, 73 ),//Dragon Sanctuary [City]
                        new Point3D( 1681, 300, 78 ),//Dragon Sanctuary [City]
                        new Point3D( 1686, 258, 68 ),//Dragon Sanctuary [City]
                        new Point3D( 1699, 291, 83 ),//Dragon Sanctuary [City]
                        new Point3D( 1707, 181, 109 ),//Dragon Sanctuary [City]
                        new Point3D( 1713, 247, 78 ),//Dragon Sanctuary [City]
                        new Point3D( 1750, 237, 58 ),//Dragon Sanctuary [City]
                        new Point3D( 1718, 635, -7 ),//Dragon Sanctuary [Dirt Passage]
                        new Point3D( 1769, 327, 53 ),//Dragon Sanctuary [Dirt Passage]
                        new Point3D( 1796, 425, -6 ),//Dragon Sanctuary [Dirt Passage]
                        new Point3D( 1815, 575, 95 ),//Dragon Sanctuary [Dirt Passage]
                        new Point3D( 1834, 594, 60 ),//Dragon Sanctuary [Dirt Passage]
                        new Point3D( 1581, 534, -14 ),//Dragon Sanctuary [Beach]
                        new Point3D( 1594, 638, -14 ),//Dragon Sanctuary [Beach]
                        new Point3D( 1619, 597, -13 ),//Dragon Sanctuary [Beach]
                        new Point3D( 1820, 484, -14 ),//Dragon Sanctuary [Beach]
                        new Point3D( 1508, 621, -23 ),//Dragon Sanctuary [Gypsy Camp]
                        new Point3D( 1602, 546, -18 ),//Dragon Sanctuary [Gypsy Camp]
                        new Point3D( 1502, 543, 0 ),//Dragon Sanctuary [Ruins]
                        new Point3D( 1527, 528, 8 ) //Dragon Sanctuary [Ruins]
                };

                private MoveTimer m_Timer;

		[Constructable] 
		public DragonSanctuarySamuraiSunElf() : base( AIType.AI_Melee, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			SetStr( 755, 788 );
			SetDex( 300, 500 );
			SetInt( 100, 200 );

			SetHits( 500, 600 );

			SetDamage( 12, 15 );

			SetSkill( SkillName.Anatomy, 100.0 );
			SetSkill( SkillName.MagicResist, 70.0 );
			SetSkill( SkillName.Swords, 100.0 );
			SetSkill( SkillName.Tactics, 100.0 );

			Karma = 10000;

                        m_Timer = new MoveTimer( this );
                        ChangeLocation();

			PackItem( new Bandage( Utility.RandomMinMax( 15, 20 ) ) );

			if ( this.Female = Utility.RandomBool() )
			{
				Name = NameList.RandomName( "elven female" );
			        Title = "Ljosalfar Samurai of Dragon Sanctuary"; 
				Body = 606;
			        Hue = Utility.RandomList( 1002,1003,1009,1010,1011,1016,1017,1023,1030 );
                                HairHue = Utility.RandomList( 1502,1507,1513,2213,2216,2218 );
                                HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );			

			        RadiantScimitar weapon = new RadiantScimitar();
		                BaseRunicTool.ApplyAttributesTo( weapon, 5, 25, 35 );
                                weapon.Slayer = SlayerName.ReptilianDeath;
			        weapon.WeaponAttributes.HitLightning = 25;
			        weapon.Hue = 0x4D5;
			        weapon.Movable = true;
			        AddItem( weapon );

			        AmazonianFighterHelmet helmet = new AmazonianFighterHelmet();
			        helmet.Movable = true;
			        AddItem( helmet );
				
			        AmazonianFighterBustier chest = new AmazonianFighterBustier();
			        chest.Movable = true;
			        AddItem( chest );

			        AmazonianFighterGloves gloves = new AmazonianFighterGloves();
			        gloves.Movable = true;
			        AddItem( gloves );

			        AddItem( new AmazonianFighterBelt() );
			        AddItem( new AmazonianFighterBoots() );

			        new Unicorn().Rider = this;
			}
			else 
			{		
				Name = NameList.RandomName( "elven male" );
			        Title = "Ljosalfar Samurai of Dragon Sanctuary";
				Body = 605;
			        Hue = Utility.RandomList( 1002,1003,1009,1010,1011,1016,1017,1023,1030 );
                                HairHue = Utility.RandomList( 1502,1507,1513,2213,2216,2218 );
                                HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );	

			        SetSkill( SkillName.Fencing, 100.0 );

			        WarCleaver weapon = new WarCleaver();
		                BaseRunicTool.ApplyAttributesTo( weapon, 5, 25, 35 );
                                weapon.Slayer = SlayerName.ReptilianDeath;
			        weapon.WeaponAttributes.HitLightning = 25;
			        weapon.Hue = 0x4D5;
			        weapon.Movable = true;
			        AddItem( weapon );

			        DecorativePlateKabuto helm = new DecorativePlateKabuto();
		                BaseRunicTool.ApplyAttributesTo( helm, 5, 25, 35 );
			        helm.Hue = 0x4D5;
			        helm.Movable = true;
			        AddItem( helm );

			        PlateMempo gorget = new PlateMempo();
		                BaseRunicTool.ApplyAttributesTo( gorget, 5, 25, 35 );
			        gorget.Hue = 0x4D5;
			        gorget.Movable = true;
			        AddItem( gorget );

			        PlateHiroSode arms = new PlateHiroSode();
		                BaseRunicTool.ApplyAttributesTo( arms, 5, 25, 35 );
			        arms.Hue = 0x4D5;
			        arms.Movable = true;
			        AddItem( arms );

			        PlateDo chest = new PlateDo();
		                BaseRunicTool.ApplyAttributesTo( chest, 5, 25, 35 );
			        chest.Hue = 0x4D5;
			        chest.Movable = true;
			        AddItem( chest );

			        PlateHaidate legs = new PlateHaidate();
		                BaseRunicTool.ApplyAttributesTo( legs, 5, 25, 35 );
			        legs.Hue = 0x4D5;
			        legs.Movable = true;
			        AddItem( legs );

			        FurBoots boots = new FurBoots();
		                BaseRunicTool.ApplyAttributesTo( boots, 5, 25, 35 );
			        boots.Hue = 0x4D5;
			        boots.Movable = true;
			        AddItem( boots );

			        new Kirin().Rider = this;
			}
		}

                public void ChangeLocation()
                {
                        this.MoveToWorld( MoveLocations[ Utility.Random( MoveLocations.Length )], Map.Ilshenar );
                        this.Hidden = true; //Arrives Hidden
                }

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public override bool OnBeforeDeath()
		{
			IMount mount = this.Mount;

			if ( mount != null )
				mount.Rider = null;

			if ( mount is Mobile )
				((Mobile)mount).Delete();

			return base.OnBeforeDeath();
		}

		public DragonSanctuarySamuraiSunElf( Serial serial ) : base( serial ) 
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
                        m_Timer = new MoveTimer(this);
		}

                private class MoveTimer : Timer
                {
                        private DragonSanctuarySamuraiSunElf m_Owner;

                public MoveTimer(DragonSanctuarySamuraiSunElf owner): base(TimeSpan.FromHours(1), TimeSpan.FromHours(1))
                {
                        m_Owner = owner;
                        TimerThread.PriorityChange(this, 7);
                }

                protected override void OnTick()
                {
                        if (m_Owner == null)
                        {
                        Stop();
                        return;
                }
                else if (m_Owner.Hits == m_Owner.HitsMax) // IE not in combat at all
                {
                        m_Owner.ChangeLocation();
                }
            }
        }
    }
}