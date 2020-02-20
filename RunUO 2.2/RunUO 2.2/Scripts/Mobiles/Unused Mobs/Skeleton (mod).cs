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
	[CorpseName( "a skeletal corpse" )]
	public class Skeleton : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.2; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public Skeleton() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = "a skeleton";
			Body = Utility.RandomList( 50, 56 );
			BaseSoundID = 0x48D;

   			if (Body == 56) //Hatchet
   				{
  					DamageMin += 10;
   					DamageMax += 15;
   					RawStr += 100;
   					RawDex -= 25;
					Skills.Lumberjacking.Base += 55;
   				}

			SetStr( 61, 76 );
			SetDex( 56, 73 );
			SetInt( 16, 37 );

			SetHits( 68, 96 );

			SetDamage( 3, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 16 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.MagicResist, 45.4, 58.2 );
			SetSkill( SkillName.Tactics, 45.1, 59.2 );
			SetSkill( SkillName.Wrestling, 49.4, 57.5 );

			Fame = 450;
			Karma = -450;

			VirtualArmor = 16;

			PackGold( 1, 3 );
		}

		public override void GenerateLoot()
		{
   			if ( Body == 56 ) //Hatchet
   			{
				AddItem( new Hatchet() );
   			}
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }

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
							damage += 5;
						}
						else if (weapon1 is SkeletalAxe )
						{
							damage += 5;
						}
						else if (weapon1 is SkeletalScimitar )
						{
							damage += 5;
						}
                                                else
                                                {
							damage -= 15;
                                                }
					}
					else if (weapon2 != null)
					{
						if (weapon2 is BaseBashing )
						{
							damage += 5;
						}
						else if (weapon2 is SkeletalAxe )
						{
							damage += 5;
						}
						else if (weapon2 is SkeletalScimitar )
						{
							damage += 5;
						}
                                                else
                                                {
							damage -= 15;
                                                }
					}
				}
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
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

		public Skeleton( Serial serial ) : base( serial )
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
