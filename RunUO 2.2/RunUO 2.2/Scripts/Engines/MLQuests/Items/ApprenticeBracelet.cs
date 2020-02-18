using System;
using Server;

namespace Server.Items
{
	public class ApprenticeBracelet : SilverBracelet
	{

		[Constructable]
		public ApprenticeBracelet()
		{
			Name = "Apprentice Bracelet";
			LootType = LootType.Blessed;
						
			Attributes.BonusDex = 1;
			Attributes.RegenStam = 1;
			Attributes.CastSpeed = 1;
		}

		public ApprenticeBracelet( Serial serial ) : base( serial )
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