using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x2B68, 0x315F )]
	public class AmazonianFighterBelt : BaseWaist
	{
		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseFireResistance{ get{ return 4; } }
		public override int BaseColdResistance{ get{ return 2; } }
		public override int BasePoisonResistance{ get{ return 1; } }
		public override int BaseEnergyResistance{ get{ return 1; } }

		public override int InitMinHits{ get{ return 11; } }
		public override int InitMaxHits{ get{ return 40; } }

		public override bool AllowMaleWearer{ get{ return false; } }

		[Constructable]
		public AmazonianFighterBelt() : this( 0 )
		{
		}

		[Constructable]
		public AmazonianFighterBelt( int hue ) : base( 0x2B68, hue )
		{
                        Name = "Amazonian Fighter Belt";
			Weight = 4.0;
                        Hue = 138;
			Attributes.BonusHits = 5;
			SkillBonuses.SetValues( 0, SkillName.Fencing, 1.0 );
		}

		public AmazonianFighterBelt( Serial serial ) : base( serial )
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
