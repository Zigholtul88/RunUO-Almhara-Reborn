using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a deer corpse" )]
	public class Hind : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.2; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public Hind() : base( AIType.AI_Animal, FightMode.Aggressor, 6, 1, 0.1, 0.2 )
		{
			CurrentSpeed = BoostedSpeed;
			RangePerception = 25;

			Name = "a hind";
			Body = 0xED;

			SetStr( 21, 50 );
			SetDex( 48, 77 );
			SetInt( 17, 46 );

			SetMana( 100 );

			SetDamage( 1 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 8 );
			SetResistance( ResistanceType.Cold, 5 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 15.0 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 300;
			Karma = -100;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 23.1;
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
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override int GetAttackSound() { return 0x82; }
		public override int GetHurtSound() { return 0x83; } 
		public override int GetDeathSound() { return 0x84; }

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

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new DeerHead(), from);
                              corpse.AddCarvedItem(new RawGroundVenison(), from);
                              corpse.AddCarvedItem(new RawVenisonRoast(), from);
                              corpse.AddCarvedItem(new RawVenisonSteak(), from);
                              corpse.AddCarvedItem(new Hides(8), from);
                              corpse.Carved = true; 

                              from.SendMessage( "You carve up some hides and deer parts." ); 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.ZaythalorPredator; }
		}

		public Hind(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}