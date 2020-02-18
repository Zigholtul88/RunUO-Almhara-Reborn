using System; 
using Server; 

namespace Server.Items 
{ 
   	public class BlueAppleQuest : Item 
   	{ 
      		[Constructable] 
      		public BlueAppleQuest() : this( 1 ) 
      		{ 
      		} 

      		[Constructable] 
      		public BlueAppleQuest( int amount ) : base( 0x9D0 ) 
      		{
	 		Name = "Blue Apple";
	 		Hue = 6;
         		Weight = 0.1; 
         		Amount = amount;
      		} 

      		public BlueAppleQuest( Serial serial ) : base( serial ) 
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