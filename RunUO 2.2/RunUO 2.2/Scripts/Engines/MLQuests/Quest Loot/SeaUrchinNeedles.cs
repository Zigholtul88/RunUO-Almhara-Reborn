using System;
using Server;

namespace Server.Items
{
	public class SeaUrchinNeedles : Item
	{
		[Constructable]
		public SeaUrchinNeedles() : this( 1 )
		{
		}

		[Constructable]
		public SeaUrchinNeedles( int amount ) : base( 22327 )
		{
                        Name = "Sea Urchin Needles - (Quest Item)";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 1161;
			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "needles that are used for various quests." );
		}

		public SeaUrchinNeedles( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}