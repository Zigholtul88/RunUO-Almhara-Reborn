using System;
using Server;

namespace Server.Items
{
        public class SteamPoweredBeverageMakerAddon : BaseAddon
	{
                public override BaseAddonDeed Deed { get { return new SteamPoweredBeverageMakerDeed(); } }

		public override bool RetainDeedHue{ get{ return true; } }

		[Constructable]
		public SteamPoweredBeverageMakerAddon() : this( 0 )
		{
		}

		[Constructable]
		public SteamPoweredBeverageMakerAddon( int hue )
		{
		        Name = "Steam-Powered Beverage Maker";
			AddComponent( new LocalizedAddonComponent( 0x2D4A, 1123598 ), 0, 0, 0 );
			Hue = hue;
		}

                public SteamPoweredBeverageMakerAddon( Serial serial ) : base( serial )
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

        public class SteamPoweredBeverageMakerDeed : BaseAddonDeed
	{
		public override BaseAddon Addon{ get{ return new SteamPoweredBeverageMakerAddon( this.Hue ); } }
                public override int LabelNumber { get { return 1123598; } }

		[Constructable]
		public SteamPoweredBeverageMakerDeed()
		{
		}

                public SteamPoweredBeverageMakerDeed( Serial serial ) : base( serial )
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