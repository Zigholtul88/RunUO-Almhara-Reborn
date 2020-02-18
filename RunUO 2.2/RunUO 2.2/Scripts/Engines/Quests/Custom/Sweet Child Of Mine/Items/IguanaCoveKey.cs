using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Engines.Quests;

namespace Server.Items
{
	public class IguanaCoveKey : Item
	{
		[Constructable]
		public IguanaCoveKey() : base( 0x100F )
		{
			Name = "Iguana Cove Key - Quest Item";
			Weight = 0.1;
                        Hue = 1278;
			LootType = LootType.Blessed;
		}

		public IguanaCoveKey( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendMessage( "This must be in your backpack in order to use it." );
			}
			else
			{
			        from.BeginTarget( 2, false, Targeting.TargetFlags.None, new TargetCallback( OnTargetIguanaCoveKeyDoor ) );
			        from.SendMessage( "Select the door you wish to unlock." );
			}
		}

		public void OnTargetIguanaCoveKeyDoor( Mobile from, object targ )
		{
			IguanaCoveKeyDoor d = targ as IguanaCoveKeyDoor;

			if ( d == null )
			{
		                from.SendMessage( "This key doesn't work on this object, idiot." );
			}
			else
			{
		                d.Locked = false;
		                d.Open = true;
		                from.SendMessage( "You have unlocked the door." );
		                from.PlaySound( 0x1FF );
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