//Customized By Mrs Death
using System;
using Server;

namespace Server.Items
{
	public class EdgarBioBlaster : CompositeBow
	{
		public override int ArtifactRarity{ get{ return 6; } }
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public EdgarBioBlaster()
		{
			Name = "[FF6] Edgar's Bio-Blaster";
			Hue = 1000;
			WeaponAttributes.HitDispel = 50;
			WeaponAttributes.HitHarm = 100;
			Attributes.WeaponSpeed = 35;
			Attributes.WeaponDamage = 50;
			Attributes.AttackChance = 100;
			Attributes.DefendChance = 50;
			Attributes.ReflectPhysical = 15;
			WeaponAttributes.ResistPoisonBonus = 10;
			WeaponAttributes.LowerStatReq = 100;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = cold = nrgy = chaos = direct = 0;
			pois = 100;
		}

		public EdgarBioBlaster( Serial serial ) : base( serial )
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