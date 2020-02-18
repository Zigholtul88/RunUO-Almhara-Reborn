using System;

namespace Server.Items
{
	[Flipable( 15904, 15905 )]
	public class RogueGarb : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 40; } }

		[Constructable]
		public RogueGarb() : this( 0 )
		{
		}

		[Constructable]
		public RogueGarb( int hue ) : base( 15904, hue )
		{
                        Name = "Rogue Garb";
			Weight = 5.0;
		}

		public RogueGarb( Serial serial ) : base( serial )
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

