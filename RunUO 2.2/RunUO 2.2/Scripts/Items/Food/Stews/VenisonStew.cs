using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Network;
using Server.Multis;
using Server.ContextMenus;

namespace Server.Items
{
	public class VenisonStew : BaseAddon
	{
		[Constructable]
                public VenisonStew()
                {
                        AddonComponent stew;
                        stew = new AddonComponent( 2416 );
                        stew.Name = "venison stew";
                        stew.Visible = true;
                        AddComponent(stew, 0, 0, 0);      //stew
			stew.Movable = false;
                }

                public override void OnComponentUsed( AddonComponent stew, Mobile from )
		{
			if ( from.InRange( this.GetWorldLocation(), 1 ) )
                                from.SendMessage("You are too far away.");
                        else
			{
			        {
                                       stew.Visible = false;

                                       Venison venisonstew = new Venison();        //this decides your fillrate
                                       venisonstew.Eat( from );

                                       Timer m_timer = new ShowStew( stew );
                                       m_timer.Start();
                                }
                        }
                }

                public class ShowStew : Timer
                {
                        private AddonComponent stew;

                        public ShowStew( AddonComponent ac ) : base(TimeSpan.FromSeconds( 30 ) )
                        {
                                stew = ac;
                                Priority = TimerPriority.OneSecond;
                        }

                        protected override void OnTick()
                        {
                                if ( stew.Visible == false )
                                {
                                    Stop();
                                    stew.Visible = true;
                                    return;
                                }
                        }
                }

		public VenisonStew( Serial serial ) : base( serial )
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