using System;
using Server;

namespace Server.Items
{
	public class DaemonBoneHelm : BoneHelm
	{
		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		[Constructable]
		public DaemonBoneHelm() 
		{
                        Name = "Daemon Bone Helm";
			Hue = 0x648;

			SkillBonuses.SetValues( 0, SkillName.MagicResist, 1.0 );
		}

		public DaemonBoneHelm( Serial serial ) : base( serial )
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