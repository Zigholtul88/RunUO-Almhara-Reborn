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
	[CorpseName( "the corpse of balzan marcos" )]
	public class BalzanMarcos : BaseCreature
	{
                private DateTime m_NextWeaponChange;

		public override bool ClickTitle{ get{ return false; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}
	 
		[Constructable] 
		public BalzanMarcos() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = "Balzan Marcos";
			Title = "the evil thief";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = Utility.RandomSkinHue();
			HairItemID = 0;
                        HairHue = 0;
                        FacialHairItemID = 0;
                        FacialHairHue = 0;

			SetStr( 205, 245 );
			SetDex( 81, 95 );
			SetInt( 610, 1000 );

			SetHits( 1000, 1500 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 6 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.Archery, 95.1, 100.0 );
			SetSkill( SkillName.Bushido, 120.0 );
			SetSkill( SkillName.Fencing, 95.0, 97.5 );
			SetSkill( SkillName.Macing, 93.0, 98.5 );
			SetSkill( SkillName.MagicResist, 0.0 );
			SetSkill( SkillName.Ninjitsu, 50.0 );
			SetSkill( SkillName.Parry, 120.0 );
			SetSkill( SkillName.Swords, 98.0, 99.5 );
			SetSkill( SkillName.Tactics, 89.0, 93.5 );
			SetSkill( SkillName.Wrestling, 63.0, 81.5 );

			Fame = 2500;
			Karma = -2500;

			SpeechHue = Utility.RandomDyedHue();  
						
			LeatherChest chest = new LeatherChest(); 
			chest.Hue = 0x966; 
			AddItem( chest ); 

			LeatherArms arms = new LeatherArms(); 
			arms.Hue = 0x966; 
			AddItem( arms ); 

			LeatherGloves gloves = new LeatherGloves(); 
			gloves.Hue = 0x966; 
			AddItem( gloves ); 

			LeatherGorget gorget = new LeatherGorget(); 
			gorget.Hue = 0x966; 
			AddItem( gorget ); 

			LeatherLegs legs = new LeatherLegs(); 
			legs.Hue = 0x966; 
			AddItem( legs ); 

			Container pack = new Backpack();

			pack.DropItem( new OrderList() );
			pack.DropItem( new Diamond() );
			pack.DropItem( new Gold( Utility.RandomMinMax( 11, 13 ) ) );
			pack.DropItem( new Lockpick( Utility.RandomMinMax( 5, 10 ) ) );

			PackItem( pack );

			switch ( Utility.Random( 6 ))
			{
				case 0: AddItem( new Longsword() ); break;
				case 1: AddItem( new Cutlass() ); break;
				case 2: AddItem( new Axe() ); break;
				case 3: AddItem( new Club() ); break;
				case 4: AddItem( new Dagger() ); break;
				case 5: AddItem( new Spear() ); break;
			}

			PackItem( new Bow() );
			PackItem( new Arrow( Utility.RandomMinMax( 80, 90 ) ) );
		} 

                public override bool OnBeforeDeath()
                {
                        this.Say("I REGRET NOTHINGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG!");

                        return base.OnBeforeDeath();
                }

		public override int GetHurtSound() { return 1081; } //play male oomph 6
		public override int GetAngerSound() { return 1074; } //play male no
		public override int GetDeathSound() { return 348; } //play male die 3

		public override bool AlwaysMurderer{ get{ return true; } }

                public override void OnThink()
                {
                        base.OnThink();

                        if ( Combatant != null && m_NextWeaponChange < DateTime.UtcNow )
                           ChangeWeapon();
                }

                private void ChangeWeapon()
                {
                        if ( Backpack == null )
                             return;

                        Item item = FindItemOnLayer(Layer.OneHanded);

                        if ( item == null )
                             item = FindItemOnLayer(Layer.TwoHanded);

                        System.Collections.Generic.List<BaseWeapon> weapons = new System.Collections.Generic.List<BaseWeapon>();

                        foreach (Item i in Backpack.Items)
                        {
                                if (i is BaseWeapon && i != item)
                                    weapons.Add((BaseWeapon)i);
                        }

                        if (weapons.Count > 0)
                        {
                                if (item != null)
                                Backpack.DropItem(item);

                                AddItem(weapons[Utility.Random(weapons.Count)]);

                                m_NextWeaponChange = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(30, 60));
                        }
                }		

		public BalzanMarcos( Serial serial ) : base( serial )
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

                        m_NextWeaponChange = DateTime.UtcNow;
		} 
	} 
}