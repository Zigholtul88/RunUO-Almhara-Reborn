using System;
using System.Collections;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a goblin corpse" )]
	public class MinorGoblin : BaseCreature
	{
		[Constructable]
		public MinorGoblin() : base( AIType.AI_Thief, FightMode.Closest, 8, 1, 0.175, 0.350 )
		{
			Name = "a minor goblin";
			Body = 723;

			SetStr( 23, 31 );
			SetDex( 16, 20 );
			SetInt( 2 );

			SetHits( 35, 50 );
			SetMana( 0 );

			SetDamage( 3, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 8 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.ArmsLore, 80.3, 80.4 );
			SetSkill( SkillName.MagicResist, 10.1, 12.7 );
			SetSkill( SkillName.Stealing, 96.9, 99.9 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 80.3, 80.4 );

			Fame = 200;
			Karma = -200;

			PackItem( new FishScale( Utility.RandomMinMax( 1, 2 ) ) );

			if ( 0.03 > Utility.RandomDouble() )
				PackItem( new ShortSpear() );
		}

		public override int Meat{ get{ return 1; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.ZaythalorPredator; }
		}

		public MinorGoblin( Serial serial ) : base( serial )
		{
		}

		public override int GetAttackSound() { return 1533; } 
		public override int GetAngerSound() { return 1533; } 
		public override int GetHurtSound() { return 1535; } 
		public override int GetDeathSound() { return 1534; }

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
