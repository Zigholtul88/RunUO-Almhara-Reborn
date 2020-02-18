using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class LeatherNinjaMitts : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 3; } }

		public override int InitMinHits{ get{ return 30; } }
		public override int InitMaxHits{ get{ return 40; } }

		public override int AosStrReq{ get{ return 12; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		[Constructable]
		public LeatherNinjaMitts() : base( 0x2792 )
		{
                        Name = "Leather Ninja Mitts - (Lv. 6)";
			Weight = 2.0;
			Attributes.BonusHits = 3;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 6 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 6 in order to equip this." );
				return false;
			}
		}

		public LeatherNinjaMitts( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 2 );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					if ( reader.ReadBool() )
					{
						reader.ReadInt();
						reader.ReadInt();
					}

					Weight = 2.0;
					ItemID = 0x2792;

					break;
				}
			}
		}
	}
}