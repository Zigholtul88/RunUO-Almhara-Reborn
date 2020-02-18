using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 15297, 15298 )]
	public class OnePieceBikini : BaseShirt
	{
		public override int InitMinHits{ get{ return 45; } }
		public override int InitMaxHits{ get{ return 55; } }

		[Constructable]
		public OnePieceBikini() : this( 0 )
		{
		}

		[Constructable]
		public OnePieceBikini( int hue ) : base( 15297, hue )
		{
                        Name = "One-Piece Bikini";
			Weight = 1.0;
		}

		public OnePieceBikini( Serial serial ) : base( serial )
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