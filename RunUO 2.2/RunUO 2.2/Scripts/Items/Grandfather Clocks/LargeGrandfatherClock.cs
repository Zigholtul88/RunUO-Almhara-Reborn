using System;
using Server;

namespace Server.Items
{
	public class LargeGrandfatherClockSouth : BaseGrandfatherClock
	{
		[Constructable]
		public LargeGrandfatherClockSouth() : base( 0x48D4 )
		{
		}

		public LargeGrandfatherClockSouth( Serial serial ) : base( serial )
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

	public class LargeGrandfatherClockEast : BaseGrandfatherClock
	{
		[Constructable]
		public LargeGrandfatherClockEast() : base( 0x48D8 )
		{
		}

		public LargeGrandfatherClockEast( Serial serial ) : base( serial )
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