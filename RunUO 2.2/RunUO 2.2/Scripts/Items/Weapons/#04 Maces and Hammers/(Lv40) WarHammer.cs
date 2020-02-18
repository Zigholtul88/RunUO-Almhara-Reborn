using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0x1439, 0x1438 )]
	public class WarHammer : BaseBashing
	{
		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return 35; } }
		public override int AosMaxDamage{ get{ return 75; } }
		public override int AosSpeed{ get{ return 31; } }
		public override float MlSpeed{ get{ return 3.75f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Bash2H; } }

		[Constructable]
		public WarHammer() : base( 0x1439 )
		{
                        Name = "War Hammer - (Lv. 40)";
			Weight = 10.0;
			Layer = Layer.TwoHanded;
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

		public WarHammer( Serial serial ) : base( serial )
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