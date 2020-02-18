/* 
	script by zerodowned
	credits to: Murzin's Hearthstone script, Peoharen's SelfDeletingItem script (part of the Mobile Abilities Package), and Soteric for help on Script Support boards - pointed out that I forgot to use ": base()" in the Constructable.

	Info: If you change the timer on this make sure that the timer on Line 24, and 112, and 123 match. 
*/

using System; 
using Server; 
using Server.Mobiles;
using Server.Items;
using Server.Regions;

namespace Server.Items 
{ 
	public class HalfLifeBow : CompositeBow
	{
	public override int InitMinHits{ get{ return 255; } }
	public override int InitMaxHits{ get{ return 255; } }
		

		// Initiate the starting variables to be used
		private DateTime i_halflife;
		private static readonly TimeSpan delay = TimeSpan.FromMinutes( 30 );
		private Timer halflifetimer;
		private Mobile m;
		private Item i;

		// Setup the GM access/viewable variables for the item
		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime lastused
		{
			get{ return i_halflife; }
			set{ i_halflife = value; }
		}
		
		// starting the item itself
		[Constructable]
		public HalfLifeBow() : base()
		{
			Name = "Half Life Bow";
			Hue = 2711;
			Attributes.WeaponDamage = 40;
			Attributes.WeaponSpeed = 20;
                        WeaponAttributes.HitLeechHits = 25;
                        WeaponAttributes.HitLeechMana = 40;
                        WeaponAttributes.HitFireball = 35;
                        WeaponAttributes.SelfRepair = 5;
			Attributes.SpellChanneling = 1;
			Attributes.CastSpeed = 1;
			Attributes.Luck = 20;
			Attributes.RegenMana = 5;
			Attributes.SpellDamage = 15;
		} 
		
		private void Expire()
		{
			if ( Deleted )
				return;

			Delete();
			m.SendMessage( "The bow turns to dust" );
		}

		// this controls the list you see when you mouse-over the item
		public override void AddNameProperty( ObjectPropertyList list )
		{
			// make sure the normal mouse-over props show up
			base.AddNameProperty( list );

			// initial variables for use only inside the property list
			TimeSpan timetouse = ( ( this.lastused + Server.Items.HalfLifeBow.delay) - DateTime.Now );
			string lisths;

			// determine the info the timer display shows
			if ( timetouse.Minutes > 0 )
			{
				int min = timetouse.Minutes;
				lisths = String.Format( "{0} minutes.", min.ToString() );
			}
			else if ( timetouse.Seconds > 0 )
			{
				int sec = timetouse.Seconds;
				lisths = String.Format( "{0} seconds.", sec.ToString() );
			}
			else
			{
				lisths = ( "<BASEFONT COLOR=#00FF00>Dormant<BASEFONT COLOR=#FFFFFF>" ); //FFFFFF
			}

			// adding the timer to the property list
			list.Add( "<BASEFONT COLOR=#00FF00>Half Life Remaining: {0}<BASEFONT COLOR=#FFFFFF>", lisths ); //FFFFFF

			// because we do not want the server spamming updates, slow down how fast the mouse-over info refreshes
			Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerCallback( InvalidateProperties ) );
		}

		public override bool OnEquip( Mobile from ) 
		{
			i = this;
			m = from;
			
			if ( ( this.lastused + Server.Items.HalfLifeBow.delay ) > DateTime.Now ) //check if timer is already started
				{
					return true;
				}
			
			else //start timer
			{
				this.lastused = DateTime.Now;
				halflifetimer = Timer.DelayCall( TimeSpan.FromMinutes( 30 ), new TimerCallback( Expire ) );
				return true;
				
			}
		}

		public HalfLifeBow( Serial serial ) : base( serial ) 
		{ 
			Timer.DelayCall( TimeSpan.FromMinutes( 30 ), new TimerCallback( Expire ) );
		} 

		public override void Serialize( GenericWriter writer ) // generic info to write and save
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 ); 
			writer.Write( (DateTime)i_halflife );
		} 
       
		public override void Deserialize(GenericReader reader) // make sure proper variables are read
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
			i_halflife = reader.ReadDateTime();
		}
	
	}
}