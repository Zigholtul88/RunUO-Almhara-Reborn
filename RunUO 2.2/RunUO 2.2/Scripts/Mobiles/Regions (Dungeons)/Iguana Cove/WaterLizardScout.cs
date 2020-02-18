using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a water lizard scout corpse" )]
	public class WaterLizardScout : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		private DateTime m_MilkedOn;

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime MilkedOn
		{
			get { return m_MilkedOn; }
			set { m_MilkedOn = value; }
		}

		private int m_Water;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Water
		{
			get { return m_Water; }
			set { m_Water = value; }
		}

		[Constructable]
		public WaterLizardScout() : base( AIType.AI_Melee, FightMode.Closest, 4, 1, 0.2, 0.4 )
		{
			Name = "a water lizard scout";
			Body = 734;
			Hue = 491;
			BaseSoundID = 0x5A;

			SetStr( 129, 142 );
			SetDex( 45, 63 );
			SetInt( 21, 30 );

			SetHits( 195, 205 );
			SetMana( 0 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );

			SetSkill( SkillName.MagicResist, 55.1, 70.0 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 5500;
			Karma = -5500;

			PackReg( 23, 36 );
		}

		public bool TryMilkingWater( Mobile from )
		{
			if ( !from.InLOS( this ) || !from.InRange( Location, 2 ) )
                                from.SendMessage( "You can not milk the water lizard from this location." ); 
			if ( Controlled && ControlMaster != from )
                                from.SendMessage( "The water lizard nimbly escapes your attempts to milk it." ); 
			if ( m_Water == 0 && m_MilkedOn + TimeSpan.FromDays( 1 ) > DateTime.Now )
                                from.SendMessage( "This water lizard can not be milked now. Please wait for some time." ); 
			else
			{
				if ( m_Water == 0 )
					m_Water = 4;

				m_MilkedOn = DateTime.Now;
				m_Water--;

				return true;
			}

			return false;
		}


		public override bool HasBreath{ get{ return true; } } // water gun enabled

		public override double BreathMinDelay{ get{ return 5.0; } }
		public override double BreathMaxDelay{ get{ return 15.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 1266; } }
		public override int BreathEffectItemID{ get{ return 0x1E28; } }
		public override int BreathEffectSound{ get{ return 0x364; } }
		public override int BreathAngerSound{ get{ return 0x1C0; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new WaterLizardMeat(), from );
                              corpse.AddCarvedItem( new SpinedHides(12), from );
                              corpse.AddCarvedItem( new SerpentScale( Utility.RandomMinMax( 6, 11 ) ), from );
                              corpse.AddCarvedItem( new WaterLizardEyeBall(), from );

                              from.SendMessage( "You carve up lizard meat, spined hides, serpent scales, and a water lizard eyeball." );
                              corpse.Carved = true; 
			}
                }

		public WaterLizardScout(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );

			writer.Write( (DateTime) m_MilkedOn );
			writer.Write( (int) m_Water );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version > 0 )
			{
				m_MilkedOn = reader.ReadDateTime();
				m_Water = reader.ReadInt();
			}
		}
	}
}