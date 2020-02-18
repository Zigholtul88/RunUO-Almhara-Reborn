using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of a gang member" )]
	public class GoblinGangMember : BaseCreature
	{
		[Constructable]
		public GoblinGangMember() : base( AIType.AI_Melee, FightMode.Closest, 2, 1, 0.3, 0.6 )
		{
			Name = "Yiff-yaff";
			Title = "the Goblin Gang Member"; 
			Body = 723;

			SetStr( 225, 235 );
			SetDex( 165, 175 );
			SetInt( 105, 110 );

			SetHits( 4650, 5785 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.Anatomy, 82.9, 85.2 );
			SetSkill( SkillName.Tactics, 182.6, 189.3 );
			SetSkill( SkillName.Wrestling, 184.1, 185.8 );

			Fame = 3000;
			Karma = -3000;

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new ChickenLeg() ); break;
				case 1: PackItem( new CookedBird() ); break;
				case 2: PackItem( new FishSteak() ); break;
				case 3: PackItem( new LambLeg() ); break;
				case 4: PackItem( new Ribs() ); break;
				case 5: PackItem( new Sausage() ); break;
			}

			Container pack = new Backpack();

			pack.DropItem( new EnchantedShovelArm() );
			pack.DropItem( new Gold( Utility.RandomMinMax( 11, 13 ) ) );
			pack.DropItem( new Lockpick( Utility.RandomMinMax( 5, 10 ) ) );

			PackItem( pack );
		}

                public override bool OnBeforeDeath()
                {
                        this.Say("THIS CAN'T BE THE END OF ME! DEFEATED BY A SMALL CHILD!");

                        return base.OnBeforeDeath();
                }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public GoblinGangMember( Serial serial ) : base( serial )
		{
		}

		public override int GetAttackSound() { return 1533; }
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
