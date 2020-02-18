using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class GemCarvingTool : BaseTool
	{
		public override CraftSystem CraftSystem { get { return DefGemCrafting.CraftSystem; } }

		[Constructable]
		public GemCarvingTool() : base( 0x12B3 )
		{
                        Name = "Gem Carving Tool";
			Weight = 1.0;
                        Hue = 781;
		}

		[Constructable]
		public GemCarvingTool( int uses ) : base( uses, 0x12B3 )
		{
                        Name = "Gem Carving Tool";
			Weight = 1.0;
                        Hue = 781;
		}

		public GemCarvingTool( Serial serial ) : base( serial )
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