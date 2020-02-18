using System;
using Server.Mobiles;
using Server;
using Server.Items;

namespace Server.Items
{
        public class YugitashiTalisman : Item
        {
                [Constructable]
                public YugitashiTalisman(): base( 15397 )
                {
			Name = "Yugitashi";
                        LootType = LootType.Blessed;
                        Movable = false;
			Hue = 1047;
			Layer = Layer.Shirt;
			Visible = true;
                }

                public YugitashiTalisman( Serial serial ) : base( serial )
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