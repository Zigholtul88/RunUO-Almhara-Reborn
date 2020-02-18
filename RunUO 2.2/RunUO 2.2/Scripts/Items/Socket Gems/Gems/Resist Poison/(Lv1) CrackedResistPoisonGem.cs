using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class CrackedResistPoisonGem : BaseResistPoisonSocketGem
	{
		private int m_RequiredLevel = 1;
		private int m_ResistPoisonArmor = 1;
		private int m_ResistPoisonClothing = 1;
		private int m_ResistPoisonJewelry = 2;
		private int m_ResistPoisonShield = 5;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ResistPoisonArmor
		{ 
			get{ return m_ResistPoisonArmor; }
			set {m_ResistPoisonArmor = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ResistPoisonClothing
		{ 
			get{ return m_ResistPoisonClothing; }
			set {m_ResistPoisonClothing = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ResistPoisonJewelry
		{ 
			get{ return m_ResistPoisonJewelry; }
			set {m_ResistPoisonJewelry = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int ResistPoisonShield
		{ 
			get{ return m_ResistPoisonShield; }
			set {m_ResistPoisonShield = value; InvalidateProperties();}
		}

		[Constructable]
		public CrackedResistPoisonGem() : base( 0x3198 )
		{
			Name = "Cracked Resist Poison Gem";
			Weight = 1.0;
			Hue = 76;
		}

		public CrackedResistPoisonGem( Serial serial ) : base( serial )
		{
		}

		private string m_name ="Cracked Resist Poison Gem";

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			writer.Write( m_name );
			writer.Write( m_RequiredLevel );
			writer.Write( m_ResistPoisonArmor );
			writer.Write( m_ResistPoisonClothing );
			writer.Write( m_ResistPoisonJewelry );
			writer.Write( m_ResistPoisonShield );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			m_name = reader.ReadString();
			m_RequiredLevel = reader.ReadInt();
			m_ResistPoisonArmor = reader.ReadInt();
			m_ResistPoisonClothing = reader.ReadInt();
			m_ResistPoisonJewelry = reader.ReadInt();
			m_ResistPoisonShield = reader.ReadInt();
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
			private CrackedResistPoisonGem m_deed;

			public InternalTarget( CrackedResistPoisonGem deed ) : base( 3, false, TargetFlags.None )
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
						if ( a.PoisonBonus!=0 )
						{
							a.PoisonBonus=0;
							from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							a.PoisonBonus=1;
							from.SendMessage("Glow from gem was transfered to item, gem vanished into thin air");
						}
					}
                                        else if ( c!=null )
					{
						if ( c.Resistances.Poison!=0 )
						{
							c.Resistances.Poison=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							c.Resistances.Poison=1;
                                                        from.SendMessage("Glow from gem was transfered to item, gem vanished into thin air");
						}
					}
                                        else if ( j!=null )
					{
						if ( j.Resistances.Poison!=0 )
						{
							j.Resistances.Poison=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							j.Resistances.Poison=2;
                                                        from.SendMessage("Glow from gem was transfered to item, gem vanished into thin air");
						}
					}
                                        else if ( s!=null )
					{
						if ( s.PoisonBonus!=0 )
						{
							s.PoisonBonus=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							s.PoisonBonus=5;
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