using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15826, 15827 )]
	public class EbonyRapier : BaseSword
	{
		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 8; } }
		public override int AosMaxDamage{ get{ return 20; } }
		public override int AosSpeed{ get{ return 55; } }
		public override float MlSpeed{ get{ return 2.00f; } }

		public override int DefHitSound{ get{ return 0x23C; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override SkillName DefSkill{ get{ return SkillName.Fencing; } }
		public override WeaponType DefType{ get{ return WeaponType.Piercing; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Pierce1H; } }

		[Constructable]
		public EbonyRapier() : base( 15826 )
		{
                        Name = "Ebony Rapier - (Lv. 10)";
			Weight = 2.0;
			Layer = Layer.OneHanded;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 10 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 10 in order to equip this." );
				return false;
			}
		}

		public EbonyRapier( Serial serial ) : base( serial )
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