using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15818, 15819 )]
	public class EbonyDagger : BaseKnife
	{
		public override int AosStrengthReq{ get{ return 5; } }
		public override int AosMinDamage{ get{ return 10; } }
		public override int AosMaxDamage{ get{ return 15; } }
		public override int AosSpeed{ get{ return 55; } }
		public override float MlSpeed{ get{ return 2.75f; } }

		public override int DefMissSound{ get{ return 0x239; } }
		public override SkillName DefSkill { get { return SkillName.Fencing; } }
		public override WeaponType DefType{ get{ return WeaponType.Piercing; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public EbonyDagger() : base( 15818 )
		{
                        Name = "Ebony Dagger - (Lv. 10)";
			Weight = 4.0;
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

		public EbonyDagger( Serial serial ) : base( serial )
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