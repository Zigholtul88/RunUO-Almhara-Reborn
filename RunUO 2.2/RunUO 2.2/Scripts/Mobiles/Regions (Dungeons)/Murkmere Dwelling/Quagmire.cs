using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a quagmire corpse" )]
	public class Quagmire : BaseCreature
	{
		[Constructable]
		public Quagmire() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8 )
		{
			Name = "a quagmire";
			Body = 789;

			SetStr( 101, 130 );
			SetDex( 66, 85 );
			SetInt( 31, 55 );

			SetHits( 591, 605 );

			SetDamage( 10, 24 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 32 );
			SetResistance( ResistanceType.Fire, -50 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.MagicResist, 65.1, 75.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 15000;
			Karma = -15000;

			ControlSlots = 1;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			        BaseClothing clothing = Loot.RandomClothing( true );
		                BaseRunicTool.ApplyAttributesTo( clothing, 5, 35, 50 );  
                                clothing.Hue = 2536;

                                PackItem( clothing );
                         }

 		         if ( Utility.RandomDouble() < 0.05 )
                         {
			         BaseShield shield = new GrassShield();
			         if ( Core.AOS )
		                 BaseRunicTool.ApplyAttributesTo( shield, 5, 35, 50 ); 
                                 shield.Hue = 2536;

                                 PackItem( shield );
                          }

 		          if ( Utility.RandomDouble() < 0.05 )
                          {
			         BaseJewel ring = new GoldRing();
			         if ( Core.AOS )
		                 BaseRunicTool.ApplyAttributesTo( ring, 5, 35, 50 ); 
                                 ring.Hue = 2536;             

                                 PackItem( ring );
                           }
	        }

		public override int GetIdleSound() { return 0x017; }
		public override int GetAngerSound() { return 0x018; }
		public override int GetAttackSound() { return 0x01E; }
		public override int GetHurtSound() { return 0x01D; }
		public override int GetDeathSound() { return 0x01A; }

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Greater; } }
		public override double HitPoisonChance{ get{ return 0.1; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new Gold( Utility.RandomMinMax( 311, 717 ) ), from );
                              corpse.AddCarvedItem( new Nirnroot( Utility.RandomMinMax( 5, 12 ) ), from );
                              corpse.AddCarvedItem( new RoseOfQuagmire(), from );

                              from.SendMessage( "Upon finding gold, you also carve up some nirnroot and a rose of quagmire." );
                              corpse.Carved = true; 
			}
                }

		public Quagmire( Serial serial ) : base( serial )
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