using System;
using Server.Items;

namespace Server.Items
{
	public abstract class BaseResistEnergySocketGem : Item
	{
		[Constructable]
		public BaseResistEnergySocketGem(int itemID) : base(itemID)
		{
		}

		public BaseResistEnergySocketGem( Serial serial ) : base( serial )
		{
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int RequiredLevel
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistEnergyArmor
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistEnergyClothing
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistEnergyJewelry
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int ResistEnergyShield
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
			if( ResistEnergyArmor > 0 )
                                list.Add( 1060659, "Resist Energy to armor\t{0}", ResistEnergyArmor.ToString() );
			if( ResistEnergyClothing > 0 )
                                list.Add( 1060660, "Resist Energy to clothing\t{0}", ResistEnergyClothing.ToString() );
			if( ResistEnergyJewelry > 0 )
                                list.Add( 1060661, "Resist Energy to jewelry\t{0}", ResistEnergyJewelry.ToString() );
			if( ResistEnergyShield > 0 )
                                list.Add( 1060662, "Resist Energy to shields\t{0}", ResistEnergyShield.ToString() );
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