using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a swamp tentacle corpse" )]
	public class SwampTentacle : BaseCreature
	{
		[Constructable]
		public SwampTentacle() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a swamp tentacle";
			Body = 66;
			BaseSoundID = 352;

			SetStr( 96, 120 );
			SetDex( 66, 85 );
			SetInt( 16, 30 );

			SetHits( 516, 644 );
			SetMana( 0 );

			SetDamage( 16, 22 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Poison, 60 );

			SetResistance( ResistanceType.Physical, 20 );
			SetResistance( ResistanceType.Fire, -50 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 95.1, 100.0 );
			SetSkill( SkillName.Wrestling, 95.1, 100.0 );

			Fame = 10000;
			Karma = -10000;

			PackReg( 200 );
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new Gold( Utility.RandomMinMax( 5, 508 ) ), from );
                              corpse.AddCarvedItem( new Nirnroot( Utility.RandomMinMax( 9, 14 ) ), from );
                              corpse.AddCarvedItem( new SwampVineAppendages(), from );

                              from.SendMessage( "Upon finding gold, you also carve up some nirnroot and a stash of vine appendages." );
                              corpse.Carved = true; 
			}
                }

		public SwampTentacle( Serial serial ) : base( serial )
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