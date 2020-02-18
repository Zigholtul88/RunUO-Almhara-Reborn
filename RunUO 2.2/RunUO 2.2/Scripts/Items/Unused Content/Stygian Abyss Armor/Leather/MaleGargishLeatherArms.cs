using System;
using Server.Items;

namespace Server.Items
{
	public class MaleGargishLeatherArms : BaseArmor
	{
		public override int BasePhysicalResistance{ get{ return 2; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 37; } }

		public override int AosStrReq{ get{ return 10; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Leather; } }
		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		[Constructable]
		public MaleGargishLeatherArms() : base( 0x0302 )
		{
                  Name = "Male Gargish Leather Arms";
			Weight = 2.0;
			Attributes.BonusStam = 9;
		}

		public override bool CanEquip( Mobile from )
		{
                  if ( from.Female == false && from.BodyValue == 666 )
			{
				return true;
			} 

			else
			{
				from.SendMessage( "Only a male gargoyle can equip this." );
				return false;
			}
		}

		public MaleGargishLeatherArms( Serial serial ) : base( serial )
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

			if ( Weight == 1.0 )
				Weight = 2.0;
		}
	}
}