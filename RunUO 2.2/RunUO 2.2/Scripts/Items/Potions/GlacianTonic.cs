//This script was made by Blank & Lauren
using System; 
using Server.Items;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{ 
	public class GlacianTonic : Item 
	{ 
		[Constructable] 
		public GlacianTonic() : base( 0xF08 ) 
		{ 
			Name = "Glacian Tonic";
			Movable = true;
			Hue = 1152 ;
		} 

		public override void OnDoubleClick( Mobile from ) 
		{ 
			if ( !IsChildOf( from.Backpack ) )
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.

			else
			{
				IceBlock ice = new IceBlock();
				ice.MoveToWorld( new Point3D( from.X +1, from.Y, from.Z  ), from.Map );
				from.PlaySound( 0x229 );


				IceBlock icea = new IceBlock();
				icea.MoveToWorld( new Point3D( from.X +1, from.Y +1, from.Z  ), from.Map );
				from.PlaySound( 0x229 );


				IceBlock iceb = new IceBlock();
				iceb.MoveToWorld( new Point3D( from.X +1, from.Y -1, from.Z  ), from.Map );
				from.PlaySound( 0x229 );

				IceBlock icec = new IceBlock();
				icec.MoveToWorld( new Point3D( from.X, from.Y +1, from.Z  ), from.Map );
				from.PlaySound( 0x229 );

				IceBlock iced = new IceBlock();
				iced.MoveToWorld( new Point3D( from.X, from.Y -1, from.Z  ), from.Map );
				from.PlaySound( 0x229 );

				IceBlock icee = new IceBlock();
				icee.MoveToWorld( new Point3D( from.X -1, from.Y, from.Z  ), from.Map );
				from.PlaySound( 0x229 );

				IceBlock icef = new IceBlock();
				icef.MoveToWorld( new Point3D( from.X -1, from.Y -1, from.Z  ), from.Map );
				from.PlaySound( 0x229 );

				IceBlock iceg = new IceBlock();
				iceg.MoveToWorld( new Point3D( from.X -1, from.Y +1, from.Z  ), from.Map );
				from.PlaySound( 0x229 );

				IceBlock iceh = new IceBlock();
				iceh.ItemID = 0x8e1;
				iceh.MoveToWorld( new Point3D( from.X, from.Y, from.Z +19 ), from.Map );
				from.PlaySound( 0x229 );

				from.PlaySound( 0x390 );
				from.PlaySound( 0x38D );
				from.FixedParticles( 0x3728, 1, 10, 9910, 1152, 1, EffectLayer.Head );
				from.Hits = from.Hits - from.Hits / 10;

				this.Delete();
			}
		}

	    	public GlacianTonic( Serial serial ) : base( serial ) 
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
} 