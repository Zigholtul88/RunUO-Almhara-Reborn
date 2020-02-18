using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class ExperienceCheck500 : Item
	{
		[Constructable]
		public ExperienceCheck500() : base( 0x14F0 )
		{
			Name = "Experience Check - (+500 XP)";
			LootType = LootType.Blessed;
			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        pm.Exp += 500;
                        pm.KillExp += 500;

                        pm.SendMessage("You've gained 500 exp.");

                        if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                        {
                                Actions.DoLevel(pm, new Setup());
                        }

			Delete( );
		}

		public ExperienceCheck500( Serial serial ) : base( serial )
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