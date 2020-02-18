using System;
using Server;

namespace Server.Items
{
        public class EyesOfHate : ElvenGlasses, ITokunoDyable
        {	
		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 55; } }

		[Constructable]
		public EyesOfHate() : base()
		{
			Name = "Eyes Of Hate";
			Hue = 137;
		
			Attributes.BonusStr = 2;
			Attributes.BonusDex = 2;
			Attributes.DefendChance = 15;
			Attributes.AttackChance = 10;
			ArmorAttributes.SelfRepair = 5;
			
			WeaponAttributes.HitLowerAttack = 30;
		}

		public EyesOfHate( Serial serial ) : base( serial )
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