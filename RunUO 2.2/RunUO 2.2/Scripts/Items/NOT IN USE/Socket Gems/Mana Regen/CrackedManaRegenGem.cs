using System;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
	public class CrackedManaRegenGem : Item
	{
		[Constructable]
		public CrackedManaRegenGem() : base( 0x3198 )
		{
			Name = "Cracked Mana Regen Gem";
			Weight = 1.0;
			Hue = 191;
		}

		public CrackedManaRegenGem( Serial serial ) : base( serial )
		{
		}

		private string m_name ="Cracked Mana Regen Gem";

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			writer.Write(m_name);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			m_name=reader.ReadString();
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );
			from.SendMessage( m_name );
		}

		public override void OnDoubleClick( Mobile from )
		{
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
			private CrackedManaRegenGem m_deed;

			public InternalTarget( CrackedManaRegenGem deed ) : base( 3, false, TargetFlags.None )
			{
				m_deed = deed;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted == null )
					return;

				if (!(targeted is Item))
				{
					from.SendMessage("This gem can only be used on armor, jewelry, and clothing.");
					return;
				}
				
				if ( m_deed.Deleted )
					return;
				
				if(!(targeted as Item).IsChildOf(from.Backpack))
				{
					from.SendMessage("You can use this gem only on items in your backpack");
					return;
				}
				
				if ( targeted is BaseArmor || targeted is BaseJewel || targeted is BaseClothing )
				{
					BaseArmor a = targeted as BaseArmor;
					BaseJewel j = targeted as BaseJewel;
					BaseClothing c = targeted as BaseClothing;

					if ( a !=null )
					{
						if ( a.Attributes.RegenMana!=0 )
						{
							a.Attributes.RegenMana=0;
							from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							a.Attributes.RegenMana=1;
							from.SendMessage("Glow from gem was transfered to item, gem wanished into thin air");
						}
					}
                                        else if ( j!=null )
					{
						if ( j.Attributes.RegenMana!=0 )
						{
							j.Attributes.RegenMana=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							j.Attributes.RegenMana=1;
                                                        from.SendMessage("Glow from gem was transfered to item, gem wanished into thin air");
						}
					} 
                                        if ( c!=null )
					{
						if ( c.Attributes.RegenMana!=0 )
						{
							c.Attributes.RegenMana=0;
                                                        from.SendMessage("Gem absorbed items glow, and disintegrated with bright flash");
						}
                                                else
						{
							c.Attributes.RegenMana=1;
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