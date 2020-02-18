using System;

namespace Server.Items
{
	[FlipableAttribute( 0x1BE9, 0x1BEC )]
	public class OneGoldBar : Item
	{
		[Constructable]
		public OneGoldBar() : base( 0x1BE9 )
		{
                  Name = "One Gold Bar";
			Weight = 1.0;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a gold bar that can be given to minters." );
		}

		public OneGoldBar( Serial serial ) : base( serial )
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

	[FlipableAttribute( 0x1BEA, 0x1BED )]
	public class ThreeGoldBars : Item
	{
		[Constructable]
		public ThreeGoldBars() : base( 0x1BEA )
		{
                  Name = "Three Gold Bars";
			Weight = 3.0;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a small set of gold bars that can be given to minters." );
		}

		public ThreeGoldBars( Serial serial ) : base( serial )
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

	[FlipableAttribute( 0x1BEB, 0x1BEE )]
	public class FiveGoldBars : Item
	{
		[Constructable]
		public FiveGoldBars() : base( 0x1BEB )
		{
                  Name = "Five Gold Bars";
			Weight = 5.0;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a large set of gold bars that can be given to minters." );
		}

		public FiveGoldBars( Serial serial ) : base( serial )
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