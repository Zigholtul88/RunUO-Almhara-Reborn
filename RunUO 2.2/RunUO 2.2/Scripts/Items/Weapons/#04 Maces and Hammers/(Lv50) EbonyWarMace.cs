using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15810, 15811 )]
	public class EbonyWarMace : BaseBashing
	{
		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return 60; } }
		public override int AosMaxDamage{ get{ return 110; } }
		public override int AosSpeed{ get{ return 32; } }
		public override float MlSpeed{ get{ return 2.75f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public EbonyWarMace() : base( 15810 )
		{
                        Name = "Ebony War Mace - (Lv. 50)";
			Weight = 17.0;
			Layer = Layer.TwoHanded;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 50 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 50 in order to equip this." );
				return false;
			}
		}

		public EbonyWarMace( Serial serial ) : base( serial )
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