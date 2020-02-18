using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Moku-myu" )]
	public class Mokumyu : BaseGuardian
	{
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public Mokumyu() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
                        // based off of umdhlebi mob stats
			Name = "Moku-myu";
			Body = 789;
                        Hue = 181;

			SetStr( 212, 271 );
			SetDex( 146, 200 );
			SetInt( 144, 185 );

			SetHits( 205, 325 );

			SetDamage( 12, 15 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.MagicResist, 65.1, 75.0 );
			SetSkill( SkillName.Tactics, 50.1, 60.0 );
			SetSkill( SkillName.Wrestling, 60.1, 80.0 );

			Fame = 0;
			Karma = 10000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
	        }

		public override int GetIdleSound() { return 0x017; }
		public override int GetAngerSound() { return 0x018; }
		public override int GetAttackSound() { return 0x01E; }
		public override int GetHurtSound() { return 0x01D; }
		public override int GetDeathSound() { return 0x01A; }

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override double HitPoisonChance{ get{ return 0.1; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 25, 42 )), from);
                              corpse.AddCarvedItem(new Nirnroot( Utility.RandomMinMax( 15, 27 )), from);
                              corpse.AddCarvedItem(new RoseOfUmdhlebi(), from);

                              from.SendMessage( "Upon finding gold, you also carve up some nirnroot and a rose of umdhlebi." );
                              corpse.Carved = true;
			}
                }

		public Mokumyu( Serial serial ) : base( serial )
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