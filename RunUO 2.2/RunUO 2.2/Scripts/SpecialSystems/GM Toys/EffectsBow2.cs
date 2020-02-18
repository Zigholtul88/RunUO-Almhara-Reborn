using System;
using System.Collections;
using Server.Items;
using Server.Misc; 
using Server.Mobiles; 
using Server.Network;
using Server.Targeting; 
using Server.Regions; 
using Server.SkillHandlers; 

namespace Server.Items
{
	[FlipableAttribute( 0xF50, 0xF4F )]
	public class EffectsBow2 : BaseRanged
	{
		public override Type TypeUsed{ get{ return typeof( Bolt ); } }
		
		public override int EffectID{ get{ return 0x1BFE; } }
		public override Type AmmoType{ get{ return TypeSelected( TypeUsed ); } } // { get{ return typeof( Bolt ); } }		
		public override Item Ammo{ get{ return AmmoSelected( TypeUsed ); } } // { get{ return new Bolt(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

		public override int AosStrengthReq{ get{ return 15; } }
		public override int AosMinDamage{ get{ return 8; } }
		public override int AosMaxDamage{ get{ return 43; } }
		public override int AosSpeed{ get{ return 18; } }
		public override float MlSpeed{ get{ return 3.00f; } }

		public override int DefMaxRange{ get{ return 10; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

                public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } } 

                private int ManaReq = 0; 

		[Constructable]
		public EffectsBow2() : base( 0xF50 )
		{
                        Name = "Effects Bow 2";
			Weight = 7.0;
			Layer = Layer.TwoHanded;
		}

		public EffectsBow2( Serial serial ) : base( serial )
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
                         defender.FixedParticles( 0x375A, 1, 30, 2405, 78, 0, EffectLayer.Head ); 
                         defender.PlaySound( 814 ); 
                         break; 
                      case 1: 
                         defender.FixedParticles( 0x37B9, 1, 30, 2406, 85, 0, EffectLayer.RightHand );
                         defender.PlaySound( 1088 ); 
                         break; 
                      case 2: 
                         defender.FixedParticles( 0x376A, 1, 31, 2404, 80, 0, EffectLayer.LeftHand );
                         defender.PlaySound( 814 ); 
                         break; 
                      case 3: 
                         defender.FixedParticles( 0x37C4, 1, 31, 2405, 88, 0, EffectLayer.Waist ); 
                         defender.PlaySound( 1088 );
                         break; 
                      case 4: 
                         defender.FixedParticles( 0x3728, 1, 30, 2406, 88, 0, EffectLayer.LeftFoot ); 
                         defender.PlaySound( 814 );
                         break; 
                      case 5: 
                         defender.FixedParticles( 0x3779, 1, 30, 2404, 85, 0, EffectLayer.RightFoot );
                         defender.PlaySound( 1088 ); 
                         break; 
                      case 6: 
                         defender.FixedParticles( 0x376A, 1, 31, 2405, 80, 0, EffectLayer.CenterFeet );
                         defender.PlaySound( 814 ); 
                         break; 
                   }       
                   for(int x = defender.X - 5; x <= defender.X + 5; x++) 
                   { 
                      for(int y = defender.Y - 5; y <= defender.Y + 5; y++) 
                      { 
                         Blood g = new Blood(); 
                         g.Visible = false; 
                         g.MoveToWorld( new Point3D( x, y, defender.Z ), defender.Map ); 
                         switch ( Utility.Random( 20 ) ) 
                         { 
                            case 0:
                            { 
                               Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x375A, 1, 30, 2405, 88 ); 
                               Effects.PlaySound( g, g.Map, 814 ); 
                               break; 
                            } 
                            case 1:
                            { 
                               Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x37B9, 1, 30, 2406, 85 ); 
                               Effects.PlaySound( g, g.Map, 1088 ); 
                               break; 
                            } 
                            case 2:
                            { 
                               Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x376A, 1, 31, 2405, 80 );
                               Effects.PlaySound( g, g.Map, 814 );  
                               break; 
                            } 
                            case 3:
                            { 
                               Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x37C4, 1, 31, 2405, 88 ); 
                               Effects.PlaySound( g, g.Map, 1088 );
                               break; 
                            } 
                            case 4:
                            { 
                               Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x3728, 1, 30, 2406, 88 ); 
                               Effects.PlaySound( g, g.Map, 814 ); 
                               break; 
                            } 
                            case 5:
                            { 
                               Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x37B9, 1, 30, 2406, 85 ); 
                               Effects.PlaySound( g, g.Map, 1088 ); 
                               break; 
                            } 
                            case 6:
                            { 
                               Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x376A, 1, 31, 2404, 80 );
                               Effects.PlaySound( g, g.Map, 814 );  
                               break; 
                            } 
                            case 7:
                            { 
                               Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x37C4, 1, 31, 2406, 88 ); 
                               Effects.PlaySound( g, g.Map, 1088 );
                               break; 
                            } 
                            case 8:
                            { 
                               Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x3728, 1, 30, 2405, 85 ); 
                               Effects.PlaySound( g, g.Map, 814 ); 
                               break; 
                            } 
                            case 9:
                            { 
                               Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x37B9, 1, 30, 2404, 88 ); 
                               Effects.PlaySound( g, g.Map, 1088 ); 
                               break; 
                            } 
                            case 10:
                            { 
                               Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x376A, 1, 31, 2406, 88 );
                               Effects.PlaySound( g, g.Map, 814 );  
                               break; 
                            } 
                            case 11:
                            { 
                               Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x3779, 1, 31, 2405, 85 ); 
                               Effects.PlaySound( g, g.Map, 1088 );
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
                            m.FixedParticles( 0x37C4, 1, 31, 2405, 85, 0, EffectLayer.CenterFeet );
                            m.PlaySound( 1088 ); 
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