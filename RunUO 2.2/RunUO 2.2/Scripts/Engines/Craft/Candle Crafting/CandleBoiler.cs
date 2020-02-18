using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class CandleBoiler : BaseTool
	{
		public override CraftSystem CraftSystem { get { return DefCandleCrafting.CraftSystem; } }

		[Constructable]
		public CandleBoiler() : base( 0x15F8 )
		{
                        Name = "Candle Boiler";
			Weight = 1.0;
                        Hue = 781;
		}

		[Constructable]
		public CandleBoiler( int uses ) : base( uses, 0x15F8 )
		{
                        Name = "Candle Boiler";
			Weight = 1.0;
                        Hue = 781;
		}

		public CandleBoiler( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}