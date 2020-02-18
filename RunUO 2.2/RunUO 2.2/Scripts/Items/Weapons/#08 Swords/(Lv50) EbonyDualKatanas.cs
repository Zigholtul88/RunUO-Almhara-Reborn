using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15828, 15829 )]
	public class EbonyDualKatanas : BaseSword
	{
		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosMinDamage{ get{ return 50; } }
		public override int AosMaxDamage{ get{ return 100; } }
		public override int AosSpeed{ get{ return 40; } }
		public override float MlSpeed{ get{ return 2.75f; } }

		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public EbonyDualKatanas() : base( 15828 )
		{
                        Name = "Ebony Dual Katanas - (Lv. 50)";
			Weight = 8.0;
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

		public EbonyDualKatanas( Serial serial ) : base( serial )
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