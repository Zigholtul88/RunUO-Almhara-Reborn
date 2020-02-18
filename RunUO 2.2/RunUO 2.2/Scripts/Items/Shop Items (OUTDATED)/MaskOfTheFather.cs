using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class MaskOfTheFather : BoneHelm, ITokunoDyable
        {
		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 55; } }

		public override int BaseColdResistance{ get{ return 11; } } 
		public override int BaseEnergyResistance{ get{ return 3; } } 
		public override int BasePhysicalResistance{ get{ return 15; } } 
		public override int BasePoisonResistance{ get{ return 12; } } 
		public override int BaseFireResistance{ get{ return 12; } } 
      
                [Constructable]
		public MaskOfTheFather()
		{
                        Name = "Mask Of The Father";
                        Hue = 2518;

			LootType = LootType.Blessed;

                        ArmorAttributes.MageArmor = 1;
                        Attributes.BonusInt = 5;
                        Attributes.DefendChance = 10;
                        Attributes.LowerManaCost = 10;
                        Attributes.NightSight = 1;
                        Attributes.SpellDamage = 15;
  		}

		public MaskOfTheFather( Serial serial ) : base( serial )
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
