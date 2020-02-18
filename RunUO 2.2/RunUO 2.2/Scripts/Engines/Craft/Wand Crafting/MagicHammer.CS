using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 0x13E4, 0x13E3 )]
	public class MagicHammer : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefWandsystem.CraftSystem; } }

		[Constructable]
		public MagicHammer() : base( 0x13E4 )
		{
                        Name = "Magic Hammer";
			Weight = 8.0;
			Layer = Layer.OneHanded;
                        Hue = 0x492;
		}

		[Constructable]
		public MagicHammer( int uses ) : base( uses, 0x13E4 )
		{
                        Name = "Magic Hammer";
			Weight = 8.0;
			Layer = Layer.OneHanded;
                        Hue = 0x492;
		}

		public MagicHammer( Serial serial ) : base( serial )
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