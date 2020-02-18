using System;
using System.Collections;
using System.Collections.Generic;
using Server;
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
	public class SkaddriaAlchemist : BaseVendor 
	{ 
		private Mobile m_ListeningTo;
		private string m_LastSaid;
		private string m_LastHeard;

		public override bool InitialInnocent{ get{ return true; } }

		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SkaddriaAlchemist() : base( "the alchemist" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBSkaddriaAlchemist() ); 
		}

		public override void InitOutfit()
		{
			m_ListeningTo = null;
			m_LastSaid = null;
			m_LastHeard = null;

			SpeechHue = Utility.RandomList( 44, 1102, 1109, 1111, 1141, 1148, 1153, 2213 );

			Name = "Zake Clementine";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33821;
                        HairItemID = 0;
                        HairHue = 0;
                        FacialHairItemID = 8254;
                        FacialHairHue = 1138;

			SetStr( 85 );
			SetDex( 72 );
			SetInt( 92 );

			SetSkill( SkillName.Alchemy, 85.0, 100.0 );
			SetSkill( SkillName.EvalInt, 65.0, 88.0 );
			SetSkill( SkillName.Magery, 64.0, 100.0 );
			SetSkill( SkillName.MagicResist, 65.0, 88.0 );
			SetSkill( SkillName.Wrestling, 36.0, 68.0 );
			SetSkill( SkillName.TasteID, 65.0, 88.0 );

			PackGold( 31, 63 );

			AddItem( new WizardsHat(58) );
			AddItem( new Robe(143) );
			AddItem( new LightBoots(58) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 2128;
			gloves.Movable = true;
			AddItem( gloves );
                }

		public override void OnSpeech( SpeechEventArgs e )
		{
			if ( !e.Handled )
			{
				Mobile from = e.Mobile;
				if ( this.ControlMaster == from )
				{
					String command = e.Speech;
					if ( command == "What did you just say?" && m_LastSaid != null )
						this.Say( m_LastSaid );
					else if ( command == "Repeat what you just heard." && m_LastHeard != null )
					if ( command == "Who are you listening to?" && this.m_ListeningTo != null )
						this.Say( "{0}", this.m_ListeningTo.Name );
				}
				if ( from is PlayerMobile )
				{
					String text = e.Speech;
					if ( this.m_ListeningTo == null )
					{
						this.m_ListeningTo = from;
						this.BeginLineRecognition( text, from );
					}
					else if ( this.m_ListeningTo == from )
						this.BeginLineRecognition( text, from );
				}
			}
		}

		public override void OnThink()
		{
			if ( this.m_ListeningTo != null && !this.m_ListeningTo.InRange( this.Location, 6 ))
				this.m_ListeningTo = null;
		}

		public void BeginLineRecognition( String text, Mobile from )
		{
			string response = this.GetResponseFor( text, from );
			this.m_LastSaid = response;
			this.m_LastHeard = text;
			this.Say( response );
		}

		public string GetResponseFor( String text, Mobile from )
		{
			if ( text == "hi" || text == "hello" || text == "hey" || text == "g'day" || text == "good day" || text == "hi there" )
				return "G'day to you and welcome to the Magician's Corner. Your number one pit stop when it comes to potions out the gizzards feathery arse. [Profession] [Inventory] [Skill] [Bye].";

//////////////////////////////////////////////////////////// Profession
			else if ( text == "Profession" || text == "profession" )
				return "My profession as an alchemist is largely associated with the conjuration and mixing of various ingredients in order to brew special liquids called [potions].";
			else if ( text == "Potions" || text == "potions" )
				return "Potions, magical as they are allow the consumer to experience various [effects] at the cost of a short cool down delay for each use.";
			else if ( text == "Effects" || text == "effects" )
				return "Effects can range from [stat] point restoration, [poison] remedies, [night vision], small time [demolition] expert and even when you need a temporary boost within a particular stat or skill.";
			else if ( text == "Stat" || text == "stat" )
				return "Whenever you take damage, these potions will automatically restore lost points depending on both its typing and its general level. Low quality variants will heal small amounts while the higher you go, the more that gets restored.";
			else if ( text == "Poison" || text == "poison" )
				return "There are two types when it comes to this area. Potions that cure poison, and those that inflict it. And of course there's varying levels when it comes to how much pain or relief you wanna inflict upon others, or to your own vessel. Know your colors and you will avoid an early trip to the [cathedral].";
			else if ( text == "Cathedral" || text == "cathedral" )
				return "Dawnguard Cathedral is where you'd wanna go should death lay waste upon you. That and there are other areas and means of bringing yourself back into the material realm.";
			else if ( text == "Night vision" || text == "night vision" )
				return "Luckily there's only one potion of this nature but it always gets the job done. It'll allow you to easily traverse through barely lit caves, dark jungles, and it'll make finding your way around much less annoying and tedious without the need for those pesky torches.";
			else if ( text == "Demolition" || text == "demolition" )
				return "Yeah, we're talking full on author Pringle Bay levels of high explosion counts. Once activated you'll have exactly 5 seconds to toss it and you better make sure it hits your target.";

//////////////////////////////////////////////////////////// Inventory
			else if ( text == "Inventory" || text == "inventory" )
				return "I [sell potions] from 1st level and even have this [potion guide] I can lend to you for a small fee.";
			else if ( text == "Sell Potions" || text == "sell potions" )
				return "If you have any potions you'd like to sell then allow me to take them off your hands.";
			else if ( text == "Potion Guide" || text == "potion guide" )
				return "With the exception of those those skill buffering types, all regular potions are unidentified and it requires the user to know there colors if they wanna be able to take advantage of their unique properties.";

//////////////////////////////////////////////////////////// Skill
			else if ( text == "Skill" || text == "skill" )
				return "With enough pocket change, I can train you as an apprentice through either [Alchemy] or [Taste ID].";
			else if ( text == "Alchemy" || text == "alchemy" )
				return "With this skill along with a mortal with pestle and enough reagents and empty bottles to spare you'll be on your way to eventually brewing potions worthy of others short attention spans.";
			else if ( text == "Taste ID" || text == "taste id" )
				return "With this skill you'll know whether that [pizza] lying out in the open of some blokes bakery is legit or whether they're attempting to poison their customers.";
			else if ( text == "Pizza" || text == "pizza" )
				return "Apparently the town baker has been giving out free pizza samples as a means of promoting their [business]. In fact some of the patrons in the community have been doing the same promotion.";
			else if ( text == "Business" || text == "business" )
				return "They say its their way of helping out with the community, but personally I think its nothing more than to try and get back at any criticism for how some of the guards bad [behavior] in the past.";
			else if ( text == "Behavior" || text == "behavior" )
				return "Historically in regards to the town [arena] there have been multiple reports of folks leaving there for not enough time to pass before suddenly being chased and possibly halberd to bits by guards whose moral compass doesn't quite allow for varying shades of gray.";
			else if ( text == "Arena" || text == "arena" )
				return "Outside the city gates lies an area where folks can resolve each others disputes without incurring much penalty. Providing that rules are established between both parties so as to not devolve into mindless savagery and chaos.";

//////////////////////////////////////////////////////////// Bye
			else if ( text == "Bye" || text == "bye" )
				return "Take care and watch your back.";
			else
				return text;
		}

//<*************//Summon Town Guards
		public override void OnHarmfulSpell( Mobile from )
		{
			if( from != null && from.Alive )
			{
			        DoSpecialAbility( from );
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGaveMeleeAttack( attacker );
			DoSpecialAbility( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			DoSpecialAbility( defender );
		}

		public void DoSpecialAbility( Mobile target )
		{
			if ( 0.05 >= Utility.RandomDouble() ) // 5% chance to spawn town guards
                                this.Say("guards");
				SpawnGuards( target );
		}

		public void SpawnGuards( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int red = 0;

			foreach ( Mobile m in this.GetMobilesInRange( 10 ) )
			{
				if ( m is RangerGuardOfSkaddria2 )
					++red;
			}

			if ( red < 5 )
			{
				PlaySound( 0x51A );

				int newblue = Utility.RandomMinMax( 1, 2 );

				for ( int i = 0; i < newblue; ++i )
				{
					BaseCreature yellow = new RangerGuardOfSkaddria2();
					yellow.Team = this.Team;

					bool validLocation = false;
					Point3D loc = this.Location;

					for ( int j = 0; !validLocation && j < 10; ++j )
					{
						int x = X + Utility.Random( 3 ) - 1;
						int y = Y + Utility.Random( 3 ) - 1;
						int z = map.GetAverageZ( x, y );

						if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
							loc = new Point3D( x, y, Z );
						else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
							loc = new Point3D( x, y, z );
					}

					yellow.MoveToWorld( loc, map );
					yellow.Combatant = target;
				}
			}
		}
//<*************//end summon town guards

		#region Bulk Orders
		public override Item CreateBulkOrder( Mobile from, bool fromContextMenu )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm != null && pm.NextAlchemyBulkOrder == TimeSpan.Zero && (fromContextMenu || 0.2 > Utility.RandomDouble()) )
			{
				double theirSkill = pm.Skills[SkillName.Alchemy].Base;

				if ( theirSkill >= 70.1 )
					pm.NextAlchemyBulkOrder = TimeSpan.FromHours( 3.0 );
				else if ( theirSkill >= 50.1 )
					pm.NextAlchemyBulkOrder = TimeSpan.FromHours( 2.0 );
				else
					pm.NextAlchemyBulkOrder = TimeSpan.FromHours( 1.0 );

				return SmallAlchemyBOD.CreateRandomFor( from );
			}

			return null;
		}

		public override bool IsValidBulkOrder( Item item )
		{
			return ( item is SmallAlchemyBOD || item is LargeAlchemyBOD );
		}

		public override bool SupportsBulkOrders( Mobile from )
		{
			return ( from is PlayerMobile && from.Skills[SkillName.Alchemy].Base > 0 );
		}

		public override TimeSpan GetNextBulkOrder( Mobile from )
		{
			if ( from is PlayerMobile )
				return ((PlayerMobile)from).NextAlchemyBulkOrder;

			return TimeSpan.Zero;
		}

		public override void OnSuccessfulBulkOrderReceive( Mobile from )
		{
			if( Core.SE && from is PlayerMobile )
				((PlayerMobile)from).NextAlchemyBulkOrder = TimeSpan.Zero;
		}
		#endregion

		public SkaddriaAlchemist( Serial serial ) : base( serial ) 
		{ 
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new SkaddriaAlchemistEntry( from, this ) );
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

		public class SkaddriaAlchemistEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public SkaddriaAlchemistEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( SkaddriaAlchemistGump ) ) )
					{
						mobile.SendGump( new SkaddriaAlchemistGump( mobile ));
						
					}
				}
			}
		}
        }

	public class SBSkaddriaAlchemist : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSkaddriaAlchemist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Your Trusty Potion Guide", typeof( YourTrustyPotionGuide ), 50, 100, 0xFBD, 0 ) );

				Add( new GenericBuyInfo( typeof( HeatingStand ), 100, 100, 0x1849, 0 ) ); 
				Add( new GenericBuyInfo( typeof( MortarPestle ), 100, 100, 0xE9B, 0 ) );

				Add( new GenericBuyInfo( typeof( AgilityPotion ), 200, 100, 0xF08, 0 ) );
				Add( new GenericBuyInfo( "Teal Potion", typeof( MindPotion ), 200, 100, 0xF04, 1173 ) );
				Add( new GenericBuyInfo( typeof( StrengthPotion ), 200, 100, 0xF09, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 200, 100, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( "Lesser Sky Blue Potion", typeof( LesserManaPotion ), 300, 100, 0xF03, 1266 ) );

 				Add( new GenericBuyInfo( typeof( LesserCurePotion ), 200, 100, 0xF07, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserExplosionPotion ), 200, 100, 0xF0D, 0 ) );
				Add( new GenericBuyInfo( "Lesser Ice Blue Potion", typeof( LesserShatterPotion ), 200, 100, 0xF0D, 1152 ) );
				Add( new GenericBuyInfo( "Lesser Magenta Potion", typeof( LesserLightningPotion ), 200, 100, 0xF0D, 23 ) );
				Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 200, 100, 0xF0A, 0 ) );
				Add( new GenericBuyInfo( "Lesser Toxic Potion", typeof( LesserToxicPotion ), 700, 100, 0xF0D, 64 ) );

				Add( new GenericBuyInfo( typeof( NightSightPotion ), 200, 100, 0xF06, 0 ) );
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 200, 100, 0xF0B, 0 ) );

////////////////////////////////////////////////////// Novice Combat Potions
				Add( new GenericBuyInfo( "Novice Potion Of Archery", typeof( NovicePotionOfArchery ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Fencing", typeof( NovicePotionOfFencing ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Mace Fighting", typeof( NovicePotionOfMaceFighting ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Magery", typeof( NovicePotionOfMagery ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Parry", typeof( NovicePotionOfParry ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Swordsmanship", typeof( NovicePotionOfSwordsmanship ), 100, 100, 0xE29, 45 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Wrestling", typeof( NovicePotionOfWrestling ), 100, 100, 0xE29, 45 ) );

////////////////////////////////////////////////////// Novice Crafting Potions
				Add( new GenericBuyInfo( "Novice Potion Of Alchemy", typeof( NovicePotionOfAlchemy ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Blacksmithy", typeof( NovicePotionOfBlacksmithy ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Mace Fighting", typeof( NovicePotionOfCarpentry ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Magery", typeof( NovicePotionOfCooking ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Parry", typeof( NovicePotionOfFletching ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Swordsmanship", typeof( NovicePotionOfInscription ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Wrestling", typeof( NovicePotionOfTailoring ), 100, 100, 0xE29, 60 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Tinkering", typeof( NovicePotionOfTinkering ), 100, 100, 0xE29, 60 ) );

////////////////////////////////////////////////////// Novice Misc Potions
				Add( new GenericBuyInfo( "Novice Potion Of Animal Taming", typeof( NovicePotionOfAnimalTaming ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Discordance", typeof( NovicePotionOfDiscordance ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Fishing", typeof( NovicePotionOfFishing ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Herding", typeof( NovicePotionOfHerding ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Hiding", typeof( NovicePotionOfHiding ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Lumberjacking", typeof( NovicePotionOfLumberjacking ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Magic Resist", typeof( NovicePotionOfMagicResist ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Mining", typeof( NovicePotionOfMining ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Peacemaking", typeof( NovicePotionOfPeacemaking ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Poisoning", typeof( NovicePotionOfPoisoning ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Provocation", typeof( NovicePotionOfProvocation ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Snooping", typeof( NovicePotionOfSnooping ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Stealing", typeof( NovicePotionOfStealing ), 100, 100, 0xE29, 285 ) );
				Add( new GenericBuyInfo( "Novice Potion Of Veterinary", typeof( NovicePotionOfVeterinary ), 100, 100, 0xE29, 285 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( GreaterAgilityPotion ), 700 );
				Add( typeof( GreaterCurePotion ), 700 );
				Add( typeof( GreaterExplosionPotion ), 700 );
				Add( typeof( GreaterHealPotion ), 700 );
				Add( typeof( GreaterLightningPotion ), 700 );
				Add( typeof( GreaterManaPotion ), 700 );
				Add( typeof( GreaterMindPotion ), 700 );
				Add( typeof( GreaterPoisonPotion ), 700 );
				Add( typeof( GreaterShatterPotion ), 700 );
				Add( typeof( GreaterStrengthPotion ), 700 );

				Add( typeof( CurePotion ), 300 );
				Add( typeof( ExplosionPotion ), 300 );
				Add( typeof( HealPotion ), 300 );
				Add( typeof( LightningPotion ), 300 );
				Add( typeof( ManaPotion ), 300 );
				Add( typeof( PoisonPotion ), 300 );
				Add( typeof( ShatterPotion ), 300 );

				Add( typeof( AgilityPotion ), 50 );
				Add( typeof( LesserCurePotion ), 50 );
				Add( typeof( LesserExplosionPotion ), 50 );
				Add( typeof( LesserHealPotion ), 50 );
				Add( typeof( LesserLightningPotion ), 50 );
				Add( typeof( LesserManaPotion ), 50 );
				Add( typeof( LesserPoisonPotion ), 50 );
				Add( typeof( LesserShatterPotion ), 50 );
				Add( typeof( MindPotion ), 50 );
				Add( typeof( NightSightPotion ), 50 );
				Add( typeof( RefreshPotion ), 50 );
				Add( typeof( StrengthPotion ), 50 );

				Add( typeof( NovicePotionOfArchery ), 50 );
				Add( typeof( NovicePotionOfFencing ), 50 );
				Add( typeof( NovicePotionOfMaceFighting ), 50 );
				Add( typeof( NovicePotionOfMagery ), 50 );
				Add( typeof( NovicePotionOfParry ), 50 );
				Add( typeof( NovicePotionOfSwordsmanship ), 50 );
				Add( typeof( NovicePotionOfWrestling ), 50 );

				Add( typeof( NovicePotionOfAlchemy ), 50 );
				Add( typeof( NovicePotionOfBlacksmithy ), 50 );
				Add( typeof( NovicePotionOfCarpentry ), 50 );
				Add( typeof( NovicePotionOfCooking ), 50 );
				Add( typeof( NovicePotionOfFletching ), 50 );
				Add( typeof( NovicePotionOfInscription ), 50 );
				Add( typeof( NovicePotionOfTailoring ), 50 );
				Add( typeof( NovicePotionOfTinkering ), 50 );

				Add( typeof( NovicePotionOfAnimalTaming ), 50 );
				Add( typeof( NovicePotionOfDiscordance ), 50 );
				Add( typeof( NovicePotionOfFishing ), 50 );
				Add( typeof( NovicePotionOfHerding ), 50 );
				Add( typeof( NovicePotionOfHiding ), 50 );
				Add( typeof( NovicePotionOfLumberjacking ), 50 );
				Add( typeof( NovicePotionOfMagicResist ), 50 );
				Add( typeof( NovicePotionOfMining ), 50 );

				Add( typeof( NovicePotionOfPeacemaking ), 50 );
				Add( typeof( NovicePotionOfPoisoning ), 50 );
				Add( typeof( NovicePotionOfProvocation ), 50 );
				Add( typeof( NovicePotionOfSnooping ), 50 );
				Add( typeof( NovicePotionOfStealing ), 50 );
				Add( typeof( NovicePotionOfVeterinary ), 50 );

				Add( typeof( HeatingStand ), 50 );
				Add( typeof( MortarPestle ), 50 );

				Add( typeof( Bone ), 2 ); 
				Add( typeof( RibCage ), 5 ); 
				Add( typeof( BonePile ), 10 );  
			}
		}
	 }

         public class SkaddriaAlchemistGump : Gump 
         { 
                public static void Initialize() 
                { 
                     CommandSystem.Register( "SkaddriaAlchemistGump", AccessLevel.GameMaster, new CommandEventHandler( SkaddriaAlchemistGump_OnCommand ) ); 
                } 

                private static void SkaddriaAlchemistGump_OnCommand( CommandEventArgs e ) 
                { 
                     e.Mobile.SendGump( new SkaddriaAlchemistGump( e.Mobile ) ); 
                } 

                public SkaddriaAlchemistGump( Mobile owner ) : base( 50,50 ) 
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
			this.AddHtml( 157, 181, 345, 279, "G'day to you and welcome to the Magician's Corner. Your number one pit stop when it comes to potions out the gizzards feathery arse.<BR><BR><I><BASEFONT COLOR=#0099FF>Profession<BR><BR>Inventory<BR><BR>Skill<BR><BR>Bye</BASEFONT COLOR></I>", false, true);

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