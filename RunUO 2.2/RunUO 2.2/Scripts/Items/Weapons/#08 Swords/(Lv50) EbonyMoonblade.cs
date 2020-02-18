using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15822, 15823 )]
	public class EbonyMoonblade : BaseSword
	{
		public override int AosStrengthReq{ get{ return 50; } }
		public override int AosMinDamage{ get{ return 50; } }
		public override int AosMaxDamage{ get{ return 100; } }
		public override int AosSpeed{ get{ return 45; } }
		public override float MlSpeed{ get{ return 2.75f; } }

		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x239; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public EbonyMoonblade() : base( 15822 )
		{
                        Name = "Ebony Moonblade - (Lv. 50)";
			Weight = 6.0;
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

		public EbonyMoonblade( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}