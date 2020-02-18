using System;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.SkillHandlers
{
	public class TasteID
	{
		public static void Initialize()
		{
			SkillInfo.Table[(int)SkillName.TasteID].Callback = new SkillUseCallback( OnUse );
		}

		public static TimeSpan OnUse( Mobile m )
		{
			m.Target = new InternalTarget();

			m.SendLocalizedMessage( 502807 ); // What would you like to taste?

			return TimeSpan.FromSeconds( 1.0 );
		}

		[PlayerVendorTarget]
		private class InternalTarget : Target
		{
			public InternalTarget() :  base ( 2, false, TargetFlags.None )
			{
				AllowNonlocal = true;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
////////////////////////////////////////////////////////////// Mobiles
				if ( targeted is BaseCreature )
				{
					BaseCreature creature = (BaseCreature) targeted;

					if ( from.CheckTargetSkill( SkillName.TasteID, creature, 0.0, 100.0 ) )
					{
////////////////////////////////////////////////////////////// Zaythalor Forest
					      if ( creature is BlackAntZaythalorForest )
					      {
				                    creature.Say( "Bro, I ain't worth nutin! You hear me {0}", from.Name );
					      }
					      else if ( creature is FaerieBeetle )
					      {
		                                    from.Hits += ( Utility.Random( 10, 15 ) ); 
		                                    from.FixedParticles( 0x375A, 1, 30, 9966, 88, 2, EffectLayer.Head ); 
           	                                    from.FixedParticles( 0x37B9, 1, 30, 9502, 85, 3, EffectLayer.Head );
		                                    from.FixedParticles( 0x376A, 1, 31, 9961, 80, 0, EffectLayer.Waist );
           	                                    from.FixedParticles( 0x37C4, 1, 31, 9502, 88, 2, EffectLayer.Waist );
				                    from.PlaySound( 0x202 );

                                                    from.SendMessage( "It's magically delicious." );
					      }
					      else if ( creature is FaerieBeetleCollector )
					      {
		                                    from.Hits += ( Utility.Random( 2, 5 ) ); 
				                    from.FixedParticles( 0x376A, 9, 32, 5005, EffectLayer.Waist );
				                    from.PlaySound( 0x1F2 );

                                                    from.SendMessage( "It's magically delicious, at a fraction of the price." );
					      }
					      else if ( creature is ForestBat )
					      {
                                                    creature.SendMessage( "Nah Nah Nah Nah Nah Nah Nah Nah! Batman!" );
					      }
					      else if ( creature is GazerLarva )
					      {
                                                    if ( from.Skills.Magery.Base >= 50.0 )
                                                    {
                                                         from.Skills.Magery.Base += 0.2;
                                                         creature.Kill();
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
                                                    }
					      }
					      else if ( creature is Gizzard )
					      {
                                                    from.AddToBackpack( new BlackPearl(5) );
				                    creature.Combatant = from;

                                                    if ( from.Skills.Magery.Base >= 50.0 )
                                                    {
                                                         from.Skills.Magery.Base += 0.2;
                                                         creature.Kill();
                                                    }
					      }
					      else if ( creature is GreenSlime )
					      {
                                                    if ( from.Skills.Poisoning.Base >= 50.0 )
                                                    {
                                                         creature.Kill();
                                                    }
                                                    else
                                                    {
                                                         from.SendMessage( "Slimer!" );
		                                         from.ApplyPoison( from, Poison.Lesser );
                                                    }
					      }
					      else if ( creature is GreySquirrel )
					      {
                                                    from.AddToBackpack( new Apple(3) );
				                    creature.Combatant = from;

                                                    if ( from.Skills.Poisoning.Base >= 50.0 )
                                                    {
					                 creature.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
					                 creature.PlaySound( 0x307 );
                                                         creature.Kill();
                                                    }

					      }
					      else if ( creature is LargeFrog )
					      {
                                                    if ( from.Skills.TasteID.Base >= 50.0 )
                                                    {
					                 from.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
                                                         from.BodyMod = 80;
                                                         from.HueMod = 663;
                                                         from.SendMessage( "You shall forever remain stuck as a large frog until your next death" );
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
					                 creature.Say( "*ribbit!*" );
                                                    }
					      }
					      else if ( creature is LesserAntLion )
					      {
                                                    if ( from.Skills.TasteID.Base >= 50.0 )
                                                    {
					                 from.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
                                                         from.BodyMod = 787;
                                                         from.HueMod = 0;
                                                         from.SendMessage( "You shall forever remain stuck as a lesser antlion until your next death" );
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
                                                    }
					      }
					      else if ( creature is MadPumpkinSpirit )
					      {
                                                    if ( from.Skills.Cooking.Base >= 50.0 )
                                                    {
                                                         from.Skills.Cooking.Base += 0.3;
                                                         creature.Kill();
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
					                 creature.Say( "*Not Appropriate!*" );
                                                    }
					      }
					      else if ( creature is RhinoBeetle )
					      {
                                                    if ( from.Skills.TasteID.Base >= 50.0 )
                                                    {
					                 from.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
                                                         from.BodyMod = 247;
                                                         from.HueMod = 0;
                                                         from.SendMessage( "You shall forever remain stuck as a rhino beetle until your next death" );
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
					                 creature.PlaySound( 0x21D );
					                 creature.Say( "*fresh meat!*" );
                                                    }
					      }
					      else if ( creature is WildTurkey )
					      {
                                                    if ( from.Skills.TasteID.Base >= 50.0 )
                                                    {
					                 from.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
                                                         from.BodyMod = 1026;
                                                         from.HueMod = 0;
                                                         from.SendMessage( "You shall forever remain stuck as a wild turkey until your next death" );
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
                                                    }
					      }
					      else if ( creature is Ogumo )
					      {
                                                    if ( from.Skills.TasteID.Base >= 50.0 )
                                                    {
                                                         creature.Kill();
                                                         from.AddToBackpack( new SpiderPotion() );
                                                         from.SendMessage( "You vanquish thy foe using your dirty mouth. A potion has been added to your pack. Use it wisely." );
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
                                                    }
					      }

////////////////////////////////////////////////////////////// Alytharr Region

					      else if ( creature is SandCrab )
					      {
                                                    if ( from.Skills.TasteID.Base >= 50.0 )
                                                    {
					                 from.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
                                                         from.BodyMod = 357;
                                                         from.HueMod = 1864;
                                                         from.SendMessage( "You shall forever remain stuck as a sand crab until your next death" );
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
                                                    }
					      }

					      else if ( creature is WyvernYoungling )
					      {
                                                    if ( from.Skills.TasteID.Base >= 50.0 )
                                                    {
					                 from.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
                                                         from.BodyMod = 62;
                                                         from.HueMod = 0;
                                                         from.SendMessage( "You shall forever remain stuck as a wyvern until your next death" );
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
                                                    }
					      }

////////////////////////////////////////////////////////////// Autumnwood

					      else if ( creature is Harpy )
					      {
                                                    if ( from.Skills.TasteID.Base >= 50.0 )
                                                    {
					                 from.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
                                                         from.BodyMod = 30;
                                                         from.HueMod = 0;
                                                         from.SendMessage( "You shall forever remain stuck as a harpy until your next death" );
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
                                                    }
					      }

					      else if ( creature is SkitteringHopper )
					      {
                                                    if ( from.Skills.TasteID.Base >= 50.0 )
                                                    {
					                 from.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
                                                         from.BodyMod = 302;
                                                         from.HueMod = 0;
                                                         from.SendMessage( "You shall forever remain stuck as a skittering hopper until your next death" );
                                                         from.Flying = true;
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
                                                    }
					      }

////////////////////////////////////////////////////////////// Glimmerwood

					      else if ( creature is HealerAnt )
					      {
                                                    if ( from.Skills.TasteID.Base >= 50.0 )
                                                    {
		                                         from.Hits += ( Utility.Random( 25, 50 ) ); 
		                                         from.FixedParticles( 0x375A, 1, 30, 9966, 88, 2, EffectLayer.Head ); 
           	                                         from.FixedParticles( 0x37B9, 1, 30, 9502, 85, 3, EffectLayer.Head );
		                                         from.FixedParticles( 0x376A, 1, 31, 9961, 80, 0, EffectLayer.Waist );
           	                                         from.FixedParticles( 0x37C4, 1, 31, 9502, 88, 2, EffectLayer.Waist );
				                         from.PlaySound( 0x202 );
                                                    }
					      }
					      else if ( creature is Parrot )
					      {
		                                    from.PlaySound( from.Female ? 800 : 1072 );
					            from.Say( "*kisses*" );
				                    creature.Combatant = from;

                                                    if ( from.Skills.Poisoning.Base >= 50.0 )
                                                    {
					                 creature.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
					                 creature.PlaySound( 0x307 );
                                                         creature.Kill();
                                                    }
					      }

////////////////////////////////////////////////////////////// Harashi Nabi Desert

					      else if ( creature is OphidianMatriarch )
					      {
                                                    if ( from.Skills.TasteID.Base >= 100.0 )
                                                    {
					                 from.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
                                                         from.BodyMod = 87;
                                                         from.HueMod = 0;
                                                         from.SendMessage( "You shall forever remain stuck as an ophidian matriarch until your next death" );
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
                                                    }
					      }

////////////////////////////////////////////////////////////// Samson Swamplands

					      else if ( creature is AnnoyingLlama1 )
					      {
                                                    if ( from.Skills.AnimalTaming.Base >= 50.0 )
                                                    {
                                                         creature.Delete();
					                 from.PlaySound( from.Female ? 792 : 1064 );
					                 from.Say( "*farts*" );
                                                    }
                                                    else
                                                    {
					                 creature.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
					                 creature.PlaySound( 0x307 );
                                                         creature.Delete();
                                                         from.Skills.AnimalTaming.Base += 1;
					                 from.PlaySound( from.Female ? 811 : 1085 );
					                 from.Say( "*oooh!*" );
                                                    }
					      }
					      else if ( creature is AnnoyingLlama2 )
					      {
                                                    if ( from.Skills.AnimalTaming.Base >= 50.0 )
                                                    {
                                                         creature.Delete();
					                 from.PlaySound( from.Female ? 782 : 1053 );
					                 from.Say( "*burp!*" );
                                                    }
                                                    else
                                                    {
					                 creature.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
					                 creature.PlaySound( 0x307 );
                                                         creature.Delete();
                                                         from.Skills.AnimalTaming.Base += 1;
					                 from.PlaySound( from.Female ? 811 : 1085 );
					                 from.Say( "*oooh!*" );
                                                    }
					      }
					      else if ( creature is AnnoyingLlama3 )
					      {
                                                    if ( from.Skills.AnimalTaming.Base >= 50.0 )
                                                    {
                                                         creature.Delete();
					                 from.PlaySound( from.Female ? 812 : 1086 );
					                 from.Say( "*oops!*" );
                                                    }
                                                    else
                                                    {
					                 creature.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
					                 creature.PlaySound( 0x307 );
                                                         creature.Delete();
					                 from.PlaySound( from.Female ? 811 : 1085 );
					                 from.Say( "*oooh!*" );
                                                         from.Skills.AnimalTaming.Base += 1;
                                                    }
					      }

////////////////////////////////////////////////////////////// Misc Mobiles
					      else if ( creature is Bird )
					      {
                                                    if ( from.Skills.Poisoning.Base >= 50.0 )
                                                    {
					                 creature.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
					                 creature.PlaySound( 0x307 );
                                                         creature.Kill();
                                                    }
					      }
					      else if ( creature is Boar )
					      {
		                                    from.PlaySound( from.Female ? 800 : 1072 );
					            from.Say( "*kisses*" );
				                    creature.Combatant = from;
					      }
					      else if ( creature is Cat )
					      {
                                                    if ( from.Skills.Poisoning.Base >= 50.0 )
                                                    {
					                 creature.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
					                 creature.PlaySound( 0x307 );
                                                         creature.Kill();
                                                    }
					      }
					      else if ( creature is Chicken )
					      {
                                                    if ( from.Skills.TasteID.Base >= 50.0 )
                                                    {
					                 from.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
                                                         from.BodyMod = 0xD0;
                                                         from.HueMod = 0;
                                                         from.SendMessage( "You shall forever remain stuck as a chicken until your next death" );
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
					                 creature.Say( "*bawk! bawk!*" );
                                                    }
					      }
					      else if ( creature is PoisonArrowFrog )
					      {
                                                    if ( from.Skills.Poisoning.Base >= 80.0 )
                                                    {
		                                         from.ApplyPoison( from, Poison.Lesser );
                                                         from.SendMessage( "You've become too corrosive even for this toxic frog to handle." );
                                                    }
                                                    else
                                                    {
		                                         from.ApplyPoison( from, Poison.Lethal );
                                                         from.Skills.Poisoning.Base += 1;
                                                         creature.Kill();
                                                    }
					      }
					      else if ( creature is Pookah )
					      {
                                                    if ( from.Skills.Meditation.Base >= 50.0 )
                                                    {
                                                         from.Location = new Point3D( 364, 733, -20 ); // Glimmerwood Entrance
			                                 from.PlaySound( 0x1FC );
                                                         from.SendMessage( "You've been teleported to the entrance." );
                                                    }
                                                    else
                                                    {
				                         creature.Combatant = from;
                                                    }
					      }
					      else if ( creature is BaseGuardian )
					      {
		                                    from.PlaySound( from.Female ? 800 : 1072 );
					            from.Say( "*kisses*" );
				                    creature.Combatant = from;
                                                    creature.Say("Not gonna put up with that nonsense!");
					      }
					      else if ( creature is BaseVendor )
					      {
		                                    from.PlaySound( from.Female ? 800 : 1072 );
					            from.Say( "*kisses*" );
                                                    from.Karma = -100;
                                                    from.SendMessage( "You've lost some karma." );
				                    creature.Say( "Faulk off {0}", from.Name );
					      }
                                        }
				}
				else if ( targeted is PlayerMobile )
				{
					PlayerMobile playermobile = (PlayerMobile) targeted;

					if ( from.CheckTargetSkill( SkillName.TasteID, playermobile, 0, 100.0 ) )
					{
                                                if ( playermobile.Female == false )
                                                {
		                                        from.PlaySound( from.Female ? 800 : 1072 );
					                from.Say( "*kisses*" );
                                                        from.Karma = -100;
                                                        from.SendMessage( "You've lost some karma." );
                                                }
                                                else if ( playermobile.Female == true )
                                                {
		                                        from.PlaySound( from.Female ? 800 : 1072 );
					                from.Say( "*kisses*" );
                                                        from.Karma = -100;
                                                        from.SendMessage( "You've lost some karma." );
                                                }
                                        }
				}
				else if ( targeted is Food )
				{
					Food food = (Food) targeted;

					if ( from.CheckTargetSkill( SkillName.TasteID, food, 0, 100 ) )
					{
						if ( food.Poison != null )
						{
							food.SendLocalizedMessageTo( from, 1038284 ); // It appears to have poison smeared on it.
						}
						else
						{
							// No poison on the food
							food.SendLocalizedMessageTo( from, 1010600 ); // You detect nothing unusual about this substance.
						}
					}
////////////////////////////////////////////////////////////// Fruits
					else if ( food is Apple )
					{
					        if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
					        {
                                                        from.SendMessage( "This apple appears rich in nutrients and has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This apple appears rich in nutrients and has a fill factor of 1." );
						}
					}
					else if ( food is Bananas )
					{
					        if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
					        {
                                                        from.SendMessage( "These bananas make for a great breakfast and have a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "These bananas make for a great breakfast and have a fill factor of 1." );
						}
					}
					else if ( food is Cantaloupe )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This cantaloupe is as big as yo mommas biscuits and has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This cantaloupe is as big as yo mommas biscuits and has a fill factor of 1." );
						}
					}
					else if ( food is Coconut )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This coconut may have been originally carried by a swallow of sorts and has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This coconut may have been originally carried by a swallow of sorts and has a fill factor of 1." );
						}
					}
					else if ( food is Dates )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "These dates are a delicacy among Ljosalfar high class officials and have a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "These dates are a delicacy among Ljosalfar high class officials and have a fill factor of 1." );
						}
					}
					else if ( food is FruitBasket )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This fruit basket is one of a kind and has a fill factor of 5." );
						}
						else
						{
                                                        from.SendMessage( "This fruit basket is one of a kind and has a fill factor of 5." );
						}
					}
					else if ( food is FruitBowl )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This fruit bowl, the fruit baskets retarded cousin has a fill factor of 4. You're Welcome." );
						}
						else
						{
                                                        from.SendMessage( "This fruit bowl, the fruit baskets retarded cousin has a fill factor of 4. You're Welcome." );
						}
					}
					else if ( food is Grapes )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "These grapes are as violet as they come and have a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "These grapes are as violet as they come and have a fill factor of 1." );
						}
					}
					else if ( food is HoneydewMelon )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This melon is sometimes cherished by certain arachnids and has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This melon is sometimes cherished by certain arachnids and has a fill factor of 1." );
						}
					}
					else if ( food is Lemon )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This lemon is not without its renowned sour touch and has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This lemon is not without its renowned sour touch and has a fill factor of 1." );
						}
					}
					else if ( food is Lime )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This lime, normally considered the green bastard reject of the lemon and has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This lime, normally considered the green bastard reject of the lemon and has a fill factor of 1." );
						}
					}
					else if ( food is Peach )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This peach has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This peach has a fill factor of 1." );
						}
					}
					else if ( food is PeachCobbler )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This peach cobbler has a fill factor of 5." );
						}
						else
						{
                                                        from.SendMessage( "This peach cobbler has a fill factor of 5." );
						}
					}
					else if ( food is Pear )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This pear has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This pear has a fill factor of 1." );
						}
					}
					else if ( food is SmallWatermelon )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This small watermelon has a fill factor of 3." );
						}
						else
						{
                                                        from.SendMessage( "This small watermelon has a fill factor of 3." );
						}
					}
					else if ( food is SplitCoconut )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This split coconut has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This split coconut has a fill factor of 1." );
						}
					}
					else if ( food is Squash )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This squash has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This squash has a fill factor of 1." );
						}
					}
					else if ( food is Watermelon )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This watermelon has a fill factor of 5." );
						}
						else
						{
                                                        from.SendMessage( "This watermelon has a fill factor of 5." );
						}
					}
////////////////////////////////////////////////////////////// Vegetables
					else if ( food is Cabbage )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This cabbage has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This cabbage has a fill factor of 1." );
						}
					}
					else if ( food is Carrot )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This carrot has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This carrot has a fill factor of 1." );
						}
					}
					else if ( food is EarOfCorn )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This ear of corn has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This ear of corn has a fill factor of 1." );
						}
					}
					else if ( food is GreenGourd )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This green gourd has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This green gourd has a fill factor of 1." );
						}
					}
					else if ( food is Lettuce )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This head of lettuce has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This head of lettuce has a fill factor of 1." );
						}
					}
					else if ( food is Onion )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This onion is full of layers, like an ogre and has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This onion is full of layers, like an ogre and has a fill factor of 1." );
						}
					}
					else if ( food is Pumpkin )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This pumpkin has a fill factor of 8." );
						}
						else
						{
                                                        from.SendMessage( "This pumpkin has a fill factor of 8." );
						}
					}
					else if ( food is Quiche )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This quiche has a fill factor of 5." );
						}
						else
						{
                                                        from.SendMessage( "This quiche has a fill factor of 5." );
						}
					}
					else if ( food is SmallPumpkin )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This small pumpkin has a fill factor of 6." );
						}
						else
						{
                                                        from.SendMessage( "This small pumpkin has a fill factor of 6." );
						}
					}
					else if ( food is Turnip )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This turnip has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This turnip has a fill factor of 1." );
						}
					}
					else if ( food is YellowGourd )
					{
						if ( from.CheckTargetSkill( SkillName.TasteID, food, 0.0, 100.0 ) )
						{
                                                        from.SendMessage( "This yellow gourd has a fill factor of 1." );
						}
						else
						{
                                                        from.SendMessage( "This yellow gourd has a fill factor of 1." );
						}
					}
					else
					{
						// Skill check failed
						food.SendLocalizedMessageTo( from, 502823 ); // You cannot discern anything about this substance.
					}
				}
				else if ( targeted is BasePotion )
				{
					BasePotion potion = (BasePotion) targeted;

					potion.SendLocalizedMessageTo( from, 502813 ); // You already know what kind of potion that is.
					potion.SendLocalizedMessageTo( from, potion.LabelNumber );
				}
				else if ( targeted is PotionKeg )
				{
					PotionKeg keg = (PotionKeg) targeted;

					if ( keg.Held <= 0 )
					{
						keg.SendLocalizedMessageTo( from, 502228 ); // There is nothing in the keg to taste!
					}
					else
					{
						keg.SendLocalizedMessageTo( from, 502229 ); // You are already familiar with this keg's contents.
						keg.SendLocalizedMessageTo( from, keg.LabelNumber );
					}
				}
				else if ( targeted is DecoHorseDung )
				{
					DecoHorseDung horsedung = (DecoHorseDung) targeted;

                                        from.RawInt -= 1;
                                        from.Fame -= 5000;
                                        from.Karma -= 5000;

			                if ( 0.05 > Utility.RandomDouble() )
                                        {
                                             from.RawInt -= 1;
                                             from.Fame -= 10000;
                                             from.Karma -= 10000;
                                             from.Kill();
                                        }
					else if ( from.RawInt <= 1 )
                                        {
                                             from.Delete();
                                             World.Broadcast( 0x35, true, string.Format( "{0} was permanently killed off due to being a colossal scathead!", from.Name ) );
                                        }
				}
				else if ( targeted is BaseWeapon )
				{
					BaseWeapon weapon = (BaseWeapon) targeted;

					if ( from.CheckTargetSkill( SkillName.TasteID, weapon, 0.0, 100.0 ) )
					{
					           if ( weapon is BaseAxe )
					           {
		                                          from.PlaySound( from.Female ? 814 : 1088 );
	                                                  AOS.Damage(from, 0, 0, 0, 0, 0, 0 );
		                                          from.Hits -= ( Utility.Random( 1, 10 ) ); 

					                  if ( from.Hits <= 10 )
                                                          {
                                                                 from.Kill();
                                                          }
					           }
					           else if ( weapon is BaseBashing )
					           {
		                                          from.PlaySound( from.Female ? 814 : 1088 );
	                                                  AOS.Damage(from, 0, 0, 0, 0, 0, 0 );
		                                          from.Hits -= ( Utility.Random( 1, 10 ) ); 

					                  if ( from.Hits <= 10 )
                                                          {
                                                                 from.Kill();
                                                          }
					           }
					           else if ( weapon is BaseKnife )
					           {
		                                          from.PlaySound( from.Female ? 814 : 1088 );
	                                                  AOS.Damage(from, 0, 0, 0, 0, 0, 0 );
		                                          from.Hits -= ( Utility.Random( 1, 10 ) ); 

					                  if ( from.Hits <= 10 )
                                                          {
                                                                 from.Kill();
                                                          }
					           }
					           else if ( weapon is BasePoleArm )
					           {
		                                          from.PlaySound( from.Female ? 814 : 1088 );
	                                                  AOS.Damage(from, 0, 0, 0, 0, 0, 0 );
		                                          from.Hits -= ( Utility.Random( 1, 15 ) ); 

					                  if ( from.Hits <= 10 )
                                                          {
                                                                 from.Kill();
                                                          }
					           }
					           else if ( weapon is BaseSpear )
					           {
		                                          from.PlaySound( from.Female ? 814 : 1088 );
	                                                  AOS.Damage(from, 0, 0, 0, 0, 0, 0 );
		                                          from.Hits -= ( Utility.Random( 1, 10 ) ); 

					                  if ( from.Hits <= 10 )
                                                          {
                                                                 from.Kill();
                                                          }
					           }
					           else if ( weapon is BaseStaff )
					           {
		                                          from.PlaySound( from.Female ? 814 : 1088 );
	                                                  AOS.Damage(from, 0, 0, 0, 0, 0, 0 );
		                                          from.Hits -= ( Utility.Random( 1, 10 ) ); 

					                  if ( from.Hits <= 10 )
                                                          {
                                                                 from.Kill();
                                                          }
					           }
					           else if ( weapon is BaseSword )
					           {
		                                          from.PlaySound( from.Female ? 814 : 1088 );
	                                                  AOS.Damage(from, 0, 0, 0, 0, 0, 0 );
		                                          from.Hits -= ( Utility.Random( 1, 10 ) ); 

					                  if ( from.Hits <= 10 )
                                                          {
                                                                 from.Kill();
                                                          }

                                                   }
					}
                                }
				else
				{
					// The target is not food or potion or potion keg.
					from.SendLocalizedMessage( 502820 ); // That's not something you can taste.
				}
			}

			protected override void OnTargetOutOfRange( Mobile from, object targeted )
			{
				from.SendLocalizedMessage( 502815 ); // You are too far away to taste that.
			}
		}
	}
}