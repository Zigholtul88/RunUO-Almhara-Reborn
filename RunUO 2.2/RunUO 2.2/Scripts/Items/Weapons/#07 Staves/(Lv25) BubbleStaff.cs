using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 15385, 15386 )]
	public class BubbleStaff : BaseStaff
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
		public BubbleStaff() : base( 15385 )
		{
                        Name = "Bubble Staff - (Lv. 25)";
			Weight = 3.0;
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

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			chaos = direct = phys = fire = pois = nrgy = 0;
                        cold = 100;
		}

		public BubbleStaff( Serial serial ) : base( serial )
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