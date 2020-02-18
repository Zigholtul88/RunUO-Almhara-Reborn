using System;
using Server.Items;

namespace Server.Items
{
	public abstract class BaseResistPoisonSocketGem : Item
	{
		[Constructable]
		public BaseResistPoisonSocketGem(int itemID) : base(itemID)
		{
		}

		public BaseResistPoisonSocketGem( Serial serial ) : base( serial )
		{
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int RequiredLevel
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistPoisonArmor
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistPoisonClothing
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistPoisonJewelry
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistPoisonShield
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
			if( ResistPoisonArmor > 0 )
                                list.Add( 1060659, "Resist Poison to armor\t{0}", ResistPoisonArmor.ToString() );
			if( ResistPoisonClothing > 0 )
                                list.Add( 1060660, "Resist Poison to clothing\t{0}", ResistPoisonClothing.ToString() );
			if( ResistPoisonJewelry > 0 )
                                list.Add( 1060661, "Resist Poison to jewelry\t{0}", ResistPoisonJewelry.ToString() );
			if( ResistPoisonShield > 0 )
                                list.Add( 1060662, "Resist Poison to shields\t{0}", ResistPoisonShield.ToString() );
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