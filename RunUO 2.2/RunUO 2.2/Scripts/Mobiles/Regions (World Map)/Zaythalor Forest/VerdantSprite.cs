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
	[CorpseName( "a verdant sprite corpse" )]
	public class VerdantSprite : BaseCreature
	{
		[Constructable]
		public VerdantSprite() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a verdant sprite";
			BaseSoundID = 0x57B;
			Body = 264;
                        Hue = 71;

			SetStr( 50, 60 );
			SetDex( 24, 38 );
			SetInt( 12, 19 );

			SetMana( 0 );

			SetDamage( 1, 3 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10 );

			SetSkill( SkillName.MagicResist, 11.5, 21.1 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 200;
			Karma = -200;

			AddItem( new LightSource() );

			switch ( Utility.Random( 7 ) )
			{
				case 0: PackItem( new Apple() );  break;
				case 1: PackItem( new Banana() );  break;
				case 3: PackItem( new HoneydewMelon() ); break;
				case 4: PackItem( new Lemon() );  break;
				case 5: PackItem( new Pear() ); break;
				case 6: PackItem( new Watermelon() ); break;
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
						if ( weapon1 is BaseRanged )
						{
							damage *= 2;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseRanged )
						{
							damage *= 2;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
				}
			}
		}

		public override bool CanRummageCorpses{ get{ return true; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem( new Gold( Utility.RandomMinMax( 1, 3 ) ), from );
                              corpse.AddCarvedItem( new VerdantSpriteWings(), from );

                              from.SendMessage( "You carve up gold and a pair of sprite wings." );
                              corpse.Carved = true; 
			}
                }

                public override bool HasBreath{ get{ return true; } } // seaweed throw enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }

		public override int BreathEffectHue{ get{ return 71; } }
		public override int BreathEffectItemID{ get{ return 14509; } }
		public override int BreathEffectSound{ get{ return 0x1E5; } }
		public override int BreathAngerSound{ get{ return 0x57B; } }

		public VerdantSprite( Serial serial ) : base( serial )
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