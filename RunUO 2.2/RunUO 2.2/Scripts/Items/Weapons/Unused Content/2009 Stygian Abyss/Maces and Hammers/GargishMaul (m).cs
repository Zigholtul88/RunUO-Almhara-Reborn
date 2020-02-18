using System;
using Server;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x48C2, 0x48C3 )]
	public class GargishMaul  : BaseBashing
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.CrushingBlow; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ConcussionBlow; } }

		public override int AosStrengthReq{ get{ return 20; } }
		public override int AosMinDamage{ get{ return 10; } }
		public override int AosMaxDamage{ get{ return 30; } }
		public override int AosSpeed{ get{ return 30; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 70; } }

		[Constructable]
		public GargishMaul () : base( 0x48C2 )
		{
                  Name = "Gargish Maul";
			Weight = 10.0;
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

		public GargishMaul ( Serial serial ) : base( serial )
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

			if ( Weight == 14.0 )
				Weight = 10.0;
		}
	}
}