using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0x2D2F, 0x2D23 )]
	public class WarCleaver : BaseKnife
	{
		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 50; } }
		public override int AosMaxDamage{ get{ return 50; } }
		public override int AosSpeed{ get{ return 37; } }
		public override float MlSpeed{ get{ return 2.25f; } }

		public override int DefHitSound{ get{ return 0x23B; } }
		public override int DefMissSound{ get{ return 0x239; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override SkillName DefSkill{ get{ return SkillName.Fencing; } }
		public override WeaponType DefType{ get{ return WeaponType.Piercing; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

		[Constructable]
		public WarCleaver() : base( 0x2D2F )
		{
                        Name = "War Cleaver - (Lv. 50)";
			Weight = 10.0;
			Layer = Layer.TwoHanded;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 50 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 50 in order to equip this." );
				return false;
			}
		}

		public WarCleaver( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadEncodedInt();
		}
	}
}