using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class CrackedSpellDamageGem : BaseSpellDamageSocketGem
	{
		private int m_RequiredLevel = 1;
		private int m_SpellDamageSpellbook = 10;
		private int m_SpellDamageJewelry = 2;
		private int m_SpellDamageClothing = 2;

		[CommandProperty( AccessLevel.GameMaster )]
		public override int RequiredLevel
		{ 
			get{ return m_RequiredLevel; }
			set {m_RequiredLevel = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int SpellDamageSpellbook
		{ 
			get{ return m_SpellDamageSpellbook; }
			set {m_SpellDamageSpellbook = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int SpellDamageJewelry
		{ 
			get{ return m_SpellDamageJewelry; }
			set {m_SpellDamageJewelry = value; InvalidateProperties();}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public override int SpellDamageClothing
		{ 
			get{ return m_SpellDamageClothing; }
			set {m_SpellDamageClothing = value; InvalidateProperties();}
		}

		[Constructable]
		public CrackedSpellDamageGem() : base( 0x3198 )
		{
			Name = "Cracked Spell Damage Gem";
			Weight = 1.0;
			Hue = 2607;
		}

		public CrackedSpellDamageGem( Serial serial ) : base( serial )
		{
		}

		private string m_name ="Cracked Spell Damage Gem";

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			writer.Write( m_name );
			writer.Write( m_RequiredLevel );
			writer.Write( m_SpellDamageSpellbook );
			writer.Write( m_SpellDamageJewelry );
			writer.Write( m_SpellDamageClothing );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			m_name = reader.ReadString();
			m_RequiredLevel = reader.ReadInt();
			m_SpellDamageSpellbook = reader.ReadInt();
			m_SpellDamageJewelry = reader.ReadInt();
			m_SpellDamageClothing = reader.ReadInt();
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
			private CrackedSpellDamageGem m_deed;

			public InternalTarget( CrackedSpellDamageGem deed ) : base( 3, false, TargetFlags.None )
			{
				m_deed = deed;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted == null )
					return;

				if (!(targeted is Item))
				{
					from.SendMessage("You can only use this gem on spellbooks, jewelry, and clothing.");
					return;
				}
				
				if ( m_deed.Deleted )
					return;
				
				if(!(targeted as Item).IsChildOf(from.Backpack))
				{
					from.SendMessage("You can use this gem only on items in your backpack");
					return;
				}
				
				if ( targeted is Spellbook || targeted is BaseJewel || targeted is BaseClothing )
				{
					Spellbook sb = targeted as Spellbook;
					BaseJewel j = targeted as BaseJewel;
					BaseClothing c = targeted as BaseClothing;

					if ( sb !=null )
					{
						if ( sb.Attributes.SpellDamage!=0 )
						{
							sb.Attributes.SpellDamage=0;
							from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							sb.Attributes.SpellDamage=10;
							from.SendMessage("Glow from gem was transfered to item, gem wanished into thin air");
						}
					}
                                        else if ( j!=null )
					{
						if ( j.Attributes.SpellDamage!=0 )
						{
							j.Attributes.SpellDamage=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							j.Attributes.SpellDamage=2;
                                                        from.SendMessage("Glow from gem was transfered to item, gem wanished into thin air");
						}
					} 
                                        if ( c!=null )
					{
						if ( c.Attributes.SpellDamage!=0 )
						{
							c.Attributes.SpellDamage=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							c.Attributes.SpellDamage=2;
                                                        from.SendMessage("Glow from gem was transfered to item, gem wanished into thin air");
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