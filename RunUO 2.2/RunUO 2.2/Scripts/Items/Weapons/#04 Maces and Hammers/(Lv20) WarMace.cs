using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0x1407, 0x1406 )]
	public class WarMace : BaseBashing
	{
		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return 18; } }
		public override int AosMaxDamage{ get{ return 40; } }
		public override int AosSpeed{ get{ return 32; } }
		public override float MlSpeed{ get{ return 4.00f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public WarMace() : base( 0x1407 )
		{
                        Name = "War Mace - (Lv. 20)";
			Weight = 17.0;
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

		public WarMace( Serial serial ) : base( serial )
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