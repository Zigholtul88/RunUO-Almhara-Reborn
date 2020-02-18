using System;

namespace Server.Items
{
       public class BagOfStrength : Bag
       {
                [Constructable]
		public BagOfStrength() : this(10)      // create a 10 item bag by default
		{
		}
		
		[Constructable]
		public BagOfStrength(int maxitems) : base()
		{
			Weight = 0.0;
			MaxItems = maxitems;
			Name = "Bag of Strength";
			Hue = 1153;
		}

		public BagOfStrength( Serial serial ) : base( serial )
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

		public override void GetProperties( ObjectPropertyList list )
                {

                    base.GetProperties(list);

                    list.Add( 1060658, "Item capacity\t{0}", MaxItems ); // ~1_val~: ~2_val~

                    if(TotalWeight != 0) 
                        Timer.DelayCall( TimeSpan.Zero, new TimerCallback( InvalidateProperties ) );

                    //TotalWeight = 0;

                }
       }
}