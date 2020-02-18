using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
   public class GargoyleStatue : Item
   {
      [Constructable]
	public GargoyleStatue() : base( 0x20D9 )
      {
         Weight = 1.0;
         Name = "Gargoyle Statue: It Lets You Fly!";
         Hue = 818;
         LootType = LootType.Blessed;
      }

      public override void OnDoubleClick( Mobile m )
      {        
            if ( m.Flying == false )
            {
               m.Flying = true;
            }
            else 
            {
               m.Flying = false;
            }
         }


      public GargoyleStatue( Serial serial ) : base( serial )
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

   }
}

