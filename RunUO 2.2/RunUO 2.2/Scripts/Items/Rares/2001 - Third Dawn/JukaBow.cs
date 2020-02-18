using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13B2, 0x13B1 )]
	public class JukaBow : BaseRanged
	{
		public override Type TypeUsed{ get{ return typeof( Arrow ); } }
		
		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return TypeSelected( TypeUsed ); } }		
		public override Item Ammo{ get{ return AmmoSelected( TypeUsed ); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MortalStrike; } }

		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosDexterityReq{ get{ return 50; } }
		public override int AosMinDamage{ get{ return 9; } }
		public override int AosMaxDamage{ get{ return 41; } }
		public override int AosSpeed{ get{ return 20; } }
		public override float MlSpeed{ get{ return 4.25f; } }

		public override int DefMaxRange{ get{ return 10; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 100; } }

		public override int DefHitSound{ get{ return 0x307; } }
		public override int DefMissSound{ get{ return 0x308; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsModified
		{
			get{ return ( Hue == 0x453 ); }
		}

		[Constructable]
		public JukaBow() : base( 0x13B2 )
		{
			Weight = 10.0;
			Layer = Layer.TwoHanded;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( IsModified )
			{
				from.SendMessage( "That has already been modified." );
			}
			else if ( !IsChildOf( from.Backpack ) )
			{
				from.SendMessage( "This must be in your backpack to modify it." );
			}
			else if ( from.Skills[SkillName.Fletching].Base < 100.0 )
			{
				from.SendMessage( "Only a grandmaster bowcrafter can modify this weapon." );
			}
			else
			{
				from.BeginTarget( 2, false, Targeting.TargetFlags.None, new TargetCallback( OnTargetGears ) );
				from.SendMessage( "Select the gears you wish to use." );
			}
		}

		public void OnTargetGears( Mobile from, object targ )
		{
			Gears g = targ as Gears;

			if ( g == null || !g.IsChildOf( from.Backpack ) )
			{
				from.SendMessage( "Those are not gears." ); // Apparently gears that aren't in your backpack aren't really gears at all. :-(
			}
			else if ( IsModified )
			{
				from.SendMessage( "That has already been modified." );
			}
			else if ( !IsChildOf( from.Backpack ) )
			{
				from.SendMessage( "This must be in your backpack to modify it." );
			}
			else if ( from.Skills[SkillName.Fletching].Base < 100.0 )
			{
				from.SendMessage( "Only a grandmaster bowcrafter can modify this weapon." );
			}
			else
			{
				g.Consume();

				Hue = 0x453;

			        Attributes.AttackChance = 15;
			        Attributes.WeaponDamage = 25;
			        Attributes.WeaponSpeed = 15;
				Slayer = (SlayerName)Utility.Random( 2, 25 );

				from.SendMessage( "You modify it." );
			}
		}

		public JukaBow( Serial serial ) : base( serial )
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