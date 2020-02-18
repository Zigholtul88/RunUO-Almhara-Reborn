using System;
using Server;
using Server.Spells.First;
using Server.Targeting;

namespace Server.Items
{
	public class ReactiveArmorWand : BaseWand
	{
		[Constructable]
		public ReactiveArmorWand() : base( WandEffect.ReactiveArmor, 5, 50 )
		{
                Name = "Reactive Armor Wand";
		}

		public ReactiveArmorWand( Serial serial ) : base( serial )
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

		public override void OnWandUse( Mobile from )
		{
			Cast( new ReactiveArmorSpell( from, this ) );
		}
	}
}