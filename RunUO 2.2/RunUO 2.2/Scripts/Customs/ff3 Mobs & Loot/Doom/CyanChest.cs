//Customized By Mrs Death
using System;
using Server;
using Server.Items;

namespace Server.Items
{
              public class CyanChest: PlateChest
{
	public override int ArtifactRarity{ get{ return 6; } }
            
              [Constructable]
              public CyanChest()
{

                          Weight = 7;
                          Name = "[FF6] Cyan's Chest";
                          Hue = 405;
              
              Attributes.BonusDex = 15;
              Attributes.BonusHits = 15;
              Attributes.BonusInt = 15;
              Attributes.DefendChance = 15;
              Attributes.LowerManaCost = 20;
              Attributes.Luck = 50;
              Attributes.NightSight = 1;
              Attributes.ReflectPhysical = 10;
              Attributes.RegenHits = 5;
              Attributes.WeaponDamage = 5;
              ArmorAttributes.DurabilityBonus = 100;
              ColdBonus = 15;
              EnergyBonus = 15;
              FireBonus = 15;
              PhysicalBonus = 40;
              PoisonBonus = 15;
              StrBonus = 25;
                  }
              public CyanChest( Serial serial ) : base( serial )
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
