using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Accounting;
using System.IO;
using Server.Mobiles;
using System.Collections;
using System.Text;

namespace Server.Spells.First
{
    public class CreateFoodSpell : MagerySpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Create Food", "In Mani Ylem",
                224,
                9011,
                Reagent.Garlic,
                Reagent.Ginseng,    
                Reagent.MandrakeRoot
            );

        public override SpellCircle Circle { get { return SpellCircle.First; } }

        public CreateFoodSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            
        		if ( CheckSequence() )
			{
				Caster.CloseGump( typeof( CreateFoodGump ) );
                Caster.SendGump(new CreateFoodGump());

			}

			FinishSequence();
		}

        }
    }


		
