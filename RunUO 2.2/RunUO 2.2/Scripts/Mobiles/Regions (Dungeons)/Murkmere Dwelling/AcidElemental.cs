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
	[CorpseName( "an acid elemental corpse" )]
	public class ToxicElemental : BaseCreature
	{
		[Constructable]
		public ToxicElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an acid elemental";
			Body = 0x9E;
			BaseSoundID = 278;

			SetStr( 326, 355 );
			SetDex( 66, 85 );
			SetInt( 271, 295 );

			SetHits( 796, 913 );

			SetDamage( 19, 25 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 50 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Fire, 40, 50 );
			SetResistance( ResistanceType.Cold, 20, 30 );
			SetResistance( ResistanceType.Poison, 10, 20 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.Anatomy, 30.3, 60.0 );
			SetSkill( SkillName.EvalInt, 70.1, 85.0 );
			SetSkill( SkillName.Magery, 70.1, 85.0 );
			SetSkill( SkillName.MagicResist, 60.1, 75.0 );
			SetSkill( SkillName.Tactics, 80.1, 90.0 );
			SetSkill( SkillName.Wrestling, 70.1, 90.0 );

			Fame = 25000;
			Karma = -25000;

                        if (Utility.RandomDouble() < 0.15 )
                                PackItem(new TreasureMap(1, Map.Malas ) );

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 1515, 2828 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new FishScale( Utility.RandomMinMax( 12, 16 ) ) );
			pack.DropItem( new Diamond(Utility.RandomMinMax( 15, 24 ) ) );

			PackItem( pack );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override double HitPoisonChance{ get{ return 0.6; } }

		public ToxicElemental( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 278;

			if ( Body == 13 )
				Body = 0x9E;

			if ( Hue == 0x4001 )
				Hue = 0;
		}
	}
}