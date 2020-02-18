using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles;


namespace Server.Mobiles 
{ 
	public class BaseAssholeEnemy : BaseCreature 
	{ 
		public BaseAssholeEnemy(AIType ai, FightMode fm, int PR, int FR, double AS, double PS) : base( ai, fm, PR, FR, AS, PS )
		{
		}

		public override bool IsEnemy( Mobile m )
		{
                        if ( m is BaseAssholeEnemy || m is Miasma )
                        {
				return false;
                        }	

			return true;
		}

		public BaseAssholeEnemy( Serial serial ) : base( serial ) 
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