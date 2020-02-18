//Customized By Mrs Death
using System;
using Server;

namespace Server.Items

{
              
              public class CyanBlade : Katana
              {
	      public override int ArtifactRarity{ get{ return 6; } }
              public override int AosMinDamage{ get{ return 25; } }
              public override int AosMaxDamage{ get{ return 40; } }
              
                      [Constructable]
                      public CyanBlade() 
                      {
                                        Weight = 7;
                                        Name = "[FF6] Cyan's Zantetsuken";
              
                                        WeaponAttributes.HitLeechHits = 80;
                                        WeaponAttributes.HitLightning = 80;
                                        WeaponAttributes.HitLeechStam = 80;
                                        WeaponAttributes.HitPhysicalArea = 80;
                                        WeaponAttributes.HitLeechMana = 80;
              
                                        Attributes.AttackChance = 50;
                                        Attributes.DefendChance = 25;
                                        Attributes.ReflectPhysical = 10;
                                        Attributes.SpellDamage = 15;
                                        Attributes.WeaponDamage = 80;
                                        Attributes.WeaponSpeed = 35;
              
                                    }
		
		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = chaos = direct = 0;
			pois = 50;
                  nrgy = 50;
		}


                      public CyanBlade( Serial serial ) : base( serial )  
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
