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
	[CorpseName( "the corpse of Kluckidile" )]
	public class Kluckidile : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.DoubleStrike;
		}

		[Constructable]
		public Kluckidile() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Kluckidile";
			Body = 0xD0;
                        Hue = 1366;
			BaseSoundID = 0x6E;

			SetStr( 500 );
			SetDex( 350 );
			SetInt( 250 );

			SetHits( 3000, 3500 );

			SetDamage( 4, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.MagicResist, 40.0 );
			SetSkill( SkillName.Tactics, 150.0 );
			SetSkill( SkillName.Wrestling, 150.0 );

			Fame = 6000;
			Karma = -6000;
		}

                public override bool OnBeforeDeath()
                {
                        this.Say("BAWK BAWK! I'LL SEE YOU ON THE OTHER SIDE, MOTHERCLUCKER!");

                        return base.OnBeforeDeath();
                }

		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 15; } }
		public override MeatType MeatType{ get{ return MeatType.Bird; } }

		public Kluckidile( Serial serial ) : base( serial )
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
