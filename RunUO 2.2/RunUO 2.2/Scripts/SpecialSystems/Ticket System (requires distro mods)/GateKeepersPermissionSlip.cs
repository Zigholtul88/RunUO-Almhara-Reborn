using System;
using Server;

namespace Server.Items
{
	public class GateKeepersPermissionSlip : Item
	{
		public override string DefaultName
		{
			get { return "Gate Keepers Permission Slip"; }
		}

		[Constructable]
		public GateKeepersPermissionSlip() : base( 0x14EE )
		{
                        Hue = 1151;
			Weight = 0.0;
			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a letter when given to the gatekeeper will allow access into the Harashi Nabi." );
                }

		public GateKeepersPermissionSlip( Serial serial ) : base( serial )
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
