using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 15329, 15330 )]
	public class ChitinArms : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 5; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 37; } }

		public override int AosStrReq{ get{ return 20; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		[Constructable]
		public ChitinArms() : base( 15329 )
		{
                        Name = "Chitin Arms - (Lv. 12)";
			Weight = 2.0;
			Layer = Layer.Arms;
			Attributes.BonusHits = 5;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 12 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 12 in order to equip this." );
				return false;
			}
		}

		public ChitinArms( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}