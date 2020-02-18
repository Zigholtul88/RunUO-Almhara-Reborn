using System;
using Server;
using Server.Misc;
using Server.Items;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an owlbear corpse" )]
	public class Owlbear : BaseCreature
	{
		private bool m_Stunning;

		[Constructable]
		public Owlbear() : base( AIType.AI_Melee, FightMode.Evil, 8, 1, 0.2, 0.4 )
		{
			Name = "an owlbear";
			Body = 371;
			BaseSoundID = 0x2EE;

			SetStr( 301, 400 );
			SetDex( 51, 70 );
			SetInt( 51, 100 );

			SetHits( 181, 240 );

			SetDamage( 9, 18 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Fire, 25 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.MagicResist, 48.2, 57.5 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 13500;
			Karma = -13500;

			PackGold( 17, 24 );

			PackItem( new Bloodstone() );
			PackItem( new FishScale( Utility.RandomMinMax( 9, 25 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new ArchProtectionScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Gems, 1 );
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool BleedImmune{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 75; } }
		public override int Hides{ get{ return 12; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !m_Stunning && 0.3 > Utility.RandomDouble() )
			{
				m_Stunning = true;

				defender.Animate( 21, 6, 1, true, false, 0 );
				this.PlaySound( 0xEE );
				defender.LocalOverheadMessage( MessageType.Regular, 0x3B2, false, "You have been stunned by a colossal blow!" );

				BaseWeapon weapon = this.Weapon as BaseWeapon;
				if ( weapon != null )
					weapon.OnHit( this, defender );

				if ( defender.Alive )
				{
					defender.Frozen = true;
					Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerStateCallback( Recover_Callback ), defender );
				}
			}
		}

		private void Recover_Callback( object state )
		{
			Mobile defender = state as Mobile;

			if ( defender != null )
			{
				defender.Frozen = false;
				defender.Combatant = null;
				defender.LocalOverheadMessage( MessageType.Regular, 0x3B2, false, "You recover your senses." );
			}

			m_Stunning = false;
		}

		public Owlbear( Serial serial ) : base( serial )
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