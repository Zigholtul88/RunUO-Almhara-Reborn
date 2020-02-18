using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 15299, 15300 )]
	public class TwoPieceBikini : BaseShirt
	{
		public override int InitMinHits{ get{ return 45; } }
		public override int InitMaxHits{ get{ return 55; } }

		[Constructable]
		public TwoPieceBikini() : this( 0 )
		{
		}

		[Constructable]
		public TwoPieceBikini( int hue ) : base( 15299, hue )
		{
                        Name = "Two-Piece Bikini";
			Weight = 1.0;
		}

		public TwoPieceBikini( Serial serial ) : base( serial )
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