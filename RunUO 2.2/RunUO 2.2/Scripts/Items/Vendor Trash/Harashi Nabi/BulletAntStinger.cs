using System;
using Server;

namespace Server.Items
{
	public class BulletAntStinger : Item
	{
		[Constructable]
		public BulletAntStinger() : this( 1 )
		{
		}

		[Constructable]
		public BulletAntStinger( int amount ) : base( 12636 )
		{
			Name = "Bullet Ant Stinger";
			Stackable = true;
			Amount = amount;

			Weight = 0.2;
                        Hue = 0x648;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the stinger of a bullet ant that can be sold to butchers." );
			m.PlaySound( 849 );
		}

		public BulletAntStinger( Serial serial ) : base( serial )
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
	}
}