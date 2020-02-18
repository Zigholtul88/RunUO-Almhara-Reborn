using System;
using Server;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class UnholyCandle : BaseEquipableLight
	{
		public override int LitItemID{ get { return 0xA0F; } }
		public override int UnlitItemID{ get { return 0xA28; } }

		[Constructable]
		public UnholyCandle() : base( 0xA28 )
		{
			if ( Burnout )
				Duration = TimeSpan.FromMinutes( 20 );
			else
				Duration = TimeSpan.Zero;

			Burning = false;
			Light = LightType.Circle150;
                        Name = "Unholy Candle";
			Weight = 1.0;
                        Hue = 1150;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			chaos = direct = phys = fire = cold = pois = 0;
                        nrgy = 100;
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			base.OnHit( attacker, defender, damageBonus );

                        if ( defender is BaseCreature )
                        {
                             defender.PlaySound( 0x202 );
                             defender.Delete();

		             attacker.FixedParticles( 0x375A, 1, 30, 9966, 88, 2, EffectLayer.Head ); 
           	             attacker.FixedParticles( 0x37B9, 1, 30, 9502, 85, 3, EffectLayer.Head );
		             attacker.FixedParticles( 0x376A, 1, 31, 9961, 80, 0, EffectLayer.Waist );
           	             attacker.FixedParticles( 0x37C4, 1, 31, 9502, 88, 2, EffectLayer.Waist );
			     attacker.SendMessage("The creature has been vanquished.");
                        }
                        else
                        {
		             defender.RawStr -= ( Utility.Random( 1, 5 ) );
		             defender.RawDex -= ( Utility.Random( 1, 5 ) );
		             defender.RawInt -= ( Utility.Random( 1, 5 ) );
		             defender.Skills.Total -= ( Utility.Random( 1, 25 ) );

		             attacker.ApplyPoison( defender, Poison.Lethal );
                             defender.PlaySound( 0x208 );
                             Effects.SendTargetEffect( defender, 0x3709, 10, 30, 1150, 0 );
                             defender.SendMessage( "Your stats and skills have been slowly drained! And you're now poisoned!" );
                        }
		}

		public UnholyCandle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}