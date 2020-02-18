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
	[CorpseName( "an ore elemental corpse" )]
	public class BronzeElemental : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}

		[Constructable]
		public BronzeElemental() : this( 25 )
		{
		}

		[Constructable]
		public BronzeElemental( int oreAmount ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a bronze elemental";
			Body = 108;
			BaseSoundID = 268;

			SetStr( 426, 455 );
			SetDex( 126, 145 );
			SetInt( 71, 92 );

			SetHits( 536, 653 );

			SetDamage( 5, 15 );

			SetDamageType( ResistanceType.Physical, 30 );
			SetDamageType( ResistanceType.Fire, 70 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 70 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.MagicResist, 50.1, 95.0 );
			SetSkill( SkillName.Poisoning, 120.1, 140.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 5000;
			Karma = -5000;

			PackGold( 519, 625 );

			PackItem( new ElementalDust( Utility.RandomMinMax( 58, 112 ) ) );

			Item ore = new BronzeOre( oreAmount );
			ore.ItemID = 0x19B9;
			PackItem( ore );

 			if ( Utility.RandomDouble() < 0.01 )
				PackItem( new TreasureMap( 1, Map.Malas ) );

			switch ( Utility.Random( 9 ))
			{
				case 0: PackItem( new Agate() ); break;
				case 1: PackItem( new Beryl() ); break;
				case 2: PackItem( new ChromeDiopside() ); break;
				case 3: PackItem( new FireOpal() ); break;
				case 4: PackItem( new MoonstoneCustom() ); break;
				case 5: PackItem( new Onyx() ); break;
				case 6: PackItem( new Opal() ); break;
				case 7: PackItem( new Pearl() ); break;
				case 8: PackItem( new TurquoiseCustom() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 10 );
			AddLoot( LootPack.Potions, 2 );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override bool AutoDispel{ get{ return true; } }

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
						if ( weapon1 is BaseBashing )
						{
							damage *= 25;
						}
                                                else
                                                {
							damage -= 500;
							from.SendMessage("Your weapon deals little damage to the bronze elemental.");
                                                }
					}

					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseBashing )
						{
							damage *= 25;
						}
                                                else
                                                {
							damage -= 500;
							from.SendMessage("Your weapon deals little damage to the bronze elemental.");
                                                }
					}
				}
			}
		}

		public override void OnDamagedBySpell( Mobile attacker )
		{
			base.OnDamagedBySpell( attacker );

			DoCounter( attacker );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			DoCounter( attacker );
		}

		private void DoCounter( Mobile attacker )
		{
			if( this.Map == null )
				return;

			if ( attacker is BaseCreature && ((BaseCreature)attacker).BardProvoked )
				return;

			if ( 0.2 > Utility.RandomDouble() )
			{
				/* Counterattack with Hit Poison Area
				 * 20-25 damage, unresistable
				 * Regular poison, 100% of the time
				 * Particle effect: Type: "2" From: "0x4061A107" To: "0x0" ItemId: "0x36BD" ItemIdName: "explosion" FromLocation: "(296 615, 17)" ToLocation: "(296 615, 17)" Speed: "1" Duration: "10" FixedDirection: "True" Explode: "False" Hue: "0xA6" RenderMode: "0x0" Effect: "0x1F78" ExplodeEffect: "0x1" ExplodeSound: "0x0" Serial: "0x4061A107" Layer: "255" Unknown: "0x0"
				 * Doesn't work on provoked monsters
				 */

				Mobile target = null;

				if ( attacker is BaseCreature )
				{
					Mobile m = ((BaseCreature)attacker).GetMaster();
					
					if( m != null )
						target = m;
				}

				if ( target == null || !target.InRange( this, 18 ) )
					target = attacker;

				this.Animate( 10, 4, 1, true, false, 0 );

				ArrayList targets = new ArrayList();

				foreach ( Mobile m in target.GetMobilesInRange( 8 ) )
				{
					if ( m == this || !CanBeHarmful( m ) )
						continue;

					if ( m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team) )
						targets.Add( m );
					else if ( m.Player && m.Alive )
						targets.Add( m );
				}

				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];

					DoHarmful( m );

					AOS.Damage( m, this, Utility.RandomMinMax( 20, 25 ), true, 0, 0, 0, 100, 0 );

					m.FixedParticles( 0x36BD, 1, 10, 0x1F78, 0xA6, 0, (EffectLayer)255 );
					m.ApplyPoison( this, Poison.Regular );
				}
			}
		}

		public BronzeElemental( Serial serial ) : base( serial )
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