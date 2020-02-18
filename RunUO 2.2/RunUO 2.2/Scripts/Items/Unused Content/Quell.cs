using System;
using Server;

namespace Server.Items
{
	public class Quell : Bardiche
	{
		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }

		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public Quell()
		{
                        Name = "Quell";
			Hue = 0x225;

			Attributes.SpellChanneling = 1;
			Attributes.WeaponSpeed = 20;
			Attributes.WeaponDamage = 10;
			Attributes.AttackChance = 10;

			WeaponAttributes.HitLeechMana = 25;
			WeaponAttributes.UseBestSkill = 1;
		}

		public Quell( Serial serial ) : base( serial )
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
