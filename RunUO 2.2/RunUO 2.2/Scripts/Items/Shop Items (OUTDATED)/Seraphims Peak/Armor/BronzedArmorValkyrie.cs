using System;
using Server;

namespace Server.Items
{
        public class BronzedArmorValkyrie : FemaleLeatherChest, ITokunoDyable
        {
	         public override int BasePhysicalResistance{ get{ return 11; } }
	         public override int BaseFireResistance{ get{ return 14; } }
	         public override int BaseColdResistance{ get{ return 8; } }
	         public override int BasePoisonResistance{ get{ return 11; } }
	         public override int BaseEnergyResistance{ get{ return 8; } }

                 public override int InitMinHits { get { return 100; } }
                 public override int InitMaxHits { get { return 155; } }

                 [Constructable]
                 public BronzedArmorValkyrie()
                 {
                        Name = "Bronzed Armor of the Valkyrie";
		        Hue = 1863;

                        Attributes.BonusHits = 5;
			Attributes.BonusStr = 5;
			Attributes.BonusDex = 5;
			Attributes.BonusStam = 5;
			Attributes.RegenStam = 3;
                        Attributes.LowerManaCost = 10;
                 }

                 public BronzedArmorValkyrie( Serial serial ): base( serial )
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
