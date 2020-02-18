using System;
using Server;
using System.Collections;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a pit bloated widow corpse" )]
	public class PitBloatedWidow : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ConcussionBlow;
		}

		[Constructable]
		public PitBloatedWidow() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.3, 0.6 )
		{
			Name = "a pit bloated widow";
			Body = 173;
                        Hue = 1058;
			BaseSoundID = 0x183;

			SetStr( 295, 300 );
			SetDex( 127, 187 );
			SetInt( 102, 134 );

			SetHits( 300, 400 );
			SetMana( 0 );

			SetDamage( 8, 12 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Poison, 80 );

			SetResistance( ResistanceType.Physical, 45 );
			SetResistance( ResistanceType.Fire, -25 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.MagicResist, 55.5, 65.0 );
			SetSkill( SkillName.Tactics, 59.4, 65.9 );
			SetSkill( SkillName.Wrestling, 63.7, 75.8 );

			Fame = 15000;
			Karma = -15000;

			PackGold( 359, 406 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 10 );
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

		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new SpiderEgg( Utility.RandomMinMax( 16, 27 ) ), from );

                              from.SendMessage( "You carve up some spider eggs." ); 
			}
                }

		public PitBloatedWidow( Serial serial ) : base( serial )
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