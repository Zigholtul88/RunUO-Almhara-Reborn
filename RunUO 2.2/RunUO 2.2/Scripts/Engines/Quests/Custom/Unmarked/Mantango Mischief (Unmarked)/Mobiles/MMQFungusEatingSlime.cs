using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a slimey corpse" )]
	public class MMQFungusEatingSlime : BaseCreature
	{
		[Constructable]
		public MMQFungusEatingSlime() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Fungus Eating Slime";
			Body = 775;
			BaseSoundID = 456;

			Hue = Utility.RandomSlimeHue();

			SetStr( 500 );
			SetDex( 500 );
			SetInt( 500 );

			SetHits( 2500 );

			SetDamage( 1, 25 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Poison, 50 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 50 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Magery, 100.0 );
			SetSkill( SkillName.Poisoning, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0 );

			Fame = 1;
			Karma = -1;

			PackSlayer();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 3 );
			AddLoot( LootPack.MedScrolls, 1 );
			AddLoot( LootPack.LowScrolls, 5 );
			AddLoot( LootPack.Gems, 10 );
		}

		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new MMQSpores(), from );
                              corpse.AddCarvedItem(new MMQSpores(), from );
                              corpse.AddCarvedItem(new MMQSpores(), from );

                              from.SendMessage( "You carve up some spores." );
                              corpse.Carved = true;  
			}
                }

		public MMQFungusEatingSlime( Serial serial ) : base( serial )
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
