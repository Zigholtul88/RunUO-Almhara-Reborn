using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Commands;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class CairnForlornKey : Item
	{
		[Constructable]
		public CairnForlornKey() : base( 0x100F )
		{
                        Name = "Cairn Forlorn Key";
			Weight = 0.1;
                        Hue = 2583;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendMessage( "This must be in your backpack in order to use it." );
			}
			else
			{
			        from.BeginTarget( 2, false, Targeting.TargetFlags.None, new TargetCallback( OnTargetCairnForlornBackDoor ) );
			        from.SendMessage( "Select the door you wish to unlock." );
			}
		}

		public void OnTargetCairnForlornBackDoor( Mobile from, object targ )
		{
			CairnForlornBackDoor d = targ as CairnForlornBackDoor;

			if ( d == null )
			{
		                from.SendMessage( "This key doesn't work on this object, idiot." );
			}
			else
			{
		                d.Locked = false;
		                d.Open = true;
		                from.SendMessage( "You have unlocked the doors. Proceed with caution." );
		                from.PlaySound( 0x1FF );
			}
		}

		public CairnForlornKey( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}