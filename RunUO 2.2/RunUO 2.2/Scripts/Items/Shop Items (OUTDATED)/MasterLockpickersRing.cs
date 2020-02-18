using System;
using Server;

namespace Server.Items
{
	public class MasterLockpickersRing : BaseRing
	{
		[Constructable]
		public MasterLockpickersRing() : base( 0x108a )
		{
                  Name = "Master Lockpicker's Ring";
			Weight = 0.1;
			SkillBonuses.SetValues( 0, SkillName.Lockpicking, 5.0 );
		}

		public MasterLockpickersRing( Serial serial ) : base( serial )
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