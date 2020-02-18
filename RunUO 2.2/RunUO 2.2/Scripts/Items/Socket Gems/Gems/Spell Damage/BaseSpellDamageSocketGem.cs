using System;
using Server.Items;

namespace Server.Items
{
	public abstract class BaseSpellDamageSocketGem : Item
	{
		[Constructable]
		public BaseSpellDamageSocketGem (int itemID) : base (itemID)
		{
		}

		public BaseSpellDamageSocketGem ( Serial serial ) : base( serial )
		{
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int RequiredLevel
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int SpellDamageSpellbook
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int SpellDamageJewelry
		{ 
			get { return 0; }
			set {}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public virtual int SpellDamageClothing
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
			if( SpellDamageSpellbook > 0 )
                                list.Add( 1060659, "Spell Damage to spellbook\t{0}", SpellDamageSpellbook.ToString() );
			if( SpellDamageJewelry > 0 )
                                list.Add( 1060660, "Spell Damage to jewelry\t{0}", SpellDamageJewelry.ToString() );
			if( SpellDamageClothing > 0 )
                                list.Add( 1060661, "Spell Damage to clothing\t{0}", SpellDamageClothing.ToString() );
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