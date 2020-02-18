using System;
using Server;

namespace Server.Items
{
        public class MarbleShield : HeaterShield, ITokunoDyable
        {
                public override int BasePhysicalResistance{ get{ return 25; } }
                public override int BaseColdResistance{ get{ return 5; } }
                public override int BaseFireResistance{ get{ return 17; } }
                public override int BaseEnergyResistance{ get{ return 13; } }
                public override int BasePoisonResistance{ get{ return 9; } }

                public override int InitMinHits{ get{ return 75; } }
                public override int InitMaxHits{ get{ return 100; } }

                [Constructable]
                public MarbleShield()
                {
                        Name = "Marble Shield";
                        Hue = 2961;

                        StrRequirement = 100;
                        Attributes.RegenHits = 1;
                        Attributes.DefendChance = 50;
                        Attributes.Luck = 300;
                        ArmorAttributes.SelfRepair = 15;
                        Attributes.CastSpeed = 1;
                        Attributes.CastRecovery = 1;
                        Attributes.SpellChanneling = 1;  
                 }

                 public MarbleShield(Serial serial) : base( serial )
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
