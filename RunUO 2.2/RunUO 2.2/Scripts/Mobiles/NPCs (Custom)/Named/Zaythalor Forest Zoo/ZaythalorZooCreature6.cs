using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a beach beetle corpse" )]
	public class ZaythalorZooCreature6 : BaseGuardian
	{
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public ZaythalorZooCreature6() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a beach beetle";
			Body = 806;
                        Hue = 251;

			SetStr( 79, 92 );
			SetDex( 56, 85 );
			SetInt( 24, 31 );

			SetMana( 0 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 17 );

			SetSkill( SkillName.MagicResist, 15.7, 25.7 );
			SetSkill( SkillName.Tactics, 39.9, 49.3 );
			SetSkill( SkillName.Wrestling, 60.1, 62.5 );

			Fame = 0;
			Karma = 10000;
		}

		public override int GetAngerSound() { return 0x21D; } 
		public override int GetIdleSound() { return 0x21D; } 
		public override int GetAttackSound() { return 0x162; } 
		public override int GetHurtSound() { return 0x163; } 
		public override int GetDeathSound()	{ return 0x21D; }

		public ZaythalorZooCreature6( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}