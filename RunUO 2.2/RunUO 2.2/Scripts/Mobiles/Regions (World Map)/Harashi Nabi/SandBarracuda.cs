using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;
using Server.Spells;
using Server.Spells.Fifth;
using Server.Spells.Seventh;

namespace Server.Mobiles
{
	[CorpseName( "a sand barracuda corpse" )]
	public class SandBarracuda : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public SandBarracuda() : base( AIType.AI_Animal, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = "a sand barracuda";
			Body = 0x97;
                        Hue = 1864;
			BaseSoundID = 0x8A;

			SetStr( 224, 342 );
			SetDex( 73, 83 );
			SetInt( 97, 110 );

			SetHits( 520, 654 );

			SetDamage( 8, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 16 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 15.1, 18.8 );
			SetSkill( SkillName.Tactics, 73.5, 84.6 );
			SetSkill( SkillName.Wrestling, 71.2, 82.8 );

			Fame = 2000;
			Karma = -2000;

			CanSwim = true;
			CantWalk = false;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 35.5;

                        PackGold( 213, 319 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new FireballScroll() );
		}

		public override int Meat { get { return 1; } }

		public override void GenerateLoot()
		{
 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			        BaseShield shield = new MetalKiteShield();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( shield, 5, 25, 30 ); 

                                shield.Attributes.BonusStam = 8;

                                PackItem( shield );
                        }

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			        BaseClothing clothing = Loot.RandomClothing( true );
		                BaseRunicTool.ApplyAttributesTo( clothing, 3, 15, 20 );  

                                clothing.Attributes.BonusHits = 7;

                                PackItem( clothing );
                        }

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                BaseJewel jewel1 = new GoldEarrings();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( jewel1, 3, 15, 20 ); 

                                jewel1.Resistances.Fire = 5;

                                PackItem( jewel1 );
		        }

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                BaseJewel jewel2 = new GoldNecklace();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( jewel2, 3, 15, 20 ); 

                                jewel2.Resistances.Fire = 7;

                                PackItem( jewel2 );
		        }

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                BaseJewel jewel3 = new GoldRing();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( jewel3, 3, 15, 20 ); 

                                jewel3.Resistances.Fire = 6;

                                PackItem( jewel3 );
		        }
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

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

		public void Polymorph( Mobile m )
		{
			if ( !m.CanBeginAction( typeof( PolymorphSpell ) ) || !m.CanBeginAction( typeof( IncognitoSpell ) ) || m.IsBodyMod )
				return;

			IMount mount = m.Mount;

			if ( mount != null )
				mount.Rider = null;

			if ( m.Mounted )
				return;

			if ( m.BeginAction( typeof( PolymorphSpell ) ) )
			{
				Item disarm = m.FindItemOnLayer( Layer.OneHanded );

				if ( disarm != null && disarm.Movable )
					m.AddToBackpack( disarm );

				disarm = m.FindItemOnLayer( Layer.TwoHanded );

				if ( disarm != null && disarm.Movable )
					m.AddToBackpack( disarm );

				m.BodyMod = 0x97;
				m.HueMod = 1864;

				new ExpirePolymorphTimer( m ).Start();
			}
		}

		private class ExpirePolymorphTimer : Timer
		{
			private Mobile m_Owner;

			public ExpirePolymorphTimer( Mobile owner ) : base( TimeSpan.FromMinutes( 3.0 ) )
			{
				m_Owner = owner;

				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
				if ( !m_Owner.CanBeginAction( typeof( PolymorphSpell ) ) )
				{
					m_Owner.BodyMod = 0;
					m_Owner.HueMod = -1;
					m_Owner.EndAction( typeof( PolymorphSpell ) );
				}
			}
		}

		public void DoSpecialAbility( Mobile target )
		{
			if ( target == null || target.Deleted ) //sanity
				return;
			if ( 0.6 >= Utility.RandomDouble() ) // 60% chance to polymorph attacker into a sand barracuda
				Polymorph( target );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoSpecialAbility( attacker );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			DoSpecialAbility( defender );
		}

		public SandBarracuda( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( from.AccessLevel >= AccessLevel.GameMaster )
				Jump();
		}

		public virtual void Jump()
		{
			if( Utility.RandomBool() )
				Animate( 3, 16, 1, true, false, 0 );
			else
				Animate( 4, 20, 1, true, false, 0 );
		}

		public override void OnThink()
		{
			if( Utility.RandomDouble() < .005 ) // slim chance to jump
				Jump();

			base.OnThink();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}