using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0xF4D, 0xF4E )]
	public class Bardiche : BasePoleArm
	{
		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return 80; } }
		public override int AosMaxDamage{ get{ return 130; } }
		public override int AosSpeed{ get{ return 26; } }
		public override float MlSpeed{ get{ return 3.75f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override int DefMaxRange{ get{ return 2; } }

		[Constructable]
		public Bardiche() : base( 0xF4D )
		{
                        Name = "Bardiche - (Lv. 70)";
			Weight = 7.0;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 70 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 70 in order to equip this." );
				return false;
			}
		}

		public Bardiche( Serial serial ) : base( serial )
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