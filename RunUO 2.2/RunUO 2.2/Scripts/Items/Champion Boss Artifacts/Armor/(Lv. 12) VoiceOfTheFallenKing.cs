using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class VoiceOfTheFallenKing : ChitinGorget
	{
		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 55; } }

		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseColdResistance{ get{ return 18; } }
		public override int BaseEnergyResistance{ get{ return 18; } }

		[Constructable]
		public VoiceOfTheFallenKing()
		{
                        Name = "Voice of the Fallen King - (Lv. 12)";
			Hue = 0x76D;

			Attributes.BonusStr = 1 + Utility.RandomMinMax( 1, 7 );
			Attributes.RegenHits = 1 + Utility.RandomMinMax( 1, 4 );
			Attributes.RegenStam = 1 + Utility.RandomMinMax( 1, 2 );
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

		public VoiceOfTheFallenKing( Serial serial ) : base( serial )
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