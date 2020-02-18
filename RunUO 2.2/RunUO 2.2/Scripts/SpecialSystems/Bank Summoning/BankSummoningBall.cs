using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Items
{
	public class BankSummoningBall : Item
	{
                private int m_Charges;

		public virtual TimeSpan GetUseDelay{ get{ return TimeSpan.FromSeconds( 60.0 ); } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set{ m_Charges = value; InvalidateProperties(); }
		}

		[Constructable]
		public BankSummoningBall() : base( 0xE2E )
		{
                        Name = "Bank Summoning Ball (charges: 5)";
			Weight = 1.0;
			Hue = 1266;
			LootType = LootType.Blessed;

                        this.Charges = 5;
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
				UseBankSummoningBall( from );
			else
				from.SendLocalizedMessage( 500446 ); // That is too far away.
		}

		public bool UseBankSummoningBall( Mobile m )
		{
			if ( m_Charges <= 0 )
			{
				m.SendLocalizedMessage( 1019073 ); // This item is out of charges.
				return false;
			}

                                Charges--;
                                if ( Charges > 0 )
                                   Name = "Bank Summoning Ball (charges: " + Charges.ToString() + ")";
                                else
                                   Name = "Bank Summoning Ball";

			if ( m_Charges <= 0 )
			{
				m.SendLocalizedMessage( 1019073 ); // This item is out of charges.
				return false;
			}
			else
			{
				m.PlaySound( 0x014 ); // wind 1
				m.PlaySound( 0x015 ); // wind 2
				m.PlaySound( 0x016 ); // wind 3
				m.PlaySound( 0x028 ); // thundr01
				m.PlaySound( 0x028 ); // thundr01
				m.PlaySound( 0x4D5 ); // defense mastery

           		        m.FixedParticles( 0x373A, 10, 15, 5036, EffectLayer.Head ); 
               		        m.PlaySound( 521 );
        		        SummonedInvestmentBanker investmentbanker = new SummonedInvestmentBanker();
			        investmentbanker.MoveToWorld( m.Location, m.Map );
               		        m.SendMessage( "You summon an investment banker for 5 minutes." );

				return true;
                        }
		}

		public BankSummoningBall( Serial serial ) : base( serial )
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