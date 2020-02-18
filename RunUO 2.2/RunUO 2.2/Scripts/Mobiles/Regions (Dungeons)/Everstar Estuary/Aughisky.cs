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
	[CorpseName( "an aughisky corpse" )]
	public class Aughisky : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public Aughisky() : base( AIType.AI_Melee, FightMode.Closest, 6, 1, 0.175, 0.350 )
		{
                        Name = "an aughisky";
			Body = 178;
			Hue = 1908;
			BaseSoundID = 0xA8;

			SetStr( 187, 245 );
			SetDex( 196, 234 );
			SetInt( 156, 173 );

			SetHits( 285, 350 );

			SetDamage( 7, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.MagicResist, 48.9, 69.7 );
			SetSkill( SkillName.Tactics, 77.9, 88.8 );
			SetSkill( SkillName.Wrestling, 48.6, 60.4 );

			Fame = 11600;
			Karma = -11600;

			Container pack = new Backpack();
			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 23, 37 ) ) );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( new Citrine() );

			if ( 0.10 > Utility.RandomDouble() )
				pack.DropItem( new NightSightScroll() );

			if ( 0.04 > Utility.RandomDouble() )
				pack.DropItem( new Pearl() );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( Loot.RandomGem() );

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseClothing clothing1 = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing1, 3, 10, 25 );  

                       pack.DropItem( clothing1 );
                  }

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseClothing clothing2 = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing2, 3, 10, 25 );  

                       pack.DropItem( clothing2 );
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

			switch ( Utility.Random( 3 ))
			{
				case 0: AddItem( Loot.RandomArmor() ); break;
				case 1: AddItem( Loot.RandomClothing() ); break;
				case 2: AddItem( Loot.RandomWeapon() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(5), from);
                        corpse.AddCarvedItem(new BarbedHides(10), from);

                        from.SendMessage( "You carve up 5 ribs and some barbed hides." );
                        corpse.Carved = true; 
			}
                }

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
		}

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

            if (map == null)
                return;

            ArrayList targets = new ArrayList();

            foreach (Mobile m in this.GetMobilesInRange(15))
            {
                if (m == this || !this.CanBeHarmful(m))
                    continue;

                if (m is BaseCreature && (((BaseCreature)m).Controlled || ((BaseCreature)m).Summoned || ((BaseCreature)m).Team != this.Team))
                    targets.Add(m);
                else if (m.Player)
                    targets.Add(m);
            }

            this.PlaySound(528);

            for (int i = 0; i < targets.Count; ++i)
            {
                Mobile m = (Mobile)targets[i];

                this.DoHarmful(m);

                AOS.Damage(m, Utility.RandomMinMax(15, 35), 0, 0, 0, 0, 100);

		    m.FixedParticles( 0x37C4, 10, 15, 1272, 0x496, 0, EffectLayer.Waist );

		    m.BoltEffect( 0x480 );

                if (m.Alive && m.Body.IsHuman && !m.Mounted)
                    m.Animate(20, 7, 1, true, false, 0); // take hit
            }
        }

		public Aughisky( Serial serial ) : base(serial)
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