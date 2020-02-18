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
	[CorpseName( "a water lizard corpse" )]
	public class WaterLizard : BaseCreature
	{
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
		public WaterLizard() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a water lizard";
			Body = 734;
			Hue = 491;
			BaseSoundID = 0x5A;

			SetStr( 116, 121 );
			SetDex( 39, 59 );
			SetInt( 16, 27 );

			SetMana( 100 );

			SetDamage( 1, 3 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Energy, -25 );

			SetSkill( SkillName.MagicResist, 55.1, 70.0 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 800;
			Karma = -800;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 34.2;
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from != null && from != this )
			{
				if ( from is PlayerMobile )
				{
					PlayerMobile p_PlayerMobile = from as PlayerMobile;
					Item weapon1 = p_PlayerMobile.FindItemOnLayer( Layer.OneHanded );
					Item weapon2 = p_PlayerMobile.FindItemOnLayer( Layer.TwoHanded );

					if ( weapon1 != null )
					{
						if ( weapon1 is BaseKnife )
						{
							damage *= 2;
						}
						else if ( weapon1 is BaseSpear )
						{
							damage *= 4;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseKnife )
						{
							damage *= 2;
						}
						else if ( weapon2 is BaseSpear )
						{
							damage *= 4;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
				}
			}
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

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

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

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
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 2, 5 )), from);
                              corpse.AddCarvedItem(new WaterLizardMeat(), from);
                              corpse.AddCarvedItem(new SpinedHides(12), from);
                              corpse.AddCarvedItem(new SerpentScale( Utility.RandomMinMax( 3, 6 )), from);
                              corpse.AddCarvedItem(new WaterLizardEyeBall(), from );

                              from.SendMessage( "You carve up gold, water lizard meat, spined hides, serpent scales, and a water lizard eyeball." );
                              corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.ZaythalorPredator; }
		}

		public WaterLizard(Serial serial) : base(serial)
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