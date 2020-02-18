using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a sheep corpse" )]
	public class Sheep : BaseCreature, ICarvable
	{
		private DateTime m_NextWoolTime;

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime NextWoolTime
		{
			get{ return m_NextWoolTime; }
			set{ m_NextWoolTime = value; Body = ( DateTime.Now >= m_NextWoolTime ) ? 0xCF : 0xDF; }
		}

		public void Carve( Mobile from, Item item )
		{
			if ( DateTime.Now < m_NextWoolTime )
			{
				// This sheep is not yet ready to be shorn.
				PrivateOverheadMessage( MessageType.Regular, 0x3B2, 500449, from.NetState );
				return;
			}

			from.SendLocalizedMessage( 500452 ); // You place the gathered wool into your backpack.
			from.AddToBackpack( new Wool( Map == Map.Felucca ? 2 : 1 ) );

			NextWoolTime = DateTime.Now + TimeSpan.FromHours( 3.0 ); // TODO: Proper time delay
		}

		public override void OnThink()
		{
			base.OnThink();
			Body = ( DateTime.Now >= m_NextWoolTime ) ? 230 : 223;
		}

		[Constructable]
		public Sheep() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a sheep";
			Body = 230;
			BaseSoundID = 0xD6;

			SetStr( 19 );
			SetDex( 25 );
			SetInt( 5 );

			SetHits( 24 );
			SetMana( 0 );

			SetDamage( 1 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 6 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 5.0 );
			SetSkill( SkillName.Tactics, 6.0 );
			SetSkill( SkillName.Wrestling, 5.0 );

			Fame = 300;
			Karma = 0;

			VirtualArmor = 6;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 11.1;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override int Wool{ get{ return (Body == 230 ? 3 : 0); } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawMuttonRoast(), from);
                              corpse.AddCarvedItem(new RawMuttonSteak(), from);
                              corpse.AddCarvedItem(new RawLambLeg(2), from);
                              corpse.Carved = true; 

                              from.SendMessage( "You carve up some sheep parts." ); 
			}
                }

		public Sheep( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );

			writer.WriteDeltaTime( m_NextWoolTime );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 1:
				{
					NextWoolTime = reader.ReadDeltaTime();
					break;
				}
			}
		}
	}
}