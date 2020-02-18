using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a water beetle corpse" )]
	public class WaterBeetle : BaseCreature
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
		public WaterBeetle() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a water beetle";
			Body = 247;
                        Hue = 181;

			SetStr( 215, 225 );
			SetDex( 99, 105 );
			SetInt( 24, 31 );

			SetHits( 185, 235 );
			SetMana( 0 );

			SetDamage( 6, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );

			SetSkill( SkillName.MagicResist, 45.1, 59.3 );
			SetSkill( SkillName.Tactics, 89.7, 95.9 );
			SetSkill( SkillName.Wrestling, 87.1, 91.5 );

			Fame = 2000;
			Karma = -2000;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 37.9;
		}

		public override int GetAngerSound() { return 0x21D; } 
		public override int GetIdleSound() { return 0x21D; } 
		public override int GetAttackSound() { return 0x162; } 
		public override int GetHurtSound() { return 0x163; } 
		public override int GetDeathSound() { return 0x21D; }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
		}

		public bool TryMilkingWater( Mobile from )
		{
			if ( !from.InLOS( this ) || !from.InRange( Location, 2 ) )
                                from.SendMessage( "You can not milk the water beetle from this location." ); 
			if ( Controlled && ControlMaster != from )
                                from.SendMessage( "The water beetle nimbly escapes your attempts to milk it." ); 
			if ( m_Water == 0 && m_MilkedOn + TimeSpan.FromDays( 1 ) > DateTime.Now )
                                from.SendMessage( "This water beetle can not be milked now. Please wait for some time." ); 
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

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new DullCopperIngot( Utility.RandomMinMax( 25, 35 )), from);
                              corpse.AddCarvedItem(new BeetleEgg( Utility.RandomMinMax( 17, 22 )), from);

                              from.SendMessage( "You carve up some beetle eggs and in addition some dull copper ingots." );
                              corpse.Carved = true; 
			}
                }

		public WaterBeetle( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );

			writer.Write( (DateTime) m_MilkedOn );
			writer.Write( (int) m_Water );
		}

		public override void Deserialize( GenericReader reader )
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