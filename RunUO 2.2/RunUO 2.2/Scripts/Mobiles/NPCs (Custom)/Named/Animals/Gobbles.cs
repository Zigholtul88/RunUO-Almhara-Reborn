using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Gobbles" )]
	public class Gobbles : BaseGuardian
	{
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public Gobbles() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
                        // based off of wild turkey mob stats
			Name = "Gobbles";
			Body = 1026;

			SetStr( 117, 137 );
			SetDex( 84, 105 );
			SetInt( 27, 50 );

			SetHits( 140, 168 );
			SetMana( 0 );

			SetDamage( 7, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20 );

			SetSkill( SkillName.MagicResist, 45.1, 59.3 );
			SetSkill( SkillName.Tactics, 60.7, 88.7 );
			SetSkill( SkillName.Wrestling, 51.7, 72.7 );

			Fame = 1500;
			Karma = 0;

			PackReg( 5, 10 );
		}

		public override void GenerateLoot()
		{
                        if ( Utility.RandomDouble() < 0.08 ) //8% chance to drop only one armor at a time.
                        {
                            BaseArmor armor = Loot.RandomArmor( true );
                            switch ( Utility.Random( 6 ))
                            {
                                case 0: armor = new LeatherChest(); break;
                                case 1: armor = new LeatherLegs(); break;
                                case 2: armor = new LeatherCap(); break;
                                case 3: armor = new LeatherArms(); break;
                                case 4: armor = new LeatherGloves(); break;
                                case 5: armor = new LeatherGorget(); break;
                            }

                            armor.Attributes.LowerManaCost = 1;
                            armor.Attributes.LowerRegCost = 1;

                            PackItem( armor );
		        }
                  }

                  public override void OnCarve( Mobile from, Corpse corpse, Item with )
		  {
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 7, 12 )), from);
                              corpse.AddCarvedItem(new RawBird(14), from);
                              corpse.AddCarvedItem(new Feather(50), from);

                              from.SendMessage( "You carve up gold, some raw bird and some feathers." );
                              corpse.Carved = true; 
			}
                }

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override int GetAttackSound() { return 0x277; } 
		public override int GetIdleSound() { return 0x270; } 
		public override int GetAngerSound() { return 0x275; } 
		public override int GetHurtSound() { return 0x273; } 
		public override int GetDeathSound() { return 0x279; }

		public Gobbles( Serial serial ) : base( serial )
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