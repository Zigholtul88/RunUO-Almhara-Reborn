using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15371, 15372 )]
	public class RainbowHeavyCrossbow : BaseRanged
	{
		public override Type TypeUsed{ get{ return typeof( Bolt ); } }
		
		public override int EffectID{ get{ return 0x1BFE; } }
		public override Type AmmoType{ get{ return TypeSelected( TypeUsed ); } }		
		public override Item Ammo{ get{ return AmmoSelected( TypeUsed ); } }

		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return 150; } }
		public override int AosMaxDamage{ get{ return 250; } }
		public override int AosSpeed{ get{ return 10; } }
		public override float MlSpeed{ get{ return 5.00f; } }

		public override int DefMaxRange{ get{ return 8; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public RainbowHeavyCrossbow() : base( 15371 )
		{
                        Name = "Rainbow Heavy Crossbow - (Lv. 90)";
			Weight = 9.0;
			Layer = Layer.TwoHanded;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 90 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 90 in order to equip this." );
				return false;
			}
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			chaos = direct = 0;
                        phys = 20;
                        fire = 20;
                        cold = 20;
                        pois = 20;
                        nrgy = 20;
		}

		public RainbowHeavyCrossbow( Serial serial ) : base( serial )
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