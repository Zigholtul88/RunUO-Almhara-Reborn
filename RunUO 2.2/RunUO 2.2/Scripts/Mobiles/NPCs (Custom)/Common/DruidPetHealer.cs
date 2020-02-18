using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.ContextMenus;
using Server.Misc;
using System.Collections.Generic;
using Server.ACC.CSS.Systems.Druid;

namespace Server.Mobiles
{
	public class DruidPetHealer : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public DruidPetHealer() : base( "the Druid" )
		{
			NameHue = 68;
			AddItem( new WildStaff() );

			SetSkill( SkillName.Camping, 80.0, 100.0 );
			SetSkill( SkillName.AnimalLore, 85.0, 100.0 );
			SetSkill( SkillName.AnimalTaming, 90.0, 100.0 );
			SetSkill( SkillName.Veterinary, 90.0, 100.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBDruidPetHealer() );
		}

		public override VendorShoeType ShoeType{ get{ return VendorShoeType.Sandals; } }

		public virtual int GetRobeColor()
		{
			return Utility.RandomGreenHue();
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Robe( GetRobeColor() ) );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if (m is BaseCreature)
			{
				BaseCreature petPatient = m as BaseCreature;

				Mobile owner = petPatient.ControlMaster;
				
				if ( petPatient != null && petPatient.IsDeadPet )
				{
					if ( owner != null && owner.InRange( petPatient, 3 ) )
					{
				
						if ( InRange( owner, 2 ) && !InRange( oldLocation, 2 ) )
						{
					
							Gold g = owner.Backpack.FindItemByType( typeof ( Gold ) ) as Gold;
		        

							if ( g == null )
							{
								if ( !owner.HasGump( typeof( DruidGump ) ) )
							{
					        	owner.SendGump( new DruidGump( owner ) );
						
								return;
							}
							}
							else if ( g != null )
							{
								Say( "I see you have some gold. If you give me 1000 gp, I will resurrect your pet. " );
								return;
							}
						}
					}
				}
			}
		}
		
		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
         	Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;
           
			if ( mobile != null)
			{
				if( dropped is Gold )
            
         		{
         			if( dropped.Amount!= 1000 )
         			{
					int amount = dropped.Amount;
				    this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I have no need for that.", mobile.NetState );
				    this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I need 1000 gp not " +dropped.Amount+".", mobile.NetState );
				
         				return false;
         			}
         			
         			dropped.Delete();   
         			mobile.Target = new PetResTarget();
         			return true;
         		}
         		else if( dropped is Gold )
         		{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			return false;
				}
         		else
         		{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "I have no need for that!", mobile.NetState );
     			}
			}
			return false;
		}
		
		private class PetResTarget : Target
		{

		public PetResTarget( ) : base( 1, false, TargetFlags.Beneficial )
		{
		}	
	            
       		protected override void OnTarget( Mobile m, object obj )
        	{
      	  		if(obj is Mobile)
      		  	{ 
         	  		Mobile mob = (Mobile)obj;		

			  		if ( mob.IsDeadBondedPet )
			  		{
						BaseCreature bc = mob as BaseCreature;
						{	
							if(bc.ControlMaster == m)
							{
								m.CloseGump( typeof( PetResurrectGump ) );
								m.SendGump( new PetResurrectGump( m, bc ) );
							}
							else
							{
								m.SendMessage( "that is not your pet." );
							}
						}	
					}
					else
					{
						m.SendMessage( "that pet is not dead." );
					}
				}
 			}
 		}

		public DruidPetHealer( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
		}
	}
}