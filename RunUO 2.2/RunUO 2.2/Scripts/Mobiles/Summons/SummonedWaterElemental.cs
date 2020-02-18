using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a water elemental corpse" )]
	public class SummonedWaterElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 100.0; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public SummonedWaterElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a water elemental";
			Body = 16;
			BaseSoundID = 278;

			SetStr( 126, 154 );
			SetDex( 67, 81 );
			SetInt( 102, 124 );

			SetHits( 400 );
			SetMana( 510, 620 );

			SetDamage( 7, 9 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Cold, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 70 );
			SetResistance( ResistanceType.Poison, 45 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.Magery, 66.3, 78.6 );
			SetSkill( SkillName.MagicResist, 101.6, 114.8 );
			SetSkill( SkillName.Tactics, 50.8, 67.7 );
			SetSkill( SkillName.Wrestling, 55.1, 69.1 );

			VirtualArmor = 40;

			ControlSlots = 3;
			CanSwim = true;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool BleedImmune{ get{ return true; } }

		public SummonedWaterElemental( Serial serial ) : base( serial )
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