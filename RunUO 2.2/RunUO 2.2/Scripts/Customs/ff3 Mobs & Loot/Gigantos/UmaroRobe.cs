//Customized By Mrs Death
using System;
using Server;


namespace Server.Items
{
              public class UmaroRobe: HoodedShroudOfShadows
{
	public override int ArtifactRarity{ get{ return 6; } }
              
              [Constructable]
              public UmaroRobe()
{

                          Weight = 10;
                          Name = "[FF6] Umaro's Robe";
                          Hue = 1150;
              
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
              public UmaroRobe( Serial serial ) : base( serial )
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
