using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0xF62, 0xF63 )]
	public class Spear : BaseSpear
	{
		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return 22; } }
		public override int AosMaxDamage{ get{ return 55; } }
		public override int AosSpeed{ get{ return 46; } }
		public override float MlSpeed{ get{ return 2.75f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override int DefMaxRange{ get{ return 2; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

		[Constructable]
		public Spear() : base( 0xF62 )
		{
                        Name = "Spear - (Lv. 20)";
			Weight = 7.0;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 20 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 20 in order to equip this." );
				return false;
			}
		}

		public Spear( Serial serial ) : base( serial )
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