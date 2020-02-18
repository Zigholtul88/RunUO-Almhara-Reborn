using System;
using Server;

namespace Server.Items
{
	public class Pacify : Pike
	{
		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 55; } }

		[Constructable]
		public Pacify()
		{
                        Name = "Pacify";
			Hue = 0x835;

			Attributes.AttackChance = 5 + Utility.RandomMinMax( 1, 10 );
			Attributes.WeaponDamage = 5 + Utility.RandomMinMax( 1, 10 );
			Attributes.WeaponSpeed = 5 + Utility.RandomMinMax( 1, 10 );
			Attributes.SpellChanneling = 1;

			WeaponAttributes.HitLeechMana = 5 + Utility.RandomMinMax( 1, 10 );
		}

		public Pacify( Serial serial ) : base( serial )
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
