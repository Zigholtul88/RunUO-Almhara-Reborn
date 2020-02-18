using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0x26C2, 0x26CC )]
	public class CompositeBow : BaseRanged
	{
		public override Type TypeUsed{ get{ return typeof( Arrow ); } }
		
		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return TypeSelected( TypeUsed ); } }		
		public override Item Ammo{ get{ return AmmoSelected( TypeUsed ); } }

		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 12; } }
		public override int AosMaxDamage{ get{ return 25; } }
		public override int AosSpeed{ get{ return 25; } }
		public override float MlSpeed{ get{ return 4.00f; } }

		public override int DefMaxRange{ get{ return 10; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }

		[Constructable]
		public CompositeBow() : base( 0x26C2 )
		{
                        Name = "Composite Bow - (Lv. 20)";
			Weight = 5.0;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 20 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 20 in order to equip this." );
				return false;
			}
		}

		public CompositeBow( Serial serial ) : base( serial )
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