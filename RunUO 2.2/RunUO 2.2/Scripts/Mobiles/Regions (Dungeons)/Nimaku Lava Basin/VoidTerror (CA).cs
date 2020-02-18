using System;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a void terror corpse" )]
	public class VoidTerror : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public VoidTerror() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a void terror";
			Body = 853;

			SetStr( 205, 230 );
			SetDex( 175, 180 );
			SetInt( 205, 210 );

			SetHits( 355, 400 );
			SetMana( 1025, 1050 );

			SetDamage( 12, 15 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.Anatomy, 35.0 );
			SetSkill( SkillName.EvalInt, 82.6, 93.2 );
			SetSkill( SkillName.Magery, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 93.2, 96.1 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 32000;
			Karma = -32000;

			AddItem( new LightSource() );

			PackGold( 575, 635 );
			PackReg( 50 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.Gems, 3 );
			AddLoot( LootPack.LowScrolls, 5 );
			AddLoot( LootPack.Potions );
		}

		public override int GetIdleSound() { return 650; }
		public override int GetAngerSound() { return 649; }
		public override int GetAttackSound() { return 651; }
		public override int GetHurtSound() { return 652; }
		public override int GetDeathSound() { return 653; }

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 50; } }

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

		public VoidTerror( Serial serial ) : base( serial )
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