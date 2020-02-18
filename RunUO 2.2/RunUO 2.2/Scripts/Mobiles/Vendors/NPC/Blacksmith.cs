using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Commands;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;
using Server.Engines.BulkOrders;

namespace Server.Mobiles
{
	public class Blacksmith : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override NpcGuild NpcGuild{ get{ return NpcGuild.BlacksmithsGuild; } }

		[Constructable]
		public Blacksmith() : base( "the blacksmith" )
		{
			SetSkill( SkillName.ArmsLore, 36.0, 68.0 );
			SetSkill( SkillName.Blacksmith, 65.0, 88.0 );
			SetSkill( SkillName.Fencing, 60.0, 83.0 );
			SetSkill( SkillName.Macing, 61.0, 93.0 );
			SetSkill( SkillName.Swords, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBBlacksmith() );
		}

		public override VendorShoeType ShoeType
		{
			get{ return VendorShoeType.None; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			Item item = ( Utility.RandomBool() ? null : new Server.Items.RingmailChest() );

			if ( item != null && !EquipItem( item ) )
			{
				item.Delete();
				item = null;
			}

			if ( item == null )
				AddItem( new Server.Items.FullApron() );

			AddItem( new Server.Items.Bascinet() );
			AddItem( new Server.Items.SmithHammer() );
		}

                public override void OnSpeech(SpeechEventArgs e)
                {
                    if ((e.Speech.ToLower() == "repair"))
                    {
                        BeginRepair (e.Mobile);
                    }
                    else
                    {
                        base.OnSpeech(e);
                    }

                }
                public void BeginRepair(Mobile from)
                {
                    if (Deleted || !from.CheckAlive())
                        return;

                    SayTo(from, "What do you want me to repair?");

                    from.Target = new RepairTarget(this);

                }

                private class RepairTarget : Target
                {
                    private Blacksmith m_Blacksmith;

                    public RepairTarget(Blacksmith blacksmith): base(12, false, TargetFlags.None)
                    {
                        m_Blacksmith = blacksmith;
                    }

                    protected override void OnTarget(Mobile from, object targeted)
                    {
                        if (targeted is BaseWeapon)
                        {
                            BaseWeapon bw = targeted as BaseWeapon;
                            Container pack = from.Backpack;
                            int toConsume = 0;
                            toConsume = (bw.MaxHitPoints - bw.HitPoints) * 3; //Adjuct price here by changing 3 to whatever you want.

                            if (toConsume == 0)
                            {
                                m_Blacksmith.SayTo(from, "That weapon is not damaged.");
                            }
                            else if ((bw.HitPoints < bw.MaxHitPoints) && (pack.ConsumeTotal(typeof(Gold), toConsume)))
                            {
			        Item a = from.Backpack.FindItemByType( typeof( Gold ) );
			        if ( a != null )

				a.Consume( toConsume );

                                bw.HitPoints = bw.MaxHitPoints;
                                m_Blacksmith.SayTo(from, "Here is your weapon.");
                                from.SendMessage(String.Format("You pay {0}gp.", toConsume));
                                Effects.PlaySound(from.Location, from.Map, 0x2A);
                            }
                            else
                            {
                                m_Blacksmith.SayTo(from, "It will cost you {0}gp to have your weapon repaired.", toConsume);
                                from.SendMessage("You do not have enough gold.");
                            }
                        }

                        if (targeted is BaseArmor)
                        {
                            BaseArmor ba = targeted as BaseArmor;
                            Container pack = from.Backpack;
                            int toConsume = 0;
                            toConsume = (ba.MaxHitPoints - ba.HitPoints) * 3; //Adjuct price here by changing 3 to whatever you want.

                            if ((toConsume == 0) && (ba.Resource == CraftResource.Iron || ba.Resource == CraftResource.DullCopper || ba.Resource == CraftResource.ShadowIron || ba.Resource == CraftResource.Copper || ba.Resource == CraftResource.Bronze || ba.Resource == CraftResource.Gold || ba.Resource == CraftResource.Agapite || ba.Resource == CraftResource.Verite || ba.Resource == CraftResource.Valorite))
                            {
                                m_Blacksmith.SayTo(from, "That armor is not damaged.");
                            }
                            else if (ba.Resource == CraftResource.RegularLeather || ba.Resource == CraftResource.SpinedLeather || ba.Resource == CraftResource.HornedLeather || ba.Resource == CraftResource.BarbedLeather)
                            {
                                m_Blacksmith.SayTo(from, "I cannot repair that.");
                            }
                            else if ((ba.HitPoints < ba.MaxHitPoints) && (pack.ConsumeTotal(typeof(Gold), toConsume) && (ba.Resource == CraftResource.Iron || ba.Resource == CraftResource.DullCopper || ba.Resource == CraftResource.ShadowIron || ba.Resource == CraftResource.Copper || ba.Resource == CraftResource.Bronze || ba.Resource == CraftResource.Gold || ba.Resource == CraftResource.Agapite || ba.Resource == CraftResource.Verite || ba.Resource == CraftResource.Valorite)))
                            {
			        Item a = from.Backpack.FindItemByType( typeof( Gold ) );
			        if ( a != null )

				a.Consume( toConsume );

                                ba.HitPoints = ba.MaxHitPoints;
                                m_Blacksmith.SayTo(from, "Here is your armor.");
                                from.SendMessage(String.Format("You pay {0}gp.", toConsume));
                                Effects.PlaySound(from.Location, from.Map, 0x2A);
                            }
                            else
                            {
                                m_Blacksmith.SayTo(from, "It will cost you {0}gp to have your armor repaired.", toConsume);
                                from.SendMessage("You do not have enough gold.");
                            }                    
                        }
                    }
                }

		#region Bulk Orders
		public override Item CreateBulkOrder( Mobile from, bool fromContextMenu )
		{
			PlayerMobile pm = from as PlayerMobile;

			if ( pm != null && pm.NextSmithBulkOrder == TimeSpan.Zero && (fromContextMenu || 0.2 > Utility.RandomDouble()) )
			{
				double theirSkill = pm.Skills[SkillName.Blacksmith].Base;

				if ( theirSkill >= 70.1 )
					pm.NextSmithBulkOrder = TimeSpan.FromHours( 6.0 );
				else if ( theirSkill >= 50.1 )
					pm.NextSmithBulkOrder = TimeSpan.FromHours( 2.0 );
				else
					pm.NextSmithBulkOrder = TimeSpan.FromHours( 1.0 );

				if ( theirSkill >= 70.1 && ((theirSkill - 40.0) / 300.0) > Utility.RandomDouble() )
					return new LargeSmithBOD();

				return SmallSmithBOD.CreateRandomFor( from );
			}

			return null;
		}

		public override bool IsValidBulkOrder( Item item )
		{
			return ( item is SmallSmithBOD || item is LargeSmithBOD );
		}

		public override bool SupportsBulkOrders( Mobile from )
		{
			return ( from is PlayerMobile && from.Skills[SkillName.Blacksmith].Base > 0 );
		}

		public override TimeSpan GetNextBulkOrder( Mobile from )
		{
			if ( from is PlayerMobile )
				return ((PlayerMobile)from).NextSmithBulkOrder;

			return TimeSpan.Zero;
		}

		public override void OnSuccessfulBulkOrderReceive( Mobile from )
		{
			if( Core.SE && from is PlayerMobile )
				((PlayerMobile)from).NextSmithBulkOrder = TimeSpan.Zero;
		}
		#endregion

		public Blacksmith( Serial serial ) : base( serial )
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