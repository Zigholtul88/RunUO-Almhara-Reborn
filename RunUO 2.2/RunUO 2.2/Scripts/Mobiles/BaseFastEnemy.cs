using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles;


namespace Server.Mobiles 
{ 
	public class BaseFastEnemy : BaseCreature 
	{ 
		public BaseFastEnemy(AIType ai, FightMode fm, int PR, int FR, double AS, double PS) : base( ai, fm, PR, FR, AS, PS )
		{
		}

		public override bool IsEnemy( Mobile m )
		{
                        if ( m is BaseFastEnemy || m is PlayerVendor || m is TownCrier || m is Miasma )

				return false;

			if ( m is BaseCreature)
			{
				BaseCreature c = (BaseCreature)m;

				if ( c.Controlled || c.FightMode == FightMode.Aggressor || c.FightMode == FightMode.Closest || c.FightMode == FightMode.None )

					return false;
			}	

			return true;
		}

		public BaseFastEnemy( Serial serial ) : base( serial ) 
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