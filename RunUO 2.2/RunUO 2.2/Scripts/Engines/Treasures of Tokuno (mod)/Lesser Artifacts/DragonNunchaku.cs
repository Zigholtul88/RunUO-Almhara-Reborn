using Server;
using System;
using Server.Misc;
using Server.Mobiles;

namespace Server.Items
{
	public class DragonNunchaku : Nunchaku
	{
		public override int LabelNumber{ get{ return 1070914; } } // Dragon Nunchaku

		public override int InitMinHits { get { return 55; } }
		public override int InitMaxHits { get { return 55; } }

		[Constructable]
		public DragonNunchaku() : base()
		{
			WeaponAttributes.ResistFireBonus = 5;
			WeaponAttributes.SelfRepair = 3;
			WeaponAttributes.HitFireball = 50;

			Attributes.WeaponDamage = 40;
			Attributes.WeaponSpeed = 20;
		}

		public DragonNunchaku( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}