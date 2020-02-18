using System;
using Server.Items;

namespace Server.Items
{
	public abstract class BaseDefendChanceSocketGem : Item
	{
		[Constructable]
		public BaseDefendChanceSocketGem(int itemID) : base(itemID)
		{
		}

		public BaseDefendChanceSocketGem( Serial serial ) : base( serial )
		{
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int RequiredLevel
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int DefendChance
		{ 
			get { return 0; }
			set {}
		}

		public override bool ForceShowProperties{ get{ return true; } }
            
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );
			if( RequiredLevel > 0 )
                                list.Add( 1060658, "Required Level\t{0}", RequiredLevel.ToString() );
			if( DefendChance > 0 )
                                list.Add( 1060659, "Defend Chance to shield\t{0}", DefendChance.ToString() );
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