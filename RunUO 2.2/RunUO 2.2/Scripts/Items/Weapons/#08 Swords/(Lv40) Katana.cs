using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0x13FF, 0x13FE )]
	public class Katana : BaseSword
	{
		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return 35; } }
		public override int AosMaxDamage{ get{ return 70; } }
		public override int AosSpeed{ get{ return 58; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public Katana() : base( 0x13FF )
		{
                        Name = "Katana - (Lv. 40)";
			Weight = 6.0;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 40 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 40 in order to equip this." );
				return false;
			}
		}

		public Katana( Serial serial ) : base( serial )
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