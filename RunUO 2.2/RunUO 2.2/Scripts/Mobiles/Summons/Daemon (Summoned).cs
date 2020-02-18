using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a daemon corpse" )]
	public class SummonedDaemon : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 100.0; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public SummonedDaemon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "daemon" );
			Body = 9;
			BaseSoundID = 357;

			SetStr( 478, 505 );
			SetDex( 82, 94 );
			SetInt( 305, 325 );

			SetHits( 572, 606 );
			SetMana( 1525, 1625 );

			SetDamage( 7, 14 );

			SetSkill( SkillName.Magery, 75.1, 82.8 );
			SetSkill( SkillName.MagicResist, 86.4, 95.0 );
			SetSkill( SkillName.Tactics, 70.8, 79.6 );
			SetSkill( SkillName.Wrestling, 64.5, 80.8 );

			VirtualArmor = 52;

			ControlSlots = 4;
		}

		public override Poison PoisonImmune{ get{ return Poison.Regular; } } // TODO: Immune to poison?

		public SummonedDaemon( Serial serial ) : base( serial )
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
