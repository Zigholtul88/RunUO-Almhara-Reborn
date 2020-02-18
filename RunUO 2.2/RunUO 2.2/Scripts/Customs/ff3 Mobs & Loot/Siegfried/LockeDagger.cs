//Customized By Mrs Death
using System;
using Server;

namespace Server.Items

{
              
              public class LockeDagger : Dagger
              {
	      public override int ArtifactRarity{ get{ return 6; } }
              public override int AosMinDamage{ get{ return 20; } }
              public override int AosMaxDamage{ get{ return 25; } }

                      [Constructable]
                      public LockeDagger() 
                      {
                                        Weight = 5;
                                        Name = "[FF6] Locke's Thief Knife";
                                        Hue = 598 ;
              				SkillBonuses.SetValues( 0, SkillName.Stealing, 5.0 );
                                        WeaponAttributes.HitDispel = 45;
                                        WeaponAttributes.HitFireball = 25;
                                        WeaponAttributes.HitHarm = 25;
                                        WeaponAttributes.HitLightning = 80;
                                        WeaponAttributes.HitLowerAttack = 35;
                                        WeaponAttributes.HitLowerDefend = 15;
                                        WeaponAttributes.HitMagicArrow = 45;
                                       
              
                                        Attributes.AttackChance = 15;
                                        Attributes.DefendChance = 15;
                                        Attributes.ReflectPhysical = 15;
                                        Attributes.WeaponDamage = 10;
                                        Attributes.WeaponSpeed = 5;
              
                                    }
              
                      public LockeDagger( Serial serial ) : base( serial )  
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
