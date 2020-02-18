using System;
using Server;

namespace Server.Items
{
	public class AgilitySupplement2 : Item
	{
		[Constructable]
		public AgilitySupplement2() : base( 0x1006 )
		{
                        Name = "Agility Supplement +2";
			Stackable = false;
			LootType = LootType.Blessed;
			Weight = 0.1;
                        Hue = 0x48F;
		}

		public override void OnDoubleClick( Mobile m )
		{
                        if ( m.RawDex >= 98 )
                        {
                                m.SendMessage("You cannot raise your dexterity any further.");
                        }
                        else
                        {
		                m.RawDex += 2;
                                m.SendMessage("You have increased your Raw Dex by 2 Points!"); 
                                this.Delete();
                        }
		}

		public AgilitySupplement2( Serial serial ) : base( serial )
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