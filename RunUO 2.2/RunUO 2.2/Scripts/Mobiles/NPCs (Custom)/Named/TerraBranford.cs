using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.ContextMenus;
using Server.Items;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	public class TerraBranford : BaseGuardian
	{
		[Constructable]
		public TerraBranford() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Terra";
			Title = "the Faraway Traveler"; 
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 33777;
                        HairItemID = 12239;
                        HairHue = 71;

			SetStr( 500 );
			SetDex( 500 );
			SetInt( 500 );

			SetHits( 1000 );
			SetMana( 2000 );

			SetDamage( 15, 20 );

			SetSkill( SkillName.AnimalLore, 64.0, 100.0 );
			SetSkill( SkillName.AnimalTaming, 90.0, 100.0 );
			SetSkill( SkillName.EvalInt, 95.5, 125.0 );
			SetSkill( SkillName.Magery, 99.5, 125.0 );
			SetSkill( SkillName.MagicResist, 95.5, 100.0 );
			SetSkill( SkillName.Meditation, 95.5, 100.0 );
			SetSkill( SkillName.Veterinary, 65.0, 88.0 );
			SetSkill( SkillName.Wrestling, 95.5, 100.0 );

			PackGold( 227, 348 );

			Circlet helm = new Circlet();
			helm.Movable = true;
			AddItem( helm );

			PlateGorget gorget = new PlateGorget();
			gorget.Hue = 29;
			gorget.Movable = true;
			AddItem( gorget );

			PlateArms arms = new PlateArms();
			arms.Hue = 221;
			arms.Movable = true;
			AddItem( arms );

			FemalePlateChest chest = new FemalePlateChest();
			chest.Hue = 29;
			chest.Movable = true;
			AddItem( chest );

			AddItem( new ThighBoots(29) );

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 450, 570 ) ) );
			pack.DropItem( new BlackPearl( Utility.RandomMinMax( 15, 20 ) ) );
			pack.DropItem( new Bloodmoss( Utility.RandomMinMax( 15, 20 ) ) );
			pack.DropItem( new Garlic( Utility.RandomMinMax( 15, 20 ) ) );
			pack.DropItem( new Ginseng( Utility.RandomMinMax( 15, 20 ) ) );
			pack.DropItem( new MandrakeRoot( Utility.RandomMinMax( 15, 20 ) ) );
			pack.DropItem( new Nightshade( Utility.RandomMinMax( 15, 20 ) ) );
			pack.DropItem( new SpidersSilk( Utility.RandomMinMax( 15, 20 ) ) );
			pack.DropItem( new SulfurousAsh( Utility.RandomMinMax( 15, 20 ) ) );

			PackItem( pack );

			switch ( Utility.Random( 32 ))
			{
					case 0: PackItem( new ClumsyScroll() ); break;
					case 1: PackItem( new CreateFoodScroll() ); break;
					case 2: PackItem( new FeeblemindScroll() ); break;
					case 3: PackItem( new HealScroll() ); break;
					case 4: PackItem( new MagicArrowScroll() ); break;
					case 5: PackItem( new NightSightScroll() ); break;
					case 6: PackItem( new ReactiveArmorScroll() ); break;
					case 7: PackItem( new WeakenScroll() ); break;
					case 8: PackItem( new AgilityScroll() ); break;
					case 9: PackItem( new CunningScroll() ); break;
					case 10: PackItem( new CureScroll() ); break;
					case 11: PackItem( new HarmScroll() ); break;
					case 12: PackItem( new MagicTrapScroll() ); break;
					case 13: PackItem( new MagicUnTrapScroll() ); break;
					case 14: PackItem( new ProtectionScroll() ); break;
					case 15: PackItem( new StrengthScroll() ); break;
					case 16: PackItem( new BlessScroll() ); break;
					case 17: PackItem( new FireballScroll() ); break;
					case 18: PackItem( new MagicLockScroll() ); break;
					case 19: PackItem( new PoisonScroll() ); break;
					case 20: PackItem( new TelekinisisScroll() ); break;
					case 21: PackItem( new TeleportScroll() ); break;
					case 22: PackItem( new UnlockScroll() ); break;
					case 23: PackItem( new WallOfStoneScroll() ); break;
					case 24: PackItem( new ArchCureScroll() ); break;
					case 25: PackItem( new ArchProtectionScroll() ); break;
					case 26: PackItem( new CurseScroll() ); break;
					case 27: PackItem( new FireFieldScroll() ); break;
					case 28: PackItem( new GreaterHealScroll() ); break;
					case 29: PackItem( new LightningScroll() ); break;
					case 30: PackItem( new ManaDrainScroll() ); break;
					case 31: PackItem( new RecallScroll() ); break;
			}
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public TerraBranford( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new TerraBranfordEntry( from, this ) );
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
		
		public class TerraBranfordEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public TerraBranfordEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}
			
			public override void OnClick()
			{
				
				
				if( !( m_Mobile is PlayerMobile ) )
					return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				
				{
					if ( ! mobile.HasGump( typeof( TerraBranfordGump ) ) )
					{
						mobile.SendGump( new TerraBranfordGump( mobile ));
						
					}
				}
			}
		}
	}

        public class TerraBranfordGump : Gump 
        { 
                public static void Initialize() 
                { 
                     CommandSystem.Register( "TerraBranfordGump", AccessLevel.GameMaster, new CommandEventHandler( TerraBranfordGump_OnCommand ) ); 
                } 

                private static void TerraBranfordGump_OnCommand( CommandEventArgs e ) 
                { 
                     e.Mobile.SendGump( new TerraBranfordGump( e.Mobile ) ); 
                } 

                public TerraBranfordGump( Mobile owner ) : base( 50,50 ) 
                { 
//----------------------------------------------------------------------------------------------------
			this.AddPage(0);
			this.AddBackground(126, 131, 398, 389, 9270);
			this.AddAlphaRegion(130, 132, 391, 389);
			this.AddImage(110, 460, 10464);
			this.AddImage(536, 214, 9265);
			this.AddImage(507, 460, 10464);
			this.AddImage(507, 408, 10464);
			this.AddImage(110, 193, 10464);
			this.AddImage(110, 247, 10464);
			this.AddImage(110, 301, 10464);
			this.AddImage(110, 354, 10464);
			this.AddImage(110, 408, 10464);
			this.AddImage(110, 139, 10464);
			this.AddImage(93, 197, 9263);
			this.AddImage(59, 124, 10421);
			this.AddImage(88, 110, 10420);
			this.AddImage(107, 246, 10411);
			this.AddImage(43, 399, 10402);
			this.AddImage(93, 513, 10103);
			this.AddImage(109, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(218, 513, 10100);
			this.AddImage(202, 513, 10100);
			this.AddImage(124, 513, 10100);
			this.AddImage(172, 513, 10100);
			this.AddImage(156, 513, 10100);
			this.AddImage(140, 513, 10100);
			this.AddImage(188, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(249, 513, 10100);
			this.AddImage(264, 513, 10100);
			this.AddImage(218, 513, 10100);
			this.AddImage(308, 513, 10100);
			this.AddImage(172, 513, 10100);
			this.AddImage(292, 513, 10100);
			this.AddImage(188, 513, 10100);
			this.AddImage(277, 513, 10100);
			this.AddImage(339, 513, 10100);
			this.AddImage(324, 513, 10100);
			this.AddImage(415, 513, 10100);
			this.AddImage(399, 513, 10100);
			this.AddImage(354, 513, 10100);
			this.AddImage(368, 123, 10100);
			this.AddImage(385, 513, 10100);
			this.AddImage(445, 513, 10100);
			this.AddImage(430, 513, 10100);
			this.AddImage(521, 513, 10100);
			this.AddImage(505, 513, 10100);
			this.AddImage(460, 513, 10100);
			this.AddImage(476, 513, 10100);
			this.AddImage(491, 513, 10100);
			this.AddImage(156, 123, 10100);
			this.AddImage(140, 123, 10100);
			this.AddImage(232, 123, 10100);
			this.AddImage(216, 123, 10100);
			this.AddImage(171, 123, 10100);
			this.AddImage(187, 123, 10100);
			this.AddImage(202, 123, 10100);
			this.AddImage(339, 513, 10100);
			this.AddImage(324, 513, 10100);
			this.AddImage(415, 513, 10100);
			this.AddImage(399, 513, 10100);
			this.AddImage(353, 123, 10100);
			this.AddImage(369, 513, 10100);
			this.AddImage(385, 513, 10100);
			this.AddImage(263, 123, 10100);
			this.AddImage(248, 123, 10100);
			this.AddImage(339, 123, 10100);
			this.AddImage(323, 123, 10100);
			this.AddImage(278, 123, 10100);
			this.AddImage(294, 123, 10100);
			this.AddImage(309, 123, 10100);
			this.AddImage(398, 123, 10100);
			this.AddImage(383, 123, 10100);
			this.AddImage(474, 123, 10100);
			this.AddImage(458, 123, 10100);
			this.AddImage(413, 123, 10100);
			this.AddImage(429, 123, 10100);
			this.AddImage(444, 123, 10100);
			this.AddImage(505, 123, 10100);
			this.AddImage(489, 123, 10100);
			this.AddImage(521, 123, 10100);
			this.AddImage(507, 193, 10464);
			this.AddImage(507, 139, 10464);
			this.AddImage(507, 354, 10464);
			this.AddImage(507, 299, 10464);
			this.AddImage(507, 247, 10464);
			this.AddImage(523, 254, 10411);
			this.AddImage(532, 130, 10431);
			this.AddImage(500, 112, 10430);
			this.AddImage(535, 513, 10105);
			this.AddImage(520, 417, 10412);
			this.AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 );
			this.AddHtml( 157, 181, 345, 279, "Please leave me be for now.<BR><BR><I><BASEFONT COLOR=#0099FF>Who Are You</BASEFONT COLOR></I>", false, true);

//----------------------------------------------------------------------------------------------------
		}

                public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 

                { 
                    Mobile from = state.Mobile; 

                    switch ( info.ButtonID ) 
                { 

                case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
                { 
                    //Cancel 
                    break; 
                } 
            }
        }
    }
}

