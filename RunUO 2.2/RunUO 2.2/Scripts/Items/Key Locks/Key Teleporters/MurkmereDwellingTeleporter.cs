using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network; 
using Server.Spells;
using Server.Targeting;

namespace Server.Items
{
	public class MurkmereDwellingTeleporter : Teleporter
	{
		public override int LabelNumber{ get{ return 1049382; } } // a magical teleporter

		[Constructable]
		public MurkmereDwellingTeleporter()
		{
		}
 
		public override bool OnMoveOver( Mobile m )
		{
                        Item item = m.Backpack.FindItemByType(typeof( SpecializedForestHartShard ) );
	                if ( item != null )
	                {
	                if ( item != this )
	                {
		                         m.SendMessage( "You will be teleported to Murkmere Dwelling in 5 seconds." );
			}
                        else
                        {
				         return true;
                        } 
				 StartTeleport( m );
			         return false;
                      }

		      m.SendMessage( "Access to this dungeon requires the heart of the forest." );
		      return true;
		}

		public MurkmereDwellingTeleporter( Serial serial ) : base( serial )
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