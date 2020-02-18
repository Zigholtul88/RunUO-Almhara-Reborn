using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class GoblinTribalMask : TribalMask
	{
		public override int BaseFireResistance{ get{ return 4; } }
		public override int BaseEnergyResistance{ get{ return 6; } }

		public override bool Dye( Mobile from, DyeTub sender )
		{
			from.SendLocalizedMessage( sender.FailMessage );
			return false;
		}

		[Constructable]
		public GoblinTribalMask()
		{
                  Name = "Goblin Tribal Mask";
                  Hue = 67;

			Attributes.BonusInt = 3;
		}

		public override bool CanEquip( Mobile m )
		{
			if ( !base.CanEquip( m ) )
				return false;

			if ( m.BodyMod == 183 || m.BodyMod == 184 )
			{
				m.SendLocalizedMessage( 1061629 ); // You can't do that while wearing savage kin paint.
				return false;
			}

			return true;
		}

		public override void OnAdded( object parent )
		{
			base.OnAdded( parent );

			if ( parent is Mobile )
				Misc.Titles.AwardKarma( (Mobile)parent, -20, true );
		}

		public GoblinTribalMask( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "Wear this mask to blend in, but don't retaliate or else!" );
		}
	}
}



