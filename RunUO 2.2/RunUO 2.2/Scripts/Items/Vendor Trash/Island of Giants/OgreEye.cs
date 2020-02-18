using System;
using Server;

namespace Server.Items
{
	public class OgreEye : Item
	{
		[Constructable]
		public OgreEye() : this( 1 )
		{
		}

		[Constructable]
		public OgreEye( int amount ) : base( 0x5749 )
		{
			Name = "Ogre Eye";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the eye of an ogre that can be sold to butchers." );
			m.PlaySound( 427 );
		}

		public OgreEye( Serial serial ) : base( serial )
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