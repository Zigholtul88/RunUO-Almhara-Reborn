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
	public class LizardmanGangMember : BaseCreature
	{
		[Constructable]
		public LizardmanGangMember() : base( AIType.AI_Melee, FightMode.Closest, 2, 1, 0.175, 0.350 )
		{
			Name = "Opethion";
			Title = "the Lizardman Gang Member"; 
			Body = Utility.RandomList( 33, 35, 36 );
			BaseSoundID = 417;

   			if ( Body == 35 ) //Short Spear 
   			{
  				DamageMin += 2;
   				DamageMax += 6;
   				RawStr += 10;
   				RawDex -= 10;
				Skills.Fencing.Base += 70;
   			}

   			if ( Body == 36 ) //Mace
   			{
  				DamageMin += 2;
   				DamageMax += 8;
   				RawStr += 10;
   				RawDex -= 10;
				Skills.Macing.Base += 70;
   			}

			SetStr( 166, 182 );
			SetDex( 114, 123 );
			SetInt( 42, 59 );

			SetHits( 3425, 3550 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 32 );
			SetResistance( ResistanceType.Fire, 8 );
			SetResistance( ResistanceType.Cold, 8 );
			SetResistance( ResistanceType.Poison, 12 );

			SetSkill( SkillName.MagicResist, 41.3, 60.2 );
			SetSkill( SkillName.Tactics, 61.7, 79.1 );
			SetSkill( SkillName.Wrestling, 59.4, 76.6 );

			Fame = 1800;
			Karma = -1800;

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

			pack.DropItem( new EnchantedShovelHead() );
			pack.DropItem( new Gold( Utility.RandomMinMax( 11, 13 ) ) );
			pack.DropItem( new Lockpick( Utility.RandomMinMax( 5, 10 ) ) );

			PackItem( pack );
		}

                public override bool OnBeforeDeath()
                {
                        this.Say("ALAS! DONE IN BY THIS FOOLISH MORTAL! I'll GET YOU NEXT TIME!");

                        return base.OnBeforeDeath();
                }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public LizardmanGangMember( Serial serial ) : base( serial )
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
