using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	public class PlundersHavenCampGuard : BaseGuardian
	{

		[Constructable]
		public PlundersHavenCampGuard() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Title = "the camp guard"; 

			SetStr( 128, 160 );
			SetDex( 87, 100 );
			SetInt( 32, 35 );

			SetHits( 125, 150 );

			SetSkill( SkillName.Anatomy, 20.0 );
			SetSkill( SkillName.Fencing, 82.6, 93.1 );
			SetSkill( SkillName.Macing, 82.6, 93.1 );
			SetSkill( SkillName.MagicResist, 38.9, 45.5 );
			SetSkill( SkillName.Swords, 82.6, 93.1 );
			SetSkill( SkillName.Tactics, 48.2, 61.9 );
			SetSkill( SkillName.Wrestling, 49.4, 57.6 );

			Fame = -2500;
			Karma = 2500;

			AddItem( new RoyalCirclet() );
			AddItem( new ThighBoots(1378) );

			LeafChest chest = new LeafChest();
			chest.Hue = 1378;
			chest.Movable = true;
			AddItem( chest );

			LeafGorget gorget = new LeafGorget();
			gorget.Hue = 1378;
			gorget.Movable = true;
			AddItem( gorget );

			LeafArms arms = new LeafArms();
			arms.Hue = 1378;
			arms.Movable = true;
			AddItem( arms );

			LeafGloves gloves = new LeafGloves();
			gloves.Hue = 1378;
			gloves.Movable = true;
			AddItem( gloves );

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 606;
				Name = NameList.RandomName( "elven female" );
			        Hue = Utility.RandomList( 897,898,899,2405 );
                                HairHue = 1153;
                                HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );

			      LeafTonlet legs = new LeafTonlet();
			      legs.Hue = 1378;
			      legs.Movable = true;
			      AddItem( legs );
			}
			else
			{
				Body = 605;
				Name = NameList.RandomName( "elven male" );
			        Hue = Utility.RandomList( 897,898,899,2405 );
                                HairHue = 1153;
                                HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );

			      LeafLegs legs = new LeafLegs();
			      legs.Hue = 1378;
			      legs.Movable = true;
			      AddItem( legs );
			}

			switch ( Utility.Random( 9 ))
			{
				case 0: AddItem( new DiamondMace() ); break;
				case 1: AddItem( new ElvenMachete() ); break;
				case 2: AddItem( new OrnateAxe() ); break;
				case 3: AddItem( new RadiantScimitar() ); break;
				case 4: AddItem( new RuneBlade() ); break;
				case 5: AddItem( new WarCleaver() ); break;
			}

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 5, 8 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );

			PackItem( pack );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( from != null && !willKill && amount > 5 && from.Player && 5 > Utility.Random( 100 ) )
			{
				string[] toSay = new string[]
					{
						"{0}!!  I have had enough of you foolish fiend!",
						"{0}!!  Prepare to face my fury!",
						"{0}!!  Why won't you die?!",
						"{0}!!  Stay and face me fool!"
					};

				this.Say( true, String.Format( toSay[Utility.Random( toSay.Length )], from.Name ) );
			}

			base.OnDamage( amount, from, willKill );
		}


		public PlundersHavenCampGuard( Serial serial ) : base( serial )
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
		}
	}
}