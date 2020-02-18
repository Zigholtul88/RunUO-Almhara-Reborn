using System;
using Server;
using Server.Items;

namespace Server.Items
{
        public class ReinforcedArms : BoneArms, ITokunoDyable
        {
	        public override int InitMinHits{ get{ return 50; } }
                public override int InitMaxHits{ get{ return 55; } }

                [Constructable]
                public ReinforcedArms()
                {
                        Name = "Reinforced Arms";
                        Hue = 1165;

			LootType = LootType.Blessed;

                        Attributes.AttackChance = 5;
                        Attributes.BonusDex = 5;
                        Attributes.DefendChance = 10;
                        Attributes.EnhancePotions = 20;
                        Attributes.NightSight = 1;

                        ColdBonus = 10;
                        EnergyBonus = 5;
                        FireBonus = 8;
                        PhysicalBonus = 9;
                        PoisonBonus = 5;
                        StrBonus = 5;
                }

	 	public ReinforcedArms(Serial serial) : base( serial )
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

