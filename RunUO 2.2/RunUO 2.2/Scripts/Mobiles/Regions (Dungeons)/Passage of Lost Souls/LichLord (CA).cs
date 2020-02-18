using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Targeting;
using Server.Spells;
using Server.Spells.Fourth;

namespace Server.Mobiles
{
	[CorpseName( "a liche's corpse" )]
	public class LichLord : BaseSpecialCreature
	{
                public override bool DoesTripleBolting { get { return true; } }
                public override double TripleBoltingChance { get { return 0.250; } }

		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

	        public override bool AlwaysMurderer { get { return true; } }

		[Constructable]
		public LichLord() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ancient lich" );
			Title = "the lich lord"; 
			Body = 79;
			BaseSoundID = 412;

			SetStr( 419, 496 );
			SetDex( 146, 164 );
                        SetInt( 571, 646 );

			SetHits( 500, 606 );
                        SetMana( 2855, 3230 );

			SetDamage( 25, 30 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Cold, 60 );
			SetDamageType( ResistanceType.Energy, 40 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.EvalInt, 120.0 );
			SetSkill( SkillName.Magery, 92.0, 99.4 );
			SetSkill( SkillName.MagicResist, 158.2, 182.2 );
			SetSkill( SkillName.Meditation, 30.2, 45.5 );
			SetSkill( SkillName.Tactics, 50.8, 69.1 );
			SetSkill( SkillName.Wrestling, 65.8, 81.8 );

			Fame = 38000;
			Karma = -38000;

			VirtualArmor = 50;

			PackItem( new GnarledStaff() );
			PackReg( 50, 80 );

			PackGold( 58, 72 );

			PackItem( new Jasper() );

			PackItem( new LichDust( Utility.RandomMinMax( 7, 10 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new PolymorphScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.MedScrolls, 3 );
			AddLoot( LootPack.Gems, 2 );
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

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

		public override void OnGotMeleeAttack( Mobile attacker )
		{
	              base.OnGotMeleeAttack( attacker );

                      Mobile target = attacker;

                      if( target is BaseCreature && ((BaseCreature)target).Controlled )
                      target = ((BaseCreature)target).ControlMaster;

                      if( target == null )
                      target = attacker;

                      if( DoesTripleBolting && TripleBoltingChance >= Utility.RandomDouble() )
                      TripleBolt( target );

                      if (0.25 >= Utility.RandomDouble())
		      Ability.CrimsonMeteor( this, 50 );

                      if (0.50 >= Utility.RandomDouble())
		      DoSummonUndead( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
		      base.OnGaveMeleeAttack( defender );

                      if (0.50 >= Utility.RandomDouble())
		      DoSummonUndead( defender );
		}

                public override void OnDamagedBySpell( Mobile attacker )
                {
                      base.OnDamagedBySpell( attacker );

                      Mobile target = attacker;

                      if( target is BaseCreature && ((BaseCreature)target).Controlled )
                      target = ((BaseCreature)target).ControlMaster;

                      if( target == null )
                      target = attacker;

                      if( DoesTripleBolting && TripleBoltingChance >= Utility.RandomDouble() )
                      TripleBolt( target );

                      if (0.50 >= Utility.RandomDouble())
		      DoSummonUndead( target );
                }

		public void DoSummonUndead( Mobile target )
		{
			if ( 0.1 >= Utility.RandomDouble() ) // 10% chance to spawn undead
				SpawnMobiles( target );
		}

		public void SpawnMobiles( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int red = 0;

			foreach ( Mobile m in this.GetMobilesInRange( 10 ) )
			{
				if ( m is BoneMagi || m is BoneKnight || m is BoneMagi )
					++red;
			}

			if ( red < 5 )
			{
				int newblue = Utility.RandomMinMax( 1, 2 );

				for ( int i = 0; i < newblue; ++i )
				{
					BaseCreature yellow;

					switch ( Utility.Random( 2 ) )
					{
						default:
						case 0: yellow = new BoneMagi(); break;
						case 1: yellow = new BoneKnight(); break;
					}

					yellow.Team = this.Team;

					bool validLocation = false;
					Point3D loc = this.Location;

					for ( int j = 0; !validLocation && j < 10; ++j )
					{
						int x = X + Utility.Random( 3 ) - 1;
						int y = Y + Utility.Random( 3 ) - 1;
						int z = map.GetAverageZ( x, y );

						if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
							loc = new Point3D( x, y, Z );
						else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
							loc = new Point3D( x, y, z );
					}

					yellow.MoveToWorld( loc, map );
					yellow.Combatant = target;
	                                yellow.PlaySound( yellow.GetIdleSound() );
	                                yellow.FixedParticles( 0x3728, 1, 10, 9910, EffectLayer.Head );
				}
			}
		}

	    public LichLord( Serial serial ) : base( serial )
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
