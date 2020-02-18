using System;
using Server;
using System.Collections;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an orcish corpse" )]
	public class StoneBurrowOrcMiner : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		[Constructable]
		public StoneBurrowOrcMiner() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
                        Name = "a stone burrow orc miner";
			Body = 17;
                        Hue = 1437;
			BaseSoundID = 0x45A;

			SetStr( 148, 194 );
			SetDex( 48, 60 );
			SetInt( 49, 65 );

			SetHits( 200, 234 );
			SetMana( 0 );

			SetDamage( 3, 6 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 32 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.MagicResist, 54.7, 71.5 );
			SetSkill( SkillName.Tactics, 57.8, 77.0 );
			SetSkill( SkillName.Wrestling, 56.3, 71.9 );

			Fame = 9000;
			Karma = -9000;

			AddItem( new LightSource() );

			PackGold( 214, 319 );
			PackReg( 3, 8 );

			PackItem( new Pickaxe() );
			PackItem( new ThighBoots() );

			PackItem( new Lantern() );
			PackItem( new Pitcher( BeverageType.Water ) );

			PackItem( new FishScale( Utility.RandomMinMax( 6, 9 ) ) );

			PackItem( new ShadowIronIngot( Utility.RandomMinMax( 5, 15 ) ) );

			if ( 0.25 > Utility.RandomDouble() )
				PackItem( new CavernPatrolUnitConstructionKit() );

			PackItem( new BlackGear( Utility.RandomMinMax( 25, 48 ) ) );
			PackItem( new BronzeGear( Utility.RandomMinMax( 25, 48 ) ) );
			PackItem( new CrimsonGear( Utility.RandomMinMax( 25, 48 ) ) );

                        if (Utility.RandomDouble() < 0.1 )
                                PackItem(new TreasureMap(2, Map.Malas ) );

			switch ( Utility.Random( 5 ) )
			{
				case 0: PackItem( new ChromeDiopside() ); break;
				case 1: PackItem( new Peridot() ); break;
				case 2: PackItem( new Demantoid() ); break;
				case 3: PackItem( new Bloodstone() ); break;
				case 4: PackItem( new Jasper() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 3 );
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs(), from );
                              corpse.AddCarvedItem( new OrcHead(), from );

                              from.SendMessage( "You carve up a raw rib and the creatures head." );
                              corpse.Carved = true; 
			}
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
			get{ return OppositionGroup.SavagesAndOrcs; }
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( m.Player && m.FindItemOnLayer( Layer.Helm ) is OrcishKinMask )
				return false;

			return base.IsEnemy( m );
		}

		public override void AggressiveAction( Mobile aggressor, bool criminal )
		{
			base.AggressiveAction( aggressor, criminal );

			Item item = aggressor.FindItemOnLayer( Layer.Helm );

			if ( item is OrcishKinMask )
			{
				AOS.Damage( aggressor, 50, 0, 100, 0, 0, 0 );
				item.Delete();
				aggressor.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
				aggressor.PlaySound( 0x307 );
			}
		}

		public StoneBurrowOrcMiner( Serial serial ) : base( serial )
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
