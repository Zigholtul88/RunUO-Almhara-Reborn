using System;
using Server;
using Server.Network;
using Server.Items;
using System.Collections;

namespace Server.Items
{
	public class BlackPantherTonic : BeverageBottle
	{		
		public override int MaxQuantity { get { return 1; } }

		[Constructable]
		public BlackPantherTonic() : base( BeverageType.Liquor )
		{
                  	Name = "a bottle of black panther tonic";
			Hue = 1904;
		}

		public BlackPantherTonic( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

            	public override void OnDoubleClick( Mobile from )
            	{
			if ( from.BeginAction( typeof( BaseHealPotion ) ) )
			{

                          	from.AddSkillMod(new TimedSkillMod(SkillName.Stealing, true, 13.0, TimeSpan.FromMinutes(3.0)));
			  	from.SendMessage( "The black panther tonic temporary boosts your Stealing skill." );
	
			  	from.PlaySound( 726 );

			  	this.Delete();

				Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( ReleaseHealLock ), from );
			}
			else
			{
				from.SendMessage( "Oui matey, you should wait 3 minutes before you drink another one." );
			}
		}
	
		private static void ReleaseHealLock( object state )
		{
			((Mobile)state).EndAction( typeof( BaseHealPotion ) );
		}
	}
}

