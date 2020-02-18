using System;
using Server;

namespace Server.Items
{
	public class SmallStarLakeCrabEgg : Item
	{
		[Constructable]
		public SmallStarLakeCrabEgg() : base( 0x41BD )
		{
                  Name = "Small Star Lake Crab Egg";
			Weight = 1.0;
			Hue = Utility.RandomList( 2958,2959,2960 );
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a slightly uncommon egg that can be sold to butchers." );
			m.PlaySound( 1561 );
		}

		public SmallStarLakeCrabEgg( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class LargeStarLakeCrabEgg : Item
	{
		[Constructable]
		public LargeStarLakeCrabEgg() : base( 0x41BE )
		{
                  Name = "Large Star Lake Crab Egg";
			Weight = 2.0;
			Hue = Utility.RandomList( 2958,2959,2960 );
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a very rare egg that can be sold to butchers." );
			m.PlaySound( 1561 );
		}

		public LargeStarLakeCrabEgg( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}