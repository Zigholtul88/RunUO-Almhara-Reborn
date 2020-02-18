using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class Bangerang : Item
	{
		[Constructable]
		public Bangerang() : base( 0x090A )
		{
			Name = "Bangerang";
			Weight = 5.0;
			Hue =  78;
		}

		public Bangerang( Serial serial ) : base( serial )
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
				if ( from.BeginAction( typeof( Bangerang ) ) ) 
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
			private Bangerang m_Bangerang;

			public InternalTarget( Bangerang bangerang ) : base( 10, false, TargetFlags.Harmful )
			{
				m_Bangerang = bangerang;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( from == targeted )
				{
			                from.SendMessage( "You can't target yourself." );
				}
				else if ( targeted is Item )
				{
			                from.SendMessage( "You can't target items." );
				}
				else if ( targeted is Corpse )
				{
			                from.SendMessage( "You can't target a corpse." );
				}
				else if ( targeted is BaseVendor )
				{
			                from.SendMessage( "You can't target that vendor." );
				}
				else if ( targeted is BaseVendor && ((BaseVendor)targeted).IsInvulnerable )
				{
			                from.SendMessage( "You can't target that vendor." );
				}
				else if ( targeted is Mobile )
				{
					Mobile targ = (Mobile)targeted;
			
					if ( targ != from && from.HarmfulCheck( targ ) )
					{
						Direction to = from.GetDirectionTo( targ );

						from.Direction = to;

						from.Animate( from.Mounted ? 26 : 9, 7, 1, true, false, 0 );

						if ( Utility.RandomDouble() <= (Math.Sqrt( from.Dex / 100.0 ) * 1.0) )
						{
							from.MovingEffect( targ, 0x090A, 7, 1, false, false, 0x481, 78 );

			                                targ.Fame = -1000;
			                                targ.Karma = -1000;

		                                        targ.RawStr -= ( Utility.Random( 1, 5 ) );
		                                        targ.RawDex -= ( Utility.Random( 1, 5 ) );
		                                        targ.RawInt -= ( Utility.Random( 1, 5 ) );

		                                        targ.Skills.Total -= ( Utility.Random( 5, 25 ) );

							targ.Paralyze( TimeSpan.FromSeconds( 60 ) );
		                                        from.ApplyPoison( targ, Poison.Lethal );
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

							x += targ.X;
							y += targ.Y;

							from.MovingEffect( m_Bangerang, 0x090A, 7, 1, false, false, 0x481, 78 );

							from.SendMessage( "You miss." );
							Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerStateCallback( ReleasecastLock ), from );
						}
					}
				}
			}
		}

		private static void ReleasecastLock( object state )
		{
 		((Mobile)state).EndAction( typeof( Bangerang ) );
		}
	}
}