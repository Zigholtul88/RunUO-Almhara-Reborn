//Created by Minth, Owner of Arise As The Gods.
//Modded by Zigholtul, Owner of Almhara Reborn.

using System;
using Server;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "an Lammasu corpse" )] 
	public class Lammasu : BaseCreature 
	{ 
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable] 
		public Lammasu() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = "a lammasu";
			Body = 123;
                        Hue = 1058;

			SetStr( 598, 799 );
			SetDex( 201, 267 );
			SetInt( 398, 489 );

			SetHits( 396, 489 );

			SetDamage( 14, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 45 );
			SetResistance( ResistanceType.Fire, 45 );
			SetResistance( ResistanceType.Cold, 45 );
			SetResistance( ResistanceType.Poison, -50 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.Anatomy, 50.1, 75.0 );
			SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Magery, 101.1, 105.0 );
			SetSkill( SkillName.Meditation, 90.1, 100.0 );
			SetSkill( SkillName.MagicResist, 90.1, 100.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 97.6, 100.0 );

			Fame = 9000;
			Karma = 9000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.MedScrolls, 5 );
			AddLoot( LootPack.LowScrolls, 7 );
			AddLoot( LootPack.Gems, 3 );
		}

		public override int Feathers{ get{ return 100; } }

		public override int GetAngerSound()
		{
			return 0x2F8;
		}

		public override int GetIdleSound()
		{
			return 0x2F8;
		}

		public override int GetAttackSound()
		{
			return Utility.Random( 0x2F5, 2 );
		}

		public override int GetHurtSound()
		{
			return 0x2F9;
		}

		public override int GetDeathSound()
		{
			return 0x2F7;
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			defender.Damage( Utility.Random( 20, 35 ), this );
			defender.Stam -= Utility.Random( 15, 20 );
			defender.Mana -= Utility.Random( 15, 20 );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			attacker.Damage( Utility.Random( 20, 35 ), this );
			attacker.Stam -= Utility.Random( 15, 20 );
			attacker.Mana -= Utility.Random( 15, 20 );
		}

		public Lammasu( Serial serial ) : base( serial ) 
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