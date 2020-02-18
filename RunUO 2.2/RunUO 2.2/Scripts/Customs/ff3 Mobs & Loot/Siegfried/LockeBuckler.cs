//Customized By Mrs Death
using System;
using Server;

namespace Server.Items
{
              public class LockeBuckler: Buckler
{
	public override int ArtifactRarity{ get{ return 6; } }

              
              [Constructable]
              public LockeBuckler()
{

                          Weight = 6;
                          Name = "[FF6] Locke's Buckler";
                          Hue = 598;
              Attributes.AttackChance = 15;
              Attributes.BonusDex = 15;
	      Attributes.BonusStr = 15;
              Attributes.BonusHits = 10;
              Attributes.BonusInt = 15;
              Attributes.BonusMana = 10;
              Attributes.BonusStam = 10;
              Attributes.DefendChance = 15;
              Attributes.ReflectPhysical = 15;
              Attributes.SpellDamage = 15;
              Attributes.WeaponDamage = 10;
              ColdBonus = 3;
              EnergyBonus = 2;
              FireBonus = 6;
              PhysicalBonus = 1;
              PoisonBonus = 4;
                  }
              public LockeBuckler( Serial serial ) : base( serial )
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
