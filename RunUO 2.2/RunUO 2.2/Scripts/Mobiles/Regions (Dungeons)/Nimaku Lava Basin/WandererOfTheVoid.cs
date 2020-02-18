using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a wanderer of the void corpse" )]
	public class WandererOfTheVoid : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Wisp; } }

		[Constructable]
		public WandererOfTheVoid() : base( AIType.AI_Mage, FightMode.Closest, 8, 1, 0.2, 0.4 )
		{
			Name = "a wanderer of the void";
			Body = 316;
			BaseSoundID = 377;

			SetStr( 111, 200 );
			SetDex( 101, 125 );
			SetInt( 301, 390 );

			SetHits( 176, 216 );
                        SetMana( 935, 1045 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Cold, 15 );
			SetDamageType( ResistanceType.Energy, 85 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.EvalInt, 60.1, 70.0 );
			SetSkill( SkillName.Magery, 60.1, 70.0 );
			SetSkill( SkillName.Meditation, 60.1, 70.0 );
			SetSkill( SkillName.MagicResist, 50.1, 75.0 );
			SetSkill( SkillName.Tactics, 60.1, 70.0 );
			SetSkill( SkillName.Wrestling, 60.1, 70.0 );

			Fame = 12000;
			Karma = -12000;

			AddItem( new LightSource() );

			PackGold( 225, 335 );
			PackReg( 20 );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool CanRummageCorpses{ get{ return true; } }

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
			AddLoot( LootPack.LowScrolls, 2 );
		}

		public WandererOfTheVoid( Serial serial ) : base( serial )
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