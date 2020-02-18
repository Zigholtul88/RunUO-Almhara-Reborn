using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Engines.Plants;
 
namespace Server.Engines.Harvest
{
      public class WheatGathering : HarvestSystem
      {
               public override HarvestVein MutateVein( Mobile from, Item tool, HarvestDefinition def, HarvestBank bank, object toHarvest, HarvestVein vein )
               {
               return base.MutateVein( from, tool, def, bank, toHarvest, vein );
               }
 
               private static int[] m_Offsets = new int[]
               {
                    -1, -1,
                    -1,  0,
                    -1,  1,
                     0, -1,
                     0,  1,
                     1, -1,
                     1,  0,
                     1,  1
               };
 
               public override void OnHarvestFinished( Mobile from, Item tool, HarvestDefinition def, HarvestVein vein, HarvestBank bank, HarvestResource resource, object harvested)
               {
                    double skillvaluelj = from.Skills[SkillName.Mining].Base;
                    int i_itemid = (int)(from.Skills[SkillName.ItemID].Base/10);
 
                 if ((Utility.RandomMinMax( 1, 1500 ) <= (1 + i_itemid)) && (skillvaluelj >= 70.1))
                 {
                      switch (Utility.RandomMinMax( 0, 10 ))
                      {
                          case 1 : from.AddToBackpack(new BarkFragment()); from.SendMessage ("you find something wedged in the wheat, a piece of bark ");break;
                          case 2 : from.AddToBackpack(new LuminescentFungi()); from.SendMessage ("you find something wedged in the wheat, some fungi ");break;
                          case 3 : from.AddToBackpack(new ParasiticPlant()); from.SendMessage ("you find something wedged in the wheat a weird looking plant");break;
                          case 4 : from.AddToBackpack(new DiseasedBark()); from.SendMessage ("you find something wedged in the wheat, some weird looking bark ");break;
                      }
                 }
           }
 
           private static WheatGathering m_System;
 
           public static WheatGathering System
           { 
                  get
                  {
                        if ( m_System == null )
                          m_System = new WheatGathering();
 
                        return m_System;
                  }
            }
 
            private HarvestDefinition m_Definition;
 
            public HarvestDefinition Definition
            {
                get{ return m_Definition; }
            }
 
            private WheatGathering()
            {
                 HarvestResource[] res;
                 HarvestVein[] veins;
 
                 #region WheatGathering
                 HarvestDefinition wheat = new HarvestDefinition();
 
                 // Resource banks are every 4x3 tiles
                     wheat.BankWidth = 2;
                     wheat.BankHeight = 2;
 
                 // Every bank holds from 4 to 5 wheat
                    wheat.MinTotal = 4;
                    wheat.MaxTotal = 5;
 
                 // A resource bank will respawn its content every 20 to 30 minutes
                    wheat.MinRespawn = TimeSpan.FromMinutes( 20.0 );
                    wheat.MaxRespawn = TimeSpan.FromMinutes( 30.0 );
 
                 // Skill checking is done on the Mining skill
                    wheat.Skill = SkillName.Mining;
 
                 // Set the list of harvestable tiles
                    wheat.Tiles = m_WheatTiles;
 
                 // Players must be within 2 tiles to harvest
                    wheat.MaxRange = 2;
 
                 // Ten logs per harvest action
                    wheat.ConsumedPerHarvest = 1;
                    wheat.ConsumedPerFeluccaHarvest = 1;
 
                 // The chopping effect
                    wheat.EffectActions = new int[]{ 13 };
                    wheat.EffectSounds = new int[]{ 0x13E };
                    wheat.EffectCounts = new int[]{ 1, 2 };
                    wheat.EffectDelay = TimeSpan.FromSeconds( 1.3 );
                    wheat.EffectSoundDelay = TimeSpan.FromSeconds( 0.9 );
 
                    wheat.NoResourcesMessage = "There's not enough wheat here to harvest";
                    wheat.FailMessage = "You hack away for a while, but fail to produce any useable wheat.";
                    wheat.OutOfRangeMessage = 500446; // That is too far away.
                    wheat.PackFullMessage = "You can't place any wheat into your backpack";
                    wheat.ToolBrokeMessage = "You broken your tool";
 
                    res = new HarvestResource[]
                    {
                          new HarvestResource( 00.0, 00.0, 00.0, "You put some Wheat in your backpack",   typeof( Wheat ) )
                    };
 
                    veins = new HarvestVein[]
                    {
                            new HarvestVein( 10.0, 0.0, res[0], null )    // Wheat
                    };
 
                    wheat.Resources = res;
                    wheat.Veins = veins;
 
                    m_Definition = wheat;
                    Definitions.Add( wheat );
                    #endregion
               }
 
               public override bool CheckHarvest( Mobile from, Item tool )
               {
                       if ( !base.CheckHarvest( from, tool ) )
                               return false;
 
                       if ( from.Mounted )
                       {
                               from.SendMessage( "You can't harvest wheat while riding." );
                               return false;
                       }
 
                       return true;
                }
 
                public override bool CheckHarvest( Mobile from, Item tool, HarvestDefinition def, object toHarvest )
                {
                       if ( !base.CheckHarvest( from, tool, def, toHarvest ) )
                               return false;
 
                       if ( from.Mounted )
                       {
                               from.SendMessage( "You can't harvest wheat while riding." );
                               return false;
                       }
 
                       return true;
                }
 
                public override void OnBadHarvestTarget( Mobile from, Item tool, object toHarvest )
                {
		        from.SendMessage( "That's not a wheat source" );
                }
 
                public static void Initialize()
                {
                        Array.Sort( m_WheatTiles );
                }
 
                #region Tile lists
                private static int[] m_WheatTiles = new int[]
                {
                      0xC55, 0xC56, 0xC58
                };
                #endregion
        }
}
 