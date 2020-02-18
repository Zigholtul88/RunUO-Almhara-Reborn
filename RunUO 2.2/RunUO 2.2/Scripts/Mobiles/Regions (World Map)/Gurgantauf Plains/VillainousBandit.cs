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
using Server.ACC.CSS.Systems.Rogue; 

namespace Server.Mobiles
{
	public class VillainousBandit : BaseCreature
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 15.0 ); //the delay between talks is 15 seconds
		public DateTime m_NextTalk;

                private DateTime m_NextWeaponChange;

		public override bool ClickTitle{ get{ return false; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public VillainousBandit() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomDyedHue();
			Name = NameList.RandomName( "male" );
			Body = 0x190;
			Title = "the villainous bandit";
			Hue = Utility.RandomSkinHue();

			SetStr( 100, 150 );
			SetDex( 24, 178 );
			SetInt( 19, 98 );

			SetHits( 100, 150 );

			SetDamage( 4, 10 );

			SetSkill( SkillName.Archery, 95.1, 100.0 );
			SetSkill( SkillName.Bushido, 120.0 );
			SetSkill( SkillName.Fencing, 95.0, 97.5 );
			SetSkill( SkillName.Macing, 93.0, 98.5 );
			SetSkill( SkillName.MagicResist, 0.0 );
			SetSkill( SkillName.Parry, 120.0 );
			SetSkill( SkillName.Swords, 98.0, 99.5 );
			SetSkill( SkillName.Tactics, 89.0, 93.5 );
			SetSkill( SkillName.Wrestling, 63.0, 81.5 );

			Fame = 2000;
			Karma = -2000;

			PackGold( 52, 87 );

			AddItem( new Bandana());

			switch ( Utility.Random( 3 ))
			{
				case 0: AddItem( new Shirt() ); break;
				case 1: AddItem( new FancyShirt() ); break;
				case 2: AddItem( new ReinassanceShirt() ); break;
			}

			switch ( Utility.Random( 5 ))
			{
				case 0: AddItem( new FancyPants() ); break;
				case 1: AddItem( new Kilt() ); break;
				case 2: AddItem( new LongPants() ); break;
				case 3: AddItem( new ReinassancePants() ); break;
				case 4: AddItem( new ShortPants() ); break;
			}

			switch ( Utility.Random( 6 ))
			{
				case 0: AddItem( new Boots() ); break;
				case 1: AddItem( new HeavyBoots() ); break;
				case 2: AddItem( new HighBoots() ); break;
				case 3: AddItem( new LightBoots() ); break;
				case 4: AddItem( new ShortBoots() ); break;
				case 5: AddItem( new ThighBoots() ); break;
			}

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 5, 208 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new FishScale( Utility.RandomMinMax( 4, 8 ) ) );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( new OneGoldBar() );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( new FireOpal() );

			if ( 0.10 > Utility.RandomDouble() )
				pack.DropItem( new RogueCharmScroll() );

			PackItem( pack );

			switch ( Utility.Random( 6 ))
			{
				case 0: AddItem( new Longsword() ); break;
				case 1: AddItem( new Cutlass() ); break;
				case 2: AddItem( new Axe() ); break;
				case 3: AddItem( new Club() ); break;
				case 4: AddItem( new Dagger() ); break;
				case 5: AddItem( new Spear() ); break;
			}

			PackItem( new Bow() );
			PackItem( new Arrow( Utility.RandomMinMax( 80, 90 ) ) );

			Utility.AssignRandomHair( this );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );

 		      if ( Utility.RandomDouble() < 0.15 )
                      {
			     BaseWeapon weapon = Loot.RandomWeapon( true );
			     if ( Core.AOS )
		             BaseRunicTool.ApplyAttributesTo( weapon, 2, 10, 20 ); 

                             PackItem( weapon );
                      }

 		      if ( Utility.RandomDouble() < 0.15 )
                      {
			     BaseClothing clothing = Loot.RandomClothing( true );
			     if ( Core.AOS )
		             BaseRunicTool.ApplyAttributesTo( clothing, 2, 10, 20 ); 

                             PackItem( clothing );
                      }
		}

		public override bool AlwaysMurderer{ get{ return true; } }

		public override int GetHurtSound() { return 1081; } //play male oomph 6
		public override int GetAngerSound() { return 1074; } //play male no
		public override int GetDeathSound() { return 348; } //play male die 3

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.2 > Utility.RandomDouble() )
			{
				/* Blood Bath
				 * Start cliloc 1070826
				 * Sound: 0x52B
				 * 2-3 blood spots
				 * Damage: 3 hps per second for 20 seconds
				 * End cliloc: 1070824
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if( timer != null )
				{
					timer.DoExpire();
                                        defender.SendMessage( "The bandit continues inflicting bleeding damage!" );
				}
				else
                                        defender.SendMessage( "The bandit goes into a rage, inflicting continuous bleeding damage!" );

				timer = new ExpireTimer( defender, this );
				timer.Start();
				m_Table[defender] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private Mobile m_From;
			private int m_Count;

			public ExpireTimer( Mobile m, Mobile from ): base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			public void DoExpire()
			{
				Stop();
				m_Table.Remove( m_Mobile );
			}

			public void DrainLife()
			{
				if( m_Mobile.Alive )
					m_Mobile.Damage( 3, m_From );
				else
					DoExpire();
			}

			protected override void OnTick()
			{
				DrainLife();

				if( ++m_Count >= 20 )
				{
					DoExpire();
                                        m_Mobile.SendMessage( "The blood clouting from the bandit's attack subsides." );
				}
			}
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 8 ) && InLOS( m ) && m is PlayerMobile ) // check if it's time to talk & mobile in range & in los.
			{
 			        if ( Utility.RandomDouble() < 0.05 )
                                {
			                RangePerception = 200;
				        this.Combatant = m;
                                }

				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 6 ))
				{
					case 0: Say("You're just the type of action I've been waiting for!"); 
						PlaySound(1066); //play male giggle
						break;
					case 1: Say("I'm so exicited and I just can't hide it"); 
						PlaySound(1098); //play male yell
						break;	
					case 2: Say("I've had sheep that put up a better fight."); 
						PlaySound(1090); //play male sigh
						break;	
					case 3: Say("Once I'm done I plan on doing things to your body!"); 
						PlaySound(1095); //play male whistle
						break;	
					case 4: Say("Oui, now that's a stench good for the hogs."); 
						PlaySound(1064); //play male fart
						break;	
					case 5: Say("You think you can best me? You haven't seen shit!"); 
						PlaySound(1054); //play male cheer
						break;	
				};
			}
		}

                public override void OnThink()
                {
                        base.OnThink();

                        if ( Combatant != null && m_NextWeaponChange < DateTime.UtcNow )
                           ChangeWeapon();
                }

                private void ChangeWeapon()
                {
                        if ( Backpack == null )
                             return;

                        Item item = FindItemOnLayer(Layer.OneHanded);

                        if ( item == null )
                             item = FindItemOnLayer(Layer.TwoHanded);

                        System.Collections.Generic.List<BaseWeapon> weapons = new System.Collections.Generic.List<BaseWeapon>();

                        foreach (Item i in Backpack.Items)
                        {
                                if (i is BaseWeapon && i != item)
                                    weapons.Add((BaseWeapon)i);
                        }

                        if (weapons.Count > 0)
                        {
                                if (item != null)
                                Backpack.DropItem(item);

                                AddItem(weapons[Utility.Random(weapons.Count)]);

                                m_NextWeaponChange = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(30, 60));
                        }
                }

		public VillainousBandit( Serial serial ) : base( serial )
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

                        m_NextWeaponChange = DateTime.UtcNow;
		}
	}
}