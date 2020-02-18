using System; 
using Server.Gumps;
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 

namespace Server.Items
{
      public class MoonElfAlterationGate : Item
      {
            [Constructable]
            public MoonElfAlterationGate() : base(0xF6C)
            {
	            Movable = false;
	            Light = LightType.Circle300;
	            Hue = 2405; 
	            Name = "Moon Elf Alteration Gate"; 
      }

      public MoonElfAlterationGate(Serial serial) : base(serial)
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
                m.CloseGump( typeof( MoonElfAlterationGump ) );
                m.SendGump( new MoonElfAlterationGump( m ) );

		m.FixedEffect( 0x376A, 10, 16 );
                m.Race = Race.Elf;
                m.Title = "the Moon Elf";
                m.BodyValue = 605;
                m.Hue = 2405;
                m.HairItemID = 12237;
                m.HairHue = 1153;
                m.FacialHairHue = 0;
                m.FacialHairItemID = 0;

                return false; //Changed this to false
            }
            else if ( m.Female == true )
            {
                m.CloseGump( typeof( MoonElfAlterationGump ) );
                m.SendGump( new MoonElfAlterationGump( m ) );

		m.FixedEffect( 0x376A, 10, 16 );
                m.Race = Race.Elf;
                m.Title = "the Moon Elf";
                m.BodyValue = 606;
                m.Hue = 2405;
                m.HairItemID = 12237;
                m.HairHue = 1153;
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
