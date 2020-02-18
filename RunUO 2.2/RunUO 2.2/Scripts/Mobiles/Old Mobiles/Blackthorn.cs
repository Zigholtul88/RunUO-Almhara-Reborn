using System;
using System.Collections;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a blackthorns corpse" )]
	public class Blackthorn : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.2; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public Blackthorn() : base( AIType.AI_Archer, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a blackthorn";
			Body = 301;
                        Hue = 968;

			SetStr( 138, 167 );
			SetDex( 21, 37 );
			SetInt( 25, 39 );

			SetHits( 125, 150 );

			SetDamage( 8, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.Archery, 76.3, 95.0 );
			SetSkill( SkillName.MagicResist, 38.9, 41.5 );
			SetSkill( SkillName.Tactics, 26.8, 43.2 );

			Fame = 1500;
			Karma = -1500;

			PackGold( 7, 12 );
			AddItem( new Bow() );
			PackItem( new Arrow( Utility.RandomMinMax( 15, 20 ) ) );

			PackItem( new MandrakeRoot( 12 ) );
			PackItem( new Log( Utility.RandomMinMax( 17, 25 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new Nirnroot( Utility.RandomMinMax( 5, 7 )), from);

                        from.SendMessage( "You carve up some nirnroot." );
                        corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override int GetIdleSound() { return 443; } 
		public override int GetDeathSound() { return 31; }
		public override int GetAttackSound() { return 672; } 

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
						if (weapon1 is BaseAxe )
						{
							damage += 1;
						}
                                    else
                                    {
							damage -= 15;
							from.SendMessage("Your weapon deals little damage to the blackthorn's bark exterior.");
                                    }
					}

					else if (weapon2 != null)
					{
						if (weapon2 is BaseAxe )
						{
							damage += 1;
						}
                                    else
                                    {
							damage -= 15;
							from.SendMessage("Your weapon deals little damage to the blackthorn's bark exterior.");
                                    }
					}
				}
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

		public Blackthorn( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 442 )
				BaseSoundID = -1;
		}
	}
}