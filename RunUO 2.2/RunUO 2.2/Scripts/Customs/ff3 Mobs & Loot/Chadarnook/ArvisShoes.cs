//Customized By Mrs Death
using System;
using Server;
using Server.Items;

namespace Server.Items
{
              public class ArvisShoes: Shoes
{
	public override int ArtifactRarity{ get{ return 6; } }
            
              [Constructable]
              public ArvisShoes()
{

                          Weight = 7;
                          Name = "[FF6] Arvis' Shoes";
                          Hue = 1055;
              
              Attributes.BonusDex = 10;
              Attributes.BonusHits = 5;
              Attributes.BonusInt = 15;
              Attributes.DefendChance = 10;
              Attributes.LowerManaCost = 10;
              Attributes.Luck = 150;
              Attributes.NightSight = 1;
              Attributes.ReflectPhysical = 15;
              Attributes.RegenHits = 1;
              Attributes.WeaponDamage = 15;
              Attributes.BonusStr = 25;
                  }
              public ArvisShoes( Serial serial ) : base( serial )
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
