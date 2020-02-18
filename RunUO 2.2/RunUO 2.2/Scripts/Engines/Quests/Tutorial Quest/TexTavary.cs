using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Engines.Quests;

namespace Server.Engines.Quests.AlmharaTutorial
{
	public class TexTavary : BaseQuester
	{
		[Constructable]
		public TexTavary() : base( "Your Beginners Strategy Guide" )
		{
		}

		public override void InitBody()
		{
			InitStats( 100, 100, 25 );

			Hue = Utility.RandomSkinHue();

			Female = false;
			Body = 0x190;
                        Name = "Tex Tavary";
		}

		public override void InitOutfit()
		{
			AddItem( new PlateChest() );
			AddItem( new PlateArms() );
			AddItem( new PlateGloves() );
			AddItem( new PlateLegs() );

			Utility.AssignRandomHair( this );
			Utility.AssignRandomFacialHair( this, HairHue );

			Bardiche weapon = new Bardiche();
			weapon.Movable = false;
			AddItem( weapon );
		}

		public override int GetAutoTalkRange( PlayerMobile pm )
		{
			return 3;
		}

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			if ( player.Quest == null && QuestSystem.CanOfferQuest( player, typeof( AlmharaTutorialQuest ) ) )
			{
				Direction = GetDirectionTo( player );

				new AlmharaTutorialQuest( player ).SendOffer();
			}
		}

		public TexTavary( Serial serial ) : base( serial )
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