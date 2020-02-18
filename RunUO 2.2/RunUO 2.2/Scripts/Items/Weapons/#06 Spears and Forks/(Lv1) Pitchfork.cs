using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0xE87, 0xE88 )]
	public class Pitchfork : BaseSpear
	{
		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 2; } }
		public override int AosMaxDamage{ get{ return 10; } }
		public override int AosSpeed{ get{ return 45; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override int DefMaxRange{ get{ return 2; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

		[Constructable]
		public Pitchfork() : base( 0xE87 )
		{
                        Name = "Pitchfork - (Lv. 1)";
			Weight = 11.0;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 1 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 1 in order to equip this." );
				return false;
			}
		}

		public Pitchfork( Serial serial ) : base( serial )
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