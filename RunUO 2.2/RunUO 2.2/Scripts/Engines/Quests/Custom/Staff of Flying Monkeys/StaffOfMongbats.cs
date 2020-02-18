using System; 
using Server.Network; 
using Server; 
using System.Collections; 
using Server.Gumps; 
using Server.Items; 
using Server.Mobiles; 
using Server.Targeting;

namespace Server.Items
{
	[FlipableAttribute( 0xDF1, 0xDF0 )]
	public class StaffOfMongbats : BaseStaff
	{
		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.WhirlwindAttack; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return 8; } }
		public override int AosMaxDamage{ get{ return 33; } }
		public override int AosSpeed{ get{ return 35; } }

                private int fModDiv = 75;
                private int m_Charges;
 
	        public override int InitMinHits{ get{ return 255; } }
	        public override int InitMaxHits{ get{ return 255; } }

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set{ m_Charges = value; InvalidateProperties(); }
		}

		[Constructable]
		public StaffOfMongbats() : base( 0xDF0 )
		{
                        Name = "Staff Of Mongbats - Quest Item (charges: 20)";
                        Identified = true;
                        Hue = 1036;
			Weight = 6.0;
 
                        this.Charges = 20;

			LootType = LootType.Blessed;
			Attributes.SpellChanneling = 1;
		}

                public override void GetProperties(ObjectPropertyList list) // Add charges to item description
                {
				base.GetProperties( list ); 

				if ( m_Charges != 0 ) 
					list.Add( 1060584, m_Charges.ToString() ); 
                }

		public override void OnSingleClick( Mobile from ) 
		{
			ArrayList attrs = new ArrayList(); 

			if ( !Identified ) 
				attrs.Add( new EquipInfoAttribute( 1038000 ) ); // Unidentified 
			else 
				attrs.Add( new EquipInfoAttribute( 1041367, m_Charges ) );

			EquipmentInfo eqInfo = new EquipmentInfo( 1017413, Crafter, false, (EquipInfoAttribute[])attrs.ToArray( typeof( EquipInfoAttribute ) ) ); 
			from.Send( new DisplayEquipmentInfo( this, eqInfo ) ); 
		} 

       public override void OnDoubleClick(Mobile from)
       {
           if (m_Charges <= 0)
           {
               from.SendLocalizedMessage(1019073); // This item is out of charges.
           }
           else
           {

               {
                   if (Parent != from)
                   {
                       from.SendMessage("You must equip this item to use it.");
                       return;
                   }

                   if (from.Skills[SkillName.Magery].Value < 10)
                   {
                       from.SendMessage("Your Magery skill is not high enough to summon.");
                       return;
                   }

                   Charges--;
                   if ( Charges > 0 )
                    Name = "Staff Of Mongbats - Quest Item (charges: " + Charges.ToString() + ")";
                   else
                    Name = "Staff Of Mongbats - Quest Item";

                   IPooledEnumerable eable = from.Map.GetItemsInRange(from.Location, 10);

                   foreach (Item c in eable)
                   {
                       if (c is Corpse)
                       {
                           Corpse corpse = (Corpse)c;

                           if (!corpse.Owner.Player)
                           {
                               if (from.Skills[SkillName.Magery].Value >= 50)
                               {
                                   BaseCreature.Summon(new CavernMongbatShaman(), from, c.Location, 422, TimeSpan.FromSeconds(from.Skills[SkillName.Magery].Value * 3));
                                   from.Mana -= 100;
					     from.PlaySound( 0xFF );
                                   c.Delete();
                                   eable.Free();
                                   return;
                               }
                               if (from.Skills[SkillName.Magery].Value >= 30)
                               {
                                   BaseCreature.Summon(new CavernMongbatBerserker(), from, c.Location, 422, TimeSpan.FromSeconds(from.Skills[SkillName.Magery].Value * 3));
                                   from.Mana -= 75;
					     from.PlaySound( 0xFF );
                                   c.Delete();
                                   eable.Free();
                                   return;
                               }

                               BaseCreature.Summon(new CavernMongbatScout(), from, c.Location, 422, TimeSpan.FromSeconds(from.Skills[SkillName.Magery].Value * 3));
                               from.Mana -= 50;
					 from.PlaySound( 0xFF );
                               c.Delete();
                               eable.Free();
                               return;
                           }
                       }

                   }
                   from.SendMessage("You must be near a corpse to raise it");
                   eable.Free();
               }
           }
       }
      public override bool OnEquip( Mobile from ) 
      { 
         if( from.Skills[SkillName.Magery].Value >= 10 ) 
         { 
            double fMod = (from.Skills[SkillName.Magery].Value + from.Skills[SkillName.Anatomy].Value) / fModDiv ; 
             
            from.FollowersMax += (int)fMod; 
         } 
         base.OnEquip(from); 
         return true; 
      } 

      public override void OnRemoved( object o ) 
      { 
         if( o is Mobile) 
         { 
            if( ((Mobile)o).Skills[SkillName.Magery].Value >= 10 ) 
            { 
               double fMod = (((Mobile)o).Skills[SkillName.Magery].Value + ((Mobile)o).Skills[SkillName.Anatomy].Value) / fModDiv ; 
             
               ((Mobile)o).FollowersMax -= (int)fMod; 
            } 
         } 
          
         base.OnRemoved( o ); 
      } 

      public StaffOfMongbats( Serial serial ) : base( serial ) 
      { 
      } 

      public override void Serialize( GenericWriter writer ) 
      { 
             base.Serialize( writer ); 
 
             writer.Write( (int) 0 ); // version 
	     writer.Write( m_Charges );
      } 

      public override void Deserialize( GenericReader reader ) 
      { 
             base.Deserialize( reader ); 

             int version = reader.ReadInt(); 

	     m_Charges = reader.ReadInt();
      } 
   } 
}
