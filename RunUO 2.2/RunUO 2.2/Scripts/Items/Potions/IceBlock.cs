//This script was made by Blank
using System;
using Server;

namespace Server.Items
{
	public class IceBlock : Item
	{
		[Constructable]
		public IceBlock() : this( 0x8E8 )
		{
		}

		[Constructable]
		public IceBlock( int itemID ) : base( itemID )
		{
			Movable = false;
			Hue = 1152;
			Name = "an Ice Pillar";

			new InternalTimer( this ).Start();
		}

		public IceBlock( Serial serial ) : base( serial )
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
			private Item m_IceBlock;

			public InternalTimer( Item IceBlock ) : base( TimeSpan.FromSeconds( 30.0 + (Utility.RandomDouble() * 3.0) ) )
			{
				Priority = TimerPriority.FiftyMS;

				m_IceBlock = IceBlock;
			}

			protected override void OnTick()
			{
				m_IceBlock.Delete();
			}
		}
	}
}