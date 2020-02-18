using System;
using Server;
using Server.ContextMenus;
using Server.Factions;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.SkillHandlers
{
	public class RemoveTrap
	{
		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.RemoveTrap].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile m )
		{
			if ( m.Skills[SkillName.Lockpicking].Value < 50 )
			{
				m.SendLocalizedMessage( 502366 ); // You do not know enough about locks.  Become better at picking locks.
			}
			else if ( m.Skills[SkillName.DetectHidden].Value < 50 )
			{
				m.SendLocalizedMessage( 502367 ); // You are not perceptive enough.  Become better at detect hidden.
			}
			else
			{
				m.Target = new InternalTarget();

				m.SendLocalizedMessage( 502368 ); // Wich trap will you attempt to disarm?
			}

			return TimeSpan.FromSeconds( 10.0 ); // 10 second delay before beign able to re-use a skill
		}

		private class InternalTarget : Target
		{
			public InternalTarget() :  base ( 2, false, TargetFlags.None )
			{
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is BaseCreature )
				{
					BaseCreature creature = (BaseCreature) targeted;

					if ( from.CheckTargetSkill( SkillName.RemoveTrap, creature, 30, 100 ) )
					{
					        if ( creature is Turret )
					        {
                                                        creature.Kill();
                                                        from.SendMessage( "You have disarmed the trap." );
                                                }
                                                else
                                                {
					                from.SendLocalizedMessage( 502816 ); // You feel that such an action would be inappropriate
                                                }
                                        }
				}
				else if ( targeted is BoulderTrap )
				{
					BoulderTrap bouldertrap = (BoulderTrap) targeted;

                                        if ( from.Skills.RemoveTrap.Base >= 75.0 )
                                        {
                                                bouldertrap.Delete();
                                                from.PlaySound( 0x5CE );
                                                from.SendMessage( "You have disarmed the trap." );
                                        }
					else if ( from.CheckTargetSkill( SkillName.RemoveTrap, bouldertrap, 50, 85 ) )
					{
                                                bouldertrap.Delete();
                                                from.PlaySound( 0x5CE );
                                                from.SendMessage( "You have disarmed the trap." );
                                                from.Skills.RemoveTrap.Base += 1;
                                        }
                                        else
                                        {
                                                from.SendMessage( "You fail to disarm the trap." );
                                        }
                                }
				else if ( targeted is BoulderTrap2 )
				{
					BoulderTrap2 bouldertrap2 = (BoulderTrap2) targeted;

                                        if ( from.Skills.RemoveTrap.Base >= 75.0 )
                                        {
                                                bouldertrap2.Delete();
                                                from.PlaySound( 0x5CE );
                                                from.SendMessage( "You have disarmed the trap." );
                                        }
					else if ( from.CheckTargetSkill( SkillName.RemoveTrap, bouldertrap2, 50, 85 ) )
					{
                                                bouldertrap2.Delete();
                                                from.PlaySound( 0x5CE );
                                                from.SendMessage( "You have disarmed the trap." );
                                                from.Skills.RemoveTrap.Base += 1;
                                        }
                                        else
                                        {
                                                from.SendMessage( "You fail to disarm the trap." );
                                        }
                                }
				else if ( targeted is MovingTrap )
				{
					MovingTrap movingtrap = (MovingTrap) targeted;

                                        if ( from.Skills.RemoveTrap.Base >= 30.0 )
                                        {
                                                movingtrap.Delete();
                                                from.PlaySound( 0x5CE );
                                                from.SendMessage( "You have disarmed the trap." );
                                        }
					else if ( from.CheckTargetSkill( SkillName.RemoveTrap, movingtrap, 0, 30 ) )
					{
                                                movingtrap.Delete();
                                                from.PlaySound( 0x5CE );
                                                from.SendMessage( "You have disarmed the trap." );
                                                from.Skills.RemoveTrap.Base += 1;
                                        }
                                        else
                                        {
                                                from.SendMessage( "You fail to disarm the trap." );
                                        }
                                }
				else if ( targeted is MovingTrap2 )
				{
					MovingTrap2 movingtrap2 = (MovingTrap2) targeted;

                                        if ( from.Skills.RemoveTrap.Base >= 30.0 )
                                        {
                                                movingtrap2.Delete();
                                                from.PlaySound( 0x5CE );
                                                from.SendMessage( "You have disarmed the trap." );
                                        }

					else if ( from.CheckTargetSkill( SkillName.RemoveTrap, movingtrap2, 0, 30 ) )
					{
                                                movingtrap2.Delete();
                                                from.PlaySound( 0x5CE );
                                                from.SendMessage( "You have disarmed the trap." );
                                                from.Skills.RemoveTrap.Base += 1;
                                        }
                                        else
                                        {
                                                from.SendMessage( "You fail to disarm the trap." );
                                        }
                                }
				else if ( targeted is MovingTreeTrap )
				{
					MovingTreeTrap movingtreetrap = (MovingTreeTrap) targeted;

                                        if ( from.Skills.RemoveTrap.Base >= 30.0 )
                                        {
                                                movingtreetrap.Delete();
                                                from.PlaySound( 0x5CE );
                                                from.SendMessage( "You have disarmed the trap." );
                                        }
					else if ( from.CheckTargetSkill( SkillName.RemoveTrap, movingtreetrap, 15, 50 ) )
					{
                                                movingtreetrap.Delete();
                                                from.PlaySound( 0x5CE );
                                                from.SendMessage( "You have disarmed the trap." );
                                                from.Skills.RemoveTrap.Base += 1;
                                        }
                                        else
                                        {
                                                from.SendMessage( "You fail to disarm the trap." );
                                        }
                                }
				else if ( targeted is MovingTreeTrap2 )
				{
					MovingTreeTrap2 movingtreetrap2 = (MovingTreeTrap2) targeted;

                                        if ( from.Skills.RemoveTrap.Base >= 30.0 )
                                        {
                                                movingtreetrap2.Delete();
                                                from.PlaySound( 0x5CE );
                                                from.SendMessage( "You have disarmed the trap." );
                                        }

					else if ( from.CheckTargetSkill( SkillName.RemoveTrap, movingtreetrap2, 15, 50 ) )
					{
                                                movingtreetrap2.Delete();
                                                from.PlaySound( 0x5CE );
                                                from.SendMessage( "You have disarmed the trap." );
                                                from.Skills.RemoveTrap.Base += 1;
                                        }
                                        else
                                        {
                                                from.SendMessage( "You fail to disarm the trap." );
                                        }
                                }

				else if ( targeted is TrapableContainer )
				{
					TrapableContainer targ = (TrapableContainer)targeted;

					from.Direction = from.GetDirectionTo( targ );

					if ( targ.TrapType == TrapType.None )
					{
						from.SendLocalizedMessage( 502373 ); // That doesn't appear to be trapped
						return;
					}

					from.PlaySound( 0x241 );
					
					if ( from.CheckTargetSkill( SkillName.RemoveTrap, targ, targ.TrapPower, targ.TrapPower + 30 ) )
					{
						targ.TrapPower = 0;
						targ.TrapLevel = 0;
						targ.TrapType = TrapType.None;
						from.SendLocalizedMessage( 502377 ); // You successfully render the trap harmless
					}
					else
					{
						from.SendLocalizedMessage( 502372 ); // You fail to disarm the trap... but you don't set it off
					}
				}
				else if ( targeted is BaseFactionTrap )
				{
					BaseFactionTrap trap = (BaseFactionTrap) targeted;
					Faction faction = Faction.Find( from );

					FactionTrapRemovalKit kit = ( from.Backpack == null ? null : from.Backpack.FindItemByType( typeof( FactionTrapRemovalKit ) ) as FactionTrapRemovalKit );

					bool isOwner = ( trap.Placer == from || ( trap.Faction != null && trap.Faction.IsCommander( from ) ) );

					if ( faction == null )
					{
						from.SendLocalizedMessage( 1010538 ); // You may not disarm faction traps unless you are in an opposing faction
					}
					else if ( faction == trap.Faction && trap.Faction != null && !isOwner )
					{
						from.SendLocalizedMessage( 1010537 ); // You may not disarm traps set by your own faction!
					}
					else if ( !isOwner && kit == null )
					{
						from.SendLocalizedMessage( 1042530 ); // You must have a trap removal kit at the base level of your pack to disarm a faction trap.
					}
					else
					{
						if ( (Core.ML && isOwner) || (from.CheckTargetSkill( SkillName.RemoveTrap, trap, 80.0, 100.0 ) && from.CheckTargetSkill( SkillName.Tinkering, trap, 80.0, 100.0 )) )
						{
							from.PrivateOverheadMessage( MessageType.Regular, trap.MessageHue, trap.DisarmMessage, from.NetState );

							if ( !isOwner )
							{
								int silver = faction.AwardSilver( from, trap.SilverFromDisarm );

								if ( silver > 0 )
									from.SendLocalizedMessage( 1008113, true, silver.ToString( "N0" ) ); // You have been granted faction silver for removing the enemy trap :
							}

							trap.Delete();
						}
						else
						{
							from.SendLocalizedMessage( 502372 ); // You fail to disarm the trap... but you don't set it off
						}

						if ( !isOwner && kit != null )
							kit.ConsumeCharge( from );
					}
				}
				else
				{
					from.SendLocalizedMessage( 502373 ); // That does'nt appear to be trapped
				}
			}
		}
	}
}