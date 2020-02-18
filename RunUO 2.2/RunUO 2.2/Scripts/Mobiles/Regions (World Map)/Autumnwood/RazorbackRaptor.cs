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
	[CorpseName( "a raptor corpse" )]
	public class RazorbackRaptor : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.2; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public RazorbackRaptor() : base( AIType.AI_Melee, FightMode.Closest, 8, 1, 0.175, 0.350 )
		{
   			if ( Flying ) // Frenzy
   			{
			        CurrentSpeed = BoostedSpeed;
			        RangePerception = 200;

  				DamageMin += 5;
   				DamageMax += 10;

			        SetResistance( ResistanceType.Physical, 35 );
			        SetResistance( ResistanceType.Fire, 30 );
			        SetResistance( ResistanceType.Cold, 20 );
			        SetResistance( ResistanceType.Poison, 50 );
			        SetResistance( ResistanceType.Energy, 30 );

			        SetSkill( SkillName.MagicResist, 45.0, 50.0 );
			        SetSkill( SkillName.Tactics, 95.0, 99.8 );
			        SetSkill( SkillName.Wrestling, 95.0, 99.8 );
   			}

			Name = "a razorback raptor";
			Body = 730; 
			Hue = Utility.RandomList( 2001,2002,2003,2004,2005,2006 );

			SetStr( 98, 117 );
			SetDex( 139, 153 );
			SetInt( 120, 123 );

			SetHits( 110, 135 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.Healing, 45.8, 60.2 );
			SetSkill( SkillName.MagicResist, 15.7, 19.1 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 62.1, 63.8 );
			SetSkill( SkillName.Wrestling, 49.3, 54.4 );

			Fame = 1000;
			Karma = -1000;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 32.5;
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
						if ( weapon1 is BaseKnife )
						{
							damage *= 2;
						}
						else if ( weapon1 is BaseSpear )
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
						if ( weapon2 is BaseKnife )
						{
							damage *= 2;
						}
						else if ( weapon2 is BaseSpear )
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

		public override bool CanAngerOnTame { get { return true; } }

		public override int GetIdleSound() { return 1573; } 
		public override int GetAngerSound() { return 1570; } 
		public override int GetHurtSound() { return 1572; } 
		public override int GetDeathSound() { return 1571; }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{      
 			if ( Utility.RandomDouble() < 0.25 )
                        {
                                Flying = true; // Frenzy
			        CurrentSpeed = BoostedSpeed;
			        RangePerception = 200;
			        PlaySound( 1570 );
			        this.Combatant = from;
				from.SendMessage( "The raptor goes into a frenzy" );
                        }

			base.OnDamage( amount, from, willKill );
                }

		public override void OnHarmfulSpell( Mobile from )
		{
 			if ( Utility.RandomDouble() < 0.25 )
                        {
                                Flying = false;
			        CurrentSpeed = PassiveSpeed;
			        PlaySound( 1572 );
                        }

                        if ( Utility.RandomDouble() < 0.25 )
                        {
                                Flying = true; // Frenzy
			        CurrentSpeed = BoostedSpeed;
			        RangePerception = 200;
			        PlaySound( 1570 );
			        this.Combatant = from;
				from.SendMessage( "The raptor goes into a frenzy" );
                        }
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new RawRibs(7), from);
                              corpse.AddCarvedItem(new HornedHides(9), from);
                              corpse.AddCarvedItem(new SerpentScale( Utility.RandomMinMax( 7, 10 )), from);
                              corpse.AddCarvedItem(new RazorbackTooth( amount ), from );

                              from.SendMessage( "You carve up raw ribs, horned hides, serpent scales, and a razorback tooth." );
                              corpse.Carved = true; 
			}
                }

		public RazorbackRaptor( Serial serial ) : base( serial )
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