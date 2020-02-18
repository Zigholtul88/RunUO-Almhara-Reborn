using System;
using Server;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an eviserated corpse" )]
	public class DerangedEviserator : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.Dismount : WeaponAbility.ParalyzingBlow;
		}

		[Constructable]
		public DerangedEviserator() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a deranged eviserator";
			Body = 315;
			Hue = 2115;

			SetStr( 347, 389 );
			SetDex( 148, 167 );
			SetInt( 221, 260 );

			SetHits( 362, 435 );

			SetDamage( 12, 15 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 70 );

			SetSkill( SkillName.MagicResist, 7.1, 15.0 );
			SetSkill( SkillName.Tactics, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 28000;
			Karma = -28000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
			AddLoot( LootPack.Gems );
	        }

		public override int GetIdleSound() { return 0x34C; }
		public override int GetAngerSound() { return 0x34C; }
		public override int GetAttackSound() { return 0x34C; }
		public override int GetHurtSound()  { return 0x354; } 
		public override int GetDeathSound() { return 0x354; } 

		public DerangedEviserator( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 660 )
				BaseSoundID = -1;
		}
	}
}