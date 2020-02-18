using System;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
	public class PoisonBoomerang : Item
	{
		[Constructable]
		public PoisonBoomerang() : base( 0x090A )
		{
			Name = "Poison Boomerang";
			Weight = 5.0;
			Hue =  78;
		}

		public PoisonBoomerang( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
			else
			{
				if ( from.BeginAction( typeof( PoisonBoomerang ) ) ) 
				{
				     InternalTarget t = new InternalTarget( this );
				     from.Target = t;
				}
				else
				{
				     from.SendMessage( "You must wait 5 seconds before using this again." );
				}
			}
		}

		private class InternalTarget : Target
		{
			private PoisonBoomerang m_PoisonBoomerang;

			public InternalTarget( PoisonBoomerang poisonboomerang ) : base( 10, false, TargetFlags.Harmful )
			{
				m_PoisonBoomerang = poisonboomerang;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Mobile )
				{
					Mobile m = (Mobile)targeted;
			
					if ( m != from && from.HarmfulCheck( m ) )
					{
						Direction to = from.GetDirectionTo( m );

						from.Direction = to;

						from.Animate( from.Mounted ? 26 : 9, 7, 1, true, false, 0 );

						if ( Utility.RandomDouble() <= (Math.Sqrt( from.Dex / 100.0 ) * 1.0) )
						{
							from.MovingEffect( m, 0x090A, 7, 1, false, false, 0x481, 78 );
							m.Paralyze( TimeSpan.FromSeconds( 60 ) );
		                                        m.ApplyPoison( m, Poison.Lethal );
							Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerStateCallback( ReleasecastLock ), from );
							
						}
						else
						{
							int x = 0, y = 0;

							switch ( to & Direction.Mask )
							{
								case Direction.North: --y; break;
								case Direction.South: ++y; break;
								case Direction.West: --x; break;
								case Direction.East: ++x; break;
								case Direction.Up: --x; --y; break;
								case Direction.Down: ++x; ++y; break;
								case Direction.Left: --x; ++y; break;
								case Direction.Right: ++x; --y; break;
							}

							x += Utility.Random( -1, 3 );
							y += Utility.Random( -1, 3 );

							x += m.X;
							y += m.Y;

							from.MovingEffect( m_PoisonBoomerang, 0x090A, 7, 1, false, false, 0x481, 78 );

							from.SendMessage( "You miss." );
							Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerStateCallback( ReleasecastLock ), from );
						}
					}
				}
			}
		}

		private static void ReleasecastLock( object state )
		{
 		((Mobile)state).EndAction( typeof( PoisonBoomerang ) );
		}
	}
}