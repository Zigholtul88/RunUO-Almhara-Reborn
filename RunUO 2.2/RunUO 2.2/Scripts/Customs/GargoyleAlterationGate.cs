using System;
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 

namespace Server.Items
{
      public class GargoyleAlterationGate : Item
      {
            [Constructable]
            public GargoyleAlterationGate() : base(0xF6C)
            {
	            Movable = false;
	            Light = LightType.Circle300;
	            Name = "Gargoyle Alteration";
      }

      public GargoyleAlterationGate(Serial serial) : base(serial)
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

      public override bool OnMoveOver( Mobile m ) 
      { 
            if ( m.Female == false )
            {
		m.FixedEffect( 0x376A, 10, 16 );
                m.Race = Race.Gargoyle;
                m.Title = "the Gargoyle";
                m.BodyValue = 666;
                m.Hue = 1779;
                m.HairItemID = 499;
                m.HairHue = 2051;
                m.FacialHairHue = 0;
                m.FacialHairItemID = 0;

                return false; //Changed this to false
            }
            else if ( m.Female == true )
            {
		m.FixedEffect( 0x376A, 10, 16 );
                m.Race = Race.Gargoyle;
                m.Title = "the Gargoyle";
                m.BodyValue = 667;
                m.Hue = 1357;
                m.HairItemID = 16994;
                m.HairHue = 1360;
                m.FacialHairHue = 0;
                m.FacialHairItemID = 0;

                return false; //Changed this to false
            }
             else 
            { 
                return false; //Changed this to false
            } 
        } 
    } 
}
