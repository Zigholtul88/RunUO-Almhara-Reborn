using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class CrackedResistEnergyGem : BaseResistEnergySocketGem
	{
		private int m_RequiredLevel = 1;
		private int m_ResistEnergyArmor = 1;
		private int m_ResistEnergyClothing = 1;
		private int m_ResistEnergyJewelry = 2;
		private int m_ResistEnergyShield = 5;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ResistEnergyArmor
		{ 
			get{ return m_ResistEnergyArmor; }
			set {m_ResistEnergyArmor = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ResistEnergyClothing
		{ 
			get{ return m_ResistEnergyClothing; }
			set {m_ResistEnergyClothing = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ResistEnergyJewelry
		{ 
			get{ return m_ResistEnergyJewelry; }
			set {m_ResistEnergyJewelry = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ResistEnergyShield
		{ 
			get{ return m_ResistEnergyShield; }
			set {m_ResistEnergyShield = value; InvalidateProperties();}
		}

		[Constructable]
		public CrackedResistEnergyGem() : base( 0x3198 )
		{
			Name = "Cracked Resist Energy Gem";
			Weight = 1.0;
			Hue = 21;
		}

		public CrackedResistEnergyGem( Serial serial ) : base( serial )
		{
		}

		private string m_name ="Cracked Resist Energy Gem";

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			writer.Write( m_name );
			writer.Write( m_RequiredLevel );
			writer.Write( m_ResistEnergyArmor );
			writer.Write( m_ResistEnergyClothing );
			writer.Write( m_ResistEnergyJewelry );
			writer.Write( m_ResistEnergyShield );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			m_name = reader.ReadString();
			m_RequiredLevel = reader.ReadInt();
			m_ResistEnergyArmor = reader.ReadInt();
			m_ResistEnergyClothing = reader.ReadInt();
			m_ResistEnergyJewelry = reader.ReadInt();
			m_ResistEnergyShield = reader.ReadInt();
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
			private CrackedResistEnergyGem m_deed;

			public InternalTarget( CrackedResistEnergyGem deed ) : base( 3, false, TargetFlags.None )
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
						if ( a.EnergyBonus!=0 )
						{
							a.EnergyBonus=0;
							from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							a.EnergyBonus=1;
							from.SendMessage("Glow from gem was transfered to item, gem vanished into thin air");
						}
					}
                                        else if ( c!=null )
					{
						if ( c.Resistances.Energy!=0 )
						{
							c.Resistances.Energy=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							c.Resistances.Energy=1;
                                                        from.SendMessage("Glow from gem was transfered to item, gem vanished into thin air");
						}
					}
                                        else if ( j!=null )
					{
						if ( j.Resistances.Energy!=0 )
						{
							j.Resistances.Energy=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							j.Resistances.Energy=2;
                                                        from.SendMessage("Glow from gem was transfered to item, gem vanished into thin air");
						}
					}
                                        else if ( s!=null )
					{
						if ( s.EnergyBonus!=0 )
						{
							s.EnergyBonus=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							s.EnergyBonus=5;
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