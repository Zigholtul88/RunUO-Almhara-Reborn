//Initial Design by Bahmut
//Working Script by Zigholtul88

using System; 
using Server; 
using Server.Mobiles; 
using Server.Targeting; 

namespace Server.Items 
{ 
      	public class PackSaddle : Item 
      	{ 

      		[Constructable] 
      		public PackSaddle() : this( 0xE75 ) 
      		{ 
            		Name = "a pack saddle";
            		Movable = true;
      		} 

      		[Constructable] 
      		public PackSaddle( int itemID ) : base( itemID ) 
      		{ 
      		} 

      		public PackSaddle( Serial serial ) : base( serial ) 
      		{ 
      		} 

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsChildOf( from.Backpack ) )
			{
				from.BeginTarget( 6, false, TargetFlags.None, new TargetCallback( OnTarget ) );
                        	from.SendMessage( "Target the horse you wish to saddle." ); 
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}

		public virtual void OnTarget( Mobile from, object obj )
		{
			Horse pet = obj as Horse;

			if ( pet == null )
			{
                        from.SendMessage( "This isn't a horse, idiot!" ); 
			}
			else if ( !pet.Controlled || pet.ControlMaster != from )
			{
                        from.SendMessage( "You can only saddle a horse that you currently own." ); 
			}
			else
			{
			      pet.Delete();

        		      PackHorse packhorse = new PackHorse();
        		      packhorse.Controlled = true;
        		      packhorse.ControlMaster = from;
        		      packhorse.Location = from.Location;
        		      packhorse.Map = from.Map;
        		      World.AddMobile( packhorse );

			      this.Delete();

                        from.SendMessage( "You place the saddle onto your horse." ); 
			}
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
} 

 
