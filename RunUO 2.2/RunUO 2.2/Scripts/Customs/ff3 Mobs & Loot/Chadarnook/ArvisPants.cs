//Customized By Mrs Death
using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class ArvisPants : LongPants
  {
public override int ArtifactRarity{ get{ return 6; } }


      
      [Constructable]
		public ArvisPants()
		{
          Name = "[FF6] Arvis' Pants";
          Hue = 361;
      Attributes.AttackChance = 25;
      Attributes.BonusHits = 10;
      Attributes.CastRecovery = 1;
      Attributes.CastSpeed = 3;
      Attributes.DefendChance = 10;
      Attributes.LowerManaCost = 15;
      Attributes.LowerRegCost = 20;
      Attributes.Luck = 200;
      Attributes.NightSight = 1;
      Attributes.ReflectPhysical = 25;
      Attributes.RegenHits = 1;
      Attributes.RegenMana = 1;
      Attributes.RegenStam = 1;
      Attributes.SpellDamage = 5;
		}

		public ArvisPants( Serial serial ) : base( serial )
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
