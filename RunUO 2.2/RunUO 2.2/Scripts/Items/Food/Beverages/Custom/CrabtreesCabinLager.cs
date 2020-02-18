using System;
using Server;
using Server.Network;
using Server.Items;
using System.Collections;

namespace Server.Items
{
	public class CrabtreesCabinLager : BeverageBottle
	{		
		public override int MaxQuantity { get { return 1; } }

		[Constructable]
		public CrabtreesCabinLager() : base( BeverageType.Cider )
		{
                  Name = "a bottle of crabtree's cabin lager";
			Hue = 1515;
		}

		public CrabtreesCabinLager( Serial serial ) : base( serial )
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

                          from.AddSkillMod(new TimedSkillMod(SkillName.Fishing, true, 11.0, TimeSpan.FromMinutes(2.0)));
			  from.SendMessage( "The crabtree cabin lager temporary boosts your Fishing skill." );

			  from.PlaySound( 726 );

			  this.Delete();

					Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerStateCallback( ReleaseHealLock ), from );
				}
				else
				{
					from.SendMessage( "Oui matey, you should wait 2 minutes before you drink another one." );
				}
			}
	
		private static void ReleaseHealLock( object state )
		{
			((Mobile)state).EndAction( typeof( BaseHealPotion ) );
		}
	}
}

