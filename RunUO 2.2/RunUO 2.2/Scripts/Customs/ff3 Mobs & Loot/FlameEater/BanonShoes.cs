//Customized By Mrs Death
using System;
using Server;
using Server.Items;

namespace Server.Items
{
              public class BanonShoes: Shoes
{
	public override int ArtifactRarity{ get{ return 6; } }
            
              [Constructable]
              public BanonShoes()
{

                          Weight = 7;
                          Name = "[FF6] Banon's Shoes";
                          Hue = 1109;
              
              Attributes.BonusDex = 10;
              Attributes.BonusHits = 10;
              Attributes.BonusInt = 10;
              Attributes.DefendChance = 10;
              Attributes.LowerManaCost = 10;
              Attributes.Luck = 100;
              Attributes.NightSight = 1;
              Attributes.ReflectPhysical = 10;
              Attributes.RegenHits = 1;
              Attributes.WeaponDamage = 10;
              Attributes.BonusStr = 10;
                  }
              public BanonShoes( Serial serial ) : base( serial )
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
