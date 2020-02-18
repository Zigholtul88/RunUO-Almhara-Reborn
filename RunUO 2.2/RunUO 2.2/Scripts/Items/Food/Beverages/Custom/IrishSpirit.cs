using System;
using Server;
using Server.Network;
using Server.Items;
using System.Collections;

namespace Server.Items
{
	public class IrishSpirit : BeverageBottle
	{		
		public override int MaxQuantity { get { return 1; } }

		[Constructable]
		public IrishSpirit() : base( BeverageType.Liquor )
		{
                  Name = "a bottle of irish spirit";
			Hue = 1368;
		}

		public IrishSpirit( Serial serial ) : base( serial )
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

                          from.AddSkillMod(new TimedSkillMod(SkillName.Wrestling, true, 12.0, TimeSpan.FromMinutes(2.0)));
			  from.SendMessage( "The irish spirit temporary boosts your Wrestling skill." );

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

