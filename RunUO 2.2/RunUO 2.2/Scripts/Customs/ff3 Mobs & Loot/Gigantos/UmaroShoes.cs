//Customized By Mrs Death
using System;
using Server;


namespace Server.Items
{
              public class UmaroShoes: Shoes
{
	public override int ArtifactRarity{ get{ return 6; } }
              
              [Constructable]
              public UmaroShoes()
{

                          Weight = 3;
                          Name = "[FF6] Umaro's Shoes";
                          Hue = 1154;
              
              Attributes.AttackChance = 10;
              Attributes.BonusDex = 10;
              Attributes.BonusHits = 15;
              Attributes.BonusInt = 10;
              Attributes.BonusMana = 15;
              Attributes.BonusStam = 15;
              Attributes.DefendChance = 10;
              Attributes.ReflectPhysical = 25;
              Attributes.SpellDamage = 25;
              Attributes.WeaponDamage = 20;
	      Attributes.WeaponSpeed = 10;

                  }
              public UmaroShoes( Serial serial ) : base( serial )
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
