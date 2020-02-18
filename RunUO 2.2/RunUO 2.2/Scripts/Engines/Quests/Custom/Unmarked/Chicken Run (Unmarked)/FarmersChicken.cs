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
	[CorpseName( "a farmers chicken corpse" )]
	public class FarmersChicken : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public FarmersChicken() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a farmers chicken";
			Body = 0xD0;
			BaseSoundID = 0x6E;
                        Hue = 1153;
            
			SetStr( 150 );
			SetDex( 150 );
			SetInt( 5 );

			SetHits( 350 );
			SetMana( 0 );

			SetDamage( 7, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 1, 5 );

			SetSkill( SkillName.MagicResist, 15.0 );
			SetSkill( SkillName.Tactics, 75.0 );
			SetSkill( SkillName.Wrestling, 85.0 );

			Fame = 150;
			Karma = -150;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new PureWhiteFeather( amount ), from );

                              corpse.AddCarvedItem(new RawChicken(), from );
                              corpse.AddCarvedItem(new Feather(25), from );

                              from.SendMessage( "You carve up some raw chicken, regular feathers, and a unique feather." );
                              corpse.Carved = true;  
			}
                }

		public FarmersChicken( Serial serial ) : base( serial )
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
