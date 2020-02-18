using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Targeting;

namespace Server.Mobiles 
{ 
	[CorpseName( "a blizzard knight corpse" )] 
	public class BlizzardKnight : BaseCreature 
	{ 
		[Constructable] 
		public BlizzardKnight() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = "a blizzard knight";
			Body = 0x190;
			BaseSoundID = 263;

			SetStr( 326, 355 );
			SetDex( 166, 185 );
			SetInt( 71, 95 );

			SetHits( 438, 511 );

			SetDamage( 12, 18 );

			SetDamageType( ResistanceType.Physical, 30 );
			SetDamageType( ResistanceType.Cold, 70 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 100 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.Anatomy, 35.0, 55.5 );
			SetSkill( SkillName.Swords, 70.2, 80.0 );
			SetSkill( SkillName.Tactics, 80.1, 100.0 );
			SetSkill( SkillName.Wrestling, 80.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			AddItem( new LightSource() );

			Lance weapon = new Lance();
			weapon.Hue = 1152;
			weapon.Movable = false;
			AddItem( weapon );

			BronzeShield shield = new BronzeShield();
			shield.Hue = 1152;
			shield.Movable = false;
			AddItem( shield );

			CloseHelm helm = new CloseHelm();
			helm.Hue = 1152;
			helm.Movable = false;
			AddItem( helm );

			PlateArms arms = new PlateArms();
			arms.Hue = 1152;
			arms.Movable = false;
			AddItem( arms );

			PlateGloves gloves = new PlateGloves();
			gloves.Hue = 1152;
			gloves.Movable = false;
			AddItem( gloves );

			PlateChest tunic = new PlateChest();
			tunic.Hue = 1152;
			tunic.Movable = false;
			AddItem( tunic );

			PlateLegs legs = new PlateLegs();
			legs.Hue = 1152;
			legs.Movable = false;
			AddItem( legs );

			new IceBeetle().Rider = this; 

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 13, 28 ) ) );
			pack.DropItem( Loot.RandomArmor() );
			pack.DropItem( Loot.RandomArmor() );

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseArmor armor = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor, 5, 15, 30 );

                       pack.DropItem( armor );
                  }

			Container bag = new Bag();
			bag.DropItem( new Gold( Utility.RandomMinMax( 35, 75 ) ) );
			bag.DropItem( new TurquoiseCustom( Utility.RandomMinMax( 2, 4 ) ) );
			bag.DropItem( new DiamondDust( Utility.RandomMinMax( 9, 18 ) ) );
			bag.DropItem( Loot.RandomPotion() );
			bag.DropItem( Loot.RandomGem() );
			bag.DropItem( Loot.RandomGem() );

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseArmor armor = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor, 5, 15, 20 );  

                       armor.Attributes.WeaponDamage = 5;

                       bag.DropItem( armor );
                  }

                  if ( Utility.RandomDouble() < 0.05 )
                  {
                       BaseJewel jewel = new GoldRing();
			     if ( Core.AOS )
		           BaseRunicTool.ApplyAttributesTo( jewel, 4, 15, 20 ); 

                       jewel.Hue = 1152;
                       jewel.Attributes.WeaponDamage = 7;
                       jewel.Resistances.Cold = 10;

                       bag.DropItem( jewel );
		      }

			pack.DropItem( bag );

			PackItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
			AddLoot( LootPack.Gems );

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                            BaseJewel jewel1 = new GoldEarrings();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( jewel1, 3, 15, 20 ); 

                            jewel1.Hue = 1152;
                            jewel1.Attributes.WeaponDamage = 6;
                            jewel1.Resistances.Cold = 9;

                            PackItem( jewel1 );
		            }

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                            BaseJewel jewel2 = new GoldNecklace();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( jewel2, 3, 15, 20 ); 

                            jewel2.Hue = 1152;
                            jewel2.Attributes.WeaponDamage = 9;
                            jewel2.Resistances.Cold = 8;

                            PackItem( jewel2 );
		            }

                        if ( Utility.RandomDouble() < 0.04 ) //4% chance to drop.
                        {
                            BaseWeapon weapon = new Lance();

                            weapon.Hue = 1152;

                            weapon.Attributes.WeaponDamage = 15;
                            weapon.WeaponAttributes.HitHarm = 5;
                            weapon.WeaponAttributes.HitLowerDefend = 10;

                            PackItem( weapon );
                        }
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public override bool HasBreath{ get{ return true; } } // cold breath enabled

		public override int BreathPhysicalDamage{ get{ return 30; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 70; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 00; } }

		public override int BreathEffectHue{ get{ return 1152; } }
		public override int BreathEffectItemID{ get{ return 0x36D4; } }
		public override int BreathEffectSound{ get{ return 0x160; } }
		public override int BreathAngerSound{ get{ return 0x597; } }

		public override bool ShowFameTitle{ get{ return false; } }
		public override bool ClickTitle{ get{ return false; } } // Do not display title in OnSingleClick

		private DateTime m_LastRadiated;
	        private Hashtable m_Mobiles = new Hashtable();

		protected override bool OnMove( Direction d )
		{
			if ( !IsDeadBondedPet )
			{
				if ( m_LastRadiated <= DateTime.Now )
					m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 10 ) );
				IPooledEnumerable eable = GetMobilesInRange( 2 );
				foreach( Mobile m in eable )
					if ( m_Mobiles[m] == null )
						m_Mobiles[m] = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( RadiationCallBack ), m );
			}

			return base.OnMove( d );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m_LastRadiated <= DateTime.Now )
					m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 10 ) );
			if ( !IsDeadBondedPet && m_Mobiles[m] == null && Utility.InRange( Location, m.Location, 2 ) && !Utility.InRange( Location, oldLocation, 2 ) )
				m_Mobiles[m] = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( RadiationCallBack ), m );

			base.OnMovement( m, oldLocation );
		}

		public void RadiationCallBack( object state )
		{
			Mobile m = (Mobile)state;

			if ( Deleted || !Alive || !Utility.InRange( Location, m.Location, 2 ) )
			{
				((Timer)m_Mobiles[m]).Stop();
				m_Mobiles[m] = null;
				return;
			}

			if ( this != m && m.AccessLevel == AccessLevel.Player && m_LastRadiated <= DateTime.Now && Server.Spells.SpellHelper.ValidIndirectTarget( m, this ) && CanBeHarmful( m, false, false ) )
			{
				AOS.Damage( m, this, Utility.Random( 25, 35 ), 0, 0, 100, 0, 0, true );
				m.PlaySound( 0x0FC );
				m.RevealingAction();
				DoHarmful( m );
				m.SendMessage( "The blizzard knight's icy aura damages you slowly as you stand near it!" );
				m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 5, 5 ) );
			}
		}

		public BlizzardKnight( Serial serial ) : base( serial )
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