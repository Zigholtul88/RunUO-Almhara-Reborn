using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal corpse" )]
	public class BoneMagi : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public BoneMagi() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a bone magi";
			Body = 148;
			BaseSoundID = 451;

			SetStr( 77, 98 );
			SetDex( 58, 75 );
			SetInt( 186, 209 );

			SetHits( 92, 120 );
			SetMana( 930, 1045 );

			SetDamage( 3, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 38 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.EvalInt, 60.4, 70.2 );
			SetSkill( SkillName.Magery, 66.9, 73.9 );
			SetSkill( SkillName.MagicResist, 56.7, 69.9 );
			SetSkill( SkillName.Tactics, 45.9, 60.0 );
			SetSkill( SkillName.Wrestling, 51.3, 57.6 );

			Fame = 8000;
			Karma = -8000;

			VirtualArmor = 38;

			PackGold( 8, 12 );

			PackReg( 5, 10 );
			PackItem( new Bone() );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new MagicArrowScroll() );

			PackItem( new Bonemeal( Utility.RandomMinMax( 13, 24 ) ) );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );
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

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from != null && from != this )
			{
				if (from is PlayerMobile)
				{
					PlayerMobile p_PlayerMobile = from as PlayerMobile;
					Item weapon1 = p_PlayerMobile.FindItemOnLayer( Layer.OneHanded );
					Item weapon2 = p_PlayerMobile.FindItemOnLayer( Layer.TwoHanded );

					if (weapon1 != null)
					{
						if (weapon1 is BaseBashing )
						{
							damage += 1;
						}
						else if (weapon1 is SkeletalAxe )
						{
							damage += 2;
						}
						else if (weapon1 is SkeletalScimitar )
						{
							damage += 2;
						}
                                    else
                                    {
							damage -= 10;
							from.SendMessage("Your weapon deals little damage to the skeletal pawn's durable bones.");
                                    }
					}

					else if (weapon2 != null)
					{
						if (weapon2 is BaseBashing )
						{
							damage += 1;
						}
						else if (weapon2 is SkeletalAxe )
						{
							damage += 2;
						}
						else if (weapon2 is SkeletalScimitar )
						{
							damage += 2;
						}
                                    else
                                    {
							damage -= 10;
							from.SendMessage("Your weapon deals little damage to the skeletal pawn's durable bones.");
                                    }
					}
				}
			}
		}

		public BoneMagi( Serial serial ) : base( serial )
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
