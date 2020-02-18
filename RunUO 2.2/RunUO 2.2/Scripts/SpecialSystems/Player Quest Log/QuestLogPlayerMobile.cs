using System; 
using System.IO; 
using System.Collections;  
using Server.Misc; 
using Server.Items; 
using Server.Gumps; 
using Server.Multis; 
using Server.Engines.Help; 
using Server.Network; 
using Server.Mobiles; 

namespace Server.Mobiles 
{       
        public class QuestLogPlayerMobile : PlayerMobile 
        { 
              private bool m_CompletedAFlagForHammerhill;
              private bool m_CompletedBaroqueORama;
              private bool m_CompletedBirdemic;
              private bool m_CompletedBrightClub;
              private bool m_CompletedChampionHunt1;
              private bool m_CompletedEggCollector;
              private bool m_CompletedEnchantedShovel;
              private bool m_CompletedFeeshTendees;
              private bool m_CompletedFullMetalForgery;
              private bool m_CompletedHaldursBait;
              private bool m_CompletedInsecticide;
              private bool m_CompletedJadeJungleJems;
              private bool m_CompletedKissOfTheSerpentMistress;
              private bool m_CompletedLetterDelivery;
              private bool m_CompletedMolassesGreed;
              private bool m_CompletedStaffOfFlyingMonkeys;
              private bool m_CompletedStarLakeInfestation;
              private bool m_CompletedStolenNecklace;
              private bool m_CompletedSweetChildOfMine;
              private bool m_CompletedTheFairElain;
              private bool m_CompletedThinnngOutTheHerd;
              private bool m_CompletedThisIsNotHalloween;
              private bool m_CompletedThoseBlueBastards;
              private bool m_CompletedTreasureOfTheSands;

              private bool m_CompletedCollectorQuest;
              private bool m_CompletedWitchApprenticeQuest;
     
              public override void Deserialize( GenericReader reader ) 
              { 
                       base.Deserialize( reader ); 
                       int version = reader.ReadInt(); 

                       if (version>=1) 
                       { 
                               m_CompletedAFlagForHammerhill = (bool)reader.ReadBool();
                               m_CompletedBaroqueORama = (bool)reader.ReadBool();
                               m_CompletedBirdemic = (bool)reader.ReadBool();
                               m_CompletedBrightClub = (bool)reader.ReadBool();
                               m_CompletedChampionHunt1 = (bool)reader.ReadBool();
                               m_CompletedEggCollector = (bool)reader.ReadBool();
                               m_CompletedEnchantedShovel = (bool)reader.ReadBool();
                               m_CompletedFeeshTendees = (bool)reader.ReadBool();
                               m_CompletedFullMetalForgery = (bool)reader.ReadBool();
                               m_CompletedHaldursBait = (bool)reader.ReadBool();
                               m_CompletedInsecticide = (bool)reader.ReadBool();
                               m_CompletedJadeJungleJems = (bool)reader.ReadBool();
                               m_CompletedKissOfTheSerpentMistress = (bool)reader.ReadBool();
                               m_CompletedLetterDelivery = (bool)reader.ReadBool();
                               m_CompletedMolassesGreed = (bool)reader.ReadBool();
                               m_CompletedStaffOfFlyingMonkeys = (bool)reader.ReadBool();
                               m_CompletedStarLakeInfestation = (bool)reader.ReadBool();
                               m_CompletedStolenNecklace = (bool)reader.ReadBool();
                               m_CompletedSweetChildOfMine = (bool)reader.ReadBool();
                               m_CompletedTheFairElain = (bool)reader.ReadBool();
                               m_CompletedThinnngOutTheHerd = (bool)reader.ReadBool();
                               m_CompletedThisIsNotHalloween = (bool)reader.ReadBool();
                               m_CompletedThoseBlueBastards = (bool)reader.ReadBool();
                               m_CompletedTreasureOfTheSands = (bool)reader.ReadBool();

                               m_CompletedCollectorQuest = (bool)reader.ReadBool();
                               m_CompletedWitchApprenticeQuest = (bool)reader.ReadBool();
                       } 
               } 
               public override void Serialize( GenericWriter writer ) 
               { 
                        base.Serialize( writer ); 
                        writer.Write( (int)1 );//version 

                        //version 1 
                        writer.Write( (bool)m_CompletedAFlagForHammerhill );
                        writer.Write( (bool)m_CompletedBaroqueORama );
                        writer.Write( (bool)m_CompletedBirdemic );
                        writer.Write( (bool)m_CompletedBrightClub );
                        writer.Write( (bool)m_CompletedChampionHunt1 );
                        writer.Write( (bool)m_CompletedEggCollector );
                        writer.Write( (bool)m_CompletedEnchantedShovel );
                        writer.Write( (bool)m_CompletedFeeshTendees );
                        writer.Write( (bool)m_CompletedFullMetalForgery );
                        writer.Write( (bool)m_CompletedHaldursBait );
                        writer.Write( (bool)m_CompletedInsecticide );
                        writer.Write( (bool)m_CompletedJadeJungleJems );
                        writer.Write( (bool)m_CompletedKissOfTheSerpentMistress );
                        writer.Write( (bool)m_CompletedLetterDelivery );
                        writer.Write( (bool)m_CompletedMolassesGreed );
                        writer.Write( (bool)m_CompletedStaffOfFlyingMonkeys );
                        writer.Write( (bool)m_CompletedStarLakeInfestation );
                        writer.Write( (bool)m_CompletedStolenNecklace );
                        writer.Write( (bool)m_CompletedSweetChildOfMine );
                        writer.Write( (bool)m_CompletedTheFairElain );
                        writer.Write( (bool)m_CompletedThinnngOutTheHerd );
                        writer.Write( (bool)m_CompletedThisIsNotHalloween );
                        writer.Write( (bool)m_CompletedThoseBlueBastards );
                        writer.Write( (bool)m_CompletedTreasureOfTheSands );

                        writer.Write( (bool)m_CompletedCollectorQuest );
                        writer.Write( (bool)m_CompletedWitchApprenticeQuest );
                } 
                public QuestLogPlayerMobile() 
                { 
                } 

                public QuestLogPlayerMobile(Serial s) :base(s) 
                { 
                } 

                public bool CompletedAFlagForHammerhill
                {
                        get{ return m_CompletedAFlagForHammerhill; } 
                        set{ m_CompletedAFlagForHammerhill = value; }
                }
                public bool CompletedBaroqueORama
                {
                        get{ return m_CompletedBaroqueORama; } 
                        set{ m_CompletedBaroqueORama = value; }
                }
                public bool CompletedBirdemic
                {
                        get{ return m_CompletedBirdemic; } 
                        set{ m_CompletedBirdemic = value; }
                }
                public bool CompletedBrightClub
                {
                        get{ return m_CompletedBrightClub; } 
                        set{ m_CompletedBrightClub = value; }
                }
                public bool CompletedChampionHunt1
                {
                        get{ return m_CompletedChampionHunt1; } 
                        set{ m_CompletedChampionHunt1 = value; }
                }
                public bool CompletedEggCollector
                {
                        get{ return m_CompletedEggCollector; } 
                        set{ m_CompletedEggCollector = value; }
                }
                public bool CompletedEnchantedShovel
                {
                        get{ return m_CompletedEnchantedShovel; } 
                        set{ m_CompletedEnchantedShovel = value; }
                }
                public bool CompletedFeeshTendees
                {
                        get{ return m_CompletedFeeshTendees; } 
                        set{ m_CompletedFeeshTendees = value; }
                }
                public bool CompletedFullMetalForgery
                {
                        get{ return m_CompletedFullMetalForgery; } 
                        set{ m_CompletedFullMetalForgery = value; }
                }
                public bool CompletedHaldursBait
                {
                        get{ return m_CompletedHaldursBait; } 
                        set{ m_CompletedHaldursBait = value; }
                }
                public bool CompletedInsecticide
                {
                        get{ return m_CompletedInsecticide; } 
                        set{ m_CompletedInsecticide = value; }
                }
                public bool CompletedJadeJungleJems
                {
                        get{ return m_CompletedJadeJungleJems; } 
                        set{ m_CompletedJadeJungleJems = value; }
                }
                public bool CompletedKissOfTheSerpentMistress
                {
                        get{ return m_CompletedKissOfTheSerpentMistress; } 
                        set{ m_CompletedKissOfTheSerpentMistress = value; }
                }
                public bool CompletedLetterDelivery
                {
                        get{ return m_CompletedLetterDelivery; } 
                        set{ m_CompletedLetterDelivery = value; }
                }
                public bool CompletedMolassesGreed
                {
                        get{ return m_CompletedMolassesGreed; } 
                        set{ m_CompletedMolassesGreed = value; }
                }
                public bool CompletedStaffOfFlyingMonkeys
                {
                        get{ return m_CompletedStaffOfFlyingMonkeys; } 
                        set{ m_CompletedStaffOfFlyingMonkeys = value; }
                }
                public bool CompletedStarLakeInfestation
                {
                        get{ return m_CompletedStarLakeInfestation; } 
                        set{ m_CompletedStarLakeInfestation = value; }
                }
                public bool CompletedStolenNecklace
                {
                        get{ return m_CompletedStolenNecklace; } 
                        set{ m_CompletedStolenNecklace = value; }
                }
                public bool CompletedSweetChildOfMine
                {
                        get{ return m_CompletedSweetChildOfMine; } 
                        set{ m_CompletedSweetChildOfMine = value; }
                }
                public bool CompletedTheFairElain
                {
                        get{ return m_CompletedTheFairElain; } 
                        set{ m_CompletedTheFairElain = value; }
                }
                public bool CompletedThinnngOutTheHerd
                {
                        get{ return m_CompletedThinnngOutTheHerd; } 
                        set{ m_CompletedThinnngOutTheHerd = value; }
                }
                public bool CompletedThisIsNotHalloween
                {
                        get{ return m_CompletedThisIsNotHalloween; } 
                        set{ m_CompletedThisIsNotHalloween = value; }
                }
                public bool CompletedThoseBlueBastards
                {
                        get{ return m_CompletedThoseBlueBastards; } 
                        set{ m_CompletedThoseBlueBastards = value; }
                }
                public bool CompletedTreasureOfTheSands
                {
                        get{ return m_CompletedTreasureOfTheSands; } 
                        set{ m_CompletedTreasureOfTheSands = value; }
                }
                public bool CompletedCollectorQuest
                {
                        get{ return m_CompletedCollectorQuest; } 
                        set{ m_CompletedCollectorQuest = value; }
                }
                public bool CompletedWitchApprenticeQuest
                {
                        get{ return m_CompletedWitchApprenticeQuest; } 
                        set{ m_CompletedWitchApprenticeQuest = value; }
                }
        }
}
