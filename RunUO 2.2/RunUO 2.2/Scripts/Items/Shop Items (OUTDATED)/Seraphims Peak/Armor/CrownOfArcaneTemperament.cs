using System;
using Server;

namespace Server.Items
{
        public class CrownOfArcaneTemperament : Circlet
        {
                 public override Race RequiredRace { get { return null; } }

	         public override int BasePhysicalResistance{ get{ return 10; } }
	         public override int BaseFireResistance{ get{ return 14; } }
	         public override int BaseColdResistance{ get{ return 4; } }
	         public override int BasePoisonResistance{ get{ return 12; } }
	         public override int BaseEnergyResistance{ get{ return 7; } }

                 public override int InitMinHits { get { return 100; } }
                 public override int InitMaxHits { get { return 155; } }

                 [Constructable]
                 public CrownOfArcaneTemperament()
                 {
                        Name = "Crown of Arcane Temperament";
		        Hue = 2012;

			Attributes.BonusMana = 15;
			Attributes.RegenMana = 3;
			Attributes.SpellDamage = 10;
                        Attributes.LowerManaCost = 6;
                 }

                 public CrownOfArcaneTemperament( Serial serial ): base( serial )
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
