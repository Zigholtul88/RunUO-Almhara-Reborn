using System;
using Server.Network;

namespace Server.Items
{
	public class AppleOfCorrosion : Food
	{
		[Constructable]
		public AppleOfCorrosion() : this( 1 )
		{
		}

		[Constructable]
		public AppleOfCorrosion( int amount ) : base( amount, 0x9D0 )
		{
                        this.Name = "apple";
			this.Weight = 1.0;
			this.FillFactor = 1;
		}

		public AppleOfCorrosion( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !Movable )
				return;

			if ( from.InRange( this.GetWorldLocation(), 1 ) )
			{
				Eat( from );

		                from.ApplyPoison( from, Poison.Lethal );
		                from.PlaySound( from.Female ? 814 : 1088 );
				from.SendMessage("You scream in agony as your organs burn from the inside.");
			}
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