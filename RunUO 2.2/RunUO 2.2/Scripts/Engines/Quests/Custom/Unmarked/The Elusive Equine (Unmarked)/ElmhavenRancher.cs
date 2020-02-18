using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class ElmhavenRancher : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public ElmhavenRancher() : base( "the rancher" )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBElmhavenRancher() );
		}

		public override void InitOutfit()
		{
			Name = "Karina";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33784;
                        HairItemID = 8253;
                        HairHue = 1126;

			SetSkill( SkillName.AnimalLore, 55.0, 78.0 );
			SetSkill( SkillName.AnimalTaming, 55.0, 78.0 );
			SetSkill( SkillName.Herding, 64.0, 100.0 );
			SetSkill( SkillName.Veterinary, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 65.0, 70.0 );

			SetStr( 185 );
			SetDex( 70 );
			SetInt( 69 );

			PackGold( 13, 27 );

			AddItem( new StrawHat(46) );
			AddItem( new FancyTunic(923) );
			AddItem( new HeavyBoots(1055) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 738;
			gloves.Movable = true;
			AddItem( gloves );
                }

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenRancherEntry( from, this ) );
		}

		public class ElmhavenRancherEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenRancherEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( TheElusiveEquineGump ) ) )
					{
						mobile.SendGump( new TheElusiveEquineGump( mobile ));
						
					}
				}
			}
		}

      private class PetSaleTarget : Target 
      { 
         private ElmhavenRancher m_Trainer; 

         public PetSaleTarget( ElmhavenRancher trainer ) : base( 12, false, TargetFlags.None ) 
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

         SayTo( from, "Have you brought back my horse?" ); 

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
		if ( pet is KarinasHorse )
		{
			SellPetForGold( from, pet, 0 );
			from.SendGump( new TheElusiveEquineFinishGump( from ));

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
      	if ( ( e.Speech.ToLower() == "horse" ) )//was sellpet
	{
      		BeginPetSale( e.Mobile );
         }
         else 
         { 
            base.OnSpeech( e ); 
         } 
      
      } 

		public ElmhavenRancher( Serial serial ) : base( serial )
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

	public class SBElmhavenRancher : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElmhavenRancher()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new AnimalBuyInfo( 1, typeof( PackHorse ), 500, 15, 291, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( PackLlama ), 500, 15, 292, 0 ) );

				Add( new AnimalBuyInfo( 1, typeof( LesserAntLion ), 2000, 15, 787, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( WaterLizard ), 1000, 15, 734, 491 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}
