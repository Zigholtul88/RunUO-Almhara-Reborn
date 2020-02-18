using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	public class MelancholicGargoyleWarrior : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }

		[Constructable]
		public MelancholicGargoyleWarrior() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
                  Name = "a melancholic gargoyle warrior";
			Body = 666;
			Hue = 1779;
                  HairItemID = 499;
                  HairHue = 2051;

			SetStr( 147, 267 );
			SetDex( 97, 114 );
			SetInt( 54, 147 );

			SetHits( 110, 138 );

			SetDamage( 6, 12 );

                  Flying = true;

			GargishPlateArms arms = new GargishPlateArms(); 
			arms.Hue = 2405; 
			arms.Movable = false; 
			AddItem( arms ); 

			GargishPlateChest chest = new GargishPlateChest(); 
			chest.Hue = 2405; 
			chest.Movable = false; 
			AddItem( chest ); 

			GargishPlateKilt kilt = new GargishPlateKilt(); 
			kilt.Hue = 2405; 
			kilt.Movable = false; 
			AddItem( kilt ); 

			GargishPlateLeggings legs = new GargishPlateLeggings(); 
			legs.Hue = 2405; 
			legs.Movable = false; 
			AddItem( legs ); 

			DreadSword weapon = new DreadSword();
			weapon.Hue = 2405;
			weapon.Movable = false; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

			SetSkill( SkillName.MagicResist, 85.9, 91.0 );
			SetSkill( SkillName.Swords, 69.8, 78.9 );
			SetSkill( SkillName.Tactics, 80.1, 89.9 );

			Fame = 5000;
			Karma = -5000;

			VirtualArmor = 35;

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Gems );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return false; } }

		public override int Meat{ get{ return 1; } }

		public override int GetIdleSound() { return 1531; } 
		public override int GetAngerSound() { return 1528; } 
		public override int GetHurtSound() { return 1530; } 
		public override int GetDeathSound()	{ return 1529; }

		public MelancholicGargoyleWarrior( Serial serial ) : base( serial )
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