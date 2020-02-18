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
	[CorpseName( "a minotaur corpse" )]
	public class AutumnwoodMinotaur : BaseCreature
	{
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
		public AutumnwoodMinotaur() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) // NEED TO CHECK
		{
   			if ( Flying ) // Frenzy
   			{
			        CurrentSpeed = BoostedSpeed;
			        RangePerception = 200;

  				DamageMin += 5;
   				DamageMax += 10;

			        SetResistance( ResistanceType.Physical, 45 );
			        SetResistance( ResistanceType.Fire, 30 );
			        SetResistance( ResistanceType.Cold, 30 );
			        SetResistance( ResistanceType.Poison, 15 );
			        SetResistance( ResistanceType.Energy, 15 );

			        SetSkill( SkillName.Anatomy, 20.0 );
			        SetSkill( SkillName.Healing, 45.8, 60.2 );
			        SetSkill( SkillName.MagicResist, 45.0, 50.0 );
			        SetSkill( SkillName.Tactics, 95.0, 99.8 );
			        SetSkill( SkillName.Wrestling, 95.0, 99.8 );
   			}

			Name = "a minotaur of the Autumnwood";
			Body = 263;

			SetStr( 129, 159 );
			SetDex( 89, 98 );
			SetInt( 29, 47 );

			SetHits( 125, 150 );
			SetMana( 100 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 36 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.MagicResist, 38.9, 45.5 );
			SetSkill( SkillName.Tactics, 48.2, 61.9 );
			SetSkill( SkillName.Wrestling, 49.4, 57.6 );

			Fame = 2500;
			Karma = -2500;

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 205, 398 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new FishScale( Utility.RandomMinMax( 6, 11 ) ) );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( new Onyx() );

			PackItem( pack );

			switch ( Utility.Random( 3 ))
			{
				case 0: AddItem( new CheckerBoard() ); break;
				case 1: AddItem( new Chessboard() ); break;
				case 2: AddItem( new Dices() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );

			if ( 0.06 > Utility.RandomDouble() )
			{
				switch ( Utility.Random( 5 ) )
				{
					case 0: PackItem( new AgilityWand() ); break;
					case 1: PackItem( new CunningWand() ); break;
					case 2: PackItem( new CureWand() ); break;
					case 3: PackItem( new HarmWand() ); break;
					case 4: PackItem( new StrengthWand() ); break;
				}
			}
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from != null && from != this )
			{
				if ( from is PlayerMobile )
				{
					PlayerMobile p_PlayerMobile = from as PlayerMobile;
					Item weapon1 = p_PlayerMobile.FindItemOnLayer( Layer.OneHanded );
					Item weapon2 = p_PlayerMobile.FindItemOnLayer( Layer.TwoHanded );

					if ( weapon1 != null )
					{
						if ( weapon1 is BaseAxe )
						{
							damage *= 4;
						}
						else if ( weapon1 is BasePoleArm )
						{
							damage *= 4;
						}
						else if ( weapon1 is BaseSword )
						{
							damage *= 2;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseAxe )
						{
							damage *= 4;
						}
						else if ( weapon2 is BasePoleArm )
						{
							damage *= 4;
						}
						else if ( weapon2 is BaseSword )
						{
							damage *= 2;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
				}
			}
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 15; } }

		public override int GetAttackSound() { return 0x599; } 
		public override int GetIdleSound() { return 0x596; } 
		public override int GetAngerSound() { return 0x597; } 
		public override int GetHurtSound() { return 0x59a; } 
		public override int GetDeathSound() { return 0x59c; }

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{      
 			if ( Utility.RandomDouble() < 0.25 )
                        {
                                Flying = true; // Frenzy
			        CurrentSpeed = BoostedSpeed;
			        RangePerception = 200;
			        PlaySound( 0x597 );
			        this.Combatant = from;
				from.SendMessage( "The autumnwood minotaur goes into a frenzy" );
                        }

			base.OnDamage( amount, from, willKill );
                }

		public override void OnHarmfulSpell( Mobile from )
		{
 			if ( Utility.RandomDouble() < 0.25 )
                        {
                                Flying = false;
			        CurrentSpeed = PassiveSpeed;
			        PlaySound( 0x59a );
                        }

                        if ( Utility.RandomDouble() < 0.25 )
                        {
                                Flying = true; // Frenzy
			        CurrentSpeed = BoostedSpeed;
			        RangePerception = 200;
			        PlaySound( 0x597 );
			        this.Combatant = from;
				from.SendMessage( "The autumnwood minotaur goes into a frenzy" );
                        }
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new PeltedMinotaurFur(), from );

                              from.SendMessage( "You carve up some minotaur parts." );
                              corpse.Carved = true; 
			}
                }

		public AutumnwoodMinotaur( Serial serial ) : base( serial )
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
