using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Commands;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class FortCalcifinaKey : Item
	{
		[Constructable]
		public FortCalcifinaKey() : base( 0x1010 )
		{
                        Name = "Fort Calcifina Key";
			Weight = 0.1;
                        Hue = 38;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendMessage( "This must be in your backpack in order to use it." );
			}
			else
			{
			        from.BeginTarget( 2, false, Targeting.TargetFlags.None, new TargetCallback( OnTargetFortCalcifinaMetalDoor ) );
			        from.SendMessage( "Select the door you wish to unlock." );
			}
		}

		public void OnTargetFortCalcifinaMetalDoor( Mobile from, object targ )
		{
			FortCalcifinaMetalDoor d = targ as FortCalcifinaMetalDoor;

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

		public FortCalcifinaKey( Serial serial ) : base( serial )
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