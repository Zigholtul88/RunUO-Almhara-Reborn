using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0x26BF, 0x26C9 )]
	public class DoubleBladedStaff : BaseSpear
	{
		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosMinDamage{ get{ return 65; } }
		public override int AosMaxDamage{ get{ return 95; } }
		public override int AosSpeed{ get{ return 49; } }
		public override float MlSpeed{ get{ return 2.25f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override int DefMaxRange{ get{ return 2; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

		[Constructable]
		public DoubleBladedStaff() : base( 0x26BF )
		{
                        Name = "Double Bladed Staff - (Lv. 60)";
			Weight = 8.0;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 60 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 60 in order to equip this." );
				return false;
			}
		}

		public DoubleBladedStaff( Serial serial ) : base( serial )
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