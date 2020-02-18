using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class SpiderPotion : Item
	{
                private int m_Charges;

		public virtual TimeSpan GetUseDelay{ get{ return TimeSpan.FromSeconds( 4.0 ); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set{ m_Charges = value; InvalidateProperties(); }
		}

		[Constructable]
		public SpiderPotion() : base( 0xE2B )
		{
                        Name = "Spider Conversion Potion (charges: 20)";
			Weight = 1.0;
			Hue = 0x2D;
			LootType = LootType.Blessed;

                        this.Charges = 20;
		}

                public override void GetProperties(ObjectPropertyList list) // Add charges to item description
                {
				base.GetProperties( list ); 

				if ( m_Charges != 0 ) 
					list.Add( 1060584, m_Charges.ToString() ); 
                }

		public override void OnDoubleClick( Mobile from )
		{
                        if ( m_Charges <= 0 )
                                from.SendLocalizedMessage( 1019073 ); // This item is out of charges.

			if ( !from.Player )
				return;

			if ( from.InRange( GetWorldLocation(), 1 ) )
				UsePotion( from );
			else
				from.SendLocalizedMessage( 500446 ); // That is too far away.
		}

		public bool UsePotion( Mobile m )
		{
                        if ( m.Skills.TasteID.Base <= 49.9 )
                        {
				m.SendMessage( "You must have a TasteID skill of 50 or higher to use this potion." );
				return false;
                        }

                        if ( m.BodyValue == 28 )
                        {
				m.PlaySound( 0x3C4 );
				m.BodyMod = 0;
				m.HueMod = -1;
				return true;
                        }

			if ( m_Charges <= 0 )
			{
				m.SendLocalizedMessage( 1019073 ); // This item is out of charges.
				return false;
			}

                                Charges--;
                                if ( Charges > 0 )
                                   Name = "Spider Conversion Potion (charges: " + Charges.ToString() + ")";
                                else
                                   Name = "Spider Conversion Potion";

			if ( m_Charges <= 0 )
			{
				m.SendLocalizedMessage( 1019073 ); // This item is out of charges.
				return false;
			}
			else
			{
				m.SendMessage( "You shall forever remain stuck as a spider until either your death, server restart or by using this potion a 2nd time." );
				m.PlaySound( 0x014 ); // wind 1
				m.PlaySound( 0x015 ); // wind 2
				m.PlaySound( 0x016 ); // wind 3
				m.PlaySound( 0x028 ); // thundr01
				m.PlaySound( 0x028 ); // thundr01
				m.PlaySound( 0x4D5 ); // defense mastery


                                m.BodyMod = 28;
                                m.HueMod = 0;

				return true;
                        }
		}

		public SpiderPotion( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
	                writer.Write( m_Charges );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
	                m_Charges = reader.ReadInt();
		}
	}
}