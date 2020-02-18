using System;
using Server;
using Server.Network;
using Server.Items;
using System.Collections;

namespace Server.Items
{
	public class BumLight : BeverageBottle
	{		
		public override int MaxQuantity { get { return 1; } }

		[Constructable]
		public BumLight() : base( BeverageType.Ale )
		{
                  Name = "a bottle of bum light";
			Hue = 2119;
		}

		public BumLight( Serial serial ) : base( serial )
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

                          from.AddSkillMod(new TimedSkillMod(SkillName.Peacemaking, true, 8.0, TimeSpan.FromMinutes(1.0)));
			  from.SendMessage( "The bum light temporary boosts your Peacemaking skill." );

			  from.PlaySound( 726 );

			  this.Delete();

					Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( ReleaseHealLock ), from );
				}
				else
				{
					from.SendMessage( "Oui matey, you should wait 1 minute before you drink another one." );
				}
			}
	
		private static void ReleaseHealLock( object state )
		{
			((Mobile)state).EndAction( typeof( BaseHealPotion ) );
		}
	}
}

