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
	[CorpseName( "a rhino beetle corpse" )]
	public class RhinoBeetle : BaseCreature
	{
		[Constructable]
		public RhinoBeetle() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a rhino beetle";
			Body = 247;

			SetStr( 79, 92 );
			SetDex( 56, 85 );
			SetInt( 24, 31 );

			SetMana( 0 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, -25 );

			SetSkill( SkillName.MagicResist, 15.7, 25.7 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 1000;
			Karma = -1000;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 24.2;
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
						if ( weapon1 is BaseBashing )
						{
							damage *= 2;
						}
						else if ( weapon1 is BaseStaff )
						{
							damage *= 4;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseBashing )
						{
							damage *= 2;
						}
						else if ( weapon2 is BaseStaff )
						{
							damage *= 4;
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

		public override bool HasBreath{ get{ return true; } } // rock throw enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 100; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 2405; } }
		public override int BreathEffectItemID{ get{ return 0x1363; } }
		public override int BreathEffectSound{ get{ return 0x5D3; } }
		public override int BreathAngerSound{ get{ return 0x21D; } }

		public override int GetAngerSound() { return 0x21D; } 
		public override int GetIdleSound() { return 0x21D; } 
		public override int GetAttackSound() { return 0x162; } 
		public override int GetHurtSound() { return 0x163; } 
		public override int GetDeathSound() { return 0x21D; }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override void OnGaveMeleeAttack( Mobile from )
		{
			base.OnGaveMeleeAttack( from );

			if( 0.5 > Utility.RandomDouble() )
			{
                                if ( from == null )
                                     return;

                                Mobile target = from.Combatant;

                                if ( target == null )
                                     return;
                                else if ( !target.Mounted )
                                     return;

                                from.NonlocalOverheadMessage(MessageType.Emote, 0x3B2, 1049633, from.Name); // ~1_NAME~ begins to menacingly swing a bola...
                                from.Direction = from.GetDirectionTo(target);
                                from.Animate(11, 5, 1, true, false, 0);
                                from.MovingEffect(target, 0x26AC, 10, 0, false, false);

                                IMount mt = target.Mount;

                                if ( mt != null )
                                {
                                        mt.Rider = null;
                                        target.SendLocalizedMessage(1040023); // You have been knocked off of your mount!
                                        BaseMount.SetMountPrevention(target, BlockMountType.Dazed, TimeSpan.FromSeconds(3.0) );
                                }
                        }
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.ZaythalorPredator; }
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new IronIngot( Utility.RandomMinMax( 25, 35 ) ), from );
                              corpse.AddCarvedItem( new BeetleEgg( Utility.RandomMinMax( 17, 22 ) ), from );

                              from.SendMessage( "You carve up some beetle eggs and in addition some iron ingots." );
                              corpse.Carved = true; 
			}
                }

		public RhinoBeetle( Serial serial ) : base( serial )
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