using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Engines.Harvest;

namespace Server.Items
{
	[FlipableAttribute( 0x26BA, 0x26C4 )]
	public class Scythe : BasePoleArm
	{
		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 90; } }
		public override int AosMaxDamage{ get{ return 150; } }
		public override int AosSpeed{ get{ return 32; } }
		public override float MlSpeed{ get{ return 3.50f; } }

		public override int DefMaxRange{ get{ return 2; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public Scythe() : base( 0x26BA )
		{
                        Name = "Scythe - (Lv. 80)";
			Weight = 5.0;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 80 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 80 in order to equip this." );
				return false;
			}
		}

		public Scythe( Serial serial ) : base( serial )
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