//This script was made by Blank
using System;
using Server;

namespace Server.Items
{
	public class AreaThunderStrike : Item
	{
		[Constructable]
		public AreaThunderStrike() : this( 0x36B0 )
		{
		}

		[Constructable]
		public AreaThunderStrike( int itemID ) : base( itemID )
		{
			new InternalTimer( this ).Start();
		}

		public AreaThunderStrike( Serial serial ) : base( serial )
		{
			new InternalTimer( this ).Start();
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

		private class InternalTimer : Timer
		{
			private Item m_AreaThunderStrike;

			public InternalTimer( Item AreaThunderStrike ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_AreaThunderStrike = AreaThunderStrike;
			}

			protected override void OnTick()
			{
				m_AreaThunderStrike.Delete();
			}
		}
	}
}