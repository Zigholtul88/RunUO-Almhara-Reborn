using System;
using System.Text;
using Server.Commands;
using Server.Gumps;
using Server.Items; 
using Server.Mobiles; 
using Server.Network;
using Server.Targeting;

namespace Server.Gumps
{
	public class SexChoiceGump : Gump
	{			
		public SexChoiceGump() : base( 0, 0 )
		{
			this.Closable = false;
			this.Disposable = true;
			this.Dragable = true;
			this.Resizable = false;

			this.AddPage( 0 );
			this.AddBackground( 28, 9, 385, 458, 9270 );
			this.AddImage( 30, 19, 5557, 0 );
			this.AddButton( 80, 140, 55, 56, (int)Buttons.Button1, GumpButtonType.Reply, 0 );
			this.AddButton( 80, 180, 55, 56, (int)Buttons.Button2, GumpButtonType.Reply, 0 );
			this.AddButton( 80, 220, 55, 56, (int)Buttons.Button3, GumpButtonType.Reply, 0 );
			this.AddLabel( 125, 69, 36, @"Choose Your Gender" );
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			this.AddLabel( 100, 140, 0, @"Male" );
			this.AddLabel( 100, 170, 0, @"Female" );
			this.AddLabel( 100, 220, 0, @"Other" );
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		}
			
		public enum Buttons
		{
			Close,
			Button1,
			Button2,
			Button3,
			Button4,
			Button5,
		}
			
		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile m = sender.Mobile;
			PlayerMobile player = m as PlayerMobile;
			
			if ( m == null )
				return;
			switch ( info.ButtonID )
			{
				case 0:
				{
			                m.Hunger = 20;
			                m.Thirst = 20;

					m.SendMessage( 0x26, "You seem to be comfortable with yourself." );
				        m.CloseGump( typeof( SexChoiceGump ) );
				        m.SendGump( new RaceChoiceGump() );

					return;
				}

				case 1:
				{
			                m.Hunger = 20;
			                m.Thirst = 20;

			                m.BodyValue = 400;
                        		m.Female = false;
					m.SendMessage( 0x26, "You have chosen to become a male." );
				        m.CloseGump( typeof( SexChoiceGump ) );
				        m.SendGump( new RaceChoiceGump() );
					break;
				}

				case 2:
				{
			                m.Hunger = 20;
			                m.Thirst = 20;

			                m.BodyValue = 401;
                        		m.Female = true;
					m.SendMessage( 0x26, "You have chosen to become a female." );
				        m.CloseGump( typeof( SexChoiceGump ) );
				        m.SendGump( new RaceChoiceGump() );
					break;
				}
				case 3:
				{
                                        m.BankBox.DropItem( new BankCheck( 5000 ) );
                                        m.BankBox.DropItem( new Watermelon( 500 ) );

                                        player.Profession = 666;
                                        player.Level = 1;
                                        player.Exp = 0;
                                        player.KillExp = 0;
                                        player.LevelAt = 200;

					m.Kills = 0;

                                        m.Title = "the Running Pants";
		                        m.EquipItem( new YoureFuckedTalisman() );

                                        m.StatCap = 1500;
                                        m.SkillsCap = 50000;
                                        m.Str = 10;
                                        m.Dex = 10;
                                        m.Int = 10;

                                        m.Hunger = 20;
                                        m.Thirst = 20;

                                        m.Fame -= 50000;
                                        m.Karma -= 50000;

                                        m.FollowersMax = 100;

		                        ResistanceMod mod1 = new ResistanceMod( ResistanceType.Physical, - 50 );
		                        ResistanceMod mod2 = new ResistanceMod( ResistanceType.Fire, - 50 );
		                        ResistanceMod mod3 = new ResistanceMod( ResistanceType.Cold, - 50 );
		                        ResistanceMod mod4 = new ResistanceMod( ResistanceType.Poison, - 50 );
		                        ResistanceMod mod5 = new ResistanceMod( ResistanceType.Energy, - 50 );

		                        m.AddResistanceMod( mod1 );
		                        m.AddResistanceMod( mod2 );
		                        m.AddResistanceMod( mod3 );
		                        m.AddResistanceMod( mod4 );
		                        m.AddResistanceMod( mod5 );

                                        m.Skills.Alchemy.Base = 0;
                                        m.Skills.Anatomy.Base = 0;
                                        m.Skills.AnimalLore.Base = 0;
                                        m.Skills.AnimalTaming.Base = 0;
                                        m.Skills.Archery.Base = 0;
                                        m.Skills.ArmsLore.Base = 0;
                                        m.Skills.Begging.Base = 0;
                                        m.Skills.Blacksmith.Base = 0;
                                        m.Skills.Camping.Base = 0;
                                        m.Skills.Carpentry.Base = 0;
                                        m.Skills.Cartography.Base = 0;
                                        m.Skills.Cooking.Base = 0;
                                        m.Skills.DetectHidden.Base = 0;
                                        m.Skills.Discordance.Base = 0;
                                        m.Skills.EvalInt.Base = 0;
                                        m.Skills.Fishing.Base = 0;
                                        m.Skills.Fencing.Base = 0;
                                        m.Skills.Fletching.Base = 0;
                                        m.Skills.Focus.Base = 0;
                                        m.Skills.Forensics.Base = 0;
                                        m.Skills.Healing.Base = 0;
                                        m.Skills.Herding.Base = 0;
                                        m.Skills.Hiding.Base = 0;
                                        m.Skills.Inscribe.Base = 0;
                                        m.Skills.ItemID.Base = 0;
                                        m.Skills.Lockpicking.Base = 0;
                                        m.Skills.Lumberjacking.Base = 0;
                                        m.Skills.Macing.Base = 0;
                                        m.Skills.Magery.Base = 0;
                                        m.Skills.MagicResist.Base = 10;
                                        m.Skills.Meditation.Base = 0;
                                        m.Skills.Mining.Base = 0;
                                        m.Skills.Musicianship.Base = 0;
                                        m.Skills.Parry.Base = 0;
                                        m.Skills.Peacemaking.Base = 0;
                                        m.Skills.Poisoning.Base = 0;
                                        m.Skills.Provocation.Base = 0;
                                        m.Skills.RemoveTrap.Base = 0;
                                        m.Skills.Snooping.Base = 0;
                                        m.Skills.SpiritSpeak.Base = 0;
                                        m.Skills.Stealing.Base = 0;
                                        m.Skills.Stealth.Base = 0;
                                        m.Skills.Swords.Base = 0;
                                        m.Skills.Tactics.Base = 0;
                                        m.Skills.Tailoring.Base = 0;
                                        m.Skills.TasteID.Base = 0;
                                        m.Skills.Tinkering.Base = 0;
                                        m.Skills.Tracking.Base = 0;
                                        m.Skills.Veterinary.Base = 0;
                                        m.Skills.Wrestling.Base = 0;
                                        m.Skills.Chivalry.Base = 0;
                                        m.Skills.Necromancy.Base = 0;
                                        m.Skills.Bushido.Base = 0;
                                        m.Skills.Ninjitsu.Base = 0;
                                        m.Skills.Spellweaving.Base = 0;

                                        m.PlaySound( 0x61F ); // wilhelm scream

		                        m.Map = Map.Malas;
                                        m.Location = new Point3D(1825, 1020, 50);
		                        m.FixedEffect( 0x376A, 10, 16 );

                                        World.Broadcast( 0x35, true, string.Format( "{0} is permanently cursed as a pair of running pants because life wasn't already difficult enough!", m.Name ) );

					m.SendMessage( 0x26, "You have chosen to remain genderless and as a result have been turned into a pair of pants." );

				        m.CloseGump( typeof( SexChoiceGump ) );
					break;
				}
			}
		}
	}
}