using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0xDF1, 0xDF0 )]
	public class BlackStaff : BaseStaff
	{
		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 28; } }
		public override int AosMaxDamage{ get{ return 60; } }
		public override int AosSpeed{ get{ return 35; } }
		public override float MlSpeed{ get{ return 2.75f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override int DefMaxRange{ get{ return 2; } }

		[Constructable]
		public BlackStaff() : base( 0xDF0 )
		{
                        Name = "Black Staff - (Lv. 30)";
			Weight = 6.0;
			Layer = Layer.TwoHanded;

			Attributes.SpellChanneling = 1;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 30 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 30 in order to equip this." );
				return false;
			}
		}

		public BlackStaff( Serial serial ) : base( serial )
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