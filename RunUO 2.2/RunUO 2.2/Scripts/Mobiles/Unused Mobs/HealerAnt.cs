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
	[CorpseName( "a healer ant corpse" )]
	public class HealerAnt : BaseCreature
	{
		[Constructable]
		public HealerAnt() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a healer ant";
			Body = 738;
			Hue = 0x851;
			BaseSoundID = 959;

			SetStr( 76, 100 );
			SetDex( 126, 145 );
			SetInt( 36, 60 );

			SetHits( 115, 143 );
			SetMana( 0 );

			SetDamage( 0 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Cold, 80 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 35.1, 50.0 );
			SetSkill( SkillName.Wrestling, 50.1, 65.0 );

			Fame = 800;
			Karma = -800;

                        Flying = true;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 60.5;

			AOEHealTimer.AOEHealList.Add( this );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new CureScroll() );
		}

		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay | FoodType.Meat; } }

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{      
 			if ( !Flying && Utility.RandomDouble() < 0.25 )
                        {
				 this.FixedParticles( 0, 10, 0, 0x2522, EffectLayer.Waist );
                                 Flying = true;
				 from.SendMessage( "Healer ant activates its energy shield" );
                        }

			base.OnDamage( amount, from, willKill );
                }

		public override void OnDamagedBySpell( Mobile from )
		{
			if ( Flying )
			{
				this.FixedParticles( 0x3735, 1, 30, 0x251F, EffectLayer.Waist );
                                Flying = false;
				from.SendMessage( "Healer ant's energy shield has been broken" );
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if( attacker != null && attacker.Alive && attacker.Weapon is BaseRanged )
			{
			        if ( Flying )
			        {
				     this.FixedParticles( 0x3735, 1, 30, 0x251F, EffectLayer.Waist );
				     attacker.SendMessage( "Healer ant's energy shield has been broken" );
                                     Flying = false;
			        }
			}
			else if ( Flying )
			{
				this.FixedParticles( 0x376A, 20, 10, 0x2530, EffectLayer.Waist );
				PlaySound( 0x2F4 );
				attacker.SendMessage( "Your weapon misses" );
			}
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( Flying )
				damage = 0; // no melee damage when flying

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
							damage += 5;
						}
                                                else
                                                {
							damage = 5;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseRanged )
						{
							damage += 5;
						}
                                                else
                                                {
							damage = 5;
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

                              corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 11, 16 )), from);

                              from.SendMessage( "You carve up some gold." ); 
			}
                }

		public void OnTick()
		{
                        if ( this.Controlled )
		             AOEHealEffect();
		}

	        public class AOEHealTimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<HealerAnt> AOEHealList = new List<HealerAnt>();

		        public static void Initialize() 
		        {
			        if (Enabled)
				        new AOEHealTimer().Start();
		        }

		        public AOEHealTimer() : base(TimeSpan.FromSeconds( 10.0 ), TimeSpan.FromSeconds( 10.0 )) 
		        {
			        Priority = TimerPriority.OneSecond;
		        }

		        protected override void OnTick() 
		        {
			        foreach (HealerAnt healerant in AOEHealList)
				        healerant.OnTick();
		        }
	        }

                public void AOEHealEffect()
                {
                        List<Mobile> list = new List<Mobile>();

                        foreach ( Mobile m in GetMobilesInRange( 5 ) )
                        {
                             if ( !CanBeBeneficial ( m ) )
                             continue;

                             if ( m.Player )
                             list.Add ( m );
                        }

                        foreach ( Mobile m in list )
                        {
                               if ( m == this || !CanBeBeneficial( m ) )
                               continue;

                               if ( !m.Player && !( m is BaseCreature && ( (BaseCreature)m).ControlMaster.Player) )
                               continue;

                               if ( m.Player && m.Alive )
                               {
                                       if ( m.Hits < m.HitsMax )
                                       {
		                            m.Hits += ( Utility.Random( 25, 50 ) ); 

		                            m.FixedParticles( 0x375A, 1, 30, 9966, 88, 2, EffectLayer.Head ); 
           	                            m.FixedParticles( 0x37B9, 1, 30, 9502, 85, 3, EffectLayer.Head );
		                            m.FixedParticles( 0x376A, 1, 31, 9961, 80, 0, EffectLayer.Waist );
           	                            m.FixedParticles( 0x37C4, 1, 31, 9502, 88, 2, EffectLayer.Waist );
				            m.PlaySound( 0x202 );

				            DoBeneficial( m );
				            m.RevealingAction();
                                       }
                               }
                        }
                }

		public HealerAnt( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 387 )
				BaseSoundID = 0x388;

			AOEHealTimer.AOEHealList.Add(this);
		}
	}
}