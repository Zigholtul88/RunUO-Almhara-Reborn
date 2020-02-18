using System;
using System.Collections;
using Server.Items;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a patrol unit corpse" )]
	public class StoneBurrowPatrolUnit : BaseCreature
	{
		public override bool IsScaredOfScaryThings{ get{ return false; } }
		public override bool IsScaryToPets{ get{ return true; } }

		public override bool IsBondable{ get{ return false; } }

		public override FoodType FavoriteFood { get { return FoodType.None; } }

		[Constructable]
		public StoneBurrowPatrolUnit() : this( false, 1.0 )
		{
		}

		[Constructable]
		public StoneBurrowPatrolUnit( bool summoned, double scalar ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8 )
		{
			Name = "a stone burrow patrol unit";
			Body = 0x2F4;
                        Hue = 2401;

			SetStr( (int)(158*scalar), (int)(201*scalar) );
			SetDex( (int)(56*scalar), (int)(70*scalar) );
			SetInt( (int)(51*scalar), (int)(62*scalar) );

			SetHits( (int)(215*scalar), (int)(220*scalar) );

			SetDamage( (int)(8*scalar), (int)(12*scalar) );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, (int)(30*scalar), (int)(35*scalar) );

			if ( summoned )
				SetResistance( ResistanceType.Energy, (int)(45*scalar), (int)(50*scalar) );
			else
				SetResistance( ResistanceType.Energy, (int)(100*scalar) );

			SetResistance( ResistanceType.Fire, (int)(10*scalar), (int)(20*scalar) );
			SetResistance( ResistanceType.Cold, (int)(15*scalar), (int)(20*scalar) );
			SetResistance( ResistanceType.Poison, (int)(10*scalar), (int)(20*scalar) );

			SetSkill( SkillName.MagicResist, (46.2*scalar), (55.5*scalar) );
			SetSkill( SkillName.Tactics, (50.1*scalar), (68.8*scalar) );
			SetSkill( SkillName.Wrestling, (60.3*scalar), (71.3*scalar) );

			if ( summoned )
			{
				Fame = 10;
				Karma = 10;
			}
			else
			{
				Fame = 12000;
				Karma = -12000;
			}

			ControlSlots = 2;

			AddItem( new LightSource() );

			PackGold( 218, 322 );
			PackReg( 35, 58 );

			PackItem( new CavernPatrolUnitConstructionKit() );

			PackItem( new BlackGear( Utility.RandomMinMax( 5, 8 ) ) );
			PackItem( new BronzeGear( Utility.RandomMinMax( 5, 8 ) ) );
			PackItem( new CrimsonGear( Utility.RandomMinMax( 5, 8 ) ) );

			PackItem( new PowerCrystal() );

			PackItem( new EnergyBoltScroll() );

			switch ( Utility.Random( 5 ) )
			{
				case 0: PackItem( new ChromeDiopside() ); break;
				case 1: PackItem( new Ruby() ); break;
				case 2: PackItem( new Chrysoberyl() ); break;
				case 3: PackItem( new Bloodstone() ); break;
				case 4: PackItem( new Topaz() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );
		}

                public override bool HasBreath{ get{ return true; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }

		public override int BreathEffectHue{ get{ return 1266; } }
		public override int BreathEffectItemID{ get{ return 14361; } }
		public override int BreathEffectSound{ get{ return 0x229; } }
		public override int BreathAngerSound{ get{ return 0x2F4; } }

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override int GetAngerSound()  { return 0x26C; }
		public override int GetAttackSound()  { return 0x23B; }
		public override int GetDeathSound() { return 0x211; }
		public override int GetHurtSound()  { return 0x140; }
		public override int GetIdleSound()  { return 0xFD; }

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
						if ( weapon1 is BaseBashing )
						{
							damage *= 25;
						}
                                                else
                                                {
							damage -= 35;
							from.SendMessage("Your weapon deals little damage to the patrol unit.");
                                                }
					}

					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseBashing )
						{
							damage *= 25;
						}
                                                else
                                                {
							damage -= 35;
							from.SendMessage("Your weapon deals little damage to the patrol.");
                                                }
					}
				}
			}
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( Controlled || Summoned )
			{
				Mobile master = ( this.ControlMaster );

				if ( master == null )
					master = this.SummonMaster;

				if ( master != null && master.Player && master.Map == this.Map && master.InRange( Location, 20 ) )
				{
					if ( master.Mana >= amount )
					{
						master.Mana -= amount;
					}
					else
					{
						amount -= master.Mana;
						master.Mana = 0;
						master.Damage( amount );
					}
				}
			}

			base.OnDamage( amount, from, willKill );
		}

		public StoneBurrowPatrolUnit( Serial serial ) : base( serial )
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
