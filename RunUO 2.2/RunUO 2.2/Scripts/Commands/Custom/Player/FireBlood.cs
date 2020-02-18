using System;
using System.Collections;
using Server;
using Server.Commands;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Scripts.Commands 
{ 
	public class FireBlood 
        { 
        	public static void Initialize() 
             	{ 
              		CommandSystem.Register( "fireblood", AccessLevel.Player, new CommandEventHandler( FireBlood_OnCommand ) );
              		CommandSystem.Register( "fire blood", AccessLevel.Player, new CommandEventHandler( FireBlood_OnCommand ) );
             	}

             	public static void FireBlood_OnCommand( CommandEventArgs e ) 
             	{
               		Mobile m = e.Mobile;

               		if ( CanUse( m ) )
               			OnUse( m );
               		else
               			return;
             	}

              	public static bool CanUse( Mobile m )
              	{
			PlayerMobile player = m as PlayerMobile;

                 	if ( player.RacialNumber == 4 ) // Yugitashi
                        {
                 		return true;
                        }
                 	else
			{
                 		return false;
			}
              	}

              	public static TimeSpan OnUse( Mobile from )
              	{
                        if ( from.Hits < (from.HitsMax ) )
			{
				from.SendMessage( "You're too physically weak to use fire blood." );
			}
			else
			{
				from.SendMessage( "Target a weapon to imbue it with fire." );
				from.Target = new FireBlood.InternalTarget();
			}

			return TimeSpan.FromSeconds( 1.0 );
		}

		private class InternalTarget : Target
		{
			public InternalTarget() : base( 3, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted == null )
					return;

				if (!(targeted is Item) )
				{
					from.SendMessage( "This ability can only be used on weapons." );
					return;
				}
				
				if (!(targeted as Item).IsChildOf(from.Backpack) )
				{
					from.SendMessage( "You can use this ability only on items in your backpack." );
					return;
				}
				
				if ( targeted is BaseWeapon )
				{
					BaseWeapon w = targeted as BaseWeapon;

					if ( w !=null )
					{
						if ( w.WeaponAttributes.HitFireball!=0 )
						{
							w.WeaponAttributes.HitFireball=0;
							from.SendMessage( "You wipe the fire blood off of the weapon." );

							Effects.PlaySound( from.Location, from.Map, 0x249 );
						}
                                                else
						{
							w.WeaponAttributes.HitFireball=15;
							from.Hits /= 5;
							from.SendMessage( "You smear fire blood onto the weapon." );

							Effects.SendLocationParticles( from, 0x3709, 10, 30, 5052 );
							Effects.PlaySound( from.Location, from.Map, 0x208 );
						}
					}
				}
                                else
				{
					from.SendMessage( "Fireblood did not react to targeted object" );
				}
			}
		}
	}
}