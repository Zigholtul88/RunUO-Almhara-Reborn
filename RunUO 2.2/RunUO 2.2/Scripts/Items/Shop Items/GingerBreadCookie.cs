using System;
using Server.Mobiles;
using Server.Network;
using System.Collections.Generic;

namespace Server.Items
{
	public class GingerBreadCookie : Food
	{
		private readonly int[] m_Messages = 
		{ 
			0, 
			1077396, // Noooo!
			1077397, // Please don't eat me... *whimper*
			1077405, // etc etc etc ..
			1077406, 
			1077407, 
			1077408, 
			1077409
		};

		[Constructable]
		public GingerBreadCookie() : base( 0x2be1 )
		{
			ItemID = Utility.RandomBool() ? 0x2be1 : 0x2be2;
			Stackable = false;
			LootType=LootType.Blessed;
		}

		public GingerBreadCookie( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( IsChildOf( from.Backpack ) || from.InRange(this, 1) )
			{
				int result;
				if( ( result = m_Messages[Utility.Random( 0, m_Messages.Length )]) == 0 )
				{
					base.OnDoubleClick( from );
				}
				else
				{
					this.SendLocalizedMessageTo( from, result );
				}
			}
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

