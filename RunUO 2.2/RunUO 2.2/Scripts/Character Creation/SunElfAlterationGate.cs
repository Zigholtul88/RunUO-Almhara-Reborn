using System; 
using Server.Gumps;
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 

namespace Server.Items
{
      public class SunElfAlterationGate : Item
      {
            [Constructable]
            public SunElfAlterationGate() : base(0xF6C)
            {
	            Movable = false;
	            Light = LightType.Circle300;
	            Hue = 1023; 
	            Name = "Sun Elf Alteration Gate"; 
      }

      public SunElfAlterationGate(Serial serial) : base(serial)
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
                m.CloseGump( typeof( SunElfAlterationGump ) );
                m.SendGump( new SunElfAlterationGump( m ) );

		m.FixedEffect( 0x376A, 10, 16 );
                m.Race = Race.Elf;
                m.Title = "the Sun Elf";
                m.BodyValue = 605;
                m.Hue = 1023;
                m.HairItemID = 12237;
                m.HairHue = 55;
                m.Female = false;
                m.FacialHairHue = 0;
                m.FacialHairItemID = 0;

                return false; //Changed this to false
            }
            else if ( m.Female == true )
            {
                m.CloseGump( typeof( SunElfAlterationGump ) );
                m.SendGump( new SunElfAlterationGump( m ) );

		m.FixedEffect( 0x376A, 10, 16 );
                m.Race = Race.Elf;
                m.Title = "the Sun Elf";
                m.BodyValue = 606;
                m.Hue = 1023;
                m.HairItemID = 12236;
                m.HairHue = 55;
                m.Female = true;

                return false; //Changed this to false
            }
             else 
            { 
                return false; //Changed this to false
            } 
        } 
    } 
}