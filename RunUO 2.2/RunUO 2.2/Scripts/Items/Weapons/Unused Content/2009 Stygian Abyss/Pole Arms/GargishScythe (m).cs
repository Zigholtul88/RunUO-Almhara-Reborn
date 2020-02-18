using System;
using Server;
using Server.Engines.Harvest;
using Server.Items;
using Server.Network;

namespace Server.Items
{
	[FlipableAttribute( 0x48C4, 0x48C5 )]
	public class GargishScythe  : BasePoleArm
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.BleedAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 6; } }
		public override int AosMaxDamage{ get{ return 42; } }
		public override int AosSpeed{ get{ return 32; } }

		public override int InitMinHits{ get{ return 31; } }
		public override int InitMaxHits{ get{ return 100; } }

		public override HarvestSystem HarvestSystem{ get{ return null; } }

		[Constructable]
		public GargishScythe () : base( 0x48C4 )
		{
                  Name = "Gargish Scythe";
			Weight = 5.0;
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

		public GargishScythe ( Serial serial ) : base( serial )
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

			if ( Weight == 15.0 )
				Weight = 5.0;
		}
	}
}