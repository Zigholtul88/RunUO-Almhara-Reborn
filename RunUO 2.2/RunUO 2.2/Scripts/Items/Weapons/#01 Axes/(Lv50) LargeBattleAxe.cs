using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0x13FB, 0x13FA )]
	public class LargeBattleAxe : BaseAxe
	{
		public override int AosStrengthReq{ get{ return 45; } }
		public override int AosMinDamage{ get{ return 55; } }
		public override int AosMaxDamage{ get{ return 110; } }
		public override int AosSpeed{ get{ return 30; } }
		public override float MlSpeed{ get{ return 3.75f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public LargeBattleAxe() : base( 0x13FB )
		{
                        Name = "Large Battle Axe - (Lv. 50)";
			Weight = 6.0;
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

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

                        if ( 0.02 > Utility.RandomDouble() )
                        {
			        defender.Hits -= Utility.Random( 45, 50 ); // 45-50 points of hit point loss
                        }
		}

		public LargeBattleAxe( Serial serial ) : base( serial )
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