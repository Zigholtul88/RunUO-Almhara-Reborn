using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0x13F6, 0x13F7 )]
	public class ButcherKnife : BaseKnife
	{
		public override int AosStrengthReq{ get{ return 5; } }
		public override int AosMinDamage{ get{ return 10; } }
		public override int AosMaxDamage{ get{ return 15; } }
		public override int AosSpeed{ get{ return 40; } }
		public override float MlSpeed{ get{ return 2.25f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public ButcherKnife() : base( 0x13F6 )
		{
                        Name = "Butcher Knife - (Lv. 10)";
			Weight = 1.0;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 10 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 10 in order to equip this." );
				return false;
			}
		}

		public ButcherKnife( Serial serial ) : base( serial )
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