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
using Server.Spells;
using Server.Spells.Third;
using Server.Spells.Sixth;

namespace Server.Mobiles
{
	[CorpseName( "a cliff diver corpse" )]
	public class CliffDiver : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }

		[Constructable]
		public CliffDiver() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
                        Name = "a cliff diver";
			Body = 667;
			Hue = 1357;
                        HairItemID = 16994;
                        HairHue = 1360;

			SetStr( 147, 267 );
			SetDex( 97, 114 );
			SetInt( 54, 147 );

			SetHits( 698, 739 );

			SetDamage( 10, 12 );

                        Flying = true;

			FemaleGargishLeatherArms arms = new FemaleGargishLeatherArms(); 
			arms.Hue = 2106; 
			arms.Movable = false; 
			AddItem( arms ); 

			FemaleGargishLeatherChest chest = new FemaleGargishLeatherChest(); 
			chest.Hue = 2106; 
			chest.Movable = false; 
			AddItem( chest ); 

			FemaleGargishLeatherKilt kilt = new FemaleGargishLeatherKilt(); 
			kilt.Hue = 2106; 
			kilt.Movable = false; 
			AddItem( kilt ); 

			FemaleGargishLeatherLegs legs = new FemaleGargishLeatherLegs(); 
			legs.Hue = 2106; 
			legs.Movable = false; 
			AddItem( legs ); 

			GlassStaff weapon = new GlassStaff();
			weapon.Movable = false; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

			SetSkill( SkillName.MagicResist, 85.9, 91.0 );
			SetSkill( SkillName.Wrestling, 69.8, 78.9 );
			SetSkill( SkillName.Tactics, 80.1, 89.9 );

			Fame = 3000;
			Karma = -3000;

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 313, 428 ) ) );
			pack.DropItem( Loot.RandomClothing() );
			pack.DropItem( Loot.RandomClothing() );

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			     BaseArmor armor = Loot.RandomArmor( true );
		             BaseRunicTool.ApplyAttributesTo( armor, 5, 15, 30 );

                             pack.DropItem( armor );
                        }

			Container bag = new Bag();
			bag.DropItem( new Gold( Utility.RandomMinMax( 15, 45 ) ) );
			bag.DropItem( new SulfurousAsh( Utility.RandomMinMax( 9, 18 ) ) );
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
			AddLoot( LootPack.Gems );

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                  BaseJewel jewel1 = new GoldEarrings();
			          if ( Core.AOS )
		                  BaseRunicTool.ApplyAttributesTo( jewel1, 3, 15, 20 ); 

                                  jewel1.Resistances.Energy = 8;

                                  PackItem( jewel1 );
		        }
                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                  BaseJewel jewel2 = new GoldNecklace();
			          if ( Core.AOS )
		                  BaseRunicTool.ApplyAttributesTo( jewel2, 3, 15, 20 ); 

                                  jewel2.Resistances.Energy = 12;

                                  PackItem( jewel2 );
		        }
                        if ( Utility.RandomDouble() < 0.04 ) //4% chance to drop.
                        {
                                  BaseWeapon weapon = new QuarterStaff();

                                  weapon.Hue = 2106;

                                  weapon.Attributes.SpellDamage = 15;
                                  weapon.WeaponAttributes.HitLightning = 5;

                                  PackItem( weapon );
                        }
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return false; } }

		public override int Meat{ get{ return 1; } }

		public override int GetIdleSound() { return 0x1AC; } //play juka mage idle
		public override int GetAttackSound() { return 0x233; } //play staff hit sound
		public override int GetHurtSound() { return 0x1D0; } // play juka mage hurt
		public override int GetAngerSound() { return 0x1CD; } //play juka mage anger
		public override int GetDeathSound() { return 0x28D; } //play juka mage death

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.HarashiNabiPredator; }
		}

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

		public override void Damage( int amount, Mobile from )
		{
			base.Damage( amount, from );
						
			if ( Combatant == null || Hits > HitsMax * 0.2 || Utility.RandomBool() )
				return;	
							
			new InvisibilitySpell( this, null ).Cast();
			
			Target target = Target;
			
			if ( target != null )
				target.Invoke( this, this );
				
			Timer.DelayCall( TimeSpan.FromSeconds( 1 ), new TimerCallback( Teleport ) );
		}
		
		public virtual void Teleport()
		{				
			if ( Combatant == null )
				return;
						
			// 20 tries to teleport
			for ( int tries = 0; tries < 20; tries ++ )
			{
				int x = Utility.RandomMinMax( 5, 7 ); 
				int y = Utility.RandomMinMax( 5, 7 );
				
				if ( Utility.RandomBool() )
					x *= -1;
					
				if ( Utility.RandomBool() )
					y *= -1;
				
				Point3D p = new Point3D( X + x, Y + y, 0 );
				IPoint3D po = new LandTarget( p, Map ) as IPoint3D;
				
				if ( po == null )
					continue;
					
				SpellHelper.GetSurfaceTop( ref po );

				if ( InRange( p, 12 ) && InLOS( p ) && Map.CanSpawnMobile( po.X, po.Y, po.Z ) )
				{					
					
					Point3D from = Location;
					Point3D to = new Point3D( po );
	
					Location = to;
					ProcessDelta();
					
					FixedParticles( 0x376A, 9, 32, 0x13AF, EffectLayer.Waist );
					PlaySound( 0x1FE );
										
					return;					
				}
			}		
			
			RevealingAction();
		}

		public CliffDiver( Serial serial ) : base( serial )
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