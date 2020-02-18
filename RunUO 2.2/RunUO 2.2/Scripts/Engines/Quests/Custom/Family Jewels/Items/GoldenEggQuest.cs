using System; 
using Server; 

namespace Server.Items 
{ 
   	public class GoldenEggQuest : Item 
   	{ 
      		[Constructable] 
      		public GoldenEggQuest() : this( 1 ) 
      		{ 
      		} 

      		[Constructable] 
      		public GoldenEggQuest( int amount ) : base( 0x9B5 ) 
      		{
	 		Name = "Golden egg";
	 		Hue = 1701;
         		Weight = 0.1; 
         		Amount = amount; 
      		} 

      		public GoldenEggQuest( Serial serial ) : base( serial ) 
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