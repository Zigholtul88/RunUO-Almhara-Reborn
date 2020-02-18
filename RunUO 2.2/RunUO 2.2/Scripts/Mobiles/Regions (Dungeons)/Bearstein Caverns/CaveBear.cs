using System;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a cave bear corpse" )]
	public class CaveBear : BaseGuardian
	{
		[Constructable]
		public CaveBear() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a cave bear";
			Body = 167;
			BaseSoundID = 0xA3;

			SetStr( 82, 115 );
			SetDex( 32, 48 );
			SetInt( 26, 50 );

			SetHits( 85, 115 );
			SetMana( 0 );

			SetDamage( 4, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 29 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 15 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 25.1, 35.0 );
			SetSkill( SkillName.Tactics, 40.1, 59.9 );
			SetSkill( SkillName.Wrestling, 45.8, 63.0 );

			Fame = 800;
			Karma = 0;

			PackReg( 3, 5 );
		}

		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(), from);
                        corpse.AddCarvedItem(new Hides(10), from);
                        corpse.AddCarvedItem(new CaveBearClaw(), from);

                        from.SendMessage( "You carve up raw ribs, hides, and a cave bear claw." );
                        corpse.Carved = true; 
			}
                }

		public CaveBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}