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

namespace Server.Fearyourself.Quests.ChainOfMammals
{
    [CorpseName("a corpse of a JackRabbit")]
    public class BriansJackRabbit : JackRabbit
    {
        [Constructable]
        public BriansJackRabbit()
            : base()
        {
            Name = "Brian's JackRabbit";
        }

        public BriansJackRabbit(Serial serial)
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

        public override void OnDeath(Container c)
        {
            Mobile m = this.FindMostRecentDamager(false);
            PlayerMobile pm = null;

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
                BriansJackRabbit newJackRabbit = new BriansJackRabbit();

                Point3D nrpos = this.Home;
                newJackRabbit.Home = this.Home;
                newJackRabbit.RangeHome = this.RangeHome;

                nrpos.X += Utility.Random(this.RangeHome) - 2 * this.RangeHome;
                nrpos.Y += Utility.Random(this.RangeHome) - 2 * this.RangeHome;
                

                newJackRabbit.MoveToWorld(nrpos, Map.Trammel);

                pm.Say("You can't believe, another JackRabbit just appeared");
            }

            base.OnDeath(c);
        }
    }
}