using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
      [FlipableAttribute( 0x4201, 0x4206 )]
	public class GargishKiteShield : BaseShield, IDyable
	{
		public override int BaseEnergyResistance{ get{ return 5; } }

		public override int InitMinHits{ get{ return 101; } }
		public override int InitMaxHits{ get{ return 115; } }

		public override int AosStrReq{ get{ return 30; } }

		[Constructable]
		public GargishKiteShield() : base( 0x4201 )
		{
                  Name = "Gargish Kite Shield";
			Weight = 7.0;
			Attributes.DefendChance = 1;
		}

		public override bool CanEquip( Mobile from )
		{
                  if ( from.Female == false && from.BodyValue == 666 )
			{
				return true;
			} 

                  else if ( from.Female == true && from.BodyValue == 667 )
			{
				return true;
			} 

			else
			{
				from.SendMessage( "Only a gargoyle can equip this." );
				return false;
			}
		}

		public GargishKiteShield( Serial serial ) : base(serial)
		{
		}

		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( Weight == 5.0 )
				Weight = 7.0;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
