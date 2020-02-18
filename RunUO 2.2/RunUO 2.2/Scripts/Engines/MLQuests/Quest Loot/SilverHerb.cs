using System;
using Server;

namespace Server.Items
{
	public class SilverHerb : Item
	{
		[Constructable]
		public SilverHerb() : this( 1 )
		{
		}

		[Constructable]
		public SilverHerb( int amount ) : base( 0xC42 )
		{
                        Name = "Silver Herb - (Quest Item)";
			Stackable = true;
			Amount = amount;

			Weight = 1.0;
			Hue = 0x482;
			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "herbs that are used for various quests." );
		}

		public SilverHerb( Serial serial ) : base( serial )
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