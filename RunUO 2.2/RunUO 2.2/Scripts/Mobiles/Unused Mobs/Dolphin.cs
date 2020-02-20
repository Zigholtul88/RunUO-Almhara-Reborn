using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a dolphin corpse" )]
	public class Dolphin : BaseCreature
	{
		[Constructable]
		public Dolphin() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a dolphin";
			Body = 0x97;
			BaseSoundID = 0x8A;

			SetStr( 24, 42 );
			SetDex( 73, 83 );
			SetInt( 97, 110 );

			SetHits( 30, 54 );

			SetDamage( 3, 6 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 16 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 15.1, 18.8 );
			SetSkill( SkillName.Tactics, 20.8, 26.2 );
			SetSkill( SkillName.Wrestling, 23.6, 28.5 );

			Fame = 500;
			Karma = 2000;

			VirtualArmor = 16;

			CanSwim = true;
			CantWalk = true;
		}

		public override int Meat { get { return 1; } }

		public Dolphin( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( from.AccessLevel >= AccessLevel.GameMaster )
				Jump();
		}

		public virtual void Jump()
		{
			if( Utility.RandomBool() )
				Animate( 3, 16, 1, true, false, 0 );
			else
				Animate( 4, 20, 1, true, false, 0 );
		}

		public override void OnThink()
		{
			if( Utility.RandomDouble() < .005 ) // slim chance to jump
				Jump();

			base.OnThink();
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
	}
}