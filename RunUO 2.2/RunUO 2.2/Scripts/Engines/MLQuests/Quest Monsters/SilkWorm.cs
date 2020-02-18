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
	[CorpseName( "a silk worm corpse" )]
	public class SilkWorm : BaseCreature
	{
		[Constructable]
		public SilkWorm() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a silk worm";
			Body = 52;
			Hue = 1810;
			BaseSoundID = 0xDB;

			SetStr( 122, 134 );
			SetDex( 16, 25 );
			SetInt( 6, 10 );

			SetHits( 215, 219 );
			SetMana( 0 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Cold, 50 );

			SetResistance( ResistanceType.Physical, 20 );
			SetResistance( ResistanceType.Cold, 10 );

			SetSkill( SkillName.Wrestling, 50.1, 70.0 );
			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 44.3, 54.0 );
			SetSkill( SkillName.Wrestling, 19.3, 34.0 );

			Fame = 300;
			Karma = -300;		
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new WormSilk( amount ), from );

                              from.SendMessage( "You carve up some worm silk." );
                              corpse.Carved = true; 
			}
                }

		public override Poison PoisonImmune { get { return Poison.Lesser; } }
		public override Poison HitPoison { get { return Poison.Lesser; } }

		public SilkWorm( Serial serial ) : base( serial )
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
