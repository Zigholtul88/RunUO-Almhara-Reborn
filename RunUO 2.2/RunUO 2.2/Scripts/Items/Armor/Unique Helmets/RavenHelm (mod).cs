using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x2B71, 0x3168 )]
	public class RavenHelm : BaseArmor, IDyable
	{
		public override Race RequiredRace { get { return Race.Elf; } }
		public override int BasePhysicalResistance{ get{ return 4; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int AosStrReq{ get{ return 40; } }
		public override int AosDexBonus{ get{ return -1; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }

		[Constructable]
		public RavenHelm() : base( 0x2B71 )
		{
			Weight = 5.0;
			Attributes.BonusHits = 7;
		}

		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public RavenHelm( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}