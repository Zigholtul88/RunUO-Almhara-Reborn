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
	[CorpseName( "a raptor corpse" )]
	public class ZaythalorZooCreature2 : BaseGuardian
	{
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public ZaythalorZooCreature2() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a razorback raptor";
			Body = 730; 
			Hue = Utility.RandomList( 2001,2002,2003,2004,2005,2006 );

			SetStr( 98, 117 );
			SetDex( 139, 153 );
			SetInt( 120, 123 );

			SetDamage( 4, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.MagicResist, 15.7, 19.1 );
			SetSkill( SkillName.Tactics, 62.1, 63.8 );
			SetSkill( SkillName.Wrestling, 49.3, 54.4 );

			Fame = 0;
			Karma = 10000;
		}

		public override int Meat{ get{ return 7; } }
		public override int Hides{ get{ return 11; } }
		public override HideType HideType{ get{ return HideType.Horned; } }

		public override int GetIdleSound() { return 1573; } 
		public override int GetAngerSound() { return 1570; } 
		public override int GetHurtSound() { return 1572; } 
		public override int GetDeathSound()	{ return 1571; }

		public ZaythalorZooCreature2( Serial serial ) : base( serial )
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