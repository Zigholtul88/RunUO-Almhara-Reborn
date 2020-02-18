using System;

namespace Server.Items
{
	public class Bolt : BaseAmmo
	{
		[Constructable]
		public Bolt() : this( 1 )
		{
		}

		[Constructable]
		public Bolt( int amount ) : base( 0x1BFB, AmmoTypes.Regular )
		{
			Amount = amount;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "regular iron" );
		}

		public Bolt( Serial serial ) : base( serial )
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
	
	public class DullCopperBolt : BaseAmmo
	{
		[Constructable]
		public DullCopperBolt() : this( 1 )
		{
		}

		[Constructable]
		public DullCopperBolt( int amount ) : base( 0x1BFB, AmmoTypes.DullCopper )
		{
			Amount = amount;
			Hue = 0x973;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "dull copper" );
		}

		public DullCopperBolt( Serial serial ) : base( serial )
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
	
	public class ShadowIronBolt : BaseAmmo
	{
		[Constructable]
		public ShadowIronBolt() : this( 1 )
		{
		}

		[Constructable]
		public ShadowIronBolt( int amount ) : base( 0x1BFB, AmmoTypes.ShadowIron )
		{
			Amount = amount;
			Hue = 0x966;
		}
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "shadow iron" );
		}

		public ShadowIronBolt( Serial serial ) : base( serial )
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
	
	public class CopperBolt : BaseAmmo
	{
		[Constructable]
		public CopperBolt() : this( 1 )
		{
		}

		[Constructable]
		public CopperBolt( int amount ) : base( 0x1BFB, AmmoTypes.Copper )
		{
			Amount = amount;
			Hue = 0x96D;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "copper" );
		}

		public CopperBolt( Serial serial ) : base( serial )
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
	
	public class BronzeBolt : BaseAmmo
	{
		[Constructable]
		public BronzeBolt() : this( 1 )
		{
		}

		[Constructable]
		public BronzeBolt( int amount ) : base( 0x1BFB, AmmoTypes.Bronze )
		{
			Amount = amount;
			Hue = 0x972;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "bronze" );
		}

		public BronzeBolt( Serial serial ) : base( serial )
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
	
	public class GoldBolt : BaseAmmo
	{
		[Constructable]
		public GoldBolt() : this( 1 )
		{
		}

		[Constructable]
		public GoldBolt( int amount ) : base( 0x1BFB, AmmoTypes.Gold )
		{
			Amount = amount;
			Hue = 0x8A5;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "gold" );
		}

		public GoldBolt( Serial serial ) : base( serial )
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
	
	public class AgapiteBolt : BaseAmmo
	{
		[Constructable]
		public AgapiteBolt() : this( 1 )
		{
		}

		[Constructable]
		public AgapiteBolt( int amount ) : base( 0x1BFB, AmmoTypes.Agapite )
		{
			Amount = amount;
			Hue = 0x979;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "agapite" );
		}

		public AgapiteBolt( Serial serial ) : base( serial )
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
	
	public class VeriteBolt : BaseAmmo
	{
		[Constructable]
		public VeriteBolt() : this( 1 )
		{
		}

		[Constructable]
		public VeriteBolt( int amount ) : base( 0x1BFB, AmmoTypes.Verite )
		{
			Amount = amount;
			Hue = 0x89F;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "verite" );
		}

		public VeriteBolt( Serial serial ) : base( serial )
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
	
	public class ValoriteBolt : BaseAmmo
	{
		[Constructable]
		public ValoriteBolt() : this( 1 )
		{
		}

		[Constructable]
		public ValoriteBolt( int amount ) : base( 0x1BFB, AmmoTypes.Valorite )
		{
			Amount = amount;
			Hue = 0x8AB;
		}
		
		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties (list);
			list.Add( "valorite" );
		}

		public ValoriteBolt( Serial serial ) : base( serial )
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