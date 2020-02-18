//Customized By Mrs Death
using System;
using Server;

namespace Server.Items

{
              
              public class SabinGloves : BlackStaff
              {
	      public override int ArtifactRarity{ get{ return 6; } }
              public override int AosMinDamage{ get{ return 20; } }
              public override int AosMaxDamage{ get{ return 24; } }
              
                      [Constructable]
                      public SabinGloves() 
                      {
                                        Weight = 5;
                                        Name = "[FF6] Sabin's Fists";
                                        Hue = 1175;
					ItemID = 10130;
              				SkillBonuses.SetValues( 0, SkillName.Wrestling, 5.0 );
                                        WeaponAttributes.HitDispel = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitFireball = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitHarm = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLeechHits = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLeechMana = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLeechStam = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLightning = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLowerAttack = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLowerDefend = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitMagicArrow = Utility.Random( 1, 10 );
              
                                        Attributes.AttackChance = Utility.Random( 1, 20 );
                                        Attributes.DefendChance = Utility.Random( 1, 20 );
                                       Attributes.ReflectPhysical = Utility.Random( 1, 20 );
              
                                    }
              
                      public SabinGloves( Serial serial ) : base( serial )  
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
