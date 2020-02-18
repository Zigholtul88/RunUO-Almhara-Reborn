using System;
using Server;

namespace Server.Items
{
        public class TongueOfTheBeast : WoodenKiteShield, ITokunoDyable
        {
	         public override int BasePhysicalResistance{ get{ return 30; } }
	         public override int BaseEnergyResistance{ get{ return 15; } }

                 public override int InitMinHits { get { return 100; } }
                 public override int InitMaxHits { get { return 155; } }

                 [Constructable]
                 public TongueOfTheBeast()
                 {
                        Name = "Tongue of the Beast";
		        Hue = 153;

                        Attributes.DefendChance = 15;
                        Attributes.RegenStam = 5;
                        Attributes.RegenMana = 5;
                        Attributes.SpellChanneling = 1;
                 }

                 public TongueOfTheBeast( Serial serial ): base( serial )
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
