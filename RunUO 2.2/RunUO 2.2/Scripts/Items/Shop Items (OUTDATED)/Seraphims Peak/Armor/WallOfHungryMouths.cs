using System;
using Server;

namespace Server.Items
{
        public class WallOfHungryMouths : HeaterShield, ITokunoDyable
        {
	         public override int BasePhysicalResistance{ get{ return 40; } }
	         public override int BaseColdResistance{ get{ return 10; } }

                 public override int InitMinHits { get { return 100; } }
                 public override int InitMaxHits { get { return 155; } }

                 [Constructable]
                 public WallOfHungryMouths()
                 {
                        Name = "Wall of Hungry Mouths";
		        Hue = 1034;

                        Attributes.DefendChance = 25;
                        Attributes.ReflectPhysical = 25;
                        Attributes.SpellChanneling = 1;
                 }

                 public WallOfHungryMouths( Serial serial ): base( serial )
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
