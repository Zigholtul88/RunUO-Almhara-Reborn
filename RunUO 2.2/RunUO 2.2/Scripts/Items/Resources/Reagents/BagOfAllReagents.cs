using System;
using Server;
using Server.Items;
using Server.ACC.CSS.Systems.Druid;

namespace Server.Items
{
	public class BagOfAllReagents : Bag
	{
		[Constructable]
		public BagOfAllReagents() : this( 25 )
		{
		}

		[Constructable]
		public BagOfAllReagents( int amount )
		{
			DropItem( new BlackPearl   ( amount ) );
			DropItem( new Bloodmoss    ( amount ) );
			DropItem( new Garlic       ( amount ) );
			DropItem( new Ginseng      ( amount ) );
			DropItem( new MandrakeRoot ( amount ) );
			DropItem( new Nightshade   ( amount ) );
			DropItem( new SulfurousAsh ( amount ) );
			DropItem( new SpidersSilk  ( amount ) );
			DropItem( new BatWing      ( amount ) );
			DropItem( new GraveDust    ( amount ) );
			DropItem( new DaemonBlood  ( amount ) );
			DropItem( new NoxCrystal   ( amount ) );
			DropItem( new PigIron      ( amount ) );
			DropItem( new DestroyingAngel  ( amount ) );
			DropItem( new PetrafiedWood   ( amount ) );
			DropItem( new SpringWater      ( amount ) );
		}

		public BagOfAllReagents( Serial serial ) : base( serial )
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