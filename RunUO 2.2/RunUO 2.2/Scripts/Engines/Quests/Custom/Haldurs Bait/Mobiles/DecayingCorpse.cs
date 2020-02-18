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
	[CorpseName( "a zombie corpse" )]
	public class DecayingCorpse : BaseCreature
	{
		[Constructable]
		public DecayingCorpse() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8 )
		{
			Name = "a decaying corpse";
			Body = 3;
			Hue = 1173;
			BaseSoundID = 471;

			SetStr( 146, 170 );
			SetDex( 71, 90 );
			SetInt( 26, 40 );

			SetHits( 122, 150 );

			SetDamage( 4, 8 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Cold, 60 );

			SetResistance( ResistanceType.Physical, 20 );
			SetResistance( ResistanceType.Fire, -15 );
			SetResistance( ResistanceType.Cold, 50 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.MagicResist, 15.1, 40.0 );
			SetSkill( SkillName.Tactics, 35.1, 50.0 );
			SetSkill( SkillName.Wrestling, 35.1, 50.0 );

			Fame = 4000;
			Karma = -4000;

			PackItem( new Garlic( 5 ) );
			PackItem( new Bandage( 10 ) );

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
			AddLoot( LootPack.Potions );
		}

		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new LeftArm(), from );
                              corpse.AddCarvedItem(new RightArm(), from );
                              corpse.AddCarvedItem(new Torso(), from );
                              corpse.AddCarvedItem(new Bone(), from );
                              corpse.AddCarvedItem(new RibCage(), from );

		              if( 0.05 > Utility.RandomDouble() ) // 0.05 = 5% = chance to poison carver
                              {
		                      from.ApplyPoison( from, Poison.Regular );
		                      from.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
                                      from.FixedParticles(0x36B0, 1, 14, 0x26BB, 0x3F, 0x7, EffectLayer.Waist);
		                      from.PlaySound( from.Female ? 814 : 1088 );
                                      from.PlaySound( from.Female ? 792 : 1064 );
                              }

		              if( 0.40 > Utility.RandomDouble() ) // 0.40 = 40% = chance to drop worm 
		              { 
                                      corpse.AddCarvedItem(new Worm(), from );
		              }

                              from.SendMessage( "You carve up some parts." );
                              corpse.Carved = true; 
			}
                }

		public DecayingCorpse( Serial serial ) : base( serial )
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