using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a lizardman corpse" )]
	public class Lizardman : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Lizardman; } }

		[Constructable]
		public Lizardman() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "lizardman" );
			Body = Utility.RandomList( 33, 35, 36 );
			BaseSoundID = 417;

   			if ( Body == 35 ) //Short Spear 
   			{
  				DamageMin += 2;
   				DamageMax += 5;
   				RawStr += 100;
   				RawDex -= 25;
				Skills.Fencing.Base += 70;
   			}

   			if ( Body == 36 ) //Mace
   			{
  				DamageMin += 2;
   				DamageMax += 5;
   				RawStr += 75;
   				RawDex -= 15;
				Skills.Macing.Base += 70;
   			}

			SetStr( 99, 119 );
			SetDex( 89, 105 );
			SetInt( 39, 55 );

			SetHits( 216, 244 );

			SetDamage( 1, 4 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 10 );

			SetSkill( SkillName.MagicResist, 35.2, 58.9 );
			SetSkill( SkillName.Tactics, 55.1, 78.2 );
			SetSkill( SkillName.Wrestling, 55.1, 72.0 );

			Fame = 8000;
			Karma = -8000;

			PackGold( 155, 195 );
			PackReg( 15, 45 );

			PackItem( new FishScale( Utility.RandomMinMax( 2, 5 ) ) );
			PackItem( new SerpentScale( Utility.RandomMinMax( 6, 9 ) ) );

			if ( Utility.RandomDouble() < 0.01 )
        		PackItem( new BigColourfulMarble() );
		}

		public override void GenerateLoot()
		{
   			if ( Body == 35 ) //Short Spear 
   			{
				AddItem( new ShortSpear() );
   			}

   			if ( Body == 36 ) //Mace
   			{
				AddItem( new WarMace() );
   			}
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public Lizardman( Serial serial ) : base( serial )
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
