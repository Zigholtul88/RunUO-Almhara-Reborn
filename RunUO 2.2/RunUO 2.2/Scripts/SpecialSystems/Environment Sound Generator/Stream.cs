using System;
using System.Collections.Generic;
using Server;

namespace Server.Items
{
	public class Stream : Item
	{
		[Constructable]
		public Stream(Direction direction) : this(direction, false)
		{
		}

		[Constructable]
		public Stream(Direction direction, bool small) : base(0x1FB7)
		{
			Visible = false;
			Movable = false;
			switch(direction)
			{
				case Direction.North:
				{
					if(small)
						ItemID = 0x1FA3;
					else
						ItemID = 0x1FB7;
					break;
				}
				case Direction.South:
				{
					if(small)
						ItemID = 0x1FB2;
					else
						ItemID = 0x1FC6;
					break;
				}
				case Direction.East:
				{
					if(small)
						ItemID = 0x1FAD;
					else
						ItemID = 0x1FC1;
					break;
				}
				case Direction.West:
				{
					if(small)
						ItemID = 0x1FA8;
					else
						ItemID = 0x1FBC;
					break;
				}
				default:
				{
					ItemID = 0x1FA3;
					break;
				}
			}
			StreamTimer.StreamList.Add(this);
		}

		public void OnTick()
		{
			Effects.PlaySound(Location, Map, 0x11);
		}

		public Stream(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			StreamTimer.StreamList.Add(this);
		}
	}

	public class StreamTimer : Timer 
	{
		public const bool Enabled = true;
		public static List<Stream> StreamList = new List<Stream>();

		public static void Initialize() 
		{
			if (Enabled)
				new StreamTimer().Start();
		}

		public StreamTimer() : base(TimeSpan.FromSeconds( 0.00 ), TimeSpan.FromSeconds( 0.00 )) 
		{
			Priority = TimerPriority.OneSecond;
		}

		protected override void OnTick() 
		{
			foreach (Stream stream in StreamList)
				stream.OnTick();
		}
	}
}