using System;
using Server.Items;

namespace Server.Items
{
	public class RedLeatherTunicOfFireProtection : LeatherChest
	{
		public override int BaseFireResistance{ get{ return 30; } }

		[Constructable]
		public RedLeatherTunicOfFireProtection()
		{
			Name = "Red Leather Tunic of Fire Protection";
                        Hue = 1281;

			Attributes.BonusHits = 25;
		}

		public RedLeatherTunicOfFireProtection( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}