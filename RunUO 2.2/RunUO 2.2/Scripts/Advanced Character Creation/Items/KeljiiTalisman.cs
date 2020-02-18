using System;
using Server.Mobiles;
using Server;
using Server.Items;

namespace Server.Items
{
        public class KeljiiTalisman : Item
        {
                [Constructable]
                public KeljiiTalisman(): base( 15398 )
                {
			Name = "Keljii";
                        LootType = LootType.Blessed;
                        Movable = false;
			Hue = 1266;
			Layer = Layer.Shirt;
			Visible = true;
                }

                public KeljiiTalisman( Serial serial ) : base( serial )
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