using System;
using Server.Mobiles;

namespace Server.Items
{
	public class BlackAntNest : Item
	{
		[Constructable]
		public BlackAntNest() : base( 0x2232 )
		{
            	Name = "a black ant nest";
            	Movable = false;

			LootType = LootType.Regular;
			Weight = 1.0;
			Hue = 0;
		}

		public override void OnDoubleClick( Mobile from )
		{
			BlackAntNest nest = (BlackAntNest)this;
			from.Animate( 32, 5, 1, true, false, 0 );

			if ( Utility.RandomDouble() < 0.50 )
			switch (Utility.Random(10))
			{
				case 0: 
				{
					SmallBlackAntEgg SBAE = new SmallBlackAntEgg();
					SBAE.MoveToWorld(new Point3D(((BlackAntNest)this).X, ((BlackAntNest)this).Y, ((BlackAntNest)this).Z), ((BlackAntNest)this).Map);
			            from.SendMessage( "You reach in and find a small black ant egg." );
					nest.Delete();	
				} break;
				case 1: 
				{
					Ruby ruby = new Ruby();
					ruby.MoveToWorld(new Point3D(((BlackAntNest)this).X, ((BlackAntNest)this).Y, ((BlackAntNest)this).Z), ((BlackAntNest)this).Map);
			            from.SendMessage( "You reach in and find a ruby." );
					nest.Delete();	
				} break;
				case 2: 
				{
					IrishSpirit IRSP = new IrishSpirit();
					IRSP.MoveToWorld(new Point3D(((BlackAntNest)this).X, ((BlackAntNest)this).Y, ((BlackAntNest)this).Z), ((BlackAntNest)this).Map);
			            from.SendMessage( "You reach in and find some irish spirit." );
					nest.Delete();	
				} break;
				case 3: 
				{
					AdeptPotionOfWrestling APOW = new AdeptPotionOfWrestling();
					APOW.MoveToWorld(new Point3D(((BlackAntNest)this).X, ((BlackAntNest)this).Y, ((BlackAntNest)this).Z), ((BlackAntNest)this).Map);
			            from.SendMessage( "You reach in and find an adept potion of wrestling." );
					nest.Delete();	
				} break;
				case 4: 
				{
					Gold GOLD5 = new Gold(5);
					GOLD5.MoveToWorld(new Point3D(((BlackAntNest)this).X, ((BlackAntNest)this).Y, ((BlackAntNest)this).Z), ((BlackAntNest)this).Map);
			            from.SendMessage( "You reach in and find some gold." );
					nest.Delete();	
				} break;
				case 5: 
				{
					Gold GOLD15 = new Gold(15);
					GOLD15.MoveToWorld(new Point3D(((BlackAntNest)this).X, ((BlackAntNest)this).Y, ((BlackAntNest)this).Z), ((BlackAntNest)this).Map);
			            from.SendMessage( "You reach in and find some gold." );
					nest.Delete();	
				} break;
				case 6: 
				{
					Gold GOLD35 = new Gold(35);
					GOLD35.MoveToWorld(new Point3D(((BlackAntNest)this).X, ((BlackAntNest)this).Y, ((BlackAntNest)this).Z), ((BlackAntNest)this).Map);
			            from.SendMessage( "You reach in and find some gold." );
					nest.Delete();	
				} break;
				case 7: 
				{
					Gold GOLD50 = new Gold(50);
					GOLD50.MoveToWorld(new Point3D(((BlackAntNest)this).X, ((BlackAntNest)this).Y, ((BlackAntNest)this).Z), ((BlackAntNest)this).Map);
			            from.SendMessage( "You reach in and find some gold." );
					nest.Delete();	
				} break;
				case 8: 
				{
					BlackAntAmbusher S1 = new BlackAntAmbusher();
					BlackAntAmbusher S2 = new BlackAntAmbusher();
					BlackAntAmbusher S3 = new BlackAntAmbusher();
					BlackAntAmbusher S4 = new BlackAntAmbusher();
					S1.MoveToWorld(new Point3D(((BlackAntNest)this).X, ((BlackAntNest)this).Y, ((BlackAntNest)this).Z), ((BlackAntNest)this).Map);
					S2.MoveToWorld(new Point3D(((BlackAntNest)this).X, ((BlackAntNest)this).Y, ((BlackAntNest)this).Z), ((BlackAntNest)this).Map);
					S3.MoveToWorld(new Point3D(((BlackAntNest)this).X, ((BlackAntNest)this).Y, ((BlackAntNest)this).Z), ((BlackAntNest)this).Map);
					S4.MoveToWorld(new Point3D(((BlackAntNest)this).X, ((BlackAntNest)this).Y, ((BlackAntNest)this).Z), ((BlackAntNest)this).Map);
					from.SendMessage( "A swarm of pissed off ants erupt from the nest and begin to unleash havoc upon you!" );
					nest.Delete();
				} break;
				case 9: 
				{
					from.SendMessage( "You reach into the nest, but due to utter retardation, you accidently destroy the eggs." );
					nest.Delete();							
				} break;
			}
		}
  
		public BlackAntNest( Serial serial ) : base( serial )
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
            
            	if ( Movable == true )
                	Movable = false;
		}
	}
}

