using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Fourth;
using Server.Targeting;

namespace Server.Mobiles
{
	public class AlhaniaTheAnimalCollector : BaseSpecialCreature
	{
		public override bool InitialInnocent{ get{ return true; } }

                public override bool DoesTripleBolting { get { return true; } }
                public override double TripleBoltingChance { get { return 0.250; } }

                public override bool DoesEarthquaking { get { return true; } }
                public override double EarthquakingChance { get { return 0.250; } }

		[Constructable]
		public AlhaniaTheAnimalCollector() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Alhania";
			Title = "the animal collector"; 
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 1002;
                        HairItemID = 12238;
                        HairHue = 1141;

			SetStr( 157 );
			SetDex( 91 );
			SetInt( 268 );

			SetHits( 500 );
			SetMana( 1000 );

			SetDamage( 25, 30 );

			SetSkill( SkillName.AnimalLore, 55.0, 78.0 );
			SetSkill( SkillName.AnimalTaming, 55.0, 78.0 );
			SetSkill( SkillName.EvalInt, 95.5, 125.0 );
			SetSkill( SkillName.Herding, 64.0, 100.0 );
			SetSkill( SkillName.Magery, 99.5, 125.0 );
			SetSkill( SkillName.MagicResist, 95.5, 100.0 );
			SetSkill( SkillName.Meditation, 95.5, 100.0 );
			SetSkill( SkillName.Veterinary, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 95.5, 100.0 );

			Karma = 5000;

			PackGold( 51, 98 );

			AddItem( new Cloak(623) );
			AddItem( new VictorianDress(783) );
			AddItem( new HighBoots(868) );

			GlacialStaff weapon = new GlacialStaff();
			weapon.Movable = false;
			AddItem( weapon );

			switch ( Utility.Random( 18 ))
			{
				case 0: PackItem( new Amethyst() ); break;
				case 1: PackItem( new Garnet() ); break;
				case 2: PackItem( new Jade() ); break;
				case 3: PackItem( new Morganite() ); break;
				case 4: PackItem( new Paraiba() ); break;
				case 5: PackItem( new TigerEye() ); break;
				case 6: PackItem( new Alexandrite() ); break;
				case 7: PackItem( new Ametrine() ); break;
				case 8: PackItem( new Kunzite() ); break;
				case 9: PackItem( new Ruby() ); break;
				case 10: PackItem( new Sapphire() ); break;
				case 11: PackItem( new Tanzanite() ); break;
				case 12: PackItem( new Topaz() ); break;
				case 13: PackItem( new Zultanite() ); break;
				case 14: PackItem( new Diamond() ); break;
				case 15: PackItem( new Emerald() ); break;
				case 16: PackItem( new PinkQuartz() ); break;
				case 17: PackItem( new StarSapphire() ); break;
			}
                }

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new AlhaniaTheAnimalCollectorEntry( from, this ) );
		}

		public class AlhaniaTheAnimalCollectorEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public AlhaniaTheAnimalCollectorEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}
			
			public override void OnClick()
			{
				if( !( m_Mobile is PlayerMobile ) )
					return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				
				{
					if ( ! mobile.HasGump( typeof( AlhaniaTheAnimalCollectorGump ) ) )
					{
						mobile.SendGump( new AlhaniaTheAnimalCollectorGump( mobile ));
						
					}
				}
			}
		}

                private class PetSaleTarget : Target 
                { 
                      private AlhaniaTheAnimalCollector m_Trainer; 

                      public PetSaleTarget( AlhaniaTheAnimalCollector trainer ) : base( 12, false, TargetFlags.None ) 
                      { 
                            m_Trainer = trainer; 
                      } 

                      protected override void OnTarget( Mobile from, object targeted ) 
                      { 
                          if ( targeted is BaseCreature ) 
                             m_Trainer.EndPetSale( from, (BaseCreature)targeted ); 
                          else if ( targeted == from ) 
                             m_Trainer.SayTo( from, 502672 ); // HA HA HA! Sorry, I am not an inn. 
                      } 
               } 

               public void BeginPetSale( Mobile from ) 
               { 
                    if ( Deleted || !from.CheckAlive() ) 
                       return; 

                       SayTo( from, "Which animal from this continent are you selling?" ); 

                       from.Target = new PetSaleTarget( this ); 
               } 

	       //RUFO beginfunction
	       private void SellPetForGold(Mobile from, BaseCreature pet, int goldamount)
	       {
               		Item gold = new Gold(goldamount);
               		pet.ControlTarget = null; 
               		pet.ControlOrder = OrderType.None; 
               		pet.Internalize(); 
               		pet.SetControlMaster( null ); 
               		pet.SummonMaster = null;
               		pet.Delete();
               		
               		Container backpack = from.Backpack;
               		if ( backpack == null || !backpack.TryDropItem( from, gold, false ) ) 
            		{ 
            			gold.MoveToWorld( from.Location, from.Map );
            		}

	       }
	       //RUFO endfunction

               public void EndPetSale( Mobile from, BaseCreature pet ) 
               { 

               if ( Deleted || !from.CheckAlive() ) 
                   return;
            
               if ( !pet.Controlled || pet.ControlMaster != from ) 
		      SayTo( from, 1042562 ); // You do not own that pet! 
	           else if ( pet.IsDeadPet ) 
		      SayTo( from, 1049668 ); // Living pets only, please. 
	           else if ( pet.Summoned ) 
		      SayTo( from, 502673 ); // I can not PetSale summoned creatures. 
	           else if ( pet.Body.IsHuman ) 
		      SayTo( from, 502672 ); // HA HA HA! Sorry, I am not an inn.
	           else if ( pet.Combatant != null && pet.InRange( pet.Combatant, 12 ) && pet.Map == pet.Combatant.Map ) 
                      SayTo( from, 1042564 ); // I'm sorry.  Your pet seems to be busy. 
	           else 
                   {
///////////////////////////////////////////////// Alytharr Region
                 if ( pet is AlytharrForestHart )
                 {
			SellPetForGold(from, pet, 390);
                 }
                 else if ( pet is AlytharrGrassSnake )
                 {
			SellPetForGold(from, pet, 315);
                 }
                 else if ( pet is BeachBeetle )
                 {
			SellPetForGold(from, pet, 242);
                 }
                 else if ( pet is BlackLizard )
                 {
			SellPetForGold(from, pet, 360);
                 }
                 else if ( pet is HillToad )
                 {
			SellPetForGold(from, pet, 281);
                 }
                 else if ( pet is SandCrab )
                 {
			SellPetForGold(from, pet, 208);
                 }
                 else if ( pet is WyvernYoungling )
                 {
			SellPetForGold(from, pet, 399);
                 }
///////////////////////////////////////////////// Autumnwood
		 else if (pet is OakwoodSnarlerPup )
                 {
			SellPetForGold(from, pet, 300);
                 }
		 else if (pet is RazorbackRaptor )
                 {
			SellPetForGold(from, pet, 325);
                 }
		 else if (pet is SkitteringHopper )
                 {
			SellPetForGold(from, pet, 129);
                 }
///////////////////////////////////////////////// Bog of Toads
		 else if (pet is DarkRose )
                 {
			SellPetForGold(from, pet, 320);
                 }
		 else if (pet is PoisonArrowFrog )
                 {
			SellPetForGold(from, pet, 455);
                 }
///////////////////////////////////////////////// Dragonstorm Island
		 else if (pet is Dragon )
                 {
			SellPetForGold(from, pet, 5000);
                 }
///////////////////////////////////////////////// Glimmerwood
		 else if (pet is AntLion )
                 {
			SellPetForGold(from, pet, 699);
                 }
		 else if (pet is Gryphon )
                 {
			SellPetForGold(from, pet, 295);
                 }
		 else if (pet is Parrot )
                 {
			SellPetForGold(from, pet, 150);
                 }
		 else if (pet is Ridgeback )
                 {
			SellPetForGold(from, pet, 291);
                 }
		 else if (pet is SavageRidgeback )
                 {
			SellPetForGold(from, pet, 351);
                 }
///////////////////////////////////////////////// Harashi Nabi
		 else if (pet is BulletAnt )
                 {
			SellPetForGold(from, pet, 312);
                 }
		 else if (pet is DesertOstard )
                 {
			SellPetForGold(from, pet, 291);
                 }
		 else if (pet is GiantTurtle )
                 {
			SellPetForGold(from, pet, 364);
                 }
		 else if (pet is HellCat )
                 {
			SellPetForGold(from, pet, 411);
                 }
		 else if (pet is Jubokko )
                 {
			SellPetForGold(from, pet, 320);
                 }
		 else if (pet is Lion )
                 {
			SellPetForGold(from, pet, 766);
                 }
		 else if (pet is SandBarracuda )
                 {
			SellPetForGold(from, pet, 355);
                 }
		 else if (pet is SandStreaker )
                 {
			SellPetForGold(from, pet, 89);
                 }
		 else if (pet is Scorpion )
                 {
			SellPetForGold(from, pet, 471);
                 }
		 else if (pet is Zebra )
                 {
			SellPetForGold(from, pet, 500);
                 }
///////////////////////////////////////////////// Oboru Jungle
		 else if (pet is DaiOgumo )
                 {
			SellPetForGold(from, pet, 395);
                 }
		 else if (pet is Yatsukahag )
                 {
			SellPetForGold(from, pet, 229);
                 }
///////////////////////////////////////////////// Samson Swamplands
		 else if (pet is Allosaur )
                 {
			SellPetForGold(from, pet, 4500);
                 }
		 else if (pet is ForestDragon )
                 {
			SellPetForGold(from, pet, 5000);
                 }
		 else if (pet is Grachiosaur )
                 {
			SellPetForGold(from, pet, 3500);
                 }
		 else if (pet is WaterBeetle )
                 {
			SellPetForGold(from, pet, 379);
                 }
///////////////////////////////////////////////// Star Lake
		 else if (pet is StarLakeCrab )
                 {
			SellPetForGold(from, pet, 208);
                 }
///////////////////////////////////////////////// Zaythalor Forest
                 else if ( pet is BlackAntZaythalorForest )
                 {
			SellPetForGold(from, pet, 50);
                 }
		 else if (pet is ForestBat )
                 {
			SellPetForGold(from, pet, 100);
                 }
		 else if (pet is Gizzard )
                 {
			SellPetForGold(from, pet, 50);
                 }
		 else if (pet is GreenSlime )
                 {
			SellPetForGold(from, pet, 50);
                 }
		 else if (pet is GreySquirrel )
                 {
			SellPetForGold(from, pet, 20);
                 }
		 else if (pet is GreyWolfPup )
                 {
			SellPetForGold(from, pet, 150);
                 }
		 else if (pet is LargeFrog )
                 {
			SellPetForGold(from, pet, 100);
                 }
		 else if (pet is LesserAntLion )
                 {
			SellPetForGold(from, pet, 150);
                 }
		 else if (pet is Ogumo )
                 {
			SellPetForGold(from, pet, 100);
                 }
		 else if (pet is RhinoBeetle )
                 {
			SellPetForGold(from, pet, 250);
                 }
		 else if (pet is WaterLizard )
                 {
			SellPetForGold(from, pet, 350);
                 }
		 else if (pet is YoungAlligator )
                 {
			SellPetForGold(from, pet, 150);
                 }
		 else if (pet is WildTurkey )
                 {
			SellPetForGold(from, pet, 300);
                 }
///////////////////////////////////////////////// Skaddria Naddheim
		 else if (pet is Chakla )
                 {
			SellPetForGold(from, pet, 45);
                 }
		 else if (pet is Cinnamologus )
                 {
			SellPetForGold(from, pet, 25);
                 }
		 else if (pet is Dobharchu )
                 {
			SellPetForGold(from, pet, 50);
                 }
		 else if (pet is Shachihoko )
                 {
			SellPetForGold(from, pet, 500);
                 }
		 else if (pet is SilverbackGorilla )
                 {
			SellPetForGold(from, pet, 50);
                 }
		 else if (pet is Taniwha )
                 {
			SellPetForGold(from, pet, 200);
                 }
		 else if (pet is Waitoreke )
                 {
			SellPetForGold(from, pet, 25);
                 }
///////////////////////////////////////////////// Misc
		 else if (pet is Bird )
                 {
			SellPetForGold(from, pet, 20);
                 }
		 else if (pet is BlackBear )
                 {
			SellPetForGold(from, pet, 350);
                 }
		 else if (pet is Boar )
                 {
			SellPetForGold(from, pet, 300);
                 }
		 else if (pet is Bull )
                 {
			SellPetForGold(from, pet, 300);
                 }
		 else if (pet is BullFrog )
                 {
			SellPetForGold(from, pet, 250);
                 }
		 else if (pet is Chicken )
                 {
			SellPetForGold(from, pet, 20);
                 }
		 else if (pet is Cougar )
                 {
			SellPetForGold(from, pet, 450);
                 }
		 else if (pet is Cow )
                 {
			SellPetForGold(from, pet, 150);
                 }
		 else if (pet is Eagle )
                 {
			SellPetForGold(from, pet, 200);
                 }
		 else if (pet is GreatHart )
                 {
			SellPetForGold(from, pet, 500);
                 }
		 else if (pet is Hind )
                 {
			SellPetForGold(from, pet, 250);
                 }
		 else if (pet is Horse )
                 {
			SellPetForGold(from, pet, 500);
                 }
		 else if (pet is Mongbat )
                 {
			SellPetForGold(from, pet, 20);
                 }
		 else if (pet is MountainGoat )
                 {
			SellPetForGold(from, pet, 20);
                 }
		 else if (pet is Pig )
                 {
			SellPetForGold(from, pet, 150);
                 }
		 else if (pet is Rabbit )
                 {
			SellPetForGold(from, pet, 20);
                 }
		 else if (pet is Rat )
                 {
			SellPetForGold(from, pet, 20);
                 }
		 else if (pet is Sheep )
                 {
			SellPetForGold(from, pet, 150);
                 }
		 else if (pet is TimberWolf )
                 {
			SellPetForGold(from, pet, 250);
                 }
            	 else 
	            	 SayTo( from, "I dont want that Beast, go away" ); // You can't PetSale that!
                 }
               }

 	        public override bool HandlesOnSpeech( Mobile from )
	        {
		           return true;
	        }

                public override void OnSpeech( SpeechEventArgs e ) 
                { 
      	               if ( ( e.Speech.ToLower() == "sell" ) )//was sellpet
	               {
      		             BeginPetSale( e.Mobile );
                       }
                       else 
                       { 
                             base.OnSpeech( e ); 
                       } 
                } 

		public override void OnGotMeleeAttack( Mobile attacker )
		{
	              base.OnGotMeleeAttack( attacker );

                      Mobile target = attacker;

                      if( target is BaseCreature && ((BaseCreature)target).Controlled )
                      target = ((BaseCreature)target).ControlMaster;

                      if( target == null )
                      target = attacker;

                      if( DoesTripleBolting && TripleBoltingChance >= Utility.RandomDouble() )
                      TripleBolt( target );
		}

                public override void OnDamagedBySpell( Mobile attacker )
                {
                      base.OnDamagedBySpell( attacker );

                      Mobile target = attacker;

                      if( target is BaseCreature && ((BaseCreature)target).Controlled )
                      target = ((BaseCreature)target).ControlMaster;

                      if( target == null )
                      target = attacker;

                      if( DoesTripleBolting && TripleBoltingChance >= Utility.RandomDouble() )
                      TripleBolt( target );
                }

		public override bool OnBeforeDeath()
		{
                    if (Combatant is PlayerMobile)
			Ability.FlameWave( Combatant );

                        return base.OnBeforeDeath();
		}

		public AlhaniaTheAnimalCollector( Serial serial ) : base( serial )
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
