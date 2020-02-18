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
using Server.Spells;
using Server.Spells.Fourth;

namespace Server.Mobiles
{
	[CorpseName( "a mad cow's corpse" )]
	public class FrenziedBull : BaseSpecialCreature
	{
                public override bool DoesTripleBolting { get { return true; } }
                public override double TripleBoltingChance { get { return 0.250; } }

		public override bool AlwaysMurderer{ get{ return true; } }

		[Constructable]
		public FrenziedBull() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a frenzied bull";
			Body = Utility.RandomList( 0xE8, 0xE9 );
			BaseSoundID = 0x64;

			Hue = 1153;

			SetStr( 205, 245 );
			SetDex( 215, 238 );
			SetInt( 1000, 1500 );

			SetHits( 800, 1000 );

			SetDamage( 5, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35, 40 );
			SetResistance( ResistanceType.Fire, 30, 40 );
			SetResistance( ResistanceType.Cold, 30, 40 );
			SetResistance( ResistanceType.Poison, 30, 40 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.MagicResist, 98.5, 112.0 );
			SetSkill( SkillName.Tactics, 65.0, 87.5 );
			SetSkill( SkillName.Wrestling, 20.3, 80.0 );

			Fame = 8000;
			Karma = -8000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 5 );
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new PrizedLeather( amount ), from );

                              corpse.AddCarvedItem(new RawBeefPorterhouse(), from);
                              corpse.AddCarvedItem(new RawBeefPrimeRib(), from);
                              corpse.AddCarvedItem(new RawBeefRibeye(), from);
                              corpse.AddCarvedItem(new RawBeefRibs(), from);
                              corpse.AddCarvedItem(new RawBeefRoast(), from);
                              corpse.AddCarvedItem(new RawBeefSirloin(), from);
                              corpse.AddCarvedItem(new RawBeefTBone(), from);
                              corpse.AddCarvedItem(new RawBeefTenderloin(), from);
                              corpse.AddCarvedItem(new RawGroundBeef(), from);

                              corpse.Carved = true; 

                              from.SendMessage( "You carve up bovine parts and some unique leather." ); 
			}
                }

		public override void OnGotMeleeAttack( Mobile attacker )
		{
	              base.OnGotMeleeAttack( attacker );

                      Mobile target = attacker;

                      if( target is BaseCreature && ((BaseCreature)target).Controlled )
                      target = ((BaseCreature)target).ControlMaster;

                      if( target == null )
                      target = attacker;

                      if( DoesTripleBolting && TripleBoltingChance >= Utility.RandomDouble() )
                      TripleBolt( target );

                      if (0.25 >= Utility.RandomDouble())
		      Ability.CrimsonMeteor( this, 50 );
		}

                public override void OnDamagedBySpell( Mobile attacker )
                {
                      base.OnDamagedBySpell( attacker );

                      Mobile target = attacker;

                      if( target is BaseCreature && ((BaseCreature)target).Controlled )
                      target = ((BaseCreature)target).ControlMaster;

                      if( target == null )
                      target = attacker;

                      if( DoesTripleBolting && TripleBoltingChance >= Utility.RandomDouble() )
                      TripleBolt( target );
                }

		public FrenziedBull(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}