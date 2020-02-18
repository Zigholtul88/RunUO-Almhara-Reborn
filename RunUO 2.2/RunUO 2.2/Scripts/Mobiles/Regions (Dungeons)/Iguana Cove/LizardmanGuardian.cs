using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a lizardman guardian corpse" )]
	public class LizardmanGuardian : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Lizardman; } }

		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}

		[Constructable]
		public LizardmanGuardian() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
			Name = NameList.RandomName( "lizardman" );
			Title = "the Lizardman Guardian"; 
			Body = Utility.RandomList( 33, 35, 36 );
			BaseSoundID = 417;

   			if ( Body == 35 ) //Short Spear 
   			{
  				DamageMin += 2;
   				DamageMax += 5;
   				RawStr += 100;
   				RawDex -= 25;
				Skills.Fencing.Base += 100;
   			}

   			if ( Body == 36 ) //Mace
   			{
  				DamageMin += 2;
   				DamageMax += 5;
   				RawStr += 75;
   				RawDex -= 15;
				Skills.Macing.Base += 100;
   			}

			SetStr( 166, 182 );
			SetDex( 114, 123 );
			SetInt( 42, 59 );

			SetHits( 225, 350 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 32 );
			SetResistance( ResistanceType.Fire, 8 );
			SetResistance( ResistanceType.Cold, 8 );
			SetResistance( ResistanceType.Poison, 12 );

			SetSkill( SkillName.MagicResist, 41.3, 60.2 );
			SetSkill( SkillName.Tactics, 81.7, 99.1 );
			SetSkill( SkillName.Wrestling, 89.4, 96.6 );

			Fame = 8500;
			Karma = -8500;

			PackGold( 230, 313 );

			switch ( Utility.Random( 9 ))
			{
				case 0: PackItem( new Agate() ); break;
				case 1: PackItem( new Beryl() ); break;
				case 2: PackItem( new ChromeDiopside() ); break;
				case 3: PackItem( new FireOpal() ); break;
				case 4: PackItem( new MoonstoneCustom() ); break;
				case 5: PackItem( new Onyx() ); break;
				case 6: PackItem( new Opal() ); break;
				case 7: PackItem( new Pearl() ); break;
				case 8: PackItem( new TurquoiseCustom() ); break;
			}
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

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs(), from );
                              corpse.AddCarvedItem( new SpinedHides(12), from );
                              corpse.AddCarvedItem( new FishScale( Utility.RandomMinMax( 4, 8 ) ), from );
                              corpse.AddCarvedItem( new SerpentScale( Utility.RandomMinMax( 7, 12 ) ), from );

                              from.SendMessage( "You carve up raw ribs, spined hides, and an assortment of various scales." );
                              corpse.Carved = true; 
			}
                }

		public LizardmanGuardian( Serial serial ) : base( serial )
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
