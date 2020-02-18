using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class CrownOfTalKeesh : ChitinHelmet
	{
		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 55; } }

		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseFireResistance{ get{ return 5; } }
		public override int BaseColdResistance{ get{ return 9; } }
		public override int BasePoisonResistance{ get{ return 20; } }
		public override int BaseEnergyResistance{ get{ return 20; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public CrownOfTalKeesh()
		{
                        Name = "Crown of Tal'Keesh - (Lv. 12)";
			Hue = 0x4F2;

			Attributes.BonusInt = 1 + Utility.RandomMinMax( 1, 7 );
			Attributes.RegenMana = 1 + Utility.RandomMinMax( 1, 3 );
			Attributes.SpellDamage = 5 + Utility.RandomMinMax( 1, 5 );
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

		public CrownOfTalKeesh( Serial serial ) : base( serial )
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
