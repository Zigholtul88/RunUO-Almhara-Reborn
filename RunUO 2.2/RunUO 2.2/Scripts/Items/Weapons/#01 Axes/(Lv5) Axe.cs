using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0xF49, 0xF4a )]
	public class Axe : BaseAxe
	{
		public override int AosStrengthReq{ get{ return 10; } }
		public override int AosMinDamage{ get{ return 8; } }
		public override int AosMaxDamage{ get{ return 15; } }
		public override int AosSpeed{ get{ return 37; } }
		public override float MlSpeed{ get{ return 3.00f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public Axe() : base( 0xF49 )
		{
                        Name = "Axe - (Lv. 5)";
			Weight = 4.0;
			Layer = Layer.TwoHanded;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 5 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 5 in order to equip this." );
				return false;
			}
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

                        if ( 0.02 > Utility.RandomDouble() )
                        {
			        defender.Hits -= Utility.Random( 10, 15 ); // 10-15 points of hit point loss
                        }
		}

		public Axe( Serial serial ) : base( serial )
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