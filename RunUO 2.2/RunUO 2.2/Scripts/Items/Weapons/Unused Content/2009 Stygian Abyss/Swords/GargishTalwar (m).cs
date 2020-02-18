using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x908, 0x4075 )]
	public class GargishTalwar : BaseSword
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.Dismount; } }

		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 5; } }
		public override int AosMaxDamage{ get{ return 49; } }
		public override int AosSpeed{ get{ return 25; } }
		
		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 80; } }

		[Constructable]
		public GargishTalwar() : base( 0x908 )
		{
                  Name = "Gargish Talwar";
			Weight = 16.0;
			Layer = Layer.TwoHanded;
		}

		public override bool CanEquip( Mobile from )
		{
                  if ( from.Female == false && from.BodyValue == 666 )
			{
				return true;
			} 

                  else if ( from.Female == true && from.BodyValue == 667 )
			{
				return true;
			} 

			else
			{
				from.SendMessage( "Only a gargoyle can equip this." );
				return false;
			}
		}

		public GargishTalwar( Serial serial ) : base( serial )
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