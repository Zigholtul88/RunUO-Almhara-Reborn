using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Engines.Craft;
using Server.Commands;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;
using Server.Engines.BulkOrders;

namespace Server.Mobiles
{
	public class KameronKoveBowyer : BaseVendor
	{
                private static bool m_Talked; // flag to prevent spam 

                string[] kfcsay = new string[] // things to say while greating 
                { 
                       "If fletchin's your game, we have all the materials needed to get you started.", 
                       "Supplies are limited. Be sure to stock up on high quality arrows and bolts.",  
                       "Need to pawn off a bow or two. We'll take 'em.",  
                       "Wanna quickly be efficient with a bow? We can help you out.", 
                       "Need to quickly be efficient at fletching? We can help.",
                       "Be sure to pick up a quiver. It'll make hauling arrows less cumbersome.",
                       "Have a nice day",
                };

		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public KameronKoveBowyer() : base( "the bowyer" )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBKameronKoveBowyer() );
		}

		public override void InitOutfit()
		{
			Hue = Utility.RandomList( 3,28,38,48,53,58,63,88,93 );

			SetStr( 57 );
			SetDex( 91 );
			SetInt( 11 );

			SetSkill( SkillName.Anatomy, 59.5, 68.7 );
			SetSkill( SkillName.Archery, 80.0, 100.0 );
			SetSkill( SkillName.Fletching, 80.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 61.0, 93.0 );

			PackGold( 14, 46 );
			PackItem( new Bolt( Utility.RandomMinMax( 20, 30 ) ) );

			Crossbow weapon = new Crossbow();
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 386;
				Name = NameList.RandomName( "female" );
			}
			else
			{
				Body = 390;
				Name = NameList.RandomName( "male" );
			}
                }

		public override void OnMovement( Mobile m, Point3D oldLocation ) 
                {                                                    
                      if( m_Talked == false ) 
                      { 
                            if ( m.InRange( this, 4 ) ) 
                            {                
                                 m_Talked = true; 
                                 SayRandom( kfcsay, this ); 
                                 this.Move( GetDirectionTo( m.Location ) ); 
                                 // Start timer to prevent spam 
                                 SpamTimer t = new SpamTimer(); 
                                 t.Start(); 
                            } 
                      } 
                } 

                private class SpamTimer : Timer 
                { 
                       public SpamTimer() : base( TimeSpan.FromSeconds( 60 ) ) 
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

		#region Bulk Orders
		public override Item CreateBulkOrder( Mobile from, bool fromContextMenu )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm != null && pm.NextFletchingBulkOrder == TimeSpan.Zero && (fromContextMenu || 0.2 > Utility.RandomDouble()) )
			{
				double theirSkill = pm.Skills[SkillName.Fletching].Base;

				if ( theirSkill >= 70.1 )
					pm.NextFletchingBulkOrder = TimeSpan.FromHours( 3.0 );
				else if ( theirSkill >= 50.1 )
					pm.NextFletchingBulkOrder = TimeSpan.FromHours( 2.0 );
				else
					pm.NextFletchingBulkOrder = TimeSpan.FromHours( 1.0 );

				return SmallFletchingBOD.CreateRandomFor( from );
			}

			return null;
		}

		public override bool IsValidBulkOrder( Item item )
		{
			return ( item is SmallFletchingBOD || item is LargeFletchingBOD );
		}

		public override bool SupportsBulkOrders( Mobile from )
		{
			return ( from is PlayerMobile && from.Skills[SkillName.Fletching].Base > 0 );
		}

		public override TimeSpan GetNextBulkOrder( Mobile from )
		{
			if ( from is PlayerMobile )
				return ((PlayerMobile)from).NextFletchingBulkOrder;

			return TimeSpan.Zero;
		}

		public override void OnSuccessfulBulkOrderReceive( Mobile from )
		{
			if( Core.SE && from is PlayerMobile )
				((PlayerMobile)from).NextFletchingBulkOrder = TimeSpan.Zero;
		}
		#endregion

		public KameronKoveBowyer( Serial serial ) : base( serial )
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
        }

	public class SBKameronKoveBowyer: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBKameronKoveBowyer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
////////////////////////////////////////////////////// Misc
// All tools sell at a base price of 100 gp
				Add( new GenericBuyInfo( typeof( FletcherTools ), 100, 378, 0x1022, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenQuiver ), 100, 20, 0x2FB7, 0 ) );

////////////////////////////////////////////////////// Primary Components
				Add( new GenericBuyInfo( "Iron Ingot", typeof( IronIngot ), 5, 999, 0x1BF2, 0 ) );
				Add( new GenericBuyInfo( "Leather", typeof( Leather ), 5, 999, 0x1081, 0 ) );
				Add( new GenericBuyInfo( "Log", typeof( Log ), 5, 999, 0x1BDD, 0 ) );

////////////////////////////////////////////////////// Secondary Components
				Add( new GenericBuyInfo( "Copper Wire", typeof( CopperWire ), 1, 999, 0x1879, 0 ) );
				Add( new GenericBuyInfo( "Feather", typeof( Feather ), 1, 999, 0x1BD1, 0 ) );
				Add( new GenericBuyInfo( "Gears", typeof( Gears ), 1, 999, 0x1053, 0 ) );
				Add( new GenericBuyInfo( "Gold Wire", typeof( GoldWire ), 1, 999, 0x1878, 0 ) );
				Add( new GenericBuyInfo( "Iron Wire", typeof( IronWire ), 1, 999, 0x1876, 0 ) );
				Add( new GenericBuyInfo( "Shaft", typeof( Shaft ), 1, 999, 0x1BD4, 0 ) );
				Add( new GenericBuyInfo( "Silver Wire", typeof( SilverWire ), 1, 999, 0x1877, 0 ) );
				Add( new GenericBuyInfo( "Spool of Thread", typeof( SpoolOfThread ), 1, 999, 0xFA0, 0 ) );
				Add( new GenericBuyInfo( "Springs", typeof( Springs ), 1, 999, 0x105D, 0 ) );

////////////////////////////////////////////////////// Ammunition
				Add( new GenericBuyInfo( typeof( Arrow ), 8, Utility.Random( 100, 500 ), 0xF3F, 0 ) );
				Add( new GenericBuyInfo( typeof( Arrow ), 8, Utility.Random( 100, 500 ), 0xF3F, 0 ) );
				Add( new GenericBuyInfo( typeof( Arrow ), 8, Utility.Random( 100, 500 ), 0xF3F, 0 ) );
				Add( new GenericBuyInfo( typeof( OakArrow ), 10, Utility.Random( 50, 80 ), 0xF3F, 2010 ) );
				Add( new GenericBuyInfo( typeof( OakArrow ), 10, Utility.Random( 50, 80 ), 0xF3F, 2010 ) );
				Add( new GenericBuyInfo( typeof( YewArrow ), 15, Utility.Random( 50, 80 ), 0xF3F, 1192 ) );
				Add( new GenericBuyInfo( typeof( YewArrow ), 15, Utility.Random( 50, 80 ), 0xF3F, 1192 ) );
				Add( new GenericBuyInfo( typeof( AshArrow ), 20, Utility.Random( 50, 80 ), 0xF3F, 1191 ) );

				Add( new GenericBuyInfo( typeof( Bolt ), 8, Utility.Random( 100, 500 ), 0x1BFB, 0 ) );
				Add( new GenericBuyInfo( typeof( Bolt ), 8, Utility.Random( 100, 500 ), 0x1BFB, 0 ) );
				Add( new GenericBuyInfo( typeof( Bolt ), 8, Utility.Random( 100, 500 ), 0x1BFB, 0 ) );
				Add( new GenericBuyInfo( typeof( DullCopperBolt ), 10, Utility.Random( 50, 100 ), 0x1BFB, 2419 ) );
				Add( new GenericBuyInfo( typeof( DullCopperBolt ), 10, Utility.Random( 50, 100 ), 0x1BFB, 2419 ) );
				Add( new GenericBuyInfo( typeof( ShadowIronBolt ), 15, Utility.Random( 50, 100 ), 0x1BFB, 2406 ) );
				Add( new GenericBuyInfo( typeof( ShadowIronBolt ), 15, Utility.Random( 50, 100 ), 0x1BFB, 2406 ) );
				Add( new GenericBuyInfo( typeof( BronzeBolt ), 20, Utility.Random( 50, 100 ), 0x1BFB, 2418 ) );

				Add( new GenericBuyInfo( typeof( FukiyaDarts ), 8, Utility.Random( 100, 500 ), 0x2806, 0 ) );

////////////////////////////////////////////////////// Weapons
				Add( new GenericBuyInfo( typeof( Fukiya ), 100, 500, 0x27AA, 0 ) );
				Add( new GenericBuyInfo( typeof( Bow ), 100, 500, 0x13B2, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Crossbow ), 100, 500, 0xF50, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( Balestra ), 200, 500, 15353, 0 ) ); // Level 5
				Add( new GenericBuyInfo( typeof( ElvenLeafBow ), 200, 500, 15358, 0 ) ); // Level 5
				Add( new GenericBuyInfo( typeof( MagicalShortbow ), 300, 500, 0x2D2B, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( RepeatingCrossbow ), 300, 500, 0x26C3, 0 ) ); // Level 10
				Add( new GenericBuyInfo( typeof( CompositeBow ), 400, 500, 0x26C2, 0 ) ); // Level 20
				Add( new GenericBuyInfo( typeof( EbonyCrossbow ), 400, 500, 15808, 0 ) ); // Level 20
				Add( new GenericBuyInfo( typeof( FireBow ), 500, 500, 15359, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( GrassBow ), 500, 500, 15362, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( IceBow ), 500, 500, 15365, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( LightningBow ), 500, 500, 15368, 0 ) ); // Level 25
				Add( new GenericBuyInfo( typeof( EbonyWarBow ), 1000, 500, 15804, 0 ) ); // Level 30
				Add( new GenericBuyInfo( typeof( PistolCrossbow ), 1000, 500, 15370, 0 ) ); // Level 30
				Add( new GenericBuyInfo( typeof( ElvenCompositeLongbow ), 1500, 500, 0x2D1E, 0 ) ); // Level 40
				Add( new GenericBuyInfo( typeof( ReinforcedCrossbow ), 1500, 500, 15376, 0 ) ); // Level 40
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
////////////////////////////////////////////////////// Misc
// (Sell Price = Vendor Price / by 2) 

				Add( typeof( FletcherTools ), 50 );
				Add( typeof( ElvenQuiver ), 50 );

////////////////////////////////////////////////////// Primary Components
// (Sell Price = Harvest component is 5 per cost equal to x amount / by 2 and round up to the nearest 5) 
				Add( typeof( IronIngot ), 3 );
				Add( typeof( Log ), 3 );

////////////////////////////////////////////////////// Components
// (Sell Price = Remains the same as those found on buying menus) 

				Add( typeof( Feather ), 1 );
				Add( typeof( Shaft ), 1 );

////////////////////////////////////////////////////// Ammunition
// (Sell Price = Harvest component is 5 per cost equal to x amount + Secondary component is 1 per cost equal to x amount / by 2) 

				Add( typeof( Arrow ), 4 );
				Add( typeof( Bolt ), 4 );
				Add( typeof( FukiyaDarts ), 4 );
			} 
		} 
	}
}