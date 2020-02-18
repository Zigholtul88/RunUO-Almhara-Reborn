using System;
using Server;

namespace Server.Items
{
	public class SkeletalScimitar : Scimitar
	{
		[Constructable]
		public SkeletalScimitar()
		{
                      Name = "Skeletal Scimitar";
                      Hue = 966;

		      Slayer = SlayerName.Silver;
		      Attributes.WeaponSpeed = 5;
		}

		public override bool OnEquip( Mobile m )
		{
		this.ItemID = 0x13B6;
		return true;
		}

		public override void OnRemoved( object parent )
		{
		this.ItemID = 0x2560;
		}

		public SkeletalScimitar( Serial serial ) : base( serial )
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
