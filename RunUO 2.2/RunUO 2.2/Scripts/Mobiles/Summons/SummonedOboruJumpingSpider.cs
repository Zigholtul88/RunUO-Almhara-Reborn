using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an oboru jumping spider corpse" )]
	public class SummonedOboruJumpingSpider : BaseCreature
	{
		[Constructable]
		public SummonedOboruJumpingSpider() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = "an oborunian jumping spider";
			Body = 736;
                        Hue = 1058;

			SetStr( 58, 87 );
			SetDex( 48, 61 );
			SetInt( 23, 41 );

			SetHits( 105, 120 );
			SetMana( 0 );

			SetDamage( 4, 11 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15 );
			SetResistance( ResistanceType.Poison, 20 );

			SetSkill( SkillName.MagicResist, 20.1, 30.5 );
			SetSkill( SkillName.Tactics, 31.5, 41.4 );
			SetSkill( SkillName.Wrestling, 36.9, 51.0 );

			Fame = 100;
			Karma = -100;
		}

		public override int GetIdleSound() { return 1605; } 
		public override int GetAngerSound() { return 1602; } 
		public override int GetHurtSound() { return 1604; } 
		public override int GetDeathSound() { return 1603; }

		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }

		public SummonedOboruJumpingSpider( Serial serial ) : base( serial )
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

