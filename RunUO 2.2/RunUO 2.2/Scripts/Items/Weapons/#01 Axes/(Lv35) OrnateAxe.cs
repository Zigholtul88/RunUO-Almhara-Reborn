using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0x2D28, 0x2D34 )]
	public class OrnateAxe : BaseAxe
	{
		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return 28; } }
		public override int AosMaxDamage{ get{ return 60; } }
		public override int AosSpeed{ get{ return 30; } }
		public override float MlSpeed{ get{ return 3.50f; } }

		public override int DefMissSound{ get{ return 0x239; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public OrnateAxe() : base( 0x2D28 )
		{
                        Name = "Ornate Axe - (Lv. 35)";
			Weight = 12.0;
			Layer = Layer.TwoHanded;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 35 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 35 in order to equip this." );
				return false;
			}
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

                        if ( 0.02 > Utility.RandomDouble() )
                        {
			        defender.Hits -= Utility.Random( 35, 40 ); // 35-40 points of hit point loss
                        }
		}

		public OrnateAxe( Serial serial ) : base( serial )
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