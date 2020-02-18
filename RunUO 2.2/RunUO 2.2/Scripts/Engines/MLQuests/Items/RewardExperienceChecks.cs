using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.MLQuests.Items
{
	public class MLExperienceCheck500 : Item
	{
		[Constructable]
		public MLExperienceCheck500() : base( 0x14F0 )
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

		public MLExperienceCheck500( Serial serial ) : base( serial )
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

	public class MLExperienceCheck1000 : Item
	{
		[Constructable]
		public MLExperienceCheck1000() : base( 0x14F0 )
		{
			Name = "Experience Check - (+1000 XP)";
			LootType = LootType.Blessed;
			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        pm.Exp += 1000;
                        pm.KillExp += 1000;

                        pm.SendMessage("You've gained 1000 exp.");

                        if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                        {
                                Actions.DoLevel(pm, new Setup());
                        }

			Delete( );
		}

		public MLExperienceCheck1000( Serial serial ) : base( serial )
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

	public class MLExperienceCheck1500 : Item
	{
		[Constructable]
		public MLExperienceCheck1500() : base( 0x14F0 )
		{
			Name = "Experience Check - (+1500 XP)";
			LootType = LootType.Blessed;
			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        pm.Exp += 1500;
                        pm.KillExp += 1500;

                        pm.SendMessage("You've gained 1500 exp.");

                        if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                        {
                                Actions.DoLevel(pm, new Setup());
                        }

			Delete( );
		}

		public MLExperienceCheck1500( Serial serial ) : base( serial )
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

/////////////////////////////// Spanish Check
	public class SpanishMLExperienceCheck1500 : Item
	{
		[Constructable]
		public SpanishMLExperienceCheck1500() : base( 0x14F0 )
		{
			Name = "Comprobacion De La Experiencia - (+1500 XP)";
			LootType = LootType.Blessed;
			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        pm.Exp += 1500;
                        pm.KillExp += 1500;

                        pm.SendMessage("Has ganado 1500 exp.");

                        if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                        {
                                Actions.DoLevel(pm, new Setup());
                        }

			Delete( );
		}

		public SpanishMLExperienceCheck1500( Serial serial ) : base( serial )
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

/////////////////////////////// Backwards Check
	public class BackwardsMLExperienceCheck1500 : Item
	{
		[Constructable]
		public BackwardsMLExperienceCheck1500() : base( 0x14F0 )
		{
			Name = "kcehC ecneirepxE - (PX 0051+)";
			LootType = LootType.Blessed;
			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        pm.Exp += 1500;
                        pm.KillExp += 1500;

                        pm.SendMessage(".pxe 0051 deniag ev'uoY");

                        if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                        {
                                Actions.DoLevel(pm, new Setup());
                        }

			Delete( );
		}

		public BackwardsMLExperienceCheck1500( Serial serial ) : base( serial )
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

	public class MLExperienceCheck2000 : Item
	{
		[Constructable]
		public MLExperienceCheck2000() : base( 0x14F0 )
		{
			Name = "Experience Check - (+2000 XP)";
			LootType = LootType.Blessed;
			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        pm.Exp += 2000;
                        pm.KillExp += 2000;

                        pm.SendMessage("You've gained 2000 exp.");

                        if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                        {
                                Actions.DoLevel(pm, new Setup());
                        }

			Delete( );
		}

		public MLExperienceCheck2000( Serial serial ) : base( serial )
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