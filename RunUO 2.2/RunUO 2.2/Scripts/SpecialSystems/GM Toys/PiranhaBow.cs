using System; 
using Server; 
using Server.Items; 

namespace Server.Items 
{ 
	[FlipableAttribute( 15804, 15805 )]
        public class PiranhaBow : BaseRanged 
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

		public override int DefMaxRange{ get{ return 15; } }

		public override int InitMinHits{ get{ return 41; } }
		public override int InitMaxHits{ get{ return 90; } }
       
                public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } } 
       
                private int ManaReq = 0;

		[Constructable]
		public PiranhaBow() : base( 15804 )
		{
                        Name = "Piranha Bow";
			Weight = 6.0;
                        Hue = 0x43;
			Layer = Layer.TwoHanded;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			fire = chaos = direct = cold = nrgy = phys = 0;
                        pois = 100;
		}
       
		public PiranhaBow( Serial serial ) : base( serial )
		{
		}

                public override bool OnFired( Mobile attacker, Mobile defender ) 
                { 
                        if(attacker.Mana <= ManaReq) 
                           return false; 
                        attacker.Mana -= ManaReq; 
                        attacker.MovingParticles( defender, 0x36CB, 7, 0, false, true, 3043, 4043, 0x211 );  
                        attacker.PlaySound( 0x22F);

                        return true; 
                } 

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

                        defender.FixedParticles( 0x36CB, 1, 9, 9911, 67, 5, EffectLayer.Head );
		        defender.PlaySound( 0x22F );
		        defender.ApplyPoison( attacker, Poison.Lethal ); 
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
