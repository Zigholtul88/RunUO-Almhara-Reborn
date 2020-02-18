using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Prompts;
using Server.Targeting;

namespace Server.Items
{
	public class IdentificationScroll : Item
	{
		[Constructable]
		public IdentificationScroll() : base( 5360 )
		{
			Name = "Identification Scroll";
			Weight = 1.0;
			Hue = 0x481;
                        LootType = LootType.Blessed;
		}

                public override void OnDoubleClick(Mobile from)
                {
                        if ( IsChildOf(from.Backpack) )
                        {
                                from.BeginTarget(2, false, TargetFlags.Beneficial, new TargetCallback(OnTarget));
                                from.SendMessage("What item you would like to identify?");
                        }
                        else
                        {
                                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                        }
                }

                public virtual void OnTarget(Mobile from, object o)
                {
                        if (Deleted)
                            return;

                        if ( o is Item )
                        {
                                if ( o is BaseWeapon && ( (BaseWeapon)o).Identified == false )
                                {
                                        ((BaseWeapon)o).Identified = true;
                                        from.SendMessage( "You identify the item." );
                                        from.Emote( "*Recites an identification scroll*" );
                                        this.Consume();
                                }
                                else if ( o is BaseArmor && ( (BaseArmor)o).Identified == false )
                                {
                                        ((BaseArmor)o).Identified = true;
                                        from.SendMessage( "You identify the item." );
                                        from.Emote( "*Recites an identification scroll*" );
                                        this.Consume();
                                }
                                else if ( o is BaseClothing && ( (BaseClothing)o).Identified == false )
                                {
                                        ((BaseClothing)o).Identified = true;
                                        from.SendMessage( "You identify the item." );
                                        from.Emote( "*Recites an identification scroll*" );
                                        this.Consume();
                                }
                                else if ( o is BaseJewel && ( (BaseJewel)o).Identified == false )
                                {
                                        ((BaseJewel)o).Identified = true;
                                        from.SendMessage( "You identify the item." );
                                        from.Emote( "*Recites an identification scroll*" );
                                        this.Consume();
                                }
                                else
                                    from.SendMessage("Are you sure this is the item you want to identify?");
                        }
                        else if ( o == null )
                        {
                                from.SendMessage("What do you think you're doing? You should target a item!");
                        }
                        else
                        {
                                from.SendMessage("Why would you want to identify that!?");
                        }
                }

		public IdentificationScroll( Serial serial ) : base( serial )
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