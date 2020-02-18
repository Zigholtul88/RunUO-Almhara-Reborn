using System;
using Server.Items;

namespace Server.Items
{
	public class FemaleGargishLeatherLegs : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 2; } }

		public override int InitMinHits{ get{ return 30; } }
		public override int InitMaxHits{ get{ return 40; } }

		public override int AosStrReq{ get{ return 10; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		[Constructable]
		public FemaleGargishLeatherLegs() : base( 0x0305 )
		{
                  Name = "Female Gargish Leather Legs";
			Weight = 4.0;
			Attributes.BonusStam = 11;
		}

		public override bool CanEquip( Mobile from )
		{
                  if ( from.Female == true && from.BodyValue == 667 )
			{
				return true;
			} 

			else
			{
				from.SendMessage( "Only a female gargoyle can equip this." );
				return false;
			}
		}

		public FemaleGargishLeatherLegs( Serial serial ) : base( serial )
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