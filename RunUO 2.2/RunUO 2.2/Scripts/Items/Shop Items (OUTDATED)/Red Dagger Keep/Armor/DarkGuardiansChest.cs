using System;
using Server;

namespace Server.Items
{
	public class DarkGuardiansChest : PlateChest, ITokunoDyable
	{
                public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 10; } } 
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

	 	public override int InitMinHits{ get{ return 50; } }
	 	public override int InitMaxHits{ get{ return 55; } }

	 	[Constructable]
	 	public DarkGuardiansChest()
	 	{
	 	 	Name = "Dark Guardian's Chest";
	 	 	Hue = 1141;

	 	 	Attributes.Luck = 150;
	 	 	Attributes.WeaponDamage = 5;
	 	 	ArmorAttributes.MageArmor = 1;
			Attributes.RegenHits = 1;
			Attributes.ReflectPhysical = 15;
 	        }

	 	public DarkGuardiansChest(Serial serial) : base( serial )
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
