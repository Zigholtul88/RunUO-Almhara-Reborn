using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15830, 15831 )]
	public class EbonyGlassBardiche : BasePoleArm
	{
		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 100; } }
		public override int AosMaxDamage{ get{ return 200; } }
		public override int AosSpeed{ get{ return 25; } }
		public override float MlSpeed{ get{ return 3.75f; } }

		public override int DefMaxRange{ get{ return 2; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public EbonyGlassBardiche() : base( 15830 )
		{
                        Name = "Ebony Glass Bardiche - (Lv. 90)";
			Weight = 12.0;
			Layer = Layer.TwoHanded;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 90 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 90 in order to equip this." );
				return false;
			}
		}

		public EbonyGlassBardiche( Serial serial ) : base( serial )
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