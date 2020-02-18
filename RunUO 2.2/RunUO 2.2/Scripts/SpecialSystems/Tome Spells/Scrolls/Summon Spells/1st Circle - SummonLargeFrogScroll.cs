using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Tome;
using Server.Targeting;

namespace Server.Items
{
	public class SummonLargeFrogScroll : Item
	{
		[Constructable]
		public SummonLargeFrogScroll() : this( 1 )
		{
		}

		[Constructable]
		public SummonLargeFrogScroll( int amount ) : base( 0x2261 )
		{
			Name = "Summon Large Frog - 1st Circle";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 768;

			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile from )
		{
                        new SummonLargeFrogSpell ( from, this ).Cast();
		}

		public SummonLargeFrogScroll( Serial serial ) : base( serial )
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

namespace Server.Spells.Tome
{
	public class SummonLargeFrogSpell : TomeSpell 
	{ 
		private static SpellInfo m_Info = new SpellInfo( 
				"Summon Large Frog", "summon large frog",
				-1,
				9002
			); 

                public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 2.0 ); } }
                public override SpellCircle Circle { get { return SpellCircle.First; } }
                public override double RequiredSkill { get { return 0.1; } }
                public override int RequiredMana { get { return 80; } }

		public SummonLargeFrogSpell( Mobile caster, Item scroll ): base( caster, scroll, m_Info )
		{ 
		} 
		
		// NOTE: Creature list based on 1hr of summon/release on OSI.

		private static Type[] m_Types = new Type[]
			{
				typeof( LargeFrog )
			};

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 1) > Caster.FollowersMax )
			{
				Caster.SendMessage( "You have too many followers to summon this frog." );
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
			{
				try
				{
					BaseCreature creature = (BaseCreature)Activator.CreateInstance( m_Types[Utility.Random( m_Types.Length )] );

					creature.RangePerception = 100;
					creature.ControlSlots = 5;

					int amount1 = 2 * (int)( Caster.Skills[SkillName.EvalInt].Value / 25 );

					creature.RawStr += (Caster.RawInt) * amount1;
					creature.RawDex += (Caster.RawInt) * amount1;
					creature.RawInt += (Caster.RawInt) * amount1;

					creature.Hits += (Caster.RawInt) * amount1;
					creature.Stam += (Caster.RawInt) * amount1;
					creature.Mana += (Caster.RawInt) * amount1;

					int amount2 = 1 + (int)( Caster.Skills[SkillName.EvalInt].Value / 25 );

					creature.DamageMin += (Caster.FollowersMax) * amount2;
					creature.DamageMax += (Caster.FollowersMax) * amount2;

					int amount3 = 3 * (int)( Caster.Skills[SkillName.MagicResist].Value / 5 );

					ResistanceMod mod1 = new ResistanceMod( ResistanceType.Physical, + amount3 );
					ResistanceMod mod2 = new ResistanceMod( ResistanceType.Fire, + amount3 );
					ResistanceMod mod3 = new ResistanceMod( ResistanceType.Cold, + amount3 );
					ResistanceMod mod4 = new ResistanceMod( ResistanceType.Poison, + amount3 );
					ResistanceMod mod5 = new ResistanceMod( ResistanceType.Energy, + amount3 );

					int amount4 = 5 * (int)( Caster.Skills[SkillName.Inscribe].Value / 5 );

					SkillMod mod6 = new DefaultSkillMod( SkillName.Anatomy, true, + amount4 );
					SkillMod mod7 = new DefaultSkillMod( SkillName.MagicResist, true, + amount4 );
					SkillMod mod8 = new DefaultSkillMod( SkillName.Tactics, true, + amount4 );
					SkillMod mod9 = new DefaultSkillMod( SkillName.Wrestling, true, + amount4 );

					creature.AddResistanceMod( mod1 );
					creature.AddResistanceMod( mod2 );
					creature.AddResistanceMod( mod3 );
					creature.AddResistanceMod( mod4 );
					creature.AddResistanceMod( mod5 );

				        creature.AddSkillMod(mod6);
				        creature.AddSkillMod(mod7);
				        creature.AddSkillMod(mod8);
				        creature.AddSkillMod(mod9);

					TimeSpan duration;

					duration = TimeSpan.FromHours( 1.0 );

					SpellHelper.Summon( creature, Caster, 0x215, duration, false, false );
				}
				catch
				{
				}
			}

			FinishSequence();
		}

		public override TimeSpan GetCastDelay()
		{
			if ( Core.AOS )
				return TimeSpan.FromTicks( base.GetCastDelay().Ticks * 5 );

			return base.GetCastDelay() + TimeSpan.FromSeconds( 6.0 );
		}
	}
}