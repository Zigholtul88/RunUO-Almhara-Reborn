using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0xf45, 0xf46 )]
	public class ExecutionersAxe : BaseAxe
	{
		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return 40; } }
		public override int AosMaxDamage{ get{ return 75; } }
		public override int AosSpeed{ get{ return 37; } }
		public override float MlSpeed{ get{ return 3.25f; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public ExecutionersAxe() : base( 0xF45 )
		{
                        Name = "Executioner's Axe - (Lv. 40)";
			Weight = 8.0;
			Layer = Layer.TwoHanded;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 40 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 40 in order to equip this." );
				return false;
			}
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

                        if ( 0.02 > Utility.RandomDouble() )
                        {
			        defender.Hits -= Utility.Random( 40, 45 ); // 35-40 points of hit point loss
                        }
		}

		public ExecutionersAxe( Serial serial ) : base( serial )
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