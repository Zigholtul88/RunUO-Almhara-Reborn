using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0x2D25, 0x2D31 )]
	public class WildStaff : BaseStaff
	{
		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 30; } }
		public override int AosMaxDamage{ get{ return 65; } }
		public override int AosSpeed{ get{ return 33; } }
		public override float MlSpeed{ get{ return 2.25f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public WildStaff() : base( 0x2D25 )
		{
                        Name = "Wild Staff - (Lv. 35)";
			Weight = 8.0;
			Layer = Layer.TwoHanded;

			Attributes.SpellChanneling = 1;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 35 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 35 in order to equip this." );
				return false;
			}
		}

		public WildStaff( Serial serial ) : base( serial )
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