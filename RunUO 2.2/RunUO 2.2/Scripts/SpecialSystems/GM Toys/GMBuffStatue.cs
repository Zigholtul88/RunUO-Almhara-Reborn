using System;
using System.Text;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class GMBuffStatue : Item
	{
		public override string DefaultName
		{
			get { return "A My Little Pony Statue"; }
		}

		[Constructable]
		public GMBuffStatue() : base( 0x3FFE )
		{
                        Movable = true;
			Weight = 5.0;
			LootType = LootType.Blessed;
		}

		public GMBuffStatue( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				from.CloseGump( typeof( GMBuffStatueWarningGump ) );
				from.SendGump( new GMBuffStatueWarningGump( from ) );
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}
        }

	public class GMBuffStatueWarningGump : Gump
	{
		public GMBuffStatueWarningGump( Mobile m): base( 0, 0 )
		{
			this.Closable=false;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
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
			this.AddLabel(282, 151, 1153, @"Summon My Little Pony!");
			this.AddButton(226, 469, 247, 248, 0, GumpButtonType.Reply, 0);
			this.AddButton(351, 469, 241, 242,  1, GumpButtonType.Reply, 0);
			this.AddHtml( 157, 181, 345, 279, "This statue when used will buff your skills up to insane levels.<br><br><i>Seriously it will.</i><br><br>Are you sure you want to commit?", false, true);
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile m = state.Mobile;

			switch( info.ButtonID )
			{
				case 0:
				{
			            Item a = m.Backpack.FindItemByType( typeof( GMBuffStatue ) );
			            if ( a != null )

				        a.Delete();

                                        m.Str = 100;
                                        m.Dex = 100;
                                        m.Int = 100;

                                        m.Hits = 500;
                                        m.Stam = 500;
                                        m.Mana = 500;

                                        m.Skills.Alchemy.Base = 500;
                                        m.Skills.Anatomy.Base = 500;
                                        m.Skills.AnimalLore.Base = 500;
                                        m.Skills.AnimalTaming.Base = 500;
                                        m.Skills.Archery.Base = 500;
                                        m.Skills.ArmsLore.Base = 500;
                                        m.Skills.Begging.Base = 500;
                                        m.Skills.Blacksmith.Base = 500;
                                        m.Skills.Camping.Base = 500;
                                        m.Skills.Carpentry.Base = 500;
                                        m.Skills.Cartography.Base = 500;
                                        m.Skills.Cooking.Base = 500;
                                        m.Skills.DetectHidden.Base = 500;
                                        m.Skills.Discordance.Base = 500;
                                        m.Skills.EvalInt.Base = 500;
                                        m.Skills.Fishing.Base = 500;
                                        m.Skills.Fencing.Base = 500;
                                        m.Skills.Fletching.Base = 500;
                                        m.Skills.Focus.Base = 500;
                                        m.Skills.Forensics.Base = 500;
                                        m.Skills.Healing.Base = 500;
                                        m.Skills.Herding.Base = 500;
                                        m.Skills.Hiding.Base = 500;
                                        m.Skills.Inscribe.Base = 500;
                                        m.Skills.ItemID.Base = 500;
                                        m.Skills.Lockpicking.Base = 500;
                                        m.Skills.Lumberjacking.Base = 500;
                                        m.Skills.Macing.Base = 500;
                                        m.Skills.Magery.Base = 500;
                                        m.Skills.MagicResist.Base = 500;
                                        m.Skills.Meditation.Base = 500;
                                        m.Skills.Mining.Base = 500;
                                        m.Skills.Musicianship.Base = 500;
                                        m.Skills.Parry.Base = 500;
                                        m.Skills.Peacemaking.Base = 500;
                                        m.Skills.Poisoning.Base = 500;
                                        m.Skills.Provocation.Base = 500;
                                        m.Skills.RemoveTrap.Base = 500;
                                        m.Skills.Snooping.Base = 500;
                                        m.Skills.SpiritSpeak.Base = 500;
                                        m.Skills.Stealing.Base = 500;
                                        m.Skills.Stealth.Base = 500;
                                        m.Skills.Swords.Base = 500;
                                        m.Skills.Tactics.Base = 500;
                                        m.Skills.Tailoring.Base = 500;
                                        m.Skills.TasteID.Base = 500;
                                        m.Skills.Tinkering.Base = 500;
                                        m.Skills.Tracking.Base = 500;
                                        m.Skills.Veterinary.Base = 500;
                                        m.Skills.Wrestling.Base = 500;
                                        m.Skills.Chivalry.Base = 500;
                                        m.Skills.Necromancy.Base = 500;
                                        m.Skills.Bushido.Base = 500;
                                        m.Skills.Ninjitsu.Base = 500;
                                        m.Skills.Spellweaving.Base = 500;

                                        m.AddToBackpack( new Spellbook( UInt64.MaxValue ) );
                                        m.AddToBackpack( new NecromancerSpellbook( (UInt64)0xFFFF ) );
                                        m.AddToBackpack( new BookOfChivalry( (UInt64)0x3FF ) );
                                        m.AddToBackpack( new BookOfBushido() );	//Default ctor = full
                                        m.AddToBackpack( new BookOfNinjitsu() ); //Default ctor = full
                                        m.AddToBackpack( new BagOfAllReagents( 5000 ) );

           		                m.FixedParticles( 0x373A, 10, 15, 5036, EffectLayer.Head ); 
               		                m.PlaySound( 521 );
               		                m.SendMessage( "You summon a my little pony." );
					m.CloseGump( typeof( GMBuffStatueWarningGump ) );

					break;
				}
				case 1:
				{
					m.SendMessage( "You decide that you'd rather forgo getting a my little pony." );
					m.CloseGump( typeof( GMBuffStatueWarningGump ) );

					break;
				}
			}
		}
	}
}