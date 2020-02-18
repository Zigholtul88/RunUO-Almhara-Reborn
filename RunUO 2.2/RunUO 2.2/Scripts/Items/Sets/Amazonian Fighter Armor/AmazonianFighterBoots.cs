using System;
using Server.Items;
using Server.Engines.Craft;

namespace Server.Items
{
	[Flipable]
	public class AmazonianFighterBoots : BaseShoes
	{
		public override int BasePhysicalResistance{ get{ return 8; } }
		public override int BaseFireResistance{ get{ return 5; } }
		public override int BaseColdResistance{ get{ return 4; } }
		public override int BasePoisonResistance{ get{ return 1; } }
		public override int BaseEnergyResistance{ get{ return 1; } }

		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override bool AllowMaleWearer{ get{ return false; } }

		public override CraftResource DefaultResource{ get{ return CraftResource.RegularLeather; } }

		[Constructable]
		public AmazonianFighterBoots() : this( 0 )
		{
		}

		[Constructable]
		public AmazonianFighterBoots( int hue ) : base( 0x1711, hue )
		{
                        Name = "Amazonian Fighter Boots";
			Weight = 4.0;
                        Hue = 138;
			Attributes.BonusHits = 5;
			SkillBonuses.SetValues( 0, SkillName.Fencing, 1.0 );
		}

		public AmazonianFighterBoots( Serial serial ) : base( serial )
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
