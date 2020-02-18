/*
LoggedQuestSystem with two example quests
Copyright (C) 2006 BEYLER Jean Christophe

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/

using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Fearyourself.Quests.Core;

namespace Server.Fearyourself.Quests.BunnyAttack
{
    [CorpseName("a hare corpse")]
    public class BobsRabbit : Rabbit
    {
        [Constructable]
        public BobsRabbit()
            : base()
        {
            Name = "Bob's rabbit";
        }

        public BobsRabbit(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public override void Damage(int amount, Mobile from)
        {
            PlayerMobile pm = null;
            if (from is PlayerMobile)
            {
                pm = from as PlayerMobile;
            }
            else if (from is BaseCreature)
            {
                BaseCreature bc = from as BaseCreature;
                if (bc.Controlled == true)
                {
                    pm = bc.ControlMaster as PlayerMobile;
                }
            }

            if (pm != null)
            {
                BobQuest qs = pm.Quest as BobQuest;

                if (qs != null)
                {
                    //Are we in the right objective ?
                    if (qs.IsObjectiveInProgress(typeof(KillBunniesObjective)))
                    {
                        base.Damage(amount, from);
                    }
                    else
                    {
                        this.Say("You've killed enough bunnies, go see Bob");
                    }
                }
                else
                {
                    //Look for the quest state
                    LoggedQuestState state = LoggedQuestSystem.getQuestState(from, "Bunny Attack Quest");

                    //Switch on states
                    switch (state)
                    {
                        case LoggedQuestState.NOTINVOLVED:
                            this.Say("Stop it, go see bob if you want to play!");
                            break;
                        case LoggedQuestState.CANCELED:
                            this.Say("Stop it, you canceled, tough!");
                            break;
                        case LoggedQuestState.FINISHED:
                            this.Say("Stop it now, this is not your quest anymore");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public override void OnDeath(Container c)
        {
            Mobile m = this.FindMostRecentDamager(false);
            PlayerMobile pm = null;
            BobQuest bq = null;

            bool ressurect = true;

            if (m is PlayerMobile)
            {
                pm = m as PlayerMobile;
            }
            else if (m is BaseCreature)
            {
                BaseCreature bc = m as BaseCreature;

                if (bc.Controlled == true)
                {
                    pm = bc.ControlMaster as PlayerMobile;
                }
            }

            if (pm != null)
            {
                bq = pm.Quest as BobQuest;
            }

            //Ok rabbit died by someone who's got the quest so it's all good
            if (bq != null)
            {
                if (bq.IsObjectiveInProgress(typeof(KillBunniesObjective)))
                {
                    ressurect = false;
                }
            }

            if (ressurect) //No marker or finished quest
            {
                BobsRabbit newrabbit = new BobsRabbit();

                Point3D nrpos = this.Location;

                nrpos.X += Utility.Random(8) - 4;
                nrpos.Y += Utility.Random(8) - 4;
                newrabbit.MoveToWorld(nrpos, Map.Trammel);

                if (pm != null)
                {
                    if (bq != null)
                    {
                        newrabbit.Say("You've killed enough rabbits don't you think ?");
                    }
                    else
                    {
                        //Look for the quest state
                        LoggedQuestState state = LoggedQuestSystem.getQuestState(pm, "Bunny Attack Quest");

                        //Switch on states
                        switch (state)
                        {
                            case LoggedQuestState.NOTINVOLVED:
                                this.Say("Stop it, go see bob if you want to play!");
                                break;
                            case LoggedQuestState.CANCELED:
                                this.Say("Stop it, you canceled, tough!");
                                break;
                            case LoggedQuestState.FINISHED:
                                this.Say("Stop it now, this is not your quest anymore");
                                break;
                            case LoggedQuestState.DECLINED:
                                this.Say("Stop it now, you declined, tough!");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            base.OnDeath(c);
        }
    }
}