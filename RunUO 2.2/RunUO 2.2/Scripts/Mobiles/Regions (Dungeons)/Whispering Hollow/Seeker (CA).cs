using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a seeker's corpse" )]
	public class Seeker : BaseCreature
	{
		private DateTime m_NextFire;

		[Constructable]
		public Seeker() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = "a seeker";
			Body = 786;

			SetStr( 115, 137 );
			SetDex( 52, 71 );
			SetInt( 25, 39 );

			SetHits( 605, 625 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.MagicResist, 25.9, 34.4 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 11300;
			Karma = -11300;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 28.7;

			PackReg( 33, 77 );
		}

		public override void OnThink()
		{
			if ( this.Combatant != null && this.m_NextFire < DateTime.Now )
			{
				this.MovingParticles( this.Combatant, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160 );
				AOS.Damage( this.Combatant, this, Utility.Random( 40, 50 ), 0, 0, 0, 0, 100 );
				this.m_NextFire = DateTime.Now + TimeSpan.FromSeconds( 30.0 );
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new Gold( Utility.RandomMinMax( 297, 614 ) ), from );
                              corpse.AddCarvedItem( new SeekerEye(), from );

                              from.SendMessage( "You carve up gold and a seeker eye." );
                              corpse.Carved = true; 
			}
                }

		public override FoodType FavoriteFood{ get{ return FoodType.Fish; } }

		public override int GetAttackSound() { return 0x0AD; } 
		public override int GetIdleSound() { return 0x0AE; } 
		public override int GetAngerSound() { return 0x0AF; } 
		public override int GetHurtSound() { return 0x0B0; } 
		public override int GetDeathSound() { return 0x0B1; }

		public Seeker( Serial serial ) : base( serial )
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