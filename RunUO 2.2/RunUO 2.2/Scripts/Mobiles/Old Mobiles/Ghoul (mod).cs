using System;
using System.Collections;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a ghostly corpse" )]
	public class Ghoul : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.2; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public Ghoul() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = "a ghoul";
			Body = 153;
			BaseSoundID = 0x482;

			SetStr( 78, 98 );
			SetDex( 80, 94 );
			SetInt( 38, 60 );

			SetHits( 92, 120 );
			SetMana( 0 );

			SetDamage( 7, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.MagicResist, 46.6, 58.7 );
			SetSkill( SkillName.Tactics, 45.4, 59.7 );
			SetSkill( SkillName.Wrestling, 49.4, 58.1 );

			Fame = 1500;
			Karma = -1500;
			
			VirtualArmor = 28;

			PackGold( 2, 5 );

			PackItem( new ShadowEssence( Utility.RandomMinMax( 9, 11 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new MagicUnTrapScroll() );

			PackItem( Loot.RandomWeapon() );
			PackItem( new Bone() );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

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

		public Ghoul( Serial serial ) : base( serial )
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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