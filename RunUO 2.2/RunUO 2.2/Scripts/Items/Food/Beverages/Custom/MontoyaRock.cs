using System;
using Server;
using Server.Network;
using Server.Items;
using System.Collections;

namespace Server.Items
{
	public class MontoyaRock : BeverageBottle
	{		
		public override int MaxQuantity { get { return 1; } }

		[Constructable]
		public MontoyaRock() : base( BeverageType.Ale )
		{
                  Name = "a bottle of montoya rock";
			Hue = 1861;
		}

		public MontoyaRock( Serial serial ) : base( serial )
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

                          from.AddSkillMod(new TimedSkillMod(SkillName.Fencing, true, 10.0, TimeSpan.FromMinutes(4.0)));
			  from.SendMessage( "The montoya rock temporary boosts your Fishing skill." );

			  from.PlaySound( 726 );

			  this.Delete();

					Timer.DelayCall( TimeSpan.FromMinutes( 4.0 ), new TimerStateCallback( ReleaseHealLock ), from );
				}
				else
				{
					from.SendMessage( "Oui matey, you should wait 4 minutes before you drink another one." );
				}
			}
	
		private static void ReleaseHealLock( object state )
		{
			((Mobile)state).EndAction( typeof( BaseHealPotion ) );
		}
	}
}

