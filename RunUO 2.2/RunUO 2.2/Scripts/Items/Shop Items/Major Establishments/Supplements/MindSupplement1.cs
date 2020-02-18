using System;
using Server;

namespace Server.Items
{
	public class MindSupplement1 : Item
	{
		[Constructable]
		public MindSupplement1() : base( 0xEFC )
		{
                        Name = "Mind Supplement +1";
			Stackable = false;
			LootType = LootType.Blessed;
			Weight = 0.1;
                        Hue = 0x62;
		}

		public override void OnDoubleClick( Mobile m )
		{
                        if ( m.RawInt >= 100 )
                        {
                                m.SendMessage("You cannot raise your intelligence any further.");
                        }
                        else
                        {
		                m.RawInt += 1;
                                m.SendMessage("You have increased your Raw Int by 1 Point!"); 
                                this.Delete();
                        }
		}

		public MindSupplement1( Serial serial ) : base( serial )
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