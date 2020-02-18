using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a slimey corpse" )]
	public class Slime : BaseCreature
	{
		[Constructable]
		public Slime() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = "a slime";
			Body = 51;
			BaseSoundID = 456;

			Hue = Utility.RandomSlimeHue();

			SetStr( 91, 110 );
			SetDex( 91, 115 );
			SetInt( 26, 50 );

			SetHits( 455, 566 );

			SetDamage( 4, 5 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 60 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.Poisoning, 30.7, 49.6 );
			SetSkill( SkillName.MagicResist, 15.1, 19.9 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 2500;
			Karma = -2500;

			PackGold( 213, 316 );
			PackReg( 42, 76 );
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
						if ( weapon1 is BaseEquipableLight )
						{
							damage *= 100;
						}
						else if ( weapon1 is BaseAxe )
						{
							damage += 0;
						}
						else if ( weapon1 is BaseBashing )
						{
							damage += 0;
						}
						else if ( weapon1 is BaseKnife )
						{
							damage += 0;
						}
						else if ( weapon1 is BasePoleArm )
						{
							damage += 0;
						}
						else if ( weapon1 is BaseRanged )
						{
							damage += 0;
						}
						else if ( weapon1 is BaseSpear )
						{
							damage += 0;
						}
						else if ( weapon1 is BaseStaff )
						{
							damage += 0;
						}
						else if ( weapon1 is BaseSword )
						{
							damage += 0;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseEquipableLight )
						{
							damage *= 100;
						}
						else if ( weapon2 is BaseAxe )
						{
							damage += 0;
						}
						else if ( weapon2 is BaseBashing )
						{
							damage += 0;
						}
						else if ( weapon2 is BaseKnife )
						{
							damage += 0;
						}
						else if ( weapon2 is BasePoleArm )
						{
							damage += 0;
						}
						else if ( weapon2 is BaseRanged )
						{
							damage += 0;
						}
						else if ( weapon2 is BaseSpear )
						{
							damage += 0;
						}
						else if ( weapon2 is BaseStaff )
						{
							damage += 0;
						}
						else if ( weapon2 is BaseSword )
						{
							damage += 0;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
				}
			}
		}

		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }
		public override Poison HitPoison{ get{ return Poison.Lesser; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish | FoodType.FruitsAndVegies | FoodType.GrainsAndHay | FoodType.Eggs; } }

		public override bool HasBreath{ get{ return true; } } // green sludge enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 163; } }
		public override int BreathEffectItemID{ get{ return 0x113E; } }
		public override int BreathEffectSound{ get{ return 0x1CA; } }
		public override int BreathAngerSound{ get{ return 0x0C9; } }

                public override void OnGotMeleeAttack(Mobile attacker)
                {
                        if ( attacker != this && this.Hits > 1 )
                        {
                                Mobile spawn = new Slime();
                                spawn.MoveToWorld(this.Location, this.Map);
                                this.Hits /= 2;
                                spawn.Hits = this.Hits;

                                //this.SetHits(this.m_HitsMax / 2);
                                //spawn.SetHits(this.m_HitsMax);

                                Say("The Slime splits into two!");
                         }

                         base.OnGotMeleeAttack( attacker );
                }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new GreenSlimeVial( amount ), from );

                              from.SendMessage( "You carve up the corpse and notice a vial of green slime." );
                              corpse.Carved = true; 
			}
                }

		public Slime( Serial serial ) : base( serial )
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

