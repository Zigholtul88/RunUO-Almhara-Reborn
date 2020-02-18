using System;
using System.Collections;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a giant skeleton corpse" )]
	public class GiantSkeleton : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.2; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public GiantSkeleton() : base( AIType.AI_Melee, FightMode.Closest, 8, 1, 0.175, 0.350 )
		{
			Name = "a giant skeleton";
			Body = 308;
			BaseSoundID = 0x48D;

			SetStr( 236, 302 );
			SetDex( 178, 183 );
			SetInt( 0 );

			SetHits( 258, 369 );
			SetMana( 0 );

			SetDamage( 12, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.MagicResist, 25.3, 34.1 );
			SetSkill( SkillName.Tactics, 59.8, 68.1 );
			SetSkill( SkillName.Wrestling, 60.2, 61.7 );

			Fame = 1500;
			Karma = -1500;

			PackGold( 21, 34 );
			PackReg( 5, 10 );
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
                                                else
                                                {
							damage -= 30;
                                                }
					}
					else if (weapon2 != null)
					{
						if (weapon2 is BaseBashing )
						{
							damage += 5;
						}
                                                else
                                                {
							damage -= 30;
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

                              corpse.AddCarvedItem(new Bone(15), from);
                              corpse.AddCarvedItem(new Bonemeal( Utility.RandomMinMax( 28, 37 ) ), from );
                              corpse.AddCarvedItem(new BonePile(), from);
                              corpse.AddCarvedItem(new BonePile(), from);
                              corpse.AddCarvedItem(new RibCage(), from);
                              corpse.AddCarvedItem(new RibCage(), from);

                              from.SendMessage( "You receive 15 bones, some bonemeal, and some bonepile/ribcages that can be converted to bones using scissors." );
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

		public GiantSkeleton( Serial serial ) : base( serial )
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
