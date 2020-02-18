using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15800, 15801 )]
	public class EbonyBattleAxe : BaseAxe
	{
		public override int AosStrengthReq{ get{ return 80; } }
		public override int AosMinDamage{ get{ return 85; } }
		public override int AosMaxDamage{ get{ return 150; } }
		public override int AosSpeed{ get{ return 30; } }
		public override float MlSpeed{ get{ return 3.75f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public EbonyBattleAxe() : base( 15800 )
		{
                        Name = "Ebony Battle Axe - (Lv. 80)";
			Weight = 12.0;
			Layer = Layer.TwoHanded;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 80 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 80 in order to equip this." );
				return false;
			}
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

                        if ( 0.02 > Utility.RandomDouble() )
                        {
			        defender.Hits -= Utility.Random( 55, 100 ); // 55-100 points of hit point loss
                        }
		}

		public EbonyBattleAxe( Serial serial ) : base( serial )
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