using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Spells;
using Server.Spells.Third;
using Server.Targeting;

namespace Server.Items
{
	public class RingOfTeleportation : BaseRing
	{
                private int m_Charges;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set{ m_Charges = value; InvalidateProperties(); }
		}

		[Constructable]
		public RingOfTeleportation() : this( 40 )
		{
		}

		[Constructable]
		public RingOfTeleportation( int charges ) : base( 0x108a )
		{
			m_Charges = charges;
                        Name = "Teleport Ring";
			Weight = 0.1;
                        Hue = 83;
		}

		public RingOfTeleportation( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

			list.Add( 1060741, m_Charges.ToString() ); // charges: ~1_val~
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.Player )
				return;

			if ( Parent != from ) 
                        { 
				from.SendMessage("You must equip the ring in order to teleport."); 
				return;
			}

			if ( from.InRange( GetWorldLocation(), 1 ) )
				BeginUsing( from, true );
			else
				from.SendLocalizedMessage( 500446 ); // That is too far away.
		}

		public void BeginUsing( Mobile from, bool useCharges )
		{
			if ( useCharges )
			{
				if ( Charges > 0 )
				{
					--Charges;
					UseRing( from );
				}
				else
				{
					from.SendLocalizedMessage( 502412 ); // There are no charges left on that item.
					return;
				}
			}		
		}

		public bool UseRing( Mobile m )
		{
			if ( m.Spell != null )
			{
				m.SendLocalizedMessage( 1049616 ); // You are too busy to do that at the moment.
				return false;
			}
			else
			{
                                new TeleportSpell ( m, this ).Cast();
				return true;
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( (int) m_Charges );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Charges = reader.ReadInt();
					break;
				}
			}
		}
	}
}