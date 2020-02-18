using System;
using Server;
namespace Server.Items
{
        public class MagesBand : GoldRing, ITokunoDyable
        {
                [Constructable]
                public MagesBand()
                {
                        Name = "Mages Band";
                        Hue = 1170;
                        Attributes.LowerRegCost = 15;
                        Attributes.LowerManaCost = 10;
                        Attributes.CastRecovery = 3;
                        Attributes.BonusMana = 15;
                        Attributes.RegenMana = 1;
                 }

                 public MagesBand( Serial serial ): base( serial )
                 {
                 }

                 public override void Serialize( GenericWriter writer )
                 {
                        base.Serialize( writer );
                        writer.Write( (int)0 );
                 }

                 public override void Deserialize( GenericReader reader )
                 {
                        base.Deserialize( reader );
                        int version = reader.ReadInt();
                 }
        }
}
