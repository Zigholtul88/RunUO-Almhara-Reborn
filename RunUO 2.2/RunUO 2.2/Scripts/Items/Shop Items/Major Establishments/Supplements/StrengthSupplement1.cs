using System;
using Server;

namespace Server.Items
{
	public class StrengthSupplement1 : Item
	{
		[Constructable]
		public StrengthSupplement1() : base( 0xF04 )
		{
                        Name = "Strength Supplement +1";
			Stackable = false;
			LootType = LootType.Blessed;
			Weight = 0.1;
                        Hue = 0xE9;
		}

		public override void OnDoubleClick( Mobile m )
		{
                        if ( m.RawStr >= 100 )
                        {
                                m.SendMessage("You cannot raise your strength any further.");
                        }
                        else
                        {
		                m.RawStr += 1;
                                m.SendMessage("You have increased your Raw Str by 1 Point!"); 
                                this.Delete();
                        }
		}

		public StrengthSupplement1( Serial serial ) : base( serial )
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