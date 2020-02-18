using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a whipping vine corpse" )]
	public class WhippingVine : BaseCreature
	{
		[Constructable]
		public WhippingVine() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a whipping vine";
			Body = 8;
			Hue = 0x851;
			BaseSoundID = 352;

			SetStr( 251, 300 );
			SetDex( 76, 100 );
			SetInt( 26, 40 );

			SetMana( 0 );

			SetHits( 551, 600 );

			SetDamage( 4, 5 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Poison, 30 );

			SetResistance( ResistanceType.Physical, 45 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 75 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.MagicResist, 70.0 );
			SetSkill( SkillName.Tactics, 70.0 );
			SetSkill( SkillName.Wrestling, 70.0 );

			Fame = 11000;
			Karma = -11000;

			PackReg( 100 );

			if ( 0.2 >= Utility.RandomDouble() )
				PackItem( new ExecutionersCap() );
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 276, 810 ) ), from );
                              corpse.AddCarvedItem(new FertileDirt( Utility.RandomMinMax( 1, 10 ) ), from );
                              corpse.AddCarvedItem(new Vines(), from );
                              corpse.AddCarvedItem(new WhippingVineAppendages( amount ), from );

                              from.SendMessage( "You carve up gold, some dirt and a bunch of vines." );
                              corpse.Carved = true; 
			}
                }

		public WhippingVine( Serial serial ) : base( serial )
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