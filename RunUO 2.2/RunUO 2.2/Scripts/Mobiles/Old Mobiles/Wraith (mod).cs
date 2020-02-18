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
	[CorpseName( "a ghostly corpse" )]
	public class Wraith : BaseCreature
	{
		[Constructable]
		public Wraith() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a wraith";
			Body = 748;
			BaseSoundID = 0x482;

			SetStr( 78, 97 );
			SetDex( 76, 92 );
			SetInt( 37, 56 );

			SetHits( 92, 120 );
			SetMana( 185, 280 );

			SetDamage( 7, 11 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Cold, 50 );

			SetResistance( ResistanceType.Physical, 100 );
			SetResistance( ResistanceType.Fire, -25 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 10 );

			SetSkill( SkillName.EvalInt, 80.6, 92.5 );
			SetSkill( SkillName.Magery, 97.6, 101.9 );
			SetSkill( SkillName.MagicResist, 55.4, 69.0 );
			SetSkill( SkillName.Tactics, 120 );
			SetSkill( SkillName.Wrestling, 120 );

			Fame = 4000;
			Karma = -4000;

			PackGold( 6, 8 );
			PackReg( 10 );
		}
			
		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override bool BleedImmune{ get{ return true; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.4 >= Utility.RandomDouble() )
			{
		                defender.RawStr -= ( Utility.Random( 1, 2 ) );
		                defender.RawDex -= ( Utility.Random( 1, 2 ) );
		                defender.RawInt -= ( Utility.Random( 1, 2 ) );

				defender.FixedParticles( 0x374A, 10, 15, 5028, EffectLayer.Waist );
				defender.PlaySound( 0x1FB );
                                defender.SendMessage( "Your stats and skills have been slowly drained!" );

				defender.Animate( 21, 6, 1, true, false, 0 );
			}
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
						if (weapon1 is BaseEquipableLight )
						{
							damage *= 5;
						}
                                                else
                                                {
							damage = 0;
							from.SendMessage("Your attack phases through the wraith.");

			                                if ( 0.5 >= Utility.RandomDouble() )
			                                {
							     damage = 0;

		                                             from.RawStr -= ( Utility.Random( 1, 2 ) );
		                                             from.RawDex -= ( Utility.Random( 1, 2 ) );
		                                             from.RawInt -= ( Utility.Random( 1, 2 ) );

				                             from.FixedParticles( 0x374A, 10, 15, 5028, EffectLayer.Waist );
				                             from.PlaySound( 0x1FB );
		                                             from.PlaySound( from.Female ? 814 : 1088 );
                                                             from.SendMessage( "Your stats has been slowly drained!" );
                                                        }
                                                }
					}
					else if (weapon2 != null)
					{
						if (weapon2 is BaseEquipableLight )
						{
							damage *= 5;
						}
                                                else
                                                {
							damage = 0;
							from.SendMessage("Your attack phases through the wraith.");

			                                if ( 0.5 >= Utility.RandomDouble() )
			                                {
							     damage = 0;

		                                             from.RawStr -= ( Utility.Random( 1, 2 ) );
		                                             from.RawDex -= ( Utility.Random( 1, 2 ) );
		                                             from.RawInt -= ( Utility.Random( 1, 2 ) );

				                             from.FixedParticles( 0x374A, 10, 15, 5028, EffectLayer.Waist );
				                             from.PlaySound( 0x1FB );
		                                             from.PlaySound( from.Female ? 814 : 1088 );
                                                             from.SendMessage( "Your stats has been slowly drained!" );
                                                        }
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

                        corpse.AddCarvedItem(new Bone(), from);
                        corpse.AddCarvedItem(new ShadowEssence( Utility.RandomMinMax( 8, 14 ) ), from );
                        corpse.AddCarvedItem(new RibCage(), from);

                        from.SendMessage( "You receive 1 bone, some shadow essence, and a ribcage that can be converted to bones using scissors." );
                        corpse.Carved = true; 
			}
                }

		public Wraith( Serial serial ) : base( serial )
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