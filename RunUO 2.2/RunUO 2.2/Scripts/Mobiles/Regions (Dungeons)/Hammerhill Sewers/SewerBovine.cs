using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a sewer bovine corpse" )]
	public class SewerBovine : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		private DateTime m_MilkedOn;

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime MilkedOn
		{
			get { return m_MilkedOn; }
			set { m_MilkedOn = value; }
		}

		private int m_Milk;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Milk
		{
			get { return m_Milk; }
			set { m_Milk = value; }
		}

		[Constructable]
		public SewerBovine() : base( AIType.AI_Melee, FightMode.Closest, 3, 1, 0.3, 0.6 )
		{
			Name = "a sewer bovine";
			Body = Utility.RandomList( 0xD8, 0xE7 );
                        Hue = 2126;
			BaseSoundID = 0x78;

			SetStr( 40, 65 );
			SetDex( 35, 55 );
			SetInt( 10 );

			SetHits( 45, 60 );

			SetDamage( 1, 4 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Poison, 30 );

			SetResistance( ResistanceType.Physical, 15 );
			SetResistance( ResistanceType.Poison, 25 );

			SetSkill( SkillName.MagicResist, 9.5, 18.2 );
			SetSkill( SkillName.Poisoning, 35.2, 43.1 );
			SetSkill( SkillName.Tactics, 23.2, 35.5 );
			SetSkill( SkillName.Wrestling, 12.1, 19.6 );

			Fame = 3000;
			Karma = -3000;

			PackGold( 1, 5 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override Poison HitPoison{ get{ return Poison.Regular; } }

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
		}

		public override void OnDoubleClick( Mobile from )
		{
			base.OnDoubleClick( from );

			int random = Utility.Random( 100 );

			if ( random < 5 )
				Tip();
			else if ( random < 20 )
				PlaySound( 120 );
			else if ( random < 40 )
				PlaySound( 121 );
		}

		public void Tip()
		{
			PlaySound( 121 );
			Animate( 8, 0, 3, true, false, 0 );
		}

		public bool TryMilk( Mobile from )
		{
			if ( !from.InLOS( this ) || !from.InRange( Location, 2 ) )
				from.SendLocalizedMessage( 1080400 ); // You can not milk the cow from this location.
			if ( Controlled && ControlMaster != from )
				from.SendLocalizedMessage( 1071182 ); // The cow nimbly escapes your attempts to milk it.
			if ( m_Milk == 0 && m_MilkedOn + TimeSpan.FromDays( 1 ) > DateTime.Now )
				from.SendLocalizedMessage( 1080198 ); // This cow can not be milked now. Please wait for some time.
			else
			{
				if ( m_Milk == 0 )
					m_Milk = 4;

				m_MilkedOn = DateTime.Now;
				m_Milk--;

				return true;
			}

			return false;
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                             corpse.AddCarvedItem(new RawRibs(8), from);
                             corpse.AddCarvedItem(new Hides(12), from);
                             corpse.AddCarvedItem(new SewerBeef(), from);

                             from.SendMessage( "You carve up raw ribs, hides, and some sewer beef." );

			     if ( 0.2 >= Utility.RandomDouble() )
                             {
		                  from.Hits -= ( Utility.Random( 2, 5 ) ); 
		                  from.Stam -= ( Utility.Random( 2, 5 ) );
		                  from.Mana -= ( Utility.Random( 2, 5 ) ); 

		                  from.ApplyPoison( from, Poison.Lesser );
                                  from.FixedParticles(0x36B0, 1, 14, 0x26BB, 0x3F, 0x7, EffectLayer.Waist);
		                  from.PlaySound( from.Female ? 785 : 1056 );
                                  from.SendMessage( "Gases emitted from the creature's corpse has rendered you poisoned!" );
                             }

                             corpse.Carved = true; 
			}
                }

		public SewerBovine( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );

			writer.Write( (DateTime) m_MilkedOn );
			writer.Write( (int) m_Milk );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version > 0 )
			{
				m_MilkedOn = reader.ReadDateTime();
				m_Milk = reader.ReadInt();
			}
		}
	}
}