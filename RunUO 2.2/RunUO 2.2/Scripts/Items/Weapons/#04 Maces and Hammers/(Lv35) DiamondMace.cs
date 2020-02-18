using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0x2D24, 0x2D30 )]
	public class DiamondMace : BaseBashing
	{
		public override int AosStrengthReq{ get{ return 20; } }
		public override int AosMinDamage{ get{ return 28; } }
		public override int AosMaxDamage{ get{ return 65; } }
		public override int AosSpeed{ get{ return 30; } }
		public override float MlSpeed{ get{ return 3.00f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public DiamondMace() : base( 0x2D24 )
		{
                        Name = "Diamond Mace - (Lv. 35)";
			Weight = 10.0;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 35 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 35 in order to equip this." );
				return false;
			}
		}

		public DiamondMace( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}