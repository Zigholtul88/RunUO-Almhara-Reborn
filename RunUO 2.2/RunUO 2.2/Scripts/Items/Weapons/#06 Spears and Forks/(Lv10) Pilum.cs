using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15379, 15380 )]
	public class Pilum : BaseSpear
	{
		public override int AosStrengthReq{ get{ return 15; } }
		public override int AosMinDamage{ get{ return 14; } }
		public override int AosMaxDamage{ get{ return 24; } }
		public override int AosSpeed{ get{ return 50; } }
		public override float MlSpeed{ get{ return 2.00f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

		[Constructable]
		public Pilum() : base( 15379 )
		{
                        Name = "Pilum - (Lv. 10)";
			Weight = 4.0;
			Layer = Layer.OneHanded;
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

		public Pilum( Serial serial ) : base( serial )
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