using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Commands;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class SagittaResidenceKey : Item
	{
		[Constructable]
		public SagittaResidenceKey() : base( 0x100F )
		{
                        Name = "Sagitta Residence Key";
			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendMessage( "This must be in your backpack in order to use it." );
			}
			else
			{
			        from.BeginTarget( 2, false, Targeting.TargetFlags.None, new TargetCallback( OnTargetSagittaResidenceFrontDoor ) );
			        from.SendMessage( "Select the door you wish to unlock." );
			}
		}

		public void OnTargetSagittaResidenceFrontDoor( Mobile from, object targ )
		{
			SagittaResidenceFrontDoor d = targ as SagittaResidenceFrontDoor;

			if ( d == null )
			{
		                from.SendMessage( "This key doesn't work on this object, idiot." );
			}
			else
			{
		                d.Locked = false;
		                d.Open = true;
		                from.SendMessage( "You have unlocked the doors to Sagitta Residence. Enjoy your stay." );
		                from.PlaySound( 0x1FF );
			}
		}

		public SagittaResidenceKey( Serial serial ) : base( serial )
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