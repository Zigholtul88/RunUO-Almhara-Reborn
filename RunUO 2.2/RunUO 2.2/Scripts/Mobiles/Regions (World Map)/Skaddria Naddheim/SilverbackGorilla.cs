using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a silverback gorilla corpse" )]
	public class SilverbackGorilla : BaseCreature
	{
		[Constructable]
		public SilverbackGorilla() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a silverback gorilla";
			Body = 0x1D;
			BaseSoundID = 0x9E;
			Hue = 1154;

			SetStr( 65, 88 );
			SetDex( 36, 55 );
			SetInt( 36, 81 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 10 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 45.2, 59.3 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 450;
			Karma = 0;

			VirtualArmor = 20;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 0.0;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 6; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

                private DateTime _NextBanana;
                private int _Thrown;

                public override void OnActionCombat()
                {
                        Mobile combatant = Combatant as Mobile;

                        if (DateTime.UtcNow < _NextBanana || combatant == null || combatant.Deleted || combatant.Map != Map || !InRange(combatant, 12) || !CanBeHarmful(combatant) || !InLOS(combatant))
                            return;

                        ThrowBanana(combatant);

                        _Thrown++;

                        if (0.75 >= Utility.RandomDouble() && (_Thrown % 2) == 1) // 75% chance to quickly throw another banana
                           _NextBanana = DateTime.UtcNow + TimeSpan.FromSeconds(3.0);
                        else
                           _NextBanana = DateTime.UtcNow + TimeSpan.FromSeconds(5.0 + (10.0 * Utility.RandomDouble())); // 5-15 seconds
                }

                public void ThrowBanana(Mobile m)
                {
                        DoHarmful(m);

                        this.MovingParticles(m, Utility.RandomList(0x171f, 0x1720, 0x1721, 0x1722), 10, 0, false, true, 0, 0, 9502, 6014, 0x11D, EffectLayer.Waist, 0);

			new InternalTimer( m, this ).Start();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile, m_From;

			public InternalTimer( Mobile m, Mobile from ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				m_Mobile.PlaySound( 0x11D );
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 1, 3 ), 100, 0, 0, 0, 0 );
			}
		}

		public SilverbackGorilla(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}