using System;
using Server;
using Server.Items;

namespace Server.Items
{
        public class RingOfTheGoddess: SilverRing
        {
                [Constructable]
                public RingOfTheGoddess()
                {
                          Weight = 1 ;
                          Name = "Ring of The Goddess";
                          Hue = 1150;
              
                          Attributes.BonusHits = 25;
                          Attributes.BonusMana = 25;
                          Attributes.BonusStam = 25;
                          Attributes.CastRecovery = 1;
                          Attributes.CastSpeed = 1;
                          Attributes.LowerManaCost = 15;
                          Attributes.LowerRegCost = 15;
                }

                public RingOfTheGoddess( Serial serial ) : base( serial )
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
