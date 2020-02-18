//Customized By Mrs Death
using System;
using Server;

namespace Server.Items
{
              public class StragoShoes: Shoes
{
	public override int ArtifactRarity{ get{ return 6; } }
              
              [Constructable]
              public StragoShoes()
{

                          Weight = 5;
                          Name = "[FF6] Strago's Shoes";
                          Hue = 273;
              
              Attributes.BonusDex = 20;
              Attributes.BonusHits = 10;
              Attributes.BonusInt = 20;
              Attributes.BonusMana = 10;
              Attributes.BonusStam = 10;
              Attributes.LowerManaCost = 5;
              Attributes.LowerRegCost = 15;
              Attributes.ReflectPhysical = 10;

                  }
              public StragoShoes( Serial serial ) : base( serial )
                      {
                      }
              
              public override void Serialize( GenericWriter writer )
                      {
                          base.Serialize( writer );
                          writer.Write( (int) 0 );
                      }
              
              public override void Deserialize(GenericReader reader)
                      {
                          base.Deserialize( reader );
                          int version = reader.ReadInt();
                      }
                  }
              }
