using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15303, 15304 )]
	public class RoseBouquet : BaseBashing
	{
		public override int AosStrengthReq{ get{ return 5; } }
		public override int AosMinDamage{ get{ return 1; } }
		public override int AosMaxDamage{ get{ return 5; } }
		public override int AosSpeed{ get{ return 53; } }
		public override float MlSpeed{ get{ return 2.75f; } }

		public override int DefHitSound{ get{ return 0x12D; } }
		public override int DefMissSound{ get{ return 0x12A; } }

		public override SkillName DefSkill { get { return SkillName.Wrestling; } }

		public override int InitMinHits{ get{ return 10; } }
		public override int InitMaxHits{ get{ return 20; } }

		[Constructable]
		public RoseBouquet() : base( 15303 )
		{
                        Name = "RoseBouquet - (Lv. 1)";
			Weight = 2.0;
			Layer = Layer.OneHanded;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 1 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 1 in order to equip this." );
				return false;
			}
		}

		public RoseBouquet( Serial serial ) : base( serial )
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