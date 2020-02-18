using System;
using Server;

namespace Server.Items
{
	public class PureWhiteFeatherBow : Bow 
	{
		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.Dismount; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.MovingShot; } }

		public override int InitMinHits{ get{ return 100; } }
		public override int InitMaxHits{ get{ return 100; } }

		[Constructable]
		public PureWhiteFeatherBow()
		{
			Weight = 5.0;
            		Name = "Pure White Feather Bow";
            		Hue = 1153;
			LootType = LootType.Blessed;
 
			WeaponAttributes.HitLeechHits = 5;  
			WeaponAttributes.ResistEnergyBonus = 20;
			WeaponAttributes.ResistPoisonBonus = 30;
			WeaponAttributes.UseBestSkill = 1;

			Attributes.BonusDex = 5;
			Attributes.BonusStr = 1;
			Attributes.Luck = 500;
			Attributes.SpellChanneling = 1;
			Attributes.WeaponSpeed = 45;

			StrRequirement = 01;
		}

		public PureWhiteFeatherBow( Serial serial ) : base( serial )
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
