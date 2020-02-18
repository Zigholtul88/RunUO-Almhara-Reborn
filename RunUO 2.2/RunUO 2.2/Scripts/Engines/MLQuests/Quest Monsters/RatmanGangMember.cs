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
	public class RatmanGangMember : BaseCreature
	{
		[Constructable]
		public RatmanGangMember() : base( AIType.AI_Melee, FightMode.Closest, 2, 1, 0.3, 0.6 )
		{
			Name = "Xakshuku";
			Title = "the Ratman Gang Member"; 
			Body = Utility.RandomList( 42, 44, 45 );
			BaseSoundID = 437;

   			if ( Body == 44 ) //Axe
   			{
  				DamageMin += 2;
   				DamageMax += 6;
   				RawStr += 10;
   				RawDex -= 10;
				Skills.Lumberjacking.Base += 75;
   			}

   			if ( Body == 45 ) //Sword
   			{
  				DamageMin += 2;
   				DamageMax += 8;
   				RawStr += 10;
   				RawDex -= 10;
				Skills.Swords.Base += 75;
   			}

			SetStr( 150, 175 );
			SetDex( 105, 135 );
			SetInt( 87, 92 );

			SetHits( 2225, 2465 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 73.2, 89.1 );
			SetSkill( SkillName.MagicResist, 73.8, 82.3 );
			SetSkill( SkillName.Tactics, 93.3, 99.2 );
			SetSkill( SkillName.Wrestling, 89.1, 92.1 );

			Fame = 2500;
			Karma = -2500;

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

			pack.DropItem( new EnchantedShovelHandle() );
			pack.DropItem( new Gold( Utility.RandomMinMax( 11, 13 ) ) );
			pack.DropItem( new Lockpick( Utility.RandomMinMax( 5, 10 ) ) );

			PackItem( pack );
		}

                public override bool OnBeforeDeath()
                {
                        this.Say("MARK MY WORDS, MORTAL! THIS WILL NOT BE THE LAST TIME WE MEET!");

                        return base.OnBeforeDeath();
                }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public RatmanGangMember( Serial serial ) : base( serial )
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
