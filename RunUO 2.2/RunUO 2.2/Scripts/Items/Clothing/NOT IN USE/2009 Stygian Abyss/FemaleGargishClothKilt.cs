using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	public class FemaleGargishClothKilt : BaseClothing
	{
		public override int BasePhysicalResistance{ get{ return 2; } }
		public override int BaseFireResistance{ get{ return 2; } }
		public override int BaseColdResistance{ get{ return 2; } }
		public override int BasePoisonResistance{ get{ return 2; } }
		public override int BaseEnergyResistance{ get{ return 2; } }

		[Constructable]
		public FemaleGargishClothKilt() : this( 0 )
		{
		}

		[Constructable]
		public FemaleGargishClothKilt( int hue ) : base( 0x0407, Layer.OuterLegs, hue)
		{
                  Name = "Female Gargish Cloth Kilt";
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

		public FemaleGargishClothKilt( Serial serial ) : base( serial )
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

