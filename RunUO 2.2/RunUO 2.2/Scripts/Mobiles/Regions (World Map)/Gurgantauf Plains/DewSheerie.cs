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
	[CorpseName( "a dew sheerie corpse" )]
	public class DewSheerie : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public DewSheerie() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dew sheerie";
			Body = 14;
                        Hue = 279;
			BaseSoundID = 268;

			SetStr( 131, 152 );
			SetDex( 66, 84 );
			SetInt( 73, 92 );

			SetHits( 152, 186 );

			SetDamage( 9, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 34 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, -25 );

			SetSkill( SkillName.MagicResist, 52.9, 87.0 );
			SetSkill( SkillName.Tactics, 65.5, 91.6 );
			SetSkill( SkillName.Wrestling, 65.7, 92.9 );

			Fame = 13500;
			Karma = -13500;

			PackGold( 219, 325 );

			PackItem( new Pearl() );

			PackItem( new FertileDirt( Utility.RandomMinMax( 1, 4 ) ) );
			PackItem( new MandrakeRoot() );

			PackItem( new ElementalDust( Utility.RandomMinMax( 4, 7 ) ) );

			switch ( Utility.Random( 9 ))
			{
				case 0: PackItem( new Agate() ); break;
				case 1: PackItem( new Beryl() ); break;
				case 2: PackItem( new ChromeDiopside() ); break;
				case 3: PackItem( new FireOpal() ); break;
				case 4: PackItem( new MoonstoneCustom() ); break;
				case 5: PackItem( new Onyx() ); break;
				case 6: PackItem( new Opal() ); break;
				case 7: PackItem( new Pearl() ); break;
				case 8: PackItem( new TurquoiseCustom() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 2 );
			AddLoot( LootPack.Potions );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

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
		public override int BreathAngerSound{ get{ return 268; } }

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
							damage -= 200;
							from.SendMessage("Your weapon deals little damage to the dew sheerie.");
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
							damage -= 200;
							from.SendMessage("Your weapon deals little damage to the earth elemental.");
                                                }
					}
				}
			}
		}

		public DewSheerie( Serial serial ) : base( serial )
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