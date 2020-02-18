using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class CrystalStaff : BaseWeapon_ItemOfLight
	{
		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 25; } }
		public override int AosMaxDamage{ get{ return 50; } }
		public override int AosSpeed{ get{ return 33; } }
		public override float MlSpeed{ get{ return 2.75f; } }

		public override int DefMaxRange{ get{ return 2; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public CrystalStaff() : base()
		{
                        Name = "Crystal Staff - (Lv. 25)";
			Weight = 5.0;
	                ItemID = 16176;
			Layer = Layer.TwoHanded;

			Attributes.SpellChanneling = 1;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 25 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 25 in order to equip this." );
				return false;
			}
		}

		public CrystalStaff( Serial serial ) : base( serial )
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

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

			defender.Stam -= Utility.Random( 3, 3 ); // 3-5 points of stamina loss
		}
	}
}