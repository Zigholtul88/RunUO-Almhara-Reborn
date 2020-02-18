using System;
using Server.Items;

namespace Server.Items
{
	public abstract class BaseResistFireSocketGem : Item
	{
		[Constructable]
		public BaseResistFireSocketGem(int itemID) : base(itemID)
		{
		}

		public BaseResistFireSocketGem( Serial serial ) : base( serial )
		{
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int RequiredLevel
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistFireArmor
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistFireClothing
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistFireJewelry
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistFireShield
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
			if( ResistFireArmor > 0 )
                                list.Add( 1060659, "Resist Fire to armor\t{0}", ResistFireArmor.ToString() );
			if( ResistFireClothing > 0 )
                                list.Add( 1060660, "Resist Fire to clothing\t{0}", ResistFireClothing.ToString() );
			if( ResistFireJewelry > 0 )
                                list.Add( 1060661, "Resist Fire to jewelry\t{0}", ResistFireJewelry.ToString() );
			if( ResistFireShield > 0 )
                                list.Add( 1060662, "Resist Fire to shields\t{0}", ResistFireShield.ToString() );
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