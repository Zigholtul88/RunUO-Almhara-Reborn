using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0x27A6, 0x27F1 )]
	public class Tetsubo : BaseBashing
	{
		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosMinDamage{ get{ return 50; } }
		public override int AosMaxDamage{ get{ return 85; } }
		public override int AosSpeed{ get{ return 32; } }
		public override float MlSpeed{ get{ return 2.50f; } }

		public override int DefHitSound{ get{ return 0x233; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Bash2H; } }

		[Constructable]
		public Tetsubo() : base( 0x27A6 )
		{
                        Name = "Tetsubo - (Lv. 45)";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 45 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 45 in order to equip this." );
				return false;
			}
		}

		public Tetsubo( Serial serial ) : base( serial )
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