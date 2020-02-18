using System; 
using Server.Network; 
using Server.Items; 

namespace Server.Items 
{ 
	[FlipableAttribute( 15802, 15803 )]
   public class FireAxe : BaseAxe 
   { 
      public override int ArtifactRarity{ get{ return 15; } } 

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = chaos = direct = cold = nrgy = pois = 0;
                        fire = 100;
		}

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.DoubleStrike; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ShadowStrike; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return 5; } }
		public override int AosMaxDamage{ get{ return 39; } }
		public override int AosSpeed{ get{ return 30; } }
		public override float MlSpeed{ get{ return 3.50f; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 90; } }
 

      public override void OnHit( Mobile attacker, Mobile defender, double damageBonus ) 
      { 
      	    base.OnHit( attacker, defender, damageBonus );
            
            defender.PlaySound( 0x208 ); 
            Effects.SendTargetEffect( defender, 0x3709, 32 ); 
      } 

      [Constructable] 
      public FireAxe() : base( 0x13FB ) 
      { 
         Weight = 2.0; 
         Name = "A Fire Axe"; 
         Hue = 2594; 
         Consecrated = true; 
         Attributes.SpellChanneling = 1; 
         Attributes.CastSpeed = 2; 
         Attributes.CastRecovery = 2; 
         Attributes.AttackChance = 15; 
         Attributes.DefendChance = 15; 
         Attributes.WeaponDamage = 20; 
      } 

      public FireAxe( Serial serial ) : base( serial ) 
      { 
      } 

      public override void Serialize( GenericWriter writer ) 
      { 
         base.Serialize( writer ); 

         writer.Write( (int) 0 ); // version 
      } 

      public override void Deserialize( GenericReader reader ) 
      { 
         base.Deserialize( reader ); 

         int version = reader.ReadInt(); 
      } 
   } 
}