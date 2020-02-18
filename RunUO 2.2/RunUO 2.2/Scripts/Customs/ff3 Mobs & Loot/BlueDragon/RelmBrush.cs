//Customized By Mrs Death
using System;
using Server;

namespace Server.Items

{
              
              public class RelmBrush : Club
              {
	      public override int ArtifactRarity{ get{ return 6; } }
              public override int AosMinDamage{ get{ return 20; } }
              public override int AosMaxDamage{ get{ return 24; } }
              
                      [Constructable]
                      public RelmBrush() 
                      {
                                        Weight = 5;
                                        Name = "[FF6] Relm's Paintbrush";
                                        Hue = 0;
              
                                        WeaponAttributes.HitDispel = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitFireball = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitHarm = Utility.Random( 1, 10 );
					WeaponAttributes.HitEnergyArea = 80;
                                        WeaponAttributes.HitLeechHits = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLeechMana = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLeechStam = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLightning = Utility.Random( 75, 80 );
                                        WeaponAttributes.HitLowerAttack = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitLowerDefend = Utility.Random( 1, 10 );
                                        WeaponAttributes.HitMagicArrow = Utility.Random( 1, 10 );
              
                                        Attributes.AttackChance = Utility.Random( 1, 20 );
                                        Attributes.DefendChance = Utility.Random( 1, 20 );
                                        Attributes.ReflectPhysical = Utility.Random( 1, 20 );
              
                                    }
					
		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = pois = nrgy = chaos = direct = 0;
			nrgy = 100;
		}

                      public RelmBrush( Serial serial ) : base( serial )  
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
