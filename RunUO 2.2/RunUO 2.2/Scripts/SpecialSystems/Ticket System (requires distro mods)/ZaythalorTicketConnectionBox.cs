using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Multis;
using Server.Network;

namespace Server.Items
{
	public class ZaythalorTicketConnectionBox : Item
	{
		[Constructable]
		public ZaythalorTicketConnectionBox() : this( null )
		{
		}

		[Constructable]
		public ZaythalorTicketConnectionBox ( string name ) : base ( 0x9A8 )
		{
			Name = "A Zaythalor Quest Ticket Connection Box";
			Weight = 0.0;
		        Movable = false;
			Hue = 1581;

			LootType = LootType.Blessed;
		}

		public ZaythalorTicketConnectionBox ( Serial serial ) : base ( serial )
		{
		}

		public override void OnDoubleClick( Mobile m )
		{
		 Item a = m.Backpack.FindItemByType( typeof( AFlagForHammerhillTicket ) );
		 if ( a != null )
		 {
		  Item b = m.Backpack.FindItemByType( typeof( BaroqueORamaTicket ) );
		  if ( b != null )
		  {
		   Item c = m.Backpack.FindItemByType( typeof( BirdemicTicket ) );
		   if ( c != null )
		   {	
		    Item d = m.Backpack.FindItemByType( typeof( EggCollectorTicket ) );
		    if ( d != null )
		    {
		     Item e = m.Backpack.FindItemByType( typeof( FeeshTendeesTicket ) );
		     if ( e != null )
		     {
		      Item f = m.Backpack.FindItemByType( typeof( HaldursBaitTicket ) );
		      if ( f != null )
		      {
		       Item g = m.Backpack.FindItemByType( typeof( InsecticideTicket ) );
		       if ( g != null )
		       {
		        Item h = m.Backpack.FindItemByType( typeof( LetterDeliveryTicket ) );
		        if ( h != null )
		        {
		         Item i = m.Backpack.FindItemByType( typeof( StaffOfFlyingMonkeysTicket ) );
		         if ( i != null )
		         {
		          Item j = m.Backpack.FindItemByType( typeof( StarLakeTicket ) );
		          if ( j != null )
		          {
		           Item k = m.Backpack.FindItemByType( typeof( StolenNecklaceTicket ) );
		           if ( k != null )
		           {
		            Item l = m.Backpack.FindItemByType( typeof( ThinningHerdTicket ) );
		            if ( l != null )
		            {
		             Item mm = m.Backpack.FindItemByType( typeof( ThisNotHalloweenTicket ) );
			     if ( mm != null )
			     {
			      Item n = m.Backpack.FindItemByType( typeof( ThoseBlueBastardsTicket ) );
			      if ( n != null )
			      {	
			       Item o = m.Backpack.FindItemByType( typeof( WitchApprenticeTicket ) );
			       if ( o != null )
			       {
			        Item p = m.Backpack.FindItemByType( typeof( BrightClubTicket ) );
			        if ( p != null )
			        {
			         Item q = m.Backpack.FindItemByType( typeof( ChampionHunt1Ticket ) );
			         if ( q != null )
			         {
			          Item r = m.Backpack.FindItemByType( typeof( EnchantedShovelTicket ) );
			          if ( r != null )
			          {
			           Item s = m.Backpack.FindItemByType( typeof( JadeJungleJemsTicket ) );
			           if ( s != null )
			           {
			            Item t = m.Backpack.FindItemByType( typeof( KissOfTheSerpentMistressTicket ) );
			            if ( t != null )
			            {
			             Item u = m.Backpack.FindItemByType( typeof( MolassesGreedTicket ) );
			             if ( u != null )
			             {
			              Item v = m.Backpack.FindItemByType( typeof( SpiderwickChroniclesTicket ) );
			              if ( v != null )
			              {
			               Item w = m.Backpack.FindItemByType( typeof( SweetChildTicket ) );
			               if ( w != null )
			               {
			                Item x = m.Backpack.FindItemByType( typeof( TreasureOfTheSandsTicket ) );
			                if ( x != null )
			                {
				                a.Delete();
				                b.Delete();
				                c.Delete();
				                d.Delete();
				                e.Delete();
				                f.Delete();
				                g.Delete();
				                h.Delete();
				                i.Delete();
				                j.Delete();
				                k.Delete();
				                l.Delete();
				                mm.Delete();
				                n.Delete();
				                o.Delete();
				                p.Delete();
				                q.Delete();
				                r.Delete();
				                s.Delete();
				                t.Delete();
				                u.Delete();
				                v.Delete();
				                w.Delete();
				                x.Delete();

				                m.AddToBackpack( new GateKeepersPermissionSlip() );
				                m.SendMessage( "You receive a permission slip. Give it to the gatekeeper in order to cross the desert." );
				                this.Delete();
			                }
			               }
                                      }
		                     }
	                            }
                                   }
		                  }
	                         }
                                }
                               }
                              }
                             }
                            }
                           }
                          }
                         }
                        }
                       }
                      }
                     }
                    }
                   }
                  }
                 }
		 else
		 {
		  m.SendMessage( "This requires all 24 tickets from the Zaythalor/Alytharr Tavern quest bulletin board." );
		 }
                }
		
		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}
}