using System;
using Server;
using Server.Network;

namespace Server.Items
{
	public class OFQRing : GoldRing
	{
		[Constructable]
		public OFQRing()
		{
			Name = "Orcish Wedding Ring - Quest Item";
			Weight = 1.0;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a wedding ring required to complete the Full Metal Forgery quest." );
		}

		public OFQRing( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}