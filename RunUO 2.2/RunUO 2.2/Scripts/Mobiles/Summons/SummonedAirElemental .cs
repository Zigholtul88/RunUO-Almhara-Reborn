using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an air elemental corpse" )]
	public class SummonedAirElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 100.0; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public SummonedAirElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an air elemental";
			Body = 13;
			Hue = 0x4001;
			BaseSoundID = 655;

			SetStr( 126, 155 );
			SetDex( 166, 185 );
			SetInt( 102, 125 );

			SetHits( 400 );
			SetMana( 510, 605 );

			SetDamage( 8, 10 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 35 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 70 );

			SetSkill( SkillName.Magery, 67.1, 78.4 );
			SetSkill( SkillName.MagicResist, 63.8, 74.8 );
			SetSkill( SkillName.Tactics, 62.5, 78.8 );
			SetSkill( SkillName.Wrestling, 66.9, 82.0 );

			VirtualArmor = 40;
			ControlSlots = 3;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool BleedImmune{ get{ return true; } }

		public override int GetAttackSound() { return 264; } 
		public override int GetAngerSound() { return 265; } 
		public override int GetDeathSound() { return 267; }
		public override int GetHurtSound() { return 266; } 
		public override int GetIdleSound() { return 263; } 

		public SummonedAirElemental( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 655;
		}
	}
}