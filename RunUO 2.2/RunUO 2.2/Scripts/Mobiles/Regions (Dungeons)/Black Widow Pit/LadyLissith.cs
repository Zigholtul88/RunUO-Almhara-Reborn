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
	[CorpseName( "a Lady Lissith corpse" )]
	public class LadyLissith : BaseCreature
	{
		[Constructable]
		public LadyLissith() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			IsParagon = true;

			Name = "Lady Lissith";
			Body =  0x9D;
			Hue = 0x452;
			BaseSoundID = 0x388;

			SetStr( 81, 130 );
			SetDex( 116, 152 );
			SetInt( 44, 100 );

			SetHits( 545, 675 );
			SetStam( 116, 152 );
			SetMana( 44, 100 );

			SetDamage( 12, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Fire, -25 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 71, 80 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.Anatomy, 68.6, 106.8 );
			SetSkill( SkillName.MagicResist, 78.8, 95.6 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Poisoning, 96.6, 112.9 );
			SetSkill( SkillName.Tactics, 102.7, 119.0 );
			SetSkill( SkillName.Wrestling, 108.6, 123.0 );

			Fame = 48900;
			Karma = -48900;

			PackGold( 2859, 4406 );

			PackItem( new SpidersSilk( 300 ) );
			PackItem( new GreaterToxicPotion() );
			PackItem( new GreaterPoisonPotion() );

                        if (Utility.RandomDouble() < 0.3 )
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
			return WeaponAbility.BleedAttack;
		}

		public LadyLissith( Serial serial ) : base( serial )
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
