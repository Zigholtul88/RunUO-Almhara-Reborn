//Created By Cassius for Order of The Red Dragon
//modified by Zigholtul of the customized oldschool shard, "Avatars Reborn"

using System; 
using Server.Network; 
using Server.Items; 
using Server.Mobiles; 
using Server.Gumps;

namespace Server.Items
{
      public class WorldGateLakeShire : Item
      {
            [Constructable]
            public WorldGateLakeShire() : base(0xF6C)
            {
                    Name = "To Lake Shire - House Foundation";
	            Movable = false;
	            Light = LightType.Circle300;
      }

      public WorldGateLakeShire(Serial serial) : base(serial)
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
		m.PlaySound( 0x1FC );

                m.Location = new Point3D(1175, 1190, -23);
		m.Map = Map.Ilshenar;
                return false; //Changed this to false
            }
            else if ( m.Female == true )
            {
		m.PlaySound( 0x1FC );

                m.Location = new Point3D(1175, 1190, -23);
		m.Map = Map.Ilshenar;
                return false; //Changed this to false
            }
             else 
            { 
                return false; //Changed this to false

              } 
            } 
         } 
}
