// Evany - Jan 2012

using System;
using Server.Network;

namespace Server.Items
{
	public enum AmmoTypes
	{		
		Regular,
		// Wood
		Oak,
		Yew,
		Ash,
		Bloodwood,
		Heartwood,
		Frostwood,	
		// Iron
		DullCopper,
		ShadowIron,
		Copper,
		Bronze,
		Gold,
		Agapite,
		Verite,
		Valorite
	}
	
	public class BaseAmmo : Item, ICommodity
	{
		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }
		
		private AmmoTypes m_AmmoType;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public AmmoTypes AmmoTypes
		{
			get{ return m_AmmoType; }
			set{ m_AmmoType = value; InvalidateProperties(); }
		}

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public BaseAmmo() : this( 0xF3F, AmmoTypes.Regular )
		{
		}

		[Constructable]
		public BaseAmmo( int itemID, AmmoTypes type ) : base( itemID )
		{
			Stackable = true;
			AmmoTypes = type;
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if( IsChildOf( from.Backpack ) )
			{
				if( from.Skills[SkillName.ArmsLore].Value >= 29.1 || from.Skills[SkillName.ArmsLore].Value >= 29.1 )
				{
					switch( AmmoTypes )
					{
						// Wood
						case AmmoTypes.Oak: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo deals extra physical damage to the target." ); break;
						case AmmoTypes.Yew: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo deals higher extra physical damage to the target." ); break;
						case AmmoTypes.Ash: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo deals fire damage to the target." ); break;
						case AmmoTypes.Bloodwood: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo deals a bleeding attack to the target." ); break;
						case AmmoTypes.Heartwood: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo applies a poison to the target, increased by the attacker's poisoning skill." ); break;
						case AmmoTypes.Frostwood: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo freezes the target for a short period of time." ); break;
						// Iron
						case AmmoTypes.DullCopper: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo penetrates the target's armor, dealing extra damage." ); break;
						case AmmoTypes.ShadowIron: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo deals extra energy damage to the target." ); break;
						case AmmoTypes.Copper: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo deals extra poison and energy damage to the target." ); break;
						case AmmoTypes.Bronze: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo deals extra physical and fire damage to the target." ); break;
						case AmmoTypes.Gold: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo deals extra physical, fire and cold damage to the target." ); break;
						case AmmoTypes.Agapite: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo deals extra physical, fire and energy damage to the target." ); break;
						case AmmoTypes.Verite: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo deals extra physical, poison and energy damage to the target." ); break;
						case AmmoTypes.Valorite: PublicOverheadMessage( MessageType.Regular, 0x480, false, "This type of ammo deals extra damage to all target's resistances." ); break;
					}
				}
				else from.SendMessage( "You don't see anything special about this type of ammo." );
			}
			else from.SendMessage( "That must be inside your backpack for you to use it." );
		}

		public BaseAmmo( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
			
			writer.Write( (int) m_AmmoType );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			
			switch( version )
			{
				case 1: m_AmmoType = (AmmoTypes)reader.ReadInt(); break;
			}
		}
	}	
	
	public class Arrow : BaseAmmo
	{
		[Constructable]
		public Arrow() : this( 1 )
		{
		}
		
		[Constructable]
		public Arrow( int amount ) : base( 0xF3F, AmmoTypes.Regular )
		{
			Amount = amount;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "regular wood" );
		}

		public Arrow( Serial serial ) : base( serial )
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
	
	public class OakArrow : BaseAmmo
	{
		[Constructable]
		public OakArrow() : this( 1 )
		{
		}
		
		[Constructable]
		public OakArrow( int amount ) : base( 0xF3F, AmmoTypes.Oak )
		{
			Amount = amount;
			Hue = 0x7DA;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "Oak" );
		}

		public OakArrow( Serial serial ) : base( serial )
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
	
	public class YewArrow : BaseAmmo
	{
		[Constructable]
		public YewArrow() : this( 1 )
		{
		}
		
		[Constructable]
		public YewArrow( int amount ) : base( 0xF3F, AmmoTypes.Yew )
		{
			Amount = amount;
			Hue = 0x4A8;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "Yew" );
		}

		public YewArrow( Serial serial ) : base( serial )
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
	
	public class AshArrow : BaseAmmo
	{
		[Constructable]
		public AshArrow() : this( 1 )
		{
		}
		
		[Constructable]
		public AshArrow( int amount ) : base( 0xF3F, AmmoTypes.Ash )
		{
			Amount = amount;
			Hue = 0x4A7;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "Ash" );
		}

		public AshArrow( Serial serial ) : base( serial )
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
	
	public class BloodwoodArrow : BaseAmmo
	{
		[Constructable]
		public BloodwoodArrow() : this( 1 )
		{
		}
		
		[Constructable]
		public BloodwoodArrow( int amount ) : base( 0xF3F, AmmoTypes.Bloodwood )
		{
			Amount = amount;
			Hue = 0x4AA;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "Bloodwood" );
		}

		public BloodwoodArrow( Serial serial ) : base( serial )
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
	
	public class HeartwoodArrow : BaseAmmo
	{
		[Constructable]
		public HeartwoodArrow() : this( 1 )
		{
		}
		
		[Constructable]
		public HeartwoodArrow( int amount ) : base( 0xF3F, AmmoTypes.Heartwood )
		{
			Amount = amount;
			Hue = 0x4A9;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "Heartwood" );
		}

		public HeartwoodArrow( Serial serial ) : base( serial )
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
	
	public class FrostwoodArrow : BaseAmmo
	{
		[Constructable]
		public FrostwoodArrow() : this( 1 )
		{
		}
		
		[Constructable]
		public FrostwoodArrow( int amount ) : base( 0xF3F, AmmoTypes.Frostwood )
		{
			Amount = amount;
			Hue = 0x47F;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "Frostwood" );
		}

		public FrostwoodArrow( Serial serial ) : base( serial )
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