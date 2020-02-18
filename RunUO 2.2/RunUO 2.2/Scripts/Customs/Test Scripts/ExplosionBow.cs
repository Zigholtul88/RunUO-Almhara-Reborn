using System; 
using System.Collections; 
using Server.Targeting; 
using Server.Network; 
using Server.Mobiles; 
using Server.Items; 
using Server.Misc; 
using Server.Regions; 
using Server.SkillHandlers; 

namespace Server.Items 
{    
	[FlipableAttribute( 15804, 15805 )]
   public class ExplosionBow : BaseRanged 
   { 
		public override Type TypeUsed{ get{ return typeof( Arrow ); } }
		
		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return TypeSelected( TypeUsed ); } }		
		public override Item Ammo{ get{ return AmmoSelected( TypeUsed ); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.LightningArrow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.PsychicAttack; } }

		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 9; } }
		public override int AosMaxDamage{ get{ return 41; } }
		public override int AosSpeed{ get{ return 20; } }
		public override float MlSpeed{ get{ return 3.00f; } }

		public override int DefMaxRange{ get{ return 10; } }

		public override int InitMinHits{ get{ return 41; } }
		public override int InitMaxHits{ get{ return 90; } }

      private int ManaReq = 0; 
       
      public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } } 

      [Constructable] 
      public ExplosionBow() : base( 15804 )
      { 
         Weight = 7.0; 
         Layer = Layer.TwoHanded; 
         Name = "Magical Explosion bow"; 
          
      } 

      public ExplosionBow( Serial serial ) : base( serial ) 
      { 
      } 
    
      public override bool OnFired( Mobile attacker, Mobile defender ) 
      { 
         if(attacker.Mana <= ManaReq) 
            return false; 
         attacker.Mana -= ManaReq; 
         attacker.MovingEffect( defender, EffectID, 18, 1, false, false ); 

         return true; 
      } 
       
      public override void OnHit( Mobile attacker, Mobile defender, double damageBonus ) 
      { 
         int bombwhere = Utility.Random( 7 ); 
         switch( bombwhere ) 
         { 
            case 0: 
               defender.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head ); 
               break; 
            case 1: 
               defender.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.RightHand ); 
               break; 
            case 2: 
               defender.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.LeftHand ); 
               break; 
            case 3: 
               defender.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Waist ); 
               break; 
            case 4: 
               defender.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.LeftFoot ); 
               break; 
            case 5: 
               defender.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.RightFoot ); 
               break; 
            case 6: 
               defender.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.CenterFeet ); 
               break; 
         }       
         for(int x = defender.X - 5; x <= defender.X + 5; x++) 
         { 
            for(int y = defender.Y - 5; y <= defender.Y + 5; y++) 
            { 
               Blood g = new Blood(); 
               g.Visible = false; 
               g.MoveToWorld( new Point3D( x, y, defender.Z ), defender.Map ); 
               switch ( Utility.Random( 10 ) ) 
               { 
                  case 0: // Fire column 
                  { 
                     Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x3709, 10, 30, 5052 ); 
                     Effects.PlaySound( g, g.Map, 0x208 ); 
                     break; 
                  } 
                  case 1: // Explosion 
                   
                  { 
                     Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36BD, 20, 10, 5044 ); 
                     Effects.PlaySound( g, g.Map, 0x307 ); 
                     break; 
                  } 
                  case 2: 
                  { 
                     Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36FE, 10, 10, 5052 ); 
                     break; 
                  } 
                  default: 
                     break; 
               } 
            } 
         } 
         int explosionDamage = Utility.Random( 30, 10 ); 
         ArrayList targets = new ArrayList(); 
         IPooledEnumerable eable = defender.Map.GetMobilesInRange( new Point3D( defender.Location ), 5 ); 
         foreach ( Mobile m in eable ) 
         { 
            targets.Add( m ); 
         }    
         eable.Free(); 
         if ( targets.Count > 0 ) 
         { 
            explosionDamage /= targets.Count; 
            for ( int i = 0; i < targets.Count; ++i ) 
            { 
               Mobile m = (Mobile)targets[i]; 
                  m.Damage( explosionDamage ); 
                  m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.CenterFeet ); 
                  m.PlaySound( 0x208 ); 
            }    
         }       
         base.OnHit( attacker, defender, damageBonus ); 
      } 
         
      public override void OnMiss( Mobile attacker, Mobile defender ) 
      { 
         base.OnMiss( attacker, defender ); 
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