using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "corpse of the town crier" )]
	public class HammerhillTownCrier : BaseCreature
	{
		private Mobile m_ListeningTo;
		private string m_LastSaid;
		private string m_LastHeard;

		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public HammerhillTownCrier() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.1, 0.2 )
		{
			Name = "Beta-Titan Z21";
			Title = "the Hammerhill Town Crier";
			SpeechHue = Utility.RandomDyedHue();
			Body = 752;

			m_ListeningTo = null;
			m_LastSaid = null;
			m_LastHeard = null;

			SetStr( 50, 500 );
			SetDex( 50, 500 );
			SetInt( 50, 500 );

			SetHits( 1000 );
			SetMana( 10000 );

			SetDamage( 1, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10 );
			SetResistance( ResistanceType.Fire, 10, 70 );
			SetResistance( ResistanceType.Cold, 10, 70 );
			SetResistance( ResistanceType.Poison, 10, 70 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.Anatomy, 10.0, 80.0 );
			SetSkill( SkillName.MagicResist, 10.0, 80.0 );
			SetSkill( SkillName.Tactics, 10.0, 80.0 );
			SetSkill( SkillName.Wrestling, 10.0, 80.0 );
			SetSkill( SkillName.EvalInt, 10.0, 80.0 );
			SetSkill( SkillName.Magery, 80.0, 100.0 );

			Fame = 1000;
			Karma = -1000;

			switch ( Utility.Random( 9 ))
			{
				case 0: PackItem( new FancyShirt() ); break;
				case 1: PackItem( new Surcoat() ); break;
				case 2: PackItem( new BearMask() ); break;
				case 3: PackItem( new DeerMask() ); break;
				case 4: PackItem( new TribalMask() ); break;
				case 5: PackItem( new JesterSuit() ); break;
				case 6: PackItem( new JesterHat() ); break;
				case 7: PackItem( new Kilt() ); break;
				case 8: PackItem( new ThighBoots() ); break;
			}

			switch ( Utility.Random( 10 ))
			{
				case 0: PackItem( new WoodenChair() ); break;
				case 1: PackItem( new SmallUrn() ); break;
				case 2: PackItem( new LargeVase() ); break;
				case 3: PackItem( new ShortMusicStand() ); break;
				case 4: PackItem( new BarrelLid() ); break;
				case 5: PackItem( new FootStool() ); break;
				case 6: PackItem( new PlainLowTable() ); break;
				case 7: PackItem( new Nightstand() ); break;
				case 8: PackItem( new SmallTowerSculpture() ); break;
				case 9: PackItem( new StatuePegasus() ); break;
			}

			switch ( Utility.Random( 4 ))
			{
				case 0: PackItem( new BarkeepContract() ); break;
				case 1: PackItem( new ClothingBlessDeed() ); break;
				case 2: PackItem( new HairRestylingDeed() ); break;
				case 3: PackItem( new VendorRentalContract() ); break;
			}

			switch ( Utility.Random( 10 ))
			{
				case 0: PackItem( new CheckerBoard() ); break;
				case 1: PackItem( new Chessboard() ); break;
				case 2: PackItem( new FishingPole() ); break;
				case 3: PackItem( new SturdyShovel() ); break;
				case 4: PackItem( new Log() ); break;
				case 5: PackItem( new BambooFlute() ); break;
				case 6: PackItem( new Scissors() ); break;
				case 7: PackItem( new Spyglass() ); break;
				case 8: PackItem( new Globe() ); break;
				case 9: PackItem( new Skillet() ); break;
			}

			PackItem( new LesserExplosionPotion() );
			PackItem( new LesserExplosionPotion() );
			PackItem( new LesserExplosionPotion() );
			PackItem( new LesserExplosionPotion() );
			PackItem( new LesserExplosionPotion() );

			PackItem( new Spear() );
			PackItem( new Spear() );
			PackItem( new Spear() );
			PackItem( new Spear() );
			PackItem( new Spear() );
		}

		public override bool CanRummageCorpses{ get{ return true; } }

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			damage = damage / 10;
		}

		public override void AlterSpellDamageFrom( Mobile from, ref int damage )
		{
			damage = damage / 10;
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
			if ( text == "Hammerhill" || text == "hammerhill" )
				return "You are already here.";
			else if ( text == "Elmhaven" || text == "elmhaven" )
				return "Leave from the north gate, then follow the dirt trail all the way north.";
			else if ( text == "Old Plunderers Haven" || text == "old plunderers haven" )
				return "Leave from the south gate, then follow the dirt trail line without breaking out among branching paths. Once you've made it past the manor and reach a split in the road go south. Keep going south and you should reach the settlement once you've noticed the camp guards.";
			else if ( text == "Elandrim Nur Shaz" || text == "elandrim nur shaz" )
				return "Leave from the north gate, follow the dirt trail all the way north until you've reached Alytharr Taven and then go west. Follow the trail past 2 bridges before reaching your destination.";
			else if ( text == "Guardians Horizon" || text == "guardians horizon" )
				return "From Old Plunderers Haven, head for the nearest bridge and make your way south until you've reached a small shrine. Go through the moongate before arriving at your destination.";
			else if ( text == "Covens Landing" || text == "covens landing" )
				return "Leave from the north gate, then keep going north, past Zaythalor Tavern until you've reached a steep hill. Go through the moongate, then proceed north-east down the trail before reaching town.";
			else if ( text == "Red Dagger Keep" || text == "red dagger keep" )
				return "From Guardians Horizon, just go north. That's basically it.";
			else if ( text == "Fuck You" || text == "fuck you" || text == "Fuck you parrot" || text == "Fuck you, parrot." || text == "Fuck you!" || text == "Fuck you parrot!" || text == "Fuck you, parrot!" )
				return "Insult me again you pussy!";
			else if ( text == "bitch" || text == "Bitch" || text == "cunt" || text == "Cunt" || text == "faggot" || text == "Faggot" || text == "hitler" || text == "Hitler" || text == "ass" || text == "Ass" || text == "asshole" || text == "Asshole" || text == "bastard" || text == "Bastard" || text == "uncle fucker" || text == "Uncle Fucker" || text == "cocksucker" || text == "Cocksucker" || text == "pussy" || text == "Pussy" || text == "homo" || text == "Homo" || text == "justin beiber" || text == "Justin Beiber" || text == "dick" || text == "Dick" || text == "die" || text == "die!" || text == "suck my dick" || text == "Suck my dick" || text == "Suck My Dick" || text == "Suck my dick!" || text == "nigger" || text == "Nigger" || text == "nigga" || text == "Nigga" || text == "pussy" || text == "Pussy")
			{
				return "Okay you bastard, its on now!";
				this.Combatant = from;
				from.Combatant = this;
			}
			else
				return text;
		}

		public HammerhillTownCrier( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new HammerhillTownCrierEntry( from, this ) );
		}

		public class HammerhillTownCrierEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public HammerhillTownCrierEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( AlmharaTownCrierGump ) ) )
					{
						mobile.SendGump( new AlmharaTownCrierGump( mobile ));
						
					}
				}
			}
		}

		public override int GetIdleSound() { return 542; }
		public override int GetAttackSound() { return 562; }
		public override int GetAngerSound() { return 541; }
		public override int GetHurtSound() { return 320; }
		public override int GetDeathSound() { return 545; }

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
}
