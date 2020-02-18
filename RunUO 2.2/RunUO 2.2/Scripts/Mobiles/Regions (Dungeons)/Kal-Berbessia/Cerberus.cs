using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a cerberus corpse" )]
	public class Cerberus : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public Cerberus(): base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a cerberus";
			Body = 250;
                        Hue = 2405;

			SetStr( 401, 450 );
			SetDex( 151, 200 );
			SetInt( 66, 76 );

			SetHits( 376, 450 );
			SetMana( 40 );

			SetDamage( 14, 18 );

			SetDamageType( ResistanceType.Physical, 90 );
			SetDamageType( ResistanceType.Cold, 5 );
			SetDamageType( ResistanceType.Energy, 5 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.Anatomy, 65.1, 72.0 );
			SetSkill( SkillName.MagicResist, 65.1, 70.0 );
			SetSkill( SkillName.Tactics, 95.1, 110.0 );
			SetSkill( SkillName.Wrestling, 97.6, 107.5 );

			Fame = 58500;
			Karma = -58500;

			PackGold( 97, 199 );

			switch( Utility.Random( 10 ) )
			{
				case 0: PackItem( new LeftArm() ); break;
				case 1: PackItem( new RightArm() ); break;
				case 2: PackItem( new Torso() ); break;
				case 3: PackItem( new Bone() ); break;
				case 4: PackItem( new RibCage() ); break;
				case 5: PackItem( new RibCage() ); break;
				case 6: PackItem( new BonePile() ); break;
				case 7: PackItem( new BonePile() ); break;
				case 8: PackItem( new BonePile() ); break;
				case 9: PackItem( new BonePile() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 5 );
			AddLoot( LootPack.Rich, 3 );
			AddLoot( LootPack.MedScrolls, 2 );
			AddLoot( LootPack.Gems, 4 );
		}

		public override int Meat { get { return 4; } }
		public override int Hides { get { return 25; } }
		public override FoodType FavoriteFood { get { return FoodType.Meat; } }

		public override bool AlwaysMurderer{ get{ return true; } }

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override bool HasBreath{ get{ return true; } } // cold breath enabled

		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 00; } }

		public override int BreathEffectHue{ get{ return 2405; } }
		public override int BreathEffectItemID{ get{ return 0x36D4; } }
		public override int BreathEffectSound{ get{ return 0x160; } }
		public override int BreathAngerSound{ get{ return 0x52D; } }

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

	  public override void OnDamagedBySpell( Mobile attacker )
	  {
		base.OnDamagedBySpell( attacker );

            if ( 0.3 >= Utility.RandomDouble() )
                this.Lightning();
	  }

        public override void OnGaveMeleeAttack( Mobile defender )
        {
            base.OnGaveMeleeAttack( defender );

            if ( 0.3 >= Utility.RandomDouble() )
                this.Lightning();
        }

        public override void OnGotMeleeAttack( Mobile attacker )
	  {
		base.OnGotMeleeAttack( attacker );

		if ( 0.3 >= Utility.RandomDouble() )
                this.Lightning();
	  }

        public void Lightning()
        {
            Map map = this.Map;

            if (map == null)
                return;

            ArrayList targets = new ArrayList();

            foreach (Mobile m in this.GetMobilesInRange(15))
            {
                if (m == this || !this.CanBeHarmful(m))
                    continue;

                if (m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team))
                    targets.Add(m);
                else if (m.Player)
                    targets.Add(m);
            }

            this.PlaySound(528);

            for (int i = 0; i < targets.Count; ++i)
            {
                Mobile m = (Mobile)targets[i];

                this.DoHarmful(m);

                AOS.Damage(m, Utility.RandomMinMax(15, 35), 0, 0, 0, 0, 100);

		    m.FixedParticles( 0x37C4, 10, 15, 1272, 0x496, 0, EffectLayer.Waist );

		    m.BoltEffect( 0x480 );

                if (m.Alive && m.Body.IsHuman && !m.Mounted)
                    m.Animate(20, 7, 1, true, false, 0); // take hit
            }
        }

		public Cerberus( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override int GetAngerSound()
		{
			return 0x52D;
		}

		public override int GetIdleSound()
		{
			return 0x52C;
		}

		public override int GetAttackSound()
		{
			return 0x52B;
		}

		public override int GetHurtSound()
		{
			return 0x52E;
		}

		public override int GetDeathSound()
		{
			return 0x52A;
		}
	}
}