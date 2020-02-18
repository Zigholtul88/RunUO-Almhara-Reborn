using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
   public class GargoyleCloak : Cloak
   {
      [Constructable]
      public GargoyleCloak()
      {
         Weight = 1.0;
         Name = "Cloak of the Gargoyle";
         Layer = Layer.Cloak;
         Hue = 1374;
         LootType = LootType.Blessed;
      }

      public override void OnDoubleClick( Mobile m )
      {        
  
         if( Parent != m )
         {
            m.SendMessage( "You must be wearing the cloak to use it!" );
         }
         else
         {
            if ( m.Body == 400 && m.Str <= 175 )
            {
               m.SendMessage( "You feel your bones change." );
               m.BodyMod = 666;
               m.Hue = 1759;
               m.HairItemID = 499;
               m.HairHue = 1608;
 
               m.Title = "the Gargoyle";
               m.LightLevel = 100;
               m.EquipItem(this);
               m.DisplayGuildTitle = true;
               
                
            }
            else if ( m.BodyMod == 666 && m.Str <= 200 )
            {
               m.SendMessage( "You feel your bones change." );
               m.BodyMod = 0;
               m.Title = null;
               m.LightLevel = 0;

               m.Hue = 33770;

               m.BaseSoundID = 0;
               m.DisplayGuildTitle = true;
               m.Criminal = false;

            }
            else if ( m.Body == 401 && m.Str <= 175 )
            {
               m.SendMessage( "You feel your bones change." );
               m.BodyMod = 667;
               m.Hue = 1759;
               m.HairItemID = 475;
               m.HairHue = 1608;
               m.Title = "the Gargoyle";
               m.LightLevel = 100;

               m.DisplayGuildTitle = true;
               m.Criminal = false;

            }
            else if ( m.BodyMod == 667 && m.Str <= 200 )
            {
               m.SendMessage( "You feel your bones change." );
               m.BodyMod = 0;
               m.LightLevel = 0;

               m.Hue = 0;

               m.BaseSoundID = 0;
               m.Title = null;
               m.DisplayGuildTitle = true;
               m.Criminal = false;

            }

         }
      }

      public override bool OnEquip( Mobile from )
      {
         if ( from.BodyMod == 0x17 || from.BodyMod == 0xE1 )
         {
         from.Title = "the Gargoyle";
         from.DisplayGuildTitle = true;
         from.Criminal = false;
         }
         return base.OnEquip(from);
      }

      public override void OnRemoved( Object o )
      {
      if( o is Mobile && (((Mobile)o).BodyMod == 666 || ((Mobile)o).BodyMod == 667 ))
      {
          ((Mobile)o).Title = null;
          
      }
      if( o is Mobile && ((Mobile)o).Kills >= 5)
               {
               ((Mobile)o).Criminal = true;
                }
      if( o is Mobile && ((Mobile)o).GuildTitle != null )
               {
          ((Mobile)o).DisplayGuildTitle = true;
                }
      base.OnRemoved( o );
      }

      public GargoyleCloak( Serial serial ) : base( serial )
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

