// Evany - Jan 2012

using System;
using Server.Mobiles;
using Server.Targeting;
using Server.Spells;
using Server.Spells.Third;
using Server.Network;

namespace Server.Items
{
	public abstract class BaseRanged : BaseMeleeWeapon
	{
		public abstract Type TypeUsed{ get; }
		
		public abstract int EffectID{ get; }
		public abstract Type AmmoType{ get; } 
		public abstract Item Ammo{ get;}
		
		private AmmoTypes m_ArrowType;	
		
		public override int DefHitSound{ get{ return 0x234; } }
		public override int DefMissSound{ get{ return 0x238; } }

		public override SkillName DefSkill{ get{ return SkillName.Archery; } }
		public override WeaponType DefType{ get{ return WeaponType.Ranged; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootXBow; } }

		public override SkillName AccuracySkill{ get{ return SkillName.Archery; } }

		private Timer m_RecoveryTimer; // so we don't start too many timers
		private bool m_Balanced;
		private int m_Velocity;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public bool Balanced
		{
			get{ return m_Balanced; }
			set{ m_Balanced = value; InvalidateProperties(); }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Velocity
		{
			get{ return m_Velocity; }
			set{ m_Velocity = value; InvalidateProperties(); }
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public AmmoTypes TypeOfAmmo
		{
			get{ return m_ArrowType; }
			set{ m_ArrowType = value; InvalidateProperties(); }
		}

		public BaseRanged( int itemID ) : base( itemID )
		{
		}

		public BaseRanged( Serial serial ) : base( serial )
		{
		}
		
		public override void OnDoubleClick(Mobile from)
		{
			if ( IsChildOf( from.Backpack ) || Parent == from )
			{
				from.SendMessage("Select what type of ammo you wish to use.");
				from.Target = new InternalTarget( this, TypeUsed );
			}			
			else return;
		}
		
		public virtual Type TypeSelected( Type typeofammo )
		{
			if( typeofammo == typeof( Arrow ) )
			{
				switch( m_ArrowType )
				{
					case AmmoTypes.Oak: return typeof( OakArrow );
					case AmmoTypes.Yew: return typeof( YewArrow );
					case AmmoTypes.Ash: return typeof( AshArrow );
					case AmmoTypes.Bloodwood: return typeof( BloodwoodArrow );
					case AmmoTypes.Heartwood: return typeof( HeartwoodArrow );
					case AmmoTypes.Frostwood: return typeof( FrostwoodArrow );
					default:  return typeof( Arrow );
				}
			}
			else
			{
				switch( m_ArrowType )
				{
					case AmmoTypes.DullCopper: return typeof( DullCopperBolt );
					case AmmoTypes.ShadowIron: return typeof( ShadowIronBolt );
					case AmmoTypes.Copper: return typeof( CopperBolt );
					case AmmoTypes.Bronze: return typeof( BronzeBolt );
					case AmmoTypes.Gold: return typeof( GoldBolt );
					case AmmoTypes.Agapite: return typeof( AgapiteBolt );
					case AmmoTypes.Verite: return typeof( VeriteBolt );
					case AmmoTypes.Valorite: return typeof( ValoriteBolt );
					default:  return typeof( Bolt );
				}
			}
		}
		
		public virtual Item AmmoSelected( Type typeofammo )
		{
			if( typeofammo == typeof( Arrow ) )
			{
				switch( m_ArrowType )
				{
					case AmmoTypes.Oak: return new OakArrow();
					case AmmoTypes.Yew: return new YewArrow();
					case AmmoTypes.Ash: return new AshArrow();
					case AmmoTypes.Bloodwood: return new BloodwoodArrow();
					case AmmoTypes.Heartwood: return new HeartwoodArrow();
					case AmmoTypes.Frostwood: return new FrostwoodArrow();
					default:  return new Arrow();
				}
			}
			else
			{
				switch( m_ArrowType )
				{
					case AmmoTypes.DullCopper: return new DullCopperBolt();
					case AmmoTypes.ShadowIron: return new ShadowIronBolt();
					case AmmoTypes.Copper: return new CopperBolt();
					case AmmoTypes.Bronze: return new BronzeBolt();
					case AmmoTypes.Gold: return new GoldBolt();
					case AmmoTypes.Agapite: return new AgapiteBolt();
					case AmmoTypes.Verite: return new VeriteBolt();
					case AmmoTypes.Valorite: return new ValoriteBolt();
					default:  return new Bolt();
				}
			}
		}
		
		private class InternalTarget : Target
		{
			private BaseRanged Bow;
			private Type ammo;
			
			public InternalTarget( BaseRanged bow, Type typeofammo ) : base( 1, false, TargetFlags.None )
			{
				Bow = bow;
				ammo = typeofammo;
			}
			
			protected override void OnTarget(Mobile from, object targeted)
			{
				if ( targeted is BaseAmmo )				
				{
					BaseAmmo ammo = (BaseAmmo)targeted;
							
					if( Bow.TypeUsed == typeof( Arrow ) )
					{
						switch( ammo.AmmoTypes )
						{
							case AmmoTypes.Regular: Bow.TypeOfAmmo = AmmoTypes.Regular; break;
							case AmmoTypes.Oak: Bow.TypeOfAmmo = AmmoTypes.Oak; break;
							case AmmoTypes.Yew: Bow.TypeOfAmmo = AmmoTypes.Yew; break;
							case AmmoTypes.Ash: Bow.TypeOfAmmo = AmmoTypes.Ash; break;
							case AmmoTypes.Bloodwood: Bow.TypeOfAmmo = AmmoTypes.Bloodwood; break;
							case AmmoTypes.Heartwood: Bow.TypeOfAmmo = AmmoTypes.Heartwood; break;
							case AmmoTypes.Frostwood: Bow.TypeOfAmmo = AmmoTypes.Frostwood; break;
							default: from.SendMessage( "That's not a valid type of ammo for this weapon." ); return;
						}
						from.SendMessage( "The new type of ammo has been selected." );
					}
					else if( Bow.TypeUsed == typeof( Bolt ) )
					{
						switch( ammo.AmmoTypes )
						{
							case AmmoTypes.Regular: Bow.TypeOfAmmo = AmmoTypes.Regular; break;
							case AmmoTypes.DullCopper: Bow.TypeOfAmmo = AmmoTypes.DullCopper; break;
							case AmmoTypes.ShadowIron: Bow.TypeOfAmmo = AmmoTypes.ShadowIron; break;
							case AmmoTypes.Copper: Bow.TypeOfAmmo = AmmoTypes.Copper; break;
							case AmmoTypes.Bronze: Bow.TypeOfAmmo = AmmoTypes.Bronze; break;
							case AmmoTypes.Gold: Bow.TypeOfAmmo = AmmoTypes.Gold; break;
							case AmmoTypes.Agapite: Bow.TypeOfAmmo = AmmoTypes.Agapite; break;
							case AmmoTypes.Verite: Bow.TypeOfAmmo = AmmoTypes.Verite; break;
							case AmmoTypes.Valorite: Bow.TypeOfAmmo = AmmoTypes.Valorite; break;
							default: from.SendMessage( "That's not a valid type of ammo for this weapon." ); return;
						}
						from.SendMessage( "The new type of ammo has been selected." );
					}				
				}
				else from.SendMessage( "You can't select that!" );
			}
		}

		public override TimeSpan OnSwing( Mobile attacker, Mobile defender )
		{
			WeaponAbility a = WeaponAbility.GetCurrentAbility( attacker );

			// Make sure we've been standing still for .25/.5/1 second depending on Era
			if ( DateTime.Now > (attacker.LastMoveTime + TimeSpan.FromSeconds( Core.SE ? 0.25 : (Core.AOS ? 0.5 : 1.0) )) || (Core.AOS && WeaponAbility.GetCurrentAbility( attacker ) is MovingShot) )
			{
				bool canSwing = true;

				if ( Core.AOS )
				{
					canSwing = ( !attacker.Paralyzed && !attacker.Frozen );

					if ( canSwing )
					{
						Spell sp = attacker.Spell as Spell;

						canSwing = ( sp == null || !sp.IsCasting || !sp.BlocksMovement );
					}
				}

				if ( canSwing && attacker.HarmfulCheck( defender ) )
				{
					attacker.DisruptiveAction();
					attacker.Send( new Swing( 0, attacker, defender ) );

					if ( OnFired( attacker, defender ) )
					{
						if ( CheckHit( attacker, defender ) )
							OnHit( attacker, defender );
						else
							OnMiss( attacker, defender );
					}
				}

				attacker.RevealingAction();

				return GetDelay( attacker );
			}
			else
			{
				attacker.RevealingAction();

				return TimeSpan.FromSeconds( 0.25 );
			}
		}

		public override void OnHit( Mobile attacker, Mobile defender, double damageBonus )
		{
			if ( attacker.Player && !defender.Player && (defender.Body.IsAnimal || defender.Body.IsMonster) && 0.4 >= Utility.RandomDouble() )
				defender.AddToBackpack( Ammo );

			if ( Core.ML && m_Velocity > 0 )
			{
				int bonus = (int) attacker.GetDistanceToSqrt( defender );

				if ( bonus > 0 && m_Velocity > Utility.Random( 100 ) )
				{
					AOS.Damage( defender, attacker, bonus * 3, 100, 0, 0, 0, 0 );

					if ( attacker.Player )
						attacker.SendLocalizedMessage( 1072794 ); // Your arrow hits its mark with velocity!

					if ( defender.Player )
						defender.SendLocalizedMessage( 1072795 ); // You have been hit  by an arrow with velocity!
				}
			}
			
			if( Ammo is BaseAmmo ) // Make sure it's a valid type of ammo... if maybe someone set a log to be used as ammo it will crash!
				ApplyDamageEffect( defender, attacker, ((BaseAmmo)Ammo).AmmoTypes );

			base.OnHit( attacker, defender, damageBonus );			
			
		}
		
		public static void ApplyDamageEffect( Mobile defender, Mobile attacker, AmmoTypes typeAmmo )
		{
			double luck = attacker.Luck * .02;
			
			int physicaldamage = (int)( ( 100 - defender.GetResistance( ResistanceType.Physical) ) * .07 + luck );
			int colddamage = (int)( ( 100 - defender.GetResistance( ResistanceType.Cold) ) * .07 + luck  );
			int firedamage = (int)( ( 100 - defender.GetResistance( ResistanceType.Fire) ) * .07 + luck  );
			int poisondamage = (int)( ( 100 - defender.GetResistance( ResistanceType.Poison) ) * .07 + luck  );
			int energydamage = (int)( ( 100 - defender.GetResistance( ResistanceType.Energy) ) * .07 + luck  );
			
			if( physicaldamage < 1 ) physicaldamage = 1;
			if( colddamage < 1 ) colddamage = 1;
			if( firedamage < 1 ) firedamage = 1;
			if( poisondamage < 1 ) poisondamage = 1;
			if( energydamage < 1 ) energydamage = 1;
			
			switch( typeAmmo )
			{
				case AmmoTypes.Oak:
				{
					if( ( 0.1 + luck ) > Utility.RandomDouble()  )
						defender.Damage( physicaldamage, attacker );
					else 
						AOS.Damage( defender, Utility.Random ( 1, 5 ), 100, 0, 0, 0, 0 );
					
					break;
				}
				case AmmoTypes.Yew:
				{		
					if( ( 0.1 + luck ) > Utility.RandomDouble()  )
						defender.Damage( physicaldamage + 3, attacker );
					else 
						AOS.Damage( defender, Utility.Random ( 3, 6 ), 100, 0, 0, 0, 0 );
					
					break;
				}
				case AmmoTypes.Ash:
				{
					if( ( 0.1 + luck ) > Utility.RandomDouble()  )
					{
						SpellHelper.Damage( new FireballSpell( attacker, null ), defender, Utility.RandomMinMax( 10, 30 ), 0, 100, 0, 0, 0 );
						attacker.MovingParticles( defender, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160 );
						attacker.PlaySound( Core.AOS ? 0x15E : 0x44B );
					}
					else AOS.Damage( defender, Utility.Random ( 1, 5 ), 0, 100, 0, 0, 0 );
					
					break;
				}
				case AmmoTypes.Bloodwood:
				{
					if( ( 0.1 + luck ) > Utility.RandomDouble()  )
					{
						defender.PlaySound( 0x133 );
						defender.FixedParticles( 0x377A, 244, 25, 9950, 31, 0, EffectLayer.Waist );
						BleedAttack.BeginBleed( defender, attacker );
					}
					else AOS.Damage( defender, Utility.Random ( 1, 5 ), 100, 0, 0, 0, 0 );
					
					break;
				}
				case AmmoTypes.Heartwood:
				{
					if( ( 0.1 + luck ) > Utility.RandomDouble()  )
					{
						defender.PlaySound( 0xDD );
						defender.FixedParticles( 0x3728, 244, 25, 9941, 1266, 0, EffectLayer.Waist );
						
						if( attacker.Skills[SkillName.Poisoning].Value > Utility.RandomMinMax( 50, 250 ) )
							defender.ApplyPoison( attacker, Poison.Deadly );
						else 
							defender.ApplyPoison( attacker, Poison.Regular );
					}
					else AOS.Damage( defender, Utility.Random ( 1, 5 ),  0, 0, 0, 100, 0 );
					
					break;
				}
				case AmmoTypes.Frostwood:
				{
					if( ( 0.15 + luck ) > Utility.RandomDouble() )
					{
						TimeSpan duration = defender.Player ? TimeSpan.FromSeconds( 4 ) : TimeSpan.FromSeconds( 8 );
						defender.Paralyze( duration );
						ParalyzingBlow.BeginImmunity( defender, duration + TimeSpan.FromSeconds( 4 ) );
						defender.FixedEffect( 0x376A, 9, 32 );
						defender.PlaySound( 0x204 );
					}
					else AOS.Damage( defender, Utility.Random( 1, 5 ),  0, 100, 15, 0, 0 );
					
					break;
				}
				case AmmoTypes.DullCopper:
				{
					if( ( 0.3 + luck ) > Utility.RandomDouble()  )
					{
						AOS.Damage( defender, Utility.RandomMinMax( 8, 18 ), true, 100, 0, 0, 0, 0 );
						defender.FixedParticles( 0x3728, 1, 26, 0x26D6, 0, 0, EffectLayer.Waist );
						defender.PlaySound( 0x56 );
					}
					else AOS.Damage( defender, Utility.Random ( 1, 8 ), 100, 0, 0, 0, 0 );
					
					break;
				}
				case AmmoTypes.ShadowIron:
				{
					if( ( 0.1 + luck ) > Utility.RandomDouble()  )
					{
						defender.Damage( energydamage, attacker );
						defender.PlaySound( 0x56 );
					}
					else AOS.Damage( defender, 5,  0, 0, 0, 0, 40 );
					break;
				}
				case AmmoTypes.Copper:
				{
					if( ( 0.1 + luck ) > Utility.RandomDouble()  )
					{
						defender.Damage( energydamage, attacker );
						defender.Damage( poisondamage, attacker );
						defender.PlaySound( 0x56 );
					}
					else AOS.Damage( defender, 5,  0, 0, 0, 30, 30 );
					break;
				}
				case AmmoTypes.Bronze:
				{	
					if( ( 0.1 + luck ) > Utility.RandomDouble()  )
					{
						defender.Damage( physicaldamage, attacker );
						defender.Damage( firedamage, attacker );
						defender.PlaySound( 0x56 );
					}
					else AOS.Damage( defender, 5,  15, 40, 0, 0, 0 );
					break;
				}
				case AmmoTypes.Gold:
				{
					if( ( 0.1 + luck ) > Utility.RandomDouble()  )
					{
						defender.Damage( physicaldamage, attacker );
						defender.Damage( firedamage, attacker );
						defender.Damage( colddamage, attacker );
						defender.PlaySound( 0x56 );
					}
					else AOS.Damage( defender, 5,  20, 15, 15, 0, 0 );
					break;
				}
				case AmmoTypes.Agapite:
				{
					if( ( 0.1 + luck ) > Utility.RandomDouble()  )
					{
						defender.Damage( physicaldamage, attacker );
						defender.Damage( firedamage, attacker );
						defender.Damage( energydamage, attacker );
						defender.PlaySound( 0x56 );
					}
					else AOS.Damage( defender, 5,  25, 30, 0, 0, 20 );
					break;
				}
				case AmmoTypes.Verite:
				{
					if( ( 0.1 + luck ) > Utility.RandomDouble()  )
					{
						defender.Damage( physicaldamage, attacker );
						defender.Damage( poisondamage, attacker );
						defender.Damage( energydamage, attacker );
						defender.PlaySound( 0x56 );
					}
					else AOS.Damage( defender, 5,  30, 0, 0, 40, 20 );
					break;
				}
				case AmmoTypes.Valorite:
				{	
					if( ( 0.1 + luck ) > Utility.RandomDouble() )
					{
						defender.Damage( physicaldamage, attacker );
						defender.Damage( firedamage, attacker );
						defender.Damage( colddamage, attacker );
						defender.Damage( poisondamage, attacker );
						defender.Damage( energydamage, attacker );
						defender.PlaySound( 0x56 );
					}
					else AOS.Damage( defender, 5,  50, 10, 20, 10, 20 );
					break;
				}
				default: break;
			}
		}

		public override void OnMiss( Mobile attacker, Mobile defender )
		{
			if ( attacker.Player && 0.4 >= Utility.RandomDouble() )
			{
				if ( Core.SE )
				{
					PlayerMobile p = attacker as PlayerMobile;

					if ( p != null )
					{
						Type ammo = AmmoType;

						if ( p.RecoverableAmmo.ContainsKey( ammo ) )
							p.RecoverableAmmo[ ammo ]++;
						else
							p.RecoverableAmmo.Add( ammo, 1 );

						if ( !p.Warmode )
						{
							if ( m_RecoveryTimer == null )
								m_RecoveryTimer = Timer.DelayCall( TimeSpan.FromSeconds( 10 ), new TimerCallback( p.RecoverAmmo ) );

							if ( !m_RecoveryTimer.Running )
								m_RecoveryTimer.Start();
						}
					}
				} else {
					Ammo.MoveToWorld( new Point3D( defender.X + Utility.RandomMinMax( -1, 1 ), defender.Y + Utility.RandomMinMax( -1, 1 ), defender.Z ), defender.Map );
				}
			}

			base.OnMiss( attacker, defender );
		}

		public virtual bool OnFired( Mobile attacker, Mobile defender )
		{
			BaseQuiver quiver = attacker.FindItemOnLayer( Layer.Cloak ) as BaseQuiver;
			Container pack = attacker.Backpack;

			if ( attacker.Player )
			{
				if ( quiver == null || quiver.LowerAmmoCost == 0 || quiver.LowerAmmoCost > Utility.Random( 100 ) )
				{					 
					if ( quiver != null && quiver.ConsumeTotal( AmmoType, 1 ) )
					quiver.InvalidateWeight();
					else if ( pack == null || !pack.ConsumeTotal( AmmoType, 1 ) )
					return false;
				}
			}

			attacker.MovingEffect( defender, EffectID, 18, 1, false, false );

			return true;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 4 ); // version
			
			writer.WriteEncodedInt( (int) m_ArrowType );

			writer.Write( (bool) m_Balanced );
			writer.Write( (int) m_Velocity );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 4:
				{
					m_ArrowType = ( AmmoTypes )reader.ReadEncodedInt();
					goto case 3;
				}
				case 3:
				{
					m_Balanced = reader.ReadBool();
					m_Velocity = reader.ReadInt();

					goto case 2;
				}
				case 2:
				case 1:
				{
					break;
				}
				case 0:
				{
					/*m_EffectID =*/ reader.ReadInt();
					break;
				}
			}

			if ( version < 2 )
			{
				WeaponAttributes.MageWeapon = 0;
				WeaponAttributes.UseBestSkill = 0;
			}
		}
	}
}