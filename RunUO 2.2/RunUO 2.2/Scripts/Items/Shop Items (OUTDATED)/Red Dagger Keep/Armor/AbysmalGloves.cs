using System;
using Server;
namespace Server.Items
{
        public class AbysmalGloves : LeatherGloves, ITokunoDyable
        {
                public override int InitMinHits{ get{ return 50;} }
                public override int InitMaxHits{ get{ return 55;} }

                [Constructable]
                public AbysmalGloves()
                {
                        Name = "Abysmal Gloves";
                        Hue = 1172;

                        ColdBonus = 3;
                        EnergyBonus = 9;
                        PhysicalBonus = 7;
                        PoisonBonus = 7;
                        FireBonus = 10;
                        Attributes.BonusInt = 5;
                        Attributes.LowerManaCost = 5;
                        Attributes.LowerRegCost = 10;
                        Attributes.SpellDamage = 35;
                        Attributes.RegenMana = 1;
                }
                
                public AbysmalGloves( Serial serial ) : base( serial )
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
