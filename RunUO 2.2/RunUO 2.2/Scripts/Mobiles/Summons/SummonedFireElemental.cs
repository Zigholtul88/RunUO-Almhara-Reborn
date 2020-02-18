using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a fire elemental corpse" )]
	public class SummonedFireElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 100.0; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public SummonedFireElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a fire elemental";
			Body = 15;
			BaseSoundID = 838;

			SetStr( 129, 151 );
			SetDex( 168, 185 );
			SetInt( 101, 119 );

			SetHits( 400 );
			SetMana( 505, 595 );

			SetDamage( 7, 9 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Fire, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.Magery, 67.0, 77.4 );
			SetSkill( SkillName.MagicResist, 79.7, 94.8 );
			SetSkill( SkillName.Tactics, 80.9, 95.3 );
			SetSkill( SkillName.Wrestling, 75.8, 99.0 );

			VirtualArmor = 40;

			ControlSlots = 3;

			AddItem( new LightSource() );
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool BleedImmune{ get{ return true; } }

		public SummonedFireElemental( Serial serial ) : base( serial )
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
