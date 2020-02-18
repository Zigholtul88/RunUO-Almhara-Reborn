using System;
using Server;

namespace Server.Items
{
	public class ArrianasEarrings : SilverEarrings
	{
		[Constructable]
		public ArrianasEarrings()
		{
			Name = "Arriana's Earrings";
			Hue = 1154;
			LootType = LootType.Blessed; 
			
                        Attributes.Luck = 100;
			Attributes.BonusHits = 50;
			Attributes.BonusMana = 25;
			Resistances.Energy = 10;
                        Resistances.Fire = 10;
			Resistances.Cold = 10;
			Resistances.Poison = 10;
                        Resistances.Physical = 10;
		}

		public ArrianasEarrings( Serial serial ) : base( serial )
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