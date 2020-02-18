using System;
using Server;

namespace Server.Items
{
	public class StrengthSupplement2 : Item
	{
		[Constructable]
		public StrengthSupplement2() : base( 0xF04 )
		{
                        Name = "Strength Supplement +2";
			Stackable = false;
			LootType = LootType.Blessed;
			Weight = 0.1;
                        Hue = 0xE9;
		}

		public override void OnDoubleClick( Mobile m )
		{
                        if ( m.RawStr >= 98 )
                        {
                                m.SendMessage("You cannot raise your strength any further.");
                        }
                        else
                        {
		                m.RawStr += 2;
                                m.SendMessage("You have increased your Raw Str by 2 Points!"); 
                                this.Delete();
                        }
		}

		public StrengthSupplement2( Serial serial ) : base( serial )
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