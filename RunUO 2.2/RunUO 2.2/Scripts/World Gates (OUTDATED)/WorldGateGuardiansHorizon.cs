//Created By Cassius for Order of The Red Dragon
//modified by Zigholtul of the customized oldschool shard, "Avatars Reborn"

using System; 
using Server.Network; 
using Server.Items; 
using Server.Mobiles; 
using Server.Gumps;

namespace Server.Items
{
      public class WorldGateGuardiansHorizon : Item
      {
            [Constructable]
            public WorldGateGuardiansHorizon() : base(0xF6C)
            {
                  Name = "To Guardians Horizon";
	            Movable = false;
	            Light = LightType.Circle300;
      }

      public WorldGateGuardiansHorizon(Serial serial) : base(serial)
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
		    m.PlaySound( 526 );

                m.Location = new Point3D(382, 1884, 29);
                return false; //Changed this to false
            }
            else if ( m.Female == true )
            {
		    m.PlaySound( 526 );

                m.Location = new Point3D(382, 1884, 29);
                return false; //Changed this to false
            }
             else 
            { 
                return false; //Changed this to false

              } 
            } 
         } 
}
