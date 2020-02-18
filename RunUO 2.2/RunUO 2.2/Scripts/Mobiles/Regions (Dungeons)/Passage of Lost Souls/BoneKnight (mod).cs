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
	public class BoneKnight : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public BoneKnight() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a bone knight";
			Body = 57;
			BaseSoundID = 451;

			SetStr( 202, 248 );
			SetDex( 74, 95 );
			SetInt( 39, 60 );

			SetHits( 236, 300 );

			SetDamage( 8, 18 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 85.1, 100.0 );
			SetSkill( SkillName.Wrestling, 85.1, 95.0 );

			Fame = 5000;
			Karma = -5000;
			
			VirtualArmor = 40;

			PackGold( 9, 10 );

			// PackSlayer();
			PackItem( new Scimitar() );
			PackItem( new WoodenShield() );

			PackItem( new Bonemeal( Utility.RandomMinMax( 15, 22 ) ) );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );

			if ( 0.08 > Utility.RandomDouble() )
			{
				switch ( Utility.Random( 6 ) )
				{
					case 0: PackItem( new PlateArms() ); break;
					case 1: PackItem( new PlateChest() ); break;
					case 2: PackItem( new PlateGloves() ); break;
					case 3: PackItem( new PlateGorget() ); break;
					case 4: PackItem( new PlateHelm() ); break;
					case 5: PackItem( new PlateLegs() ); break;
				}
			}
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
							damage -= 15;
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
							damage -= 15;
							from.SendMessage("Your weapon deals little damage to the skeletal pawn's durable bones.");
                                    }
					}
				}
			}
		}

		public BoneKnight( Serial serial ) : base( serial )
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
