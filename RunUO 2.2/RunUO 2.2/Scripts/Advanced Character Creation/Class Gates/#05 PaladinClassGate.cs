using System;
using System.Text;
using Server.Commands;
using Server.Gumps;
using Server.Items; 
using Server.Mobiles; 
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
      public class PaladinClassGate : Item
      {
                [Constructable]
                public PaladinClassGate() : base(0xF6C)
                {
	                Movable = false;
	                Light = LightType.Circle300;
	                Name = "Paladin Class Gate"; 
                }

                public PaladinClassGate(Serial serial) : base(serial)
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

                public override bool OnMoveOver( Mobile m ) 
                { 
                        if ( m.Female == false )
                        {
				m.CloseGump( typeof( PaladinClassGump ) );
				m.SendGump( new PaladinClassGump( m ) );

                                return false; //Changed this to false
                        }
                        else if ( m.Female == true )
                        {
				m.CloseGump( typeof( PaladinClassGump ) );
				m.SendGump( new PaladinClassGump( m ) );

                                return false; //Changed this to false
                        }
                        else 
                        { 
                                return false; //Changed this to false
                        } 
                }
        } 

	public class PaladinClassGump : Gump
	{
		public PaladinClassGump( Mobile m ): base( 0, 0 )
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
			this.AddLabel(282, 151, 1153, @"Way of the Paladin!");
			this.AddButton(226, 469, 247, 248, 0, GumpButtonType.Reply, 0);
			this.AddButton(351, 469, 241, 242,  1, GumpButtonType.Reply, 0);
			this.AddHtml( 157, 181, 345, 279, "Proceed through this portal if you seek on joining the ways of the Paladin.<br><br><i>Once you've made your selection, you will be drawn to the outside gates of this island and thus will be unable to return.</i><br><br>Are you sure you want to commit?", false, true);
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;
			PlayerMobile player = from as PlayerMobile;

			switch( info.ButtonID )
			{
				case 0:
				{
                                        player.Profession = 5;
                                        player.Level = 1;
                                        player.Exp = 0;
                                        player.KillExp = 0;
                                        player.LevelAt = 200;

                                        from.BankBox.DropItem( new BankCheck( 500 ) );

                                        from.Str += 25;
                                        from.Dex += 5;
                                        from.Int += 20;

                                        from.Skills.Chivalry.Base = 50;
                                        from.Skills.Focus.Base = 10;
                                        from.Skills.Swords.Base = 50;
                                        from.Skills.Tactics.Base = 25;

					Spellbook book = new BookOfChivalry( (ulong)0x3FF );
					book.LootType = LootType.Blessed;
					from.BankBox.DropItem( book );

		                        from.Map = Map.Malas;
                                        from.Location = new Point3D( 1670, 2008, 1 );
		                        from.PlaySound( 0x214 );
		                        from.FixedEffect( 0x376A, 10, 16 );

                                        World.Broadcast( 0x35, true, "Another has chosen thy path of the Paladin!" );
					from.CloseGump( typeof( PaladinClassGump ) );

					break;
				}
				case 1:
				{
					from.SendMessage( "You decide that the way of the Paladin is not in your best interests." );
					from.CloseGump( typeof( PaladinClassGump ) );

					break;
				}
			}
		}
	}
}