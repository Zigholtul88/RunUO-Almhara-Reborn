using System; 
using Server; 

namespace Server.Items 
{ 
   	public class GreenCarrotQuest : Item 
   	{ 
      		[Constructable] 
      		public GreenCarrotQuest() : this( 1 ) 
      		{ 
      		} 

      		[Constructable] 
      		public GreenCarrotQuest( int amount ) : base( 0xC78 ) 
      		{
	 		Name = "Green Carrot";
	 		Hue = 462;
         		Weight = 0.1;
      		} 

      		public GreenCarrotQuest( Serial serial ) : base( serial ) 
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