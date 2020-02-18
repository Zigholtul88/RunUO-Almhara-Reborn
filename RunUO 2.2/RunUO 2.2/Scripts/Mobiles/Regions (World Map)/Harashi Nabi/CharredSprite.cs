using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a charred sprite corpse" )]
	public class CharredSprite : BaseCreature
	{
		[Constructable]
		public CharredSprite() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = "a charred sprite";
			BaseSoundID = 0x57B;
			Body = 264;
                        Hue = 1908;

			SetStr( 150, 160 );
			SetDex( 24, 38 );
			SetInt( 12, 19 );

			SetHits( 470, 595 );
			SetMana( 0 );

			SetDamage( 8, 12 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Fire, 60 );

			SetResistance( ResistanceType.Physical, 10 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.MagicResist, 11.5, 21.1 );
			SetSkill( SkillName.Tactics, 56.5, 62.2 );
			SetSkill( SkillName.Wrestling, 70.2, 77.3 );

			Fame = 2000;
			Karma = -2000;

			AddItem( new LightSource() );

			PackReg( 1, 5 );

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 13, 28 ) ) );
			pack.DropItem( Loot.RandomClothing() );
			pack.DropItem( Loot.RandomClothing() );


 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			     BaseArmor armor = Loot.RandomArmor( true );
		             BaseRunicTool.ApplyAttributesTo( armor, 5, 15, 30 );

                             pack.DropItem( armor );
                        }

			Container bag = new Bag();
			bag.DropItem( new Gold( Utility.RandomMinMax( 215, 345 ) ) );
			bag.DropItem( new SulfurousAsh( Utility.RandomMinMax( 39, 58 ) ) );
			bag.DropItem( Loot.RandomWand() );
			bag.DropItem( new HealPotion() );
			bag.DropItem( Loot.RandomPotion() );
			bag.DropItem( Loot.RandomGem() );

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			     BaseClothing clothing = Loot.RandomClothing( true );
		             BaseRunicTool.ApplyAttributesTo( clothing, 2, 15, 20 );  

                             clothing.Attributes.ReflectPhysical = 3;

                             bag.DropItem( clothing );
                        }

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                             BaseJewel jewel = new GoldRing();
			     if ( Core.AOS )
		             BaseRunicTool.ApplyAttributesTo( jewel, 4, 15, 20 ); 

                             jewel.Attributes.SpellDamage = 5;
                             jewel.Resistances.Energy = 9;

                             bag.DropItem( jewel );
		        }

                        Item ScrollLoot = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                        ScrollLoot.Amount = Utility.Random( 2, 5 );
                        bag.DropItem( ScrollLoot );

			pack.DropItem( bag );

			PackItem( pack );
		}

		public override void GenerateLoot()
		{
                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                  BaseJewel jewel1 = new GoldEarrings();
			          if ( Core.AOS )
		                  BaseRunicTool.ApplyAttributesTo( jewel1, 3, 15, 20 ); 

                                  jewel1.Resistances.Fire = 8;

                                  PackItem( jewel1 );
		        }
                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                  BaseJewel jewel2 = new GoldNecklace();
			          if ( Core.AOS )
		                  BaseRunicTool.ApplyAttributesTo( jewel2, 3, 15, 20 ); 

                                  jewel2.Resistances.Fire = 12;

                                  PackItem( jewel2 );
		        }
                        if ( Utility.RandomDouble() < 0.05 ) //5% chance to drop.
                        {
                                  BaseWeapon weapon = new BlackStaff();

                                  weapon.Hue = 1908;

                                  weapon.Attributes.SpellDamage = 15;
                                  weapon.WeaponAttributes.HitFireball = 5;

                                  PackItem( weapon );
		        }
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new CharredSpriteWings(), from );

                              from.SendMessage( "You carve up a pair of charred sprite wings." ); 
                              corpse.Carved = true;
			}
                }

                public override bool HasBreath{ get{ return true; } }

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 100; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 1908; } }
		public override int BreathEffectItemID{ get{ return 0x36BD; } }
		public override int BreathEffectSound{ get{ return 0x1E5; } }
		public override int BreathAngerSound{ get{ return 0x57B; } }

		public override bool IsEnemy( Mobile m )
		{
		        PlayerMobile pm = m as PlayerMobile;

			if ( m is PlayerMobile && m.SkillsTotal >= 7000 )
				return false;

                        if ( m is PlayerVendor || m is TownCrier || m is BaseSpecialCreature )
				return false;

			if ( m is BaseCreature )
			{
				BaseCreature c = (BaseCreature)m;

				if( c.Controlled || c.FightMode == FightMode.Aggressor || c.FightMode == FightMode.Closest || c.FightMode == FightMode.None )

					return false;
			}

			return true;
		}

		public CharredSprite( Serial serial ) : base( serial )
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