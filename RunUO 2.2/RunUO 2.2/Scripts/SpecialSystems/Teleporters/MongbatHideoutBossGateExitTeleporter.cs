using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network; 
using Server.Spells;

namespace Server.Items
{
	public class MongbatHideoutBossGateExitTeleporter : Teleporter
	{
		[Constructable]
		public MongbatHideoutBossGateExitTeleporter()
		{
                        Name = "Arena Exit - WARNING: Your key will be deleted!";
			Light = LightType.Circle300;
                        ItemID = 0xF6C;

			Movable = false;
			Visible = true;
		}

		public override bool OnMoveOver( Mobile m )
		{
                        Item item = m.Backpack.FindItemByType(typeof( MongbatHideoutBossKey ) );
	                if ( item != null )
	                {
	                if ( item != this )
	                {
					 m.PlaySound( 0x014 ); // wind 1
					 m.PlaySound( 0x015 ); // wind 2
					 m.PlaySound( 0x016 ); // wind 3
					 m.PlaySound( 0x028 ); // thundr01
					 m.PlaySound( 0x028 ); // thundr01
					 m.PlaySound( 0x4D5 ); // defense mastery

		                         m.SendMessage( "You have left the arena." );
			}
                        else
                        {
				         return true;
                        } 
				 StartTeleport( m );
			         return false;
                      }

		      m.SendMessage( "Unless you have the boss key, you're not leaving unless you face your execution." );
		      return true;
		}

		public MongbatHideoutBossGateExitTeleporter( Serial serial ) : base( serial )
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