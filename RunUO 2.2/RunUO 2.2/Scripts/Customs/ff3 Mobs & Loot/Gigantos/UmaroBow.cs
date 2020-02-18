//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class UmaroBow : CompositeBow
	{

		public override int ArtifactRarity{ get{ return 6; } }
		public override int AosMinDamage{ get{ return 20; } }
		public override int OldMinDamage{ get{ return 20; } }
		public override int AosMaxDamage{ get{ return 25; } }
		public override int OldMaxDamage{ get{ return 25; } }

		public override int InitMinHits{ get{ return 250; } }
		public override int InitMaxHits{ get{ return 250; } }

		[Constructable]
		public UmaroBow()
		{
			Weight = 5.0;
			Name = "[FF6] Umaro's Snowball Launcher";
			Hue = 1154;
			Layer = Layer.OneHanded;
                        WeaponAttributes.HitLeechHits = 25;
      			WeaponAttributes.HitLeechMana = 75;
      			WeaponAttributes.HitLeechStam = 25;
      			Attributes.AttackChance = 20;
      			Attributes.BonusDex = 20;
      			Attributes.BonusInt = 20;
			Attributes.BonusStr = 20;
      			Attributes.DefendChance = 20;
      			Attributes.WeaponDamage = 80;
      			Attributes.WeaponSpeed = 80;
			LootType = LootType.Regular;
			
		}

		public UmaroBow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize(GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}