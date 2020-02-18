using System;
using Server.Items;

namespace Server.Items
{
	public abstract class BaseResistColdSocketGem : Item
	{
		[Constructable]
		public BaseResistColdSocketGem(int itemID) : base(itemID)
		{
		}

		public BaseResistColdSocketGem( Serial serial ) : base( serial )
		{
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int RequiredLevel
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistColdArmor
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistColdClothing
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistColdJewelry
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistColdShield
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
			if( ResistColdArmor > 0 )
                                list.Add( 1060659, "Resist Cold to armor\t{0}", ResistColdArmor.ToString() );
			if( ResistColdClothing > 0 )
                                list.Add( 1060660, "Resist Cold to clothing\t{0}", ResistColdClothing.ToString() );
			if( ResistColdJewelry > 0 )
                                list.Add( 1060661, "Resist Cold to jewelry\t{0}", ResistColdJewelry.ToString() );
			if( ResistColdShield > 0 )
                                list.Add( 1060662, "Resist Cold to shields\t{0}", ResistColdShield.ToString() );
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