using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a gualichu corpse" )]
	public class Gualichu : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public Gualichu() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = "a gualichu";
			Body = Utility.RandomList( 50, 56 );
			BaseSoundID = 0x48D;
                        Hue = 1237;

   			if ( Body == 56 ) //Hatchet
   			{
  				DamageMin += 5;
   				DamageMax += 8;
   				RawStr += 100;
   				RawDex -= 25;
				Skills.Lumberjacking.Base += 55;
   			}

			SetStr( 61, 76 );
			SetDex( 56, 73 );
			SetInt( 16, 37 );

			SetHits( 68, 96 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 16 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, -25 );

			SetSkill( SkillName.MagicResist, 45.4, 58.2 );
			SetSkill( SkillName.Tactics, 45.1, 59.2 );
			SetSkill( SkillName.Wrestling, 49.4, 57.5 );

			Fame = 450;
			Karma = -450;

			PackGold( 50, 100 );

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
   			if ( Body == 56 ) //Hatchet
   			{
				AddItem( new Hatchet() );
   			}
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

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new Bone(3), from);
                              corpse.AddCarvedItem(new Bonemeal( Utility.RandomMinMax( 5, 8 ) ), from );
                              corpse.AddCarvedItem(new BonePile(), from );
                              corpse.AddCarvedItem(new RibCage(), from );

                              from.SendMessage( "You receive 3 bones, some bonemeal, and a bonepile/ribcage that can be converted to bones using scissors." );
                              corpse.Carved = true; 
			}
                }

		public Gualichu( Serial serial ) : base( serial )
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
