using System;
using Server.Items;

namespace Server.Items
{
	public class DupresShield : BaseShield
	{
		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 125; } }

		public override int OldStrReq{ get{ return 0; } }
		public override int ArmorBase{ get{ return 32; } }

		[Constructable]
		public DupresShield() : base( 0x2B01 )
		{
                  Name = "Dupre's Shield";
			Weight = 10.0;
		}

		public DupresShield( Serial serial ) : base( serial )
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

			if ( Weight == 1.0 )
				Weight = 4.0;
		}
	}
}








