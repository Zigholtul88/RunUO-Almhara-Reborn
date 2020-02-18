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
	[CorpseName( "a Lady Sabrix corpse" )]
	public class LadySabrix : BaseCreature
	{
		[Constructable]
		public LadySabrix() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			IsParagon = true;

			Name = "Lady Sabrix";
			Body =  0x9D;
			Hue = 0x497;
			BaseSoundID = 0x388;

			SetStr( 82, 130 );
			SetDex( 117, 146 );
			SetInt( 50, 98 );

			SetHits( 633, 761 );
			SetStam( 117, 146 );
			SetMana( 50, 98 );

			SetDamage( 12, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, -25 );
			SetResistance( ResistanceType.Cold, 30, 39 );
			SetResistance( ResistanceType.Poison, 70, 80 );
			SetResistance( ResistanceType.Energy, 35, 44 );

			SetSkill( SkillName.Anatomy, 68.8, 105.1 );
			SetSkill( SkillName.MagicResist, 79.4, 95.1 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Poisoning, 97.8, 116.7 );
			SetSkill( SkillName.Tactics, 102.8, 120.0 );
			SetSkill( SkillName.Wrestling, 109.8, 122.8 );

			Fame = 38900;
			Karma = -38900;

			PackGold( 2859, 4406 );

			PackItem( new SpidersSilk( 300 ) );
			PackItem( new GreaterToxicPotion() );
			PackItem( new GreaterPoisonPotion() );

                        if (Utility.RandomDouble() < 0.4 )
                                PackItem(new TreasureMap(2, Map.Malas ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 20 );
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

		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ArmorIgnore;
		}

		public LadySabrix( Serial serial ) : base( serial )
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
