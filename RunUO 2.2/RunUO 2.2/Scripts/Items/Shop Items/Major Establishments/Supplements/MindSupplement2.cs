using System;
using Server;

namespace Server.Items
{
	public class MindSupplement2 : Item
	{
		[Constructable]
		public MindSupplement2() : base( 0xEFC )
		{
                        Name = "Mind Supplement +2";
			Stackable = false;
			LootType = LootType.Blessed;
			Weight = 0.1;
                        Hue = 0x62;
		}

		public override void OnDoubleClick( Mobile m )
		{
                        if ( m.RawInt >= 98 )
                        {
                                m.SendMessage("You cannot raise your intelligence any further.");
                        }
                        else
                        {
		                m.RawInt += 2;
                                m.SendMessage("You have increased your Raw Int by 2 Points!"); 
                                this.Delete();
                        }
		}

		public MindSupplement2( Serial serial ) : base( serial )
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