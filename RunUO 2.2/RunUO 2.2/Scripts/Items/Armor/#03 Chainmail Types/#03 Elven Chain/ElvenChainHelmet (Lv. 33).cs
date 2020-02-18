using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 15325, 15326 )]
	public class ElvenChainHelmet : BaseArmor, IDyable
	{
		public override int BasePhysicalResistance{ get{ return 12; } }

		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 60; } }

		public override int AosStrReq{ get{ return 55; } }

		public override ArmorMaterialType MaterialType{ get{ return ArmorMaterialType.Chainmail; } }

		[Constructable]
		public ElvenChainHelmet() : base( 15325 )
		{
                        Name = "Elven Chain Helmet - (Lv. 33)";
			Weight = 5.0;
			Layer = Layer.Helm;
			Attributes.BonusHits = 20;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 33 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 33 in order to equip this." );
				return false;
			}
		}

		public bool Dye( Mobile from, DyeTub sender )
		{
			if ( Deleted )
				return false;

			Hue = sender.DyedHue;

			return true;
		}

		public ElvenChainHelmet( Serial serial ) : base( serial )
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