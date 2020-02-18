using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15808, 15809 )]
	public class EbonyCrossbow : BaseRanged
	{
		public override Type TypeUsed{ get{ return typeof( Bolt ); } }
		
		public override int EffectID{ get{ return 0x1BFE; } }
		public override Type AmmoType{ get{ return TypeSelected( TypeUsed ); } } // { get{ return typeof( Bolt ); } }		
		public override Item Ammo{ get{ return AmmoSelected( TypeUsed ); } } // { get{ return new Bolt(); } }

		public override int AosStrengthReq{ get{ return 15; } }
		public override int AosMinDamage{ get{ return 12; } }
		public override int AosMaxDamage{ get{ return 25; } }
		public override int AosSpeed{ get{ return 18; } }
		public override float MlSpeed{ get{ return 4.50f; } }

		public override int DefMaxRange{ get{ return 8; } }

		public override int InitMinHits{ get{ return 15; } }
		public override int InitMaxHits{ get{ return 25; } }

		[Constructable]
		public EbonyCrossbow() : base( 15809 )
		{
                        Name = "Ebony Crossbow - (Lv. 20)";
			Weight = 5.0;
			Layer = Layer.TwoHanded;
		}

		public override bool CanEquip( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level >= 20 )
			{
				return true;
			} 
			else
			{
				from.SendMessage( "You must reach at least level 20 in order to equip this." );
				return false;
			}
		}

		public EbonyCrossbow( Serial serial ) : base( serial )
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