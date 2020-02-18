using System;
using Server;

namespace Server.Items
{
        public class LensesOfFocus : ElvenGlasses, ITokunoDyable
	{
		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 12; } }
		public override int BaseColdResistance{ get{ return 11; } }
		public override int BasePoisonResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 13; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 55; } }

		[Constructable]
		public LensesOfFocus() : base()
		{
			Name = "Lenses Of Focus";
			Hue = 2105;

			Attributes.NightSight = 1;
			Attributes.DefendChance = 20;
			Attributes.AttackChance = 20;
		}

		public LensesOfFocus( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}
	}
}