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
	[CorpseName( "a moloch corpse" )]
	public class Moloch : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ConcussionBlow;
		}

		[Constructable]
		public Moloch() : base( AIType.AI_Melee, FightMode.Closest, 8, 1, 0.175, 0.350 )
		{
			Name = "a moloch";
			Body = 0x311;
			BaseSoundID = 0x300;

			SetStr( 331, 360 );
			SetDex( 66, 85 );
			SetInt( 41, 65 );

			SetHits( 855, 1000 );

			SetDamage( 15, 23 );

			SetSkill( SkillName.MagicResist, 5.1, 10.5 );
			SetSkill( SkillName.Tactics, 75.1, 90.0 );
			SetSkill( SkillName.Wrestling, 70.1, 90.0 );

			Fame = 7500;
			Karma = -7500;

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 713, 1228 ) ) );

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			     BaseClothing clothing1 = Loot.RandomClothing( true );
		             BaseRunicTool.ApplyAttributesTo( clothing1, 3, 15, 30 );  

                             pack.DropItem( clothing1 ); 
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			     BaseClothing clothing2 = Loot.RandomClothing( true );
		             BaseRunicTool.ApplyAttributesTo( clothing2, 3, 15, 30 );  

                             pack.DropItem( clothing2 );
                        }

			Container bag = new Bag();
			bag.DropItem( new Gold( Utility.RandomMinMax( 15, 45 ) ) );
			bag.DropItem( new Bandage( Utility.RandomMinMax( 9, 18 ) ) );
			bag.DropItem( Loot.RandomGem() );

                        Item ScrollLoot1 = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                        ScrollLoot1.Amount = Utility.Random( 2, 5 );
                        bag.DropItem( ScrollLoot1 );

                        Item ScrollLoot2 = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                        ScrollLoot2.Amount = Utility.Random( 2, 5 );
                        bag.DropItem( ScrollLoot2 );

			pack.DropItem( bag );

			PackItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 6 );

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			        BaseClothing clothing = Loot.RandomClothing( true );
		                BaseRunicTool.ApplyAttributesTo( clothing, 3, 25, 30 );  

                                PackItem( clothing );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			        BaseJewel bracelet = new GoldBracelet();
			        if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( bracelet, 5, 25, 30 );  

                                PackItem( bracelet );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			        BaseJewel earrings = new GoldEarrings();
			        if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( earrings, 5, 25, 30 ); 

                                PackItem( earrings );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			        BaseJewel necklace = new GoldNecklace();
			        if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( necklace, 5, 25, 30 );      

                                PackItem( necklace );
                        }
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			        BaseJewel ring = new GoldRing();
			        if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( ring, 5, 25, 30 ); 

                                PackItem( ring );
                        }
	        }

		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		private DateTime m_NextAttack;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextAttack )
			{
				SandAttack( combatant );
				m_NextAttack = DateTime.Now + TimeSpan.FromSeconds( 10.0 + (10.0 * Utility.RandomDouble()) );
			}
		}

		public void SandAttack( Mobile m )
		{
			DoHarmful( m );

			m.FixedParticles( 0x36B0, 10, 25, 9540, 2413, 0, EffectLayer.Waist );

			new InternalTimer( m, this ).Start();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile, m_From;

			public InternalTimer( Mobile m, Mobile from ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				m_Mobile.PlaySound( 0x4CF );
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 1, 15 ), 90, 10, 0, 0, 0 );
			}
		}

		public Moloch( Serial serial ) : base( serial )
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