using System; 
using Server.Gumps;
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 

namespace Server.Items
{
      public class MoonElfChangeGate : Item
      {
            [Constructable]
            public MoonElfChangeGate() : base(0xF6C)
            {
	            Movable = false;
	            Light = LightType.Circle300;
	            Name = "The Path of the Moon Elf"; 
      }

      public MoonElfChangeGate(Serial serial) : base(serial)
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
                m.CloseGump( typeof( MoonElfChangeGump ) );
                m.SendGump( new MoonElfChangeGump( m ) );

                m.Location = new Point3D(2528, 1980, 0);
                return false; //Changed this to false
            }
            else if ( m.Female == true )
            {
                m.CloseGump( typeof( MoonElfChangeGump ) );
                m.SendGump( new MoonElfChangeGump( m ) );

                m.Location = new Point3D(2528, 1980, 0);
                return false; //Changed this to false
            }
             else 
            { 
                return false; //Changed this to false
            } 
        } 
    } 
}
