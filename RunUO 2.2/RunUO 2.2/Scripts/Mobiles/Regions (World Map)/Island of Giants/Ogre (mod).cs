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
	[CorpseName( "an ogre corpse" )]
	public class Ogre : BaseCreature
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
		public Ogre() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
			Name = "an ogre";
			Body = 1;
			BaseSoundID = 427;

			SetStr( 148, 194 );
			SetDex( 48, 60 );
			SetInt( 49, 65 );

			SetHits( 200, 234 );
			SetMana( 0 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 32 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.Macing, 74.1, 81.3 );
			SetSkill( SkillName.MagicResist, 56.3, 69.8 );
			SetSkill( SkillName.Tactics, 60.5, 69.1 );
			SetSkill( SkillName.Wrestling, 74.1, 81.3 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 32;

			PackGold( 216, 221 );

 		        if ( Utility.RandomDouble() < 0.15 )
                        {
			     BaseWeapon weapon = new Club();
			     if ( Core.AOS )
		             BaseRunicTool.ApplyAttributesTo( weapon, 3, 15, 30 ); 

                             AddItem( weapon );
                        }

			Container pack = new Backpack();

			pack.DropItem( new Arrow( Utility.RandomMinMax( 8, 13 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );

 		        if ( Utility.RandomDouble() < 0.15 )
                        {
			     BaseJewel ring = new GoldRing();
			     if ( Core.AOS )
		             BaseRunicTool.ApplyAttributesTo( ring, 2, 15, 30 ); 

                             pack.DropItem( ring );
                        }

			if ( 0.05 > Utility.RandomDouble() )
				pack.DropItem( new Peridot() );

			PackItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions, 2 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison HitPoison{ get{ return Poison.Lesser; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(2), from);
                              corpse.AddCarvedItem(new OgreEye(), from);

                              from.SendMessage( "You carve up a raw rib and an ogre eye." );
                              corpse.Carved = true; 
			}
                }

		public override void OnGaveMeleeAttack(Mobile defender)
		{
			base.OnGaveMeleeAttack(defender);
			if (0.1 >= Utility.RandomDouble() )
				Earthquake();
		}

		public void Earthquake()
		{
			Map map = this.Map;
			if (map == null)
				return;
			ArrayList targets = new ArrayList();
			foreach (Mobile m in this.GetMobilesInRange(8))
			{
				if (m == this || !CanBeHarmful(m))
					continue;
				if (m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team))
					targets.Add(m);
				else if (m.Player)
					targets.Add(m);
			}
			PlaySound(0x2F3);
			for (int i = 0; i < targets.Count; ++i)
			{
				Mobile m = (Mobile)targets[i];
				if( m != null && !m.Deleted && m is PlayerMobile )
				{
					PlayerMobile pm = m as PlayerMobile;
					if(pm != null && pm.Mounted)
					{
						pm.Mount.Rider=null;
					}
				}
				double damage = m.Hits * 0.6;//was .6
				if (damage < 10.0)
					damage = 10.0;
				else if (damage > 75.0)
					damage = 75.0;
				DoHarmful(m);
				AOS.Damage(m, this, (int)damage, 100, 0, 0, 0, 0);
				if (m.Alive && m.Body.IsHuman && !m.Mounted)
					m.Animate(20, 7, 1, true, false, 0); // take hit
			}
		}

		public Ogre( Serial serial ) : base( serial )
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