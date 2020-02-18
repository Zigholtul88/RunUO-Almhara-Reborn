using System;
using Server;
using System.Collections;
using Server.ContextMenus;
using Server.Factions;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a wisp corpse" )]
	public class Wisp : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Wisp; } }

		public override Faction FactionAllegiance{ get{ return CouncilOfMages.Instance; } }
		public override Ethics.Ethic EthicAllegiance { get { return Ethics.Ethic.Hero; } }

		public override TimeSpan ReacquireDelay { get { return TimeSpan.FromSeconds( 1.0 ); } }

		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public Wisp() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a wisp";
			Body = 58;
			BaseSoundID = 466;

			SetStr( 196, 225 );
			SetDex( 196, 225 );
			SetInt( 196, 225 );

			SetHits( 236, 270 );
			SetMana( 980, 1125 );

			SetDamage( 17, 18 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.EvalInt, 80.0 );
			SetSkill( SkillName.Magery, 80.0 );
			SetSkill( SkillName.MagicResist, 80.0 );
			SetSkill( SkillName.Tactics, 80.0 );
			SetSkill( SkillName.Wrestling, 80.0 );

			Fame = 35000;
			Karma = 0;

			VirtualArmor = 40;

			AddItem( new LightSource() );

			PackGold( 47, 48 );

			PackItem( new Lolite() );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new NightSightScroll() );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
		}

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

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public Wisp( Serial serial ) : base( serial )
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