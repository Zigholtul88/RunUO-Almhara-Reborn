//This script was made by Blank
using System;
using Server;

namespace Server.Items
{
	public class IceFieldIceFlame : Item
	{
		[Constructable]
		public IceFieldIceFlame() : this( 0x3709 )
		{
		}

		[Constructable]
		public IceFieldIceFlame( int itemID ) : base( itemID )
		{
			Movable = false;
			Hue = 1150;
			Name = "an Ice Flame";

			new InternalTimer( this ).Start();
		}

		public IceFieldIceFlame( Serial serial ) : base( serial )
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
			private Item m_IceFieldIceFlame;

			public InternalTimer( Item IceFieldIceFlame ) : base( TimeSpan.FromSeconds( 5.0 ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_IceFieldIceFlame = IceFieldIceFlame;
			}

			protected override void OnTick()
			{
				m_IceFieldIceFlame.Delete();
			}
		}
	}
}