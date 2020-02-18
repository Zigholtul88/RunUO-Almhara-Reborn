using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 15804, 15805 )]
	public class BowOfThePoet : BaseRanged
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

		public override int InitMinHits{ get{ return 30; } }
		public override int InitMaxHits{ get{ return 100; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }
		
		public int m_Line = 1;

		[Constructable]
		public BowOfThePoet() : base( 15804 )
		{
			Hue = 2224;
			Name = "Bow Of the Poet";
			Layer = Layer.TwoHanded;
			
			Attributes.AttackChance = 15;
			Attributes.SpellChanneling = 1;
			Attributes.WeaponSpeed = 30;
			Attributes.WeaponDamage= 20;
			
			Slayer = SlayerName.Silver;

			LootType = LootType.Blessed;
			DurabilityLevel = WeaponDurabilityLevel.Indestructible;

		}	
		
		[CommandProperty( AccessLevel.GameMaster )] 
		public int Line 
		{ 
			get{ return m_Line; } 
			set{ m_Line = value; } 
		}
		
		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			fire = chaos = direct = cold = nrgy = pois = 0;
                        phys = 100;
		}

                public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{	
			switch ( Utility.Random( 5 ) )
    		{ 
        		case 1: defender.Damage( 50, attacker );
						defender.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.Waist ); //FlameStrike Effect
						defender.PlaySound( 0x208 );
						if (Line == 1)
						{	attacker.Say( "Let your past be forgotten"); Line++;}
						else if (Line == 2)
						{	attacker.Say( "Restrain your wish for murder"); Line++;}
						else if (Line == 3)
						{	attacker.Say( "The smell of blood's rotten"); Line++;}
						else if (Line == 4)
						{	attacker.Say( "Let war continue no further!"); Line = 1;}

    	           	 break;
    		}
			base.OnHit( attacker, defender, damageBonus );
		}

		public BowOfThePoet( Serial serial ) : base( serial )
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