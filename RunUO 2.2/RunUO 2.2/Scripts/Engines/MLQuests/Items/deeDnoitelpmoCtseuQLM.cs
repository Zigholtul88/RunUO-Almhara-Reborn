using System;
using Server;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Engines.MLQuests.Items
{
	public class deeDnoitelpmoCtseuQLM : Item
	{
		[Constructable]
		public deeDnoitelpmoCtseuQLM() : base( 5360 )
		{
			Name = "deeD noitelpmoC tseuQ - (latot tseuq ruoy drocer ot kcilC-BD)";
			Weight = 1.0;
			Hue = 0x481;
                        LootType = LootType.Blessed;
			Movable = false;
		}

		public deeDnoitelpmoCtseuQLM( Serial serial ) : base( serial )
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

                public override void OnDoubleClick( Mobile from )
                {
                      PlayerMobile mobile = from as PlayerMobile;

                      if ( !IsChildOf( from.Backpack ) ) 
                      { 
                              from.SendMessage( ".ti esu ot uoy rof kcap ruoy ni eb tsum tahT" );
                      }
                      else
                      {
                              mobile.TotalQuestsDone += 1;
                              mobile.SendMessage( ".latot tseuq detelpmoc ruoy ot 1+ deniag evah uoY" );
             
                              Effects.SendLocationParticles( EffectItem.Create( from.Location, from.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 5060, 0 );
                              Effects.PlaySound( from.Location, from.Map, 0x243 );
                              Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                              Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 4, from.Y - 6, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                              Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
                              Delete(); 
                      }
                }
          }
   }