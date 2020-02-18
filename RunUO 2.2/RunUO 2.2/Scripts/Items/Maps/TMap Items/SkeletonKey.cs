using System;
using Server.Network;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{
	public class SFSkeletonKey : Item
	{
        public override int LabelNumber{ get{ return 1095522; } }

        private int m_UsesRemaining;

        [CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining
		{
			get { return m_UsesRemaining; }
			set { m_UsesRemaining = value; InvalidateProperties(); }
		}

        public bool ShowUsesRemaining{ get{ return true; } set{} }

        [Constructable]
        public SFSkeletonKey() : this(10)
		{
		}

		[Constructable]
        public SFSkeletonKey( int uses ) : base(0x410A)
		{
            Weight = 1.0;
            UsesRemaining = uses;
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

            list.Add("Gives +5 to Lockpicking");	
		}

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add(1060584, m_UsesRemaining.ToString()); // uses remaining: ~1_val~
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                from.SendMessage("What do you want to use the Skeleton Key on?");
                from.Target = new InternalTarget(this);
            }
            else
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
        }

        public SFSkeletonKey(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
			writer.Write( (int) m_UsesRemaining );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_UsesRemaining = reader.ReadInt();
					break;
				}
			}
		}

		private class InternalTarget : Target
		{
            private SFSkeletonKey m_Skey;

            public InternalTarget(SFSkeletonKey skey) : base(1, false, TargetFlags.None)
			{
				m_Skey = skey;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Skey.Deleted || m_Skey.UsesRemaining <= 0 )
				{
					from.SendMessage( "This skeleton key is useless" ); // You have used up your powder of temperament.
					return;
				}

				if ( targeted is ILockpickable )
				{
					Item item = (Item)targeted;
					from.Direction = from.GetDirectionTo( item );

					if ( ((ILockpickable)targeted).Locked )
					{
						from.PlaySound( 0x241 );

						new InternalTimer( from, (ILockpickable)targeted, m_Skey ).Start();
					}
					else
					{
						// The door is not locked
						from.SendLocalizedMessage( 502069 ); // This does not appear to be locked
					}
				}
				else
				{
					from.SendLocalizedMessage( 501666 ); // You can't unlock that!
				}
            }

            private class InternalTimer : Timer
            {
                private Mobile m_From;
                private ILockpickable m_Item;
                private SFSkeletonKey m_Skey;

                public InternalTimer(Mobile from, ILockpickable item, SFSkeletonKey skey)
                    : base(TimeSpan.FromSeconds(3.0))
                {
                    m_From = from;
                    m_Item = item;
                    m_Skey = skey;
                    Priority = TimerPriority.TwoFiftyMS;
                }

                protected override void OnTick()
                {
                    Item item = (Item)m_Item;

                    int m_LockLvl = m_Item.LockLevel - 5;
                    int m_MaxLockLvl = m_Item.MaxLockLevel - 5;

                    if (m_LockLvl <= 0)
                        m_LockLvl = 1;
                    if (m_MaxLockLvl <= 0)
                        m_MaxLockLvl = 1;

                    if (!m_From.InRange(item.GetWorldLocation(), 1))
                        return;

                    if (m_Item.LockLevel == 0 || m_Item.LockLevel == -255)
                    {
                        // LockLevel of 0 means that the door can't be picklocked
                        // LockLevel of -255 means it's magic locked
                        item.SendLocalizedMessageTo(m_From, 502073); // This lock cannot be picked by normal means
                        return;
                    }

                    if ((m_From.Skills[SkillName.Lockpicking].Value + 5.0) < m_Item.RequiredSkill)
                    {
                        // The LockLevel is higher thant the LockPicking of the player
                        item.SendLocalizedMessageTo(m_From, 502072); // You don't see how that lock can be manipulated.
                        return;
                    }

                    if (m_From.CheckTargetSkill(SkillName.Lockpicking, m_Item, m_LockLvl, m_MaxLockLvl))
                    {
                        // Success! Pick the lock!
                        item.SendLocalizedMessageTo(m_From, 502076); // The lock quickly yields to your skill.
                        m_From.PlaySound(0x4A);
                        m_Item.LockPick(m_From);
                        --m_Skey.UsesRemaining;
                    }
                    else
                    {
                        // The player failed to pick the lock						
                        item.SendLocalizedMessageTo(m_From, 502075); // You are unable to pick the lock.
                        --m_Skey.UsesRemaining;
                        if (m_Skey.UsesRemaining <= 0)
                        {
                            m_From.SendMessage("You have used up your skeleton key");
                            m_Skey.Delete();
                        }

                        // ==== Random Item Disintergration upon Failure ====
                        if ((Core.SA) && m_Item is TreasureMapChest)
                        {
                            int i_Num = 0; Item i_Destroy = null;

                            BaseContainer m_chest = m_Item as BaseContainer;
                            Item Dust = new DustPile();

                            for (int i = 10; i > 0; i--)
                            {
                                i_Num = Utility.Random(m_chest.Items.Count);
                                // Make sure DustPiles aren't called for destruction
                                if ((m_chest.Items.Count > 0) && m_chest.Items[i_Num] is DustPile)
                                {
                                    for (int ci = (m_chest.Items.Count - 1); ci >= 0; ci--)
                                    {
                                        i_Num = ci;
                                        if (i_Num < 0) { i_Num = 0; }

                                        if (m_chest.Items[i_Num] is DustPile)
                                        {
                                            i_Destroy = null;
                                        }
                                        else
                                        {
                                            i_Destroy = m_chest.Items[i_Num];
                                            i_Num = i_Num; i = 0;
                                        }
                                        // Nothing left but Dust
                                        if (ci < 0 && i > 0)
                                        {
                                            i_Destroy = null; i = 0;
                                        }
                                    }
                                }
                                // Item targetted =+= prepare for object DOOM! >;D
                                else
                                {
                                    i_Destroy = m_chest.Items[i_Num]; i = 0;
                                }
                            }
                            // Delete chosen Item and drop a Dust Pile
                            if (i_Destroy is Gold)
                            {
                                if (i_Destroy.Amount > 1000)
                                    i_Destroy.Amount -= 1000;
                                else
                                    i_Destroy.Delete();

                                Dust.Hue = 1177; m_chest.DropItem(Dust);
                            }
                            else if (i_Destroy != null)
                            {
                                i_Destroy.Delete(); m_chest.DropItem(Dust);
                            }
                            Effects.PlaySound(m_chest.Location, m_chest.Map, 0x1DE);
                            m_chest.PublicOverheadMessage(MessageType.Regular, 2004, false, "The sound of gas escaping is heard from the chest.");
                        }
                    }                    
                }
            }
        }
    }
}