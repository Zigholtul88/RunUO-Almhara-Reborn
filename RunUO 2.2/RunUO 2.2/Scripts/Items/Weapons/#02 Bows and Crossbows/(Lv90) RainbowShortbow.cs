using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15373, 15374 )]
	public class RainbowShortbow : BaseRanged
	{
		public override Type TypeUsed{ get{ return typeof( Arrow ); } }
		
		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 100; } }
		public override int AosMaxDamage{ get{ return 200; } }
		public override int AosSpeed{ get{ return 20; } }
		public override float MlSpeed{ get{ return 4.25f; } }

		public override int DefMaxRange{ get{ return 10; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }

		[Constructable]
		public RainbowShortbow() : base( 15373 )
		{
                        Name = "Rainbow Shortbow - (Lv. 90)";
			Weight = 6.0;
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

		public RainbowShortbow( Serial serial ) : base( serial )
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