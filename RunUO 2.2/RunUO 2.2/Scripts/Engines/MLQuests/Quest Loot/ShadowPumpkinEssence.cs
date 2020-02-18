using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class ShadowPumpkinEssence : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public ShadowPumpkinEssence() : this( 1 )
		{
		}

		[Constructable]
		public ShadowPumpkinEssence( int amount ) : base( 0xF8E )
		{
			Name = "Shadow Pumpkin Essence - Quest Item";
                        Hue = 343;
			Stackable = true;
			Amount = amount;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "an item needed for the This Is Not Halloween quest" );
		}

		public ShadowPumpkinEssence( Serial serial ) : base( serial )
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