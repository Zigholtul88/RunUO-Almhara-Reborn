using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a mesmenir corpse" )]
	public class Mesmenir : BaseCreature
	{
		[Constructable]
		public Mesmenir() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a mesmenir";
			Body = 0x7A;
			Hue = 2583;
			BaseSoundID = 0xA8;

			SetStr( 226, 252 );
			SetDex( 266, 285 );
			SetInt( 102, 121 );

			SetHits( 335, 398 );

			SetDamage( 12, 15 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Energy, 40 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 45 );

			SetSkill( SkillName.MagicResist, 48.9, 69.7 );
			SetSkill( SkillName.Tactics, 77.9, 88.8 );
			SetSkill( SkillName.Wrestling, 48.6, 60.4 );

			Fame = 14500;
			Karma = -14500;

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 21, 27 ) ) );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( new Beryl() );

			if ( 0.10 > Utility.RandomDouble() )
				pack.DropItem( new NightSightScroll() );

 		        if ( Utility.RandomDouble() < 0.15 )
                        {
			     BaseArmor armor1 = Loot.RandomArmor( true );
		             BaseRunicTool.ApplyAttributesTo( armor1, 3, 10, 25 );  

                             pack.DropItem( armor1 );
                        }

 		        if ( Utility.RandomDouble() < 0.15 )
                        {
			     BaseArmor armor2 = Loot.RandomArmor( true );
		             BaseRunicTool.ApplyAttributesTo( armor2, 3, 10, 25 );  

                             pack.DropItem( armor2 );
                        }

 		        if ( Utility.RandomDouble() < 0.15 )
                        {
			     BaseWeapon weapon = Loot.RandomWeapon( true );
		             BaseRunicTool.ApplyAttributesTo( weapon, 3, 10, 25 );  

                             pack.DropItem( weapon );
                        }

 		        if ( Utility.RandomDouble() < 0.15 )
                        {
			     BaseJewel necklace = new GoldNecklace();
			     if ( Core.AOS )
		             BaseRunicTool.ApplyAttributesTo( necklace, 2, 10, 15 ); 

                             pack.DropItem( necklace );
                        }

			PackItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(5), from);
                        corpse.AddCarvedItem(new BarbedHides(10), from);
                        corpse.AddCarvedItem(new MesmenirHorn(), from);

                        from.SendMessage( "You carve up 5 ribs, some barbed hides, and a mesmenir horn" );
                        corpse.Carved = true; 
			}
                }

		public override bool BleedImmune{ get{ return true; } }


	        public override void OnDamagedBySpell( Mobile attacker )
	        {
		        base.OnDamagedBySpell( attacker );

                        if ( 0.3 >= Utility.RandomDouble() )
                        this.Lightning();
	        }

                public override void OnGaveMeleeAttack( Mobile defender )
                {
                        base.OnGaveMeleeAttack( defender );

                        if ( 0.3 >= Utility.RandomDouble() )
                        this.Lightning();
                }

                public override void OnGotMeleeAttack( Mobile attacker )
	        {
		        base.OnGotMeleeAttack( attacker );

		        if ( 0.3 >= Utility.RandomDouble() )
                        this.Lightning();
	        }

                public void Lightning()
                {
                        Map map = this.Map;

                        if ( map == null )
                            return;

                        ArrayList targets = new ArrayList();

                        foreach ( Mobile m in this.GetMobilesInRange( 15 ) )
                        {
                                 if ( m == this || !this.CanBeHarmful( m ) )
                                 continue;

                                 if ( m is BaseCreature && ( ( ( BaseCreature )m ).Controlled || ( ( BaseCreature )m ).Summoned || ( ( BaseCreature )m ).Team != this.Team ) )
                                      targets.Add( m );
                                 else if ( m.Player )
                                      targets.Add( m );
                        }

                        this.PlaySound( 528 );

                        for ( int i = 0; i < targets.Count; ++i )
                        {
                                Mobile m = ( Mobile )targets[i];

                                this.DoHarmful( m );

                                AOS.Damage( m, Utility.RandomMinMax( 15, 35 ), 0, 0, 0, 0, 100 );

		                m.FixedParticles( 0x37C4, 15, 35, 1272, 0x496, 0, EffectLayer.Waist );

		                m.BoltEffect( 0x480 );

                                if ( m.Alive && m.Body.IsHuman && !m.Mounted )
                                    m.Animate( 20, 7, 1, true, false, 0 ); // take hit
                        }
                }

		public Mesmenir( Serial serial ) : base(serial)
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

			if ( BaseSoundID == 0x16A )
				BaseSoundID = 0xA8;
		}
	}
}
