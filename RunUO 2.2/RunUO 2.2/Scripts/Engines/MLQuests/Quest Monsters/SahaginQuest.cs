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
	[CorpseName( "a sahagin corpse" )]
	public class SahaginQuest : BaseCreature
	{
		[Constructable]
		public SahaginQuest() : base( AIType.AI_Melee, FightMode.Closest, 6, 1, 0.2, 0.4 )
		{
			Name = "a sahagin";
			Body = 796;
			BaseSoundID = 0x275;

			SetStr( 144, 179 );
			SetDex( 75, 81 );
			SetInt( 22, 36 );

			SetHits( 2175, 3200 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.Anatomy, 20.0 );
			SetSkill( SkillName.MagicResist, 35.1, 37.2 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 2800;
			Karma = -2800;

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( Loot.RandomStatue() );
			pack.DropItem( new Pearl() );
			pack.DropItem( new TurquoiseCustom() );
			pack.DropItem( Loot.RandomGem() );

			PackItem( pack );
		}

                public override bool OnBeforeDeath()
                {
                        this.Say("GO ON! TAKE THE DAMN ROD! SEE IF I CARE!");

                        return base.OnBeforeDeath();
                }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawFishSteak( Utility.RandomMinMax( 9, 13 ) ), from );
                              corpse.AddCarvedItem( new FishScale( Utility.RandomMinMax( 12, 15 ) ), from );
                              corpse.AddCarvedItem( new StupidFishingRod(), from );

                              from.SendMessage( "You carve up raw fish steaks, some fish scales and a stupid fishing rod." ); 
                              corpse.Carved = true;
			}
                }

		public SahaginQuest( Serial serial ) : base( serial )
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
