using System;
using Server;

namespace Server.Items
{
	public class FatManHealPotion  : BaseHealPotion
	{
		public override int MinHeal { get { return 500; } }
		public override int MaxHeal { get { return 700; } }
		public override double Delay{ get{ return 10.0; } }

		[Constructable]
		public FatManHealPotion () : base( PotionEffect.HealGreater )
		{
                Name = "Fat Man Yellow Potion";
		}

		public FatManHealPotion ( Serial serial ) : base( serial )
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