using System;
using System.Text;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class LetterToCecilia : Item
	{
		public override string DefaultName
		{
			get { return "Letter To Cecilia"; }
		}

		[Constructable]
		public LetterToCecilia() : base( 0x14EE )
		{
			Weight = 1.0;
			LootType = LootType.Blessed;
		}

		public LetterToCecilia( Serial serial ) : base( serial )
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
				from.CloseGump( typeof( LetterToCeciliaGump ) );
				from.SendGump( new LetterToCeciliaGump( from ) );
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}
      }

   public class LetterToCeciliaGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "LetterToCeciliaGump", AccessLevel.GameMaster, new CommandEventHandler( LetterToCeciliaGump_OnCommand ) ); 
      } 

      private static void LetterToCeciliaGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new LetterToCeciliaGump( e.Mobile ) ); 
      } 

      public LetterToCeciliaGump( Mobile owner ) : base( 50,50 ) 
      { 
//----------------------------------------------------------------------------------------------------

				AddPage( 0 );
			AddImageTiled(  54, 33, 369, 400, 2624 );
			AddAlphaRegion( 54, 33, 369, 400 );

			AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
			
			AddImage( 97, 49, 9005 );
			AddImageTiled( 58, 39, 29, 390, 10460 );
			AddImageTiled( 412, 37, 31, 389, 10460 );
			AddLabel( 140, 60, 0x34, "Letter to Cecilia" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Oh Cecilia my beloved, I do wish I can <BR>" +
"<BASEFONT COLOR=YELLOW>embrace your presence yet again.<BR>" +
"<BASEFONT COLOR=YELLOW>Hammerhill is still rebuilding from the<BR>" +
"<BASEFONT COLOR=YELLOW>war that was caused by outside forces <BR>" +
"<BASEFONT COLOR=YELLOW>involving a band of evil mages and <BR>" +
"<BASEFONT COLOR=YELLOW>their cohorts. I'm recovering from an <BR>" +
"<BASEFONT COLOR=YELLOW>attack received from a vicious fire<BR>" +
"<BASEFONT COLOR=YELLOW>elemental and it nearly burnt my arm <BR>" +
"<BASEFONT COLOR=YELLOW>off. I pray to the gods above that my <BR>" +
"<BASEFONT COLOR=YELLOW>luck won't run out and I can in due <BR>" +
"<BASEFONT COLOR=YELLOW>time make it back to Elmhaven where I<BR>" +
"<BASEFONT COLOR=YELLOW>can gaze upon your lovely visage.<BR>" +

"</BODY>", false, true);
			
//			<BASEFONT COLOR=#7B6D20>			

			AddImage( 430, 9, 10441);
			AddImageTiled( 40, 38, 17, 391, 9263 );
			AddImage( 6, 25, 10421 );
			AddImage( 34, 12, 10420 );
			AddImageTiled( 94, 25, 342, 15, 10304 );
			AddImageTiled( 40, 427, 415, 16, 10304 );
			AddImage( -10, 314, 10402 );
			AddImage( 56, 150, 10411 );
			AddImage( 155, 120, 2103 );
			AddImage( 136, 84, 96 );

			AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); 

//--------------------------------------------------------------------------------------------------------------
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
