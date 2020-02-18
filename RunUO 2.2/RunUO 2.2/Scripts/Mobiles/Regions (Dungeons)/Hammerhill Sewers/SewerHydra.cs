using System;
using Server;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
        [CorpseName( "a sewer hydra corpse" )]
        public class SewerHydra : BaseCreature
        {
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

                [Constructable]
                public SewerHydra() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
                {
                        Name = "a sewer hydra";
                        Hue = 2130;
                        Body = 0x109;
                        BaseSoundID = 0x16A;

			SetStr( 125, 145 );
			SetDex( 105, 115 );
			SetInt( 20 );

			SetHits( 250, 300 );

			SetDamage( 4, 5 );

                        SetDamageType( ResistanceType.Physical, 60 );
                        SetDamageType( ResistanceType.Fire, 10 );
                        SetDamageType( ResistanceType.Cold, 10 );
                        SetDamageType( ResistanceType.Poison, 10 );
                        SetDamageType( ResistanceType.Energy, 10 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 35 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.Anatomy, 73.2, 89.1 );
			SetSkill( SkillName.MagicResist, 73.8, 82.3 );
			SetSkill( SkillName.Tactics, 66.3, 79.2 );
			SetSkill( SkillName.Wrestling, 69.1, 82.1 );

			Fame = 12000;
			Karma = -12000;

			PackGold( 15, 17 );
			PackReg( 15, 30 );

			switch ( Utility.Random( 8 ))
			{
				case 0: PackItem( new Bloodstone() ); break;
				case 1: PackItem( new Demantoid() ); break;
				case 2: PackItem( new Jasper() ); break;
				case 3: PackItem( new Lolite() ); break;
				case 4: PackItem( new Lupis() ); break;
				case 5: PackItem( new Peridot() ); break;
				case 6: PackItem( new Tsavorite() ); break;
				case 7: PackItem( new Zircon() ); break;
			}

                }
               
                public override void GenerateLoot()
                {
			      AddLoot( LootPack.Rich );
                }              
                              
                public override bool HasBreath{ get{ return true; } }

		public override int BreathPhysicalDamage{ get{ return 40; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 30; } }
	        public override int BreathPoisonDamage{ get{ return 0; } }
	        public override int BreathEnergyDamage{ get{ return 30; } }

		public override int BreathEffectHue{ get{ return 1179; } }
		public override int BreathEffectItemID{ get{ return 0x36BD; } }
		public override int BreathEffectSound{ get{ return 0x56D; } }
		public override int BreathAngerSound{ get{ return 0x5C7; } }

                public override int Hides{ get{ return 40; } }
                public override int Meat{ get{ return 19; } }
               
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

                public SewerHydra( Serial serial ) : base( serial )
                {
                }
               
                public override void Serialize( GenericWriter writer )
                {
                        base.Serialize( writer );
                       
                        writer.Write( (int) 0 ); // version
                }

                public override void Deserialize( GenericReader reader )
                {
                        base.Deserialize( reader );
                       
                        int version = reader.ReadInt();
                }
        }
}       