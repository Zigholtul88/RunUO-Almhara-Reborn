using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles;

namespace Server.Mobiles 
{ 
	public class BaseGuardian : BaseCreature 
	{ 
		public BaseGuardian(AIType ai, FightMode fm, int PR, int FR, double AS, double PS) : base( ai, fm, PR, FR, AS, PS )
		{
			SpeechHue = Utility.RandomDyedHue(); 
			Hue = Utility.RandomSkinHue();
		}

		public override bool IsEnemy( Mobile m )
		{
                        if (m is BaseGuardian || m is BaseVendor || m is PlayerVendor || m is TownCrier || m is Miasma )

				return false;

			if ( m is PlayerMobile && !m.Criminal )

				return false;

			if (m is BaseCreature)
			{
				BaseCreature c = (BaseCreature)m;

				if( c.Controlled || c.FightMode == FightMode.Aggressor || c.FightMode == FightMode.None )

					return false;
			}	

			return true;
		}

        public override bool OnBeforeDeath()
        {
            if (Combatant is PlayerMobile)
                Combatant.Kills += 1;
        	
            return base.OnBeforeDeath();
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            if (e.Handled || !e.Mobile.InRange(Location, 18))
                return;

            if (e.Speech.ToLower().Contains("guard") || e.Speech.ToLower().Contains("guards") || e.Speech.ToLower().Contains("help"))
            {
                Direction = GetDirectionTo(e.Mobile);

                if (e.Mobile.Combatant != null && IsEnemy(e.Mobile.Combatant))
                {
                    Say(speech[Utility.Random(speech.Length)]);
                    Warmode = true;
                    Combatant = e.Mobile.Combatant;
                }
                else if (IsEnemy(e.Mobile))
                {
                    Say(speech[Utility.Random(speech.Length)]);
                    Warmode = true;
                    Combatant = e.Mobile;
                }
                else
                {
                    Emote("looks around");
                    Warmode = false;
                    Combatant = null;
                }
            }
        }

        static string[] speech =
        {
            "To the fight!",
            "To arms!",
            "Attack!",
            "The battle is on!",
            "To your weapons!",
            "I have my eye on my enemy!",
            "Time to die!",
            "Nothing walks away!",
            "I have sight of my enemy!",
            "You will not prevail!",
            "To my side!",
            "We must defend our land!",
            "Fight for our people!",
            "I see them!",
            "Destroy them all!"
};


		public BaseGuardian( Serial serial ) : base( serial ) 
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
	} 
}   