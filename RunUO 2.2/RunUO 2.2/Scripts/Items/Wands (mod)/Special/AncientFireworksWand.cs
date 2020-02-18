using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
   public class AncientFireworksWand : BaseBashing
   {
      private int m_Charges;

      public override int AosStrengthReq{ get{ return 5; } }
      public override int AosMinDamage{ get{ return 9; } }
      public override int AosMaxDamage{ get{ return 11; } }
      public override int AosSpeed{ get{ return 40; } }

      public override int OldStrengthReq{ get{ return 0; } }
      public override int OldMinDamage{ get{ return 2; } }
      public override int OldMaxDamage{ get{ return 6; } }
      public override int OldSpeed{ get{ return 35; } }
      public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.Disarm; } }
      public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Dismount; } }
      public override int InitMinHits{ get{ return 31; } }
      public override int InitMaxHits{ get{ return 40; } }

      [Constructable]
      public AncientFireworksWand() : base( 0xDF2 )
      {
         Weight = 1.0;
         LootType = LootType.Blessed;
         Name = "Ancient Fireworks Wand (charges: 100)";
         Charges = 100;
      }

      [CommandProperty( AccessLevel.GameMaster )]
      public int Charges
      {
        get{ return m_Charges; }
        set{ m_Charges = value; }
      }

      public AncientFireworksWand( Serial serial ) : base( serial )
      {
      }

      public override void Serialize( GenericWriter writer )
      {
         base.Serialize( writer );

         writer.Write( (int) 0 );
         writer.Write( (int) m_Charges );
      }

      public override void Deserialize( GenericReader reader )
      {
         base.Deserialize( reader );

         int version = reader.ReadInt();
         m_Charges = (int)reader.ReadInt();
      }

      public override void OnSingleClick( Mobile from )
      {
         this.LabelTo( from, 1041304 ); // a fireworks wand
      }

      public override void OnDoubleClick( Mobile from )
      {
         if ( Charges <= 0 )
         {
            from.SendMessage( "That item is out of charges!" );
            return;
         }

         Charges--;
         if ( Charges > 0 )
           Name = "Ancient Fireworks Wand (charges: " + Charges.ToString() + ")";
         else
           Name = "Ancient Fireworks Wand";

         DrawFirework( from );
         DrawFirework( from );
         DrawFirework( from );
         DrawFirework( from );
         DrawFirework( from );
         DrawFirework( from );
      }

      public static void DrawFirework( Mobile from )
      {
         int[] intEffectID = {14138,14154,14201};

         Point3D EffectLocation = new Point3D( ( from.X + Utility.Random( -4, 8 ) ), ( from.Y + Utility.Random( -4, 8 ) ), from.Z + 20 );
         Effects.SendLocationEffect( EffectLocation, from.Map, intEffectID[ Utility.Random( 0, 3 ) ], 70, (int)( 5 * Utility.Random( 0, 20 ) ) + 3, 2 );
      }
   }
}