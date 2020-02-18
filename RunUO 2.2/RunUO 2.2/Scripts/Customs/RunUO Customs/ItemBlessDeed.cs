using System;
using Server.Network;
using Server.Prompts;
using Server.Targeting;

namespace Server.Items
{
	public class ItemBlessTarget : Target 
	{
		private ItemBlessDeed m_Deed;

		public ItemBlessTarget( ItemBlessDeed deed ) : base( 1, false, TargetFlags.None )
		{
			m_Deed = deed;
		}

		protected override void OnTarget( Mobile from, object target )
		{
			if ( m_Deed.Deleted || m_Deed.RootParent != from )
				return;

			if ( target is BaseClothing )
			{
				from.SendLocalizedMessage( 500509 ); // You cannot bless that object
			}
			else if (target is Item)
			{
				Item i = (Item)target;
				if(i.Stackable || i is Container || i is BasePotion)
				{
					from.SendLocalizedMessage( 500509 ); // You cannot bless that object
				}else
				{
					i.LootType = LootType.Blessed;
					from.SendMessage("Item was blessed");
					m_Deed.Delete();
				}
			}
		}
	}

	public class ItemBlessDeed : Item
	{
		public override string DefaultName
		{
			get { return "Item Bless Deed"; }
		}

		[Constructable]
		public ItemBlessDeed() : base( 0x14F0 )
		{
			Weight = 1.0;
			LootType = LootType.Blessed;
		}

		public ItemBlessDeed( Serial serial ) : base( serial )
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
			LootType = LootType.Blessed;

			int version = reader.ReadInt();
		}

		public override bool DisplayLootType{ get{ return false; } }

		public override void OnDoubleClick( Mobile from ) 
		{
			if ( !IsChildOf( from.Backpack ) ) 
			{
				 from.SendLocalizedMessage( 1042001 ); 
			}
			else
			{
				from.SendMessage( "What would you like to bless?" ); 
				from.Target = new ItemBlessTarget( this ); 
			 }
		}	
	}
}
