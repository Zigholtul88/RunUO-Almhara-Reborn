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
	[CorpseName( "a darkrose corpse" )]
	public class ZaythalorZooCreature1 : BaseGuardian
	{
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public ZaythalorZooCreature1() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8 )
		{
			Name = "a darkrose";
			Body = 789;
                        Hue = 1172; 
			BaseSoundID = 352;

			SetStr( 102, 131 );
			SetDex( 67, 86 );
			SetInt( 32, 56 );

			SetDamage( 3, 6 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Poison, 30 );

			SetResistance( ResistanceType.Physical, 15 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.MagicResist, 59.2, 68.2 );
			SetSkill( SkillName.Tactics, 47.5, 57.9 );
			SetSkill( SkillName.Wrestling, 56.8, 63.7 );

			Fame = 0;
			Karma = 10000;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }

		public override int GetAngerSound()
		{
			return 353;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public ZaythalorZooCreature1( Serial serial ) : base( serial )
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

			if ( BaseSoundID == -1 )
				BaseSoundID = 352;
		}
	}
}