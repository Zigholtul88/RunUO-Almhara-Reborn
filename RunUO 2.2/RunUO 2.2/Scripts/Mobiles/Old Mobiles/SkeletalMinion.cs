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
	[CorpseName( "a skeletal minion corpse" )]
	public class SkeletalMinion : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.2; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public SkeletalMinion() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a skeletal minion";
			Body = 50;
			BaseSoundID = 0x48D;

			SetStr( 21, 26 );
			SetDex( 13, 19 );
			SetInt( 0 );

			SetHits( 35, 40 );
			SetMana( 0 );

			SetDamage( 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 8 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.MagicResist, 9.8, 12.2 );
			SetSkill( SkillName.Tactics, 6.9, 10.2 );
			SetSkill( SkillName.Wrestling, 16.2, 20.2 );

			Fame = 250;
			Karma = -250;
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
							damage += 1;
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
                                    else
                                    {
							damage -= 10;
							from.SendMessage("Your weapon deals little damage to the skeletal pawn's durable bones.");
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

                        corpse.AddCarvedItem(new Bone(2), from);
                        corpse.AddCarvedItem(new Bonemeal( Utility.RandomMinMax( 1, 3 ) ), from );
                        corpse.AddCarvedItem(new RibCage(), from);

                        from.SendMessage( "You receive 2 bones, some bonemeal, and a ribcage that can be converted to bones using scissors." );
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

		public SkeletalMinion( Serial serial ) : base( serial )
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
