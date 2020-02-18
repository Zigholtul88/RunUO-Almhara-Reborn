using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class FemaleGargishClothArms : BaseClothing
	{
		public override int BasePhysicalResistance{ get{ return 2; } }
		public override int BaseFireResistance{ get{ return 2; } }
		public override int BaseColdResistance{ get{ return 2; } }
		public override int BasePoisonResistance{ get{ return 2; } }
		public override int BaseEnergyResistance{ get{ return 2; } }

		[Constructable]
		public FemaleGargishClothArms() : this( 0 )
		{
		}

		[Constructable]
		public FemaleGargishClothArms( int hue ) : base( 0x0403, Layer.Arms, hue)
		{
                  Name = "Female Gargish Cloth Arms";
			Weight = 2.0;
		}

		public override bool CanEquip( Mobile from )
		{
                  if ( from.Female == true && from.BodyValue == 667 )
			{
				return true;
			} 

			else
			{
				from.SendMessage( "Only a female gargoyle can equip this." );
				return false;
			}
		}

		public FemaleGargishClothArms( Serial serial ) : base( serial )
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

