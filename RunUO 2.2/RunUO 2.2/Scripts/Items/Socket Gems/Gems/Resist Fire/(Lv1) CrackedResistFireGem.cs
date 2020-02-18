using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class CrackedResistFireGem : BaseResistFireSocketGem
	{
		private int m_RequiredLevel = 1;
		private int m_ResistFireArmor = 1;
		private int m_ResistFireClothing = 1;
		private int m_ResistFireJewelry = 2;
		private int m_ResistFireShield = 5;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ResistFireArmor
		{ 
			get{ return m_ResistFireArmor; }
			set {m_ResistFireArmor = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ResistFireClothing
		{ 
			get{ return m_ResistFireClothing; }
			set {m_ResistFireClothing = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ResistFireJewelry
		{ 
			get{ return m_ResistFireJewelry; }
			set {m_ResistFireJewelry = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ResistFireShield
		{ 
			get{ return m_ResistFireShield; }
			set {m_ResistFireShield = value; InvalidateProperties();}
		}

		[Constructable]
		public CrackedResistFireGem() : base( 0x3198 )
		{
			Name = "Cracked Resist Fire Gem";
			Weight = 1.0;
			Hue = 48;
		}

		public CrackedResistFireGem( Serial serial ) : base( serial )
		{
		}

		private string m_name ="Cracked Resist Fire Gem";

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			writer.Write( m_name );
			writer.Write( m_RequiredLevel );
			writer.Write( m_ResistFireArmor );
			writer.Write( m_ResistFireClothing );
			writer.Write( m_ResistFireJewelry );
			writer.Write( m_ResistFireShield );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			m_name = reader.ReadString();
			m_RequiredLevel = reader.ReadInt();
			m_ResistFireArmor = reader.ReadInt();
			m_ResistFireClothing = reader.ReadInt();
			m_ResistFireJewelry = reader.ReadInt();
			m_ResistFireShield = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			PlayerMobile pm = from as PlayerMobile;

                        if ( pm.Level < RequiredLevel )
			{
				from.SendMessage( "Your level isn't high enough to use this gem." );
				return;
			}

			if ( IsChildOf( from.Backpack ) )
			{
				from.Target = new InternalTarget( this );
			}
                        else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}

		private class InternalTarget : Target
		{
			private CrackedResistFireGem m_deed;

			public InternalTarget( CrackedResistFireGem deed ) : base( 3, false, TargetFlags.None )
			{
				m_deed = deed;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted == null )
					return;

				if (!(targeted is Item))
				{
					from.SendMessage("This gem can only be used on armor, clothing, jewelry and shields.");
					return;
				}
				
				if ( m_deed.Deleted )
					return;
				
				if (!(targeted as Item).IsChildOf(from.Backpack))
				{
					from.SendMessage("You can use this gem only on items in your backpack");
					return;
				}
				
				if ( targeted is BaseArmor || targeted is BaseClothing || targeted is BaseJewel || targeted is BaseShield )
				{
					BaseArmor a = targeted as BaseArmor;
					BaseClothing c = targeted as BaseClothing;
					BaseJewel j = targeted as BaseJewel;
					BaseShield s = targeted as BaseShield;

					if ( a !=null )
					{
						if ( a.FireBonus!=0 )
						{
							a.FireBonus=0;
							from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							a.FireBonus=1;
							from.SendMessage("Glow from gem was transfered to item, gem vanished into thin air");
						}
					}
                                        else if ( c!=null )
					{
						if ( c.Resistances.Fire!=0 )
						{
							c.Resistances.Fire=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							c.Resistances.Fire=1;
                                                        from.SendMessage("Glow from gem was transfered to item, gem vanished into thin air");
						}
					}
                                        else if ( j!=null )
					{
						if ( j.Resistances.Fire!=0 )
						{
							j.Resistances.Fire=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							j.Resistances.Fire=2;
                                                        from.SendMessage("Glow from gem was transfered to item, gem vanished into thin air");
						}
					}
                                        else if ( s!=null )
					{
						if ( s.FireBonus!=0 )
						{
							s.FireBonus=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							s.FireBonus=5;
                                                        from.SendMessage("Glow from gem was transfered to item, gem vanished into thin air");
						}
					}

					Effects.PlaySound( from.Location, from.Map, 0x243 );
					Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( from.X - 6, from.Y - 4, from.Z + 15 ), from.Map ), from, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
					Effects.SendTargetParticles( from, 0x375A, 35, 90, 0x00, 0x00, 9502, (EffectLayer)255, 0x100 );
					Effects.SendTargetParticles( from, 0x375A, 35, 90, 0x00, 0x00, 9502, (EffectLayer)255, 0x100 );
					m_deed.Delete();
				}
                                else
				{
					from.SendMessage( (string)"Gem did not react to targeted object" );
				}

			}
		}
	}
}