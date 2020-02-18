using System;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x2B0C, 0x2B0D )]
	public class GauntletsOfValor : BaseArmor
	{
		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int OldStrReq{ get{ return 30; } }
		public override int OldDexBonus{ get{ return -2; } }
		public override int ArmorBase{ get{ return 40; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Plate; } }


		[Constructable]
		public GauntletsOfValor() : base( 0x2B0D )
		{
                  Name = "Gauntlets of Valor";
			Weight = 10.0;
		}

		public GauntletsOfValor( Serial serial ) : base( serial )
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
				Weight = 4.0;
		}
	}
}








