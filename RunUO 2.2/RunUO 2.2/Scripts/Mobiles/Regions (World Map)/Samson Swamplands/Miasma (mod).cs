using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a Miasma corpse" )]
	public class Miasma : BaseCreature
	{
		public override bool CanTeach{ get{ return true; } }

		public override bool CheckTeach( SkillName skill, Mobile from )
		{
		        PlayerMobile pm = from as PlayerMobile;

			if ( !base.CheckTeach( skill, from ) )
				return false;

			return ( skill == SkillName.Ninjitsu )
				|| ( skill == SkillName.Poisoning )
				|| ( skill == SkillName.Tactics )
				|| ( skill == SkillName.Wrestling );
		}

		[Constructable]
		public Miasma() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.3, 0.6 )
		{
			Name = "Miasma";
			Body = 48;
			Hue = 0x8FD;
			BaseSoundID = 397;

			SetStr( 255, 277 );
			SetDex( 145, 428 );
			SetInt( 250, 380 );

			SetHits( 250, 300 );

			SetDamage( 35, 50 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 40 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 70 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.MagicResist, 50.1, 54.9 );
			SetSkill( SkillName.Ninjitsu, 83.4, 99.1 );
			SetSkill( SkillName.Poisoning, 128.5, 143.6 );
			SetSkill( SkillName.Tactics, 98.4, 110.6 );
			SetSkill( SkillName.Wrestling, 84.9, 103.3 );

			Fame = 10000;
			Karma = -10000;

			PackGold( 75, 97 );
			PackReg( 15, 25 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new PoisonScroll() );

			PackItem( new GreaterCurePotion() );

		}

		public override bool IsScaryToPets{ get{ return true; } }
		public override bool AutoDispel{ get{ return true; } }
		public override bool BardImmune{ get{ return true; } }
		public override bool Unprovokable{ get{ return true; } }
		public override bool AreaPeaceImmune { get{ return true; } }

		public override double WeaponAbilityChance { get { return 0.75; } }
		public override double HitPoisonChance { get { return 0.35; } }
		public override Poison HitPoison { get { return ( Poison.Lethal ); } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 4 );
			AddLoot( LootPack.UltraRich );
		}

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.MortalStrike;
		}

		public override bool IsEnemy( Mobile m )
		{
		        PlayerMobile pm = m as PlayerMobile;

			if ( m is PlayerMobile )
				return false;

                        if (m is BaseFastEnemy || m is BaseVendor || m is PlayerVendor || m is TownCrier || m is BaseGuardian || m is BaseSpecialCreature )
				return false;

			if ( m is BaseCreature )
			{
				BaseCreature c = (BaseCreature)m;

				if( c.Controlled || c.FightMode == FightMode.Aggressor || c.FightMode == FightMode.Closest || c.FightMode == FightMode.None )

					return false;
			}

			return true;
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new MiasmaEntry( from, this ) );
		}

		public class MiasmaEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public MiasmaEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( MiasmaGump ) ) )
					{
					       mobile.SendGump( new MiasmaGump( mobile ));	
                                        }
				}
			}
                }

                private class PetSaleTarget : Target 
                { 
                      private Miasma m_Trainer; 

                      public PetSaleTarget( Miasma trainer ) : base( 12, false, TargetFlags.None ) 
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
		       PlayerMobile pm = e.Mobile as PlayerMobile;
                       return;

      	               if ( ( e.Speech.ToLower() == "sell" ) )//was sellpet
	               {
      		             BeginPetSale( e.Mobile );
                       }
                       else 
                       { 
                             base.OnSpeech( e ); 
                       } 
                } 

		public Miasma( Serial serial ) : base( serial )
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

                public class MiasmaGump : Gump 
                { 

                public static void Initialize() 
                { 
                     CommandSystem.Register( "MiasmaGump", AccessLevel.GameMaster, new CommandEventHandler( MiasmaGump_OnCommand ) ); 
                } 

                private static void MiasmaGump_OnCommand( CommandEventArgs e ) 
                { 
                     e.Mobile.SendGump( new MiasmaGump( e.Mobile ) ); 
                } 

                public MiasmaGump( Mobile owner ) : base( 50,50 ) 
                { 
//----------------------------------------------------------------------------------------------------
			this.AddPage(0);
			this.AddBackground(126, 131, 398, 389, 9270);
			this.AddAlphaRegion(130, 132, 391, 389);
			this.AddImage(110, 460, 10464);
			this.AddImage(536, 214, 9265);
			this.AddImage(507, 460, 10464);
			this.AddImage(507, 408, 10464);
			this.AddImage(110, 193, 10464);
			this.AddImage(110, 247, 10464);
			this.AddImage(110, 301, 10464);
			this.AddImage(110, 354, 10464);
			this.AddImage(110, 408, 10464);
			this.AddImage(110, 139, 10464);
			this.AddImage(93, 197, 9263);
			this.AddImage(59, 124, 10421);
			this.AddImage(88, 110, 10420);
			this.AddImage(107, 246, 10411);
			this.AddImage(43, 399, 10402);
			this.AddImage(93, 513, 10103);
			this.AddImage(109, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(218, 513, 10100);
			this.AddImage(202, 513, 10100);
			this.AddImage(124, 513, 10100);
			this.AddImage(172, 513, 10100);
			this.AddImage(156, 513, 10100);
			this.AddImage(140, 513, 10100);
			this.AddImage(188, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(249, 513, 10100);
			this.AddImage(264, 513, 10100);
			this.AddImage(218, 513, 10100);
			this.AddImage(308, 513, 10100);
			this.AddImage(172, 513, 10100);
			this.AddImage(292, 513, 10100);
			this.AddImage(188, 513, 10100);
			this.AddImage(277, 513, 10100);
			this.AddImage(339, 513, 10100);
			this.AddImage(324, 513, 10100);
			this.AddImage(415, 513, 10100);
			this.AddImage(399, 513, 10100);
			this.AddImage(354, 513, 10100);
			this.AddImage(368, 123, 10100);
			this.AddImage(385, 513, 10100);
			this.AddImage(445, 513, 10100);
			this.AddImage(430, 513, 10100);
			this.AddImage(521, 513, 10100);
			this.AddImage(505, 513, 10100);
			this.AddImage(460, 513, 10100);
			this.AddImage(476, 513, 10100);
			this.AddImage(491, 513, 10100);
			this.AddImage(156, 123, 10100);
			this.AddImage(140, 123, 10100);
			this.AddImage(232, 123, 10100);
			this.AddImage(216, 123, 10100);
			this.AddImage(171, 123, 10100);
			this.AddImage(187, 123, 10100);
			this.AddImage(202, 123, 10100);
			this.AddImage(339, 513, 10100);
			this.AddImage(324, 513, 10100);
			this.AddImage(415, 513, 10100);
			this.AddImage(399, 513, 10100);
			this.AddImage(353, 123, 10100);
			this.AddImage(369, 513, 10100);
			this.AddImage(385, 513, 10100);
			this.AddImage(263, 123, 10100);
			this.AddImage(248, 123, 10100);
			this.AddImage(339, 123, 10100);
			this.AddImage(323, 123, 10100);
			this.AddImage(278, 123, 10100);
			this.AddImage(294, 123, 10100);
			this.AddImage(309, 123, 10100);
			this.AddImage(398, 123, 10100);
			this.AddImage(383, 123, 10100);
			this.AddImage(474, 123, 10100);
			this.AddImage(458, 123, 10100);
			this.AddImage(413, 123, 10100);
			this.AddImage(429, 123, 10100);
			this.AddImage(444, 123, 10100);
			this.AddImage(505, 123, 10100);
			this.AddImage(489, 123, 10100);
			this.AddImage(521, 123, 10100);
			this.AddImage(507, 193, 10464);
			this.AddImage(507, 139, 10464);
			this.AddImage(507, 354, 10464);
			this.AddImage(507, 299, 10464);
			this.AddImage(507, 247, 10464);
			this.AddImage(523, 254, 10411);
			this.AddImage(532, 130, 10431);
			this.AddImage(500, 112, 10430);
			this.AddImage(535, 513, 10105);
			this.AddImage(520, 417, 10412);
			this.AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 );
			this.AddHtml( 157, 181, 345, 279, "Tell you what. For the right price I'll teach you some skills and in addition will even buy some pets off of you.<BR><BR>Do we have a deal or not?", false, true);

//----------------------------------------------------------------------------------------------------
		}

                public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 

                { 
                    Mobile from = state.Mobile; 

                    switch ( info.ButtonID ) 
                { 

                case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
                { 
                    //Cancel 
                    break; 
                } 
            }
        }
    }
}