using System;
using Server;

namespace Server.Items
{
	public class Calm : Halberd
	{
		public override int LabelNumber{ get{ return 1094915; } } // Calm [Replica]

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 50; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public Calm()
		{
			Hue = 0x2cb;

			Attributes.SpellChanneling = 1;
			Attributes.WeaponDamage = 20;
			Attributes.WeaponSpeed = 10;
			Attributes.AttackChance = 10;

			WeaponAttributes.HitLeechMana = 25;
			WeaponAttributes.UseBestSkill = 1;
		}

		public Calm( Serial serial ) : base( serial )
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
