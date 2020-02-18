using System;
using Server;

namespace Server.Items
{
	public class AgilitySupplement1 : Item
	{
		[Constructable]
		public AgilitySupplement1() : base( 0x1006 )
		{
                        Name = "Agility Supplement +1";
			Stackable = false;
			LootType = LootType.Blessed;
			Weight = 0.1;
                        Hue = 0x48F;
		}

		public override void OnDoubleClick( Mobile m )
		{
                        if ( m.RawDex >= 100 )
                        {
                                m.SendMessage("You cannot raise your dexterity any further.");
                        }
                        else
                        {
		                m.RawDex += 1;
                                m.SendMessage("You have increased your Raw Dex by 1 Point!"); 
                                this.Delete();
                        }
		}

		public AgilitySupplement1( Serial serial ) : base( serial )
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