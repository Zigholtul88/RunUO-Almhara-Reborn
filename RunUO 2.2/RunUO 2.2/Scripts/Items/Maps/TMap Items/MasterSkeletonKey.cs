using System;
using Server.Network;
using Server.Targeting;
using Server.Items;

namespace Server.Items
{
	public class SFMasterSkeletonKey : Item
	{
        public override int LabelNumber { get { return 1095523; } }

        private int m_UsesRemaining;

        [CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining
		{
			get { return m_UsesRemaining; }
			set { m_UsesRemaining = value; InvalidateProperties(); }
		}

        public bool ShowUsesRemaining{ get{ return true; } set{} }

        [Constructable]
        public SFMasterSkeletonKey() : this(1)
		{
		}

		[Constructable]
        public SFMasterSkeletonKey( int uses ) : base(0x410A)
		{
            Weight = 1.0;
            UsesRemaining = uses;
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

            list.Add("Unlocks any Treasure chest on first attempt");	
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
                from.SendMessage("Select a Treasure chest to Unlock");
                from.Target = new InternalTarget(this);
            }
            else
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
        }

        public SFMasterSkeletonKey(Serial serial) : base(serial)
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
            private SFMasterSkeletonKey m_Skey;

            public InternalTarget(SFMasterSkeletonKey skey) : base(1, false, TargetFlags.None)
			{
				m_Skey = skey;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( m_Skey.Deleted || m_Skey.UsesRemaining <= 0 )
				{
					from.SendMessage( "This master skeleton key can only be used once" ); // You have used up your powder of temperament.
					return;
				}

				if ( targeted is ILockpickable )
				{
					Item item = (Item)targeted;
					from.Direction = from.GetDirectionTo( item );

                    if (item is TreasureMapChest)
                    {
                        if (((ILockpickable)targeted).Locked)
                        {
                            from.PlaySound(0x241);

                            new InternalTimer(from, (ILockpickable)targeted, m_Skey).Start();
                        }
                        else
                        {
                            // The door is not locked
                            from.SendLocalizedMessage(502069); // This does not appear to be locked
                        }
                    }
                    else
                    {
                        from.SendMessage("This Skeleton Key is specifically designed for use on Treasure Chests"); 
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
                private SFMasterSkeletonKey m_Skey;

                public InternalTimer(Mobile from, ILockpickable item, SFMasterSkeletonKey skey) : base(TimeSpan.FromSeconds(3.0))
                {
                    m_From = from;
                    m_Item = item;
                    m_Skey = skey;
                    Priority = TimerPriority.TwoFiftyMS;
                }

                protected override void OnTick()
                {
                    Item item = (Item)m_Item;

                    if (!m_From.InRange(item.GetWorldLocation(), 1))
                        return;

                    item.SendLocalizedMessageTo(m_From, 502076);
                    m_From.PlaySound(0x4A);
                    m_Item.LockPick(m_From);

                    m_From.SendMessage("The key opens the Treasure chest but is now rendered useless");
                    m_Skey.Delete();
                }
            }
        }
    }
}